using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class UnitOfWork(MovieContext _context) : IUnitOfWork
    {
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}