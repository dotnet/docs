// <Snippet1>
using System;
using System.Runtime.InteropServices;

// The Demo class is attributed as AutoLayout.
[StructLayoutAttribute(LayoutKind.Auto)]
public class Demo
{
}

public class Example
{
    public static void Main()
    {
        // Create an instance of the Type class using the GetType method.
        Type  myType=typeof(Demo);
        // Get and display the IsAutoLayout property of the 
        // Demoinstance.
        Console.WriteLine("\nThe AutoLayout property for the Demo class is {0}.",
            myType.IsAutoLayout); 
    }
}
// </Snippet1>