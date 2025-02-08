using Microsoft.AspNetCore.Http;

namespace SingletonPattern.Domain.Interfaces
{
    public interface IUtilityService
    {
        Task<string> SaveImage(string containerName, IFormFile file);
        Task<string> EditImage(string containerName, IFormFile file, string dbPath);
        Task DeleteImage(string containerName, string dbPath);

    }
}
