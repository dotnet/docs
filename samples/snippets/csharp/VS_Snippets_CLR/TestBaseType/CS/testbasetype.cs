//<Snippet1>
using System;
class TestType 
{
    public static void Main() 
    {
        Type t = typeof(int);
        Console.WriteLine("{0} inherits from {1}.", t,t.BaseType);
    }
}
//</Snippet1>