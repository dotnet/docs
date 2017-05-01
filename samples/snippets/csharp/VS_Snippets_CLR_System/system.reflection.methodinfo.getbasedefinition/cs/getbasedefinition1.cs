// <Snippet1>
using System;
using System.Reflection;

interface Interf
{
   string InterfaceImpl(int n);
}

public class BaseClass
{
   public override string ToString()
   {
      return "Base";
   }

   public virtual void Method1()
   {
      Console.WriteLine("Method1");
   }

   public virtual void Method2()
   {
      Console.WriteLine("Method2");
   }

   public virtual void Method3()
   {
      Console.WriteLine("Method3");
   }
}

public class DerivedClass : BaseClass, Interf
{
   public string InterfaceImpl(int n)
   {
      return n.ToString("N");
   }

   public override void Method2()
   {
      Console.WriteLine("Derived.Method2");
   }

   public new void Method3()
   {
      Console.WriteLine("Derived.Method3");
   }
}

public class Example
{
   public static void Main()
   {
      Type t = typeof(DerivedClass);
      MethodInfo m, mb;
      string[] methodNames = { "ToString", "Equals", "InterfaceImpl",
                               "Method1", "Method2", "Method3" };

      foreach (var methodName in methodNames) {
         m = t.GetMethod(methodName);
         mb = m.GetBaseDefinition();
         Console.WriteLine("{0}.{1} --> {2}.{3}", m.ReflectedType.Name,
                           m.Name, mb.ReflectedType.Name, mb.Name);
      }
   }
}
// The example displays the following output:
//       DerivedClass.ToString --> Object.ToString
//       DerivedClass.Equals --> Object.Equals
//       DerivedClass.InterfaceImpl --> DerivedClass.InterfaceImpl
//       DerivedClass.Method1 --> BaseClass.Method1
//       DerivedClass.Method2 --> BaseClass.Method2
//       DerivedClass.Method3 --> DerivedClass.Method3
// </Snippet1>
