// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Logging;

namespace GlobalLogBufferingFileBased;

internal static partial class Log
{
    [LoggerMessage(Level = LogLevel.Error, Message = "ERROR log message in my application. {message}")]
    public static partial void ErrorMessage(this ILogger logger, string message);

    [LoggerMessage(Level = LogLevel.Information, Message = "INFORMATION log message in my application.")]
    public static partial void InformationMessage(this ILogger logger);
}
