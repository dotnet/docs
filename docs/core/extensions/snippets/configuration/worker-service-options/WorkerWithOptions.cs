using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WorkerServiceOptions.Example
{
    public class WorkerWithOptions : BackgroundService
    {
        private bool _hasWrittenSettings;
        private readonly ILogger<WorkerWithOptions> _logger;
        private readonly CustomSettings _settings;

        public WorkerWithOptions(
            ILogger<WorkerWithOptions> logger,
            IOptions<CustomSettings> options) =>
            (_logger, _settings) = (logger, options.Value);

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_hasWrittenSettings is false)
                {
                    _hasWrittenSettings = true;
                    _logger.LogInformation($"Settings: {_settings}");
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
