using ProsigliereBlogPost.Api.Routes;

namespace ProsigliereBlogPost.Api.Extensions
{
    internal static class WebApplicationExtensions
    {
        public static void AddRoutes(this IEndpointRouteBuilder builder)
        {
            var groupApi = builder.MapGroup("api");

            groupApi.MapBlogPostRoutes();
        }
    }
}
