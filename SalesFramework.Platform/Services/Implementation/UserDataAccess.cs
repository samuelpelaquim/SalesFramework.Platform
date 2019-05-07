using SalesFramework.Platform.Model;
using SalesFramework.Platform.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Services.Implementation
{
    public class UserDataAccess : IDataAccess<User>
    {
        public bool Create(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(System.Int64 ID)
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllBySearchTerm(System.String searchTerm)
        {
            throw new NotImplementedException();
        }

        public User SelectSingle(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
