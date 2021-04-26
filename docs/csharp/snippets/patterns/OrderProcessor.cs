using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    public record Order(int Items, decimal Cost);
    class OrderProcessor
    {
        // <PropertyPattern>
        public double CalculateDiscount(Order order) =>
            order switch
            {
                (Items: > 10, Cost: > 1000.00m) => 0.10,
                (Items: > 5, Cost: > 500.00m) => 0.05,
                Order { Cost: > 250.00m } => 0.02,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var o => 0,
            };
        // </PropertyPattern>
    }

    class OrderProcessing
    {
        // <DeconstructPattern>
        public double CalculateDiscount(Order order) =>
            order switch
            {
                ( > 10,  > 1000.00m) => 0.10,
                ( > 5, > 50.00m) => 0.05,
                Order { Cost: > 250.00m } => 0.02,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var o => 0,
            };
        // </DeconstructPattern>

    }
}
