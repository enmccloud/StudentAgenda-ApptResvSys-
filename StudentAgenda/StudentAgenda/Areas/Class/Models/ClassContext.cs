using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.GroupMember.Models;
using StudentAgenda.Areas.Teacher.Models;

namespace StudentAgenda.Areas.Class.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options): base(options)
        {

        }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<GroupMembers> GroupMembers { get; set; }

        public DbSet<Teachers> Teachers { get; set; }
        
        //load data at start of program 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>().HasData(
                new Classes { Id =1, Name = "Advanced C#", CourseDescription = "IT"},
                new Classes { Id = 2, Name = "CISCO", CourseDescription = "NetWorking" },
                new Classes { Id = 3, Name = "Environmental Science", CourseDescription = "Liberal Arts"}
                );
        }
    }
}
