using Microsoft.EntityFrameworkCore;
using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Repository.Interface;

namespace MovieRecommendationApi.Repository.implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MovieContext _context;
        public CommentRepository(MovieContext context)
        {
            _context = context;
        }
        public bool Create(Comment comment)
        {
            _context.Set<Comment>().Add(comment);
            return true;
        }
        public bool DeactivateComment(Comment comment)
        {
            _context.Set<Comment>().Update(comment);
            return true;
        }
        public List<Comment> GetAllComments()
        {
            return _context.Set<Comment>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();
        }
        public Comment? GetComment(string id)
        {
            return _context.Set<Comment>().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public List<Comment> GetCommentsByMovie(string movieId)
        {
            return _context.Set<Comment>().Where(x => x.MovieId == movieId && x.IsDeleted == false).AsNoTracking().ToList();
        }
        public List<Comment> GetCommentsByUser(string userId)
        {
            return _context.Set<Comment>().Where(c => c.UserId == userId && c.IsDeleted == false).AsNoTracking().ToList();
        }
        public bool UpdateComment(Comment comment)
        {
            _context.Set<Comment>().Update(comment);
            return true;
        }
    }
}