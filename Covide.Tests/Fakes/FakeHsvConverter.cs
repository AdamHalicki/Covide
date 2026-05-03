using Covide.Application.Interfaces;

namespace Covide.Tests.Fakes
{
    public class FakeHsvConverter : IHsvConverter
    {
        public double[] Convert(double r, double g, double b)
            => new[] { 269.0, 77.8, 93.7 };
    }
}
