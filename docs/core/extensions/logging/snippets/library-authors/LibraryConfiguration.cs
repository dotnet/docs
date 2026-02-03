using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Logging.LibraryAuthors;

public sealed class LibraryConfiguration
{
    internal static ILoggerFactory LoggerFactory { get; private set; } = NullLoggerFactory.Instance;

    public static void SetLoggerFactory(ILoggerFactory loggerFactory) =>
        LoggerFactory = loggerFactory;
}
