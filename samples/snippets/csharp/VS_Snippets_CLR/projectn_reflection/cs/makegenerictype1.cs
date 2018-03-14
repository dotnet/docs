using System;
using System.Collections.Generic;
using System.Reflection;


class Example
{
   internal static TextBlock b;

   public static void Main()
   {
       Example.GetGenericInfo();
       Example.b = new TextBlock();
   }
   //public Example(TextBlock block)
   //{
   //   Example.b = block;
   //}

   // <Snippet2>
   public static void GetGenericInfo()
   {
      // Get the type that represents the generic type definition and
      // display information about it.
      Type generic1 = typeof(Dictionary<,>);
      DisplayGenericType(generic1);

      // Get the type that represents a constructed generic type and its 
      // generic type definition.
      Dictionary<string, Example> d1 = new Dictionary<string, Example>();
      Type constructed1 = d1.GetType();
      Type generic2 = constructed1.GetGenericTypeDefinition();

      // Display information for the generic type definition, and
      // for the constructed type Dictionary<String, Example>.
      DisplayGenericType(constructed1);
      DisplayGenericType(generic2);

      // Construct an array of type arguments.
      Type[] typeArgs = { typeof(string), typeof(Example) };
      // Construct the type Dictionary<String, Example>.
      Type constructed2 = generic1.MakeGenericType(typeArgs);

      DisplayGenericType(constructed2);

      object o = Activator.CreateInstance(constructed2);

      b.Text += "\r\nCompare types obtained by different methods:\n";
      b.Text += String.Format("   Are the constructed types equal? {0}\n",
                              (d1.GetType() == constructed2));
      b.Text += String.Format("   Are the generic definitions equal? {0}\n",
                              (generic1 == constructed2.GetGenericTypeDefinition()));

      // Demonstrate the DisplayGenericType and 
      // DisplayGenericParameter methods with the Test class 
      // defined above. This shows base, interface, and special
      // constraints.
      DisplayGenericType(typeof(TestGeneric<>));
   }

   // Display information about a generic type.
   private static void DisplayGenericType(Type t)
   {
      b.Text += String.Format("\n{0}\n", t);
      b.Text += String.Format("   Generic type? {0}\n",
                              t.GetTypeInfo().GenericTypeParameters.Length !=
                              t.GenericTypeArguments.Length);
      b.Text += String.Format("   Generic type definition? {0}\n",
                              ! t.IsConstructedGenericType);

      // Get the generic type parameters.
      Type[] typeParameters = t.GetTypeInfo().GenericTypeParameters;
      if (typeParameters.Length > 0)
      {
         b.Text += String.Format("   {0} type parameters:\n",
                                 typeParameters.Length);
         foreach (Type tParam in typeParameters)
            b.Text += String.Format("      Type parameter: {0} position {1}\n",
                     tParam.Name, tParam.GenericParameterPosition);

      }
      else
      {
         Type[] typeArgs = t.GenericTypeArguments;
         b.Text += String.Format("   {0} type arguments:\n",
                                 typeArgs.Length);
         foreach (var tArg in typeArgs)
               b.Text += String.Format("      Type argument: {0}\n",
                                       tArg);
      }
      b.Text += "\n-------------------------------\n";
   }

}

public interface ITestInterface { }

public class TestBase { }

public class TestGeneric<T> where T : TestBase, ITestInterface, new() { }

public class TestArgument : TestBase, ITestInterface
{
   public TestArgument()
   { }
}
// </Snippet2>

internal class TextBlock
{
   private String s;
   
   public String Text 
   {
      get { return s; }
      set { s = value; }
   }
}
