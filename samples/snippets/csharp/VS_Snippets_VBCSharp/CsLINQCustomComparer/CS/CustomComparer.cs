using System;
using System.Collections.Generic;
using System.Linq;

//<Snippet1>
public class Product
{
    public string Name { get; set; }
    public int Code { get; set; }
}

// Custom comparer for the Product class
class ProductComparer : IEqualityComparer<Product>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(Product x, Product y)
    {
       
        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the products' properties are equal.
        return x.Code == y.Code && x.Name == y.Name;
    }

    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(Product product)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(product, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

        //Get hash code for the Code field.
        int hashProductCode = product.Code.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }

}
//</Snippet1>

class Program
{
    static void Main(string[] args)
    {
        //<Snippet2>
        Product[] store1 = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 } };

        Product[] store2 = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "lemon", Code = 12 } };
        //</Snippet2>

        //INTERSECT

        //<Snippet3>
        // Get the products from the first array 
        // that have duplicates in the second array.
        
        IEnumerable<Product> duplicates =
            store1.Intersect(store2, new ProductComparer());

        foreach (var product in duplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9
        */
        //</Snippet3>

        //UNION
        
        //<Snippet4>
        //Get the products from the both arrays
        //excluding duplicates.

        IEnumerable<Product> union =
          store1.Union(store2, new ProductComparer());

        foreach (var product in union)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
         
            apple 9
            orange 4
            lemon 12
        */
        //</Snippet4>

        //DISTINCT

        //<Snippet5>
        Product[] products = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 }, 
                               new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "lemon", Code = 12 } };

        //Exclude duplicates.
        
        IEnumerable<Product> noduplicates =
            products.Distinct(new ProductComparer());

        foreach (var product in noduplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9 
            orange 4
            lemon 12
        */
        //</Snippet5>

        //CONTAINS

        //<Snippet6>

        Product[] fruits = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 }, 
                               new Product { Name = "lemon", Code = 12 } };

        Product apple = new Product { Name = "apple", Code = 9 };
        Product kiwi = new Product {Name = "kiwi", Code = 8 };

        ProductComparer prodc = new ProductComparer();

        bool hasApple = fruits.Contains(apple, prodc);
        bool hasKiwi = fruits.Contains(kiwi, prodc);

        Console.WriteLine("Apple? " + hasApple);
        Console.WriteLine("Kiwi? " + hasKiwi);

        /*
            This code produces the following output:
         
            Apple? True
            Kiwi? False
        */    

        //</Snippet6>

        //EXCEPT

        //<Snippet7>
        Product[] fruits1 = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 },
                                new Product { Name = "lemon", Code = 12 } };

        Product[] fruits2 = { new Product { Name = "apple", Code = 9 } };

        //Get all the elements from the first array
        //except for the elements from the second array.

        IEnumerable<Product> except =
            fruits1.Except(fruits2, new ProductComparer());

        foreach (var product in except)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
          This code produces the following output:
         
          orange 4
          lemon 12
        */

        //</Snippet7>

        //SEQUENCEEQUAL

        //<Snippet8>

        Product[] storeA = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 } };

        Product[] storeB = { new Product { Name = "apple", Code = 9 }, 
                               new Product { Name = "orange", Code = 4 } };

        bool equalAB = storeA.SequenceEqual(storeB, new ProductComparer());

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:
            
            Equal? True
        */

        //</Snippet8>
        Console.ReadLine();

    }
}
