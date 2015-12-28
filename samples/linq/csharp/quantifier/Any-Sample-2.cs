using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantifier
{
    public class AnySample2
    {
        //This sample uses Any and query syntax to return a grouped a list of products only for
        //categories that have at least one product that is out of stock.
        //
        //Output:
        // Category: Condiments
        //  Product: Aniseed Syrup Unit Price:$10.00 Units In Stock:13
        //  Product: Chef Anton's Cajun Seasoning Unit Price:$22.00 Units In Stock:53
        //  Product: Chef Anton's Gumbo Mix Unit Price:$21.35 Units In Stock:0
        //  Product: Grandma's Boysenberry Spread Unit Price:$25.00 Units In Stock:120
        //  Product: Northwoods Cranberry Sauce Unit Price:$40.00 Units In Stock:6
        //  Product: Genen Shouyu Unit Price:$15.50 Units In Stock:39
        //  Product: Gula Malacca Unit Price:$19.45 Units In Stock:27
        //  Product: Sirop d'erable Unit Price:$28.50 Units In Stock:113
        //  Product: Vegie-spread Unit Price:$43.90 Units In Stock:24
        //  Product: Louisiana Fiery Hot Pepper Sauce Unit Price:$21.05 Units In Stock:76
        //  Product: Louisiana Hot Spiced Okra Unit Price:$17.00 Units In Stock:4
        //  Product: Original Frankfurter grune Sobe Unit Price:$13.00 Units In Stock:32
        // Category: Meat/Poultry
        //  Product: Mishi Kobe Niku Unit Price:$97.00 Units In Stock:29
        //  Product: Alice Mutton Unit Price:$39.00 Units In Stock:0
        //  Product: Thuringer Rostbratwurst Unit Price:$123.79 Units In Stock:0
        //  Product: Perth Pasties Unit Price:$32.80 Units In Stock:0
        //  Product: Tourtiere Unit Price:$7.45 Units In Stock:21
        //  Product: Pate chinois Unit Price:$24.00 Units In Stock:115
        // Category: Dairy Products
        //  Product: Queso Cabrales Unit Price:$21.00 Units In Stock:22
        //  Product: Queso Manchego La Pastora Unit Price:$38.00 Units In Stock:86
        //  Product: Gorgonzola Telino Unit Price:$12.50 Units In Stock:0
        //  Product: Mascarpone Fabioli Unit Price:$32.00 Units In Stock:9
        //  Product: Geitost Unit Price:$2.50 Units In Stock:112
        //  Product: Raclette Courdavault Unit Price:$55.00 Units In Stock:79
        //  Product: Camembert Pierrot Unit Price:$34.00 Units In Stock:19
        //  Product: Gudbrandsdalsost Unit Price:$36.00 Units In Stock:26
        //  Product: Flotemysost Unit Price:$21.50 Units In Stock:26
        //  Product: Mozzarella di Giovanni Unit Price:$34.80 Units In Stock:14
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var productGroups =
                from prod in products
                group prod by prod.Category
                into prodGroup
                where prodGroup.Any(p => p.UnitsInStock == 0)
                select new {Category = prodGroup.Key, Products = prodGroup};

            foreach (var group in productGroups)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine(
                        $" Product: {product.ProductName} Unit Price:{product.UnitPrice:C} Units In Stock:{product.UnitsInStock}");
                }
            }
        }

        //This sample uses Any and method syntax to return a grouped a list of products only for
        //categories that have at least one product that is out of stock.
        //
        //Output:
        // Category: Condiments
        //  Product: Aniseed Syrup Unit Price:$10.00 Units In Stock:13
        //  Product: Chef Anton's Cajun Seasoning Unit Price:$22.00 Units In Stock:53
        //  Product: Chef Anton's Gumbo Mix Unit Price:$21.35 Units In Stock:0
        //  Product: Grandma's Boysenberry Spread Unit Price:$25.00 Units In Stock:120
        //  Product: Northwoods Cranberry Sauce Unit Price:$40.00 Units In Stock:6
        //  Product: Genen Shouyu Unit Price:$15.50 Units In Stock:39
        //  Product: Gula Malacca Unit Price:$19.45 Units In Stock:27
        //  Product: Sirop d'erable Unit Price:$28.50 Units In Stock:113
        //  Product: Vegie-spread Unit Price:$43.90 Units In Stock:24
        //  Product: Louisiana Fiery Hot Pepper Sauce Unit Price:$21.05 Units In Stock:76
        //  Product: Louisiana Hot Spiced Okra Unit Price:$17.00 Units In Stock:4
        //  Product: Original Frankfurter grune Sobe Unit Price:$13.00 Units In Stock:32
        // Category: Meat/Poultry
        //  Product: Mishi Kobe Niku Unit Price:$97.00 Units In Stock:29
        //  Product: Alice Mutton Unit Price:$39.00 Units In Stock:0
        //  Product: Thuringer Rostbratwurst Unit Price:$123.79 Units In Stock:0
        //  Product: Perth Pasties Unit Price:$32.80 Units In Stock:0
        //  Product: Tourtiere Unit Price:$7.45 Units In Stock:21
        //  Product: Pate chinois Unit Price:$24.00 Units In Stock:115
        // Category: Dairy Products
        //  Product: Queso Cabrales Unit Price:$21.00 Units In Stock:22
        //  Product: Queso Manchego La Pastora Unit Price:$38.00 Units In Stock:86
        //  Product: Gorgonzola Telino Unit Price:$12.50 Units In Stock:0
        //  Product: Mascarpone Fabioli Unit Price:$32.00 Units In Stock:9
        //  Product: Geitost Unit Price:$2.50 Units In Stock:112
        //  Product: Raclette Courdavault Unit Price:$55.00 Units In Stock:79
        //  Product: Camembert Pierrot Unit Price:$34.00 Units In Stock:19
        //  Product: Gudbrandsdalsost Unit Price:$36.00 Units In Stock:26
        //  Product: Flotemysost Unit Price:$21.50 Units In Stock:26
        //  Product: Mozzarella di Giovanni Unit Price:$34.80 Units In Stock:14
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var productGroups =
                products.GroupBy(prod => prod.Category)
                    .Where(prodGroup => prodGroup.Any(p => p.UnitsInStock == 0))
                    .Select(prodGroup => new {Category = prodGroup.Key, Products = prodGroup});

            foreach (var group in productGroups)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine(
                        $" Product: {product.ProductName} Unit Price:{product.UnitPrice:C} Units In Stock:{product.UnitsInStock}");
                }
            }
        }
    }
}