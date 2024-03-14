using Microsoft.EntityFrameworkCore;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            // throw new NotImplementedException();
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(Guid id)
        {
            //throw new NotImplementedException();
            return await _context.Services.Include(a => a.AppUser).FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(Service service)
        {
            //throw new NotImplementedException();
            _context.Update(service);
            return Save();
        }

        public bool Add(Service service)
        {
            //throw new NotImplementedException();
            _context.Add(service);
            return Save();
        }

        public bool Save()
        {

            var save = _context.SaveChanges();
            return save > 0;

        }
    }
}
