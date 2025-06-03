using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface ICustomerService
    {
        bool Create(CreateCustomerRequestModel createCustomerRequestModel);
        CustomerDto GetCustomer(string id);
        Customer? GetCustomer(string email,string password);
        List<CustomerDto> GetAllCustomers();
        bool UpdateCustomer(UpdateCustomerRequestModel updateCustomerRequestModel);
        bool DeactivateCustomer(string id);
    }
}