using SalesFramework.Platform.Entities.EnumeratedTypes;
using SalesFramework.Platform.Model;
using System;

namespace SalesFramework.Platform.Entities
{
    /// <summary>
    /// Class that represents a post-purchase sale object.
    /// </summary>
    public class Sale : Base
    {
        #region Fields
        //The user ID.
        private System.Int64 _userID;

        //The cart field.
        private Cart _cart;

        //The shipped address field.
        private Address _shippedAddress;

        //The promotion field.
        private Promotion _promotion;

        //The sale status field.
        private SaleStatus _status;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The default Sale object parameterless constructor.
        /// </summary>
        public Sale()
        {

        }

        /// <summary>
        /// Constructor for the Sale class.
        /// </summary>
        /// <param name="ID">The Sale ID.</param>
        /// <param name="UserID">The Sale User ID.</param>
        /// <param name="Cart">The Sale cart.</param>
        /// <param name="ShippedAddress">The sale shippment address.</param>
        /// <param name="Promotion">The Sale promotion.</param>
        /// <param name="Status">The sale status.</param>
        public Sale(System.Int64 ID, System.Int64 UserID, Cart Cart, Address ShippedAddress, Promotion Promotion, SaleStatus Status)
        {
            this._ID = ID;
            this._userID = UserID;
            this._cart = Cart;
            this._shippedAddress = ShippedAddress;
            this._promotion = Promotion;
            this._status = Status;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or Sets the valid UserID property of the Sale object instance.
        /// </summary>
        public System.Int64 UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if (value > 0)
                {
                    this._userID = UserID;
                }
                else
                {
                    throw new InvalidOperationException("Property UserID must be a valid user ID.");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the valid Cart property of the Sale object instance.
        /// </summary>
        public Cart Cart
        {
            get
            {
                return this._cart;
            }
            set
            {
                if (value is Cart)
                {
                    this._cart = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Cart must be a valid Cart object.");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the valid Shipped to Address of the Sale object instance.
        /// </summary>
        public Address ShippedAddress
        {
            get
            {
                return this._shippedAddress;
            }
            set
            {
                if (value is Address)
                {
                    this._shippedAddress = value;
                }
                else
                {
                    throw new InvalidOperationException("Property ShippedAddress must be a valid Address object.");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the valid Promotion applied to the Sale object instance.
        /// </summary>
        public Promotion Promotion
        {
            get
            {
                return this._promotion;
            }
            set
            {
                if (value is Promotion)
                {
                    this._promotion = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Promotion must be a valid Promotion object.");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the valid Status of the Sale object instance.
        /// </summary>
        public SaleStatus SaleStatus
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
        #endregion Properties
    }
}
