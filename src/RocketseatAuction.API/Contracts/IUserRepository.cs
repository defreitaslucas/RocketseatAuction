using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
