---
title: Shut down Orleans silos
description: Learn how to shut down .NET Orleans silos.
ms.date: 02/01/2022
---

# Shut down Orleans silos

This document explains how to gracefully shut down an Orleans silo before application exit, first as a Console app, and then as a Docker container app. The following code shows how to gracefully shut down an Orleans silo console app in response to the user pressing <kbd>Ctrl</kbd> + <kbd>C</kbd>, which generates the <xref:System.Console.CancelKeyPress?displayProperty=nameWithType> event.

Normally when that event handler returns, the application will exit immediately, causing a catastrophic Orleans silo crash and loss of in-memory state. But in the sample code below, we set `a.Cancel = true;` to prevent the application closing before the Orleans silo has completed its graceful shutdown.

```csharp
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

static readonly ManualResetEvent s_siloStopped = new(false);
static readonly object s_syncLock = new object();

static ISiloHost s_silo;
static bool s_siloStopping = false;

SetupApplicationShutdown();

s_silo = CreateSilo();
await s_silo.StartAsync();

/// Wait for the silo to completely shutdown before exiting.
s_siloStopped.WaitOne();

static void SetupApplicationShutdown()
{
    Console.CancelKeyPress += (s, a) =>
    {
        /// Prevent the application from crashing ungracefully.
        a.Cancel = true;
        /// Don't allow the following code to repeat if the user presses Ctrl+C repeatedly.
        lock (s_syncLock)
        {
            if (!s_siloStopping)
            {
                s_siloStopping = true;
                Task.Run(StopSiloAsync).Ignore();
            }
        }
        // Event handler execution exits immediately, leaving the
        // silo shutdown running on a background thread,
        // but the app doesn't crash because a.Cancel has been set = true
    };
}

static ISiloHost CreateSilo() => new SiloHostBuilder()
    .Configure(options => options.ClusterId = "MyTestCluster")
    .UseDevelopmentClustering(
        options => options.PrimarySiloEndpoint = new IPEndPoint(IPAddress.Loopback, 11111))
    .ConfigureLogging(b => b.SetMinimumLevel(LogLevel.Debug).AddConsole())
    .Build();

static async Task StopSiloAsync() {
    await s_silo.StopAsync();
    s_siloStopped.Set();
}
```

Of course, there are many other ways of achieving the same goal. But beware, that there are online examples that _do not_ work properly.

> [!CAUTION]
> Always avoid race conditions between two methods trying to exit first, for example, the `Console.CancelKeyPress` event handler method, and the `static void Main(string[] args)` method. When the event handler method finishes first, which happens at least half the time, the application will hang instead of exiting smoothly.
