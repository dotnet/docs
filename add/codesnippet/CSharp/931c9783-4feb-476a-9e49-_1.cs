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