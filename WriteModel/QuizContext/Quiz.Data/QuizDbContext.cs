using Framework.Data;
using Microsoft.EntityFrameworkCore;
using Quiz.Data.TypeConfigurations.Users;

namespace Quiz.Data;

public class QuizDbContext : BaseDbContext
{
    public QuizDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTypeConfiguration).Assembly);
    }
    
}