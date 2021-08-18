namespace ForumSoftware.Data
{
    using System.Collections.Generic;
    using ForumSoftware.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Forum>()
                .HasOne(f => f.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(key => key.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Topic>()
                .HasOne(c => c.Forum)
                .WithMany(t => t.Topics)
                .OnDelete(DeleteBehavior.Restrict);

            this.SeedForums(ref builder);
            builder.Entity<Topic>().HasData(new Topic { Id = 1, ForumId = 1, Name = "The Roleplay Regulations" });

            base.OnModelCreating(builder);

        }

        private void SeedForums(ref ModelBuilder builder)
        {
            List<Forum> forums = new List<Forum>();
            forums.Add(new Forum { Id = 1, ParentId = null, Type = "category", Name = "General" });
            forums.Add(new Forum { Id = 2, ParentId = 1, Type = "forum", Name = "Regulations & Guidelines", Description = "Test" });
            forums.Add(new Forum { Id = 3, ParentId = 2, Type = "forum", Name = "The Guilds And Factions", Description = "Test" });
            forums.Add(new Forum { Id = 4, ParentId = 2, Type = "forum", Name = "The Rosters", Description = "Test" });

            builder.Entity<Forum>().HasData(forums);
        }
    }
}
