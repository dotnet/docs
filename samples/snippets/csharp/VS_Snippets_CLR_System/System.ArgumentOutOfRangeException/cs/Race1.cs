// <Snippet11>
using System;
using System.Collections.Generic;
using System.Threading;

public class Continent
{
   public String Name { get; set; }
   public int Population { get; set; }
   public Decimal Area { get; set; }   
}

public class Example
{
   static List<Continent> continents = new List<Continent>();
   static String msg; 
   
   public static void Main()
   {
      String[] names = { "Africa", "Antarctica", "Asia", 
                         "Australia", "Europe", "North America",
                         "South America" };
      // Populate the list.
      foreach (var name in names) {
         var th = new Thread(PopulateContinents);
         th.Start(name);
      }              
      Console.WriteLine(msg);
      Console.WriteLine();

      // Display the list.
      for (int ctr = 0; ctr < names.Length; ctr++) {
         var continent = continents[ctr];
         Console.WriteLine("{0}: Area: {1}, Population {2}", 
                           continent.Name, continent.Population,
                           continent.Area);
      }
   }
   
   private static void PopulateContinents(Object obj)
   {
      String name = obj.ToString();
      msg += String.Format("Adding '{0}' to the list.\n", name);
      var continent = new Continent();
      continent.Name = name;
      // Sleep to simulate retrieving remaining data.
      Thread.Sleep(50);
      continents.Add(continent);
   }
}
// The example displays output like the following:
//    Adding //Africa// to the list.
//    Adding //Antarctica// to the list.
//    Adding //Asia// to the list.
//    Adding //Australia// to the list.
//    Adding //Europe// to the list.
//    Adding //North America// to the list.
//    Adding //South America// to the list.
//    
//    
//    
//    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
//       at Example.Main()
// </Snippet11>
