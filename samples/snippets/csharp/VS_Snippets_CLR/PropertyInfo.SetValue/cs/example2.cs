//<Snippet2>
using System;
using System.Reflection;

class Example
{
    private static int _staticProperty = 41;
    private int _instanceProperty = 42;

    // Declare a public static property.
    public static int StaticProperty
    {
        get { return _staticProperty; }
        set { _staticProperty = value; }
    }

    // Declare a public instance property.
    public int InstanceProperty
    {
        get { return _instanceProperty; }
        set { _instanceProperty = value; }
    }

    public static void Main()
    {
        Console.WriteLine("Initial value of static property: {0}",
            Example.StaticProperty);

        // Get a type object that represents the Example type.
        Type examType = typeof(Example);

        // Change the static property value.
        PropertyInfo piShared = examType.GetProperty("StaticProperty");
        piShared.SetValue(null, 76);
                 
        Console.WriteLine("New value of static property: {0}",
                          Example.StaticProperty);

        // Create an instance of the Example class.
        Example exam = new Example();

        Console.WriteLine("\nInitial value of instance property: {0}", 
                          exam.InstanceProperty);

        // Change the instance property value.
        PropertyInfo piInstance = examType.GetProperty("InstanceProperty");
        piInstance.SetValue(exam, 37);
                 
        Console.WriteLine("New value of instance property: {0}",
                          exam.InstanceProperty);
    }
}
// The example displays the following output:
//       Initial value of static property: 41
//       New value of static property: 76
//
//       Initial value of instance property: 42
//       New value of instance property: 37
//</Snippet2>



