using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Model
{
    /// <summary>
    /// Class that represents a single Shopping Cart instance.
    /// </summary>
    public class Cart : Base
    {
        #region Fields
        //Street field.
        private System.Int64 _userID;

        //Shipping cost field.
        private System.Decimal _shipping;

        //Products field.
        private Dictionary<Product, System.Int16> _products;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default parameterless contructor for the Cart class.
        /// </summary>
        public Cart() { }

        /// <summary>
        /// Constructor for the Cart class.
        /// </summary>
        /// <param name="ID">The cart ID.</param>
        /// <param name="Shipping">The shipping cost.</param>
        /// <param name="Products">The products/amount dictionary.</param>
        public Cart(System.Int64 ID, System.Int64 UserID, System.Decimal Shipping, Dictionary<Product, System.Int16> Products)
        {
            this._ID = ID;
            this._userID = UserID;
            this._shipping = Shipping;
            this._products = Products;
        }
        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or Sets the valid UserID property of the Cart instance.
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
        /// Gets or sets the Shipping cost property of the Cart instance.
        /// </summary>
        public System.Decimal Shipping
        {
            get
            {
                return this._shipping;
            }
            set
            {
                if (value > -1)
                {
                    this._shipping = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Shipping can't be less than 0.");
                }
            }
        }

        /// <summary>
        /// Gets the Products attribute of the Cart instance.
        /// </summary>
        public Dictionary<Product, System.Int16> Products
        {
            get
            {
                return this._products;
            }
            set
            {
                if (value is Dictionary<Product, System.Int16>)
                {
                    this._products = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Products must be a valid 'Dictionary<Product, System.Int16>'.");
                }
            }
        }

        /// <summary>
        /// Gets the sum of prices of each Product in the Cart instance.
        /// </summary>
        public System.Decimal TotalPrice
        {
            get
            {
                System.Decimal _totalPrice = 0.0m;
                foreach (var product in this._products)
                {
                    _totalPrice += product.Key.Price * product.Value;
                }
                return _totalPrice;
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Add a valid quantity of Product object(s) to the Cart instance.
        /// </summary>
        /// <param name="product">A Product object.</param>
        /// <param name="amount">A short amount.</param>
        public void AddProduct(Product product, System.Int16 amount)
        {
            if (!(product is Product && amount > 0))
                return;

            //If the product is already present in the Cart, the amount of products is updated.
            if (this._products.ContainsKey(product))
                this._products[product] += amount;
            //If the product is not yeat present in the Cart, the product and amount are added.
            else
                this._products.Add(product, amount);
        }

        /// <summary>
        /// Removes an existing amount of Product object(s) from the Cart instance.
        /// </summary>
        /// <param name="product">A Product object.</param>
        /// <param name="amount">A short amount.</param>
        public void RemoveProduct(Product product, System.Int16 amount)
        {
            if (!(product is Product && amount > 0))
                return;

            if (this._products.ContainsKey(product))
            {
                System.Int16 currentAmount = this._products[product];

                //If the amount to remove is less the amount present, the amount of products is updated.
                if (this._products[product] > amount)
                    this._products[product] = (System.Int16) (currentAmount - amount);
                //If the amount to remove is greater than the amount present, remove the product from the Cart.
                else
                    this._products.Remove(product);
            }
        }
        #endregion Methods
    }
}
