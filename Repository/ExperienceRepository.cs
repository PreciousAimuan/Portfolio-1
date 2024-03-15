using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Experience>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Experiences.ToListAsync();
        }

        public async Task<Experience> GetByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.Experiences.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Experience experience)
        {
            //throw new NotImplementedException();
            _context.Update(experience);
            return Save();
        }

        public bool Add(Experience experience)
        {
            //throw new NotImplementedException();
            _context.Add(experience);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
