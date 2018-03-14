// <Snippet1>

using System;
using System.Reflection;

class Program
{

    // Method to get:
    public void MethodA() { }


    static void Main(string[] args)
    {

        // Get MethodA()
        MethodInfo mInfo = typeof(Program).GetMethod("MethodA",
            BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine("Found method: {0}", mInfo);

    }
}
// </Snippet1>


