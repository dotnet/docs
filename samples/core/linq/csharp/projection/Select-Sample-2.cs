using System;
using System.Collections.Generic;
using System.Linq;

namespace Projection
{
    public class SelectSample2
    {
        //This sample uses select and method syntax to return a sequence of just the names of a list of products.
        //
        //Outputs:
        // Product Names:
        // Chai
        // Chang
        // Aniseed Syrup
        // Chef Anton's Cajun Seasoning
        // Chef Anton's Gumbo Mix
        // Grandma's Boysenberry Spread
        // Uncle Bob's Organic Dried Pears
        // Northwoods Cranberry Sauce
        // Mishi Kobe Niku
        // Ikura
        // Queso Cabrales
        // Queso Manchego La Pastora
        // Konbu
        // Tofu
        // Genen Shouyu
        // Pavlova
        // Alice Mutton
        // Carnarvon Tigers
        // Teatime Chocolate Biscuits
        // Sir Rodney's Marmalade
        // Sir Rodney's Scones
        // Gustaf's Knackebrod
        // Tunnbrod
        // Guarana Fantastica
        // NuNuCa Nub-Nougat-Creme
        // Gumbar Gummibarchen
        // Schoggi Schokolade
        // Rossle Sauerkraut
        // Thuringer Rostbratwurst
        // Nord-Ost Matjeshering
        // Gorgonzola Telino
        // Mascarpone Fabioli
        // Geitost
        // Sasquatch Ale
        // Steeleye Stout
        // Inlagd Sill
        // Gravad lax
        // Cote de Blaye
        // Chartreuse verte
        // Boston Crab Meat
        // Jack's New England Clam Chowder
        // Singaporean Hokkien Fried Mee
        // Ipoh Coffee
        // Gula Malacca
        // Rogede sild
        // Spegesild
        // Zaanse koeken
        // Chocolade
        // Maxilaku
        // Valkoinen suklaa
        // Manjimup Dried Apples
        // Filo Mix
        // Perth Pasties
        // Tourtiere
        // Pate chinois
        // Gnocchi di nonna Alice
        // Ravioli Angelo
        // Escargots de Bourgogne
        // Raclette Courdavault
        // Camembert Pierrot
        // Sirop d'erable
        // Tarte au sucre
        // Vegie-spread
        // Wimmers gute Semmelknodel
        // Louisiana Fiery Hot Pepper Sauce
        // Louisiana Hot Spiced Okra
        // Laughing Lumberjack Lager
        // Scottish Longbreads
        // Gudbrandsdalsost
        // Outback Lager
        // Flotemysost
        // Mozzarella di Giovanni
        // Rod Kaviar
        // Longlife Tofu
        // Rhonbrau Klosterbier
        // Lakkalikoori
        // Original Frankfurter grune Sobe
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var productNames =
                from p in products
                select p.ProductName;

            Console.WriteLine("Product Names:");
            foreach (var productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }

        //This sample uses select and method syntax to return a sequence of just the names of a list of products.
        //
        //Outputs:
        // Product Names:
        // Chai
        // Chang
        // Aniseed Syrup
        // Chef Anton's Cajun Seasoning
        // Chef Anton's Gumbo Mix
        // Grandma's Boysenberry Spread
        // Uncle Bob's Organic Dried Pears
        // Northwoods Cranberry Sauce
        // Mishi Kobe Niku
        // Ikura
        // Queso Cabrales
        // Queso Manchego La Pastora
        // Konbu
        // Tofu
        // Genen Shouyu
        // Pavlova
        // Alice Mutton
        // Carnarvon Tigers
        // Teatime Chocolate Biscuits
        // Sir Rodney's Marmalade
        // Sir Rodney's Scones
        // Gustaf's Knackebrod
        // Tunnbrod
        // Guarana Fantastica
        // NuNuCa Nub-Nougat-Creme
        // Gumbar Gummibarchen
        // Schoggi Schokolade
        // Rossle Sauerkraut
        // Thuringer Rostbratwurst
        // Nord-Ost Matjeshering
        // Gorgonzola Telino
        // Mascarpone Fabioli
        // Geitost
        // Sasquatch Ale
        // Steeleye Stout
        // Inlagd Sill
        // Gravad lax
        // Cote de Blaye
        // Chartreuse verte
        // Boston Crab Meat
        // Jack's New England Clam Chowder
        // Singaporean Hokkien Fried Mee
        // Ipoh Coffee
        // Gula Malacca
        // Rogede sild
        // Spegesild
        // Zaanse koeken
        // Chocolade
        // Maxilaku
        // Valkoinen suklaa
        // Manjimup Dried Apples
        // Filo Mix
        // Perth Pasties
        // Tourtiere
        // Pate chinois
        // Gnocchi di nonna Alice
        // Ravioli Angelo
        // Escargots de Bourgogne
        // Raclette Courdavault
        // Camembert Pierrot
        // Sirop d'erable
        // Tarte au sucre
        // Vegie-spread
        // Wimmers gute Semmelknodel
        // Louisiana Fiery Hot Pepper Sauce
        // Louisiana Hot Spiced Okra
        // Laughing Lumberjack Lager
        // Scottish Longbreads
        // Gudbrandsdalsost
        // Outback Lager
        // Flotemysost
        // Mozzarella di Giovanni
        // Rod Kaviar
        // Longlife Tofu
        // Rhonbrau Klosterbier
        // Lakkalikoori
        // Original Frankfurter grune Sobe
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var productNames = products.Select(p => p.ProductName);

            Console.WriteLine("Product Names:");
            foreach (var productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }
    }
}