// <Snippet4>
using System;
using System.Threading;
using System.Threading.Tasks;

class Example
{
   static void Main()
   {
      var outer = Task<int>.Factory.StartNew(() => {
            Console.WriteLine("Outer task executing.");

            var nested = Task<int>.Factory.StartNew(() => {
                  Console.WriteLine("Nested task starting.");
                  Thread.SpinWait(5000000);
                  Console.WriteLine("Nested task completing.");
                  return 42;
            });

            // Parent will wait for this detached child.
            return nested.Result;
      });

      Console.WriteLine($"Outer has returned {outer.Result}.");
   }
}
// The example displays the following output:
//       Outer task executing.
//       Nested task starting.
//       Nested task completing.
//       Outer has returned 42.
// </Snippet4>

public class Extra
{
     //<snippet5> //not used yet
     static void AttachedChildCancels()
     {
         var tokenSource = new CancellationTokenSource();

         Task.Factory.StartNew(() =>
         {
             Console.WriteLine("Press c to cancel");
             if (Console.ReadKey().KeyChar == 'c')
                 tokenSource.Cancel();
         });

         var parent = Task<int>.Factory.StartNew(() =>
         {
             Console.WriteLine("Parent task starting.");
             var ct = tokenSource.Token;
             //  tokenSource.Cancel();
             var child = Task<int>.Factory.StartNew(() =>
             {
                 Console.WriteLine("Attached child starting.");
                 //  ct.ThrowIfCancellationRequested();
                 //  Thread.SpinWait(500000000);
                 for (int i = 0; i < 10000; i++)
                 {
                     Thread.SpinWait(50000);
                     if (ct.IsCancellationRequested)
                     {
                         Console.WriteLine("Request noticed in attached child");
                         ct.ThrowIfCancellationRequested();
                     }
                 }
                 Console.WriteLine("Attached child completing.");
                 return 42;
             }, ct);

             Console.WriteLine($"child.Result = {child.Result}");
             return child.Result;
         }, tokenSource.Token);

         //try
         //{
         //    Console.WriteLine("About to wait");
         //    parent.Wait();

         //}
         //catch (AggregateException ae)
         //{
         //    Console.WriteLine("Exception caught");
         //    foreach (var v in ae.Flatten().InnerExceptions)
         //        Console.WriteLine(v.GetType().Name);
         //}
         tokenSource.Dispose();

         Console.WriteLine("Parent has returned.");
     }

     /* Sample output:
         Parent task executing.
         Detached child starting.
         Detached child completing.
         Parent has completed.
      */
     //</snippet5>

     static void ChildTaskException()
     {
         var parent = new Task(() =>
         {
             Console.WriteLine("Parent task executing.");

             //var child1 = Task.Factory.StartNew(() =>
             //    {
             //        Thread.SpinWait(5000000);
             //        Console.WriteLine("Attached child running.");
             //        throw new InvalidOperationException("attached child faulted.");
             //    });

             var child2 = Task.Factory.StartNew(() =>
             {
                 Thread.SpinWait(70000000);
                 Console.WriteLine("Detached child running.");
                 throw new InvalidOperationException("detached child faulted.");
             });

             try
             {
                 child2.Wait();
             }
             catch (AggregateException ae)
             {
                 throw ae.InnerException;
             }
         });

         parent.Start();

         try
         {
             parent.Wait();
         }
         catch (AggregateException ae)
         {
             // Flatten the exception to avoid having to iterate
             // nested AggregateExceptions.
             foreach (var v in ae.Flatten().InnerExceptions)
             {
                 Console.WriteLine(v.Message);
             }
         }
     }

     static void ChildReturns()
     {

         var parent = new Task<int>(() =>
         {
             Console.WriteLine("Parent task executing.");

             var child1 = Task<int>.Factory.StartNew(() =>
             {
                 Thread.SpinWait(5000000);
                 Console.WriteLine("Attached child running.");
                 return 5;
             });

             //var child2 = Task.Factory.StartNew(() =>
             //{
             //    Thread.SpinWait(70000000);
             //    Console.WriteLine("Detached child running.");
             //    throw new InvalidOperationException("detached child faulted.");
             //});

             return child1.Result;
         });

         parent.Start();

         Console.WriteLine(parent.Result);
     }
 }
