using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MusicApp.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using System.Net.Mail;

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
}
