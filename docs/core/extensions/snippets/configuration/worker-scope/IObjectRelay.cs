using System.Threading.Tasks;

namespace WorkerScope.Example
{
    interface IObjectRelay
    {
        Task RelayAsync(ObjectGraph obj);
    }
}
