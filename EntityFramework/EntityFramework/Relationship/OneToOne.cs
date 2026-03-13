using EntityFrameworkCore_DotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_DotNet.Relationship
{
    internal class OneToOne
    {
        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<UserProfile> UserProfiles { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .HasOne(u => u.Profile)      // User عنده Profile واحد
                    .WithOne(p => p.User)        // Profile مرتبط بـ User واحد فقط
                    .HasForeignKey<UserProfile>(p => p.UserId) // العمود UserId في UserProfile هو FK
                    .IsRequired();               // العلاقة إلزامية
            }
        }
    }
}
