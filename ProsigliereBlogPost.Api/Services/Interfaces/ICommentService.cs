using ProsigliereBlogPost.Api.Data.Dto;

namespace ProsigliereBlogPost.Api.Services.Interfaces
{
    public interface ICommentService
    {
        Task<int> CreateAsync(int blogPostId, Comment comment);
    }
}