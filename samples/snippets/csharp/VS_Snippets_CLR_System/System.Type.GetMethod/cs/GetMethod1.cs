// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Get a Type object that represents a non-generic type.
      GetAddMethod(typeof(ArrayList));

      var list = new List<String>();
      // Get a Type object that represents a constructed generic type.
      Type closed = list.GetType();
      GetAddMethod(closed);
      
      // Get a Type object that represents an open generic type.
      Type open = typeof(List<>);
      GetAddMethod(open);
   }

   private static void GetAddMethod(Type typ)
   {
      MethodInfo method;
      // Determine if this is a generic type.
      if (typ.IsGenericType) {
         // Is it an open generic type?
         if (typ.ContainsGenericParameters)
            method = typ.GetMethod("Add", typ.GetGenericArguments());
         // Get closed generic type arguments.
         else
            method = typ.GetMethod("Add", typ.GenericTypeArguments);
      }
      // This is not a generic type.
      else {
         method = typ.GetMethod("Add", new Type[] { typeof(Object) } );
      }

      // Test if an Add method was found.
      if (method == null) { 
         Console.WriteLine("No Add method found.");
         return;
      }   
      
      Type t = method.ReflectedType;
      Console.Write("{0}.{1}.{2}(", t.Namespace, t.Name, method.Name);
      ParameterInfo[] parms = method.GetParameters();
      for (int ctr = 0; ctr < parms.Length; ctr++)
         Console.Write("{0}{1}", parms[ctr].ParameterType.Name, 
                       ctr < parms.Length - 1 ? ", " : "");

      Console.WriteLine(")");
   }   
}
// The example displays the following output:
//       System.Collections.ArrayList.Add(Object)
//       System.Collections.Generic.List`1.Add(String)
//       System.Collections.Generic.List`1.Add(T)
// </Snippet1>

