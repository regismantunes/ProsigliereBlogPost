using Microsoft.AspNetCore.Mvc;
using ProsigliereBlogPost.Api.Data.Dto;
using ProsigliereBlogPost.Api.Services.Interfaces;

namespace ProsigliereBlogPost.Api.Routes
{
    internal static class CommentMap
    {
        public static IEndpointRouteBuilder MapCommentRoutes(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("posts/{blogPostId:int}/comments");

            group.MapPost(string.Empty, async (int blogPostId, [FromBody] Comment comment, ICommentService commentService) =>
            {
                var createdId = await commentService.CreateAsync(blogPostId, comment);

                return Results.Created($"/posts/{blogPostId}", new { Id = createdId });
            });

            return app;
        }
    }
}