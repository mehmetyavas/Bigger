using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Image;

public interface IImageService
{
    public string PathDir { get; set; }
    Task<string> UpdateImageAsync(IFormFile file, string avatarUrl);
    Task<string> SaveImageAsync(IFormFile file);
}