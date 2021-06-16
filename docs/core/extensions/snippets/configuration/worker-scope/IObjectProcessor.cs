using System.Threading.Tasks;

namespace WorkerScope.Example
{
    interface IObjectProcessor
    {
        Task ProcessAsync(ObjectGraph obj);
    }
}
