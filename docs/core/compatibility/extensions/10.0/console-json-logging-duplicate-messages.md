---
title: "Breaking change: Message no longer duplicated in Console log output"
description: "Learn about the breaking change in .NET 10 where `Message` is no longer duplicated in Console log output using the JSON formatter."
ms.date: 08/07/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47006
---

# Message no longer duplicated in Console log output

When logging to the console using the JSON formatter, log messages are no longer duplicated in the log output. Previously, messages typically appeared three times: once as the top-level `Message`, again within the `State` object, and a third time as the original format string.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, when using a console logger configured with the JSON formatter, log messages were duplicated in the output. For example, the code `logger.LogInformation("This is an information message.");` produced the following output:

```json
{
  "EventId": 0,
  "LogLevel": "Information",
  "Category": "Program",
  "Message": "This is an information message.",
  "State": {
    "Message": "This is an information message.",
    "{OriginalFormat}": "This is an information message."
  }
}
```

As you can see, `Message` appears twice: once as the top-level `Message` and again inside the `State` object.

## New behavior

Starting in .NET 10, `Message` appears only at the top level and not inside the `State` object (typically). The log output looks like this:

```json
{
  "EventId": 0,
  "LogLevel": "Information",
  "Category": "Program",
  "Message": "This is an information message.",
  "State": {
    "{OriginalFormat}": "This is an information message."
  }
}
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The goal of this change is to reduce unnecessary logging overhead by eliminating duplicate content. By avoiding repeated formatting of the same message, the change helps:

- Minimize log output size.
- Reduce confusion caused by redundant information.
- Improve performance by preventing multiple formatting operations for the same message.

Overall, this results in cleaner, more efficient, and easier-to-read logs.

## Recommended action

If you previously parsed the logging output to extract the `Message` from within the `State` object, it's safe to use the top-level `Message` instead, now that duplication has been removed.

> [!NOTE]
> In some cases, a `Message` might still appear within the `State` object. This typically happens when its content differs from the top-level `Message`.

## Affected APIs

- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsoleFormatter*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddJsonConsole*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddSimpleConsole*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddSystemdConsole*?displayProperty=fullName>
