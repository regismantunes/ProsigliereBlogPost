using Microsoft.AspNetCore.Mvc;
using ProsigliereBlogPost.Api.Data.Dto;
using ProsigliereBlogPost.Api.Services.Interfaces;

namespace ProsigliereBlogPost.Api.Routes
{
    internal static class BlogPostMap
    {
        public static IEndpointRouteBuilder MapBlogPostRoutes(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/posts");

            group.MapGet(string.Empty, async (IBlogPostService blogPostService) =>
            {
                var blogPosts = await blogPostService.GetAllAsync();
                return Results.Ok(blogPosts);
            });

            group.MapGet("{id:int}", async (int id, IBlogPostService blogPostService) =>
            {
                var blogPost = await blogPostService.GetByIdAsync(id);
                return Results.Ok(blogPost);
            });

            group.MapPost(string.Empty, async ([FromBody] BlogPost blogPost, IBlogPostService blogPostService) =>
            {
                var createdId = await blogPostService.CreateAsync(blogPost);
                return Results.Created($"/posts/{createdId}", new { Id = createdId });
            });

            return app;
        }
    }
}
