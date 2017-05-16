using System;

namespace App1
{
   public class AppClass<T>
   {
//      private T type;
      
      public AppClass()
      {
//         this.type = type; 
      }
   }
}


public class Example
{
   public static void Main()
   {
      // <Snippet1>
      var t = Type.GetType("App1.AppClass`1", true);
      Type[] typeArgs = {typeof(int)};
      Type t2 = t.MakeGenericType(typeArgs);
      Activator.CreateInstance(t2);
      // </Snippet1>
      Console.WriteLine(t2.GetType().Name);
   }
}