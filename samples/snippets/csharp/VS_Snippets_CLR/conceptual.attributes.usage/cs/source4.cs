//<snippet21>
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class MyAttribute : Attribute
{
    public string Description { get; }
    public MyAttribute(string description) { Description = description; }
}

public class MyClass
{
    [MyAttribute("This is a sample method.")]
    public void MyMethod() { }
}

class AttributeRetrieval
{
    public static void Main()
    {
        // Create an instance of MyClass
        MyClass myClass = new MyClass();

        // Retrieve the method information for MyMethod
        MethodInfo methodInfo = typeof(MyClass).GetMethod("MyMethod");
        MyAttribute attribute = (MyAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(MyAttribute));

        if (attribute != null)
        {
            // Print the description of the method attribute
            Console.WriteLine("Method Attribute: {0}", attribute.Description);
        }
        else
        {
            Console.WriteLine("Attribute not found.");
        }
    }
}
//</snippet21>
