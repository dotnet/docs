// </Snippet1>
using System;


public class Example
{
    delegate void TestDelegate(string s);

    public static void Main()
    {
       TestDelegate test = n => { string s = n + " " + "World"; Console.WriteLine(s); };  
       test("Hello");
    }
}

// </Snippet1>  

