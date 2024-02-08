using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
