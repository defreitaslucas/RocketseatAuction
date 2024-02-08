using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entity;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Auctions.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;
        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var userId = _loggedUser.User();

            var offer = new Offer
            {
                ItemId = itemId,
                UserId = userId.Id,
                Price = request.Price,
                CreatedOn = DateTime.Now
            };

            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
