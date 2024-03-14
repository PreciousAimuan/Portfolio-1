using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAll();

        Task<About> GetByIdAsync(Guid Id);

        bool Update(About about);

        bool Add(About about);

        bool Save();
    }
}
