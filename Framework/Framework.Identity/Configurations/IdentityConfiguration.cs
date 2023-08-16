using Microsoft.IdentityModel.Tokens;

namespace Framework.Identity.Configurations;

public class IdentityConfiguration
{
    public string IdentityConnectionString { get; set; }
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string Secret { get; set; }
}