using System.ComponentModel;
using SimpleGraphicViewer.Core.Abstracts;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI;

public partial class MainForm : Form
{
    private readonly ISourceFileParserContext _sourceFileParserContext;

    private IEnumerable<PrimitiveBase> _primitives = [];

    public MainForm(ISourceFileParserContext sourceFileParserContext)
    {
        _sourceFileParserContext = sourceFileParserContext;

        InitializeComponent();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog.ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void OpenFileDialog_FileOK(object sender, CancelEventArgs e)
    {
        Activate();
        Invalidate();
        AutoScroll = true;

        string? file = OpenFileDialog.FileNames.FirstOrDefault();

        if (string.IsNullOrEmpty(file))
        {
            return;
        }

        FileInfo fileInfo = new(file);
        using StreamReader fileStream = fileInfo.OpenText();

        ISourceFileParser fileParser = _sourceFileParserContext.GetConcreteParser(fileInfo.Extension);
        _primitives = fileParser.Parse(fileStream.ReadToEnd());
    }

    private void MainForm_MouseEnter(object sender, EventArgs e)
    {
        Point mousePosition = CoordinateTransformer.ShiftDisplayed(Cursor.Position
            , Size.Width / 2, Size.Height / 2);

        CoordinateStatusBar.Text = $"X: {mousePosition.X}; Y: {mousePosition.Y};";
    }

    private void MainForm_Paint(object sender, PaintEventArgs e)
    {
        if (!_primitives.Any())
        {
            return;
        }

        Size actualDrawableArea = new(Size.Width, Size.Height);
        //MainMenuStrip.Height;

        float scaleRatio = PainterService.DrawPrimitives(e.Graphics, Size, 0, _primitives);

        ScaleRatioStatusBar.Text = $"Scale: {(int)(1 / scaleRatio * 100)} %";
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        Invalidate();
    }
}