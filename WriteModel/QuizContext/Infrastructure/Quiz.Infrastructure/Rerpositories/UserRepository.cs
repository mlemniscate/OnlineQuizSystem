using Framework.Data;
using Framework.Infrastrucutre.Repositories;
using Quiz.Domain;
using Quiz.Domain.Services;

namespace Quiz.Infrastructure.Rerpositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }

    public void Create(User user)
    {
        base.Create(user);
    }
}