using ProsigliereBlogPost.Api.Data.Entities;
using BlogPostDto = ProsigliereBlogPost.Api.Data.Dto.BlogPost;

namespace ProsigliereBlogPost.Api.Data.DtoMap
{
    public static class BlogPostExtensions
    {
        public static BlogPostDto ToDto(this BlogPost blogPost)
        {
            ArgumentNullException.ThrowIfNull(blogPost, nameof(blogPost));

            return new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CommentsCount = blogPost.CommentsCount,
                Comments = blogPost.Comments?.ToDto(),
            };
        }

        public static IEnumerable<BlogPostDto> ToDto(this IEnumerable<BlogPost> blogPosts)
        {
            ArgumentNullException.ThrowIfNull(blogPosts, nameof(blogPosts));

            return blogPosts.Select(b => b.ToDto());
        }

        public static BlogPost ToEntity(this BlogPostDto blogPostDto)
        {
            return new BlogPost
            {
                Id = blogPostDto.Id,
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                CommentsCount = blogPostDto.CommentsCount,
                Comments = blogPostDto.Comments?.ToEntity(),
            };
        }

        public static IEnumerable<BlogPost> ToEntity(this IEnumerable<BlogPostDto> blogPostDtos)
        {
            ArgumentNullException.ThrowIfNull(blogPostDtos, nameof(blogPostDtos));

            return blogPostDtos.Select(b => b.ToEntity());
        }
    }
}
