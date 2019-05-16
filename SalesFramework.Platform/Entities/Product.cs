using SalesFramework.Platform.Entities;
using System;
using System.Collections.Generic;

namespace SalesFramework.Platform.Model
{
    /// <summary>
    /// Class that represents a single Product item.
    /// </summary>
    public class Product : Base, IEquatable<Product>
    {
        #region Fields
        //Product Name field.
        private System.String _name;

        //Product Price field.
        private System.Decimal _price;

        //Product discount field.
        private System.Decimal _discount;

        //Product category field.
        private Category _category;

        //Product characteristics field.
        private Dictionary<System.String, System.Object> _characteristics;

        //Product images field.
        private List<System.String> _images;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default parameterless contructor for the Product class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Constructor for the Product class.
        /// </summary>
        /// <param name="ID">The product ID.</param>
        /// <param name="Name">The product name.</param>
        /// <param name="Price">The product price.</param>
        /// <param name="Category">The product category.</param>
        /// <param name="Characteristics">The Dictionary of Product characteristics.</param>
        /// <param name="Images">The List of Product images.</param>
        public Product(System.Int64 ID, System.String Name, System.Decimal Price, Category Category, Dictionary<System.String, System.Object> Characteristics, List<System.String> Images)
        {
            this._ID = ID;
            this._name = Name;
            this._price = Price;
            this._category = Category;
            this._characteristics = Characteristics;
            this._images = Images;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or sets the valid Name property of the Product instance.
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
        /// Gets or sets the valid Price property of the Product instance.
        /// </summary>
        public System.Decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (value > -1)
                {
                    this._price = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Price can't be less than 0.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Price property of the Product instance.
        /// </summary>
        public System.Decimal Discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                if (value > -1)
                {
                    this._discount = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Discount can't be less than 0.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Category property of the Product instance.
        /// </summary>
        public Category Category
        {
            get
            {
                return this._category;
            }
            set
            {
                if (value is Category)
                {
                    this._category = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Category must be a valid Category object.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Product Characteristics for this instance of Product class.
        /// </summary>
        public Dictionary<System.String, System.Object> Characteristics
        {
            get
            {
                return this._characteristics;
            }
            set
            {
                if (value is Dictionary<System.String, System.Object>)
                {
                    this._characteristics = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Characteristics must be a valid 'Dictionary<System.String, System.Object>'.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Product Images for this instance of the Product class.
        /// </summary>
        public List<System.String> Images
        {
            get
            {
                return this._images;
            }
            set
            {
                if (value is List<System.String>)
                {
                    this._images = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Images must be a valid 'List<System.String>'.");
                }
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Implementation method for the IEquatable.Equals method.
        /// </summary>
        /// <param name="other">Another product to compare this instance to.</param>
        /// <returns>True if the Product objects are equal based on field value, or False.</returns>
        public System.Boolean Equals(Product other)
        {
            if (other == null)
                return false;

            return other.Name == this._name &&
                    other.Price == this._price &&
                    other.Category == this._category &&
                    other.Characteristics == this._characteristics;
        }

        /// <summary>
        /// Overridden Object.Equals method for the Product class.
        /// </summary>
        /// <param name="obj">Object to compare this instance to.</param>
        /// <returns>True if the Product objects are equal based on field value, or False.</returns>
        public override System.Boolean Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals(obj as Product);
        }

        /// <summary>
        /// Overridden Object.GetHashCode method for the Product class.
        /// </summary>
        /// <returns>The overridden object field value-based hashcode.</returns>
        public override System.Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = (hashCode * 397) ^ (System.Int32) _price;

                var nameHashCode = !System.String.IsNullOrEmpty(_name) ? _name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ nameHashCode;

                hashCode = (hashCode * 397) ^ _category.GetHashCode();

                hashCode = (hashCode * 397) ^ _characteristics.GetHashCode();

                return hashCode;
            }
        }
        #endregion Methods
    }
}
