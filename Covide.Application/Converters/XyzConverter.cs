using Covide.Application.Interfaces;
using System;

namespace Covide.Application.Converters
{
    public class XyzConverter : IXyzConverter
    {
        public double[] Convert(double r, double g, double b)
        {
            r = Pivot(r);
            g = Pivot(g);
            b = Pivot(b);

            r *= 100;
            g *= 100;
            b *= 100;

            double x = r * 0.4124 + g * 0.3576 + b * 0.1805;
            double y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            double z = r * 0.0193 + g * 0.1192 + b * 0.9505;

            return new[]
            {
                Math.Round(x, 3),
                Math.Round(y, 3),
                Math.Round(z, 3)
            };
        }

        private double Pivot(double value)
        {
            return value > 0.04045
                ? Math.Pow((value + 0.055) / 1.055, 2.4)
                : value / 12.92;
        }
    }
}