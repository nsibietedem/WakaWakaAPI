using Microsoft.EntityFrameworkCore;
using WakaWakaApi.Models;

namespace WakaWakaApi.DataAccess
{
    public class WakaWakaDbContext:DbContext
    {
        public WakaWakaDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
