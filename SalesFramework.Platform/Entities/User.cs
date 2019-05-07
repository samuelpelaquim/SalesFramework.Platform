using SalesFramework.Platform.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFramework.Platform.Model
{
    /// <summary>
    /// Class that represents an instance of a User.
    /// </summary>
    public class User : Base
    {
        #region Fields
        //Name field.
        private System.String _name;

        //UserName field.
        private System.String _userName;

        //Password field.
        private System.String _password;

        //Birthday field.
        private System.DateTime _birthDate;

        //Document field.
        private System.String _document;

        //Email field.
        private System.String _email;

        //Phones field.
        private List<System.String> _phones;

        //Addresses field.
        private Dictionary<Address, System.Boolean> _addresses;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default parameterless constructor for the User class.
        /// </summary>
        public User() { }

        public User(System.Int64 ID, System.String Name, System.String UsarName, System.DateTime BirthDate, System.String Email, List<System.String> Phones, Dictionary<Address, System.Boolean> Addresses)
        {
            this._ID = ID;
            this._name = Name;
            this._userName = UserName;
            this._birthDate = BirthDate;
            this._email = Email;
            this._phones = Phones;
            this._addresses = Addresses;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or sets the valid Name property of the User instance.
        /// </summary>
        public System.String Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!System.String.IsNullOrWhiteSpace(value))
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
        /// Gets or sets the valid UserName property of the User instance.
        /// </summary>
        public System.String UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (!System.String.IsNullOrWhiteSpace(value))
                {
                    this._userName = value;
                }
                else
                {
                    throw new InvalidOperationException("Property UserName can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Password property of the User instance.
        /// </summary>
        public System.String Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (!System.String.IsNullOrWhiteSpace(value))
                {
                    this._password = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Password can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Date of Birth property of the User instance.
        /// </summary>
        public System.DateTime BirthDate
        {
            get
            {
                return this._birthDate;
            }
            set
            {
                if (value < System.DateTime.Today)
                {
                    this._birthDate = value;
                }
                else
                {
                    throw new InvalidOperationException("Property BirthDate can't be a date in the future.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Document property of the User instance.
        /// </summary>
        public System.String Document
        {
            get
            {
                return this._document;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (ValidationHelper.ValidateDocument(value, EnumeratedTypes.DocumentType.CPF))
                    {
                        this._document = Document;
                    }
                    else
                    {
                        throw new InvalidOperationException("Property Document must be a valid document.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Property Document can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid E-mail property of the User instance.
        /// </summary>
        public System.String Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (!System.String.IsNullOrWhiteSpace(value))
                {
                    if (ValidationHelper.ValidateEmail(value))
                    {
                        this._email = value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Property Email must be a valid email address.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Property Email can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Phones property of the User instance.
        /// </summary>
        public List<System.String> Phones
        {
            get
            {
                return this._phones;
            }
            set
            {
                if (value is List<System.String>)
                {
                    this._phones = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Phones must be a valid 'List<System.String>'.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Addresses property of the USer instance.
        /// </summary>
        public Dictionary<Address, System.Boolean> Addresses
        {
            get
            {
                return this._addresses;
            }
            set
            {
                if (value is Dictionary<Address, System.Boolean>)
                {
                    this._addresses = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Addresses must be a valid Dictionary<Address, System.Boolean>");
                }
            }
        }

        /// <summary>
        /// Gets the Age in Years of the User instance.
        /// </summary>
        public System.Int16 Age
        {
            get
            {
                return Convert.ToInt16(System.DateTime.Today.Year - this._birthDate.Year);
            }
        }

        /// <summary>
        /// Gets the current Shipping Address of the User instance.
        /// </summary>
        public Address ShippingAddress
        {
            get
            {
                return this._addresses.FirstOrDefault(shippingAddress => shippingAddress.Value == true).Key;
            }
        }
        #endregion Properties

        #region Methods
        #endregion Methods
    }
}
