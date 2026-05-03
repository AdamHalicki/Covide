using Covide.Domain.Entities;
using Covide.Application.Interfaces;

namespace Covide.Tests.Fakes
{
    public class FakeColorRepository : IColorRepository
    {
        public string GetColorName(string hex)
        {
            return "Purple";
        }
    }
}