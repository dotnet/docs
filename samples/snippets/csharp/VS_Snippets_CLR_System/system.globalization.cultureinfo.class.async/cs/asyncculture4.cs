// <Snippet4>
using System;
using System.Globalization;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

[assembly:TargetFramework(".NETFramework,Version=v4.6")]

public class Example
{
   public static void Main()
   {
       string formatString = "C2";
       Console.WriteLine("The example is running on thread {0}",
                         Thread.CurrentThread.ManagedThreadId);
       // Make the current culture different from the system culture.
       Console.WriteLine("The current culture is {0}",
                         CultureInfo.CurrentCulture.Name);
       if (CultureInfo.CurrentCulture.Name == "fr-FR")
          Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
       else
          Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

       Console.WriteLine("Changed the current culture to {0}.\n",
                         CultureInfo.CurrentCulture.Name);

       // Call an async delegate to format the values using one format string.
       Console.WriteLine("Executing a task asynchronously in the main appdomain:");
       var t1 = Task.Run(() => { DataRetriever d = new DataRetriever();
                                 return d.GetFormattedNumber(formatString);
                               });
       Console.WriteLine(t1.Result);
       Console.WriteLine();

       Console.WriteLine("Executing a task synchronously in two appdomains:");
       var t2 = Task.Run(() => { Console.WriteLine("Thread {0} is running in app domain '{1}'",
                                                   Thread.CurrentThread.ManagedThreadId,
                                                   AppDomain.CurrentDomain.FriendlyName);
                                 AppDomain domain = AppDomain.CreateDomain("Domain2");
                                 DataRetriever d = (DataRetriever) domain.CreateInstanceAndUnwrap(typeof(Example).Assembly.FullName,
                                                   "DataRetriever");
                                 return d.GetFormattedNumber(formatString);
                               });
       Console.WriteLine(t2.Result);
   }
}

public class DataRetriever : MarshalByRefObject
{
   public string GetFormattedNumber(String format)
   {
      Thread thread = Thread.CurrentThread;
      Console.WriteLine("Current culture is {0}", thread.CurrentCulture);
      Console.WriteLine("Thread {0} is running in app domain '{1}'",
                        thread.ManagedThreadId,
                        AppDomain.CurrentDomain.FriendlyName);
      Random rnd = new Random();
      Double value = rnd.NextDouble() * 1000;
      return value.ToString(format);
   }
}
// The example displays output like the following:
//     The example is running on thread 1
//     The current culture is en-US
//     Changed the current culture to fr-FR.
//
//     Executing a task asynchronously in a single appdomain:
//     Current culture is fr-FR
//     Thread 3 is running in app domain 'AsyncCulture4.exe'
//     93,48 €
//
//     Executing a task synchronously in two appdomains:
//     Thread 4 is running in app domain 'AsyncCulture4.exe'
//     Current culture is fr-FR
//     Thread 4 is running in app domain 'Domain2'
//     288,66 €
// </Snippet4>
