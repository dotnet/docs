// <Snippet3>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Assembly assem = Assembly.ReflectionOnlyLoadFrom(@".\Enumerations.dll");
      Type typ = assem.GetType("Pets");
      FieldInfo[] fields = typ.GetFields();

      foreach (var field in fields) {
         if (field.Name.Equals("value__")) continue;
          
         Console.WriteLine("{0,-9} {1}", field.Name + ":", 
                                         field.GetRawConstantValue());
      }
   }
}
// The example displays the following output:
//       None:     0
//       Dog:      1
//       Cat:      2
//       Rodent:   4
//       Bird:     8
//       Fish:     16
//       Reptile:  32
//       Other:    64
// </Snippet3>

// <Snippet2>
[Flags] enum Pets { None=0, Dog=1, Cat=2, Rodent=4, Bird=8, 
                    Fish=16, Reptile=32, Other=64 };
// </Snippet2>

