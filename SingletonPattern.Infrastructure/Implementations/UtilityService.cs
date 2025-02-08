using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class UtilityService : IUtilityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;

        public UtilityService(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }

        public Task DeleteImage(string containerName, string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath,"Uploads", containerName, filename);
            if (File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string containerName, IFormFile file, string dbPath)
        {
            await DeleteImage(containerName, dbPath);
            return await SaveImage(containerName, file);
        }

        public async Task<string> SaveImage(string containerName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid() + extension;
            var folderName = Path.Combine(_env.WebRootPath,"Uploads", containerName);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var filePath = Path.Combine(folderName, fileName);
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var content = ms.ToArray();
                await File.WriteAllBytesAsync(filePath, content);
            }
            var basePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var completePath = Path.Combine(basePath,"Uploads", containerName, fileName).Replace("\\", "/");
            return completePath;
        }
    }
}
