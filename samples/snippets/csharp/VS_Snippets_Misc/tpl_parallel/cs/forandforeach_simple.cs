namespace ThreadLocalFor
{
//<snippet05>
 using System;
 using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;

 class Test
 {
     static void Main()
     {
         int[] nums = Enumerable.Range(0, 1_000_000).ToArray();
         long total = 0;

         // Use type parameter to make subtotal a long, not an int
         Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
         {
             subtotal += nums[j];
             return subtotal;
         },
             subtotal => Interlocked.Add(ref total, subtotal)
         );

         Console.WriteLine("The total is {0:N0}", total);
         Console.WriteLine("Press any key to exit");
         Console.ReadKey();
     }
 }
//</snippet05>
}

namespace NotInUse
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class FromSnippet1
    {
        static void MultiplyMatrixScalar(int cols, double[,] matrix, double scalar)
        {
            // Parallelize the outer loop to partition the source array by rows.
            int rowCount = matrix.Length / cols;
            Parallel.For(0, rowCount, i =>
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= scalar;
                }
            });
        }

        static void ComputeHeron(double x, int precision)
        {
            Random rand = new Random();

            double r = rand.Next(1, (int)x);
            double f = (double)1 / precision;
            while (true)
            {
                r = (r + x / r) / 2;

                Console.WriteLine((double)r);
                if ((double)(r - (double)(x / r)) < f)
                    break;
            }
            int places = (from c in precision.ToString().ToCharArray()
                          where c == '0'
                          select c).Count();
            Console.WriteLine("The square root of {0} to {1} places is {2}", x, places, r);
        }
    }
}
