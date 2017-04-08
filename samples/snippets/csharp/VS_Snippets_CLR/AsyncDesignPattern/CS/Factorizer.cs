// <Snippet6>
using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    // Create a class that factors a number.
    public class PrimeFactorFinder
    {
       public static bool Factorize(
                    int number,
                    ref int primefactor1,
                    ref int primefactor2)
       {
          primefactor1 = 1;
          primefactor2 = number;

          // Factorize using a low-tech approach.
          for (int i=2;i<number;i++)
          {
             if (0 == (number % i))
             {
                primefactor1 = i;
                primefactor2 = number / i;
                break;
             }
          }
          if (1 == primefactor1 )
             return false;
          else
             return true   ;
       }
    }

    // Create an asynchronous delegate that matches the Factorize method.
    public delegate bool AsyncFactorCaller (
             int number, 
             ref int primefactor1,
             ref int primefactor2);

    public class DemonstrateAsyncPattern
    {
        // The waiter object used to keep the main application thread
        // from terminating before the callback method completes.
        ManualResetEvent waiter;
        
        // Define the method that receives a callback when the results are available.
        public void FactorizedResults(IAsyncResult result)
           {
              int factor1=0;
              int factor2=0; 
        
              // Extract the delegate from the 
              // System.Runtime.Remoting.Messaging.AsyncResult.
              AsyncFactorCaller factorDelegate = (AsyncFactorCaller)((AsyncResult)result).AsyncDelegate;
              int number = (int) result.AsyncState;
              // Obtain the result.
              bool answer = factorDelegate.EndInvoke(ref factor1, ref factor2, result);
              // Output the results.
              Console.WriteLine("On CallBack: Factors of {0} : {1} {2} - {3}", 
                  number, factor1, factor2, answer);
              waiter.Set();
           }

       // The following method demonstrates the asynchronous pattern using a callback method.
       public void FactorizeNumberUsingCallback()
       {
          AsyncFactorCaller factorDelegate = new AsyncFactorCaller (PrimeFactorFinder.Factorize);
          int number = 1000589023;
          int temp=0; 
          // Waiter will keep the main application thread from 
          // ending before the callback completes because
          // the main thread blocks until the waiter is signaled
          // in the callback.
           waiter = new ManualResetEvent(false);

          // Define the AsyncCallback delegate.
          AsyncCallback callBack = new AsyncCallback(this.FactorizedResults);

          // Asynchronously invoke the Factorize method.
          IAsyncResult result = factorDelegate.BeginInvoke(
                               number, 
                               ref temp, 
                               ref temp, 
                               callBack, 
                               number); 

          // Do some other useful work while 
          // waiting for the asynchronous operation to complete.

          // When no more work can be done, wait.
          waiter.WaitOne();
       }

       // The following method demonstrates the asynchronous pattern 
       // using a BeginInvoke, followed by waiting with a time-out.
       public void FactorizeNumberAndWait()
       {
          AsyncFactorCaller factorDelegate = new AsyncFactorCaller (PrimeFactorFinder.Factorize);

          int number = 1000589023;
          int temp=0; 

          // Asynchronously invoke the Factorize method.
          IAsyncResult result = factorDelegate.BeginInvoke(
                            number, 
                            ref temp, 
                            ref temp, 
                            null, 
                            null); 
                            
          while (!result.IsCompleted)
          {
            // Do any work you can do before waiting.
            result.AsyncWaitHandle.WaitOne(10000, false);
          }
          result.AsyncWaitHandle.Close();

          // The asynchronous operation has completed.
          int factor1=0;
          int factor2=0; 

         // Obtain the result.
         bool answer = factorDelegate.EndInvoke(ref factor1, ref factor2, result);

         // Output the results.
         Console.WriteLine("Sequential : Factors of {0} : {1} {2} - {3}", 
                           number, factor1, factor2, answer);
       }

       public static void Main()
       {
          DemonstrateAsyncPattern demonstrator = new DemonstrateAsyncPattern();
          demonstrator.FactorizeNumberUsingCallback();
          demonstrator.FactorizeNumberAndWait();
       }
    }
}
// </Snippet6>

