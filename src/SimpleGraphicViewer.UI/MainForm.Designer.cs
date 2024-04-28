using SimpleGraphicViewer.Core.Constants;

namespace SimpleGraphicViewer.UI;

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
        mainMenu = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        openFileDialog = new OpenFileDialog();
        statusStrip = new StatusStrip();
        coordinateStatusBar = new ToolStripStatusLabel();
        scaleRatioStatusBar = new ToolStripStatusLabel();
        mainMenu.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // mainMenu
        // 
        mainMenu.ImageScalingSize = new Size(24, 24);
        mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        mainMenu.Location = new Point(0, 0);
        mainMenu.Name = "mainMenu";
        mainMenu.Size = new Size(800, 33);
        mainMenu.TabIndex = 0;
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
        // openFileDialog
        // 
        openFileDialog.Filter = $"JSON file|*{AllowedFileExtensions.JSON}";
        openFileDialog.FileOk += openFileDialog_FileOK;
        // 
        // statusStrip
        // 
        statusStrip.ImageScalingSize = new Size(24, 24);
        statusStrip.Items.AddRange(new ToolStripItem[] { coordinateStatusBar, scaleRatioStatusBar });
        statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        statusStrip.Location = new Point(0, 428);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(800, 22);
        statusStrip.TabIndex = 1;
        statusStrip.Text = "statusStrip";
        // 
        // coordinateStatusBar
        // 
        coordinateStatusBar.BorderSides = ToolStripStatusLabelBorderSides.Right;
        coordinateStatusBar.Name = "coordinateStatusBar";
        coordinateStatusBar.Size = new Size(4, 15);
        // 
        // scaleRatioStatusBar
        // 
        scaleRatioStatusBar.Alignment = ToolStripItemAlignment.Right;
        scaleRatioStatusBar.BorderSides = ToolStripStatusLabelBorderSides.Left;
        scaleRatioStatusBar.Name = "scaleRatioStatusBar";
        scaleRatioStatusBar.Size = new Size(4, 15);
        // 
        // mainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(statusStrip);
        Controls.Add(mainMenu);
        MainMenuStrip = mainMenu;
        Name = "mainForm";
        StartPosition = FormStartPosition.Manual;
        Paint += mainForm_Paint;
        MouseMove += mainForm_MouseEnter;
        Resize += mainForm_Resize;
        mainMenu.ResumeLayout(false);
        mainMenu.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip mainMenu;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private OpenFileDialog openFileDialog;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel coordinateStatusBar;
    private ToolStripStatusLabel scaleRatioStatusBar;
}
