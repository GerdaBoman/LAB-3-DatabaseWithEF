using LAB_3.Model;
using Microsoft.EntityFrameworkCore;

namespace LAB_3.Data
{
    public partial class BokHandelContext : DbContext
    {
        public BokHandelContext()
        {
        }

        public BokHandelContext(DbContextOptions<BokHandelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<TitlesPerAuthor> TitlesPerAuthors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BokHandel;Integrated Security = true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IsbnId)
                    .HasName("PK__Books__7C97DF4A77FDA38E");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__Author_ID__300424B4");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Books__Genre_ID__30F848ED");

                entity.HasOne(d => d.Publishers)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublishersId)
                    .HasConstraintName("FK__Books__Publisher__2F10007B");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.ShopId, e.IsbnId })
                    .HasName("PK__Inventor__EBC1EB24AF647E4E");

                entity.HasOne(d => d.Isbn)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IsbnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Quant__2C3393D0");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Shop___31EC6D26");
            });

            modelBuilder.Entity<TitlesPerAuthor>(entity =>
            {
                entity.ToView("Titles_Per_Authors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
