using SalesFramework.Platform.Helpers;
using SalesFramework.Platform.Model;
using SalesFramework.Platform.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalesFramework.Platform.Services.Implementation
{
    /// <summary>
    /// The Product service for Database related operations.
    /// </summary>
    public class ProductDataAccess : IDataAccess<Product>
    {
        #region Fields and Constructors
        //Connection String field.
        private System.String _connectionString;

        /// <summary>
        /// Default constructor for the ProductDataAccess class.
        /// </summary>
        /// <param name="ConnectionString">The connection string to be used.</param>
        public ProductDataAccess(System.String ConnectionString)
        {
            this._connectionString = ConnectionString;
        }
        #endregion Fields and Constructors

        #region Methods
        /// <summary>
        /// Create a new Product record in the Database.
        /// </summary>
        /// <param name="item">The Product object.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Create(Product item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spInsertProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Discount", item.Discount);

                //TO DO: Implement user-defined table-type for product characteristics.

                //TO DO: Implement user-defined table-type for product images.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Deletes a Product record from the database.
        /// </summary>
        /// <param name="ID">The Product ID for deletion.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Delete(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spDeleteProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Gets all products from the Database.
        /// </summary>
        /// <returns>A List containing all Product objects in the database.</returns>
        public List<Product> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Product> products = ORMHelper.MapCollection<Product>(reader);
                    return products;
                }
            }
        }

        /// <summary>
        /// Gets all Product objects from the Database that contain the searchTerm string in one of it's fields.
        /// </summary>
        /// <param name="searchTerm">The string to search for.</param>
        /// <returns>A List of Product objects which contain the searchTerm string in one of it's fields.</returns>
        public List<Product> SelectAllBySearchTerm(System.String searchTerm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllProductsBySearchTerm", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Product> products = ORMHelper.MapCollection<Product>(reader);
                    return products;
                }
            }
        }

        /// <summary>
        /// Gets a single Product record from the Database.
        /// </summary>
        /// <param name="ID">The Product ID.</param>
        /// <returns>The Product record from the database.</returns>
        public Product SelectSingle(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectSingleProductByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    Product product = ORMHelper.MapSingle<Product>(reader);
                    return product;
                }
            }
        }

        /// <summary>
        /// Updates a Product record in the Database.
        /// </summary>
        /// <param name="item">The Product object to be updated.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Update(Product item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spInsertProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Discount", item.Discount);

                //TO DO: Implement user-defined table-type for product characteristics.

                //TO DO: Implement user-defined table-type for product images.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }
        #endregion Methods
    }
}