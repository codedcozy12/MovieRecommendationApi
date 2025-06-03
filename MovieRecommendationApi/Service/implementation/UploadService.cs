using Microsoft.Extensions.Options;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class UploadService: IUploadService
    {


        public string? Create(IFormFile file)
        {
            var rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MovieImages");
            if(!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            var contentType = file.ContentType;

            string subFolder = contentType switch
            {
                var type when type.StartsWith("image/") => "Images",
                var type when type.StartsWith("video/") => "Videos",
                var type when type.StartsWith("application/") => "Documents",
                _ => "Others"
            };

            var folder = Path.Combine(rootFolder, subFolder);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(folder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create)) 
            { 
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}