using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAgenda.Areas.Teacher.Models
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options)
        {

        }
        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Classes> Classes { get; set; }
    }
}
