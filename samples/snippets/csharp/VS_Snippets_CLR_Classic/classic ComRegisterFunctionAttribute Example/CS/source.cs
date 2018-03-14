// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class MyClassThatNeedsToRegister
{
   [ComRegisterFunctionAttribute]
   public static void RegisterFunction(Type t)
   {
      //Insert code here.
   }
   
   [ComUnregisterFunctionAttribute]
   public static void UnregisterFunction(Type t)
   {
      //Insert code here.
   }
}
// </Snippet1>

