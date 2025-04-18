using ProsigliereBlogPost.Api.Data.DtoMap;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;
using ProsigliereBlogPost.Api.Services.Interfaces;
using CommentDto = ProsigliereBlogPost.Api.Data.Dto.Comment;

namespace ProsigliereBlogPost.Api.Services
{
    public class CommentService(ICommentsRepository commentsRepository) : ICommentService
    {
        public async Task<int> CreateAsync(int blogPostId, CommentDto comment)
        {
            var entity = comment.ToEntity();
            entity.BlogPostId = blogPostId;
            return await commentsRepository.CreateAsync(entity);
        }
    }
}