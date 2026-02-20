using EasyClothing.App.Common;
using MediatR;

public record ConsumerSignUpCommand(
    string Name,
    string Email,
    string Password,
    string Cpf,
    string Phone,
    string Cep,
    string Street,
    string City,
    string State,
    string Country,
    string? Complement
) : IRequest<Result<Guid>>;