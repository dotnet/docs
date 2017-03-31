using System;

public class Example
{
   public static void Main()
   {
    Ctor1();
    Factory();
   }

   private static void Ctor1()
   {
      // <Snippet1>
      // Create a 7-tuple.
      var population = new Tuple<string, int, int, int, int, int, int>(
                                 "New York", 7891957, 7781984, 
                                 7894862, 7071639, 7322564, 8008278);
      // Display the first and last elements.
      Console.WriteLine("Population of {0} in 2000: {1:N0}",
                        population.Item1, population.Item7);
      // The example displays the following output:
      //       Population of New York in 2000: 8,008,278
      // </Snippet1>
   }

   private static void Factory()
   {
      // <Snippet2>
      // Create a 7-tuple.
      var population = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
      // Display the first and last elements.
      Console.WriteLine("Population of {0} in 2000: {1:N0}",
                        population.Item1, population.Item7);
      // The example displays the following output:
      //       Population of New York in 2000: 8,008,278
      // </Snippet2>
   }
}
