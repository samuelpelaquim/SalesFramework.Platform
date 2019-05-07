using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Entities.Attributes
{
    /// <summary>
    /// Defines a name for the property to link it to a field name in a database query dataset.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DatabaseFieldNameAttribute : System.Attribute
    {
        #region Fields
        //Name field.
        private string _name;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default Attribute constructor.
        /// </summary>
        /// <param name="fieldName">The anme of the field.</param>
        public DatabaseFieldNameAttribute(System.String fieldName)
        {
            this._name = fieldName;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets the Name property of the Attribute.
        /// </summary>
        public System.String Name
        {
            get
            {
                return this._name;
            }
        }
        #endregion Properties
    }
}
