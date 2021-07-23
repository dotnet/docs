using System.Threading.Tasks;

namespace CachingExamples.Memory
{
    public class PhotoCacheSignal
    {
        private AsyncAutoResetEvent _signal = new(false);

        /// <summary>
        /// Exposes a <see cref="Task"/> that represents the asynchronous wait operation.
        /// When signaled (consumer calls <see cref="Set"/>), the 
        /// <see cref="Task.Status"/> is set as <see cref="TaskStatus.RanToCompletion"/>.
        /// </summary>
        public Task WaitAsync() => _signal.WaitAsync();

        /// <summary>
        /// Reset's the signal. When called with <c>false</c>, the <see cref="WaitAsync"/>
        /// will not release until <see cref="Set"/> is called. When called with 
        /// <c>true</c>, the <see cref="WaitAsync"/> will release immediately when awaited.
        /// </summary>
        public void Reset(bool isSet) => _signal = new(isSet);

        /// <summary>
        /// Exposes the ability to signal the release of the <see cref="WaitAsync"/>'s operation.
        /// Callers who were waiting, will be able to continue.
        /// </summary>
        public void Set() => _signal.Set();
    }
}
