// <Snippet1>
using System;
using System.Globalization;
using System.Text;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Console.OutputEncoding = Encoding.UTF8; 
      // Change current culture
      CultureInfo culture;
      if (Thread.CurrentThread.CurrentCulture.Name == "fr-FR")
         culture = CultureInfo.CreateSpecificCulture("en-US");
      else
         culture = CultureInfo.CreateSpecificCulture("fr-FR");

      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      
      // Generate and display three random numbers on the current thread.
      DisplayRandomNumbers();
      Thread.Sleep(1000);
      
      Thread workerThread = new Thread(new ThreadStart(Example.DisplayRandomNumbers));
      workerThread.Start();
   }

   private static void DisplayRandomNumbers()
   {
      Console.WriteLine();
      Console.WriteLine("Current Culture:    {0}", 
                        Thread.CurrentThread.CurrentCulture);
      Console.WriteLine("Current UI Culture: {0}", 
                        Thread.CurrentThread.CurrentUICulture);

      Console.Write("Random Values: ");
      Random rand = new Random();
      for (int ctr = 0; ctr <= 2; ctr++)
         Console.Write("     {0:C2}     ", rand.NextDouble());

      Console.WriteLine();
   }
}
// The example displays output similar to the following:
//    Current Culture:    fr-FR
//    Current UI Culture: fr-FR
//    Random Values:      0,77 €          0,35 €          0,52 €     
//    
//    Current Culture:    en-US
//    Current UI Culture: en-US
//    Random Values:      $0.30          $0.79          $0.65     
// </Snippet1>
