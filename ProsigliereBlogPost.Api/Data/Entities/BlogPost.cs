namespace ProsigliereBlogPost.Api.Data.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<Comment>? Comments { get; set; }
    }
}
