using System;
using System.Reflection;
using System.Windows.Forms;

// <Snippet1>
 class methodbase
 {
    public static int Main(string[] args)
    {     
 
       Console.WriteLine("\nReflection.MethodBase");
       
       //Get the MethodBase of a method.
  
       //Get the type
       Type MyType = Type.GetType("System.MulticastDelegate");
  
       //Get and display the method
       MethodBase Mymethodbase =
          MyType.GetMethod("RemoveImpl",BindingFlags.NonPublic);
  
       Console.Write("\nMymethodbase = " + Mymethodbase);
  
       bool Myispublic = Mymethodbase.IsPublic;
       if (Myispublic)
          Console.Write ("\nMymethodbase is a public method");
       else
          Console.Write ("\nMymethodbase is not a public method");
       
       return 0;
    }
 }
 /*
 Produces the following output
 
 Reflection.MethodBase
 Mymethodbase = System.Delegate RemoveImpl (System.Delegate)
 Mymethodbase is not a public method
 */
// </Snippet1>

