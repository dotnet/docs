---
title: "Breaking change: IHost.RunAsync and IHost.StopAsync throw when a BackgroundService fails"
description: "Learn about the breaking change in .NET 11 where IHost.RunAsync, IHost.StopAsync, and related methods throw an exception when a BackgroundService fails."
ms.date: 04/03/2026
ai-usage: ai-assisted
---

# IHost.RunAsync and IHost.StopAsync throw when a BackgroundService fails

When a <xref:Microsoft.Extensions.Hosting.BackgroundService> fails with an exception from its `ExecuteAsync` method and <xref:Microsoft.Extensions.Hosting.HostOptions.BackgroundServiceExceptionBehavior?displayProperty=nameWithType> is set to <xref:Microsoft.Extensions.Hosting.BackgroundServiceExceptionBehavior.StopHost> (the default), the host stops. In .NET 11, the tasks returned from `RunAsync`, `StopAsync`, `WaitForShutdownAsync`, and their synchronous equivalents now fail with an exception instead of completing successfully.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, when a `BackgroundService` threw an exception from its <xref:Microsoft.Extensions.Hosting.BackgroundService.ExecuteAsync*> method and `HostOptions.BackgroundServiceExceptionBehavior` was set to `BackgroundServiceExceptionBehavior.StopHost`, the task returned from calling `RunAsync`, `StopAsync`, or `WaitForShutdownAsync` completed successfully. This usually meant the application exited with a success exit code (zero).

## New behavior

Starting in .NET 11, when a `BackgroundService` throws an exception from its `ExecuteAsync` method and `HostOptions.BackgroundServiceExceptionBehavior` is set to `BackgroundServiceExceptionBehavior.StopHost`, the task returned from calling `RunAsync`, `StopAsync`, or `WaitForShutdownAsync` fails with an exception. The application typically exits with a failure exit code (non-zero).

- If a single service fails, the exception thrown by the service is rethrown.
- If multiple services fail, their exceptions are combined into an <xref:System.AggregateException>.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

If an application stops because of a failure, it shouldn't exit with a success exit code. The previous behavior hid the failure, making it harder to detect and diagnose the exception that caused it.

## Recommended action

The recommended action is to do nothing—a failing application should exit with a failure exit code, which is the new behavior.

If you need to maintain the previous behavior and exit with a success exit code, wrap the `await` of `RunAsync` or `StopAsync` in a `try`-`catch` block:

```csharp
try
{
    await host.RunAsync();
}
catch (Exception ex)
{
    // Log or inspect the exception if needed.
}
```

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.StopAsync*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown*?displayProperty=fullName>
- <xref:Microsoft.Extensions.Hosting.IHost.StopAsync*?displayProperty=fullName> (default implementation)
