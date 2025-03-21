using System;
using System.Reflection;
using System.Runtime.Versioning;

[assembly:ComponentGuaranteesAttribute(ComponentGuaranteesOptions.None)]
namespace MyLibrary
{
   [ComponentGuaranteesAttribute(ComponentGuaranteesOptions.Stable)] public class MyLibraryClass
   {
      public string GetName()
      { 
         return "My Library"; 
      }
   }
   
   [ComponentGuaranteesAttribute(ComponentGuaranteesOptions.Exchange)] public class MyPrimitiveClass
   {}
   
   [ComponentGuaranteesAttribute(ComponentGuaranteesOptions.None)] public class MyChurningClass
   {}
}

public class Example
{
   public static void Main()
   {
      Assembly assem = typeof(Example).Assembly;
      foreach (Type typ in assem.GetTypes())
      {
         object[] typeAttribs = typ.GetCustomAttributes(typeof(ComponentGuaranteesAttribute), true);
         if (typeAttribs.Length > 0)
         {
            ComponentGuaranteesAttribute guaranteeAttrib = (ComponentGuaranteesAttribute) typeAttribs[0];
            ComponentGuaranteesOptions guarantee = guaranteeAttrib.Guarantees;
            // Test whether guarantee is Exchange.
            if ((guarantee & ComponentGuaranteesOptions.Exchange) == ComponentGuaranteesOptions.Exchange)
               Console.WriteLine($"{typ.Name} is marked as {guarantee}.");
            // <Snippet1>   
            // Test whether guarantee is Stable.
            if ((guarantee & ComponentGuaranteesOptions.Stable) == ComponentGuaranteesOptions.Stable)
               Console.WriteLine($"{typ.Name} is marked as {guarantee}.");
            // </Snippet1>
            // <Snippet2>
            // Test whether guarantee is Stable or Exchange.
            if ((guarantee & (ComponentGuaranteesOptions.Stable | ComponentGuaranteesOptions.Exchange)) > 0)
               Console.WriteLine($"{typ.Name} is marked as Stable or Exchange.");
            // </Snippet2>
            // <Snippet3>
            // Test whether there is no guarantee (neither Stable nor Exchange).
            if ((guarantee & (ComponentGuaranteesOptions.Stable | ComponentGuaranteesOptions.Exchange)) == 0)
               Console.WriteLine($"{typ.Name} has no compatibility guarantee.");
            // </Snippet3>            
         }
      }
   }
}
