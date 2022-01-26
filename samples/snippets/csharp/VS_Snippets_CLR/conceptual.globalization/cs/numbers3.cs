// <Snippet7>
using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

public class Example16
{
   public static void Main16()
   {
      // Create ten random doubles.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      double[] numbers = GetRandomNumbers(10);
      DisplayRandomNumbers(numbers);

      // Serialize the array.
      FileStream fsIn = new FileStream("randoms.dat", FileMode.Create);
      BinaryFormatter formatter = new BinaryFormatter();
      formatter.Serialize(fsIn, numbers);
      fsIn.Close();

      // Read the persisted data.
      FileStream fsOut = new FileStream("randoms.dat", FileMode.Open);
      double[] numbers1 = (Double[]) formatter.Deserialize(fsOut);
      fsOut.Close();

      // Display the data using the conventions of the en-US culture.
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      DisplayRandomNumbers(numbers1);

      // Display the data using the conventions of the fr-FR culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      DisplayRandomNumbers(numbers1);
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
//       932.10070623648392
//       96.868112262742642
//       857.111520067375
//       771.37727233179726
//       262.65733840999064
//       387.00796914613244
//       557.49389788019187
//       83.79498919648816
//       957.31006048494487
//       996.54487892824454
//
//       Current Culture: English (United States)
//       932.10070623648392
//       96.868112262742642
//       857.111520067375
//       771.37727233179726
//       262.65733840999064
//       387.00796914613244
//       557.49389788019187
//       83.79498919648816
//       957.31006048494487
//       996.54487892824454
//
//       Current Culture: French (France)
//       932,10070623648392
//       96,868112262742642
//       857,111520067375
//       771,37727233179726
//       262,65733840999064
//       387,00796914613244
//       557,49389788019187
//       83,79498919648816
//       957,31006048494487
//       996,54487892824454
// </Snippet7>
