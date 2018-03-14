using System;
using System.Collections.Generic;
using System.Linq;

namespace Join
{
    public static class GroupJoinExample1
    {
        //Using a group join you can get all the products that match a given category bundled as a sequence. 
        //
        //Output: 
        // Beverages:
        //    Chai
        //    Chang
        //    Guarana Fantastica
        //    Sasquatch Ale
        //    Steeleye Stout
        //    Cote de Blaye
        //    Chartreuse verte
        //    Ipoh Coffee
        //    Laughing Lumberjack Lager
        //    Outback Lager
        //    Rhonbrau Klosterbier
        //    Lakkalikoori
        // Condiments:
        //    Aniseed Syrup
        //    Chef Anton's Cajun Seasoning
        //    Chef Anton's Gumbo Mix
        //    Grandma's Boysenberry Spread
        //    Northwoods Cranberry Sauce
        //    Genen Shouyu
        //    Gula Malacca
        //    Sirop d'erable
        //    Vegie-spread
        //    Louisiana Fiery Hot Pepper Sauce
        //    Louisiana Hot Spiced Okra
        //    Original Frankfurter grune Sobe
        // Vegetables:
        // Dairy Products:
        //    Queso Cabrales
        //    Queso Manchego La Pastora
        //    Gorgonzola Telino
        //    Mascarpone Fabioli
        //    Geitost
        //    Raclette Courdavault
        //    Camembert Pierrot
        //    Gudbrandsdalsost
        //    Flotemysost
        //    Mozzarella di Giovanni
        // Seafood:
        //     Ikura
        //     Konbu
        //     Carnarvon Tigers
        //     Nord-Ost Matjeshering
        //     Inlagd Sill
        //     Gravad lax
        //     Boston Crab Meat
        //     Jack's New England Clam Chowder
        //     Rogede sild
        //     Spegesild
        //     Escargots de Bourgogne
        //     Rod Kaviar
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
                select new {Category = c, Products = ps};

            foreach (var v in q)
            {
                Console.WriteLine(v.Category + ":");
                foreach (var p in v.Products)
                {
                    Console.WriteLine("   " + p.ProductName);
                }
            }
        }

        //Using a group join you can get all the products that match a given category bundled as a sequence. 
        //
        //Output: 
        //Output: 
        // Beverages:
        //    Chai
        //    Chang
        //    Guarana Fantastica
        //    Sasquatch Ale
        //    Steeleye Stout
        //    Cote de Blaye
        //    Chartreuse verte
        //    Ipoh Coffee
        //    Laughing Lumberjack Lager
        //    Outback Lager
        //    Rhonbrau Klosterbier
        //    Lakkalikoori
        // Condiments:
        //    Aniseed Syrup
        //    Chef Anton's Cajun Seasoning
        //    Chef Anton's Gumbo Mix
        //    Grandma's Boysenberry Spread
        //    Northwoods Cranberry Sauce
        //    Genen Shouyu
        //    Gula Malacca
        //    Sirop d'erable
        //    Vegie-spread
        //    Louisiana Fiery Hot Pepper Sauce
        //    Louisiana Hot Spiced Okra
        //    Original Frankfurter grune Sobe
        // Vegetables:
        // Dairy Products:
        //    Queso Cabrales
        //    Queso Manchego La Pastora
        //    Gorgonzola Telino
        //    Mascarpone Fabioli
        //    Geitost
        //    Raclette Courdavault
        //    Camembert Pierrot
        //    Gudbrandsdalsost
        //    Flotemysost
        //    Mozzarella di Giovanni
        // Seafood:
        //     Ikura
        //     Konbu
        //     Carnarvon Tigers
        //     Nord-Ost Matjeshering
        //     Inlagd Sill
        //     Gravad lax
        //     Boston Crab Meat
        //     Jack's New England Clam Chowder
        //     Rogede sild
        //     Spegesild
        //     Escargots de Bourgogne
        //     Rod Kaviar
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

            var q = categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => new {Category = c, Products = ps});

            foreach (var v in q)
            {
                Console.WriteLine(v.Category + ":");
                foreach (var p in v.Products)
                {
                    Console.WriteLine("   " + p.ProductName);
                }
            }
        }
    }
}