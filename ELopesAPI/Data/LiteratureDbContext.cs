using ELopesAPI.Models.Entities;
using ELopesAPI.Models.JoinEntities;
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
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsPostTag> NewsPostsTags { get; set; }

        public DbSet<Poem> Poems { get; set; }
        public DbSet<PoemTag> PoemTags { get; set; }
        public DbSet<PoemTagJoin> PoemTagJoins { get; set; }


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

            modelBuilder.Entity<NewsPost>().ToTable("NewsPost");

            modelBuilder.Entity<Comment>()
                .HasOne<NewsPost>(c => c.NewsPost)
                .WithMany(c => c.Comments) 
                .HasForeignKey(c => c.NewsPostId)
                .IsRequired(false);

            modelBuilder.Entity<BlogPost>().ToTable("BlogPost");

            modelBuilder.Entity<Comment>()
                .HasOne<BlogPost>(c => c.BlogPost)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.BlogPostId)
                .IsRequired(false);

            modelBuilder.Entity<NewsPost>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.NewsPosts)
                .UsingEntity<NewsPostTag>();

            modelBuilder.Entity<Poem>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.Poems)
                .UsingEntity<PoemTagJoin>();
        }

        public bool BookExists(int id)
        {
            return Books.Any(e => e.Id == id);
        }
    }
}
