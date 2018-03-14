// Example for Task.Run(Action) method.

// <Snippet1>
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var list = new ConcurrentBag<string>();
      string[] dirNames = { ".", ".." };
      List<Task> tasks = new List<Task>();
      foreach (var dirName in dirNames) {
         Task t = Task.Run( () => { foreach(var path in Directory.GetFiles(dirName)) 
                                       list.Add(path); }  );
         tasks.Add(t);
      }
      Task.WaitAll(tasks.ToArray());
      foreach (Task t in tasks)
         Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);
         
      Console.WriteLine("Number of files read: {0}", list.Count);
   }
}
// The example displays output like the following:
//       Task 1 Status: RanToCompletion
//       Task 2 Status: RanToCompletion
//       Number of files read: 23
// </Snippet1>
