using BasketballForEveryone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasketballForEveryone.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BPlayer_BestPlayer>().HasKey(bb => new
            {
                bb.BPlayerId,
                bb.BestPlayerId
            });

            modelBuilder.Entity<BPlayer_BestPlayer>().HasOne(bp => bp.BestPlayer).WithMany(bb => bb.BPlayer_BestPlayers)
                .HasForeignKey(bp =>bp.BestPlayerId);
            modelBuilder.Entity<BPlayer_BestPlayer>().HasOne(bp => bp.BPlayer).WithMany(bb => bb.BPlayer_BestPlayers)
                .HasForeignKey(bp => bp.BPlayerId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BPlayer> BPlayers { get; set; }
        public DbSet<BestPlayer> BestPlayers { get; set; }
        public DbSet<BPlayer_BestPlayer> BPlayers_BestPlayers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        //Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
