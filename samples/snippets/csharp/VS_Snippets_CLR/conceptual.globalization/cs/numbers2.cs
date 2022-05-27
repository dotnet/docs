// <Snippet6>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

public class Example15
{
   public static void Main15()
   {
      // Create ten random doubles.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      double[] numbers = GetRandomNumbers(10);
      DisplayRandomNumbers(numbers);

      // Persist the numbers as strings.
      StreamWriter sw = new StreamWriter("randoms.dat");
      for (int ctr = 0; ctr < numbers.Length; ctr++)
         sw.Write("{0:R}{1}", numbers[ctr], ctr < numbers.Length - 1 ? "|" : "");

      sw.Close();

      // Read the persisted data.
      StreamReader sr = new StreamReader("randoms.dat");
      string numericData = sr.ReadToEnd();
      sr.Close();
      string[] numberStrings = numericData.Split('|');

      // Restore and display the data using the conventions of the en-US culture.
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      foreach (var numberStr in numberStrings) {
         double restoredNumber;
         if (Double.TryParse(numberStr, out restoredNumber))
            Console.WriteLine(restoredNumber.ToString("R"));
         else
            Console.WriteLine("ERROR: Unable to parse '{0}'", numberStr);
      }
      Console.WriteLine();

      // Restore and display the data using the conventions of the fr-FR culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      foreach (var numberStr in numberStrings) {
         double restoredNumber;
         if (Double.TryParse(numberStr, out restoredNumber))
            Console.WriteLine(restoredNumber.ToString("R"));
         else
            Console.WriteLine("ERROR: Unable to parse '{0}'", numberStr);
      }
   }

   private static double[] GetRandomNumbers(int n)
   {
      Random rnd = new Random();
      double[] numbers = new double[n];
      for (int ctr = 0; ctr < n; ctr++)
         numbers[ctr] = rnd.NextDouble() * 1000;
      return numbers;
   }

   private static void DisplayRandomNumbers(double[] numbers)
   {
      for (int ctr = 0; ctr < numbers.Length; ctr++)
         Console.WriteLine(numbers[ctr].ToString("R"));
      Console.WriteLine();
   }
}
// The example displays output like the following:
//       487.0313743534644
//       674.12000879371533
//       498.72077885024288
//       42.3034229512808
//       970.57311049223563
//       531.33717716268131
//       587.82905693530529
//       562.25210175023039
//       600.7711019370571
//       299.46113717717174
//
//       Current Culture: English (United States)
//       487.0313743534644
//       674.12000879371533
//       498.72077885024288
//       42.3034229512808
//       970.57311049223563
//       531.33717716268131
//       587.82905693530529
//       562.25210175023039
//       600.7711019370571
//       299.46113717717174
//
//       Current Culture: French (France)
//       ERROR: Unable to parse '487.0313743534644'
//       ERROR: Unable to parse '674.12000879371533'
//       ERROR: Unable to parse '498.72077885024288'
//       ERROR: Unable to parse '42.3034229512808'
//       ERROR: Unable to parse '970.57311049223563'
//       ERROR: Unable to parse '531.33717716268131'
//       ERROR: Unable to parse '587.82905693530529'
//       ERROR: Unable to parse '562.25210175023039'
//       ERROR: Unable to parse '600.7711019370571'
//       ERROR: Unable to parse '299.46113717717174'
// </Snippet6>
