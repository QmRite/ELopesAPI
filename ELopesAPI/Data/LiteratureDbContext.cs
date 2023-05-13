using ELopesAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ELopesAPI.Data
{
    public class LiteratureDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<BookLink> BooksLinks { get; set; }
        public DbSet<BookReview> BooksReviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }

        public LiteratureDbContext(DbContextOptions<LiteratureDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookReview)
                .WithOne(r => r.Book)
                .HasForeignKey<BookReview>(r => r.BookId);

            modelBuilder.Entity<Book>()
                .HasMany<BookLink>(b => b.BookLinks)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<BookLink>()
                .HasOne<Shop>(l => l.Shop)
                .WithMany()
                .HasForeignKey(l => l.ShopId);

           // modelBuilder.Entity<Commented>().ToTable("Commented");

            modelBuilder.Entity<Post>().ToTable("Posts");

            modelBuilder.Entity<Comment>()
                .HasOne<Post>(c => c.Post)
                .WithMany(c => c.Comments) 
                .HasForeignKey(c => c.PostId)
                .IsRequired(false);

            modelBuilder.Entity<NewsPost>().ToTable("NewsPosts");

            modelBuilder.Entity<Comment>()
                .HasOne<NewsPost>(c => c.NewsPost)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.NewsPostId)
                .IsRequired(false);

            //modelBuilder.Entity<Commented>()
            //    .ToTable("Commented", t => t.ExcludeFromMigrations());
        }

        public bool BookExists(int id)
        {
            return Books.Any(e => e.Id == id);
        }
    }
}
