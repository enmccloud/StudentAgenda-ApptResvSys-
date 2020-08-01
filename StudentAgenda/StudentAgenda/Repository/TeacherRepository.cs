using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Teacher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAgenda.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherContext context;

        public TeacherRepository(TeacherContext context)
        {
            this.context = context;
        }

        public async Task<List<Teachers>> GetAllAsync()
        {
            return await context.Teachers.Include(c => c.Classes).ToListAsync();
        }

        public async Task<Teachers> GetByIdAsync(int id)
        {
            return await context.Teachers
                .Include(c => c.Classes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Teachers> InsertAsync(Teachers item)
        {
            context.Add(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
