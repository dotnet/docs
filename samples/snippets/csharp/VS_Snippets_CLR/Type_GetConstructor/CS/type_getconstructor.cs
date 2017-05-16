// <Snippet1>

using System;
using System.Reflection;
using System.Security;

public class MyClass1
{
    public MyClass1(){}
    public MyClass1(int i){}

    public static void Main()
    {
        try
        {
            Type myType = typeof(MyClass1);
            Type[] types = new Type[1];
            types[0] = typeof(int);
            // Get the constructor that takes an integer as a parameter.
            ConstructorInfo constructorInfoObj = myType.GetConstructor(types);
            if (constructorInfoObj != null)
            {
                Console.WriteLine("The constructor of MyClass1 that takes an " + 
                    "integer as a parameter is: "); 
                Console.WriteLine(constructorInfoObj.ToString());
            }
            else
            {
                Console.WriteLine("The constructor of MyClass1 that takes an integer " +
                    "as a parameter is not available."); 
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception caught.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
    }
}
// </Snippet1>