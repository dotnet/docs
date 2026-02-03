using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

internal static partial class LogMessages
{
    [LoggerMessage(
        Message = "Sold {Quantity} of {Description}",
        Level = LogLevel.Information)]
    internal static partial void LogProductSaleDetails(
        this ILogger logger,
        int quantity,
        string description);
}
