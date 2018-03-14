
// <Snippet27>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var task1 = Task.Run(() =>
                           { throw new CustomException("task1 faulted.");
      }).ContinueWith( t => { Console.WriteLine("{0}: {1}",
                                                t.Exception.InnerException.GetType().Name,
                                                t.Exception.InnerException.Message);
                            }, TaskContinuationOptions.OnlyOnFaulted);
      Thread.Sleep(500);
   }
}

public class CustomException : Exception
{
   public CustomException(String message) : base(message)
   {}
}
// The example displays output like the following:
//        CustomException: task1 faulted.
// </Snippet27>
