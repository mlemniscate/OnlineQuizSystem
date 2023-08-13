using MediatR;
using Quiz.Application.Contracts;

namespace Quiz.Application;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{


    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("I am in the create user command handler");
    }
}