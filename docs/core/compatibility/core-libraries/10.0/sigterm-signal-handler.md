---
title: "Breaking change: .NET runtime no longer provides default termination signal handler"
description: "Learn about the breaking change in .NET 10 where the runtime no longer provides a default termination signal handler."
ms.date: 06/06/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46226
---
# .NET runtime no longer provides default termination signal handlers

On Unix systems, the .NET runtime no longer provides a default SIGTERM signal handler. On Windows, the .NET runtime no longer provides default handlers for the [`CTRL_SHUTDOWN_EVENT` and `CTRL_CLOSE_EVENT` signals](/windows/console/handlerroutine), which are equivalents of Unix `SIGTERM` and `SIGHUP` signals.

This change reverts the termination signal handling behavior to what it used to be in .NET Framework and classic Mono runtime.

## Version introduced

.NET 10 Preview 5

## Previous behavior

Previously, termination signal handlers registered by the .NET runtime by default triggered graceful application exit. <xref:System.AppDomain.ProcessExit?displayProperty=nameWithType> and <xref:System.Runtime.Loader.AssemblyLoadContext.Unloading?displayProperty=nameWithType> events were raised before the application exited.

## New behavior

Starting in .NET 10, the .NET runtime does not override termination signal handling provided by the operating system. The typical default termination signal handler provided by the operating system terminates the application immediately. <xref:System.AppDomain.ProcessExit?displayProperty=nameWithType> and <xref:System.Runtime.Loader.AssemblyLoadContext.Unloading?displayProperty=nameWithType> events aren't raised.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The termination signal handlers registered by the .NET runtime by default were both insufficient for some app models (for example, console and containerized applications) and incompatible with other app models (for example, Windows services). It's better to leave it to higher-level libraries or application code to register signal handlers appropriate for the given app model.

## Recommended action

- No action is necessary for typical ASP.NET applications or applications that use higher-level APIs such as <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseConsoleLifetime*?displayProperty=nameWithType> to handle app-model specific concerns. These higher-level APIs register handlers for SIGTERM and other signals as appropriate.

- If you want to handle termination signals without taking a dependency on higher-level libraries, you can replicate the previous behavior by creating termination signal handlers in your `Main` method using the <xref:System.Runtime.InteropServices.PosixSignalRegistration.Create%2A?displayProperty=nameWithType> API:

```csharp
static void Main()
{
    using var termSignalRegistration =
        PosixSignalRegistration.Create(
            PosixSignal.SIGTERM,
            (_) => Environment.Exit(0));

    // Replicates the previous behavior on Windows
    using var sigHupSignalRegistration =
        PosixSignalRegistration.Create(
            PosixSignal.SIGHUP,
            (_) => Environment.Exit(0));

    // Your application code here
}
```

## Affected APIs

- <xref:System.AppDomain.ProcessExit?displayProperty=fullName>
- <xref:System.Runtime.Loader.AssemblyLoadContext.Unloading?displayProperty=fullName>
