// <Snippet2>
using System;
using System.Reflection;

public class TestClass
{
   public void DisplayValue(String s)
   {
      Console.WriteLine(s);
   }
   
   public void DisplayValue(String s, params Object[] values)
   {
      Console.WriteLine(s, values);
   }
   
   public static bool Equals(TestClass t1, TestClass t2)
   {
      return Object.ReferenceEquals(t1, t2);
   }
   
   public bool Equals(TestClass t) 
   {
      return Object.ReferenceEquals(this, t);
   }          
}

public class Example
{
   public static void Main()
   {
      Type t = typeof(TestClass);
      
      RetrieveMethod(t, "DisplayValue", BindingFlags.Public | BindingFlags.Instance);

      RetrieveMethod(t, "Equals", BindingFlags.Public | BindingFlags.Instance);
      
      RetrieveMethod(t, "Equals", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
      
      RetrieveMethod(t, "Equals", BindingFlags.Public | BindingFlags.Static);
   }
   
   private static void RetrieveMethod(Type t, String name, BindingFlags flags)
   {
      try {
         MethodInfo m = t.GetMethod(name, flags);
         if (m != null) {
            Console.Write("{0}.{1}(", t.Name, m.Name);
            ParameterInfo[] parms= m.GetParameters();
            for (int ctr = 0; ctr <parms.Length; ctr++) {
               Console.Write(parms[ctr].ParameterType.Name);
               if (ctr < parms.Length - 1) 
                  Console.Write(", ");

            }
            Console.WriteLine(")");
         }
         else {
            Console.WriteLine("Method not found");
         }
      }
      catch (AmbiguousMatchException) {
         Console.WriteLine("The following duplicate matches were found:");
         MethodInfo[] methods = t.GetMethods(flags);
         foreach (var method in methods) {
            if (method.Name != name) continue;

            Console.Write("   {0}.{1}(", t.Name, method.Name);
            ParameterInfo[] parms = method.GetParameters();
            for (int ctr = 0; ctr < parms.Length; ctr++) {
               Console.Write(parms[ctr].ParameterType.Name);
               if (ctr < parms.Length - 1) 
                  Console.Write(", ");

            }
            Console.WriteLine(")");
         } 
      }         
      Console.WriteLine();
   }
}
// The example displays the following output:
//       The following duplicate matches were found:
//          TestClass.DisplayValue(String)
//          TestClass.DisplayValue(String, Object[])
//       
//       The following duplicate matches were found:
//          TestClass.Equals(TestClass)
//          TestClass.Equals(Object)
//       
//       TestClass.Equals(TestClass)
//       
//       TestClass.Equals(TestClass, TestClass)
// </Snippet2>

