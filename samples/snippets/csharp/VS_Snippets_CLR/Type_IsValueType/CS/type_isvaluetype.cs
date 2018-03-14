// <Snippet1>   
using System;

// Declare an enum type.
enum NumEnum { One, Two }

public class Example
{

    public static void Main(string []args)
    {
        bool flag = false;
        NumEnum testEnum = NumEnum.One;
        // Get the type of myTestEnum.
        Type t = testEnum.GetType();
        // Get the IsValueType property of the myTestEnum variable.
        flag = t.IsValueType;
        Console.WriteLine("{0} is a value type: {1}", t.FullName, flag);
    }
}
// The example displays the following output:
//        NumEnum is a value type: True
// </Snippet1>