namespace FtlSaveScummer
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label labelInstructions;
            System.Windows.Forms.Label labelTags;
            System.Windows.Forms.Button buttonCleanup;
            System.Windows.Forms.Button buttonLoad;
            System.Windows.Forms.Button buttonDrone2;
            System.Windows.Forms.Button buttonDrone1;
            System.Windows.Forms.Button buttonBomb;
            System.Windows.Forms.Button buttonMissile;
            System.Windows.Forms.Button buttonBeam;
            System.Windows.Forms.Button buttonIon;
            System.Windows.Forms.Button buttonLaser2;
            System.Windows.Forms.Button buttonLaser1;
            System.Windows.Forms.Button buttonBackupFolder;
            KeyboardListener keyListener;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.saveList = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconSet = new System.Windows.Forms.ImageList(this.components);
            this.pathBox = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.watcher = new System.IO.FileSystemWatcher();
            labelInstructions = new System.Windows.Forms.Label();
            labelTags = new System.Windows.Forms.Label();
            buttonCleanup = new System.Windows.Forms.Button();
            buttonLoad = new System.Windows.Forms.Button();
            buttonDrone2 = new System.Windows.Forms.Button();
            buttonDrone1 = new System.Windows.Forms.Button();
            buttonBomb = new System.Windows.Forms.Button();
            buttonMissile = new System.Windows.Forms.Button();
            buttonBeam = new System.Windows.Forms.Button();
            buttonIon = new System.Windows.Forms.Button();
            buttonLaser2 = new System.Windows.Forms.Button();
            buttonLaser1 = new System.Windows.Forms.Button();
            buttonBackupFolder = new System.Windows.Forms.Button();
            keyListener = new KeyboardListener();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.Location = new System.Drawing.Point(9, 53);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new System.Drawing.Size(177, 13);
            labelInstructions.TabIndex = 0;
            labelInstructions.Text = "Single click to rename; Del to delete";
            // 
            // labelTags
            // 
            labelTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelTags.AutoSize = true;
            labelTags.Location = new System.Drawing.Point(312, 53);
            labelTags.Name = "labelTags";
            labelTags.Size = new System.Drawing.Size(58, 13);
            labelTags.TabIndex = 4;
            labelTags.Text = "Quick tags";
            // 
            // buttonCleanup
            // 
            buttonCleanup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            buttonCleanup.Image = global::FtlSaveScummer.Properties.Resources.broom;
            buttonCleanup.Location = new System.Drawing.Point(315, 676);
            buttonCleanup.Name = "buttonCleanup";
            buttonCleanup.Size = new System.Drawing.Size(64, 64);
            buttonCleanup.TabIndex = 13;
            buttonCleanup.UseVisualStyleBackColor = false;
            buttonCleanup.Click += new System.EventHandler(this.CleanupClick);
            // 
            // buttonLoad
            // 
            buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            buttonLoad.BackColor = System.Drawing.Color.DarkOliveGreen;
            buttonLoad.Image = global::FtlSaveScummer.Properties.Resources.load;
            buttonLoad.Location = new System.Drawing.Point(385, 676);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new System.Drawing.Size(64, 64);
            buttonLoad.TabIndex = 14;
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += new System.EventHandler(this.LoadClick);
            // 
            // buttonDrone2
            // 
            buttonDrone2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonDrone2.Image = global::FtlSaveScummer.Properties.Resources.drone2;
            buttonDrone2.Location = new System.Drawing.Point(385, 231);
            buttonDrone2.Name = "buttonDrone2";
            buttonDrone2.Size = new System.Drawing.Size(64, 48);
            buttonDrone2.TabIndex = 12;
            buttonDrone2.Tag = "drone2";
            buttonDrone2.UseVisualStyleBackColor = true;
            buttonDrone2.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonDrone1
            // 
            buttonDrone1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonDrone1.Image = global::FtlSaveScummer.Properties.Resources.drone1;
            buttonDrone1.Location = new System.Drawing.Point(315, 231);
            buttonDrone1.Name = "buttonDrone1";
            buttonDrone1.Size = new System.Drawing.Size(64, 48);
            buttonDrone1.TabIndex = 11;
            buttonDrone1.Tag = "drone1";
            buttonDrone1.UseVisualStyleBackColor = true;
            buttonDrone1.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonBomb
            // 
            buttonBomb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBomb.Image = global::FtlSaveScummer.Properties.Resources.bomb;
            buttonBomb.Location = new System.Drawing.Point(385, 177);
            buttonBomb.Name = "buttonBomb";
            buttonBomb.Size = new System.Drawing.Size(64, 48);
            buttonBomb.TabIndex = 10;
            buttonBomb.Tag = "bomb";
            buttonBomb.UseVisualStyleBackColor = true;
            buttonBomb.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonMissile
            // 
            buttonMissile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonMissile.Image = global::FtlSaveScummer.Properties.Resources.missile;
            buttonMissile.Location = new System.Drawing.Point(315, 177);
            buttonMissile.Name = "buttonMissile";
            buttonMissile.Size = new System.Drawing.Size(64, 48);
            buttonMissile.TabIndex = 9;
            buttonMissile.Tag = "missile";
            buttonMissile.UseVisualStyleBackColor = true;
            buttonMissile.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonBeam
            // 
            buttonBeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBeam.Image = global::FtlSaveScummer.Properties.Resources.beam;
            buttonBeam.Location = new System.Drawing.Point(385, 123);
            buttonBeam.Name = "buttonBeam";
            buttonBeam.Size = new System.Drawing.Size(64, 48);
            buttonBeam.TabIndex = 8;
            buttonBeam.Tag = "beam";
            buttonBeam.UseVisualStyleBackColor = true;
            buttonBeam.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonIon
            // 
            buttonIon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonIon.Image = global::FtlSaveScummer.Properties.Resources.ion;
            buttonIon.Location = new System.Drawing.Point(315, 123);
            buttonIon.Name = "buttonIon";
            buttonIon.Size = new System.Drawing.Size(64, 48);
            buttonIon.TabIndex = 7;
            buttonIon.Tag = "ion";
            buttonIon.UseVisualStyleBackColor = true;
            buttonIon.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonLaser2
            // 
            buttonLaser2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonLaser2.Image = global::FtlSaveScummer.Properties.Resources.laser2;
            buttonLaser2.Location = new System.Drawing.Point(385, 69);
            buttonLaser2.Name = "buttonLaser2";
            buttonLaser2.Size = new System.Drawing.Size(64, 48);
            buttonLaser2.TabIndex = 6;
            buttonLaser2.Tag = "laser2";
            buttonLaser2.UseVisualStyleBackColor = true;
            buttonLaser2.Click += new System.EventHandler(this.TagClick);
            // 
            // buttonLaser1
            // 
            buttonLaser1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonLaser1.Image = global::FtlSaveScummer.Properties.Resources.laser1;
            buttonLaser1.Location = new System.Drawing.Point(315, 69);
            buttonLaser1.Name = "buttonLaser1";
            buttonLaser1.Size = new System.Drawing.Size(64, 48);
            buttonLaser1.TabIndex = 5;
            buttonLaser1.Tag = "laser1";
            buttonLaser1.UseVisualStyleBackColor = true;
            buttonLaser1.Click += new System.EventHandler(this.TagClick);
            // 
            // saveList
            // 
            this.saveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
            this.saveList.HideSelection = false;
            this.saveList.LabelEdit = true;
            this.saveList.LabelWrap = false;
            this.saveList.LargeImageList = this.iconSet;
            this.saveList.Location = new System.Drawing.Point(12, 69);
            this.saveList.MultiSelect = false;
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(284, 671);
            this.saveList.SmallImageList = this.iconSet;
            this.saveList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.saveList.TabIndex = 1;
            this.saveList.UseCompatibleStateImageBehavior = false;
            this.saveList.View = System.Windows.Forms.View.List;
            this.saveList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.SaveList_AfterLabelEdit);
            this.saveList.ItemActivate += new System.EventHandler(this.SaveList_ItemActivate);
            this.saveList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SaveList_KeyUp);
            // 
            // columnName
            // 
            this.columnName.Text = "Save Games";
            this.columnName.Width = 395;
            // 
            // iconSet
            // 
            this.iconSet.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconSet.ImageSize = new System.Drawing.Size(64, 32);
            this.iconSet.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pathBox
            // 
            this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathBox.Location = new System.Drawing.Point(12, 12);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(284, 20);
            this.pathBox.TabIndex = 2;
            this.pathBox.Text = "%userprofile%\\Documents\\My Games\\FasterThanLight";
            this.pathBox.TextChanged += new System.EventHandler(this.PathBox_TextChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 250;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // watcher
            // 
            this.watcher.EnableRaisingEvents = true;
            this.watcher.Filter = "continue.sav";
            this.watcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.watcher.SynchronizingObject = this;
            this.watcher.Changed += new System.IO.FileSystemEventHandler(this.FileChanged);
            // 
            // buttonBackupFolder
            // 
            buttonBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBackupFolder.Location = new System.Drawing.Point(315, 10);
            buttonBackupFolder.Name = "buttonBackupFolder";
            buttonBackupFolder.Size = new System.Drawing.Size(134, 23);
            buttonBackupFolder.TabIndex = 3;
            buttonBackupFolder.Text = "Open backup folder";
            buttonBackupFolder.UseVisualStyleBackColor = true;
            buttonBackupFolder.Click += new System.EventHandler(this.ClickOpenBackup);
            // 
            // keyListener
            // 
            keyListener.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GlobalUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 752);
            this.Controls.Add(buttonBackupFolder);
            this.Controls.Add(buttonCleanup);
            this.Controls.Add(buttonLoad);
            this.Controls.Add(labelTags);
            this.Controls.Add(buttonDrone2);
            this.Controls.Add(buttonDrone1);
            this.Controls.Add(buttonBomb);
            this.Controls.Add(buttonMissile);
            this.Controls.Add(buttonBeam);
            this.Controls.Add(buttonIon);
            this.Controls.Add(buttonLaser2);
            this.Controls.Add(buttonLaser1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.saveList);
            this.Controls.Add(labelInstructions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "MainWindow";
            this.Text = "FTL Save Scummer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

      #endregion
      private System.Windows.Forms.ListView saveList;
      private System.Windows.Forms.ColumnHeader columnName;
      private System.Windows.Forms.TextBox pathBox;
      private System.Windows.Forms.Timer updateTimer;
      private System.IO.FileSystemWatcher watcher;
      private System.Windows.Forms.ImageList iconSet;
   }
}

