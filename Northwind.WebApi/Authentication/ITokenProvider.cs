using Microsoft.IdentityModel.Tokens;
using Northwind.Models;
using System;

namespace Northwind.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
    
    }
}
