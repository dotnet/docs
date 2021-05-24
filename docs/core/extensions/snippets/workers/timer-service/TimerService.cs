using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.TimerHostedService
{
    public sealed class TimerService : IHostedService, IAsyncDisposable
    {
        private readonly Task _completedTask = Task.CompletedTask;
        private readonly ILogger<TimerService> _logger;
        private int _executionCount = 0;
        private Timer? _timer;

        public TimerService(ILogger<TimerService> logger) => _logger = logger;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(TimerHostedService)} is running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return _completedTask;
        }

        private void DoWork(object? state)
        {
            int count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation(
                $"{nameof(TimerHostedService)} is working, execution count: {{Count:#,0}}",
                count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(TimerHostedService)} is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return _completedTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_timer is IAsyncDisposable timer)
            {
                await timer.DisposeAsync();
            }

            _timer = null;
        }
    }
}
