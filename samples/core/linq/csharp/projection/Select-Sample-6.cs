using System.Linq;
using System;
using System.Collections.Generic;

namespace Projection
{
    public class SelectSample6
    {
        //This sample uses select and query syntax to produce a sequence containing some properties of Products, including UnitPrice 
        //which is renamed to Price in the resulting type.
        //
        //Outputs:
        // Product Info:
        // Chai is in the category Beverages and costs $$18.00 per unit.
        // Chang is in the category Beverages and costs $$19.00 per unit.
        // Aniseed Syrup is in the category Condiments and costs $$10.00 per unit.
        // Chef Anton's Cajun Seasoning is in the category Condiments and costs $$22.00 per unit.
        // Chef Anton's Gumbo Mix is in the category Condiments and costs $$21.35 per unit.
        // Grandma's Boysenberry Spread is in the category Condiments and costs $$25.00 per unit.
        // Uncle Bob's Organic Dried Pears is in the category Produce and costs $$30.00 per unit.
        // Northwoods Cranberry Sauce is in the category Condiments and costs $$40.00 per unit.
        // Mishi Kobe Niku is in the category Meat/Poultry and costs $$97.00 per unit.
        // Ikura is in the category Seafood and costs $$31.00 per unit.
        // Queso Cabrales is in the category Dairy Products and costs $$21.00 per unit.
        // Queso Manchego La Pastora is in the category Dairy Products and costs $$38.00 per unit.
        // Konbu is in the category Seafood and costs $$6.00 per unit.
        // Tofu is in the category Produce and costs $$23.25 per unit.
        // Genen Shouyu is in the category Condiments and costs $$15.50 per unit.
        // Pavlova is in the category Confections and costs $$17.45 per unit.
        // Alice Mutton is in the category Meat/Poultry and costs $$39.00 per unit.
        // Carnarvon Tigers is in the category Seafood and costs $$62.50 per unit.
        // Teatime Chocolate Biscuits is in the category Confections and costs $$9.20 per unit.
        // Sir Rodney's Marmalade is in the category Confections and costs $$81.00 per unit.
        // Sir Rodney's Scones is in the category Confections and costs $$10.00 per unit.
        // Gustaf's Knackebrod is in the category Grains/Cereals and costs $$21.00 per unit.
        // Tunnbrod is in the category Grains/Cereals and costs $$9.00 per unit.
        // Guarana Fantastica is in the category Beverages and costs $$4.50 per unit.
        // NuNuCa Nub-Nougat-Creme is in the category Confections and costs $$14.00 per unit.
        // Gumbar Gummibarchen is in the category Confections and costs $$31.23 per unit.
        // Schoggi Schokolade is in the category Confections and costs $$43.90 per unit.
        // Rossle Sauerkraut is in the category Produce and costs $$45.60 per unit.
        // Thuringer Rostbratwurst is in the category Meat/Poultry and costs $$123.79 per unit.
        // Nord-Ost Matjeshering is in the category Seafood and costs $$25.89 per unit.
        // Gorgonzola Telino is in the category Dairy Products and costs $$12.50 per unit.
        // Mascarpone Fabioli is in the category Dairy Products and costs $$32.00 per unit.
        // Geitost is in the category Dairy Products and costs $$2.50 per unit.
        // Sasquatch Ale is in the category Beverages and costs $$14.00 per unit.
        // Steeleye Stout is in the category Beverages and costs $$18.00 per unit.
        // Inlagd Sill is in the category Seafood and costs $$19.00 per unit.
        // Gravad lax is in the category Seafood and costs $$26.00 per unit.
        // Cote de Blaye is in the category Beverages and costs $$263.50 per unit.
        // Chartreuse verte is in the category Beverages and costs $$18.00 per unit.
        // Boston Crab Meat is in the category Seafood and costs $$18.40 per unit.
        // Jack's New England Clam Chowder is in the category Seafood and costs $$9.65 per unit.
        // Singaporean Hokkien Fried Mee is in the category Grains/Cereals and costs $$14.00 per unit.
        // Ipoh Coffee is in the category Beverages and costs $$46.00 per unit.
        // Gula Malacca is in the category Condiments and costs $$19.45 per unit.
        // Rogede sild is in the category Seafood and costs $$9.50 per unit.
        // Spegesild is in the category Seafood and costs $$12.00 per unit.
        // Zaanse koeken is in the category Confections and costs $$9.50 per unit.
        // Chocolade is in the category Confections and costs $$12.75 per unit.
        // Maxilaku is in the category Confections and costs $$20.00 per unit.
        // Valkoinen suklaa is in the category Confections and costs $$16.25 per unit.
        // Manjimup Dried Apples is in the category Produce and costs $$53.00 per unit.
        // Filo Mix is in the category Grains/Cereals and costs $$7.00 per unit.
        // Perth Pasties is in the category Meat/Poultry and costs $$32.80 per unit.
        // Tourtiere is in the category Meat/Poultry and costs $$7.45 per unit.
        // Pate chinois is in the category Meat/Poultry and costs $$24.00 per unit.
        // Gnocchi di nonna Alice is in the category Grains/Cereals and costs $$38.00 per unit.
        // Ravioli Angelo is in the category Grains/Cereals and costs $$19.50 per unit.
        // Escargots de Bourgogne is in the category Seafood and costs $$13.25 per unit.
        // Raclette Courdavault is in the category Dairy Products and costs $$55.00 per unit.
        // Camembert Pierrot is in the category Dairy Products and costs $$34.00 per unit.
        // Sirop d'erable is in the category Condiments and costs $$28.50 per unit.
        // Tarte au sucre is in the category Confections and costs $$49.30 per unit.
        // Vegie-spread is in the category Condiments and costs $$43.90 per unit.
        // Wimmers gute Semmelknodel is in the category Grains/Cereals and costs $$33.25 per unit.
        // Louisiana Fiery Hot Pepper Sauce is in the category Condiments and costs $$21.05 per unit.
        // Louisiana Hot Spiced Okra is in the category Condiments and costs $$17.00 per unit.
        // Laughing Lumberjack Lager is in the category Beverages and costs $$14.00 per unit.
        // Scottish Longbreads is in the category Confections and costs $$12.50 per unit.
        // Gudbrandsdalsost is in the category Dairy Products and costs $$36.00 per unit.
        // Outback Lager is in the category Beverages and costs $$15.00 per unit.
        // Flotemysost is in the category Dairy Products and costs $$21.50 per unit.
        // Mozzarella di Giovanni is in the category Dairy Products and costs $$34.80 per unit.
        // Rod Kaviar is in the category Seafood and costs $$15.00 per unit.
        // Longlife Tofu is in the category Produce and costs $$10.00 per unit.
        // Rhonbrau Klosterbier is in the category Beverages and costs $$7.75 per unit.
        // Lakkalikoori is in the category Beverages and costs $$18.00 per unit.
        // Original Frankfurter grune Sobe is in the category Condiments and costs $$13.00 per unit.
        public static void QuerySyntaxExample()
        {
            List<Product> products = Data.Products;

            var productInfos =
                from p in products
                select new { p.ProductName, p.Category, Price = p.UnitPrice };

            Console.WriteLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs ${productInfo.Price:C} per unit.");
            }
        }

        //This sample uses selectand method syntax to produce a sequence containing some properties of Products, including UnitPrice 
        //which is renamed to Price in the resulting type.
        //
        //Outputs:
        // Product Info:
        // Chai is in the category Beverages and costs $$18.00 per unit.
        // Chang is in the category Beverages and costs $$19.00 per unit.
        // Aniseed Syrup is in the category Condiments and costs $$10.00 per unit.
        // Chef Anton's Cajun Seasoning is in the category Condiments and costs $$22.00 per unit.
        // Chef Anton's Gumbo Mix is in the category Condiments and costs $$21.35 per unit.
        // Grandma's Boysenberry Spread is in the category Condiments and costs $$25.00 per unit.
        // Uncle Bob's Organic Dried Pears is in the category Produce and costs $$30.00 per unit.
        // Northwoods Cranberry Sauce is in the category Condiments and costs $$40.00 per unit.
        // Mishi Kobe Niku is in the category Meat/Poultry and costs $$97.00 per unit.
        // Ikura is in the category Seafood and costs $$31.00 per unit.
        // Queso Cabrales is in the category Dairy Products and costs $$21.00 per unit.
        // Queso Manchego La Pastora is in the category Dairy Products and costs $$38.00 per unit.
        // Konbu is in the category Seafood and costs $$6.00 per unit.
        // Tofu is in the category Produce and costs $$23.25 per unit.
        // Genen Shouyu is in the category Condiments and costs $$15.50 per unit.
        // Pavlova is in the category Confections and costs $$17.45 per unit.
        // Alice Mutton is in the category Meat/Poultry and costs $$39.00 per unit.
        // Carnarvon Tigers is in the category Seafood and costs $$62.50 per unit.
        // Teatime Chocolate Biscuits is in the category Confections and costs $$9.20 per unit.
        // Sir Rodney's Marmalade is in the category Confections and costs $$81.00 per unit.
        // Sir Rodney's Scones is in the category Confections and costs $$10.00 per unit.
        // Gustaf's Knackebrod is in the category Grains/Cereals and costs $$21.00 per unit.
        // Tunnbrod is in the category Grains/Cereals and costs $$9.00 per unit.
        // Guarana Fantastica is in the category Beverages and costs $$4.50 per unit.
        // NuNuCa Nub-Nougat-Creme is in the category Confections and costs $$14.00 per unit.
        // Gumbar Gummibarchen is in the category Confections and costs $$31.23 per unit.
        // Schoggi Schokolade is in the category Confections and costs $$43.90 per unit.
        // Rossle Sauerkraut is in the category Produce and costs $$45.60 per unit.
        // Thuringer Rostbratwurst is in the category Meat/Poultry and costs $$123.79 per unit.
        // Nord-Ost Matjeshering is in the category Seafood and costs $$25.89 per unit.
        // Gorgonzola Telino is in the category Dairy Products and costs $$12.50 per unit.
        // Mascarpone Fabioli is in the category Dairy Products and costs $$32.00 per unit.
        // Geitost is in the category Dairy Products and costs $$2.50 per unit.
        // Sasquatch Ale is in the category Beverages and costs $$14.00 per unit.
        // Steeleye Stout is in the category Beverages and costs $$18.00 per unit.
        // Inlagd Sill is in the category Seafood and costs $$19.00 per unit.
        // Gravad lax is in the category Seafood and costs $$26.00 per unit.
        // Cote de Blaye is in the category Beverages and costs $$263.50 per unit.
        // Chartreuse verte is in the category Beverages and costs $$18.00 per unit.
        // Boston Crab Meat is in the category Seafood and costs $$18.40 per unit.
        // Jack's New England Clam Chowder is in the category Seafood and costs $$9.65 per unit.
        // Singaporean Hokkien Fried Mee is in the category Grains/Cereals and costs $$14.00 per unit.
        // Ipoh Coffee is in the category Beverages and costs $$46.00 per unit.
        // Gula Malacca is in the category Condiments and costs $$19.45 per unit.
        // Rogede sild is in the category Seafood and costs $$9.50 per unit.
        // Spegesild is in the category Seafood and costs $$12.00 per unit.
        // Zaanse koeken is in the category Confections and costs $$9.50 per unit.
        // Chocolade is in the category Confections and costs $$12.75 per unit.
        // Maxilaku is in the category Confections and costs $$20.00 per unit.
        // Valkoinen suklaa is in the category Confections and costs $$16.25 per unit.
        // Manjimup Dried Apples is in the category Produce and costs $$53.00 per unit.
        // Filo Mix is in the category Grains/Cereals and costs $$7.00 per unit.
        // Perth Pasties is in the category Meat/Poultry and costs $$32.80 per unit.
        // Tourtiere is in the category Meat/Poultry and costs $$7.45 per unit.
        // Pate chinois is in the category Meat/Poultry and costs $$24.00 per unit.
        // Gnocchi di nonna Alice is in the category Grains/Cereals and costs $$38.00 per unit.
        // Ravioli Angelo is in the category Grains/Cereals and costs $$19.50 per unit.
        // Escargots de Bourgogne is in the category Seafood and costs $$13.25 per unit.
        // Raclette Courdavault is in the category Dairy Products and costs $$55.00 per unit.
        // Camembert Pierrot is in the category Dairy Products and costs $$34.00 per unit.
        // Sirop d'erable is in the category Condiments and costs $$28.50 per unit.
        // Tarte au sucre is in the category Confections and costs $$49.30 per unit.
        // Vegie-spread is in the category Condiments and costs $$43.90 per unit.
        // Wimmers gute Semmelknodel is in the category Grains/Cereals and costs $$33.25 per unit.
        // Louisiana Fiery Hot Pepper Sauce is in the category Condiments and costs $$21.05 per unit.
        // Louisiana Hot Spiced Okra is in the category Condiments and costs $$17.00 per unit.
        // Laughing Lumberjack Lager is in the category Beverages and costs $$14.00 per unit.
        // Scottish Longbreads is in the category Confections and costs $$12.50 per unit.
        // Gudbrandsdalsost is in the category Dairy Products and costs $$36.00 per unit.
        // Outback Lager is in the category Beverages and costs $$15.00 per unit.
        // Flotemysost is in the category Dairy Products and costs $$21.50 per unit.
        // Mozzarella di Giovanni is in the category Dairy Products and costs $$34.80 per unit.
        // Rod Kaviar is in the category Seafood and costs $$15.00 per unit.
        // Longlife Tofu is in the category Produce and costs $$10.00 per unit.
        // Rhonbrau Klosterbier is in the category Beverages and costs $$7.75 per unit.
        // Lakkalikoori is in the category Beverages and costs $$18.00 per unit.
        // Original Frankfurter grune Sobe is in the category Condiments and costs $$13.00 per unit.
        public static void MethodSyntaxExample()
        {
            List<Product> products = Data.Products;

            var productInfos = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

            Console.WriteLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs ${productInfo.Price:C} per unit.");
            }
        }
    }
}