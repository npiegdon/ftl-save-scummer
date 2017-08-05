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
         this.labelInstructions = new System.Windows.Forms.Label();
         this.saveList = new System.Windows.Forms.ListView();
         this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.pathBox = new System.Windows.Forms.TextBox();
         this.updateTimer = new System.Windows.Forms.Timer(this.components);
         this.fileTimer = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // labelInstructions
         // 
         this.labelInstructions.AutoSize = true;
         this.labelInstructions.Location = new System.Drawing.Point(12, 55);
         this.labelInstructions.Name = "labelInstructions";
         this.labelInstructions.Size = new System.Drawing.Size(370, 13);
         this.labelInstructions.TabIndex = 0;
         this.labelInstructions.Text = "Double-click (while on FTL main menu) to load; Click to rename; Del to delete";
         // 
         // saveList
         // 
         this.saveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.saveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
         this.saveList.LabelEdit = true;
         this.saveList.LabelWrap = false;
         this.saveList.Location = new System.Drawing.Point(12, 85);
         this.saveList.MultiSelect = false;
         this.saveList.Name = "saveList";
         this.saveList.Size = new System.Drawing.Size(370, 719);
         this.saveList.Sorting = System.Windows.Forms.SortOrder.Descending;
         this.saveList.TabIndex = 1;
         this.saveList.UseCompatibleStateImageBehavior = false;
         this.saveList.View = System.Windows.Forms.View.List;
         this.saveList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.saveList_AfterLabelEdit);
         this.saveList.ItemActivate += new System.EventHandler(this.saveList_ItemActivate);
         this.saveList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.saveList_KeyUp);
         // 
         // columnName
         // 
         this.columnName.Text = "Save Games";
         this.columnName.Width = 395;
         // 
         // pathBox
         // 
         this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.pathBox.Location = new System.Drawing.Point(12, 12);
         this.pathBox.Name = "pathBox";
         this.pathBox.Size = new System.Drawing.Size(370, 20);
         this.pathBox.TabIndex = 2;
         this.pathBox.Text = "%userprofile%\\Documents\\My Games\\FasterThanLight";
         this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
         // 
         // updateTimer
         // 
         this.updateTimer.Interval = 250;
         this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
         // 
         // fileTimer
         // 
         this.fileTimer.Interval = 1000;
         this.fileTimer.Tick += new System.EventHandler(this.fileTimer_Tick);
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(394, 816);
         this.Controls.Add(this.pathBox);
         this.Controls.Add(this.saveList);
         this.Controls.Add(this.labelInstructions);
         this.MinimumSize = new System.Drawing.Size(200, 200);
         this.Name = "MainWindow";
         this.Text = "FTL Save Manager";
         this.Load += new System.EventHandler(this.MainWindow_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

		}

      #endregion

      private System.Windows.Forms.Label labelInstructions;
      private System.Windows.Forms.ListView saveList;
      private System.Windows.Forms.ColumnHeader columnName;
      private System.Windows.Forms.TextBox pathBox;
      private System.Windows.Forms.Timer updateTimer;
      private System.Windows.Forms.Timer fileTimer;
   }
}

