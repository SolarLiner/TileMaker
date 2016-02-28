using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TileMaker
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            Program.MSM.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue800, Accent.Orange400, TextShade.WHITE);
            Program.MSM.AddFormToManage(this);
        }

        private void BT_OpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.bmp;*.png;*.tiff";
            ofd.Title = "Open aerial imagery...";
            ofd.ShowReadOnly = false;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            PB_Image.ImageLocation = ofd.FileName;
            PB_Image.LoadProgressChanged += (s, ev) =>
            {
                LB_ImagePath.Text = string.Format("Loading \"{0}\" ({1} %)", ofd.FileName, ev.ProgressPercentage);
                //Application.DoEvents();
            };
            PB_Image.LoadCompleted += (s, ev) =>
            {
                LB_ImagePath.Text = string.Format("{0} ({1}x{2}, {3})", ofd.FileName, PB_Image.Image.Width, PB_Image.Image.Height, PB_Image.Image.PixelFormat.ToString());
                Size NewDimensions = PB_Image.Image.Size;
                NewDimensions.Height = Misc.GetNextDividibleBy512(NewDimensions.Height);
                NewDimensions.Width = Misc.GetNextDividibleBy512(NewDimensions.Width);
                LB_ImageInfo.Text = string.Format("Cropped dimensions: {0}x{1}", NewDimensions.Width, NewDimensions.Height);
                LB_ImageInfo.Visible = true;
            };
        }

        private void BT_Compute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_East.Text)
                || string.IsNullOrWhiteSpace(TB_North.Text)
                || string.IsNullOrWhiteSpace(TB_South.Text)
                || string.IsNullOrWhiteSpace(TB_West.Text))
               return;

            // Assuming Earth for the moment
            Planet Earth = new Planet(6371010);

            try {
                PointF TopLeft = new PointF(float.Parse(TB_West.Text), float.Parse(TB_North.Text));
                PointF BottomRight = new PointF(float.Parse(TB_East.Text), float.Parse(TB_South.Text));
                SatelliteImage img = new SatelliteImage(TopLeft, BottomRight, PB_Image.Image, Earth);
                Tile TileUpperLeft = img.GetUpperLeftTile();


                LB_ImageInfo.Text = string.Format("Vertical Span: {0} | North Span: {1} | South Span: {2}\nFirst tile: {3} | Cropped Image: X{4} Y{5} - {6}x{7}",
                    Misc.FormatBest(img.Span.VerticalSpan, "0.00", "m"), Misc.FormatBest(img.Span.NorthSpan, "0.00", "m"), Misc.FormatBest(img.Span.SouthSpan, "0.00", "m"),
                    TileUpperLeft, img.CroppedRectangle.X, img.CroppedRectangle.Y, img.CroppedRectangle.Width, img.CroppedRectangle.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease enter decimal values only in the text boxes.", ex.Source + " error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}