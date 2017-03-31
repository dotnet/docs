// This example demonstrates StringBuilder.EnsureCapacity
//                           StringBuilder.Capacity
//                           StringBuilder.Length
//                           StringBuilder.Equals
//<snippet1>
using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {
    StringBuilder sb1 = new StringBuilder("abc");
    StringBuilder sb2 = new StringBuilder("abc", 16);

    Console.WriteLine();
    Console.WriteLine("a1) sb1.Length = {0}, sb1.Capacity = {1}", sb1.Length, sb1.Capacity);
    Console.WriteLine("a2) sb2.Length = {0}, sb2.Capacity = {1}", sb2.Length, sb2.Capacity);
    Console.WriteLine("a3) sb1.ToString() = \"{0}\", sb2.ToString() = \"{1}\"", 
                           sb1.ToString(),       sb2.ToString());
    Console.WriteLine("a4) sb1 equals sb2: {0}", sb1.Equals(sb2));

    Console.WriteLine();
    Console.WriteLine("Ensure sb1 has a capacity of at least 50 characters.");
    sb1.EnsureCapacity(50);

    Console.WriteLine();
    Console.WriteLine("b1) sb1.Length = {0}, sb1.Capacity = {1}", sb1.Length, sb1.Capacity);
    Console.WriteLine("b2) sb2.Length = {0}, sb2.Capacity = {1}", sb2.Length, sb2.Capacity);
    Console.WriteLine("b3) sb1.ToString() = \"{0}\", sb2.ToString() = \"{1}\"", 
                           sb1.ToString(),       sb2.ToString());
    Console.WriteLine("b4) sb1 equals sb2: {0}", sb1.Equals(sb2));

    Console.WriteLine();
    Console.WriteLine("Set the length of sb1 to zero.");
    Console.WriteLine("Set the capacity of sb2 to 51 characters.");
    sb1.Length = 0;
    sb2.Capacity = 51;

    Console.WriteLine();
    Console.WriteLine("c1) sb1.Length = {0}, sb1.Capacity = {1}", sb1.Length, sb1.Capacity);
    Console.WriteLine("c2) sb2.Length = {0}, sb2.Capacity = {1}", sb2.Length, sb2.Capacity);
    Console.WriteLine("c3) sb1.ToString() = \"{0}\", sb2.ToString() = \"{1}\"", 
                           sb1.ToString(),       sb2.ToString());
    Console.WriteLine("c4) sb1 equals sb2: {0}", sb1.Equals(sb2));
    }
}
/*
The example displays the following output:

a1) sb1.Length = 3, sb1.Capacity = 16
a2) sb2.Length = 3, sb2.Capacity = 16
a3) sb1.ToString() = "abc", sb2.ToString() = "abc"
a4) sb1 equals sb2: True

Ensure sb1 has a capacity of at least 50 characters.

b1) sb1.Length = 3, sb1.Capacity = 50
b2) sb2.Length = 3, sb2.Capacity = 16
b3) sb1.ToString() = "abc", sb2.ToString() = "abc"
b4) sb1 equals sb2: False

Set the length of sb1 to zero.
Set the capacity of sb2 to 51 characters.

c1) sb1.Length = 0, sb1.Capacity = 50
c2) sb2.Length = 3, sb2.Capacity = 51
c3) sb1.ToString() = "", sb2.ToString() = "abc"
c4) sb1 equals sb2: False
*/
//</snippet1>