using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public bool Create(CreateCategoryRequestModel createCategoryRequestModel)
        {
            var res = _categoryRepository.CheckIfExists(createCategoryRequestModel.Name!);
           if (res)
           {
                return false;
           }
            var category = new Category()
            {
                Name = createCategoryRequestModel.Name,
                Title = createCategoryRequestModel.Title,
                Description = createCategoryRequestModel.Description,
            };
            _categoryRepository.Create(category);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool DeleteCategory(string id)
        {
             var categories = _categoryRepository.GetCategory(id);
            if (categories == null)
            {
                return false;
            }
            categories.IsDeleted = true;
            _categoryRepository.UpdateCategory(categories);
             _unitOfWork.SaveChanges();
             return true;
        }
        public List<CategoryDto> GetAllCategories()
        {
            var category = _categoryRepository.GetAllCategories();
            return category.Select(a => new CategoryDto
            {
                Id = a.Id,
                Name = a.Name,
                Title = a.Title,
                Description = a.Description,
                DateCreated = a.DateCreated,
                DateModified = a.DateModified,
            }).ToList();
        }
        public CategoryDto? GetCategory(string id)
        {
            var category = _categoryRepository.GetCategory(id);
            if(category == null)
            {
                return null;
            }
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Title = category.Title,
            };
        }
        public CategoryDto? GetCategoryByName(string name)
        {
            var category = _categoryRepository.GetCategoryByName(name);
            if (category == null)
            {
                return null;
            }
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Title = category.Title,
            };
        }
        public bool UpdateCategory(UpdateCategoryRequestModel updateCategoryRequestModel)
        {
            var category = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == updateCategoryRequestModel.Name);
            if(category == null)
            {
                return false;
            }
            _categoryRepository.UpdateCategory(category);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}