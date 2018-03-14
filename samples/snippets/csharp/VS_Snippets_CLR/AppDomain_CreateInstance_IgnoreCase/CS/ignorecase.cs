// <Snippet1>
using System;
using System.Reflection;

class Test {

   static void Main() {
      InstantiateINT32(false);     // Failed!
      InstantiateINT32(true);      // OK!
   }
   
   static void InstantiateINT32(bool ignoreCase) {
      try {
         AppDomain currentDomain = AppDomain.CurrentDomain;
         object instance = currentDomain.CreateInstanceAndUnwrap(
            "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "SYSTEM.INT32",
            ignoreCase,
            BindingFlags.Default,
            null,
            null,
            null,
            null,
            null
         );
         Console.WriteLine(instance.GetType());
      } catch (TypeLoadException e) {
         Console.WriteLine(e.Message);
      }
   }
}
// </Snippet1>