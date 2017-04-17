//<snippet1>
using System;

class Sample 
{
    public static void Main() 
    {
    string s1 = "abcd";
    string s2 = "";
    string s3 = null;

    Console.WriteLine("String s1 {0}.", Test(s1));
    Console.WriteLine("String s2 {0}.", Test(s2));
    Console.WriteLine("String s3 {0}.", Test(s3));
    }

    public static String Test(string s)
    {
    if (String.IsNullOrEmpty(s)) 
        return "is null or empty";
    else
        return String.Format("(\"{0}\") is neither null nor empty", s);
    }
}
// The example displays the following output:
//       String s1 ("abcd") is neither null nor empty.
//       String s2 is null or empty.
//       String s3 is null or empty.
// </snippet1>