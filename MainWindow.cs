﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Windows.Forms;

namespace FtlSaveScummer
{
   public partial class MainWindow : Form
   {
      DirectoryInfo ourSaves = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FtlSaveScummer"));
      FileInfo saveLocation;
      FileSystemWatcher watcher;
      DateTime lastCopy = DateTime.MinValue;

      public MainWindow()
      {
         if (!ourSaves.Exists) ourSaves.Create();
         InitializeComponent();
      }

      FileInfo FileFromLabel(string label) { return new FileInfo(Path.Combine(ourSaves.FullName, label.Replace(':', '_') + ".sav")); }
      static string LabelFromFile(FileInfo file) { return file.Name.Substring(0, file.Name.Length - file.Extension.Length).Replace('_', ':'); }

      void PopulateList()
      {
         string selected = saveList.SelectedItems.Count == 1 ? saveList.SelectedItems[0].Text : null;

         saveList.BeginUpdate();
         saveList.Clear();
         foreach (var save in ourSaves.EnumerateFiles("*.sav")) saveList.Items.Add(LabelFromFile(save));

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
         pathBox_TextChanged(this, new EventArgs());
         PopulateList();
      }

      void fileChanged(object sender, FileSystemEventArgs e) { Invoke(new Action(()=>updateTimer.Start())); }

      void pathBox_TextChanged(object sender, EventArgs e)
      {
         if (watcher != null) watcher.EnableRaisingEvents = false;
         watcher = null;

         var file = new FileInfo(Environment.ExpandEnvironmentVariables(pathBox.Text));
         if (!file.Exists) return;
         saveLocation = file;

         watcher = new FileSystemWatcher(file.DirectoryName, file.Name);
         watcher.NotifyFilter = NotifyFilters.LastWrite;
         watcher.Changed += fileChanged;
         watcher.EnableRaisingEvents = true;
      }

      void updateTimer_Tick(object sender, EventArgs e)
      {
         if (saveLocation == null || !saveLocation.Exists) { updateTimer.Enabled = false; return; }

         // Don't echo our own changes back
         var sinceLastCopy = DateTime.UtcNow - lastCopy;
         if (sinceLastCopy.TotalSeconds < 2) { updateTimer.Enabled = false; return; }

         // Wait a little while for the file system to settle down
         var sinceLastWrite = DateTime.UtcNow - saveLocation.LastWriteTimeUtc;
         if (sinceLastWrite.TotalMilliseconds < 450) return;

         updateTimer.Enabled = false;

         saveLocation.CopyTo(FileFromLabel(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")).FullName, true);
         PopulateList();
      }

      void saveList_AfterLabelEdit(object sender, LabelEditEventArgs e)
      {
         try
         {
            var before = FileFromLabel(saveList.Items[e.Item].Text);
            if (!before.Exists) return;

            var after = FileFromLabel(e.Label);
            before.MoveTo(after.FullName);
         }
         catch { e.CancelEdit = true; }
      }

      void saveList_ItemActivate(object sender, EventArgs e)
      {
         var activated = FileFromLabel(saveList.SelectedItems[0].Text);
         if (!activated.Exists) return;

         lastCopy = DateTime.UtcNow;
         activated.CopyTo(saveLocation.FullName, true);
      }

      void saveList_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back) return;
         if (saveList.SelectedItems.Count != 1) return;

         var file = FileFromLabel(saveList.SelectedItems[0].Text);
         FileSystem.DeleteFile(file.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

         PopulateList();
      }
   }
}