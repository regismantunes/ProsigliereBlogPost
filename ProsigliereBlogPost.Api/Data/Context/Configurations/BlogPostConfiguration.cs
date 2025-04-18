using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsigliereBlogPost.Api.Data.Entities;

namespace ProsigliereBlogPost.Api.Data.Context.Configurations
{
    internal sealed class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasColumnType(DefaultTypes.Content);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.BlogPost)
                .HasForeignKey(x => x.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
