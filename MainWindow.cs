using FtlSaveScummer.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FtlSaveScummer
{
   public partial class MainWindow : Form
   {
      readonly SoundPlayer loadSound = new SoundPlayer(Resources.bell);
      readonly DirectoryInfo ourSaves = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FtlSaveScummer"));

      FileInfo SaveLocation => new FileInfo(Path.Combine(Environment.ExpandEnvironmentVariables(pathBox.Text), "continue.sav"));
      DateTime lastCopy = DateTime.MinValue;
      bool active = false;

      public MainWindow()
      {
         if (!ourSaves.Exists) ourSaves.Create();
         InitializeComponent();

         Text += $" v{Application.ProductVersion.Substring(0, Application.ProductVersion.IndexOf('.'))}";

         void Add(string b) => iconSet.Images.Add(b, (Bitmap)Resources.ResourceManager.GetObject(b));
         string[] iconList = { "laser1", "laser2", "ion", "beam", "missile", "bomb", "drone1", "drone2" };
         foreach (var s in iconList) Add(s);
      }

      FileInfo FileFromLabel(string label) => new FileInfo(Path.Combine(ourSaves.FullName, label.Replace(':', '_') + ".sav"));
      static string LabelFromFile(FileInfo file) => Path.GetFileNameWithoutExtension(file.Name).Replace('_', ':');

      static readonly Regex DefaultName = new Regex("^\\d\\d\\d\\d-\\d\\d-\\d\\d \\d\\d:\\d\\d:\\d\\d$");
      static readonly Regex Tagged = new Regex("\\[(.+)\\]");

      // Both of these only use the selected entry when the window is currently active.  Otherwise (in
      // headless/while-the-game-is-running mode), we should always just use the most recent entries.
      ListViewItem SelectedOrFirstNonDefault => saveList.SelectedItems.Count == 1 && active ? saveList.SelectedItems[0] : (from ListViewItem i in saveList.Items where !DefaultName.IsMatch(i.Text) select i).FirstOrDefault();
      ListViewItem SelectedOrTop => saveList.SelectedItems.Count == 1 && active ? saveList.SelectedItems[0] : (saveList.Items.Count == 0 ? null : saveList.Items[0]);

      void PopulateList()
      {
         string selected = saveList.SelectedItems.Count == 1 ? saveList.SelectedItems[0].Text : null;

         saveList.BeginUpdate();
         saveList.Clear();
         foreach (var save in ourSaves.EnumerateFiles("*.sav"))
         {
            var item = saveList.Items.Add(LabelFromFile(save));

            var match = Tagged.Match(item.Text);
            if (match.Success) item.ImageKey = match.Groups[1].Value;
         }

         if (!string.IsNullOrWhiteSpace(selected))
         {
            var item = saveList.FindItemWithText(selected);
            if (item != null) item.Selected = true;
            saveList.Select();
         }

         saveList.Sort();
         saveList.EndUpdate();
      }

      void MainWindow_Load(object sender, EventArgs e)
      {
         PathBox_TextChanged(this, new EventArgs());
         PopulateList();
      }

      void FileChanged(object sender, FileSystemEventArgs e) => Invoke(new Action(() => updateTimer.Start()));

      void PathBox_TextChanged(object sender, EventArgs e)
      {
         var folder = SaveLocation.DirectoryName;
         if (!Directory.Exists(folder)) return;
         watcher.Path = folder;
      }

      void UpdateTimer_Tick(object sender, EventArgs e)
      {
         var path = SaveLocation;
         if (path == null || !path.Exists) { updateTimer.Enabled = false; return; }

         // Don't echo our own changes back
         var sinceLastCopy = DateTime.UtcNow - lastCopy;
         if (sinceLastCopy.TotalSeconds < 2) { updateTimer.Enabled = false; return; }

         // Wait a little while for the file system to settle down
         var sinceLastWrite = DateTime.UtcNow - path.LastWriteTimeUtc;
         if (sinceLastWrite.TotalMilliseconds < 450) return;

         updateTimer.Enabled = false;

         path.CopyTo(FileFromLabel(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")).FullName, true);
         PopulateList();
      }

      void SaveList_AfterLabelEdit(object sender, LabelEditEventArgs e)
      {
         try
         {
            var before = FileFromLabel(saveList.Items[e.Item].Text);
            if (!before.Exists) return;

            var after = FileFromLabel(e.Label);
            before.MoveTo(after.FullName);

            string imageKey = null;

            var match = Tagged.Match(e.Label);
            if (match.Success) imageKey = match.Groups[1].Value;

            saveList.Items[e.Item].ImageKey = imageKey;

         }
         catch { e.CancelEdit = true; }
      }

      void LoadState(string label)
      {
         if (label == null) return;

         var file = FileFromLabel(label);
         if (!file.Exists) return;

         lastCopy = DateTime.UtcNow;
         file.CopyTo(SaveLocation.FullName, true);
         loadSound.Play();
      }

      void SaveList_ItemActivate(object sender, EventArgs e) => LoadState(saveList.SelectedItems[0].Text);
      void LoadClick(object sender, EventArgs e) => LoadState(SelectedOrFirstNonDefault?.Text ?? null);

      void SaveList_KeyUp(object sender, KeyEventArgs e)
      {
         if (saveList.SelectedItems.Count != 1) return;
         if (e.KeyCode == Keys.F2) { saveList.SelectedItems[0].BeginEdit(); return; }
         if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back) return;

         var file = FileFromLabel(saveList.SelectedItems[0].Text);
         FileSystem.DeleteFile(file.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

         PopulateList();
      }

      private void CleanupClick(object sender, EventArgs e)
      {
         foreach (var save in ourSaves.EnumerateFiles("*.sav"))
            if (DefaultName.IsMatch(LabelFromFile(save))) FileSystem.DeleteFile(save.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

         PopulateList();
      }

      void GlobalUp(object sender, KeyEventArgs e)
      {
         List<string>[,] tags = {
            { new List<string>{ "laser1", "laser2" }, new List<string>{ "ion", "beam" }, new List<string>{ "missile", "bomb" }, new List<string>{ "drone1", "drone2" } },
            { new List<string>{ }, new List<string>{ }, new List<string>{ }, new List<string>{ } },
            { new List<string>{ }, new List<string>{ }, new List<string>{ }, new List<string>{ } }   
         };

         switch (e.KeyCode)
         {
            case Keys.F20:
            case Keys.F21:
            case Keys.F22:
            case Keys.F23:
               int c = e.KeyCode - Keys.F20;
               int r = 0 + (e.Shift ? 1 : 0) + (e.Control ? 1 : 0) - (e.Shift && e.Control ? 1 : 0);

               var tagList = tags[r, c];
               if (tagList.Count == 0) return;
               SetTag(tagList);
               break;

            case Keys.F24:
               if (e.Shift) CleanupClick(sender, e);
               if (e.Control) LoadClick(sender, e);
               break;
         }
      }

      void SetTag(List<string> tagList)
      {
         var item = SelectedOrTop;

         string tag = tagList[0];
         string newLabel = $"{item.Text.Trim()} [{tag}]";

         var match = Tagged.Match(item.Text);
         if (match.Success)
         {
            var g = match.Groups[1];

            tag = tagList[(tagList.IndexOf(g.Value) + 1) % tagList.Count];
            newLabel = $"{item.Text.Substring(0, g.Index)}{tag}{item.Text.Substring(g.Index + g.Length)}";
         }

         var before = FileFromLabel(item.Text);
         if (!before.Exists) return;

         var after = FileFromLabel(newLabel);
         before.MoveTo(after.FullName);

         item.Text = newLabel;
         item.ImageKey = tag;
      }

      void TagClick(object sender, EventArgs e)
      {
         var tag = (string)(sender as Button)?.Tag ?? null;
         if (tag == null) return;

         SetTag(new List<string>{ tag });
      }

      private void ClickOpenBackup(object sender, EventArgs e) => Process.Start(ourSaves.FullName);

      // Keep track of when our whole process goes active/inactive
      protected override void WndProc(ref Message m)
      {
         const int WM_ACTIVATEAPP = 0x1C;
         if (m.Msg == WM_ACTIVATEAPP) active = m.WParam != IntPtr.Zero;

         base.WndProc(ref m);
      }

   }
}
