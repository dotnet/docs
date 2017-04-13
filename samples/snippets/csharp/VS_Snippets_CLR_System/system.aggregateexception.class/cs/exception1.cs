// <Snippet1>
using System;
using System.IO;
using System.Threading.Tasks;

class Example
{
   static void Main(string[] args)
   {
      // Get a folder path whose directories should throw an UnauthorizedAccessException.
      string path = Directory.GetParent(
                              Environment.GetFolderPath(
                              Environment.SpecialFolder.UserProfile)).FullName;

      // Use this line to throw UnauthorizedAccessException, which we handle.
      Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));

      // Use this line to throw an exception that is not handled.
      // Task task1 = Task.Factory.StartNew(() => { throw new IndexOutOfRangeException(); } );
      try {
          task1.Wait();
      }
      catch (AggregateException ae) {
          ae.Handle((x) =>
          {
              if (x is UnauthorizedAccessException) // This we know how to handle.
              {
                  Console.WriteLine("You do not have permission to access all folders in this path.");
                  Console.WriteLine("See your network administrator or try another path.");
                  return true;
              }
              return false; // Let anything else stop the application.
          });
      }

      Console.WriteLine("task1 Status: {0}{1}", task1.IsCompleted ? "Completed," : "", 
                                                task1.Status);
   }
 
   static string[] GetAllFiles(string str)
   {
      // Should throw an UnauthorizedAccessException exception.
      return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories);
   }
}
// The example displays the following output if the file access task is run:
//       You do not have permission to access all folders in this path.
//       See your network administrator or try another path.
//       task1 Status: Completed,Faulted
// It displays the following output if the second task is run:
//       Unhandled Exception: System.AggregateException: One or more errors occurred. ---
//       > System.IndexOutOfRangeException: Index was outside the bounds of the array.
//          at Example.<Main>b__0()
//          at System.Threading.Tasks.Task.Execute()
//          --- End of inner exception stack trace ---
//          at System.AggregateException.Handle(Func`2 predicate)
//          at Example.Main(String[] args)
// </Snippet1>





