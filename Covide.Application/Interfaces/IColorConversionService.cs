using Covide.Domain.Entities;

namespace Covide.Application.Interfaces
{
    public interface IColorConversionService
    {
        bool IsValidHex(string hex);
        ColorResult Convert(string hex);
    }
}
