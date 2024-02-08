using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entity;

namespace RocketseatAuction.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
        {
            _httpContext = httpContext;
            _repository = repository;
        }
        public User User()
        {
            var token = TokenOnRequest(_httpContext.HttpContext!);
            var email = FromBase64(token);

            return _repository.GetUserByEmail(email);
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = _httpContext.HttpContext!.Request.Headers.Authorization.ToString();

            return authentication["Bearer ".Length..];
        }

        private string FromBase64(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
