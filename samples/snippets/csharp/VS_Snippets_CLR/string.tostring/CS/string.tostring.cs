//<snippet1>
using System;

class stringToString {
    public static void Main() {
    String str1 = "123";
    String str2 = "abc";

    Console.WriteLine("Original str1: {0}", str1);
    Console.WriteLine("Original str2: {0}", str2);
    Console.WriteLine("str1 same as str2?: {0}", Object.ReferenceEquals(str1, str2));

    str2 = str1.ToString();
    Console.WriteLine();
    Console.WriteLine("New str2:      {0}", str2);
    Console.WriteLine("str1 same as str2?: {0}", Object.ReferenceEquals(str1, str2));
    }
}
/*
This code produces the following output:
Original str1: 123
Original str2: abc
str1 same as str2?: False

New str2:      123
str1 same as str2?: True
*/
//</snippet1>