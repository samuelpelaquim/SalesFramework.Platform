using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Model
{
    /// <summary>
    /// Base class for all entity classes.
    /// </summary>
    public class Base
    {
        //ID field.
        protected System.Int64 _ID;

        /// <summary>
        /// Gets or sets the Valid ID property or the class instance.
        /// </summary>
        public System.Int64 ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (value > 0)
                {
                    this._ID = value;
                }
                else
                {
                    throw new InvalidOperationException("Property ID must be a non-negative valid user ID.");
                }
            }
        }
    }
}
