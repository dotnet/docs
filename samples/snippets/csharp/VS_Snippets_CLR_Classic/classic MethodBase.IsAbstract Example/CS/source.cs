// <Snippet1>
using System;
using System.Reflection;
// using System.Windows.Forms;

class methodbase
{
    public static int Main(string[] args)
    {      
        Console.WriteLine ("\nReflection.MethodBase");
        
        // Get the types.
        Type MyType1 = Type.GetType("System.Runtime.Serialization.Formatter");       
        Type MyType2 = Type.GetType("System.Reflection.MethodBase");
 
        // Get and display the methods.
        MethodBase Mymethodbase1 = 
            MyType1.GetMethod("WriteInt32", BindingFlags.NonPublic|BindingFlags.Instance);

        MethodBase Mymethodbase2 = 
            MyType2.GetMethod("GetCurrentMethod", BindingFlags.Public|BindingFlags.Static);
 
        Console.Write("\nMymethodbase = " + Mymethodbase1.ToString());
        if (Mymethodbase1.IsAbstract)
            Console.Write ("\nMymethodbase is an abstract method.");
        else
            Console.Write ("\nMymethodbase is not an abstract method.");
 
        Console.Write("\n\nMymethodbase = " + Mymethodbase2.ToString());
        if (Mymethodbase2.IsAbstract)
            Console.Write ("\nMymethodbase is an abstract method.");
        else
            Console.Write ("\nMymethodbase is not an abstract method.");
       
        return 0;
    }
}
// </Snippet1>
