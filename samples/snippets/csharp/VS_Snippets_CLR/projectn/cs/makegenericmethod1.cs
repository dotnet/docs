using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      Type ct = typeof(Class1);
      MethodInfo mi = ct.GetMethod("GetMethod");
      Type[] typeArgs = {typeof(int)};
      object[] parameters = { 12 };
      var method = mi.MakeGenericMethod(typeArgs);
      Class1 c = new Class1();
      method.Invoke(c, parameters);
      // </Snippet2>
   }
}

public class Class1
{
   public void GetMethod<T>(T t)
   {
      if (t == null) {
         Console.WriteLine("t is null!");
         return;
      }   
      Console.WriteLine(t.GetType().Name);
      Console.WriteLine("The value is {0}", t);
   }
}