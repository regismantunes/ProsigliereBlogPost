using ProsigliereBlogPost.Api.Data.Context;
using ProsigliereBlogPost.Api.Data.Entities;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;
using ProsigliereBlogPost.Api.Exceptions;

namespace ProsigliereBlogPost.Api.Data.Repositories
{
    public class CommentsRepository(AppDbContext context) : ICommentsRepository
    {
        public async Task<int> CreateAsync(Comment comment)
        {
            if (comment.BlogPostId is null)
                throw new ArgumentNullException(nameof(comment.BlogPostId), "BlogPostId cannot be null");

            var blogPost = await context.BlogPosts.FindAsync(comment.BlogPostId)
                ?? throw new BlogPostNotFoundException(comment.BlogPostId.Value);

            blogPost.CommentsCount++;
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment.Id;
        }
    }
}
