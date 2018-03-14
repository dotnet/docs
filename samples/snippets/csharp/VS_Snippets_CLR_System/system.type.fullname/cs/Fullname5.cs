// <Snippet5>
using System;
using System.Reflection;

public class Base<T> { }

public class Derived<T> : Base<T> { }

public class Example
{
   public static void Main()
   {
      Type t = typeof(Derived<>);
      Console.WriteLine("Generic Class: {0}", t.FullName);
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        t.ContainsGenericParameters);
      Console.WriteLine("   Generic Type Definition: {0}\n",
                        t.IsGenericTypeDefinition);                 

      Type baseType = t.BaseType;
      Console.WriteLine("Its Base Class: {0}", 
                        baseType.FullName ?? 
                        "(unassigned) " + baseType.ToString());
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        baseType.ContainsGenericParameters);
      Console.WriteLine("   Generic Type Definition: {0}",
                        baseType.IsGenericTypeDefinition);                 
      Console.WriteLine("   Full Name: {0}\n", 
                        baseType.GetGenericTypeDefinition().FullName);

      t = typeof(Base<>);
      Console.WriteLine("Generic Class: {0}", t.FullName);
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        t.ContainsGenericParameters);
      Console.WriteLine("   Generic Type Definition: {0}\n",
                        t.IsGenericTypeDefinition);                 


   }
}
// The example displays the following output:
//       Generic Class: Derived`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
//       
//       Its Base Class: (unassigned) Base`1[T]
//          Contains Generic Paramters: True
//          Generic Type Definition: False
//          Full Name: Base`1
//       
//       Generic Class: Base`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
// </Snippet5>

