using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        public RocketseatAuctionDbContext(DbContextOptions options) : base(options) { }
        // DbSet serve para referenciar o nome da tabela no banco de dados
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
