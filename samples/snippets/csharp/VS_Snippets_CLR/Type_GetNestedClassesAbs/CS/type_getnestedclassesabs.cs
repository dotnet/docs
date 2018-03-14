// <Snippet1>
using System;
using System.Reflection;

// Create a class with 2 nested public and 2 nested protected classes.
public class MyTypeClass
{
    public class Myclass1
    {
    }

    public class Myclass2 
    {
    }

    protected class MyClass3
    {
    }

    protected class MyClass4
    {
    }
}

public class TypeMain
{
    public static void Main() 
    {
        Type myType = (typeof(MyTypeClass));
        // Get the public nested classes.
        Type[] myTypeArray = myType.GetNestedTypes(BindingFlags.Public);
        Console.WriteLine("The number of nested public classes is {0}.", myTypeArray.Length);
        // Display all the public nested classes.
        DisplayTypeInfo(myTypeArray);
        Console.WriteLine();
        
        // Get the nonpublic nested classes.
        Type[] myTypeArray1 = myType.GetNestedTypes(BindingFlags.NonPublic|BindingFlags.Instance);
        Console.WriteLine("The number of nested protected classes is {0}.", myTypeArray1.Length);
        // Display all the nonpublic nested classes.
        DisplayTypeInfo(myTypeArray1);		
    }

    public static void DisplayTypeInfo(Type[] myArrayType)
    {
        // Display the information for all the nested classes.
        foreach (var t in myArrayType)
            Console.WriteLine("The name of the nested class is {0}.", t.FullName);
    }
}
// The example displays the following output:
//       The number of public nested classes is 2.
//       The name of the nested class is MyTypeClass+Myclass1.
//       The name of the nested class is MyTypeClass+Myclass2.
//       
//       The number of protected nested classes is 2.
//       The name of the nested class is MyTypeClass+MyClass3.
//       The name of the nested class is MyTypeClass+MyClass4.
//	</Snippet1>