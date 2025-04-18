using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsigliereBlogPost.Api.Data.Entities;

namespace ProsigliereBlogPost.Api.Data.Context.Configurations
{
    internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Content)
                .IsRequired()
                .HasColumnType(DefaultTypes.Content);

            builder.Property(x => x.BlogPostId)
                .IsRequired();

            builder.HasOne(x => x.BlogPost)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogPostId);
        }
    }
}
