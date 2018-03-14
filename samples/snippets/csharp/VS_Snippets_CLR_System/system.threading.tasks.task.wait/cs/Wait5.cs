// <Snippet5>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Task t = Task.Run( () => {
                            Random rnd = new Random();
                            long sum = 0;
                            int n = 5000000;
                            for (int ctr = 1; ctr <= n; ctr++) {
                               int number = rnd.Next(0, 101);
                               sum += number;
                            }
                            Console.WriteLine("Total:   {0:N0}", sum);
                            Console.WriteLine("Mean:    {0:N2}", sum/n);
                            Console.WriteLine("N:       {0:N0}", n);   
                         } );
     if (! t.Wait(150))
        Console.WriteLine("The timeout interval elapsed.");
   }
}
// The example displays output similar to the following:
//       Total:   50,015,714
//       Mean:    50.02
//       N:       1,000,000
// Or it displays the following output:
//      The timeout interval elapsed.
// </Snippet5>


