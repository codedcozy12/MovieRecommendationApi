using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface ICustomerRepository
    {
         bool CheckIfExists(string email);
        bool Create(Customer customer);
        Customer? GetCustomer(string id);
        Customer? GetByEmail(string email);
        CustomerDto? Login(LoginCustomerRequestModel model); 
        Customer? GetCustomer(string email,string password);
        List<Customer> GetAllCustomers();
        bool UpdateCustomer(Customer customer);
        bool DeactivateCustomer(Customer customer);
    }
}