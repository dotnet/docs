﻿// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class DefaultThreadEx
{
    static Random rnd = new Random();

    public static void Main()
    {
        if (Thread.CurrentThread.CurrentCulture.Name != "fr-FR")
        {
            // If current culture is not fr-FR, set culture to fr-FR.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
        }
        else
        {
            // Set culture to en-US.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
        }
        ThreadProc();

        Thread worker = new Thread(ThreadProc);
        worker.Name = "WorkerThread";
        worker.Start();
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
//          8,11 €
//          1,48 €
//          8,99 €
//          9,04 €
//
//       Current Thread Name: 'WorkerThread'
//       Current Thread Culture/UI Culture: en-US/en-US
//       Some currency values:
//          $6.72
//          $6.35
//          $2.90
//          $7.72
// </Snippet1>
