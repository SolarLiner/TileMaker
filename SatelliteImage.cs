using System;
using System.Drawing;

namespace TileMaker
{
    internal class SatelliteImage
    {
        private Bitmap _bmp;
        private RectangleF span;
        private Planet _body;

        public Tile.TileSpan Span;
        public Rectangle CroppedRectangle;
        public int Level
        {
            get
            {
                return CalculateBestLevel();
            }
        }

        public SatelliteImage(PointF topLeft, PointF bottomRight, Image image, Planet body)
        {
            SizeF size = new SizeF(Math.Abs(topLeft.X - bottomRight.X), Math.Abs(topLeft.Y - bottomRight.Y));
            span = new RectangleF(topLeft, size);
            this._bmp = new Bitmap(image);
            this._body = body;

            CroppedRectangle = new Rectangle(0, 0, Misc.GetNextDividibleBy512(image.Width), Misc.GetNextDividibleBy512(image.Height));

            double circ = 2 * Math.PI * body.Radius;
            double height = (span.Height / 360.0) * circ;

            // Latitude in radians of the northern edge
            double northrad = (span.Top / 180) * Math.PI;
            // Latitude in radians of the southern edge
            double southrad = (span.Bottom / 180) * Math.PI;

            double nSpan = (span.Width / 360.0) * circ * Math.Cos(northrad);
            double sSpan = (span.Width / 360.0) * circ * Math.Cos(southrad);

            Span = new Tile.TileSpan() { NorthSpan = nSpan, SouthSpan = sSpan, VerticalSpan = height };
        }

        public Tile GetUpperLeftTile(int Level)
        {
            return Tile.GetUnderlyingTile(Level, span.Location);
        }

        public int CalculateBestLevel()
        {
            double VertDegPerPx = span.Height / (double)_bmp.Height;
            int i = 0;
            double value = 360d / Math.Pow(2, 10 + i);
            while (value - (512 * VertDegPerPx) > 0)
            {
                i++;
                value = 360d / Math.Pow(2, 10 + i);
            }

            return i;
        }
    }
}