using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Image;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile file, string avatarUrl);
}