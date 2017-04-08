// <Snippet1>
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

public class Example
{
   string Name; 
   
   public Example(string name)
   {
      this.Name = name;
   }
   
   public override string ToString()
   {
      return this.Name;
   }
}

// Define a class to contain information about each Example instance.
public class ExampleInfo
{
   public string Name;
   public int Methods;
   public int Properties;
   
   public override string ToString()
   {
      return String.Format("{0}: {1} Methods, {2} Properties", 
                           this.Name, this.Methods, this.Properties);
   }
}

public class ExampleTest
{
   private static BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

   public static void Main()
   {
      Example ex1 = new Example("ex1");
      Example ex2 = new Example("ex2");
      Example ex3 = new Example("ex3");
      
      ExampleInfo exInfo1 = new ExampleInfo(); 
      exInfo1.Name = ex1.ToString();
      exInfo1.Methods = ex1.GetType().GetMethods(flags).Length;
      exInfo1.Properties = ex1.GetType().GetProperties(flags).Length;
      
      ExampleInfo exInfo3 = new ExampleInfo(); 
      exInfo3.Name = ex3.ToString();
      exInfo3.Methods = ex3.GetType().GetMethods(flags).Length;
      exInfo3.Properties = ex3.GetType().GetProperties(flags).Length;

      var attached = new ConditionalWeakTable<Example, ExampleInfo>();
      ExampleInfo value = null;

      // Attach a property to ex1 using the Add method, then retrieve it.
      attached.Add(ex1, exInfo1);
      if (attached.TryGetValue(ex1, out value))
         Console.WriteLine("{0}, {1}", ex1, value);
      else
         Console.WriteLine("{0} does not have an attached property.", ex1);

      // Attempt to retrieve the value attached to ex2.
      value = attached.GetValue(ex2, ExampleTest.CreateAttachedValue);      
      if (attached.TryGetValue(ex2, out value))
         Console.WriteLine("{0}, {1}", ex2, value);
      else 
         Console.WriteLine("{0} does not have an attached property.", ex2);
      
      // Attempt to retrieve the value attached to ex3.
      value = attached.GetOrCreateValue(ex3);
      Console.WriteLine("{0}, {1}", ex3, value);
   }

   public static ExampleInfo CreateAttachedValue(Example ex)
   {
      ExampleInfo info = new ExampleInfo();
      info.Name = ex.ToString();
      info.Methods = ex.GetType().GetMethods(flags).Length;
      info.Properties = ex.GetType().GetProperties(flags).Length;
      return info;
   }
}
// The example displays the following output:
//       ex1, ex1: 4 Methods, 0 Properties
//       ex2, ex2: 4 Methods, 0 Properties
//       ex3, : 0 Methods, 0 Properties
// </Snippet1>