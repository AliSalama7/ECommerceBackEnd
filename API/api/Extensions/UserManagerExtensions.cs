using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddress(
            this UserManager<AppUser> userManager , ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.Include(u => u.Address)
                .SingleOrDefaultAsync(u => u.Email == email);
        }
        public static async Task<AppUser> FindByEmailFromPrincipal(
                    this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            return await userManager.Users.SingleOrDefaultAsync
                (u => u.Email == user.FindFirstValue(ClaimTypes.Email));
        } 
    }
}
