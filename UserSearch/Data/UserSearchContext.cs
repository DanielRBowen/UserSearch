using Microsoft.EntityFrameworkCore;
using UserSearch.Models;

namespace UserSearch.Data
{
    public class UserSearchContext : DbContext
    {
        public UserSearchContext(DbContextOptions<UserSearchContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Media> Media { get; set; }

        public DbSet<UserMedia> UserMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userMedia = modelBuilder.Entity<UserMedia>();
            userMedia.HasKey(userMedia0 => new { userMedia0.UserId, userMedia0.MediaId });

            userMedia.HasOne(userMedia0 => userMedia0.User)
                .WithMany(user => user.UserMedia)
                .HasForeignKey(userMedia0 => userMedia0.UserId);

            userMedia.HasOne(userMedia0 => userMedia0.Media)
                .WithMany()
                .HasForeignKey(userMedia0 => userMedia0.MediaId);

            return;
        }
    }
}
