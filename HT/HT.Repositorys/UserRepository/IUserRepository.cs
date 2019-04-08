using HT.EFCode.EntityFrameworkCore;
using HT.EFCode.Entitys;
using HT.Repositorys.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Repositorys.UserRepository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        T MapTo<T>(UserEntity user) where T : class;
        UserEntity MapTo<T>(T input) where T : class;
    }
}
