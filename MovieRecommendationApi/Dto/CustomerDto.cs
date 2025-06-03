namespace MovieRecommendationApi.Dto
{
    public class CustomerDto
    {
        public required string FirstName{get; set;}
        public required string LastName{get; set;}
        // public int Age{get; set;}
        public DateTime DateOfBirth {get; init;}
        public required string PhoneNumber {get; set;}
        public string? Email {get; set;}
        public required string Gender{get; set;}
        public string Id{get; init;}
        public DateTime DateCreated{get; init;} = DateTime.UtcNow;
        public DateTime DateModified{get; set;} = DateTime.UtcNow;
        public string? CreatedBy{get;set;}
        public string? ModifiedBy{get;set;}
        public bool IsDeleted{get; set;}   
        public List<CommentDto> comments {get; set;} = [];
    }
    public class CreateCustomerRequestModel
    {
        public required string FirstName{get; set;}
        public required string LastName{get; set;}
        // public int Age{get; set;}
        public DateTime DateOfBirth {get; init;}
        public required string PhoneNumber {get; set;}
        public required string Email {get; set;}
        public required string Password{get; set;}
        public required string Gender{get; set;}
    }
    public class UpdateCustomerRequestModel
    {
        public required string FirstName{get; set;}
        public required string LastName{get; set;}
        public required string PhoneNumber {get; set;}
        public int Age{get; set;}
    }
    public class LoginCustomerRequestModel
    {
        public required string Email{get; set;}
        public required string Password{get; set;}
    }
}