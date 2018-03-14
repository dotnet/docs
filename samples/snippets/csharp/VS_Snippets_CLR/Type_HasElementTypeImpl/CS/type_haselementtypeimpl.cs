// <Snippet1>
using System;
using System.Reflection;
public class MyTypeDelegator : TypeDelegator
{
    public string myElementType = null;
    private Type myType = null ; 
    public MyTypeDelegator(Type myType) : base(myType)
    {
        this.myType = myType;
    }
    // Override Type.HasElementTypeImpl().
    protected override bool HasElementTypeImpl()
    {
        // Determine whether the type is an array.
        if(myType.IsArray)
        {
            myElementType = "array";
            return true;
        }
        // Determine whether the type is a reference.
        if(myType.IsByRef)
        {
            myElementType = "reference";
            return true;
        }
        // Determine whether the type is a pointer.
        if(myType.IsPointer)
        { 
            myElementType = "pointer";
            return true;
        }
        // Return false if the type is not a reference, array, or pointer type.
        return false;
    }  
}
public class Type_HasElementTypeImpl
{
    public static void Main()
    {
        try
        {
            int myInt = 0 ; 
            int[] myArray = new int[5];
            MyTypeDelegator myType = new MyTypeDelegator(myArray.GetType());
            // Determine whether myType is an array, pointer, reference type.  
            Console.WriteLine("\nDetermine whether a variable is an array, pointer, or reference type.\n");
            if( myType.HasElementType)
                Console.WriteLine("The type of myArray is {0}.", myType.myElementType);
            else
                Console.WriteLine("myArray is not an array, pointer, or reference type.");
            myType = new MyTypeDelegator(myInt.GetType());
            // Determine whether myType is an array, pointer, reference type. 
            if( myType.HasElementType)
                Console.WriteLine("The type of myInt is {0}.", myType.myElementType);
            else
                Console.WriteLine("myInt is not an array, pointer, or reference type.");
        }
        catch( Exception e )
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// </Snippet1>

