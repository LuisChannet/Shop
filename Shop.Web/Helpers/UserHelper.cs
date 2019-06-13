using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;
using Shop.Web.Models;

public class UserHelper : IUserHelper
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;

    }

    public async Task<IdentityResult> AddUserAsync(User user, string password)
    {
        return await this.userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
    {
        return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);

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

    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        return await this.signInManager.PasswordSignInAsync(
           model.Username,
           model.Password,
           model.RememberMe,
           false);

    }

    public async Task LogoutAsync()
    {
        await this.signInManager.SignOutAsync();

    }

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        return await this.userManager.UpdateAsync(user);

    }
}
