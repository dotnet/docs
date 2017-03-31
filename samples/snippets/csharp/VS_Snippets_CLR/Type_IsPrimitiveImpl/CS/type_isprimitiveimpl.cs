// <Snippet1>
using System;
using System.Reflection;
public class MyTypeDelegatorClass : TypeDelegator
{
    public string myElementType = null;
    private Type myType = null ; 
    public MyTypeDelegatorClass(Type myType) : base(myType)
    {
        this.myType = myType;
    }
    // Override the IsPrimitiveImpl.
    protected override bool IsPrimitiveImpl()
    {
        // Determine whether the type is a primitive type.
        if(myType.IsPrimitive)
        { 
            myElementType = "primitive";
            return true;
        }
        return false;
    }
}
public class MyTypeDemoClass
{
    public static void Main()
    {
        try
        {
            Console.WriteLine ("Determine whether int is a primitive type.");
            MyTypeDelegatorClass myType;
            myType = new MyTypeDelegatorClass(typeof(int));
            // Determine whether int is a primitive type.
            if( myType.IsPrimitive)
            {
                Console.WriteLine(typeof(int) + " is a primitive type.");
            }
            else
            {
                Console.WriteLine(typeof(int) + " is not a primitive type.");
            }
            Console.WriteLine ("\nDetermine whether string is a primitive type.");
            myType = new MyTypeDelegatorClass(typeof(string));
            // Determine if string is a primitive type.
            if( myType.IsPrimitive)
            {
                Console.WriteLine(typeof(string) + " is a primitive type.");
            }
            else
            {
                Console.WriteLine(typeof(string) + " is not a primitive type.");
            }
        }
        catch( Exception e )
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// </Snippet1>