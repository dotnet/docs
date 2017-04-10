// <Snippet1>
using System;
using System.Reflection;

// Create a class having six properties.
public class PropertyClass
{
    public String Property1
    {
        get { return "hello"; }
    }

    public String Property2
    {
        get { return "hello"; }
    }

    protected String Property3
    {
        get { return "hello"; }
    }

    private Int32 Property4
    {
        get { return 32; }
    }

    internal String Property5
    {
       get { return "value"; }
    }

    protected internal String Property6
    {
       get { return "value"; }
    }
}

public class Example
{
    public static void Main() 
    {
        Type t = typeof(PropertyClass);
        // Get the public properties.
        PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        Console.WriteLine("The number of public properties: {0}.\n",
                          propInfos.Length);
        // Display the public properties.
        DisplayPropertyInfo(propInfos);

        // Get the nonpublic properties.
        PropertyInfo[] propInfos1 = t.GetProperties(BindingFlags.NonPublic|BindingFlags.Instance);
        Console.WriteLine("The number of non-public properties: {0}.\n",
                          propInfos1.Length);
        // Display all the nonpublic properties.
        DisplayPropertyInfo(propInfos1);
    }

    public static void DisplayPropertyInfo(PropertyInfo[] propInfos)
    {
        // Display information for all properties.
        foreach (var propInfo in propInfos) {
            bool readable = propInfo.CanRead;
            bool writable = propInfo.CanWrite;
            
            Console.WriteLine("   Property name: {0}", propInfo.Name);
            Console.WriteLine("   Property type: {0}", propInfo.PropertyType);
            Console.WriteLine("   Read-Write:    {0}", readable & writable);
            if (readable) {
               MethodInfo getAccessor = propInfo.GetMethod;
               Console.WriteLine("   Visibility:    {0}",
                                 GetVisibility(getAccessor));
            }
            if (writable) {
               MethodInfo setAccessor = propInfo.SetMethod;
               Console.WriteLine("   Visibility:    {0}",
                                 GetVisibility(setAccessor));
            }
            Console.WriteLine();
        }
    }

    public static String GetVisibility(MethodInfo accessor)
    {
       if (accessor.IsPublic)
          return "Public";
       else if (accessor.IsPrivate)
          return "Private";
       else if (accessor.IsFamily)
          return "Protected";
       else if (accessor.IsAssembly)
          return "Internal/Friend";
       else
          return "Protected Internal/Friend";
    }
}
// The example displays the following output:
//       The number of public properties: 2.
//
//          Property name: Property1
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//          Property name: Property2
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//       The number of non-public properties: 4.
//
//          Property name: Property3
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Protected
//
//          Property name: Property4
//          Property type: System.Int32
//          Read-Write:    False
//          Visibility:    Private
//
//          Property name: Property5
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Internal/Friend
//
//          Property name: Property6
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Protected Internal/Friend
// </Snippet1>
