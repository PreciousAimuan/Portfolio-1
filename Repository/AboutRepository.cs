using System;
using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class AboutRepository: IAboutRepository
    {
        private readonly ApplicationDbContext _context;
        public AboutRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<About>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Abouts.ToListAsync();
        }

        public async Task<About> GetByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.Abouts.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(About about)
        {
            //throw new NotImplementedException();
            _context.Update(about);
            return Save();
        }

        public bool Add(About about)
        {
            //throw new NotImplementedException();
            _context.Add(about);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
