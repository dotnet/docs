// <Snippet4>
using System;
using System.IO;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = Task.Run( () => { string s = File.ReadAllText(@"C:\NonexistentFile.txt");
                                return s;
                              });

      var c = t.ContinueWith( (antecedent) =>
                              { // Get the antecedent's exception information.
                                foreach (var ex in antecedent.Exception.InnerExceptions) {
                                   if (ex is FileNotFoundException)
                                      Console.WriteLine(ex.Message);
                                }
                              }, TaskContinuationOptions.OnlyOnFaulted);

      c.Wait();
   }
}
// The example displays the following output:
//        Could not find file 'C:\NonexistentFile.txt'.
// </Snippet4>

public class Example2
{
   public static void ShowTaskException()
   {
      var t = Task.Run( () => { string s = File.ReadAllText(@"C:\NonexistentFile.txt");
                                return s;
                              });

      var c = t.ContinueWith( (antecedent) =>
                              { // Accessing Exception property catches the exception.
                                // Exception should not be null if OnlyOnFaulted.
                                // <Snippet11>
                                // Determine whether an exception occurred.
                                if (antecedent.Exception != null) {
                                   foreach (var ex in antecedent.Exception.InnerExceptions) {
                                      if (ex is FileNotFoundException)
                                         Console.WriteLine(ex.Message);
                                   }
                                }
                                // </Snippet11>
                              } );

   }
}