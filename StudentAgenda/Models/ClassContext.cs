using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAgenda.Models;

namespace StudentAgenda.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAgenda.Models.Classes> Classes { get; set; }

        public DbSet<StudentAgenda.Models.GroupMembers> GroupMembers { get; set; }

        public DbSet<StudentAgenda.Models.Teachers> Teachers { get; set; }

    }
}