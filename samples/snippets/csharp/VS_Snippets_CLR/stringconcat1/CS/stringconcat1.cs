// <Snippet1>
using System;

public class ConcatTest {
    public static void Main() {
        // Create a group of objects.
        Test1 t1 = new Test1();
        Test2 t2 = new Test2();
        int i = 16;
        string s = "Demonstration";

        // Place the objects in an array.
        object [] o = { t1, i, t2, s };

        // Concatenate the objects together as a string. To do this,
        // the ToString method of each of the objects is called.
        Console.WriteLine(string.Concat(o));
    }
}

// Create two empty test classes.
class Test1 {
}

class Test2 {
}
// The example displays the following output:
//       Test116Test2Demonstration
// </Snippet1>
