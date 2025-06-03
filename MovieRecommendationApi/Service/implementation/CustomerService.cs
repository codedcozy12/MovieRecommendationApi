using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.implementation;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository1;
        private readonly ILogger<CustomerService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public CustomerService(IUserRepository userRepository, ICustomerRepository customerRepository, ILogger<CustomerService> logger, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _customerRepository1 = customerRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public bool Create(CreateCustomerRequestModel createCustomerRequestModel)
        {
            var check = _customerRepository1.CheckIfExists(createCustomerRequestModel.Email);
            if (check)
            {
                return false;
            }
            var user = new User
            {
                Email = createCustomerRequestModel.Email,
                Password = _userRepository.HashPassword(createCustomerRequestModel.Password),
                Role = Role.Customer,
                CreatedBy = createCustomerRequestModel.Email,
                ModifiedBy = createCustomerRequestModel.Email
            };
            var customer = new Customer()
            {
                FirstName = createCustomerRequestModel.FirstName,
                LastName = createCustomerRequestModel.LastName,
                Email = createCustomerRequestModel.Email,
                Password = createCustomerRequestModel.Password,
                DateOfBirth = createCustomerRequestModel.DateOfBirth,
                Gender = createCustomerRequestModel.Gender,
                PhoneNumber = createCustomerRequestModel.PhoneNumber
            };
            _logger.LogInformation("Created SUccessfully.");
            _userRepository.Persist(user);
            _customerRepository1.Create(customer);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool DeactivateCustomer(string id)
        {
            var customers = _customerRepository1.GetCustomer(id);
            if (customers == null)
            {
                _logger.LogError("Null Reference");
                return false;
            }
            customers.IsDeleted = true;
            _customerRepository1.UpdateCustomer(customers);
            _unitOfWork.SaveChanges();
            return true;
        }
        public List<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository1.GetAllCustomers();
            return customers.Select(a => new CustomerDto
            {
                Id = a.Id,
                Email = a.Email,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Gender = a.Gender,
                PhoneNumber = a.PhoneNumber
            }).ToList();
        }
        public CustomerDto GetCustomer(string id)
        {
            var customers = _customerRepository1.GetCustomer(id);
            if (customers == null)
            {
                return null;
            }
            return new CustomerDto
            {
                Id = customers.Id,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                Gender = customers.Gender,
                PhoneNumber = customers.PhoneNumber
            };
        }
        public Customer? GetCustomer(string email, string password)
        {
            var customers = _customerRepository1.GetCustomer(email, password);
            if (customers == null)
            {
                return null;
            }
            return new Customer
            {
                Email = customers.Email,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumber,
                Gender = customers.Gender,
                Password = customers.Password
            };
        }
        public bool UpdateCustomer(UpdateCustomerRequestModel updateCustomerRequestModel)
        {
            var customer = _customerRepository1.GetAllCustomers().FirstOrDefault(a => a.FirstName == updateCustomerRequestModel.FirstName && a.LastName == updateCustomerRequestModel.LastName && a.PhoneNumber == updateCustomerRequestModel.PhoneNumber);
            if (customer == null)
            {
                return false;
            }
            _customerRepository1.UpdateCustomer(customer);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}