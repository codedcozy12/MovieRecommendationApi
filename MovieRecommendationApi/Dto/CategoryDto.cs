namespace MovieRecommendationApi.Dto
{
    public class CategoryDto
    {
        public string? Name{get; set;}
        public string? Title{get; set;}
        public string? Description{get; set;}
        public required string Id{get; set;}
        public DateTime DateCreated{get; init;} = DateTime.UtcNow;
        public DateTime DateModified{get; set;} = DateTime.UtcNow;
        public string? CreatedBy{get;set;}
        public string? ModifiedBy{get;set;}
        public bool IsDeleted{get; set;}
        public List<MoviesDto> Movies {get; set;} = [];
    }
    public class CreateCategoryRequestModel
    {
        public string? Name{get; set;}
        public required string Title{get; set;}
        public required string Description{get; set;}
    }
    public class UpdateCategoryRequestModel
    {
        public required string Title{get; set;}
        public required string Description{get; set;}
        public string? Name{get; set;}
    }
}