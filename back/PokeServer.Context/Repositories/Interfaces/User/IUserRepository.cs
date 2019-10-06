using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Context.Repositories.Interfaces.User
{
    public interface IUserRepository
    {
        public void Add(Models.User.User user);
        public void Delete(Models.User.User user);
        public void Save(Models.User.User user);
    }
}
