using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogNetCore.AppService.Mapping
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Posts");

            entityTypeBuilder
               .HasOne<User>(x => x.Author)
               .WithMany()
               .HasForeignKey(x => x.AuthorId);

            entityTypeBuilder
                .HasOne<Category>(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasMany<Comment>(x => x.Comments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
