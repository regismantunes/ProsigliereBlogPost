using ProsigliereBlogPost.Api.Data.Dto;
using ProsigliereBlogPost.Api.Services.Interfaces;

namespace ProsigliereBlogPost.Api.Routes
{
    internal static class BlogPostMap
    {
        public static void MapBlogPostRoutes(this IEndpointRouteBuilder app)
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
                return blogPost is not null ? Results.Ok(blogPost) : Results.NotFound();
            });

            group.MapPost(string.Empty, async (BlogPost blogPost, IBlogPostService blogPostService) =>
            {
                var createdId = await blogPostService.CreateAsync(blogPost);
                return Results.Created($"/posts/{createdId}", createdId);
            });

            group.MapCommentRoutes();
        }
    }
}
