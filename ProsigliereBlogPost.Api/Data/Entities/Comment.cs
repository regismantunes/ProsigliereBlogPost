namespace ProsigliereBlogPost.Api.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public required string Author { get; set; }

        public required string Content { get; set; }

        public int? BlogPostId { get; set; }

        public BlogPost? BlogPost { get; set; }
    }
}
