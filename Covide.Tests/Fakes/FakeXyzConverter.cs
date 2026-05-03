using Covide.Application.Interfaces;

namespace Covide.Tests.Fakes
{
    public class FakeXyzConverter : IXyzConverter
    {
        public double[] Convert(double r, double g, double b)
            => new[] { 28.008, 14.529, 82.99 };
    }
}
