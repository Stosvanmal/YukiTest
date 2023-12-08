using Microsoft.EntityFrameworkCore;
using YukiTest.Domain.Model;

namespace YukiTest.Infrastructure
{
    public partial class YukiContext:DbContext
    {
        public YukiContext(DbContextOptions<YukiContext> options)
        : base(options)
    {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Author__3214EC0731894C22");

                entity.ToTable("Author");

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Post__3214EC071374314F");

                entity.ToTable("Post");

                entity.Property(e => e.Description).HasMaxLength(150);
                entity.Property(e => e.Content);
                entity.Property(e => e.Title).HasMaxLength(50);
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}