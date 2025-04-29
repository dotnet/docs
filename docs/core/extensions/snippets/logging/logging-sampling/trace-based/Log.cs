// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;

namespace LogSamplingTraceBased;

internal static partial class Log
{
    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Count: {count}. Noisy log message.")]
    public static partial void NoisyMessage(this ILogger logger, int count);
}
