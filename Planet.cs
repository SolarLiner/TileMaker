using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMaker
{
    public class Planet
    {
        /// <summary>
        /// The radius of the planet, in meters.
        /// </summary>
        public int Radius { get; private set; }

        public Planet(int radius)
        {
            Radius = radius;
        }

        public Planet()
        {
            Radius = 1;
        }

        public static readonly Planet Irrelevant = new Planet(-1);
    }
}
