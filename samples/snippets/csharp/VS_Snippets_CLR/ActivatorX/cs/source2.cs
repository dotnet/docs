//<snippet4>
using System;

class DynamicInstanceList
{
    private static string instanceSpec = "System.EventArgs;System.Random;" +
        "System.Exception;System.Object;System.Version";

    public static void Main()
    {
        string[] instances = instanceSpec.Split(';');
        Array instlist = Array.CreateInstance(typeof(object), instances.Length);
        object item;
        for (int i = 0; i < instances.Length; i++)
        {
            // create the object from the specification string
            Console.WriteLine("Creating instance of: {0}", instances[i]);
            item = Activator.CreateInstance(Type.GetType(instances[i]));
            instlist.SetValue(item, i);
        }
        Console.WriteLine("\nObjects and their default values:\n");
        foreach (object o in instlist)
        {
            Console.WriteLine("Type:     {0}\nValue:    {1}\nHashCode: {2}\n",
                o.GetType().FullName, o.ToString(), o.GetHashCode());
        }
    }
}

// This program will display output similar to the following:
//
// Creating instance of: System.EventArgs
// Creating instance of: System.Random
// Creating instance of: System.Exception
// Creating instance of: System.Object
// Creating instance of: System.Version
//
// Objects and their default values:
//
// Type:     System.EventArgs
// Value:    System.EventArgs
// HashCode: 46104728
//
// Type:     System.Random
// Value:    System.Random
// HashCode: 12289376
//
// Type:     System.Exception
// Value:    System.Exception: Exception of type 'System.Exception' was thrown.
// HashCode: 55530882
//
// Type:     System.Object
// Value:    System.Object
// HashCode: 30015890
//
// Type:     System.Version
// Value:    0.0
// HashCode: 1048575
//</snippet4>
