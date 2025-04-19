using ProsigliereBlogPost.Api.Data.Context;
using ProsigliereBlogPost.Api.Data.Entities;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;

namespace ProsigliereBlogPost.Api.Data.Repositories
{
    public class CommentsRepository(AppDbContext context) : ICommentsRepository
    {
        public async Task<int> CreateAsync(Comment comment)
        {
            var blogPost = await context.BlogPosts.FindAsync(comment.BlogPostId)
                ?? throw new KeyNotFoundException($"BlogPost with ID {comment.BlogPostId} not found.");

            blogPost.CommentsCount++;
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment.Id;
        }
    }
}
