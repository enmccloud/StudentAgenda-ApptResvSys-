using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Class.Models;

namespace StudentAgenda.Areas.Teacher.Models
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options)
        {

        }
        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Classes> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teachers>().HasData(
                new Teachers { Id = 1, Name = "John Cena", Email = "john@doc.com" },
                new Teachers { Id = 2, Name = "Mary poppins", Email = "mary@doc.com" },
                new Teachers { Id = 3, Name = "Clara James", Email = "clara@doc.com" }
                );
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                               