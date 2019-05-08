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
    /// The Cart service for Database related operations.
    /// </summary>
    public class CartDataAccess : IDataAccess<Cart>
    {
        #region Fields and Constructors
        //Connection String field.
        private System.String _connectionString;

        /// <summary>
        /// Default constructor for the CartDataAccess class.
        /// </summary>
        /// <param name="ConnectionString">The connection string to be used.</param>
        public CartDataAccess(System.String ConnectionString)
        {
            this._connectionString = ConnectionString;
        }
        #endregion Fields and Constructors

        #region Methods
        /// <summary>
        /// Create a new Cart record in the Database.
        /// </summary>
        /// <param name="item">The Cart object.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Create(Cart item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spInsertCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@UserID", item.UserID);
                cmd.Parameters.AddWithValue("@Shipping", item.Shipping);

                //TO DO: Implement user-defined table-type for products.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Deletes a Cart record from the database.
        /// </summary>
        /// <param name="ID">The Cart ID for deletion.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Delete(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spDeleteCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Gets all carts from the Database.
        /// </summary>
        /// <returns>A List containing all Cart objects in the database.</returns>
        public List<Cart> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllCarts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Cart> carts = ORMHelper.MapCollection<Cart>(reader);
                    return carts;
                }
            }
        }

        /// <summary>
        /// Gets all Cart objects from the Database that contain the searchTerm string in one of it's fields.
        /// </summary>
        /// <param name="searchTerm">The string to search for.</param>
        /// <returns>A List of Cart objects which contain the searchTerm string in one of it's fields.</returns>
        public List<Cart> SelectAllBySearchTerm(System.String searchTerm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllCartsBySearchTerm", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Cart> carts = ORMHelper.MapCollection<Cart>(reader);
                    return carts;
                }
            }
        }

        /// <summary>
        /// Gets a single Cart record from the Database.
        /// </summary>
        /// <param name="ID">The Cart ID.</param>
        /// <returns>The Cart record from the database.</returns>
        public Cart SelectSingle(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectSingleCartByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    Cart cart = ORMHelper.MapSingle<Cart>(reader);
                    return cart;
                }
            }
        }

        /// <summary>
        /// Updates a Cart record in the Database.
        /// </summary>
        /// <param name="item">The Cart object to be updated.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Update(Cart item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spUpdatetCart", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@ID", item.ID);
                cmd.Parameters.AddWithValue("@UserID", item.UserID);
                cmd.Parameters.AddWithValue("@Shipping", item.Shipping);

                //TO DO: Implement user-defined table-type for products.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }
        #endregion Methods
    }
}
