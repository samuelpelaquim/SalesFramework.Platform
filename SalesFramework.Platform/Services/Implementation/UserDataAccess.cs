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
    /// The User service for Database related operations.
    /// </summary>
    public class UserDataAccess : IDataAccess<User>
    {
        #region Fields and Constructors
        //Connection String field.
        private System.String _connectionString;

        /// <summary>
        /// Default constructor for the UserDataAccess class.
        /// </summary>
        /// <param name="ConnectionString">The connection string to be used.</param>
        public UserDataAccess(System.String ConnectionString)
        {
            this._connectionString = ConnectionString;
        }
        #endregion Fields and Constructors

        #region Methods
        /// <summary>
        /// Create a new User record in the Database.
        /// </summary>
        /// <param name="item">The User object.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Create(User item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spInsertProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@UserName", item.UserName);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Email", item.Email);
                cmd.Parameters.AddWithValue("@Document", item.Document);
                cmd.Parameters.AddWithValue("@BirthDate", item.BirthDate);

                //TO DO: Implement user-defined table-type for user phones.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Deletes a User record from the database.
        /// </summary>
        /// <param name="ID">The User ID for deletion.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Delete(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spDeleteUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Gets all users from the Database.
        /// </summary>
        /// <returns>A List containing all User objects in the database.</returns>
        public List<User> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<User> users = ORMHelper.MapCollection<User>(reader);
                    return users;
                }
            }
        }

        /// <summary>
        /// Gets all User objects from the Database that contain the searchTerm string in one of it's fields.
        /// </summary>
        /// <param name="searchTerm">The string to search for.</param>
        /// <returns>A List of User objects which contain the searchTerm string in one of it's fields.</returns>
        public List<User> SelectAllBySearchTerm(System.String searchTerm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllUsersBySearchTerm", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<User> users = ORMHelper.MapCollection<User>(reader);
                    return users;
                }
            }
        }

        /// <summary>
        /// Gets a single User record from the Database.
        /// </summary>
        /// <param name="ID">The User ID.</param>
        /// <returns>The User record from the database.</returns>
        public User SelectSingle(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectSingleUserByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    User user = ORMHelper.MapSingle<User>(reader);
                    return user;
                }
            }
        }

        /// <summary>
        /// Updates a User record in the Database.
        /// </summary>
        /// <param name="item">The User object to be updated.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Update(User item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spUpdateUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@UserName", item.UserName);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Email", item.Email);
                cmd.Parameters.AddWithValue("@Document", item.Document);
                cmd.Parameters.AddWithValue("@BirthDate", item.BirthDate);

                //TO DO: Implement user-defined table-type for user phones.

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }
        #endregion Methods
    }
}
