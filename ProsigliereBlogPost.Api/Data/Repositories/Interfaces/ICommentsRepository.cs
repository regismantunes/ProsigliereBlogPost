using ProsigliereBlogPost.Api.Data.Entities;

namespace ProsigliereBlogPost.Api.Data.Repositories.Interfaces
{
    public interface ICommentsRepository
    {
        Task<int> CreateAsync(Comment comment);
    }
}