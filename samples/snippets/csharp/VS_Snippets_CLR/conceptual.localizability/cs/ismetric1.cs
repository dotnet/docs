// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "ne-NP", "es-BO", "ig-NG" };
      foreach (var cultureName in cultureNames) {
         RegionInfo region = new RegionInfo(cultureName);
         Console.WriteLine($"{region.EnglishName} {region.IsMetric ? "uses" : "does not use"} the metric system.");
      }
   }
}
// The example displays the following output:
//       United States does not use the metric system.
//       United Kingdom uses the metric system.
//       France uses the metric system.
//       Nepal uses the metric system.
//       Bolivia uses the metric system.
//       Nigeria uses the metric system.
// </Snippet1>
