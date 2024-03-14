using System;
using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class AboutRepository: IAboutInterface
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


    }
}
