using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
