using ProsigliereBlogPost.Api.Data.Context;
using ProsigliereBlogPost.Api.Data.Entities;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;

namespace ProsigliereBlogPost.Api.Data.Repositories
{
    public class CommentsRepository(AppDbContext context) : ICommentsRepository
    {
        public async Task<int> CreateAsync(Comment comment)
        {
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment.Id;
        }
    }
}
