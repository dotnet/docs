using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      DelayAtStart();
      Console.WriteLine("---");
      DelayDuring();
      Console.WriteLine("---");
      DelayDuringLang();
   }

   private static void DelayAtStart()
   {
      // <Snippet5>
      Stopwatch sw = Stopwatch.StartNew();
      var delay = Task.Delay(1000).ContinueWith(_ =>
                                 { sw.Stop();
                                   return sw.ElapsedMilliseconds; } );

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);
      // The example displays output like the following:
      //        Elapsed milliseconds: 1013
      // </Snippet5>
   }

   private static void DelayDuring()
   {
      // <Snippet6>
      var delay = Task.Run( () => { Stopwatch sw = Stopwatch.StartNew();
                                    Task.Delay(2000).Wait();
                                    sw.Stop();
                                    return sw.ElapsedMilliseconds; });

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);
      // The example displays output like the following:
      //        Elapsed milliseconds: 2006
      // </Snippet6>
   }

   private static void DelayDuringLang()
   {
      // <Snippet7>
      var delay = Task.Run( async () => { Stopwatch sw = Stopwatch.StartNew();
                                          await Task.Delay(2500);
                                          sw.Stop();
                                          return sw.ElapsedMilliseconds; });

      Console.WriteLine("Elapsed milliseconds: {0}", delay.Result);
      // The example displays output like the following:
      //        Elapsed milliseconds: 2501
      // </Snippet7>
   }
}
