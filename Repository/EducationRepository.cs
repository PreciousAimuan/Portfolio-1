using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class EducationRepository: IEducationRepository
    {
        private readonly ApplicationDbContext _context;
        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Education>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.Educations.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Education education)
        {
            //throw new NotImplementedException();
            _context.Update(education);
            return Save();
        }

        public bool Add(Education education)
        {
            //throw new NotImplementedException();
            _context.Add(education);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
