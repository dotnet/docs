// <snippet12>
using System;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        HandleExceptions();
        // RethrowAllExceptions();
        Console.Write("Press any key.");
        Console.ReadKey();
    }

    static string[] GetAllFiles(string str)
    {
       // Should throw an AccessDenied exception on Vista.
       return System.IO.Directory.GetFiles(str, "*.txt",
                                           System.IO.SearchOption.AllDirectories);
   }

   static void HandleExceptions()
   {
       // Assume this is a user-entered string.
       string path = @"C:\";

       // Use this line to throw UnauthorizedAccessException, which we handle.
       Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));

       // Use this line to throw an exception that is not handled.
       //  Task task1 = Task.Factory.StartNew(() => { throw new IndexOutOfRangeException(); } );
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

      Console.WriteLine("task1 has completed.");
   }
}
// </snippet12>
