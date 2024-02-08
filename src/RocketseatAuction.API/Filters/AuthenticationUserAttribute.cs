﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationUserAttribute(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                var email = FromBase64(token);

                var exist = _userRepository.ExistUserWithEmail(email);

                if (!exist)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail not valid");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication))
                throw new Exception("Token is missing.");

            return authentication["Bearer ".Length..]; // pega o token sem o "Bearer "

            // metodo simples pegar o token sem o Bearer
            //return authentication.Replace("Bearer ", "");
        }

        private string FromBase64(string base64)
        {
            var bytes = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}