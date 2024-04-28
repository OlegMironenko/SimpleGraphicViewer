using Microsoft.Extensions.DependencyInjection;
using SimpleGraphicViewer.Core.Models.Abstracts;
using SimpleGraphicViewer.Core.Parsers;
using SimpleGraphicViewer.UI.Services;
using System.ComponentModel;

namespace SimpleGraphicViewer
{
    public partial class MainForm : Form
    {
        private readonly IPrimitiveParser _jsonParser;

        private IEnumerable<PrimitiveBase> _primitives = [];

        public MainForm([FromKeyedServices("JsonParser")] IPrimitiveParser jsonParser)
        {
            _jsonParser = jsonParser;

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

            FileInfo fileInfo = new FileInfo(file);
            using StreamReader fileStream = fileInfo.OpenText();

            _primitives = _jsonParser.Parse(fileStream.ReadToEnd());
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

            float scaleRatio = PainterService.DrawPrimitives(e.Graphics, Size, _primitives);

            ScaleRatioStatusBar.Text = $"Scale: {(int)(1 / scaleRatio * 100)} %";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}