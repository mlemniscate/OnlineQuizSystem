namespace Quiz.Domain.Services;

public interface IUserRepository
{
    public Task Create(User user);
}