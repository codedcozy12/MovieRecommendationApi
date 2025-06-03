using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Repository.Interface;

namespace MovieRecommendationApi.Repository.implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext _context;
        public UserRepository(MovieContext context)
        {
            _context = context;
        }
        public bool CheckIfExists(string email)
        {
           return _context.Set<User>().Any(a => a.Email == email);
        }

        public bool DeActivateUser(User user)
        {
            _context.Set<User>().Update(user);
             return true;
        }

        public List<User> GetAllUsers()
        {
            return _context.Set<User>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();
        }

        public User? GetUser(string id)
        {
            return _context.Set<User>().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(x => x.Email == email && x.IsDeleted == false);
        }

        public string HashPassword(string password)
        {
            #region 512
            string hashSalt = "dsew%}{:....,ueee6388jdmm@#$%^&#**hhuushwei3i3483843";
            using var sha512 = SHA512.Create();
            byte[] hashedPasswordByBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password+hashSalt));
            var hashedPassword = Convert.ToBase64String(hashedPasswordByBytes);
            #endregion
            return hashedPassword;
        }
        public bool Persist(User user)
        {
            _context.Set<User>().Add(user);
            return true;
        }
        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return true;
        }
    }
}