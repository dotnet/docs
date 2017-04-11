// <Snippet1>
using System;
using System.Collections.Generic;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Type t =typeof(int);
      Object obj1 = typeof(int).GetTypeInfo();
      IsEqualTo(t, obj1);

      Object obj2 = typeof(String);
      IsEqualTo(t, obj2);
      
      t = typeof(Object);
      Object obj3 = typeof(Object);
      IsEqualTo(t, obj3);
      
      t = typeof(List<>);
      Object obj4 = (new List<String>()).GetType();
      IsEqualTo(t, obj4);
      
      t = typeof(Type);
      Object obj5 = null;
      IsEqualTo(t, obj5);
   }
   
   private static void IsEqualTo(Type t, Object inst)
   {
      Type t2 = inst as Type;
      if (t2 != null)
         Console.WriteLine("{0} = {1}: {2}", t.Name, t2.Name,
                           t.Equals(t2));
      else
         Console.WriteLine("Cannot cast the argument to a type.");

      Console.WriteLine();                        
   }
}
// The example displays the following output:
//       Int32 = Int32: True
//       
//       Int32 = String: False
//       
//       Object = Object: True
//       
//       List`1 = List`1: False
//       
//       Cannot cast the argument to a type.
// </Snippet1>


