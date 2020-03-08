using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogNetCore.AppService.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Comments");

            entityTypeBuilder
                .HasOne<User>(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            entityTypeBuilder
                .HasOne<Post>(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.PostId);
        }
    }
}
