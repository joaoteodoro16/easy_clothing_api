using EasyClothing.Domain.Entities;
using EasyClothing.Domain.Repositories;
using EasyClothing.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EasyClothingDbContext context) : base(context)
        {
        }
    }
}
