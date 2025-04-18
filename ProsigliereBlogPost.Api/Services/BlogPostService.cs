using Microsoft.EntityFrameworkCore;
using ProsigliereBlogPost.Api.Data.DtoMap;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;
using ProsigliereBlogPost.Api.Services.Interfaces;
using BlogPostDto = ProsigliereBlogPost.Api.Data.Dto.BlogPost;

namespace ProsigliereBlogPost.Api.Services
{
    public class BlogPostService(IBlogPostRepository blogPostRepository) : IBlogPostService
    {
        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            var list = await blogPostRepository
                .GetAll()
                .ToListAsync();

            return list.ToDto();
        }

        public async Task<BlogPostDto?> GetByIdAsync(int id)
        {
            var entity = await blogPostRepository.GetByIdAsync(id);
            return entity?.ToDto();
        }

        public async Task<int> CreateAsync(BlogPostDto blogPost)
        {
            var entity = blogPost.ToEntity();
            return await blogPostRepository.CreateAsync(entity);
        }
    }
}