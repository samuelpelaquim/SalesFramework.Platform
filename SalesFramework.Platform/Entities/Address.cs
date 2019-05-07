using SalesFramework.Platform.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Model
{
    /// <summary>
    /// Class that represents a single Address item.
    /// </summary>
    public class Address : Base, IEquatable<Address>
    {
        #region Fields
        //Street field.
        private System.String _street;

        //Street number field.
        private System.String _number;

        //Address adjunct information field.
        private System.String _adjunct;

        //Postal Code field.
        private System.String _postalCode;

        //City field.
        private System.String _city;

        //State field.
        private System.String _state;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default parameterless constructor for the Address class.
        /// </summary>
        public Address() { }

        /// <summary>
        /// Constructor for the Address class.
        /// </summary>
        /// <param name="ID">The address id.</param>
        /// <param name="Street">The address street.</param>
        /// <param name="Number">The residence number.</param>
        /// <param name="Adjunct">The address adjunct information.</param>
        /// <param name="PostalCode">The address postal code.</param>
        /// <param name="City">The city of residency.</param>
        /// <param name="State">The state of residency.</param>
        public Address(System.Int64 ID, System.String Street, System.String Number, System.String Adjunct, System.String PostalCode, System.String City, System.String State)
        {
            this._ID = ID;
            this._street = Street;
            this._number = Number;
            this._adjunct = Adjunct;
            this._postalCode = PostalCode;
            this._city = City;
            this._state = State;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or sets the valid Street property of the Address instance.
        /// </summary>
        public System.String Street
        {
            get
            {
                return this._street;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._street = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Street can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Number property of the Address instance.
        /// </summary>
        public System.String Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (ValidationHelper.ValidateStringIsNumber(value))
                    {
                        this._number = value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Property Number must be valid numeric characters only.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Property Number can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Adjunct property of the Address instance.
        /// </summary>
        public System.String Adjunct
        {
            get
            {
                return this._adjunct;
            }
            set
            {
                this._adjunct = value;
            }
        }

        /// <summary>
        /// Gets or sets the valid PostalCode property of the Address instance.
        /// </summary>
        public System.String PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (ValidationHelper.ValidateAddressCode(value))
                    {
                        this._postalCode = value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Property PostalCode must be in a valid Postal Code format.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Property PostalCode can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid City property of the Address instance.
        /// </summary>
        public System.String City
        {
            get
            {
                return this._city;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._city = value;
                }
                else
                {
                    throw new InvalidOperationException("Property City can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid State property of the Address instance.
        /// </summary>
        public System.String State
        {
            get
            {
                return this._state;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._state = value;
                }
                else
                {
                    throw new InvalidOperationException("Property State can't be null, empty or white space.");
                }
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Implementation method for the IEquatable.Equals method.
        /// </summary>
        /// <param name="other">Another address to compare this instance to.</param>
        /// <returns>True if the Address objects are equal based on field value, or False.</returns>
        public System.Boolean Equals(Address other)
        {
            if (other == null)
                return false;

            return other.Street == this._street &&
                    other.Number == this._number &&
                    other.Adjunct == this._adjunct &&
                    other.PostalCode == this._postalCode &&
                    other.City == this._city &&
                    other.State == this._state;
        }

        /// <summary>
        /// Overridden Object.Equals method for the Address class.
        /// </summary>
        /// <param name="obj">Object to compare this instance to.</param>
        /// <returns>True if the Address objects are equal based on field value, or False.</returns>
        public override System.Boolean Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals(obj as Address);
        }

        /// <summary>
        /// Overridden Object.GetHashCode method for the Address class.
        /// </summary>
        /// <returns>The overridden object field value-based hashcode.</returns>
        public override System.Int32 GetHashCode()
        {
            unchecked
            {
                var hashCode = 17;

                var streetHashCode = !System.String.IsNullOrEmpty(this._street) ? this._street.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ streetHashCode;

                hashCode = (hashCode * 397) ^ Convert.ToInt32(this._number);

                var adjuncttHashCode = !System.String.IsNullOrEmpty(this._adjunct) ? this._adjunct.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ adjuncttHashCode;

                var postalCodeHashCode = !System.String.IsNullOrEmpty(this._postalCode) ? this._postalCode.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ postalCodeHashCode;

                var cityHashCode = !System.String.IsNullOrEmpty(this._city) ? this._city.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ cityHashCode;

                var stateHashCode = !System.String.IsNullOrEmpty(this._state) ? this._state.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ stateHashCode;

                return hashCode;
            }
        }
        #endregion Methods
    }
}
