using Covide.Application.Interfaces;

namespace Covide.Tests.Fakes
{
    public class FakeHslConverter : IHslConverter
    {
        public double[] Convert(double r, double g, double b)
            => new[] { 269.0, 85.3, 57.3 };
    }
}