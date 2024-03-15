using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAll();

        Task<Education> GetByIdAsync(Guid Id);

        bool Update(Education education);

        bool Add(Education education);

        bool Save();
    }
}
