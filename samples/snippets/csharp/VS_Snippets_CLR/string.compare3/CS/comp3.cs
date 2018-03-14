//<snippet1>
// Sample for String.Compare(String, Int32, String, Int32, Int32)
using System;

class Sample {
    public static void Main() {
//                 0123456
    String str1 = "machine";
    String str2 = "device";
    String str;
    int result;

    Console.WriteLine();
    Console.WriteLine("str1 = '{0}', str2 = '{1}'", str1, str2);
    result = String.Compare(str1, 2, str2, 0, 2);
    str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
    Console.Write("Substring '{0}' in '{1}' is ", str1.Substring(2, 2), str1);
    Console.Write("{0} ", str);
    Console.WriteLine("substring '{0}' in '{1}'.", str2.Substring(0, 2), str2);
    }
}
/*
This example produces the following results:

str1 = 'machine', str2 = 'device'
Substring 'ch' in 'machine' is less than substring 'de' in 'device'.
*/
//</snippet1>