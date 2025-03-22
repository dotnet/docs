// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class SetThreadsEx
{
    static Random rnd = new Random();

    public static void Main()
    {
        if (Thread.CurrentThread.CurrentCulture.Name != "fr-FR")
        {
            // If current culture is not fr-FR, set culture to fr-FR.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
        }
        else
        {
            // Set culture to en-US.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
        }
        ThreadProc();

        Thread worker = new Thread(SetThreadsEx.ThreadProc);
        worker.Name = "WorkerThread";
        worker.Start();
    }

    private static void DisplayThreadInfo()
    {
        Console.WriteLine($"\nCurrent Thread Name: '{Thread.CurrentThread.Name}'");
        Console.WriteLine($"Current Thread Culture/UI Culture: {Thread.CurrentThread.CurrentCulture.Name}/{Thread.CurrentThread.CurrentUICulture.Name}");
    }

    private static void DisplayValues()
    {
        // Create new thread and display three random numbers.
        Console.WriteLine("Some currency values:");
        for (int ctr = 0; ctr <= 3; ctr++)
            Console.WriteLine($"   {rnd.NextDouble() * 10:C2}");
    }

    private static void ThreadProc()
    {
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
// </Snippet3>
