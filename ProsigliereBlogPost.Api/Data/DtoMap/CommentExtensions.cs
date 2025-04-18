using ProsigliereBlogPost.Api.Data.Entities;
using CommentDto = ProsigliereBlogPost.Api.Data.Dto.Comment;

namespace ProsigliereBlogPost.Api.Data.DtoMap
{
    public static class CommentExtensions
    {
        public static CommentDto ToDto(this Comment comment)
        {
            ArgumentNullException.ThrowIfNull(comment, nameof(comment));

            return new CommentDto
            {
                Id = comment.Id,
                Author = comment.Author,
                Content = comment.Content
            };
        }

        public static IEnumerable<CommentDto> ToDto(this IEnumerable<Comment> comments)
        {
            ArgumentNullException.ThrowIfNull(comments, nameof(comments));

            return comments.Select(c => c.ToDto());
        }

        public static Comment ToEntity(this CommentDto commentDto)
        {
            return new Comment
            {
                Id = commentDto.Id,
                Author = commentDto.Author,
                Content = commentDto.Content
            };
        }

        public static IEnumerable<Comment> ToEntity(this IEnumerable<CommentDto> commentDtos)
        {
            ArgumentNullException.ThrowIfNull(commentDtos, nameof(commentDtos));

            return commentDtos.Select(c => c.ToEntity());
        }
    }
}
