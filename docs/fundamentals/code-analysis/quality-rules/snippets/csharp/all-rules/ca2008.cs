using System.Threading;
using System.Threading.Tasks;

namespace ca2008
{
    //<snippet1>
    public class Example
    {
        public void ProcessData()
        {
            // This code violates the rule.
            var badTask = Task.Factory.StartNew(
                () =>
                {
                    // ...
                }
            );
            badTask.ContinueWith(
                t =>
                {
                    // ...
                }
            );

            // This code satisfies the rule.
            var goodTask = Task.Factory.StartNew(
                () =>
                {
                    // ...
                },
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default
            );
            goodTask.ContinueWith(
                t =>
                {
                    // ...
                },
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default
            );
        }
    }
    //</snippet1>
}
