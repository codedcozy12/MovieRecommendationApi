using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi.Repository.Interface
{
    public interface ICommentRepository
    {
        bool Create(Comment comment);
        Comment? GetComment(string id);
        List<Comment> GetCommentsByMovie(string movieId);
        List<Comment> GetCommentsByUser(string UserId);
        List<Comment> GetAllComments();
        bool UpdateComment(Comment comment);
        bool DeactivateComment(Comment comment);
    }
}
