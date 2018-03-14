//<Snippet1>
using System;

public interface IExample {}

public class BaseClass : IExample {}

public class DerivedClass : BaseClass {}

public class Example
{
    public static void Main()
    {
        var interfaceType = typeof(IExample);
        var base1 = new BaseClass();
        var base1Type = base1.GetType();
        var derived1 = new DerivedClass();
        var derived1Type = derived1.GetType();
        int[] arr = new int[11];

        Console.WriteLine("Is int[] an instance of the Array class? {0}.",
                           typeof(Array).IsInstanceOfType(arr));
        Console.WriteLine("Is base1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(base1));
        Console.WriteLine("Is derived1 an instance of BaseClass? {0}.",
                          base1Type.IsInstanceOfType(derived1));
        Console.WriteLine("Is base1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(base1));
        Console.WriteLine("Is derived1 an instance of IExample? {0}.",
                          interfaceType.IsInstanceOfType(derived1));
    }
}
// The example displays the following output:
//    Is int[] an instance of the Array class? True.
//    Is base1 an instance of BaseClass? True.
//    Is derived1 an instance of BaseClass? True.
//    Is base1 an instance of IExample? True.
//    Is derived1 an instance of IExample? True.
//</Snippet1>