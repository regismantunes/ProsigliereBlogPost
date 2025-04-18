using ProsigliereBlogPost.Api.Data.Entities;

namespace ProsigliereBlogPost.Api.Data.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        IQueryable<BlogPost> GetAll();
        Task<int> CreateAsync(BlogPost blogPost);
        Task<BlogPost?> GetByIdAsync(int id);
    }
}