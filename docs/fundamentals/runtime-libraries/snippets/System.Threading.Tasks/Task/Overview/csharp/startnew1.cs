// <Snippet7>
using System;
using System.Threading.Tasks;

public class Example2
{
    public static void Main()
    {
        Task t = Task.Factory.StartNew(() =>
        {
            // Just loop.
            int ctr = 0;
            for (ctr = 0; ctr <= 1000000; ctr++)
            { }
            Console.WriteLine($"Finished {ctr} loop iterations");
        });
        t.Wait();
    }
}
// The example displays the following output:
//        Finished 1000001 loop iterations
// </Snippet7>
