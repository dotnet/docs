using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    // <OrderRecord>
    public record Order(int Items, decimal Cost);
    // </OrderRecord>

    class OrderProcessor
    {
        // <PropertyPattern>
        public decimal CalculateDiscount(Order order) =>
            order switch
            {
                (Items: > 10, Cost: > 1000.00m) => 0.10m,
                (Items: > 5, Cost: > 500.00m) => 0.05m,
                Order { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m,
            };
        // </PropertyPattern>
    }

    class OrderProcessing
    {
        // <DeconstructPattern>
        public decimal CalculateDiscount(Order order) =>
            order switch
            {
                ( > 10,  > 1000.00m) => 0.10m,
                ( > 5, > 50.00m) => 0.05m,
                Order { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m,
            };
        // </DeconstructPattern>

    }
}
