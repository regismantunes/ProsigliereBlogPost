using ProsigliereBlogPost.Api.Data.Dto;
using ProsigliereBlogPost.Api.Services.Interfaces;

namespace ProsigliereBlogPost.Api.Routes
{
    internal static class CommentMap
    {
        public static void MapCommentRoutes(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("{blogPostId:int}/comments");
            
            group.MapPost(string.Empty, async (int blogPostId, Comment comment, ICommentService commentService) =>
            {
                var createdId = await commentService.CreateAsync(blogPostId, comment);

                return Results.Created($"/posts/{blogPostId}", createdId);
            });
        }
    }
}