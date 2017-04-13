// System.Type.GetTypeFromHandle(RuntimeTypeHandle)

/*
   The following example demonstrates the 'GetTypeFromHandle(RuntimeTypeHandle)' method
   of the 'Type' Class.
	It defines an empty class 'Myclass1' and obtains an object of 'Myclass1'. Then the runtime handle of 
	the object is obtained and passed as an argument to 'GetTypeFromHandle(RuntimeTypeHandle)'method. That 
	returns the type referenced by the specified type handle.
*/



using System;
using System.Reflection;

public class MyClass1
{
}
public class MyClass2
{
   public static void Main()
   {
// <Snippet1>
        MyClass1 myClass1 = new MyClass1();
	     // Get the type referenced by the specified type handle.
        Type myClass1Type = Type.GetTypeFromHandle(Type.GetTypeHandle(myClass1));
        Console.WriteLine("The Names of the Attributes :"+myClass1Type.Attributes);
// </Snippet1>
   }
}

