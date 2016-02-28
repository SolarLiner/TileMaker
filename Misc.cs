using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TileMaker
{
    public static class Misc
    {
        public static ColorScheme GetMatchingTheme(Color[] cols)
        {
            Primary P, LP, DP;
            Accent A;

            Color sel = cols[1].RemoveAlpha();
            List<Primary> prims = new List<Primary>((Primary[])Enum.GetValues(typeof(Primary))).ToList();
            P = prims.Aggregate((x,y) =>
            {
                Color p = ((int)x).ToColor();
                Color q = ((int)y).ToColor();
                double magP = p.R + p.G + p.B;
                double magQ = q.R + q.G + q.B;
                double magS = sel.R + sel.G + sel.B;

                return (Math.Abs(magP - magS) < Math.Abs(magQ - magS) ? x : y);
            });

            sel = cols[2].RemoveAlpha();
            LP = prims.Aggregate((x, y) =>
            {
                Color p = ((int)x).ToColor();
                Color q = ((int)y).ToColor();
                double magP = p.R + p.G + p.B;
                double magQ = q.R + q.G + q.B;
                double magS = sel.R + sel.G + sel.B;

                return (Math.Abs(magP - magS) < Math.Abs(magQ - magS) ? x : y);
            });

            sel = cols[3].RemoveAlpha();
            DP = prims.Aggregate((x, y) =>
            {
                Color p = ((int)x).ToColor();
                Color q = ((int)y).ToColor();
                double magP = p.R + p.G + p.B;
                double magQ = q.R + q.G + q.B;
                double magS = sel.R + sel.G + sel.B;

                return (Math.Abs(magP - magS) < Math.Abs(magQ - magS) ? x : y);
            });

            sel = cols[0].RemoveAlpha();
            List<Accent> acc = new List<Accent>((Accent[])Enum.GetValues(typeof(Accent))).ToList();
            A = acc.Aggregate((x, y) =>
            {
                Color p = ((int)x).ToColor();
                Color q = ((int)y).ToColor();
                double magP = p.R + p.G + p.B;
                double magQ = q.R + q.G + q.B;
                double magS = sel.R + sel.G + sel.B;

                return (Math.Abs(magP - magS) < Math.Abs(magQ - magS) ? x : y);
            });

            return new ColorScheme(P, DP, LP, A, TextShade.BLACK);
        }

        public static int GetNextPowerOf2(double x)
        {
            int power = (int)Math.Ceiling(Math.Log(x, 2));
            return (int)Math.Pow(2, power);
        }

        public static int GetNextDividibleBy512(double x)
        {
            double coeff = x / 512.0;
            return (int)Math.Ceiling(coeff) * 512;
        }

        internal static object FormatBest(double x, string format, string unit)
        {
            char[] SI_Units = "yzafpnum kMGTPEZY".ToCharArray();

            sbyte count = 8;
            if (Math.Abs(x) < 1)
            {
                do
                {
                    count--;
                    x *= 1000;
                } while (Math.Abs(x) < 1 && count > 0);
            }
            else if (Math.Abs(x) > 1000)
            {
                do
                {
                    count++;
                    x /= 1000;
                } while (Math.Abs(x) > 1000 && count < 16);
            }
            else
            {
                return x.ToString(format) + " " + unit;
            }

            return x.ToString(format) + " " + SI_Units[count] + unit;
        }
    }
}
