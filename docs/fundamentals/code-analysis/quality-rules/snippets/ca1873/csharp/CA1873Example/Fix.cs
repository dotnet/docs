using Microsoft.Extensions.Logging;

// <FixExample>
partial class FixExample
{
    private readonly ILogger _logger;

    public FixExample(ILogger<FixExample> logger)
    {
        _logger = logger;
    }

    public void ProcessData(int[] data)
    {
        // Fixed: use source-generated logging.
        // The data array is passed directly; no expensive operation executed unless log level is enabled.
        LogProcessingData(data);

        // Fixed: use source-generated logging.
        LogTraceData(data.Length, data);
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "Processing {Data} items")]
    private partial void LogProcessingData(int[] data);

    [LoggerMessage(Level = LogLevel.Trace, Message = "Data: Count={Count}, Items={Items}")]
    private partial void LogTraceData(int count, int[] items);
}
// </FixExample>
