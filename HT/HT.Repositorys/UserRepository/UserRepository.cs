using HT.EFCode.EntityFrameworkCore;
using HT.EFCode.Entitys;
using HT.Repositorys.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Ws.CommonWeb.Interfaces;
using Ws.CommonWeb.ObjectMap;

namespace HT.Repositorys.UserRepository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository, ISupControl
    {
        private readonly IObjectMap _objectMap;
        public UserRepository(HTDbContext dbContext, IObjectMap objectMap) : base(dbContext)
        {
            _objectMap = objectMap;
        }
        public T MapTo<T>(UserEntity user) where T : class
        {
            return _objectMap.Map<T>(user);
        }
        public UserEntity MapTo<T>(T input) where T : class
        {
            return _objectMap.Map<UserEntity>(input);
        }
    }
}
