using System;

namespace Covide.Application.Converters
{
    public static class ColorPercentageConverter
    {
        public static double[] FromRgb(int r, int g, int b)
        {
            return new[]
            {
                ToPercentage(r),
                ToPercentage(g),
                ToPercentage(b)
            };
        }

        private static double ToPercentage(int value)
        {
            return Math.Round(value / 2.55, 1);
        }
    }
}