// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;

namespace LogSamplingFileConfig;

internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Debug, Message = "Entered While loop in my application.")]
    public static partial void EnteredWhileLoop(ILogger logger);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Left While loop in my application.")]
    public static partial void LeftWhileLoop(ILogger logger);

    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Noisy log message in my application.")]
    public static partial void NoisyMessage(ILogger logger);
}
