// <Snippet1>
using System;
using System.Reflection;

public class MainClass 
{ 
    public static void Main(string[] args)
    {
        Type tDate = typeof(System.DateTime);
        Object result = tDate.InvokeMember("Now", 
            BindingFlags.GetProperty, null, null, new Object[0]);
        Console.WriteLine(result.ToString());
    }
}
// </Snippet1>
