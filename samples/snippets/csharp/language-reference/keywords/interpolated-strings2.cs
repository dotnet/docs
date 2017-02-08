// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      var price = 1000;
      IFormattable s2 = $"The cost of this item is {price:C}.";  
      ShowInfo(s2);
      CultureInfo.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine(s2);
      CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
      Console.WriteLine(s2);      
   }

   private static void ShowInfo(object obj)
   {
      Console.WriteLine("Displaying member information:\n");
      var t = obj.GetType();
      var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;
      foreach (var m in t.GetMembers(flags)) {
         Console.WriteLine($"{m.Name}: {m.MemberType}");   
         if (m.MemberType == MemberTypes.Property) {
            var p = t.GetProperty(m.Name, flags);
            Console.WriteLine($"   Value: {p.GetValue(obj)}");         
         }
         if (m.MemberType == MemberTypes.Field) {
            var f = t.GetField(m.Name, flags);
            Console.WriteLine($"   Value: {f.GetValue(obj)}");
         }
      }
      Console.WriteLine("-------\n");
   }
}
// The example displays the following output:
//       Displaying member information:
//       
//       get_Format: Method
//       GetArguments: Method
//       get_ArgumentCount: Method
//       GetArgument: Method
//       ToString: Method
//       System.IFormattable.ToString: Method
//       ToString: Method
//       Equals: Method
//       GetHashCode: Method
//       GetType: Method
//       Finalize: Method
//       MemberwiseClone: Method
//       .ctor: Constructor
//       Format: Property
//          Value: The cost of this item is {0:C}.
//       ArgumentCount: Property
//          Value: 1
//       _format: Field
//          Value: The cost of this item is {0:C}.
//       _arguments: Field
//          Value: System.Object[]
//       -------
//       
//       The cost of this item is $1,000.00.
//       The cost of this item is 1 000,00 €.
// </Snippet1>

