using Microsoft.EntityFrameworkCore;
using examplewebapi.Models;

namespace examplewebapi.Services
{
    public class ArtWorksContext : DbContext
    {
        public ArtWorksContext(DbContextOptions<ArtWorksContext> options)
            : base(options)
        { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Work> Works {get; set; }

    }
}