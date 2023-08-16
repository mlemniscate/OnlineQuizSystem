using Framework.Core.Identity;
using Framework.Identity.Exceptions;
using Framework.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Framework.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration configuration;

    public IdentityService(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.configuration = configuration;
    }

    public async Task Register(RegisterModel model)
    {
        var userExistsInIdentity = await userManager.FindByNameAsync(model.Username);
        if (userExistsInIdentity != null)
            throw new UserExistsException();

        IdentityUser user = new IdentityUser
        {
            UserName = model.Username,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new Exception("There is a problem in server. Please try again later!");
    }

    public Task Login()
    {
        throw new NotImplementedException();
    }

    public async Task AddRolesAsync(string[] roles)
    {
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}