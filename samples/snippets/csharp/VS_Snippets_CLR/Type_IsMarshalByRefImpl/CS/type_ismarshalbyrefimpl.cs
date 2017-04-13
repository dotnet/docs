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
    // Override IsMarshalByRefImpl.
    protected override bool IsMarshalByRefImpl()
    {
        // Determine whether the type is marshalled by reference.
        if(myType.IsMarshalByRef)
        { 
            myElementType = " marshalled by reference";
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
            MyTypeDelegatorClass myType;
            Console.WriteLine ("Determine whether MyContextBoundClass is marshalled by reference.");
            // Determine whether MyContextBoundClass type is marshalled by reference.
            myType = new MyTypeDelegatorClass(typeof(MyContextBoundClass));
            if( myType.IsMarshalByRef )
            {
                Console.WriteLine(typeof(MyContextBoundClass) + " is marshalled by reference.");
            }
            else
            {
                Console.WriteLine(typeof(MyContextBoundClass) + " is not marshalled by reference.");
            }

            // Determine whether int type is marshalled by reference.
            myType = new MyTypeDelegatorClass(typeof(int));
            Console.WriteLine ("\nDetermine whether int is marshalled by reference.");
            if( myType.IsMarshalByRef)
            {
                Console.WriteLine(typeof(int) + " is marshalled by reference.");
            }
            else
            {
                Console.WriteLine(typeof(int) + " is not marshalled by reference.");
            }
        }
        catch( Exception e )
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// This class is used to demonstrate the IsMarshalByRefImpl method.
public class MyContextBoundClass : ContextBoundObject
{
    public string myString = "This class is used to demonstrate members of the Type class.";
}
// </Snippet1>
