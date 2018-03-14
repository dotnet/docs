// <Snippet1>
using System;
using System.Reflection;

public  class MyDemoClass
{
}

public class MyTypeClass
{
    public static void Main(string[] args)
    {
        try
        {
            Type  myType = typeof(MyDemoClass);
            // Get and display the 'IsClass' property of the 'MyDemoClass' instance.
            Console.WriteLine("\nIs the specified type a class? {0}.", myType.IsClass); 
        }
        catch(Exception e)
        {
            Console.WriteLine("\nAn exception occurred: {0}." ,e.Message);
        }
    }
}
// </Snippet1>
