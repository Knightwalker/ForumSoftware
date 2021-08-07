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

            base.OnModelCreating(builder);
        }
    }
}
