using Microsoft.EntityFrameworkCore;
using ProsigliereBlogPost.Api.Data.Entities;

namespace ProsigliereBlogPost.Api.Data.Context
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
