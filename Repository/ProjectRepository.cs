using System;
using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Portfolio>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Projects.ToListAsync();
        }

        public async Task<Portfolio> GetByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Portfolio project)
        {
            //throw new NotImplementedException();
            _context.Update(project);
            return Save();
        }

        public bool Add(Portfolio project)
        {
            //throw new NotImplementedException();
            _context.Add(project);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
