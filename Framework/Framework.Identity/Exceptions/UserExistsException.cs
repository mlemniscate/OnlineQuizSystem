namespace Framework.Identity.Exceptions;

public class UserExistsException : IdentityException
{
    public override string Message => "User exists with this username";
}