// <Snippet2>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var task1 = Task.Factory.StartNew(() => {
                     var child1 = Task.Factory.StartNew(() => {
                        var child2 = Task.Factory.StartNew(() => {
                            // This exception is nested inside three AggregateExceptions.
                            throw new CustomException("Attached child2 faulted.");
                        }, TaskCreationOptions.AttachedToParent);

                        // This exception is nested inside two AggregateExceptions.
                        throw new CustomException("Attached child1 faulted.");
                     }, TaskCreationOptions.AttachedToParent);
      });

      try {
         task1.Wait();
      }
      catch (AggregateException ae) {
         foreach (var e in ae.Flatten().InnerExceptions) {
            if (e is CustomException) {
               Console.WriteLine(e.Message);
            }
            else {
               throw;
            }
         }
      }
   }
}

public class CustomException : Exception
{
   public CustomException(String message) : base(message)
   {}
}
// The example displays the following output:
//    Attached child1 faulted.
//    Attached child2 faulted.
// </Snippet2>
