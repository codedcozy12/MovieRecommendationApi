using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface ICategoryRepository
    {
        bool Create(Category category);
        Category? GetCategory(string Id);
        Category? GetCategoryByName(string Name);
        List<Category> GetAllCategories();
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool CheckIfExists(string name);
    }
}