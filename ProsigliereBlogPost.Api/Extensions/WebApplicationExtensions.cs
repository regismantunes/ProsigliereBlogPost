using ProsigliereBlogPost.Api.Routes;

namespace ProsigliereBlogPost.Api.Extensions
{
    internal static class WebApplicationExtensions
    {
        public static void AddRoutes(this IEndpointRouteBuilder builder)
        {
            builder.MapGroup("api")
                .MapBlogPostRoutes()
                .MapCommentRoutes();
        }
    }
}