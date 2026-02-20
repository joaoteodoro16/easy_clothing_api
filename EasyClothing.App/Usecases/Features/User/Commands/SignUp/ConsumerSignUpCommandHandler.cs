using AutoMapper;
using EasyClothing.App.Common;
using EasyClothing.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace EasyClothing.App.Usecases.Features.User.Commands.SignUp
{
    public class ConsumerSignUpCommandHandler : IRequestHandler<ConsumerSignUpCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public ConsumerSignUpCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(ConsumerSignUpCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetUserByEmail(request.Email);
            if(userExists != null) return Result<Guid>.Failure(new Error(ErrorCode.Conflict, Messages.User.EmailJaVinculadoConta));

            var entity = _mapper.Map<Domain.Entities.User>(request);
            var result = await _userRepository.AddAsync(entity);

            return Result<Guid>.Success(result.Id, Messages.User.UsuarioCadastrado);
        }
    }
}
