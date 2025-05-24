---
title: Log buffering
description: Learn how to delay log emission using log buffering in .NET applications.
ms.date: 05/16/2025
---

# Log buffering in .NET

.NET provides log buffering capabilities that allow you to delay the emission of logs until certain conditions are met. Log buffering is useful in scenarios where you want to:

- Collect all logs from a specific operation before deciding whether to emit them.
- Prevent logs from being emitted during normal operation, but emit them when errors occur.
- Optimize performance by reducing the number of logs written to storage.

Buffered logs are stored in temporary circular buffers in process memory, and the following conditions apply:

- If the buffer is full, the oldest logs are dropped and never emitted.
- If you want to emit the buffered logs, you can call <xref:Microsoft.Extensions.Diagnostics.Buffering.LogBuffer.Flush> on the <xref:Microsoft.Extensions.Diagnostics.Buffering.GlobalLogBuffer> or <xref:Microsoft.Extensions.Diagnostics.Buffering.PerRequestLogBuffer> class.
- If you never flush the buffers, the buffered logs will eventually be dropped as the application runs, so it effectively behaves like those logs are disabled.

There are two buffering strategies available:

- Global buffering: Buffers logs across the entire application.
- Per-request buffering: Buffers logs for each individual HTTP request if available; otherwise, buffers to the global buffer.

> [!NOTE]
> Log buffering is available in .NET 9 and later versions.

Log buffering works with all logging providers. If a logging provider you use does not implement the <xref:Microsoft.Extensions.Logging.Abstractions.IBufferedLogger> interface, log buffering will call log methods directly on every single buffered log record when flushing the buffer.

Log buffering extends [filtering capabilities](logging.md#configure-logging-with-code) by allowing you to capture and store logs temporarily. Rather than making an immediate emit-or-discard decision, buffering lets you hold logs in memory and decide later whether to emit them.

## Get started

To get started, install the [📦 Microsoft.Extensions.Telemetry](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry) NuGet package for [Global buffering](#global-buffering)
and/or install the [📦 Microsoft.AspNetCore.Diagnostics.Middleware](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.Middleware) NuGet package for [Per-request buffering](#per-request-buffering):

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Telemetry
dotnet add package Microsoft.AspNetCore.Diagnostics.Middleware
```

### [PackageReference](#tab/package-reference)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Telemetry"
                    Version="*" />
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.Middleware"
                    Version="*" />
</ItemGroup>
```

---

For more information, see [dotnet add package](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Global buffering

Global buffering allows you to buffer logs across your entire application. You can configure which logs to buffer using filter rules, and then flush the buffer as needed to emit those logs.

### Simple configuration

To enable global buffering at or below a specific log level, specify that level:

:::code language="csharp" source="snippets/logging/log-buffering/global/basic/Program.cs" range="18-19":::

The preceding configuration enables buffering logs with level <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> and below.

### File-based configuration

Create a configuration section in your _appsettings.json_, for example:

:::code language="json" source="snippets/logging/log-buffering/global/file-based/appsettings.json" range="1-22" highlight="7-20" :::

The preceding configuration:

- Buffers logs from categories starting with `BufferingDemo` with level <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> and below.
- Buffers all logs with event ID 1001.
- Sets the maximum buffer size to approximately 100 MB.
- Sets the maximum log record size to 50 KB.
- Sets an auto-flush duration of 30 seconds after manual flushing.

To register the log buffering with the configuration, consider the following code:

:::code language="csharp" source="snippets/logging/log-buffering/global/file-based/Program.cs" range="21-22":::

### Inline code configuration

:::code language="csharp" source="snippets/logging/log-buffering/global/code-based/Program.cs" range="18-28" :::

The preceding configuration:

- Buffers logs from categories starting with `BufferingDemo` with level <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> and below.
- Buffers all logs with event ID 1001.
- Sets the maximum buffer size to approximately 100 MB.
- Sets the maximum log record size to 50 KB.
- Sets an auto-flush duration of 30 seconds after manual flushing.

### Flushing the buffer

To flush the buffered logs, inject the `GlobalLogBuffer` abstract class and call the `Flush()` method:

:::code language="cs" source="snippets/logging/log-buffering/global/basic/myservice.cs" range="6-22" highlight="5,12" :::

## Per-request buffering

Per-request buffering is specific to ASP.NET Core applications and allows you to buffer logs independently for each HTTP request. The
buffer for each respective request is created when the request starts and disposed when the request ends, so if you don't flush the buffer, the logs will be lost when the request ends. This way, it is useful to only flush buffers when you really need to, such as when an error occurs.

Per-request buffering is tightly coupled with [global buffering](#global-buffering). If a log entry is supposed to be buffered to a per-request buffer, but there is no active HTTP context at the moment
of buffering attempt, it will be buffered to the global buffer instead. If buffer flush is triggered, the per-request buffer will be flushed first, followed by the global buffer.

### Simple configuration

To buffer only logs at or below a specific log level:

:::code language="cs" source="snippets/logging/log-buffering/per-request/basic/program.cs" range="16" :::

### File-based configuration

Create a configuration section in your _appsettings.json_:

:::code language="json" source="snippets/logging/log-buffering/per-request/file-based/appsettings.json" range="1-18" highlight="8-16":::

The preceding configuration:

- Buffers logs from categories starting with `PerRequestLogBufferingFileBased.` with level <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> and below.
- Sets an auto-flush duration of 5 seconds after manual flushing.

To register the log buffering with the configuration, consider the following code:

:::code language="cs" source="snippets/logging/log-buffering/per-request/file-based/program.cs" range="16" :::

### Inline code configuration

:::code language="cs" source="snippets/logging/log-buffering/per-request/code-based/program.cs" range="16-20" :::

The preceding configuration:

- Buffers logs from categories starting with `PerRequestLogBufferingFileBased.` with level <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> and below.
- Sets an auto-flush duration of 5 seconds after manual flushing.

### Flushing the per-request buffer

To flush the buffered logs for the current request, inject the `PerRequestLogBuffer` abstract class and call its `Flush()` method:

:::code language="cs" source="snippets/logging/log-buffering/per-request/basic/homecontroller.cs" range="8-48" highlight="8,11,34" :::

> [!NOTE]
> Flushing the per-request buffer will also flush the global buffer.

## How buffering rules are applied

Log buffering rules evaluation is performed on each log record. The following algorithm is used for each log record:

1. If a log entry matches any rule, it will be buffered instead of being emitted immediately.
1. If a log entry does not match any rule, it will be emitted normally.
1. If the buffer size limit is reached, the oldest buffered log entries will be dropped (not emitted!) to make room for new ones.
1. If a log entry size is greater than the maximum log record size, it will not be buffered and will be emitted normally.

For each log record, the algorithm checks:

- If the log level matches (is equal to or lower than) the rule's log level.
- If the category name starts with the rule's CategoryName prefix.
- If the event ID matches the rule's EventId.
- If the event name matches the rule's EventName.
- If any attributes match the rule's Attributes.

### Change buffer filtering rules in a running app

Both [global buffering](#global-buffering) and [per-request buffering](#per-request-buffering) support runtime configuration updates via the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> interface. If you're using a configuration provider that supports reloads—such as the [File Configuration Provider](configuration-providers.md#file-configuration-provider)—you can update filtering rules at runtime without restarting the application.

For example, you can start your application with the following _appsettings.json_, which enables log buffering for logs with the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level and category starting with `PerRequestLogBufferingFileBased.`:

:::code language="json" source="snippets/logging/log-buffering/per-request/file-based/appsettings.json" range="1-19" :::

While the app is running, you can update the _appsettings.json_ with the following configuration:

:::code language="json" source="snippets/logging/log-buffering/per-request/file-based/appsettingsUpdated.json" range="1-17" highlight="9-13" :::

The new rules will be applied automatically, for instance, with the preceding configuration, all logs with the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level will be buffered.

## Performance considerations

Log buffering offers a trade-off between memory usage and log storage costs. Buffering logs in memory allows you to:

1. Selectively emit logs based on run-time conditions.
1. Drop unnecessary logs without writing them to storage.

However, be mindful of the memory consumption, especially in high-throughput applications. Configure appropriate buffer size limits to prevent excessive memory usage.

## Best practices

- Set appropriate buffer size limits based on your application's memory constraints.
- Use per-request buffering for web applications to isolate logs by request.
- Configure auto-flush duration carefully to balance memory usage and log availability.
- Implement explicit flush triggers for important events (such as errors and warnings).
- Monitor buffer memory usage in production to ensure it remains within acceptable limits.

## Limitations

- Log buffering is not supported in .NET 8 and earlier versions.
- The order of logs is not guaranteed to be preserved. However, original timestamps are preserved.
- Custom configuration per each logging provider is not supported. The same configuration is used for all providers.
- Log scopes are not supported. This means that if you use the <xref:Microsoft.Extensions.Logging.ILogger.BeginScope%2A> method, the buffered log records will not be associated with the scope.
- Not all information of the original log record is preserved. Log buffering internally uses <xref:Microsoft.Extensions.Logging.Abstractions.BufferedLogRecord> class when flushing, and its following properties are always empty:
  - <xref:Microsoft.Extensions.Logging.Abstractions.BufferedLogRecord.ActivitySpanId>
  - <xref:Microsoft.Extensions.Logging.Abstractions.BufferedLogRecord.ActivityTraceId>
  - <xref:Microsoft.Extensions.Logging.Abstractions.BufferedLogRecord.ManagedThreadId>
  - <xref:Microsoft.Extensions.Logging.Abstractions.BufferedLogRecord.MessageTemplate>

## See also

- [Log Sampling](log-sampling.md)
- [Logging in .NET](logging.md)
- [High-performance logging in .NET](high-performance-logging.md)
