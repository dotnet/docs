using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

internal static partial class LogMessages
{
    [LoggerMessage(Message = "Sold {quantity} of {description}")]
    internal static partial void LogProductSaleDetails(
        this ILogger logger,
        int quantity,
        string description,
        LogLevel logLevel = LogLevel.Information);
}
