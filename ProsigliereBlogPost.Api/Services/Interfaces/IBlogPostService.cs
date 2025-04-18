using ProsigliereBlogPost.Api.Data.Dto;

namespace ProsigliereBlogPost.Api.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<int> CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);
    }
}