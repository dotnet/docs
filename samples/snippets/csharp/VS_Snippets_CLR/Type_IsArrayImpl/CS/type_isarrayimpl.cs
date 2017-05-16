// <Snippet1>
using System;
using System.Reflection;
public class MyTypeDelegator : TypeDelegator
{
    public string myElementType = null;
    public Type myType;
    public MyTypeDelegator(Type myType) : base(myType)
    {
        this.myType = myType;
    }
    // Override IsArrayImpl().
    protected override bool IsArrayImpl()
    {
        // Determine whether the type is an array.
        if(myType.IsArray)
        {
            myElementType = "array";
            return true;
        }
        // Return false if the type is not an array.
        return false;  
    }
}
public class Type_IsArrayImpl
{
    public static void Main()
    {
        try
        {
            int myInt = 0 ; 
            // Create an instance of an array element.
            int[] myArray = new int[5];
            MyTypeDelegator myType = new MyTypeDelegator(myArray.GetType());
            Console.WriteLine("\nDetermine whether the variable is an array.\n");
            // Determine whether myType is an array type.  
            if( myType.IsArray)
                Console.WriteLine("The type of myArray is {0}.", myType.myElementType);
            else
                Console.WriteLine("myArray is not an array.");
            myType = new MyTypeDelegator(myInt.GetType());

            // Determine whether myType is an array type. 
            if( myType.IsArray)
                Console.WriteLine("The type of myInt is {0}.", myType.myElementType);
            else
                Console.WriteLine("myInt is not an array.");
        }
        catch( Exception e )
        {
            Console.WriteLine("Exception: {0}", e.Message );
        }
    }
}
// </Snippet1>
