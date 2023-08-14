using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Quiz.Data;

public class QuizDesignTimeDbContext : IDesignTimeDbContextFactory<QuizDbContext>
{

    public QuizDesignTimeDbContext()
    {
    }

    public QuizDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QuizDB;Trusted_Connection=true");

        return new QuizDbContext(optionsBuilder.Options);
    }
}