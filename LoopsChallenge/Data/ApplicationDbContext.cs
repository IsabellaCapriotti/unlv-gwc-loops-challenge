using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoopsChallenge.Data.Entities;

namespace LoopsChallenge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<UserInfo> UserInfo { get; set; } = null;
        public DbSet<ProfileDetails> ProfileDetails { get; set; } = null; 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
    }


}