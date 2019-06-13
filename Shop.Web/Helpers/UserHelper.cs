using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;

public class UserHelper : IUserHelper
{
    private readonly UserManager<User> userManager;

    public UserHelper(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<IdentityResult> AddUserAsync(User user, string password)
    {
        return await this.userManager.CreateAsync(user, password);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await this.userManager.FindByEmailAsync("channet@ityh.com");
        if (user == null)
        {
            user = new User
            {
                FirstName = "Luis",
                LastName = "Channet",
                Email = "channet@ityh.com",
                UserName = "channet@ityh.com"
            };

            var result = await this.userManager.CreateAsync(user, "123456");
            if (result != IdentityResult.Success)
            {
            }
        }

        //var user = await this.userManager.FindByEmailAsync(email);
        return await this.userManager.FindByEmailAsync(email);
        //return user;
    }
}
