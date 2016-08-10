using System;
using System.Collections.Generic;
using System.Linq;

namespace Join
{
    public static class LeftOuterJoinExample1
    {
        //A left outer joinis like a cross join, except that all the left hand side elements get included at least once,
        //even if they don't match any right hand side elements. Note how Vegetables shows up in the output even though
        //it has no matching products.
        //
        //Output: 
        // Chai: Beverages
        // Chang: Beverages
        // Guarana Fantastica: Beverages
        // Sasquatch Ale: Beverages
        // Steeleye Stout: Beverages
        // Cote de Blaye: Beverages
        // Chartreuse verte: Beverages
        // Ipoh Coffee: Beverages
        // Laughing Lumberjack Lager: Beverages
        // Outback Lager: Beverages
        // Rhonbrau Klosterbier: Beverages
        // Lakkalikoori: Beverages
        // Aniseed Syrup: Condiments
        // Chef Anton's Cajun Seasoning: Condiments
        // Chef Anton's Gumbo Mix: Condiments
        // Grandma's Boysenberry Spread: Condiments
        // Northwoods Cranberry Sauce: Condiments
        // Genen Shouyu: Condiments
        // Gula Malacca: Condiments
        // Sirop d'erable: Condiments
        // Vegie-spread: Condiments
        // Louisiana Fiery Hot Pepper Sauce: Condiments
        // Louisiana Hot Spiced Okra: Condiments
        // Original Frankfurter grune Sobe: Condiments
        // (No products): Vegetables
        // Queso Cabrales: Dairy Products
        // Queso Manchego La Pastora: Dairy Products
        // Gorgonzola Telino: Dairy Products
        // Mascarpone Fabioli: Dairy Products
        // Geitost: Dairy Products
        // Raclette Courdavault: Dairy Products
        // Camembert Pierrot: Dairy Products
        // Gudbrandsdalsost: Dairy Products
        // Flotemysost: Dairy Products
        // Mozzarella di Giovanni: Dairy Products
        // Ikura: Seafood
        // Konbu: Seafood
        // Carnarvon Tigers: Seafood
        // Nord-Ost Matjeshering: Seafood
        // Inlagd Sill: Seafood
        // Gravad lax: Seafood
        // Boston Crab Meat: Seafood
        // Jack's New England Clam Chowder: Seafood
        // Rogede sild: Seafood
        // Spegesild: Seafood
        // Escargots de Bourgogne: Seafood
        // Rod Kaviar: Seafood
        public static void QuerySyntaxExample()
        {
            string[] categories = new string[]
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            List<Product> products = Data.Products;

            var q =
                from c in categories
                join p in products on c equals p.Category into ps
                from p in ps.DefaultIfEmpty()
                select new {Category = c, ProductName = p == null ? "(No products)" : p.ProductName};

            foreach (var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category);
            }
        }

        //A left outer joinis like a cross join, except that all the left hand side elements get included at least once,
        //even if they don't match any right hand side elements. Note how Vegetables shows up in the output even though
        //it has no matching products.
        //
        //Output: 
        // Chai: Beverages
        // Chang: Beverages
        // Guarana Fantastica: Beverages
        // Sasquatch Ale: Beverages
        // Steeleye Stout: Beverages
        // Cote de Blaye: Beverages
        // Chartreuse verte: Beverages
        // Ipoh Coffee: Beverages
        // Laughing Lumberjack Lager: Beverages
        // Outback Lager: Beverages
        // Rhonbrau Klosterbier: Beverages
        // Lakkalikoori: Beverages
        // Aniseed Syrup: Condiments
        // Chef Anton's Cajun Seasoning: Condiments
        // Chef Anton's Gumbo Mix: Condiments
        // Grandma's Boysenberry Spread: Condiments
        // Northwoods Cranberry Sauce: Condiments
        // Genen Shouyu: Condiments
        // Gula Malacca: Condiments
        // Sirop d'erable: Condiments
        // Vegie-spread: Condiments
        // Louisiana Fiery Hot Pepper Sauce: Condiments
        // Louisiana Hot Spiced Okra: Condiments
        // Original Frankfurter grune Sobe: Condiments
        // (No products): Vegetables
        // Queso Cabrales: Dairy Products
        // Queso Manchego La Pastora: Dairy Products
        // Gorgonzola Telino: Dairy Products
        // Mascarpone Fabioli: Dairy Products
        // Geitost: Dairy Products
        // Raclette Courdavault: Dairy Products
        // Camembert Pierrot: Dairy Products
        // Gudbrandsdalsost: Dairy Products
        // Flotemysost: Dairy Products
        // Mozzarella di Giovanni: Dairy Products
        // Ikura: Seafood
        // Konbu: Seafood
        // Carnarvon Tigers: Seafood
        // Nord-Ost Matjeshering: Seafood
        // Inlagd Sill: Seafood
        // Gravad lax: Seafood
        // Boston Crab Meat: Seafood
        // Jack's New England Clam Chowder: Seafood
        // Rogede sild: Seafood
        // Spegesild: Seafood
        // Escargots de Bourgogne: Seafood
        // Rod Kaviar: Seafood

        public static void MethodSyntaxExample()
        {
            string[] categories = new string[]
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            List<Product> products = Data.Products;

            var q =
                categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => new {c, ps})
                    .SelectMany(@t => @t.ps.DefaultIfEmpty(),
                        (@t, p) => new {Category = @t.c, ProductName = p == null ? "(No products)" : p.ProductName});

            foreach (var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category);
            }
        }
    }
}