//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Reflection;

// This code is compiled into a strong-named
// assembly that requires full trust and does 
// not allow partially trusted callers. 

namespace AptcaTestLibrary
{
   public class ClassRequiringFullTrust
   {
      public static void DoWork()
      {
        Console.WriteLine("ClassRequiringFullTrust.DoWork was called.");
      }
   }
}
//</Snippet1>
