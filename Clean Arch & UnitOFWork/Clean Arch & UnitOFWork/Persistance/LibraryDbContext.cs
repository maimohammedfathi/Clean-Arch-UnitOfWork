using Clean_Arch___UnitOFWork.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clean_Arch___UnitOFWork.Persistance
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("LibraryConnection");
            }
        }

    }
}
