//<snippet1>
// Sample for String.Intern(String)
using System;
using System.Text;

class Sample
{
    public static void Main()
    {
        string s1 = "MyTest";
        string s2 = new StringBuilder().Append("My").Append("Test").ToString(); 
        string s3 = String.Intern(s2);
        Console.WriteLine($"s1 == {s1}");
        Console.WriteLine($"s2 == {s2}");
        Console.WriteLine($"s3 == {s3}");
        Console.WriteLine($"Is s2 the same reference as s1?: {(Object)s2 == (Object)s1}"); 
        Console.WriteLine($"Is s3 the same reference as s1?: {(Object)s3 == (Object)s1}");
    }
}
/*
This example produces the following results:
s1 == MyTest
s2 == MyTest
s3 == MyTest
Is s2 the same reference as s1?: False
Is s3 the same reference as s1?: True
*/
//</snippet1>
