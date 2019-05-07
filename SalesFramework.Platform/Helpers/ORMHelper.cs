using SalesFramework.Platform.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace SalesFramework.Platform.Helpers
{
    /// <summary>
    /// Static helper class to assist with object/relation mapping.
    /// </summary>
    public static class ORMHelper
    {
        #region ResultSet Mapper Methods
        /// <summary>
        /// Maps database field values from a DataReader to the corresponding class properties.
        /// </summary>
        /// <typeparam name="T">The class type definition.</typeparam>
        /// <param name="reader">The DataReader from which to read the field values.</param>
        /// <returns>An instance of the class defined by the Type with property values populated by the DataReader data.</returns>
        public static T MapSingle<T>(IDataReader reader) where T : class
        {
            if (reader.IsClosed)
                throw new DataException("DataReader is closed.");

            if (reader == null || !reader.Read())
                return null;

            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();
            T obj = Activator.CreateInstance<T>();

            foreach (PropertyInfo p in properties)
            {
                DatabaseFieldNameAttribute databaseFieldNameAttr = GetPropertyDatabaseFieldNameAttribute(p);
                if (databaseFieldNameAttr == null)
                    continue;

                int dataReaderFieldIndex = GetFieldIndex(reader, databaseFieldNameAttr.Name);
                if (dataReaderFieldIndex == -1)
                    continue;

                object value = reader.GetValue(dataReaderFieldIndex);
                if (value is DBNull)
                    value = null;

                p.SetValue(obj, value, null);
            }

            return obj;
        }

        /// <summary>
        /// Maps database field values from a DataReader to a List<T> of the corresponding class properties.
        /// </summary>
        /// <typeparam name="T">The class type definition.</typeparam>
        /// <param name="reader">The DataReader from which to read the field values.</param>
        /// <returns>A List<T> of the class defined by the Type with property values populated by the DataReader data.</returns>
        public static List<T> MapCollection<T>(IDataReader reader) where T : class
        {
            List<T> list = new List<T>();

            while (true)
            {
                T item = MapSingle<T>(reader);
                if (item == null)
                    break;

                list.Add(item);
            }
            return list;
        }
        #endregion ResultSet Mapper Methods

        #region Auxiliary Methods
        /// <summary>
        /// Gets the DatabaseFieldNameAttribute attribute of the property via reflection.
        /// </summary>
        /// <param name="propertyInfo">The property information in which to search for the Attribute.</param>
        /// <returns>The DatabaseFieldNameAttribute of the property or null.</returns>
        private static DatabaseFieldNameAttribute GetPropertyDatabaseFieldNameAttribute(PropertyInfo propertyInfo)
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(DatabaseFieldNameAttribute), true);
            return attributes[0] as DatabaseFieldNameAttribute;
        }

        /// <summary>
        /// Get the index of the field ehich has a name equal to the given field name.
        /// </summary>
        /// <param name="reader">The Data Reader from which to get the index of the field.</param>
        /// <param name="fieldName">The field name string to compare to.</param>
        /// <returns>The field name index as an Int32, or -1 if the field is not found in the Reader.</returns>
        private static int GetFieldIndex(IDataReader reader, string fieldName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string readerFieldName = reader.GetName(i);
                if (readerFieldName.Equals(fieldName, StringComparison.CurrentCultureIgnoreCase))
                    return i;
            }
            return -1;
        }
        #endregion Auxiliary Methods
    }
}