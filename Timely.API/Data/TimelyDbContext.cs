
using Microsoft.EntityFrameworkCore;
using Timely.API.Models;

namespace Timely.API.Data
{
    public class TimelyDbContext : DbContext
    {
        public TimelyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<ProjEntry> ProjEntries { get; set; }
    }
}
