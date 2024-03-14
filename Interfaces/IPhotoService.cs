using CloudinaryDotNet.Actions;

namespace SQ20.Net_Wee7_8_Task.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}
