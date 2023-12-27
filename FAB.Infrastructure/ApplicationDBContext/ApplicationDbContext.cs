using FAB.Domain.Common;
using FAB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAB.Infrastructure.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Server=localhost;Port=5432;Database=academic_blog;User ID=postgres;Password=root;Integrated Security=True;Pooling=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSet
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<BannedInfor> BannedInfors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.HasDefaultSchema("fab");

            modelBuilder.Entity<Account>()
                .HasOne(p => p.Field)
                .WithMany(d => d.Account)
                .HasForeignKey(p => p.FieldId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Account>()
                .HasMany(p => p.Awards)
                .WithMany(d => d.Accounts)
                .UsingEntity(j => j.ToTable("account_award"));

            modelBuilder.Entity<BannedInfor>()
                 .HasOne(p => p.Account)
                 .WithOne(d => d.BannedInfor)
                 .HasForeignKey<BannedInfor>(p => p.AccountId)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Blog>()
                 .HasOne(p => p.Reviewer)
                 .WithMany(d => d.ReviewedBlogs)
                 .HasForeignKey(p => p.ReviewId)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Blog>()
                .HasOne(p => p.Author)
                .WithMany(d => d.OwnedBlogs)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Blog>()
                .HasOne(p => p.Category)
                .WithMany(d => d.Blogs)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Commentor)
                .WithMany(d => d.Comments)
                .HasForeignKey(p => p.CommentorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(p => p.ReplyTo)
                .WithOne(d => d.CommentTo)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.FromAccount)
                .WithOne(d => d.From)
                .HasForeignKey<Notification>(p => p.FromAccountId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Notification>()
                .HasOne(p => p.ToAccount)
                .WithMany(d => d.Tos)
                .HasForeignKey(p => p.ToAccountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
