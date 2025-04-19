using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using ProsigliereBlogPost.Api.Data.Context;
using ProsigliereBlogPost.Api.Data.Repositories;
using ProsigliereBlogPost.Api.Data.Repositories.Interfaces;
using ProsigliereBlogPost.Api.Middlewares;
using ProsigliereBlogPost.Api.Services;
using ProsigliereBlogPost.Api.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProsigliereBlogPost.Api.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddDatabaseComponents(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDbContext<AppDbContext>(options =>
                    options.UseConfiguration(builder.Configuration))
                .AddScoped<DbContext, AppDbContext>();

            return builder;
        }

        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IBlogPostRepository, BlogPostRepository>()
                .AddScoped<ICommentsRepository, CommentsRepository>();

            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IBlogPostService, BlogPostService>()
                .AddScoped<ICommentService, CommentService>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureJsonResponse(this WebApplicationBuilder builder)
        {
            builder.Services
                .Configure<JsonOptions>(options =>
                    {
                        options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                        options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    });

            return builder;
        }

        public static WebApplication BuildConfiguredApplication(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseHttpsRedirection()
                .UseMiddleware<ExceptionHandlingMiddleware>();

            app.AddRoutes();

            return app;
        }
    }
}
