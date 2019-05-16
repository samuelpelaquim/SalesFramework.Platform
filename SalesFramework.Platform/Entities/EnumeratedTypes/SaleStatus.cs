using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFramework.Platform.Entities.EnumeratedTypes
{
    /// <summary>
    /// Defines the sale status after purchase completion.
    /// </summary>
    public enum SaleStatus
    {
        Received = 1,
        Confirmed = 2,
        PaymentReceived = 3,
        Processed = 4,
        Shipped = 5,
        Delivered = 6
    }
}
