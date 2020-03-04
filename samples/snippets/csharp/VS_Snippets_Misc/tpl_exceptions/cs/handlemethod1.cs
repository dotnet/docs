// <Snippet6>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var task1 = Task.Run( () => { throw new CustomException("This exception is expected!"); } );

      try {
          task1.Wait();
      }
      catch (AggregateException ae)
      {
         // Call the Handle method to handle the custom exception,
         // otherwise rethrow the exception.
         ae.Handle(ex => { if (ex is CustomException)
                             Console.WriteLine(ex.Message);
                          return ex is CustomException;
                        });
      }
   }
}

public class CustomException : Exception
{
   public CustomException(String message) : base(message)
   {}
}
// The example displays the following output:
//        This exception is expected!
// </Snippet6>
