﻿using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entity;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers
{
    public class AuctionController : RocketseatAuctionController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAcutionUseCase useCase)
        {
            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
