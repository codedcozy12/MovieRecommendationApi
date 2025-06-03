using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.Interface;

namespace MovieRecommendationApi.Repository.implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieContext _context;
        public CustomerRepository(MovieContext context)
        {
            _context = context;
        }
        public bool CheckIfExists(string email)
        {
           return _context.Set<Customer>().Any(a => a.Email == email );
            
        }
        public bool Create(Customer customer)
        {
            _context.Set<Customer>().Add(customer);
            return true;
        }
        public bool DeactivateCustomer(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            return true;
        }
        public List<Customer> GetAllCustomers()
        {
            return _context.Set<Customer>().AsNoTracking().Where(a => a.IsDeleted == false).ToList();
        }
        public Customer? GetCustomer(string id)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
        public Customer? GetByEmail(string email)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.Email == email && x.IsDeleted == false);
        }

        public Customer? GetCustomer(string email, string password)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.Email == email && x.Password == password && x.IsDeleted == false);
        }

        public CustomerDto? Login(LoginCustomerRequestModel model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return true;
        }
    }
}