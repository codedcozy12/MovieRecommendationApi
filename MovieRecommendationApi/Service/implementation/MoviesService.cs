using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.implementation;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
        public class MoviesService : IMoviesService
        {
            private readonly IMoviesRepository _moviesRepository;
            private readonly IUploadService _uploadService;
            private readonly ILogger<MoviesService> _logger;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRatingRepository _ratingRepository;

        public MoviesService(IMoviesRepository moviesRepository,ILogger<MoviesService> logger, IUnitOfWork unitOfWork, IUploadService uploadService, IRatingRepository ratingRepository)
            {
                _moviesRepository = moviesRepository;
                _logger = logger;
                _uploadService = uploadService;
                _unitOfWork = unitOfWork;
                _ratingRepository = ratingRepository;
            }
            public bool CreateMovies(CreateMovieRequestModel createMovieRequestModel)
            {
                var movies = new Movies()
                {
                    ImageUrl = _uploadService.Create(createMovieRequestModel.Image)!,
                    Title = createMovieRequestModel.Title,
                    CategoryId = createMovieRequestModel.CategoryId,
                    MovieUrl = createMovieRequestModel.MovieUrl
                };
            _logger.LogInformation("Created SUccessfully.");
             _moviesRepository.CreateMovies(movies);
             _unitOfWork.SaveChanges();
             return true;
            }
        public bool DeleteMovies(string id)
        {
            var movies1 = _moviesRepository.GetMovie(id);
            if (movies1 == null)
            {
                _logger.LogError("Null Reference");
                return false;
            }
            movies1.IsDeleted = true;
            _logger.LogInformation("Movie With Id :{0} Was Successsfully Deleted At {1}",id,DateTime.Now);
            _moviesRepository.UpdateMovies(movies1);
            _unitOfWork.SaveChanges();
            return true;
        }
        public List<MoviesDto> GetAllMovies()
            {
                var movies = _moviesRepository.GetAllMovies();
                _logger.LogInformation("All Movies Was Gotten At {0}",DateTime.Now);
                return movies.Select(a => new MoviesDto
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    MovieUrl = a.MovieUrl,
                    Title = a.Title,
                    CategoryId = a.CategoryId,
                    DateCreated = a.DateCreated,
                    DateModified = a.DateModified,
                    Score = _ratingRepository.MovieRating(a.Id)
                }).ToList();
            }
            public MoviesDto? GetMovie(string id)
            {
                var movies = _moviesRepository.GetMovie(id);
                if (movies == null)
                {
                _logger.LogError("Null Reference");
                    return null;
                }
                var rating = _ratingRepository.MovieRating(movies.Id);
            _logger.LogInformation("Movie With Id :{0} Was Successsfully Retrieved At {1}",id,DateTime.Now);
                return new MoviesDto
                {
                    Id = movies.Id,
                    Score = rating,
                    ImageUrl = movies.ImageUrl,
                    MovieUrl = movies.MovieUrl,
                    Title = movies.Title,
                    CategoryId = movies.CategoryId,
                };
            }
        public List<MoviesDto> GetMoviesByCategory(string id)
        {
            var movies = _moviesRepository.GetMoviesByCategory(id);
            _logger.LogInformation("All movies was gotten At {0}", DateTime.Now);
            return movies.Select(a => new MoviesDto()
            {
                     Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    MovieUrl = a.MovieUrl,
                    Title = a.Title,
                    CategoryId = a.CategoryId,
                    DateCreated = a.DateCreated,
                    DateModified = a.DateModified,
                    Score = _ratingRepository.MovieRating(a.Id)
            }).ToList();
        }
        public Movies GetMoviesByTitle(string title)
            {
                var movies = _moviesRepository.GetMovie(title);
                if (movies == null)
                {
                _logger.LogError("Null Reference");
                    return null;
                }
            _logger.LogInformation("Movie With Title :{0} Was Successsfully Retrieved At {1}",title,DateTime.Now);
                return new Movies
                {
                    ImageUrl = movies.ImageUrl,
                    Title = movies.Title,
                    CategoryId = movies.CategoryId,
                    MovieUrl = movies.MovieUrl
                };
            }
            public bool UpdateMovies(UpdateMoviesRequestModel updateMoviesRequestModel)
            {
                var movies = _moviesRepository.GetAllMovies().FirstOrDefault(a => a.Title == updateMoviesRequestModel.Title);
                if (movies == null)
                {
                _logger.LogError("Null Reference");
                    return false;
                }
            _logger.LogInformation("Movie With Title :{0} Was Successsfully Updated At {1}",updateMoviesRequestModel.Title,DateTime.Now);
                movies.Title = updateMoviesRequestModel.UpdatedTitle;
                _moviesRepository.UpdateMovies(movies);
                _unitOfWork.SaveChanges();
                return true;
            }
        }
    }