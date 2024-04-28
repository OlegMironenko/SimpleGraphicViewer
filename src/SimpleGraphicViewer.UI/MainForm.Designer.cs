namespace SimpleGraphicViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            OpenFileDialog = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            CoordinateStatusBar = new ToolStripStatusLabel();
            ScaleRatioStatusBar = new ToolStripStatusLabel();
            MainMenu.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.ImageScalingSize = new Size(24, 24);
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(800, 33);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(270, 34);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitToolStripMenuItem.Size = new Size(270, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog";
            OpenFileDialog.FileOk += OpenFileDialog_FileOK;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { CoordinateStatusBar, ScaleRatioStatusBar });
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // CoordinateStatusBar
            // 
            CoordinateStatusBar.BorderSides = ToolStripStatusLabelBorderSides.Right;
            CoordinateStatusBar.Name = "CoordinateStatusBar";
            CoordinateStatusBar.Size = new Size(4, 15);
            // 
            // ScaleRatioStatusBar
            // 
            ScaleRatioStatusBar.Alignment = ToolStripItemAlignment.Right;
            ScaleRatioStatusBar.BorderSides = ToolStripStatusLabelBorderSides.Left;
            ScaleRatioStatusBar.Name = "ScaleRatioStatusBar";
            ScaleRatioStatusBar.Size = new Size(4, 15);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(MainMenu);
            MainMenuStrip = MainMenu;
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            Paint += MainForm_Paint;
            MouseMove += MainForm_MouseEnter;
            Resize += MainForm_Resize;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private OpenFileDialog OpenFileDialog;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel CoordinateStatusBar;
        private ToolStripStatusLabel ScaleRatioStatusBar;
    }
}
