namespace WorkerServiceOptions.Example.Extensions;

public static class LoggerExtensions
{
    #region ProcessingItemField
    private static readonly Action<ILogger, WorkItem, Exception> s_processingPriorityItem;
    #endregion

    #region FailedProcessingField
    private static readonly Action<ILogger, Exception> s_failedToProcessWorkItem;
    #endregion

    #region ProcessingWorkField
    private static Func<ILogger, DateTime, IDisposable?> s_processingWorkScope;
    #endregion

    static LoggerExtensions()
    {
        #region ProcessingItemAssignment
        s_processingPriorityItem = LoggerMessage.Define<WorkItem>(
            LogLevel.Information,
            new EventId(1, nameof(PriorityItemProcessed)),
            "Processing priority item: {Item}");
        #endregion

        #region FailedProcessingAssignment
        s_failedToProcessWorkItem = LoggerMessage.Define(
            LogLevel.Critical,
            new EventId(13, nameof(FailedToProcessWorkItem)),
            "Epic failure processing item!");
        #endregion

        #region ProcessingWorkAssignment
        s_processingWorkScope =
            LoggerMessage.DefineScope<DateTime>(
                "Processing work, started at: {DateTime}");
        #endregion
    }

    #region ProcessingItemMethod
    public static void PriorityItemProcessed(
        this ILogger logger, WorkItem workItem) =>
        s_processingPriorityItem(logger, workItem, default!);
    #endregion

    #region FailedProcessingMethod
    public static void FailedToProcessWorkItem(
        this ILogger logger, Exception ex) =>
        s_failedToProcessWorkItem(logger, ex);
    #endregion

    #region ProcessingWorkMethod
    public static IDisposable? ProcessingWorkScope(
        this ILogger logger, DateTime time) =>
        s_processingWorkScope(logger, time);
    #endregion
}
