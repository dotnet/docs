using System.Threading;
using System.Threading.Tasks;

namespace App.ScopedService
{
    public interface IScopedProcessingService
    {
        Task DoWorkAsync(CancellationToken stoppingToken);
    }
}
