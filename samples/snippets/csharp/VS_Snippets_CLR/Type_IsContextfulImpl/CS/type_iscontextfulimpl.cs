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
    // Override IsContextfulImpl.
    protected override bool IsContextfulImpl()
    {
        // Check whether the type is contextful.
        if(myType.IsContextful)
        { 
            myElementType = " is contextful ";
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
            Console.WriteLine ("Check whether MyContextBoundClass can be hosted in a context.");
            // Check whether MyContextBoundClass is contextful.
            myType = new MyTypeDelegatorClass(typeof(MyContextBoundClass));
            if( myType.IsContextful)
            {
                Console.WriteLine(typeof(MyContextBoundClass) + " can be hosted in a context.");
            }
            else
            {
                Console.WriteLine(typeof(MyContextBoundClass) + " cannot be hosted in a context.");
            }
            // Check whether the int type is contextful.
            myType = new MyTypeDelegatorClass(typeof(MyTypeDemoClass));
            Console.WriteLine ("\nCheck whether MyTypeDemoClass can be hosted in a context.");
            if( myType.IsContextful)
            {
                Console.WriteLine(typeof(MyTypeDemoClass) + " can be hosted in a context.");
            }
            else
            {
                Console.WriteLine(typeof(MyTypeDemoClass) + " cannot be hosted in a context.");
            }
        }
        catch( Exception e )
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
// This class demonstrates IsContextfulImpl.
public class MyContextBoundClass : ContextBoundObject
{
    public string myString = "This class is used to demonstrate members of the Type class.";
}
// </Snippet1>
