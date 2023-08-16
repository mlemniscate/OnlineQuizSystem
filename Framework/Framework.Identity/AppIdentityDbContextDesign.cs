using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Framework.Identity;

public class AppIdentityDbContextDesign : IDesignTimeDbContextFactory<AppIdentityDbContext>
{
    public AppIdentityDbContext CreateDbContext(string[] args)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
        dbContextOptionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=QuizIdentityDB;Trusted_Connection=true");
        return new AppIdentityDbContext(dbContextOptionsBuilder.Options);
    }
}