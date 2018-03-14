// <Snippet1>	
using System;

class MyGetTypeFromCLSID
{
    public class MyClass1
    {
        public void MyMethod1()
        {
        }
    }
    public static void Main()
    {
        // Get the type corresponding to the class MyClass.
        Type myType = typeof(MyClass1);
        // Get the object of the Guid.
        Guid myGuid =(Guid) myType.GUID;
        Console.WriteLine("The name of the class is "+myType.ToString());
        Console.WriteLine("The ClassId of MyClass is "+myType.GUID);				
    }
}
// </Snippet1>

