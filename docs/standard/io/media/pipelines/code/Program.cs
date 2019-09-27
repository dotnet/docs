using System;
using System.Collections.Concurrent;
using System.IO.Pipes;
using System.Threading;

namespace Pipes
{
    class Program
    {
        #region snippet
        public static void Main(string[] args)
        {
            var writeScheduler = new SingleThreadPipeScheduler();
            var readScheduler = new SingleThreadPipeScheduler();

            // Tell the Pipe what schedulers to use
            // and disable the SynchronizationContext .
            var options = new PipeOptions(readerScheduler: readScheduler, writerScheduler: writeScheduler, useSynchronizationContext: false);
            var pipe = new Pipe(options);
        }

        // This is a sample scheduler that async callbacks on a single dedicated thread.
        public class SingleThreadPipeScheduler : PipeScheduler
        {
            private readonly BlockingCollection<(Action<object> Action, object State)> _queue = new BlockingCollection<(Action<object> Action, object State)>();
            private readonly Thread _thread;

            public SingleThreadPipeScheduler()
            {
                _thread = new Thread(DoWork);
                _thread.Start();
            }

            private void DoWork()
            {
                foreach (var item in _queue.GetConsumingEnumerable())
                {
                    item.Action(item.State);
                }
            }

            public override void Schedule(Action<object> action, object state)
            {
                _queue.Add((action, state));
            }
        }
        #endregion
    }
}
