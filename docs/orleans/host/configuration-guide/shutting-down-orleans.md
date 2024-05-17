---
title: Shut down Orleans silos
description: Learn how to shut down .NET Orleans silos.
ms.date: 11/01/2022
---

# Shut down Orleans silos

This article explains how to gracefully shut down an Orleans silo before the app exits. This applies to apps running as a console app, or as a container app. Various termination signals can cause an app to shut down, such as <kbd>Ctrl</kbd>+<kbd>C</kbd> (or `SIGTERM`). The following sections explain how to handle these signals.

## Graceful Silo shutdown

The following code shows how to gracefully shut down an Orleans silo console app. Consider the following example code:

```csharp
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        // Use the siloBuilder instance to configure the Orleans silo.
    })
    .RunConsoleAsync();
```

The preceding code relies on the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting), and [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet packages. The <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.RunConsoleAsync%2A> extension method, extends <xref:Microsoft.Extensions.Hosting.IHostBuilder> to help manage the lifetime of the app accordingly, listening for process termination signals and shutting down the silo gracefully.

Internally, the `RunConsoleAsync` method calls <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseConsoleLifetime%2A> which ensures that the app shuts down gracefully. For more information on host shutdown, see [.NET Generic Host: Host shutdown](../../../core/extensions/generic-host.md#host-shutdown).

## See also

- [.NET Generic Host](../../../core/extensions/generic-host.md)
- [Orleans silo lifecycle overview](../silo-lifecycle.md)
