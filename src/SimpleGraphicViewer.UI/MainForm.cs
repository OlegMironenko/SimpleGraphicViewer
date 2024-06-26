using System.ComponentModel;
using SimpleGraphicViewer.Core.Abstracts;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.UI.Services;

namespace SimpleGraphicViewer.UI;

public partial class MainForm : Form
{
    private readonly ISourceFileParserContext _sourceFileParserContext;

    private List<PrimitiveBase> _primitives = [];

    public MainForm(ISourceFileParserContext sourceFileParserContext)
    {
        _sourceFileParserContext = sourceFileParserContext;

        InitializeComponent();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        openFileDialog.ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void openFileDialog_FileOK(object sender, CancelEventArgs e)
    {
        Activate();
        Invalidate();

        string? file = openFileDialog.FileNames.FirstOrDefault();

        if (string.IsNullOrEmpty(file))
        {
            return;
        }

        FileInfo fileInfo = new(file);
        using StreamReader fileStream = fileInfo.OpenText();

        ISourceFileParser fileParser = _sourceFileParserContext.GetConcreteParser(fileInfo.Extension);
        _primitives = fileParser.Parse(fileStream.ReadToEnd()).ToList();
    }

    private void mainForm_MouseEnter(object sender, EventArgs e)
    {
        // Point mousePosition = CoordinateTransformer.ShiftDisplayed(Cursor.Position
        //     , Size.Width / 2, Size.Height / 2);

        Point mousePosition = Cursor.Position;

        coordinateStatusBar.Text = $"X: {mousePosition.X}; Y: {mousePosition.Y};";
    }

    private void mainForm_Paint(object sender, PaintEventArgs e)
    {
        if (!_primitives.Any())
        {
            return;
        }

        float scaleRatio = PainterService.DrawPrimitives(e.Graphics, Size, mainMenu.Height, _primitives);

        scaleRatioStatusBar.Text = $"Scale: {(int)(1 / scaleRatio * 100)} %";
    }

    private void mainForm_Resize(object sender, EventArgs e)
    {
        Invalidate();
    }
}