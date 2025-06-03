using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;
using MovieRecommendationApi.Repository.Interface;
using MovieRecommendationApi.Service.Interface;

namespace MovieRecommendationApi.Service.implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILogger<CommentService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICurrentUser _currentUser;
        private readonly ICustomerRepository _customerRepository;
        public CommentService(ICommentRepository commentRepository, ILogger<CommentService> logger, IUnitOfWork unitOfWork, ICurrentUser currentUser,ICustomerRepository customerRepository)
        {
            _commentRepository = commentRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _customerRepository = customerRepository;
        }
        public bool Create(CreateCommmentRequestModel createCommmentRequestModel)
        {
            var currentUser = _currentUser.GetCurrentUser();
            var user = _customerRepository.GetByEmail(currentUser);
            if(user is null)
                return false;
            var comment = new Comment()
            {
                UserId = user.Id,
                CommentNote = createCommmentRequestModel.CommentNote,
                MovieId = createCommmentRequestModel.MovieId
            };
            _commentRepository.Create(comment);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool DeactivateComment(string id)
        {
            var comments = _commentRepository.GetComment(id);
            if (comments == null)
            {
                return false;
            }
            comments.IsDeleted = true;
            _commentRepository.UpdateComment(comments);
            _unitOfWork.SaveChanges();
            return true;
        }
        public List<CommentDto> GetAllComments()
        {
            var comment = _commentRepository.GetAllComments();
            return comment.Select(x => new CommentDto
            {
                MovieId = x.MovieId,
                CommentNote = x.CommentNote
            }).ToList();
        }
        public CommentDto? GetComment(string id)
        {
            var comment = _commentRepository.GetComment(id);
            if (comment == null)
            {
                return null;
            }
            return new CommentDto()
            {
                MovieId = comment.MovieId,
                CommentNote = comment.CommentNote
            };
        }
        public List<CommentDto> GetCommentsByMovie(string movieId)
        {
            var comment = _commentRepository.GetCommentsByMovie(movieId);
            if (comment == null)
            {
                return null;
            }
            return comment.Select(a => new CommentDto
            {
                MovieId = a.MovieId,
                CommentNote = a.CommentNote,
                DateCreated = a.DateCreated,
                
            }).ToList();
        }
        public List<CommentDto> GetCommentsByUser(string UserId)
        {
             var comment = _commentRepository.GetCommentsByUser(UserId);
            if (comment == null)
            {
                return null;
            }
            return comment.Select(a => new CommentDto
            {
                CommentNote = a.CommentNote,
                MovieId = a.MovieId,
                Id = a.Id,  
            }).ToList();
        }
        public bool UpdateComment(UpdateCommentRequestModel updateCommentRequestModel)
        {
            var comment = _commentRepository.GetAllComments().FirstOrDefault(a => a.CommentNote == updateCommentRequestModel.CommentNote);
            if (comment == null)
            {
                return false;
            }
            _commentRepository.UpdateComment(comment);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}