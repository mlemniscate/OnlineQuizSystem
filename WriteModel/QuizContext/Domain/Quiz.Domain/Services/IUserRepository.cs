using Framework.Core.Domain;

namespace Quiz.Domain.Services;

public interface IUserRepository : IRepository
{
    public void Create(User user);
}