using Microsoft.EntityFrameworkCore;
using StudentAgenda.Areas.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAgenda.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ClassContext context;

        public ClassRepository(ClassContext context)
        {
            this.context = context;
        }

        public async Task<List<Classes>> GetAllAsync()
        {
            return await context.Classes.ToListAsync();
        }

        public Task<Classes> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Classes> InsertAsync(Classes item)
        {
            throw new NotImplementedException();
        }
    }
}
