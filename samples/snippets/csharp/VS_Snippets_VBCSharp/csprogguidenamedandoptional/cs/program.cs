// Snippets 5000 Note:  
// The container used for building our samples doesn't include the Office assemblies.
// This sample will generate a few errors in the CI build. Those are expected,
// so the build passes.
//
// If you update this sample, make sure to build it locally.
// Then, make sure no new errors are added.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedAndOptionalSnippets
{
    //<Snippet1>
    class NamedExample
    {
        static void Main(string[] args)
        {
            // The method can be called in the normal way, by using positional arguments.
            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");
            PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug"); 
            PrintOrderDetails("Gift Shop", orderNum: 31, "Red Mug");

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
            // PrintOrderDetails(31, sellerName: "Gift Shop", "Red Mug");
            // PrintOrderDetails(31, "Red Mug", sellerName: "Gift Shop");
        }

        static void PrintOrderDetails(string sellerName, int orderNum, string productName)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
            {
                throw new ArgumentException(message: "Seller name cannot be null or empty.", paramName: nameof(sellerName));
            }

            Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
        }
    }
//</Snippet1>
}
