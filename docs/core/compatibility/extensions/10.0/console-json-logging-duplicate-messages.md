---
title: "Breaking change: Avoid duplicate messages in Console logging with Json formatter"
description: "Learn about the breaking change in .NET 10 where duplicate messages are avoided in Console logging with JSON formatter."
ms.date: 01/15/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47006
---

# Avoid duplicate messages in Console logging with Json formatter

When logging to the console using the JSON formatter, log messages are no longer duplicated in the log output. Previously, messages typically appeared three times: once as the top-level `Message`, again within the `State` object, and a third time as the original format string.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, when using a console logger configured with the JSON formatter, log messages were duplicated in the output. For example:

```csharp
logger.LogInformation("This is an information message.");
```

This code would produce output like:

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

As you can see, `Message` appears twice—once as the top-level `Message` and again inside the `State` object.

## New behavior

After the change, the log output looks like this:

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

The `Message` is no longer duplicated—it now appears only at the top level, resulting in cleaner and more concise log output.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The goal of this change is to reduce unnecessary logging overhead by eliminating duplicate content. By avoiding repeated formatting of the same message, the change helps:

- **Minimize log output size**
- **Reduce confusion caused by redundant information**
- **Improve performance by preventing multiple formatting operations for the same message**

Overall, this results in cleaner, more efficient, and easier-to-read logs.

## Recommended action

For users who were previously parsing the logging output and extracting the `Message` from within the `State` object, it's safe to use the top-level `Message` instead, now that duplication has been removed.

> [!NOTE]
> In some cases, a `Message` might still appear within the `State` object—this typically happens when its content differs from the top-level `Message`.

## Affected APIs

- <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A?displayProperty=fullName>
- [Microsoft.Extensions.Logging.Console NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console)
