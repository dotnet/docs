using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantifier
{
    public class AllSample2
    {
        //This sample uses All and query syntax to return a grouped a list of products only for
        //categories that have all of their products in stock.
        //
        //Output:
        // Category: Beverages
        //  Product: Chai Unit Price: $18.00 Units In Stock: 39
        //  Product: Chang Unit Price: $19.00 Units In Stock: 17
        //  Product: Guarana Fantastica Unit Price: $4.50 Units In Stock: 20
        //  Product: Sasquatch Ale Unit Price: $14.00 Units In Stock: 111
        //  Product: Steeleye Stout Unit Price: $18.00 Units In Stock: 20
        //  Product: Cote de Blaye Unit Price: $263.50 Units In Stock: 17
        //  Product: Chartreuse verte Unit Price: $18.00 Units In Stock: 69
        //  Product: Ipoh Coffee Unit Price: $46.00 Units In Stock: 17
        //  Product: Laughing Lumberjack Lager Unit Price: $14.00 Units In Stock: 52
        //  Product: Outback Lager Unit Price: $15.00 Units In Stock: 15
        //  Product: Rhonbrau Klosterbier Unit Price: $7.75 Units In Stock: 125
        //  Product: Lakkalikoori Unit Price: $18.00 Units In Stock: 57
        // Category: Produce
        //  Product: Uncle Bob's Organic Dried Pears Unit Price: $30.00 Units In Stock: 15
        //  Product: Tofu Unit Price: $23.25 Units In Stock: 35
        //  Product: Rossle Sauerkraut Unit Price: $45.60 Units In Stock: 26
        //  Product: Manjimup Dried Apples Unit Price: $53.00 Units In Stock: 20
        //  Product: Longlife Tofu Unit Price: $10.00 Units In Stock: 4
        // Category: Seafood
        //  Product: Ikura Unit Price: $31.00 Units In Stock: 31
        //  Product: Konbu Unit Price: $6.00 Units In Stock: 24
        //  Product: Carnarvon Tigers Unit Price: $62.50 Units In Stock: 42
        //  Product: Nord-Ost Matjeshering Unit Price: $25.89 Units In Stock: 10
        //  Product: Inlagd Sill Unit Price: $19.00 Units In Stock: 112
        //  Product: Gravad lax Unit Price: $26.00 Units In Stock: 11
        //  Product: Boston Crab Meat Unit Price: $18.40 Units In Stock: 123
        //  Product: Jack's New England Clam Chowder Unit Price: $9.65 Units In Stock: 85
        //  Product: Rogede sild Unit Price: $9.50 Units In Stock: 5
        //  Product: Spegesild Unit Price: $12.00 Units In Stock: 95
        //  Product: Escargots de Bourgogne Unit Price: $13.25 Units In Stock: 62
        //  Product: Rod Kaviar Unit Price: $15.00 Units In Stock: 101
        // Category: Confections
        //  Product: Pavlova Unit Price: $17.45 Units In Stock: 29
        //  Product: Teatime Chocolate Biscuits Unit Price: $9.20 Units In Stock: 25
        //  Product: Sir Rodney's Marmalade Unit Price: $81.00 Units In Stock: 40
        //  Product: Sir Rodney's Scones Unit Price: $10.00 Units In Stock: 3
        //  Product: NuNuCa Nub-Nougat-Creme Unit Price: $14.00 Units In Stock: 76
        //  Product: Gumbar Gummibarchen Unit Price: $31.23 Units In Stock: 15
        //  Product: Schoggi Schokolade Unit Price: $43.90 Units In Stock: 49
        //  Product: Zaanse koeken Unit Price: $9.50 Units In Stock: 36
        //  Product: Chocolade Unit Price: $12.75 Units In Stock: 15
        //  Product: Maxilaku Unit Price: $20.00 Units In Stock: 10
        //  Product: Valkoinen suklaa Unit Price: $16.25 Units In Stock: 65
        //  Product: Tarte au sucre Unit Price: $49.30 Units In Stock: 17
        //  Product: Scottish Longbreads Unit Price: $12.50 Units In Stock: 6
        // Category: Grains/Cereals
        //  Product: Gustaf's Knackebrod Unit Price: $21.00 Units In Stock: 104
        //  Product: Tunnbrod Unit Price: $9.00 Units In Stock: 61
        //  Product: Singaporean Hokkien Fried Mee Unit Price: $14.00 Units In Stock: 26
        //  Product: Filo Mix Unit Price: $7.00 Units In Stock: 38
        //  Product: Gnocchi di nonna Alice Unit Price: $38.00 Units In Stock: 21
        //  Product: Ravioli Angelo Unit Price: $19.50 Units In Stock: 36
        //  Product: Wimmers gute Semmelknodel Unit Price: $33.25 Units In Stock: 22
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var productGroups =
                from prod in products
                group prod by prod.Category
                into prodGroup
                where prodGroup.All(p => p.UnitsInStock > 0)
                select new {Category = prodGroup.Key, Products = prodGroup};

            foreach (var group in productGroups)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine(
                        $" Product: {product.ProductName} Unit Price: {product.UnitPrice:C} Units In Stock: {product.UnitsInStock}");
                }
            }
        }

        //This sample uses All and method syntax to return a grouped a list of products only for
        //categories that have all of their products in stock.
        //
        //Output:
        // Category: Beverages
        //  Product: Chai Unit Price: $18.00 Units In Stock: 39
        //  Product: Chang Unit Price: $19.00 Units In Stock: 17
        //  Product: Guarana Fantastica Unit Price: $4.50 Units In Stock: 20
        //  Product: Sasquatch Ale Unit Price: $14.00 Units In Stock: 111
        //  Product: Steeleye Stout Unit Price: $18.00 Units In Stock: 20
        //  Product: Cote de Blaye Unit Price: $263.50 Units In Stock: 17
        //  Product: Chartreuse verte Unit Price: $18.00 Units In Stock: 69
        //  Product: Ipoh Coffee Unit Price: $46.00 Units In Stock: 17
        //  Product: Laughing Lumberjack Lager Unit Price: $14.00 Units In Stock: 52
        //  Product: Outback Lager Unit Price: $15.00 Units In Stock: 15
        //  Product: Rhonbrau Klosterbier Unit Price: $7.75 Units In Stock: 125
        //  Product: Lakkalikoori Unit Price: $18.00 Units In Stock: 57
        // Category: Produce
        //  Product: Uncle Bob's Organic Dried Pears Unit Price: $30.00 Units In Stock: 15
        //  Product: Tofu Unit Price: $23.25 Units In Stock: 35
        //  Product: Rossle Sauerkraut Unit Price: $45.60 Units In Stock: 26
        //  Product: Manjimup Dried Apples Unit Price: $53.00 Units In Stock: 20
        //  Product: Longlife Tofu Unit Price: $10.00 Units In Stock: 4
        // Category: Seafood
        //  Product: Ikura Unit Price: $31.00 Units In Stock: 31
        //  Product: Konbu Unit Price: $6.00 Units In Stock: 24
        //  Product: Carnarvon Tigers Unit Price: $62.50 Units In Stock: 42
        //  Product: Nord-Ost Matjeshering Unit Price: $25.89 Units In Stock: 10
        //  Product: Inlagd Sill Unit Price: $19.00 Units In Stock: 112
        //  Product: Gravad lax Unit Price: $26.00 Units In Stock: 11
        //  Product: Boston Crab Meat Unit Price: $18.40 Units In Stock: 123
        //  Product: Jack's New England Clam Chowder Unit Price: $9.65 Units In Stock: 85
        //  Product: Rogede sild Unit Price: $9.50 Units In Stock: 5
        //  Product: Spegesild Unit Price: $12.00 Units In Stock: 95
        //  Product: Escargots de Bourgogne Unit Price: $13.25 Units In Stock: 62
        //  Product: Rod Kaviar Unit Price: $15.00 Units In Stock: 101
        // Category: Confections
        //  Product: Pavlova Unit Price: $17.45 Units In Stock: 29
        //  Product: Teatime Chocolate Biscuits Unit Price: $9.20 Units In Stock: 25
        //  Product: Sir Rodney's Marmalade Unit Price: $81.00 Units In Stock: 40
        //  Product: Sir Rodney's Scones Unit Price: $10.00 Units In Stock: 3
        //  Product: NuNuCa Nub-Nougat-Creme Unit Price: $14.00 Units In Stock: 76
        //  Product: Gumbar Gummibarchen Unit Price: $31.23 Units In Stock: 15
        //  Product: Schoggi Schokolade Unit Price: $43.90 Units In Stock: 49
        //  Product: Zaanse koeken Unit Price: $9.50 Units In Stock: 36
        //  Product: Chocolade Unit Price: $12.75 Units In Stock: 15
        //  Product: Maxilaku Unit Price: $20.00 Units In Stock: 10
        //  Product: Valkoinen suklaa Unit Price: $16.25 Units In Stock: 65
        //  Product: Tarte au sucre Unit Price: $49.30 Units In Stock: 17
        //  Product: Scottish Longbreads Unit Price: $12.50 Units In Stock: 6
        // Category: Grains/Cereals
        //  Product: Gustaf's Knackebrod Unit Price: $21.00 Units In Stock: 104
        //  Product: Tunnbrod Unit Price: $9.00 Units In Stock: 61
        //  Product: Singaporean Hokkien Fried Mee Unit Price: $14.00 Units In Stock: 26
        //  Product: Filo Mix Unit Price: $7.00 Units In Stock: 38
        //  Product: Gnocchi di nonna Alice Unit Price: $38.00 Units In Stock: 21
        //  Product: Ravioli Angelo Unit Price: $19.50 Units In Stock: 36
        //  Product: Wimmers gute Semmelknodel Unit Price: $33.25 Units In Stock: 22
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var productGroups =
                products.GroupBy(prod => prod.Category)
                    .Where(prodGroup => prodGroup.All(p => p.UnitsInStock > 0))
                    .Select(prodGroup => new {Category = prodGroup.Key, Products = prodGroup});

            foreach (var group in productGroups)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var product in group.Products)
                {
                    Console.WriteLine(
                        $" Product: {product.ProductName} Unit Price: {product.UnitPrice: C} Units In Stock: {product.UnitsInStock}");
                }
            }
        }
    }
}