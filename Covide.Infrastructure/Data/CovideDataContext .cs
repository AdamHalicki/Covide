using Microsoft.EntityFrameworkCore;
using Covide.Domain.Entities;

namespace Covide.Infrastructure.Data
{
    public class CovideDataContext : DbContext
    {
        public CovideDataContext(DbContextOptions<CovideDataContext> options)
            : base(options)
        {
        }

        public DbSet<ColorCode> ColorCodes { get; set; }
    }
}