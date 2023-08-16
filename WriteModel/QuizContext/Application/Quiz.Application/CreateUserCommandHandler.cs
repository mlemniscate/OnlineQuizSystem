using Framework.Core.Identity;
using Framework.Identity.Models;
using MediatR;
using Quiz.Application.Contracts;
using Quiz.Domain;
using Quiz.Domain.Services;

namespace Quiz.Application;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IIdentityService identityService;

    public CreateUserCommandHandler(IUserRepository userRepository,
        IIdentityService identityService)
    {
        this.userRepository = userRepository;
        this.identityService = identityService;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FirstName, request.LastName, request.Email,
            request.BirthDate, request.Role);

        var registerModel = new RegisterModel
        {
            Username = request.UserName,
            Email = request.Email,
            Password = request.Password,
        };

        await userRepository.Create(user);
        await identityService.Register(registerModel);
    }
}