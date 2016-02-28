using System;
using System.Drawing;

namespace TileMaker
{
    internal class SatelliteImage
    {
        private Bitmap _bmp;
        private RectangleF _span;
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
            this._span = new RectangleF(topLeft, size);
            this._bmp = new Bitmap(image);
            this._body = body;

            double VerticalDegPerPx = _span.Height / _bmp.Height;
            double HorizontalDegPerPx = _span.Width / _bmp.Width;

            RectangleF Composite = GetCompositeRectangle();
            CroppedRectangle = new Rectangle();
            CroppedRectangle.X = (int)((Composite.X - topLeft.X) / HorizontalDegPerPx);
            CroppedRectangle.Y = (int)((Composite.Y - topLeft.Y) / VerticalDegPerPx);
            CroppedRectangle.Width = (int)(Composite.Width / HorizontalDegPerPx);
            CroppedRectangle.Height = (int)(Composite.Height / VerticalDegPerPx);

            double circ = 2 * Math.PI * body.Radius;
            double height = (_span.Height / 360.0) * circ;

            // Latitude in radians of the northern edge
            double northrad = (_span.Top / 180) * Math.PI;
            // Latitude in radians of the southern edge
            double southrad = (_span.Bottom / 180) * Math.PI;

            double nSpan = (_span.Width / 360.0) * circ * Math.Cos(northrad);
            double sSpan = (_span.Width / 360.0) * circ * Math.Cos(southrad);

            Span = new Tile.TileSpan() { NorthSpan = nSpan, SouthSpan = sSpan, VerticalSpan = height };
        }

        public Tile GetUpperLeftTile(int Level)
        {
            return Tile.GetUnderlyingTile(Level, _span.Location);
        }
        public Tile GetUpperLeftTile()
        {
            return GetUpperLeftTile(this.Level);
        }

        public Tile GetLowerRightTile(int Level)
        {
            PointF BottomRight = new PointF(_span.Right, _span.Bottom);
            return Tile.GetUnderlyingTile(Level, BottomRight);
        }
        public Tile GetLowerRightTile()
        {
            return GetLowerRightTile(this.Level);
        }

        public RectangleF GetCompositeRectangle()
        {
            PointF Location = GetUpperLeftTile().Bounds.Location;

            Tile LowerRight = GetLowerRightTile();
            SizeF Size = new SizeF();
            Size.Width = (LowerRight.Bounds.X + LowerRight.Bounds.Width) - Location.X;
            Size.Height = (LowerRight.Bounds.Y + LowerRight.Bounds.Height) - Location.Y;

            return new RectangleF(Location, Size);
        }

        public int CalculateBestLevel()
        {
            double VertDegPerPx = _span.Height / (double)_bmp.Height;
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