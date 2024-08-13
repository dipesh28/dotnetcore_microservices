using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlatformService.Models;

namespace PlatformService.Data 
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt) 
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}