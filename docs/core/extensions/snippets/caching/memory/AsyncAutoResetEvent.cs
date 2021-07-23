using System.Collections.Generic;
using System.Threading.Tasks;

namespace CachingExamples.Memory
{
    /// <summary>
    /// Inspired by:
    ///   https://devblogs.microsoft.com/pfxteam/building-async-coordination-primitives-part-2-asyncautoresetevent/
    /// </summary>
    public sealed class AsyncAutoResetEvent
    {
        private readonly Queue<TaskCompletionSource<bool>> _completionQueue = new();
        private bool _isSet;

        public AsyncAutoResetEvent(bool isSet = false) => _isSet = isSet;

        public Task WaitAsync()
        {
            lock (_completionQueue)
            {
                if (_isSet)
                {
                    _isSet = false;
                    return Task.CompletedTask;
                }
                else
                {
                    var tcs = new TaskCompletionSource<bool>();
                    _completionQueue.Enqueue(tcs);
                    return tcs.Task;
                }
            }
        }

        public void Set()
        {
            TaskCompletionSource<bool>? toRelease = null;
            lock (_completionQueue)
            {
                if (_completionQueue is { Count: > 0 })
                {
                    toRelease = _completionQueue.Dequeue();
                }
                else if (!_isSet)
                {
                    _isSet = true;
                }
            }

            toRelease?.SetResult(true);
        }
    }
}
