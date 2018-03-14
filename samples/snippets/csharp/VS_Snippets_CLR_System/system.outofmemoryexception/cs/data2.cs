// <Snippet4>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Tuple<Double, long> result = GetResult();
      Console.WriteLine("Sample mean: {0}, N = {1:N0}",
                        result.Item1, result.Item2);
   }

   private static Tuple<Double, long> GetResult()
   {
      int chunkSize = 50000000;
      int nToGet = 200000000;
      Random rnd = new Random();
      // FileStream fs = new FileStream(@".\data.bin", FileMode.Create);
      // BinaryWriter bin = new BinaryWriter(fs);
      // bin.Write((int)0);
      int n = 0;
      Double sum = 0;
      for (int outer = 0;
           outer <= ((int) Math.Ceiling(nToGet * 1.0 / chunkSize) - 1);
           outer++) {
         for (int inner = 0;
              inner <= Math.Min(nToGet - n - 1, chunkSize - 1);
              inner++) {
            Double value = rnd.NextDouble();
            sum += value;
            n++;
            // bin.Write(value);
         }
      }
      // bin.Seek(0, SeekOrigin.Begin);
      // bin.Write(n);
      // bin.Close();
      return new Tuple<Double, long>(sum/n, n);
   }
}
// The example displays output like the following:
//    Sample mean: 0.500022771458399, N = 200,000,000
// </Snippet4>
