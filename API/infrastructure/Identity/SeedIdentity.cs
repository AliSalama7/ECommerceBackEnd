using Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class SeedIdentity
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "LOL",
                    Email = "Admin@lol.com",
                    UserName = "Admin@lol.com",
                    Address = new Address
                    {
                        FirstName = "Ali",
                        LastName = "Abosalama",
                        Street = "Nasserya",
                        City = "Samanoud",
                        State = "Gharbia",
                        ZipCode = "1324"
                    }
                };
                await userManager.CreateAsync(user , "123@Ali");
            }
        }
    }
}
