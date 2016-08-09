using System.Linq;
using System;
using System.Collections.Generic;

namespace Element
{
    public static class FirstSample1
    {
        //This sample uses First and query syntax to return the first matching element as a Product, 
        //instead of as a sequence containing a Product.
        //
        //Output: 
        // The product with the ProductId of 12 is Queso Manchego La Pastora in the Dairy Products category.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            Product product12 = (
                from prod in products
                where prod.ProductId == 12
                select prod)
                .First();

            Console.WriteLine(
                $"The product with the ProductId of 12 is {product12.ProductName} in the {product12.Category} category.");
        }

        //This sample uses First and method syntax to return the first matching element as a Product, 
        //instead of as a sequence containing a Product.
        //
        //Output: 
        // The product with the ProductId of 12 is Queso Manchego La Pastora in the Dairy Products category.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            Product product12 = (products.Where(prod => prod.ProductId == 12)).First();

            Console.WriteLine(
                $"The product with the ProductId of 12 is {product12.ProductName} in the {product12.Category} category.");
        }
    }
}