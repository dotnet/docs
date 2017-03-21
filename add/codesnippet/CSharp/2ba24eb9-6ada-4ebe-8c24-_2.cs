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