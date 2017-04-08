// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Assembly assem = typeof(Example).Assembly;
      Type t = assem.GetType("Transportation.MeansOfTransportation");
      if (t != null) {
         Console.WriteLine("Virtual properties in type {0}:", 
                           t.FullName);
         PropertyInfo[] props = t.GetProperties();
         int nVirtual = 0;
         for (int ctr = 0; ctr < props.Length; ctr++)
            if (props[ctr].GetMethod.IsVirtual) {
               Console.WriteLine("   {0} (type {1})",
                                 props[ctr].Name, 
                                 props[ctr].PropertyType.FullName);
               nVirtual++;
            }

         if (nVirtual == 0) 
            Console.WriteLine("   No virtual properties");
      }   
   }
}

namespace Transportation
{
   public abstract class MeansOfTransportation
   {
      abstract public bool HasWheels { get; set; }
      abstract public int Wheels { get; set; }
      abstract public bool ConsumesFuel { get; set; }
      abstract public bool Living  { get; set; }
   }
 
}
// The example displays the following output:
//    Virtual properties in type Transportation.MeansOfTransportation:
//       HasWheels (type System.Boolean)
//       Wheels (type System.Int32)
//       ConsumesFuel (type System.Boolean)
//       Living (type System.Boolean)
// </Snippet1>

