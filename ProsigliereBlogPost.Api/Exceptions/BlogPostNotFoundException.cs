namespace ProsigliereBlogPost.Api.Exceptions
{
    public class BlogPostNotFoundException : NotFoundException
    {
        private static string GetMessage(int id) => $"Blog post with ID {id} not found.";

        public BlogPostNotFoundException(int id) : base(GetMessage(id)) { }
        public BlogPostNotFoundException(int id, Exception innerException)
            : base(GetMessage(id), innerException)
        {
        }
    }
}