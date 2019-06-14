using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Helpers;
using Shop.Web.Models;
using System.Threading.Tasks;

public class UserHelper : IUserHelper
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    public async Task<IdentityResult> AddUserAsync(User user, string password)
    {
        return await userManager.CreateAsync(user, password);
    }

    public async Task AddUserToRoleAsync(User user, string roleName)
    {
        await userManager.AddToRoleAsync(user, roleName);

    }

    public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
    {
        return await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

    }


    public async Task CheckRoleAsync(string roleName)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName
            });
        }
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync("channet@ityh.com");
        if (user == null)
        {
            user = new User
            {
                FirstName = "Luis",
                LastName = "Channet",
                Email = "channet@ityh.com",
                UserName = "channet@ityh.com"
            };

            var result = await userManager.CreateAsync(user, "123456");
            if (result != IdentityResult.Success)
            {
            }
        }

        await CheckRoleAsync("Admin");
        await AddUserToRoleAsync(user, "Admin");
        await CheckRoleAsync("Customer");
        //var user = await this.userManager.FindByEmailAsync(email);
        return await userManager.FindByEmailAsync(email);
        //return user;
    }

    public async Task<bool> IsUserInRoleAsync(User user, string roleName)
    {
        return await userManager.IsInRoleAsync(user, roleName);
    }

    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        return await signInManager.PasswordSignInAsync(
           model.Username,
           model.Password,
           model.RememberMe,
           false);

    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();

    }

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        return await userManager.UpdateAsync(user);

    }

    public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
    {
        return await signInManager.CheckPasswordSignInAsync(
            user,
            password,
            false);
    }

}
