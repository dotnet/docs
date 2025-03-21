//<snippet15>
using System;

class Example
{
    public static void Main()
    {
        Trim();
        TrimEnd1();
        TrimEnd2();
        TrimStart();
        Remove();
    }

    public static void Trim()
    {
        // <snippet17>
        string MyString = " Big   ";
        Console.WriteLine($"Hello{MyString}World!");
        string TrimString = MyString.Trim();
        Console.WriteLine($"Hello{TrimString}World!");
        //       The example displays the following output:
        //             Hello Big   World!
        //             HelloBigWorld!
        // </snippet17>
    }

    public static void TrimEnd1()
    {
        // <snippet18>
        string MyString = "Hello World!";
        char[] MyChar = {'r','o','W','l','d','!',' '};
        string NewString = MyString.TrimEnd(MyChar);
        Console.WriteLine(NewString);
        // </snippet18>
    }

    public static void TrimEnd2()
    {
        // <snippet19>
        string MyString = "Hello, World!";
        char[] MyChar = {'r','o','W','l','d','!',' '};
        string NewString = MyString.TrimEnd(MyChar);
        Console.WriteLine(NewString);
        // </snippet19>
    }

    public static void TrimStart()
    {
        // <snippet20>
        string MyString = "Hello World!";
        char[] MyChar = {'e', 'H','l','o',' ' };
        string NewString = MyString.TrimStart(MyChar);
        Console.WriteLine(NewString);
        // </snippet20>
    }

    public static void Remove()
    {
        // <snippet21>
        string MyString = "Hello Beautiful World!";
        Console.WriteLine(MyString.Remove(5,10));
        // The example displays the following output:
        //         Hello World!
        // </snippet21>
    }
}
//</snippet15>
