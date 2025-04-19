namespace ProsigliereBlogPost.Api.Data.Dto
{
    public readonly record struct BlogPost(
        int Id, 
        string Title, 
        string? Content,
        int CommentsCount,
        IEnumerable<Comment>? Comments
        );
}
