// <Snippet1>
using System;

class Example
{
   static void Main()
   {
      Tuple<Double>[] values = { Tuple.Create(13.54),
                                 Tuple.Create(Double.NaN),
                                 Tuple.Create(-189.42993),
                                 Tuple.Create(Double.PositiveInfinity),
                                 Tuple.Create(Double.Epsilon),
                                 Tuple.Create(1.934E-17),
                                 Tuple.Create(Double.NegativeInfinity),
                                 Tuple.Create(-0.000000000003588),
                                 null };
      Console.WriteLine("The values in unsorted order:");
      foreach (var value in values)
         if (value != null)
            Console.WriteLine("   {0}", value.Item1);
         else
            Console.WriteLine("   <null>");
      Console.WriteLine();

      Array.Sort(values);

      Console.WriteLine("The values in sorted order:");
      foreach (var value in values)
         if (value != null)
            Console.WriteLine("   {0}", value.Item1);
         else
            Console.WriteLine("   <null>");
   }
}
// The example displays the following output:
//      The values in unsorted order:
//         13.54
//         NaN
//         -189.42993
//         Infinity
//         4.94065645841247E-324
//         1.934E-17
//         -Infinity
//         -3.588E-12
//
//      The values in sorted order:
//         NaN
//         -Infinity
//         -189.42993
//         -3.588E-12
//         4.94065645841247E-324
//         1.934E-17
//         13.54
//         Infinity
// </Snippet1>
