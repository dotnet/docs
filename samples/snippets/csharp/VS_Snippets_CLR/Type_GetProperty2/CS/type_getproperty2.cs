// <Snippet1>   

using System;
using System.Reflection;
class MyClass
{
    private int myProperty;
    // Declare MyProperty.
    public int MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty=value;
        }
    }
}
public class MyTypeClass
{
    public static void Main(string[] args)
    {
        try
        {
            // Get Type object of MyClass.
            Type myType=typeof(MyClass);       
            // Get the PropertyInfo by passing the property name and specifying the BindingFlags.
            PropertyInfo myPropInfo = myType.GetProperty("MyProperty", BindingFlags.Public | BindingFlags.Instance);
            // Display Name propety to console.
            Console.WriteLine("{0} is a property of MyClass.", myPropInfo.Name);
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine("MyProperty does not exist in MyClass." +e.Message);
        }
    }
}
// </Snippet1>