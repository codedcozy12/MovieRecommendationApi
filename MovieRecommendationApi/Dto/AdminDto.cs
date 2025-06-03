namespace MovieRecommendationApi.Dto
{
    public class AdminDto
    {
        public required string Email{get; set;}
        public string Id{get; init;} = Guid.NewGuid().ToString();
        public DateTime DateCreated{get; init;} = DateTime.UtcNow;
        public DateTime DateModified{get; set;} = DateTime.UtcNow;
        public string? CreatedBy{get;set;}
        public string? ModifiedBy{get;set;}
        public bool IsDeleted{get; set;}
    }
    public class CreateAdminRequestModel
    {
        public required string Email{get; set;}
        public required string Password{get; set;}
    }
    public class UpdateAdminRequestModel
    {
        public required string Email{get; set;}
        public required string Password{get; set;}
    }
    public class LoginAdminRequestModel
    {
        public required string Email{get; set;}
        public required string Password{get; set;}
    }
}