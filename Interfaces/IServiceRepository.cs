using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();

        Task<Service> GetByIdAsync(Guid id);

        bool Update(Service service);

        bool Add(Service service);

        bool Save();
    }
}
