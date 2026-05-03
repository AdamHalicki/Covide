using Covide.Application.Interfaces;

namespace Covide.Tests.Fakes
{
    public class FakeCmykConverter : ICmykConverter
    {
        public int[] Convert(double r, double g, double b)
            => new[] { 41, 78, 0, 6 };
    }
}
