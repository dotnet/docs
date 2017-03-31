// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   static Random rnd = new Random();
   
   public static void Main()
   {
      if (Thread.CurrentThread.CurrentCulture.Name != "fr-FR") {
         // If current culture is not fr-FR, set culture to fr-FR.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
         Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
      }   
      else {
         // Set culture to en-US.
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
         Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
      }
      DisplayThreadInfo();
      DisplayValues();
          
       Thread worker = new Thread(Example.ThreadProc);
       worker.Name = "WorkerThread";
       worker.Start(Thread.CurrentThread.CurrentCulture);
   }
   
   private static void DisplayThreadInfo()
   {
      Console.WriteLine("\nCurrent Thread Name: '{0}'", 
                        Thread.CurrentThread.Name);
      Console.WriteLine("Current Thread Culture/UI Culture: {0}/{1}", 
                        Thread.CurrentThread.CurrentCulture.Name,
                        Thread.CurrentThread.CurrentUICulture.Name);                        
   }
   
   private static void DisplayValues()
   {
      // Create new thread and display three random numbers.
      Console.WriteLine("Some currency values:");
      for (int ctr = 0; ctr <= 3; ctr++)
         Console.WriteLine("   {0:C2}", rnd.NextDouble() * 10);                        
   }
   
   private static void ThreadProc(Object obj) 
   {
      Thread.CurrentThread.CurrentCulture = (CultureInfo) obj;
      Thread.CurrentThread.CurrentUICulture = (CultureInfo) obj;
      DisplayThreadInfo();
      DisplayValues();
   }
}
// The example displays output similar to the following:
//       Current Thread Name: ''
//       Current Thread Culture/UI Culture: fr-FR/fr-FR
//       Some currency values:
//          6,83 €
//          3,47 €
//          6,07 €
//          1,70 €
//       
//       Current Thread Name: 'WorkerThread'
//       Current Thread Culture/UI Culture: fr-FR/fr-FR
//       Some currency values:
//          9,54 €
//          9,50 €
//          0,58 €
//          6,91 €
// </Snippet2>
