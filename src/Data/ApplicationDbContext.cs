namespace ForumSoftware.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ForumSoftware.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Topic>()
                .HasOne(c => c.Forum)
                .WithMany(t => t.Topics)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Forum>().HasData(new Forum { Id = 1, Name = "Regulations", Description = "Test" });
            builder.Entity<Forum>().HasData(new Forum { Id = 2, ForumId = 1, Name = "The Guilds And Factions", Description = "Test" });
            builder.Entity<Forum>().HasData(new Forum { Id = 3, ForumId = 1, Name = "The Rosters", Description = "Test" });
            builder.Entity<Forum>().HasData(new Forum { Id = 4, ForumId = 2, Name = "The Guilds And Factions Test", Description = "Test" });

            builder.Entity<Topic>().HasData(new Topic { Id = 1, ForumId = 1, Name = "The Roleplay Regulations" });
            
            base.OnModelCreating(builder);

        }
    }
}
