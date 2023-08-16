using Framework.Core.Domain;
using Quiz.Domain.Enums;

namespace Quiz.Domain;

public class User : BaseEntity
{
    public User(string firstName, string lastName,
        string email, DateTime? birthDate,
        UserRole role)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetBirthDate(birthDate);
        SetRole(role);
        IsActive = false;
    }

    protected User(){}

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }

    private void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(FirstName));

        FirstName = firstName;
    }

    private void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentNullException(nameof(LastName));

        LastName = lastName;
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(Email));

        Email = email;
    }
    
    private void SetBirthDate(DateTime? birthDate)
    {
        if (birthDate == null)
            throw new ArgumentNullException(nameof(BirthDate));

        BirthDate = birthDate.Value;
    }

    private void SetRole(UserRole role)
    {
        Role = role;
    }

}