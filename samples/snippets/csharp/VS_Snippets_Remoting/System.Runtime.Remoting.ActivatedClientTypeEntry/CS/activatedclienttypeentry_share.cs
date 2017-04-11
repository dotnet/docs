//<snippet20>
using System;
public class HelloServer : MarshalByRefObject
{
    public HelloServer(String myString)
    {
        Console.WriteLine("HelloServer activated");
        Console.WriteLine("Parameter passed to the constructor is "+myString);
    }
    public String HelloMethod(String myName)
    {
        Console.WriteLine("HelloMethod : {0}",myName);
        return "Hi there " + myName;
    }
}
//</snippet20>
