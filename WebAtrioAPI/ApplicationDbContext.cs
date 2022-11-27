using Microsoft.EntityFrameworkCore;
using WebAtrioAPI.Entities;

namespace WebAtrioAPI
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Personne> Personnes { get; set; }
    }
}
