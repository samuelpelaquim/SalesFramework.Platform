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
    /// The Address service for Database related operations.
    /// </summary>
    public class AddressDataAccess : IDataAccess<Address>
    {
        #region Fields and Constructors
        //Connection String field.
        private System.String _connectionString;

        /// <summary>
        /// Default constructor for the AddressDataAccess class.
        /// </summary>
        /// <param name="ConnectionString">The connection string to be used.</param>
        public AddressDataAccess(System.String ConnectionString)
        {
            this._connectionString = ConnectionString;
        }
        #endregion Fields and Constructors

        #region Methods
        /// <summary>
        /// Create a new Address record in the Database.
        /// </summary>
        /// <param name="item">The Address object.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Create(Address item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spInsertAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@UserID", item.UserID);
                cmd.Parameters.AddWithValue("@Street", item.Street);
                cmd.Parameters.AddWithValue("@Number", item.Number);
                cmd.Parameters.AddWithValue("@Adjunct", item.Adjunct);
                cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);
                cmd.Parameters.AddWithValue("@City", item.City);
                cmd.Parameters.AddWithValue("@State", item.State);

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Deletes an Address record from the database.
        /// </summary>
        /// <param name="ID">The Address ID for deletion.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Delete(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spDeleteAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }

        /// <summary>
        /// Gets all addresses from the Database.
        /// </summary>
        /// <returns>A List containing all Address object in the database.</returns>
        public List<Address> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllAddresses", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Address> addresses = ORMHelper.MapCollection<Address>(reader);
                    return addresses;
                }
            }
        }

        /// <summary>
        /// Gets all Address objects from the Database that contain the searchTerm string in one of it's fields.
        /// </summary>
        /// <param name="searchTerm">The string to search for.</param>
        /// <returns>A List of Address objects which contain the searchTerm string in one of it's fields.</returns>
        public List<Address> SelectAllBySearchTerm(string searchTerm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectAllAddressesBySearchTerm", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Address> addresses = ORMHelper.MapCollection<Address>(reader);
                    return addresses;
                }
            }
        }

        /// <summary>
        /// Gets a single Address record from the Database.
        /// </summary>
        /// <param name="ID">The Address ID.</param>
        /// <returns>The Address record from the database.</returns>
        public Address SelectSingle(System.Int64 ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spSelectSingleAddressByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    Address address = ORMHelper.MapSingle<Address>(reader);
                    return address;
                }
            }
        }

        /// <summary>
        /// Updates an Address record in the Database.
        /// </summary>
        /// <param name="item">The Address object to be updated.</param>
        /// <returns>True if the operation is successful, or False.</returns>
        public bool Update(Address item)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //Estabelecendo conexão.
                connection.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("spUpdateAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Definindo valores de Parâmetros da Stored Procedure.
                cmd.Parameters.AddWithValue("@ID", item.ID);
                cmd.Parameters.AddWithValue("@UserID", item.UserID);
                cmd.Parameters.AddWithValue("@Street", item.Street);
                cmd.Parameters.AddWithValue("@Number", item.Number);
                cmd.Parameters.AddWithValue("@Adjunct", item.Adjunct);
                cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);
                cmd.Parameters.AddWithValue("@City", item.City);
                cmd.Parameters.AddWithValue("@State", item.State);

                connection.Open();

                //Resultado.
                System.Int32 affectRows = cmd.ExecuteNonQuery();
                return affectRows > 0;
            }
        }
        #endregion Methods
    }
}