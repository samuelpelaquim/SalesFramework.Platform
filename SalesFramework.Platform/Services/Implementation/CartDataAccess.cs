using SalesFramework.Platform.Model;
using SalesFramework.Platform.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Services.Implementation
{
    public class CartDataAccess : IDataAccess<Cart>
    {
        public bool Create(Cart item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Cart> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<Cart> SelectAllBySearchTerm(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Cart SelectSingle(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cart item)
        {
            throw new NotImplementedException();
        }
    }
}
