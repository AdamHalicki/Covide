using Covide.Application.Interfaces;
using Covide.Infrastructure.Data;
using System.Linq;

public class ColorRepository : IColorRepository
{
    private readonly CovideDataContext _db;

    public ColorRepository(CovideDataContext db)
    {
        _db = db;
    }

    public string GetColorName(string hex)
    {
        return _db.ColorCodes
            .FirstOrDefault(c => c.HexTriplet == hex.ToUpper())
            ?.Name;
    }
}