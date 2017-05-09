// <Snippet1>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[ComVisible(true)]
class MyComVisibleType {
   public MyComVisibleType() {
      Console.WriteLine("MyComVisibleType instantiated!");
   }
}

[ComVisible(false)]
class MyComNonVisibleType {
   public MyComNonVisibleType() {
      Console.WriteLine("MyComNonVisibleType instantiated!");
   }
}

class Test {
   public static void Main() {
      CreateComInstance("MyComNonVisibleType");   // Fail!
      CreateComInstance("MyComVisibleType");      // OK!
   }
   
   static void CreateComInstance(string typeName) {
      try {
         AppDomain currentDomain = AppDomain.CurrentDomain;
         string assemblyName = currentDomain.FriendlyName;
         currentDomain.CreateComInstanceFrom(assemblyName, typeName);
      } catch (Exception e) {
         Console.WriteLine(e.Message);
      }
   }
}
// </Snippet1>