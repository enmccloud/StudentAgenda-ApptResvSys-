using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Class.Models;
using StudentAgenda.Areas.Teacher.Models;

namespace StudentAgenda.Areas.GroupMember.Models
{
    public class GroupMembersContext : DbContext
    {
        public GroupMembersContext(DbContextOptions<GroupMembersContext> options) : base(options)
        {

        }
        public DbSet<GroupMembers> GroupMembers { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<Teachers> Teachers { get; set; }
    }

}
