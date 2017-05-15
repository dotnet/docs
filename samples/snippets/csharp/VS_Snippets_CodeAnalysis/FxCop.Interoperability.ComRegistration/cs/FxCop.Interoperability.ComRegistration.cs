//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(true)]
namespace InteroperabilityLibrary
{
   public class ClassToRegister
   {
   }

   public class ComRegistration
   {
      [ComRegisterFunction]
      internal static void RegisterFunction(Type typeToRegister) {}

//      [ComUnregisterFunction]
//      internal static void UnregisterFunction(Type typeToRegister) {}
   }
}

//</Snippet1>
