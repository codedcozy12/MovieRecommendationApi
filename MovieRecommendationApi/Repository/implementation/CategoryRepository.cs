using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Repository.Interface;

namespace MovieRecommendationApi.Repository.implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MovieContext _context;
        public CategoryRepository(MovieContext context)
        {
            _context = context;
        }
        public bool CheckIfExists(string name)
        {
           return _context.Set<Category>().Any(a => a.Name == name);
        }
        public bool Create(Category category)
        {
            _context.Set<Category>().Add(category);
            return true;
        }
        public bool DeleteCategory(Category category)
        {
            _context.Set<Category>().Update(category);
            return true;
        }
        public List<Category> GetAllCategories()
        {
            return _context.Set<Category>().AsNoTracking().Where(a => a.IsDeleted == false).ToList();
        }
        public Category? GetCategory(string id)
        {
            return _context.Set<Category>().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
        public Category? GetCategoryByName(string name)
        {
            return _context.Set<Category>().AsNoTracking().FirstOrDefault(c => c.Name == name && c.IsDeleted == false);
        }
        public bool UpdateCategory(Category category)
        {
            _context.Set<Category>().Update(category);
            return true;
        }
    }
}