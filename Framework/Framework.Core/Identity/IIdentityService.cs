using Framework.Identity.Models;

namespace Framework.Core.Identity;

public interface IIdentityService
{
    public Task Register(RegisterModel model);
    public Task Login();
    public Task AddRolesAsync(string[] roles);
}