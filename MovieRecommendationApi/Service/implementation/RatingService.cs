using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICurrentUser _currentUser;
        public RatingService(ICustomerRepository customerRepository,ICurrentUser currentUser, IRatingRepository ratingRepository,ILogger<RatingService> logger, IUnitOfWork unitOfWork)
            {
                _ratingRepository = ratingRepository;
                _logger = logger;
                _unitOfWork = unitOfWork;
                _currentUser = currentUser;
                _customerRepository = customerRepository;
            }
        public bool CreateRating(CreateRatingRequestModel createRatingRequestModel)
        {
            if(createRatingRequestModel.Score < 1 || createRatingRequestModel.Score > 5)
            {
                return false;
            }
             var currentUser = _currentUser.GetCurrentUser();
            var user = _customerRepository.GetByEmail(currentUser);
            if(user is null)
                return false;
            var ratings = new Rating()
            {
                UserId = user.Id,
                MovieId = createRatingRequestModel.MovieId,
                Score = createRatingRequestModel.Score
            };
            _logger.LogInformation("Created Successfully.");
             _ratingRepository.CreateRating(ratings);
             _unitOfWork.SaveChanges();
             return true;
        }
        public bool DeleteRating(string id)
        {
            var ratings = _ratingRepository.GetRating(id);
            if (ratings == null)
            {
                _logger.LogError("Null Reference");
                return false;
            }
            ratings.IsDeleted = true;
            _logger.LogInformation("Rating With Id :{0} Was Successsfully Deleted At {1}",id,DateTime.Now);
            _ratingRepository.UpdateRating(ratings);
            _unitOfWork.SaveChanges();
            return true;
        }
        public List<RatingDto> GetAllRating()
        {
            var ratings = _ratingRepository.GetAllRating();
                _logger.LogInformation("All Movies Was Gotten At {0}",DateTime.Now);
                return ratings.Select(a => new RatingDto
                {
                    UserId = a.UserId,
                    MovieId = a.MovieId,
                    Score = a.Score,
                    DateCreated = a.DateCreated,
                    DateModified = a.DateModified
                }).ToList();
            }
        public RatingDto? GetRating(string id)
        {
            {
                var ratings = _ratingRepository.GetRating(id);
                if (ratings == null)
                {
                _logger.LogError("Null Reference");
                    return null;
                }
            _logger.LogInformation("Rating With Id :{0} Was Successsfully Retrieved At {1}",id,DateTime.Now);
                return new RatingDto
                {
                    Score = ratings.Score,
                    UserId = ratings.UserId,
                    MovieId = ratings.MovieId
                };
            }
        }

        public double MovieRating(string MovieId)
        {
            return _ratingRepository.MovieRating(MovieId);
        }


        public bool UpdateRating(UpdateRatingRequestModel updateRatingRequestModel)
        {
            var ratings = _ratingRepository.GetAllRating().FirstOrDefault(a => a.Score == updateRatingRequestModel.Score);
                if (ratings == null)
                {
                _logger.LogError("Null Reference");
                    return false;
                }
            _logger.LogInformation("Rating With Title :{0} Was Successsfully Updated At {1}",updateRatingRequestModel.Score,DateTime.Now);
                ratings.Score = updateRatingRequestModel.UpdatedScore;                
                _ratingRepository.UpdateRating(ratings);
                _unitOfWork.SaveChanges();
                return true;   
        }
    }
}