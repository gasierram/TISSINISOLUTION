using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TissiniModels;
using TissiniunitOfWork;
using TissiniWebApi.Authentication;

namespace TissiniWebApi.Controllers
{
    [Route("api/token")]
    public class TokenController:Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork; 
        }

        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480//minutes

            };
            return token;
        
        }
    }
}
