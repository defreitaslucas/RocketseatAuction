using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entity;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAcutionUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAcutionUseCase(IAuctionRepository repository)
        {
            _repository = repository;
        }
        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
