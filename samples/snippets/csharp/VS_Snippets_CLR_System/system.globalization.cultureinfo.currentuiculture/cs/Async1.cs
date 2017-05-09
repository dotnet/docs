// <Snippet14>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

[assembly:TargetFramework(".NETFramework,Version=v4.6")]

public class Example
{
   public static void Main()
   {
      var tasks = new List<Task>();
      Console.WriteLine("The current UI culture is {0}", 
                        Thread.CurrentThread.CurrentUICulture.Name);
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
      // Change the current UI culture to Portuguese (Brazil).
      Console.WriteLine("Current UI culture changed to {0}",
                        Thread.CurrentThread.CurrentUICulture.Name);
      Console.WriteLine("Application thread is thread {0}",
                        Thread.CurrentThread.ManagedThreadId);
      // Launch six tasks and display their current culture.
      for (int ctr = 0; ctr <= 5; ctr++)
         tasks.Add(Task.Run( () => {
                               Console.WriteLine("UI Culture of task {0} on thread {1} is {2}",
                                                 Task.CurrentId, 
                                                 Thread.CurrentThread.ManagedThreadId,
                                                 Thread.CurrentThread.CurrentUICulture.Name);
                            } ));                     

      Task.WaitAll(tasks.ToArray());
   }
}
// The example displays output like the following:
//     The current culture is en-US
//     Current culture changed to pt-BR
//     Application thread is thread 9
//     Culture of task 2 on thread 11 is pt-BR
//     Culture of task 1 on thread 10 is pt-BR
//     Culture of task 3 on thread 11 is pt-BR
//     Culture of task 5 on thread 11 is pt-BR
//     Culture of task 6 on thread 11 is pt-BR
//     Culture of task 4 on thread 10 is pt-BR
// </Snippet14>

