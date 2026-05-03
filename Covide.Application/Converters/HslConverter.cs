using Covide.Application.Interfaces;
using System;

namespace Covide.Application.Converters
{
    public class HslConverter : IHslConverter
    {
        public double[] Convert(double r, double g, double b)
        {
            double cmax = Math.Max(r, Math.Max(g, b));
            double cmin = Math.Min(r, Math.Min(g, b));
            double delta = cmax - cmin;

            double hue = CalculateHue(r, g, b, cmax, delta);
            double lightness = (cmax + cmin) / 2;
            double saturation = CalculateSaturation(delta, lightness);

            return new[]
            {
                Math.Round(hue),
                Math.Round(saturation * 100, 1),
                Math.Round(lightness * 100, 1)
            };
        }

        private double CalculateHue(double r, double g, double b, double cmax, double delta)
        {
            if (delta == 0)
                return 0;

            double hue;

            if (cmax == r)
                hue = ((g - b) / delta) % 6;
            else if (cmax == g)
                hue = (b - r) / delta + 2;
            else
                hue = (r - g) / delta + 4;

            hue *= 60;

            if (hue < 0)
                hue += 360;

            return hue;
        }

        private double CalculateSaturation(double delta, double lightness)
        {
            if (delta == 0)
                return 0;

            return delta / (1 - Math.Abs(2 * lightness - 1));
        }
    }
}