// <Snippet1>

using System;
using System.Reflection;

class Example
{
    public static void Main()
    {

        Type a = typeof(System.String);
        Type b = typeof(System.Int32);

        Console.WriteLine("{0} == {1}: {2}", a, b, a.Equals(b));

        // The Type objects in a and b are not equal,
        // because they represent different types.

        a = typeof(Example);
        b = new Example().GetType();

        Console.WriteLine("{0} is equal to {1}: {2}", a, b, a.Equals(b));

        // The Type objects in a and b are equal,
        // because they both represent type Example.

        b = typeof(Type);

        Console.WriteLine("typeof({0}).Equals(typeof({1})): {2}", a, b, a.Equals(b));

        // The Type objects in a and b are not equal,
        // because variable a represents type Example
        // and variable b represents type Type.

        //Console.ReadLine();

    }
}

//
/* This code example produces the following output:
    System.String == System.Int32: False
    Example is equal to Example: True
    typeof(Example).Equals(typeof(System.Type)): False
*/
// </Snippet1>