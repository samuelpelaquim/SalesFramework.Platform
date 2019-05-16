using SalesFramework.Platform.Entities;
using SalesFramework.Platform.Services.Contracts;
using System.Collections.Generic;

namespace SalesFramework.Platform.Services.Implementation
{
    public class CategoryDataAccess : IDataAccess<Category>
    {
        public bool Create(Category item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long ID)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Category> SelectAllBySearchTerm(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public Category SelectSingle(long ID)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Category item)
        {
            throw new System.NotImplementedException();
        }
    }
}
