using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(15);
        builder.Property(x => x.BlogPostId).IsRequired();
        builder.Property(x => x.Context).IsRequired().HasMaxLength(200);
    }
}
