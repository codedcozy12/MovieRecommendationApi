using MovieRecommendationApi.Domain;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Service.Interface
{
    public interface ICommentService
    {
        bool Create(CreateCommmentRequestModel createCommmentRequestModel);
        CommentDto? GetComment(string id);
        List<CommentDto> GetCommentsByMovie(string movieId);
        List<CommentDto> GetCommentsByUser(string UserId);
        List<CommentDto> GetAllComments();
        bool UpdateComment(UpdateCommentRequestModel updateCommentRequestModel);
        bool DeactivateComment(string id);
    }
}