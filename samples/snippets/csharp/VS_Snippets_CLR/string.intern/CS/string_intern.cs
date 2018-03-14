//<snippet1>
// Sample for String.Intern(String)
using System;
using System.Text;

class Sample {
    public static void Main() {
    String s1 = "MyTest";
    String s2 = new StringBuilder().Append("My").Append("Test").ToString(); 
    String s3 = String.Intern(s2); 
    Console.WriteLine("s1 == '{0}'", s1);
    Console.WriteLine("s2 == '{0}'", s2);
    Console.WriteLine("s3 == '{0}'", s3);
    Console.WriteLine("Is s2 the same reference as s1?: {0}", (Object)s2==(Object)s1); 
    Console.WriteLine("Is s3 the same reference as s1?: {0}", (Object)s3==(Object)s1);
    }
}
/*
This example produces the following results:
s1 == 'MyTest'
s2 == 'MyTest'
s3 == 'MyTest'
Is s2 the same reference as s1?: False
Is s3 the same reference as s1?: True
*/
//</snippet1>