// <snippet13>
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
public class Example
{
   public static void Main()
   {
	    try {
	        ExecuteTasks();
	    }
	    catch (AggregateException ae) {
	        foreach (var e in ae.InnerExceptions) {
	            Console.WriteLine("{0}:\n   {1}", e.GetType().Name, e.Message);
	        }
	    }
   }

   static void ExecuteTasks()
   {
        // Assume this is a user-entered String.
        String path = @"C:\";
        List<Task> tasks = new List<Task>();

        tasks.Add(Task.Run(() => {
                             // This should throw an UnauthorizedAccessException.
                              return Directory.GetFiles(path, "*.txt",
                                                        SearchOption.AllDirectories);
                           }));

        tasks.Add(Task.Run(() => {
                              if (path == @"C:\")
                                 throw new ArgumentException("The system root is not a valid path.");
                              return new String[] { ".txt", ".dll", ".exe", ".bin", ".dat" };
                           }));

        tasks.Add(Task.Run(() => {
                               throw new NotImplementedException("This operation has not been implemented.");
                           }));

        try {
            Task.WaitAll(tasks.ToArray());
        }
        catch (AggregateException ae) {
            throw ae.Flatten();
        }
    }
}
// The example displays the following output:
//       UnauthorizedAccessException:
//          Access to the path 'C:\Documents and Settings' is denied.
//       ArgumentException:
//          The system root is not a valid path.
//       NotImplementedException:
//          This operation has not been implemented.
// </Snippet13>
