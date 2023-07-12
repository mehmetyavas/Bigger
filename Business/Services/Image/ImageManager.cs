using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Image;

public class ImageManager : IImageService
{
    private readonly string _uploadsFolder;

    public ImageManager()
    {
        _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        if (!Directory.Exists(_uploadsFolder))
            Directory.CreateDirectory(_uploadsFolder);
    }

    public async Task<string> SaveImageAsync(IFormFile file, string avatarUrl)
    {
        if (file == null ||
            file.Length == 0)
            return null;


        var fileName = Guid.NewGuid() + ".webp";
        var filePath = Path.Combine(_uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        if (avatarUrl != null)
            if (File.Exists(Path.Combine(_uploadsFolder, avatarUrl)))
                File.Delete(Path.Combine(_uploadsFolder, avatarUrl));

        return fileName;
    }
}