using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface IUploadService
    {
        string? Create(IFormFile file);
    }
}