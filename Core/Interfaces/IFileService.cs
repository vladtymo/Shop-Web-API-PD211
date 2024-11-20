using Microsoft.AspNetCore.Http;

namespace Core.Interfaces;

public interface IFileService
{
    Task<string> SaveFile(IFormFile file);
    Task DeleteFile(string path);
}