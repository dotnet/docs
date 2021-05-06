using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace keywords
{
    class AsyncExceptionExamples
    {
        // try-catch (C# Reference)
        public static async Task Examples()
        {
            var examples = new AsyncExceptionExamples();
            await examples.DoSomethingAsync();
            await examples.DoMultipleAsync();
        }

        // Snippet1 in VB is equivalent to Snippet2 in C#.

        //<Snippet2>
        public async Task DoSomethingAsync()
        {
            Task<string> theTask = DelayAsync();

            try
            {
                string result = await theTask;
                Debug.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
            }
            Debug.WriteLine("Task IsCanceled: " + theTask.IsCanceled);
            Debug.WriteLine("Task IsFaulted:  " + theTask.IsFaulted);
            if (theTask.Exception != null)
            {
                Debug.WriteLine("Task Exception Message: "
                    + theTask.Exception.Message);
                Debug.WriteLine("Task Inner Exception Message: "
                    + theTask.Exception.InnerException.Message);
            }
        }

        private async Task<string> DelayAsync()
        {
            await Task.Delay(100);

            // Uncomment each of the following lines to
            // demonstrate exception handling.

            //throw new OperationCanceledException("canceled");
            //throw new Exception("Something happened.");
            return "Done";
        }

        // Output when no exception is thrown in the awaited method:
        //   Result: Done
        //   Task IsCanceled: False
        //   Task IsFaulted:  False

        // Output when an Exception is thrown in the awaited method:
        //   Exception Message: Something happened.
        //   Task IsCanceled: False
        //   Task IsFaulted:  True
        //   Task Exception Message: One or more errors occurred.
        //   Task Inner Exception Message: Something happened.

        // Output when a OperationCanceledException or TaskCanceledException
        // is thrown in the awaited method:
        //   Exception Message: canceled
        //   Task IsCanceled: True
        //   Task IsFaulted:  False
        //</Snippet2>

        // Snippet3 in VB is equivalent to Snippet4 in C#.

        //<Snippet4>
        public async Task DoMultipleAsync()
        {
            Task theTask1 = ExcAsync(info: "First Task");
            Task theTask2 = ExcAsync(info: "Second Task");
            Task theTask3 = ExcAsync(info: "Third Task");

            Task allTasks = Task.WhenAll(theTask1, theTask2, theTask3);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                Debug.WriteLine("Task IsFaulted: " + allTasks.IsFaulted);
                foreach (var inEx in allTasks.Exception.InnerExceptions)
                {
                    Debug.WriteLine("Task Inner Exception: " + inEx.Message);
                }
            }
        }

        private async Task ExcAsync(string info)
        {
            await Task.Delay(100);

            throw new Exception("Error-" + info);
        }

        // Output:
        //   Exception: Error-First Task
        //   Task IsFaulted: True
        //   Task Inner Exception: Error-First Task
        //   Task Inner Exception: Error-Second Task
        //   Task Inner Exception: Error-Third Task
        //</Snippet4>
    }
}
