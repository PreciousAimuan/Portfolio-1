using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Portfolio>> GetAll();

        Task<Portfolio> GetByIdAsync(Guid Id);

        bool Update(Portfolio project);

        bool Add(Portfolio project);

        bool Save();
    }
}
