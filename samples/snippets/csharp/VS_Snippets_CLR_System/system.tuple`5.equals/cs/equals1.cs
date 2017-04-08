// <Snippet1>
using System;

public class Class1
{
   public static void Main()
   {
      Tuple<int, double, double, double, double>[] temperatureInfos = 
                           { Tuple.Create(2, 97.9, 97.8, 98.0, 98.2),
                             Tuple.Create(1, 98.6, 98.8, 98.8, 99.0), 
                             Tuple.Create(2, 98.6, 98.6, 98.6, 98.4),
                             Tuple.Create(1, 98.4, 98.6, 99.0, 99.2),
                             Tuple.Create(2, 98.6, 98.6, 98.6, 98.4),
                             Tuple.Create(1, 98.6, 98.8, 98.8, 99.0) }; 
      // Compare each item with every other item for equality.
      for (int ctr = 0; ctr < temperatureInfos.Length; ctr++)
      {
         var temperatureInfo = temperatureInfos[ctr];
         for (int ctr2 = ctr + 1; ctr2 < temperatureInfos.Length; ctr2++)
            Console.WriteLine("{0} = {1}: {2}", temperatureInfo, temperatureInfos[ctr2], 
                                                temperatureInfo.Equals(temperatureInfos[ctr2]));
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
//    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.4, 98.6, 99, 99.2): False
//    (2, 97.9, 97.8, 98, 98.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (2, 97.9, 97.8, 98, 98.2) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.6, 98.8, 98.8, 99) = (1, 98.4, 98.6, 99, 99.2): False
//    (1, 98.6, 98.8, 98.8, 99) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.6, 98.8, 98.8, 99) = (1, 98.6, 98.8, 98.8, 99): True
//    
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.4, 98.6, 99, 99.2): False
//    (2, 98.6, 98.6, 98.6, 98.4) = (2, 98.6, 98.6, 98.6, 98.4): True
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (1, 98.4, 98.6, 99, 99.2) = (2, 98.6, 98.6, 98.6, 98.4): False
//    (1, 98.4, 98.6, 99, 99.2) = (1, 98.6, 98.8, 98.8, 99): False
//    
//    (2, 98.6, 98.6, 98.6, 98.4) = (1, 98.6, 98.8, 98.8, 99): False
// </Snippet1>