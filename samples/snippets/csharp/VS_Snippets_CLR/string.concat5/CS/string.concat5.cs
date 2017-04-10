//<snippet1>
using System;

class stringConcat5 {
    public static void Main() {
    int i = -123;
    Object o = i;
    Object[] objs = new Object[] {-123, -456, -789};

    Console.WriteLine("Concatenate 1, 2, and 3 objects:");
    Console.WriteLine("1) {0}", String.Concat(o));
    Console.WriteLine("2) {0}", String.Concat(o, o));
    Console.WriteLine("3) {0}", String.Concat(o, o, o));

    Console.WriteLine("\nConcatenate 4 objects and a variable length parameter list:");
    Console.WriteLine("4) {0}", String.Concat(o, o, o, o));
    Console.WriteLine("5) {0}", String.Concat(o, o, o, o, o));

    Console.WriteLine("\nConcatenate a 3-element object array:");
    Console.WriteLine("6) {0}", String.Concat(objs));
    }
}
// The example displays the following output:
//    Concatenate 1, 2, and 3 objects:
//    1) -123
//    2) -123-123
//    3) -123-123-123
//    
//    Concatenate 4 objects and a variable length parameter list:
//    4) -123-123-123-123
//    5) -123-123-123-123-123
//    
//    Concatenate a 3-element object array:
//    6) -123-456-789
// </snippet1>