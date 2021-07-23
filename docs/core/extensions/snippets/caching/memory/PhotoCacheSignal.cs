using System.Threading.Tasks;

namespace CachingExamples.Memory
{
    public class PhotoCacheSignal
    {
        private AsyncAutoResetEvent _signal = new(false);
        
        public void Set() => _signal.Set();

        public void Reset(bool isSet) => _signal = new(isSet);
        
        public Task WaitAsync() => _signal.WaitAsync();
    }
}
