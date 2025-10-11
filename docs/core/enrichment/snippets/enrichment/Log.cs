// Copyright (c) Microsoft Corporation. All Rights Reserved.

using Microsoft.Extensions.Logging;

namespace Enrichment
{
    internal static partial class Log
    {
        [LoggerMessage(LogLevel.Information, "This is a sample log message")]
        public static partial void LogSampleMessage(this ILogger logger);
    }
}
