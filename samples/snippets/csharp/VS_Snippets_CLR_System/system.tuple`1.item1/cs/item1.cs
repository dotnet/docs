// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      var tuple1 = Tuple.Create(-1.23445e-32);
      // Display information about this singleton.
      Type tuple1Type = tuple1.GetType();
      Console.WriteLine("First 1-Tuple:");
      Console.WriteLine("   Type: {0}", tuple1Type.Name);
      Console.WriteLine("   Generic Parameter Type: {0}", 
                        tuple1Type.GetGenericArguments()[0]);
      Console.WriteLine("   Component Value: {0}", tuple1.Item1);
      Console.WriteLine("   Component Value Type: {0}", 
                        tuple1.Item1.GetType().Name);
      Console.WriteLine();
      
      var tuple2 = Tuple.Create((BigInteger)1.83789322281780983781356676e103);
      // Display information about this singleton.
      Type tuple2Type = tuple2.GetType();
      Console.WriteLine("Second 1-Tuple:");
      Console.WriteLine("   Type: {0}", tuple2Type.Name);
      Console.WriteLine("   Generic Parameter Type: {0}", 
                        tuple2Type.GetGenericArguments()[0]);
      Console.WriteLine("   Component Value: {0}", tuple2.Item1);
      Console.WriteLine("   Component Value Type: {0}", 
                        tuple2.Item1.GetType().Name);
   }
}
// The example displays the following output:
//       First 1-Tuple:
//          Type: Tuple`1
//          Generic Parameter Type: System.Double
//          Component Value: -1.23445E-32
//          Component Value Type: Double
//       
//       Second 1-Tuple:
//          Type: Tuple`1
//          Generic Parameter Type: System.Numerics.BigInteger
//          Component Value: 1.8378932228178098168858909492E+103
//          Component Value Type: BigInteger
// </Snippet1>