using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Image;

public class ImageManager : IImageService
{
    private string _uploadsFolder;
    public string PathDir { get; set; } = string.Empty;


    public ImageManager()
    {
        _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");


        if (!Directory.Exists(_uploadsFolder))
            Directory.CreateDirectory(_uploadsFolder);
    }

    public async Task<string> UpdateImageAsync(IFormFile file, string avatarUrl)
    {
        if (file == null ||
            file.Length == 0)
            return null;

        _uploadsFolder = !string.IsNullOrWhiteSpace(PathDir)
            ? $"{_uploadsFolder}/{PathDir}"
            : _uploadsFolder;

        var fileName = Guid.NewGuid() + ".webp";
        var filePath = Path.Combine(_uploadsFolder, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        if (avatarUrl != null)
            if (File.Exists(Path.Combine(_uploadsFolder, avatarUrl)))
                File.Delete(Path.Combine(_uploadsFolder, avatarUrl));

        return fileName;
    }


    public async Task<string> SaveImageAsync(IFormFile file)
    {
        if (file == null ||
            file.Length == 0)
            return null;

        _uploadsFolder = !string.IsNullOrWhiteSpace(PathDir)
            ? $"{_uploadsFolder}/{PathDir}"
            : _uploadsFolder;

        var fileName = Guid.NewGuid() + ".webp";
        var filePath = Path.Combine(_uploadsFolder, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);


        return fileName;
    }
}