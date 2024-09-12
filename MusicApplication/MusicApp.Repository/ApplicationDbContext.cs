using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusicApp.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using System.Net.Mail;
using MusicApp.Domain.BookApp;
using MusicApp.Domain.BookApp.Identity;

namespace MusicApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<UserPlaylist> UserPlaylists { get; set; }
        public virtual DbSet<TrackInPlaylist> TrackInPlaylists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TrackInOrder> TrackInOrders { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class SecondDbContext : IdentityDbContext<BookStoreApplicationUser>

    {

        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options) { }

        // DbSet properties...
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookInOrder> BookInOrders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<OrderBook> Orders { get; set; }
        public virtual DbSet<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}
