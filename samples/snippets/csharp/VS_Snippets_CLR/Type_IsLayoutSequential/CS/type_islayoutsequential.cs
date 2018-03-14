// <Snippet1>
using System;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
class MyTypeSequential1
{
}
[StructLayoutAttribute(LayoutKind.Sequential)]
class MyTypeSequential2
{
    public static void Main(string []args)
    {
        try
        {
            // Create an instance of myTypeSeq1.
            MyTypeSequential1 myObj1 = new MyTypeSequential1();
            Type myTypeObj1 = myObj1.GetType();
            // Check for and display the SequentialLayout attribute.
            Console.WriteLine("\nThe object myObj1 has IsLayoutSequential: {0}.", myObj1.GetType().IsLayoutSequential);
            // Create an instance of 'myTypeSeq2' class.
            MyTypeSequential2 myObj2 = new MyTypeSequential2();
            Type myTypeObj2 = myObj2.GetType();
            // Check for and display the SequentialLayout attribute.
            Console.WriteLine("\nThe object myObj2 has IsLayoutSequential: {0}.", myObj2.GetType().IsLayoutSequential);
        }
        catch(Exception e)
        {
            Console.WriteLine("\nAn exception occurred: {0}", e.Message);
        }
    }
}
// </Snippet1>
