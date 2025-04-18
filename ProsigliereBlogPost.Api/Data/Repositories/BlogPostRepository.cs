using Microsoft.EntityFrameworkCore;
using ProsigliereBlogPost.Api.Data.Context;
using ProsigliereBlogPost.Api.Data.Entities;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;

namespace ProsigliereBlogPost.Api.Data.Repositories
{
    public class BlogPostRepository(AppDbContext context) : IBlogPostRepository
    {
        public IQueryable<BlogPost> GetAll()
        {
            return context.BlogPosts;
        }

        public async Task<int> CreateAsync(BlogPost blogPost)
        {
            context.BlogPosts.Add(blogPost);
            await context.SaveChangesAsync();
            return blogPost.Id;
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await context.BlogPosts
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
