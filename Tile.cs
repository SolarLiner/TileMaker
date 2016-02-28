using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TileMaker
{
    public class Tile
    {
        /// <summary>
        /// Struct that allows storage of tile vertical and horizontal span
        /// </summary>
        public struct TileSpan
        {
            public double NorthSpan { get; set; }
            public double SouthSpan { get; set; }
            public double VerticalSpan { get; set; }
        }

        /// <summary>
        /// Tile number, X is Longitude and Y is Latitude.
        /// </summary>
        public Point Coordinates { get; private set; }

        /// <summary>
        /// Level of Detail of the tile, from 0 being the less detailed one.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Body that owns the tile.
        /// </summary>
        public Planet Body { get; private set; }

        /// <summary>
        /// Calculates the tile span
        /// </summary>
        public TileSpan Span
        {
            get
            {
                return CalculateSpan(Body, Level, Coordinates);
            }
        }

        /// <summary>
        /// Returns the latitude/longitude bounds of the tile
        /// </summary>
        public RectangleF Bounds
        {
            get
            {
                RectangleF r = new RectangleF();
                // Upper-left corner
                r.X = (float)( Coordinates.X    * (180.0 / Math.Pow(2, 11 + Level)));
                r.Y = (float)((Coordinates.Y+1) * ( 90.0 / Math.Pow(2, 10 + Level)));

                // Bottom-right corner
                float bX = (float)((Coordinates.X+1) * (180.0 / Math.Pow(2, 11 + Level)));
                float bY = (float)( Coordinates.Y    * ( 90.0 / Math.Pow(2, 10 + Level)));

                r.Width = Math.Abs(bX - r.X);
                r.Height = Math.Abs(bY - r.Y);

                return r;
            }
        }

        public Tile(Point Coordinates, int Level, Planet Body)
        {
            this.Coordinates = Coordinates;
            this.Level = Level;
            this.Body = Body;
        }
        public Tile(Point Coordinates, int Level)
        {
            this.Coordinates = Coordinates;
            this.Level = Level;
            this.Body = Planet.Irrelevant;
        }
        public Tile()
        {
            this.Coordinates = new Point();
            this.Level = 1;
            this.Body = Planet.Irrelevant;
        }

        public void SetCoordinates(Point Coordinates)
        {
            SetCoordinates(Coordinates.X, Coordinates.Y);
        }
        public void SetCoordinates(int x, int y)
        {
            while (x < -1 * Math.Pow(2, 11 + Level))
                x += (int)Math.Pow(2, 11 + Level);
            while (x > Math.Pow(2, 11 + Level))
                x -= (int)Math.Pow(2, 11 + Level);

            while (y < -1 * Math.Pow(2, 10 + Level))
                y += (int)Math.Pow(2, 10 + Level);
            while (y > Math.Pow(2, 10 + Level))
                y -= (int)Math.Pow(2, 10 + Level);

            this.Coordinates = new Point(x, y);
        }

        public void CalculateLevel(TileSpan span)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string LatLetter = Coordinates.Y < 0 ? "S" : "N";
            string LonLetter = Coordinates.X < 0 ? "W" : "E";

            return string.Format("{0}{1:0000} {2}{3:0000} (Level {4})", LatLetter, Math.Abs(Coordinates.Y), LonLetter, Math.Abs(Coordinates.X), Level);
        }

        public static TileSpan CalculateSpan(Planet planet, int Level, Point Coords)
        {
            double h = (Math.PI * planet.Radius) / Math.Pow(2, Level + 8);
            double south = h * Math.Sin(Math.PI * (0.5 - (Math.Abs(Coords.Y) / Math.Pow(2, Level + 8))));
            double north = h * Math.Sin(Math.PI * (0.5 - (Math.Abs(Coords.Y+1) / Math.Pow(2, Level + 8))));

            return new TileSpan() { NorthSpan = north, SouthSpan = south, VerticalSpan = h };
        }

        public static Tile GetUnderlyingTile(int Level, PointF point)
        {
            int TileX = (int)Math.Floor(point.X * (Math.Pow(2, 11 + Level)));
            int TileY = (int)Math.Floor(point.Y * (Math.Pow(2, 10 + Level)));

            return new Tile(new Point(TileX, TileY), Level);
        }
    }
}