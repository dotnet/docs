using System.Collections.Generic;

namespace Quantifier
{
    //The Data class is used as a fake repository 
    public class Data
    {
        public static List<Product> Products => new List<Product>()
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Chai",
                Category = "Beverages",
                UnitPrice = 18.0000M,
                UnitsInStock = 39
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Chang",
                Category = "Beverages",
                UnitPrice = 19.0000M,
                UnitsInStock = 17
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Aniseed Syrup",
                Category = "Condiments",
                UnitPrice = 10.0000M,
                UnitsInStock = 13
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Chef Anton's Cajun Seasoning",
                Category = "Condiments",
                UnitPrice = 22.0000M,
                UnitsInStock = 53
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Chef Anton's Gumbo Mix",
                Category = "Condiments",
                UnitPrice = 21.3500M,
                UnitsInStock = 0
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Grandma's Boysenberry Spread",
                Category = "Condiments",
                UnitPrice = 25.0000M,
                UnitsInStock = 120
            },
            new Product
            {
                ProductId = 7,
                ProductName = "Uncle Bob's Organic Dried Pears",
                Category = "Produce",
                UnitPrice = 30.0000M,
                UnitsInStock = 15
            },
            new Product
            {
                ProductId = 8,
                ProductName = "Northwoods Cranberry Sauce",
                Category = "Condiments",
                UnitPrice = 40.0000M,
                UnitsInStock = 6
            },
            new Product
            {
                ProductId = 9,
                ProductName = "Mishi Kobe Niku",
                Category = "Meat/Poultry",
                UnitPrice = 97.0000M,
                UnitsInStock = 29
            },
            new Product
            {
                ProductId = 10,
                ProductName = "Ikura",
                Category = "Seafood",
                UnitPrice = 31.0000M,
                UnitsInStock = 31
            },
            new Product
            {
                ProductId = 11,
                ProductName = "Queso Cabrales",
                Category = "Dairy Products",
                UnitPrice = 21.0000M,
                UnitsInStock = 22
            },
            new Product
            {
                ProductId = 12,
                ProductName = "Queso Manchego La Pastora",
                Category = "Dairy Products",
                UnitPrice = 38.0000M,
                UnitsInStock = 86
            },
            new Product
            {
                ProductId = 13,
                ProductName = "Konbu",
                Category = "Seafood",
                UnitPrice = 6.0000M,
                UnitsInStock = 24
            },
            new Product
            {
                ProductId = 14,
                ProductName = "Tofu",
                Category = "Produce",
                UnitPrice = 23.2500M,
                UnitsInStock = 35
            },
            new Product
            {
                ProductId = 15,
                ProductName = "Genen Shouyu",
                Category = "Condiments",
                UnitPrice = 15.5000M,
                UnitsInStock = 39
            },
            new Product
            {
                ProductId = 16,
                ProductName = "Pavlova",
                Category = "Confections",
                UnitPrice = 17.4500M,
                UnitsInStock = 29
            },
            new Product
            {
                ProductId = 17,
                ProductName = "Alice Mutton",
                Category = "Meat/Poultry",
                UnitPrice = 39.0000M,
                UnitsInStock = 0
            },
            new Product
            {
                ProductId = 18,
                ProductName = "Carnarvon Tigers",
                Category = "Seafood",
                UnitPrice = 62.5000M,
                UnitsInStock = 42
            },
            new Product
            {
                ProductId = 19,
                ProductName = "Teatime Chocolate Biscuits",
                Category = "Confections",
                UnitPrice = 9.2000M,
                UnitsInStock = 25
            },
            new Product
            {
                ProductId = 20,
                ProductName = "Sir Rodney's Marmalade",
                Category = "Confections",
                UnitPrice = 81.0000M,
                UnitsInStock = 40
            },
            new Product
            {
                ProductId = 21,
                ProductName = "Sir Rodney's Scones",
                Category = "Confections",
                UnitPrice = 10.0000M,
                UnitsInStock = 3
            },
            new Product
            {
                ProductId = 22,
                ProductName = "Gustaf's Knackebrod",
                Category = "Grains/Cereals",
                UnitPrice = 21.0000M,
                UnitsInStock = 104
            },
            new Product
            {
                ProductId = 23,
                ProductName = "Tunnbrod",
                Category = "Grains/Cereals",
                UnitPrice = 9.0000M,
                UnitsInStock = 61
            },
            new Product
            {
                ProductId = 24,
                ProductName = "Guarana Fantastica",
                Category = "Beverages",
                UnitPrice = 4.5000M,
                UnitsInStock = 20
            },
            new Product
            {
                ProductId = 25,
                ProductName = "NuNuCa Nub-Nougat-Creme",
                Category = "Confections",
                UnitPrice = 14.0000M,
                UnitsInStock = 76
            },
            new Product
            {
                ProductId = 26,
                ProductName = "Gumbar Gummibarchen",
                Category = "Confections",
                UnitPrice = 31.2300M,
                UnitsInStock = 15
            },
            new Product
            {
                ProductId = 27,
                ProductName = "Schoggi Schokolade",
                Category = "Confections",
                UnitPrice = 43.9000M,
                UnitsInStock = 49
            },
            new Product
            {
                ProductId = 28,
                ProductName = "Rossle Sauerkraut",
                Category = "Produce",
                UnitPrice = 45.6000M,
                UnitsInStock = 26
            },
            new Product
            {
                ProductId = 29,
                ProductName = "Thuringer Rostbratwurst",
                Category = "Meat/Poultry",
                UnitPrice = 123.7900M,
                UnitsInStock = 0
            },
            new Product
            {
                ProductId = 30,
                ProductName = "Nord-Ost Matjeshering",
                Category = "Seafood",
                UnitPrice = 25.8900M,
                UnitsInStock = 10
            },
            new Product
            {
                ProductId = 31,
                ProductName = "Gorgonzola Telino",
                Category = "Dairy Products",
                UnitPrice = 12.5000M,
                UnitsInStock = 0
            },
            new Product
            {
                ProductId = 32,
                ProductName = "Mascarpone Fabioli",
                Category = "Dairy Products",
                UnitPrice = 32.0000M,
                UnitsInStock = 9
            },
            new Product
            {
                ProductId = 33,
                ProductName = "Geitost",
                Category = "Dairy Products",
                UnitPrice = 2.5000M,
                UnitsInStock = 112
            },
            new Product
            {
                ProductId = 34,
                ProductName = "Sasquatch Ale",
                Category = "Beverages",
                UnitPrice = 14.0000M,
                UnitsInStock = 111
            },
            new Product
            {
                ProductId = 35,
                ProductName = "Steeleye Stout",
                Category = "Beverages",
                UnitPrice = 18.0000M,
                UnitsInStock = 20
            },
            new Product
            {
                ProductId = 36,
                ProductName = "Inlagd Sill",
                Category = "Seafood",
                UnitPrice = 19.0000M,
                UnitsInStock = 112
            },
            new Product
            {
                ProductId = 37,
                ProductName = "Gravad lax",
                Category = "Seafood",
                UnitPrice = 26.0000M,
                UnitsInStock = 11
            },
            new Product
            {
                ProductId = 38,
                ProductName = "Cote de Blaye",
                Category = "Beverages",
                UnitPrice = 263.5000M,
                UnitsInStock = 17
            },
            new Product
            {
                ProductId = 39,
                ProductName = "Chartreuse verte",
                Category = "Beverages",
                UnitPrice = 18.0000M,
                UnitsInStock = 69
            },
            new Product
            {
                ProductId = 40,
                ProductName = "Boston Crab Meat",
                Category = "Seafood",
                UnitPrice = 18.4000M,
                UnitsInStock = 123
            },
            new Product
            {
                ProductId = 41,
                ProductName = "Jack's New England Clam Chowder",
                Category = "Seafood",
                UnitPrice = 9.6500M,
                UnitsInStock = 85
            },
            new Product
            {
                ProductId = 42,
                ProductName = "Singaporean Hokkien Fried Mee",
                Category = "Grains/Cereals",
                UnitPrice = 14.0000M,
                UnitsInStock = 26
            },
            new Product
            {
                ProductId = 43,
                ProductName = "Ipoh Coffee",
                Category = "Beverages",
                UnitPrice = 46.0000M,
                UnitsInStock = 17
            },
            new Product
            {
                ProductId = 44,
                ProductName = "Gula Malacca",
                Category = "Condiments",
                UnitPrice = 19.4500M,
                UnitsInStock = 27
            },
            new Product
            {
                ProductId = 45,
                ProductName = "Rogede sild",
                Category = "Seafood",
                UnitPrice = 9.5000M,
                UnitsInStock = 5
            },
            new Product
            {
                ProductId = 46,
                ProductName = "Spegesild",
                Category = "Seafood",
                UnitPrice = 12.0000M,
                UnitsInStock = 95
            },
            new Product
            {
                ProductId = 47,
                ProductName = "Zaanse koeken",
                Category = "Confections",
                UnitPrice = 9.5000M,
                UnitsInStock = 36
            },
            new Product
            {
                ProductId = 48,
                ProductName = "Chocolade",
                Category = "Confections",
                UnitPrice = 12.7500M,
                UnitsInStock = 15
            },
            new Product
            {
                ProductId = 49,
                ProductName = "Maxilaku",
                Category = "Confections",
                UnitPrice = 20.0000M,
                UnitsInStock = 10
            },
            new Product
            {
                ProductId = 50,
                ProductName = "Valkoinen suklaa",
                Category = "Confections",
                UnitPrice = 16.2500M,
                UnitsInStock = 65
            },
            new Product
            {
                ProductId = 51,
                ProductName = "Manjimup Dried Apples",
                Category = "Produce",
                UnitPrice = 53.0000M,
                UnitsInStock = 20
            },
            new Product
            {
                ProductId = 52,
                ProductName = "Filo Mix",
                Category = "Grains/Cereals",
                UnitPrice = 7.0000M,
                UnitsInStock = 38
            },
            new Product
            {
                ProductId = 53,
                ProductName = "Perth Pasties",
                Category = "Meat/Poultry",
                UnitPrice = 32.8000M,
                UnitsInStock = 0
            },
            new Product
            {
                ProductId = 54,
                ProductName = "Tourtiere",
                Category = "Meat/Poultry",
                UnitPrice = 7.4500M,
                UnitsInStock = 21
            },
            new Product
            {
                ProductId = 55,
                ProductName = "Pate chinois",
                Category = "Meat/Poultry",
                UnitPrice = 24.0000M,
                UnitsInStock = 115
            },
            new Product
            {
                ProductId = 56,
                ProductName = "Gnocchi di nonna Alice",
                Category = "Grains/Cereals",
                UnitPrice = 38.0000M,
                UnitsInStock = 21
            },
            new Product
            {
                ProductId = 57,
                ProductName = "Ravioli Angelo",
                Category = "Grains/Cereals",
                UnitPrice = 19.5000M,
                UnitsInStock = 36
            },
            new Product
            {
                ProductId = 58,
                ProductName = "Escargots de Bourgogne",
                Category = "Seafood",
                UnitPrice = 13.2500M,
                UnitsInStock = 62
            },
            new Product
            {
                ProductId = 59,
                ProductName = "Raclette Courdavault",
                Category = "Dairy Products",
                UnitPrice = 55.0000M,
                UnitsInStock = 79
            },
            new Product
            {
                ProductId = 60,
                ProductName = "Camembert Pierrot",
                Category = "Dairy Products",
                UnitPrice = 34.0000M,
                UnitsInStock = 19
            },
            new Product
            {
                ProductId = 61,
                ProductName = "Sirop d'erable",
                Category = "Condiments",
                UnitPrice = 28.5000M,
                UnitsInStock = 113
            },
            new Product
            {
                ProductId = 62,
                ProductName = "Tarte au sucre",
                Category = "Confections",
                UnitPrice = 49.3000M,
                UnitsInStock = 17
            },
            new Product
            {
                ProductId = 63,
                ProductName = "Vegie-spread",
                Category = "Condiments",
                UnitPrice = 43.9000M,
                UnitsInStock = 24
            },
            new Product
            {
                ProductId = 64,
                ProductName = "Wimmers gute Semmelknodel",
                Category = "Grains/Cereals",
                UnitPrice = 33.2500M,
                UnitsInStock = 22
            },
            new Product
            {
                ProductId = 65,
                ProductName = "Louisiana Fiery Hot Pepper Sauce",
                Category = "Condiments",
                UnitPrice = 21.0500M,
                UnitsInStock = 76
            },
            new Product
            {
                ProductId = 66,
                ProductName = "Louisiana Hot Spiced Okra",
                Category = "Condiments",
                UnitPrice = 17.0000M,
                UnitsInStock = 4
            },
            new Product
            {
                ProductId = 67,
                ProductName = "Laughing Lumberjack Lager",
                Category = "Beverages",
                UnitPrice = 14.0000M,
                UnitsInStock = 52
            },
            new Product
            {
                ProductId = 68,
                ProductName = "Scottish Longbreads",
                Category = "Confections",
                UnitPrice = 12.5000M,
                UnitsInStock = 6
            },
            new Product
            {
                ProductId = 69,
                ProductName = "Gudbrandsdalsost",
                Category = "Dairy Products",
                UnitPrice = 36.0000M,
                UnitsInStock = 26
            },
            new Product
            {
                ProductId = 70,
                ProductName = "Outback Lager",
                Category = "Beverages",
                UnitPrice = 15.0000M,
                UnitsInStock = 15
            },
            new Product
            {
                ProductId = 71,
                ProductName = "Flotemysost",
                Category = "Dairy Products",
                UnitPrice = 21.5000M,
                UnitsInStock = 26
            },
            new Product
            {
                ProductId = 72,
                ProductName = "Mozzarella di Giovanni",
                Category = "Dairy Products",
                UnitPrice = 34.8000M,
                UnitsInStock = 14
            },
            new Product
            {
                ProductId = 73,
                ProductName = "Rod Kaviar",
                Category = "Seafood",
                UnitPrice = 15.0000M,
                UnitsInStock = 101
            },
            new Product
            {
                ProductId = 74,
                ProductName = "Longlife Tofu",
                Category = "Produce",
                UnitPrice = 10.0000M,
                UnitsInStock = 4
            },
            new Product
            {
                ProductId = 75,
                ProductName = "Rhonbrau Klosterbier",
                Category = "Beverages",
                UnitPrice = 7.7500M,
                UnitsInStock = 125
            },
            new Product
            {
                ProductId = 76,
                ProductName = "Lakkalikoori",
                Category = "Beverages",
                UnitPrice = 18.0000M,
                UnitsInStock = 57
            },
            new Product
            {
                ProductId = 77,
                ProductName = "Original Frankfurter grune Sobe",
                Category = "Condiments",
                UnitPrice = 13.0000M,
                UnitsInStock = 32
            }
        };
    }
}