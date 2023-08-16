using Framework.Application;
using Quiz.Domain.Enums;

namespace Quiz.Application.Contracts;

public record CreateUserCommand : Command
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}