using Framework.Core.Identity;
using Framework.Identity;
using Framework.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace OnlineQuizSystem.API.Seed;

public class SeedData
{
    private readonly IIdentityService identityService;

    public SeedData(IIdentityService identityService)
    {
        this.identityService = identityService;
    }

    public async Task Seed()
    {
        await SeedRoles();
    }

    private async Task SeedRoles()
    {
        await identityService.AddRolesAsync(new[] { UserRoles.Admin, UserRoles.Student, UserRoles.Teacher });
    }
}