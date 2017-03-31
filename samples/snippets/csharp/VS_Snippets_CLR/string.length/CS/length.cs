//<snippet1>
using System;

class Sample 
{
    public static void Main() 
    {
       string str = "abcdefg";
       Console.WriteLine("1) The length of '{0}' is {1}", str, str.Length);
       Console.WriteLine("2) The length of '{0}' is {1}", "xyz", "xyz".Length);
       
       int length = str.Length;
       Console.WriteLine("3) The length of '{0}' is {1}", str, length);
    }
}
// This example displays the following output:
//    1) The length of 'abcdefg' is 7
//    2) The length of 'xyz' is 3
//    3) The length of 'abcdefg' is 7
//</snippet1>