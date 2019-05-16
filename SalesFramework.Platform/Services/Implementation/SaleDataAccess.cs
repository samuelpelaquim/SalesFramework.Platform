using SalesFramework.Platform.Entities;
using SalesFramework.Platform.Services.Contracts;
using System.Collections.Generic;

namespace SalesFramework.Platform.Services.Implementation
{
    public class SaleDataAccess : IDataAccess<Sale>
    {
        public bool Create(Sale item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long ID)
        {
            throw new System.NotImplementedException();
        }

        public List<Sale> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Sale> SelectAllBySearchTerm(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public Sale SelectSingle(long ID)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Sale item)
        {
            throw new System.NotImplementedException();
        }
    }
}
