namespace ProsigliereBlogPost.Api.Data.Dto
{
    public readonly record struct Comment(
        int Id,
        string Author,
        string Content
        );
}
