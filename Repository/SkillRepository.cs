using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using System.Data.Entity;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class SkillRepository: ISkillRepository
    {
        private readonly ApplicationDbContext _context;
        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Skill>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(Guid Id)
        {
            //throw new NotImplementedException();
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public bool Update(Skill skill)
        {
            //throw new NotImplementedException();
            _context.Update(skill);
            return Save();
        }

        public bool Add(Skill skill)
        {
            //throw new NotImplementedException();
            _context.Add(skill);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
