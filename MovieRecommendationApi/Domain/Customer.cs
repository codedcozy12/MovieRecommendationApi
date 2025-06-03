namespace MovieRecommendationApi.Domain
{
    public class Customer : BaseEntities
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        // public int Age { get; set; }
        public DateTime DateOfBirth { get; init; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public Role Role{get; init;} = Role.Customer;
    }
}
