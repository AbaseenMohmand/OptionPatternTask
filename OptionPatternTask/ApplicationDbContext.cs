using Microsoft.EntityFrameworkCore;
using OptionPatternTask.Models;

namespace OptionPatternTask
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
            
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
    }
}
