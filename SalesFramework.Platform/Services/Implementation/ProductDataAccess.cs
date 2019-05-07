using SalesFramework.Platform.Model;
using SalesFramework.Platform.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Services.Implementation
{
    public class ProductDataAccess : IDataAccess<Product>
    {
        public bool Create(Product item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Product> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> SelectAllBySearchTerm(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Product SelectSingle(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
