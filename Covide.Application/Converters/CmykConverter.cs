using Covide.Application.Interfaces;
using System;

namespace Covide.Application.Converters
{
    public class CmykConverter : ICmykConverter
    {
        public int[] Convert(double r, double g, double b)
        {
            double k = 1 - Math.Max(r, Math.Max(g, b));

            if (k == 1)
            {
                return new[] { 0, 0, 0, 100 };
            }

            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            return new[]
            {
                (int)Math.Round(c * 100),
                (int)Math.Round(m * 100),
                (int)Math.Round(y * 100),
                (int)Math.Round(k * 100)
            };
        }
    }
}