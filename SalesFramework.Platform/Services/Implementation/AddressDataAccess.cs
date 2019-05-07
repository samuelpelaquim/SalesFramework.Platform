using SalesFramework.Platform.Model;
using SalesFramework.Platform.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Services.Implementation
{
    public class AddressDataAccess : IDataAccess<Address>
    {
        public bool Create(Address item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Address> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<Address> SelectAllBySearchTerm(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Address SelectSingle(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Address item)
        {
            throw new NotImplementedException();
        }
    }
}
