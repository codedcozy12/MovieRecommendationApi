namespace MovieRecommendationApi.Dto
{
    public class CommentDto
    {
        public required string CommentNote { get; set;}
        public required string MovieId { get; set; }
        public string Id{get; set;}
        public DateTime DateCreated{get; init;} 
        public DateTime DateModified{get; set;} 
        public string? CreatedBy{get;set;}
        public string? ModifiedBy{get;set;}
        public bool IsDeleted{get; set;}
        public MoviesDto Movie{get; set;}
    }
    public class CreateCommmentRequestModel
    {
        public required string CommentNote { get; set;}
        public required string MovieId { get; set; }
    }
    public class UpdateCommentRequestModel
    {
        public required string CommentNote{get; set;}
        public required string MovieId{get; set;}
    }
}