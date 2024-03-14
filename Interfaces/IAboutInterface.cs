using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IAboutInterface
    {
        Task<IEnumerable<About>> GetAll();
    }
}
