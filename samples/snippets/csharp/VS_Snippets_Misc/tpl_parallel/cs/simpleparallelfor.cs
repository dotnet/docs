
// <snippet01>
 using System;
 using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

 class MultiplyMatrices
 {
     #region Sequential_Loop
     static void MultiplyMatricesSequential(double[,] matA, double[,] matB,
                                             double[,] result)
     {
         int matACols = matA.GetLength(1);
         int matBCols = matB.GetLength(1);
         int matARows = matA.GetLength(0);

         for (int i = 0; i < matARows; i++)
         {
             for (int j = 0; j < matBCols; j++)
             {
                 double temp = 0;
                 for (int k = 0; k < matACols; k++)
                 {
                    temp += matA[i, k] * matB[k, j];
                 }
                 result[i, j] += temp;
             }
         }
     }
     #endregion

     #region Parallel_Loop
     static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
     {
         int matACols = matA.GetLength(1);
         int matBCols = matB.GetLength(1);
         int matARows = matA.GetLength(0);

         // A basic matrix multiplication.
         // Parallelize the outer loop to partition the source array by rows.
         Parallel.For(0, matARows, i =>
         {
             for (int j = 0; j < matBCols; j++)
             {
                 double temp = 0;
                 for (int k = 0; k < matACols; k++)
                 {
                     temp += matA[i, k] * matB[k, j];
                 }
                 result[i, j] = temp;
             }
         }); // Parallel.For
     }
     #endregion

     #region Main
     static void Main(string[] args)
     {
         // Set up matrices. Use small values to better view
         // result matrix. Increase the counts to see greater
         // speedup in the parallel loop vs. the sequential loop.
         int colCount = 180;
         int rowCount = 2000;
         int colCount2 = 270;
         double[,] m1 = InitializeMatrix(rowCount, colCount);
         double[,] m2 = InitializeMatrix(colCount, colCount2);
         double[,] result = new double[rowCount, colCount2];

         // First do the sequential version.
         Console.Error.WriteLine("Executing sequential loop...");
         Stopwatch stopwatch = new Stopwatch();
         stopwatch.Start();

         MultiplyMatricesSequential(m1, m2, result);
         stopwatch.Stop();
         Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
                                 stopwatch.ElapsedMilliseconds);

         // For the skeptics.
         OfferToPrint(rowCount, colCount2, result);

         // Reset timer and results matrix.
         stopwatch.Reset();
         result = new double[rowCount, colCount2];

         // Do the parallel loop.
         Console.Error.WriteLine("Executing parallel loop...");
         stopwatch.Start();
         MultiplyMatricesParallel(m1, m2, result);
         stopwatch.Stop();
         Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
                                 stopwatch.ElapsedMilliseconds);
         OfferToPrint(rowCount, colCount2, result);

         // Keep the console window open in debug mode.
         Console.Error.WriteLine("Press any key to exit.");
         Console.ReadKey();
     }
     #endregion

     #region Helper_Methods
     static double[,] InitializeMatrix(int rows, int cols)
     {
         double[,] matrix = new double[rows, cols];

         Random r = new Random();
         for (int i = 0; i < rows; i++)
         {
             for (int j = 0; j < cols; j++)
             {
                 matrix[i, j] = r.Next(100);
             }
         }
         return matrix;
     }

     private static void OfferToPrint(int rowCount, int colCount, double[,] matrix)
     {
         Console.Error.Write("Computation complete. Print results (y/n)? ");
         char c = Console.ReadKey(true).KeyChar;
         Console.Error.WriteLine(c);
         if (Char.ToUpperInvariant(c) == 'Y')
         {
            if (!Console.IsOutputRedirected &&
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WindowWidth = 180;
            }

             Console.WriteLine();
             for (int x = 0; x < rowCount; x++)
             {
                 Console.WriteLine("ROW {0}: ", x);
                 for (int y = 0; y < colCount; y++)
                 {
                     Console.Write("{0:#.##} ", matrix[x, y]);
                 }
                 Console.WriteLine();
             }
         }
     }
     #endregion
 }
// </snippet01>
