using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetAll();

        Task<Experience> GetByIdAsync(Guid Id);

        bool Update(Experience experience);

        bool Add(Experience experience);

        bool Save();
    }
}
