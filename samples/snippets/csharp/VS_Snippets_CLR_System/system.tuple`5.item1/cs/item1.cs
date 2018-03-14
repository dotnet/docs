// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define array of tuples reflecting population change by state, 1990-2000.
      Tuple<string, int, int, int, double>[] statesData = 
         { Tuple.Create("California", 29760021, 33871648, 4111627, 13.8), 
           Tuple.Create("Illinois", 11430602, 12419293, 988691, 8.6), 
           Tuple.Create("Washington", 4866692, 5894121, 1027429, 21.1) };

      // Display the items of each tuple
      Console.WriteLine("{0,-12}{1,18}{2,18}{3,15}{4,12}\n", "State", 
                        "Population 1990", "Population 2000", "Change", 
                        "% Change");
      foreach(Tuple<string, int, int, int, double> stateData in statesData)
         Console.WriteLine("{0,-12}{1,18:N0}{2,18:N0}{3,15:N0}{4,12:P1}", 
                           stateData.Item1, stateData.Item2, 
                           stateData.Item3, stateData.Item4, stateData.Item5/100);      
   }
}
// The example displays the following output:
//    State          Population 1990   Population 2000         Change    % Change
//    
//    California          29,760,021        33,871,648      4,111,627      13.8 %
//    Illinois            11,430,602        12,419,293        988,691       8.6 %
//    Washington           4,866,692         5,894,121      1,027,429      21.1 %
// </Snippet1>