namespace WorkerServiceOptions.Example.Extensions;

public static class LoggerExtensions
{
    #region ProcessingItemField
    private static readonly Action<ILogger, WorkItem, Exception> _processingPriorityItem;
    #endregion

    #region FailedProcessingField
    private static readonly Action<ILogger, Exception> _failedToProcessWorkItem;
    #endregion

    #region ProcessingWorkField
    private static Func<ILogger, DateTime, IDisposable> _processingWorkScope;
    #endregion

    static LoggerExtensions()
    {
        #region ProcessingItemAssignment
        _processingPriorityItem = LoggerMessage.Define<WorkItem>(
            LogLevel.Information,
            new EventId(1, nameof(PriorityItemProcessed)),
            "Processing priority item: {Item}");
        #endregion

        #region FailedProcessingAssignment
        _failedToProcessWorkItem = LoggerMessage.Define(
            LogLevel.Critical,
            new EventId(13, nameof(FailedToProcessWorkItem)),
            "Epic failure processing item!");
        #endregion

        #region ProcessingWorkAssignment
        _processingWorkScope =
            LoggerMessage.DefineScope<DateTime>(
                "Processing work, started at: {DateTime}");
        #endregion
    }

    #region ProcessingItemMethod
    public static void PriorityItemProcessed(
        this ILogger logger, WorkItem workItem) =>
        _processingPriorityItem(logger, workItem, default!);
    #endregion

    #region FailedProcessingMethod
    public static void FailedToProcessWorkItem(
        this ILogger logger, Exception ex) =>
        _failedToProcessWorkItem(logger, ex);
    #endregion

    #region ProcessingWorkMethod
    public static IDisposable ProcessingWorkScope(
        this ILogger logger, DateTime time) =>
        _processingWorkScope(logger, time);
    #endregion
}
