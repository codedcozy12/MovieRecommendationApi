using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface ICategoryService
    {
        bool Create(CreateCategoryRequestModel createCategoryRequestModel);
        CategoryDto? GetCategory(string Id);
        CategoryDto? GetCategoryByName(string Name);
        List<CategoryDto> GetAllCategories();
        bool UpdateCategory(UpdateCategoryRequestModel updateCategoryRequestModel);
        bool DeleteCategory(string id);
    }
}