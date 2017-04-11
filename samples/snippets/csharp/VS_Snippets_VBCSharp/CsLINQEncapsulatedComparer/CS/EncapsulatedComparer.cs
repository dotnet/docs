using System;
using System.Collections.Generic;
using System.Linq;

//<Snippet1>
public class Product : IEquatable<Product>
{
    public string Name { get; set; }
    public int Code { get; set; }

    public bool Equals(Product other)
    {

        //Check whether the compared object is null. 
        if (Object.ReferenceEquals(other, null)) return false;

        //Check whether the compared object references the same data. 
        if (Object.ReferenceEquals(this, other)) return true;

        //Check whether the products' properties are equal. 
        return Code.Equals(other.Code) && Name.Equals(other.Name);
    }

    // If Equals() returns true for a pair of objects  
    // then GetHashCode() must return the same value for these objects. 

    public override int GetHashCode()
    {

        //Get hash code for the Name field if it is not null. 
        int hashProductName = Name == null ? 0 : Name.GetHashCode();

        //Get hash code for the Code field. 
        int hashProductCode = Code.GetHashCode();

        //Calculate the hash code for the product. 
        return hashProductName ^ hashProductCode;
    }
}
//</Snippet1>

class Program
{
    static void Main(string[] args)
    {
        // This snippet is different than #2 by using ProductA (not Product).
        // Some samples here need to use ProductA in conjunction with
        // ProductComparer, which implements IEqualityComparer (not IEquatable).
        //<Snippet10>
        ProductA[] store1 = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 } };

        ProductA[] store2 = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "lemon", Code = 12 } };
        //</Snippet10>


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
        
        IEnumerable<ProductA> duplicates =
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

        IEnumerable<ProductA> union =
          store1.Union(store2);

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
            products.Distinct();

        foreach (var product in noduplicates)
            Console.WriteLine(product.Name + " " + product.Code);

        /*
            This code produces the following output:
            apple 9 
            orange 4
            lemon 12
        */
        //</Snippet5>

        //EXCEPT

        //<Snippet7>
        ProductA[] fruits1 = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 },
                                new ProductA { Name = "lemon", Code = 12 } };

        ProductA[] fruits2 = { new ProductA { Name = "apple", Code = 9 } };

        //Get all the elements from the first array
        //except for the elements from the second array.

        IEnumerable<ProductA> except =
            fruits1.Except(fruits2);

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

        ProductA[] storeA = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 } };

        ProductA[] storeB = { new ProductA { Name = "apple", Code = 9 }, 
                               new ProductA { Name = "orange", Code = 4 } };

        bool equalAB = storeA.SequenceEqual(storeB);

        Console.WriteLine("Equal? " + equalAB);

        /*
            This code produces the following output:
            
            Equal? True
        */

        //</Snippet8>
        Console.ReadLine();

    }

//<Snippet9>
public class ProductA
{ 
    public string Name { get; set; }
    public int Code { get; set; }
}

public class ProductComparer : IEqualityComparer<ProductA>
{

    public bool Equals(ProductA x, ProductA y)
    {
        //Check whether the objects are the same object. 
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether the products' properties are equal. 
        return x != null && y != null && x.Code.Equals(y.Code) && x.Name.Equals(y.Name);
    }

    public int GetHashCode(ProductA obj)
    {
        //Get hash code for the Name field if it is not null. 
        int hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();

        //Get hash code for the Code field. 
        int hashProductCode = obj.Code.GetHashCode();

        //Calculate the hash code for the product. 
        return hashProductName ^ hashProductCode;
    }
}
//</Snippet9>

}
