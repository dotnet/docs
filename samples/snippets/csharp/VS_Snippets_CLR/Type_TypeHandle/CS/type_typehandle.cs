// <Snippet1>	
using System;
using System.Reflection;
class MyClass
{
    public int myField = 10;
}

class Type_TypeHandle
{
    public static void Main()
    {
        try
        {
            MyClass myClass = new MyClass();

            // Get the type of MyClass.
            Type myClassType = myClass.GetType();

            // Get the runtime handle of MyClass.
            RuntimeTypeHandle myClassHandle = myClassType.TypeHandle;
         
            DisplayTypeHandle(myClassHandle);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message );
        }
    }

    public static void DisplayTypeHandle(RuntimeTypeHandle myTypeHandle)
    {
        // Get the type from the handle.
        Type myType = Type.GetTypeFromHandle(myTypeHandle);      
        // Display the type.
        Console.WriteLine("\nDisplaying the type from the handle:\n");
        Console.WriteLine("The type is {0}.", myType.ToString());
    }
}
// </Snippet1>