using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProsigliereBlogPost.Api.Extensions;

namespace ProsigliereBlogPost.Api.Data.Context
{
    public class AppDbContextFactory() : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseConfiguration(configuration);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
