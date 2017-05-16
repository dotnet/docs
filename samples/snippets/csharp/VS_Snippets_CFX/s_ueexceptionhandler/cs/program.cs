// Snippet for S_UE System.ServiceModel.Dispatcher.ExceptionHandler.HandleException
// 06192006 Created by A.Hu

// <snippet0>
using System;
using System.ServiceModel.Dispatcher;

namespace CS
{
    public class MyExceptionHandler: ExceptionHandler
    {
            // HandleException method override gives control to 
            // your code.
            public override bool HandleException ( Exception ex )
            {
                // This method contains logic to decide whether 
                // the exception is serious enough
                // to terminate the process.
                return ShouldTerminateProcess (ex);
            }

            public bool ShouldTerminateProcess (Exception ex)
            {
                // Write your logic here.
                return  true;
            }
    } 
  
// </snippet0>
    class Program
    {
// <snippet1>
        static void Main(string[] args)
        {
            // Create an instance of the MyExceptionHander class.
            MyExceptionHandler thisExceptionHandler =
                new MyExceptionHandler();

            // Enable the custom handler by setting 
            //   AsynchronousThreadExceptionHandler property
            //   to this object.
            ExceptionHandler.AsynchronousThreadExceptionHandler = 
                thisExceptionHandler;

            // After the handler is set, write your call to 
            // System.ServiceModel.ICommunication.Open here
        }
    }
// </snippet1>
}
