using BlogProjetArticle.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogProjetArticle.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Subjects)
                .WithMany(t => t.Articles);
        }
    }
}
