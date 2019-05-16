using SalesFramework.Platform.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Entities
{
    /// <summary>
    /// Class that represents a product category object.
    /// </summary>
    public class Category : Base
    {
        #region Fields
        //The name field.
        private System.String _name;

        //The parent category field.
        private Category _parent;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The default parameterless constructor for the Category class.
        /// </summary>
        public Category()
        {

        }

        /// <summary>
        /// The default constructor for the Category class.
        /// </summary>
        /// <param name="ID">The Category ID.</param>
        /// <param name="Name">The Category Name.</param>
        /// <param name="Parent">The Category Parent Category.</param>
        public Category(System.Int64 ID, System.String Name, Category Parent)
        {
            this._ID = ID;
            this._name = Name;
            this._parent = Parent;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or sets the valid Name property of the Category object instance.
        /// </summary>
        public System.String Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._name = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Name can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Parent category property of the Category object instance.
        /// </summary>
        public Category Parent
        {
            get
            {
                return this._parent;
            }
            set
            {
                if (value is Category)
                {
                    this._parent = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Category must be a valid Category object.");
                }
            }
        }
        #endregion Properties
    }
}
