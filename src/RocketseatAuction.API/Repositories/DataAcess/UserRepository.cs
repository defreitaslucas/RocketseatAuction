﻿using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Repositories.DataAcess
{
    public class UserRepository : IUserRepository
    {
        private readonly RocketseatAuctionDbContext _dbContext;
        public UserRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

        public bool ExistUserWithEmail(string email) => _dbContext.Users.Any(user => user.Email.Equals(email));

        public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
