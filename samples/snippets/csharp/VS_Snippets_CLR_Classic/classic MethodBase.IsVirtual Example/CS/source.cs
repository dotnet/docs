// <Snippet1>
using System;
using System.Reflection;
 
public class MyClass 
{
    public void MyMethod() 
    {
    }
    public static void Main() 
    {
        MethodBase m = typeof(MyClass).GetMethod("MyMethod");
        Console.WriteLine("The IsFinal property value of MyMethod is {0}.", m.IsFinal);
        Console.WriteLine("The IsVirtual property value of MyMethod is {0}.", m.IsVirtual);
    }
}
// </Snippet1>