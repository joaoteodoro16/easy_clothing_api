using AutoMapper;
using EasyClothing.App.Usecases.Features.User.Commands.SignUp;
using EasyClothing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ConsumerSignUpCommand, User>()
                .ConstructUsing(C => User.CreateCustomer(
                    C.Name, C.Email, C.Password,C.Cpf, C.Phone,C.Cep,C.Street,C.City,C.State,C.Country, C.Complement
                    ));
        }
    }
}
