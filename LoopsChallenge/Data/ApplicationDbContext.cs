using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<UserInfo> UserInfo { get; set; } = null;
        public DbSet<ProfileDetails> ProfileDetails { get; set; } = null;
        public DbSet<Company> Company { get; set; } = null;
        public DbSet<Review> Review { get; set; } = null;
        public DbSet<Tag> Tag { get; set; } = null;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>()
                .HasIndex(t => t.NormalizedTagText)
                .IsUnique();
            
            foreach(string tagText in Constants.DefaultTags)
            {
                builder.Entity<Tag>()
                    .HasData(new Tag
                    {
                        TagText = tagText,
                        NormalizedTagText = tagText.ToLowerInvariant(),
                        IsDefaultSuggested = true
                    });
            }

            base.OnModelCreating(builder);

        }
    }


}