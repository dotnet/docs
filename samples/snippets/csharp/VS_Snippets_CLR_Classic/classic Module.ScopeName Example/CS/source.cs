// <Snippet1>
 using System.Reflection;
 using System;
 
 public class Simple
 {
    public static void Main ()
    {
         Module mod = typeof(Simple).Assembly.GetModules()[0];
         Console.WriteLine ("Module Name is "
            + mod.Name);
         Console.WriteLine ("Module FullyQualifiedName is "
            + mod.FullyQualifiedName);
         Console.WriteLine ("Module ScopeName is "
            + mod.ScopeName);
    }
 }
 /*
 The example displays output like the folloowing:
 Module Name is modname.exe
 Module FullyQualifiedName is C:\Bin\modname.exe
 Module ScopeName is modname.exe
 */
// </Snippet1>

