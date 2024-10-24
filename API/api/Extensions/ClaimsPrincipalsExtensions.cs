﻿using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalsExtensions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}
