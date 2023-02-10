---
title: Dumps - .NET
description: An introduction to dumps in .NET.
ms.date: 01/11/2023
---

# Dumps

A dump is a file that contains a snapshot of the process at the time the dump was created and can be useful for examining the state of your application. Dumps can be used to debug your .NET application when it is difficult to attach a debugger to it, such as production or CI environments. Using dumps allows you to capture the state of the problematic process and examine it without having to stop the application.

## Collect dumps

Dumps can be collected in a variety of ways depending on which platform your app is running on.

> [!NOTE]
> Dumps may contain sensitive information because they can contain the full memory of the running process. Handle them with any security restrictions and guidances in mind.

> [!TIP]
> For frequently asked questions about dump collection, analysis, and other caveats, see [Dumps: FAQ](faq-dumps.yml).

* You can use environment variables to configure your application to [collect a dump on a crash](collect-dumps-crash.md).

* You may want to collect a dump when the app hasn't crashed yet. For example, if you want to examine the state of an application that seems to be in a deadlock, configuring the environment variables to collect dumps on crash will not be helpful because the app is still running.

* [dotnet-dump](dotnet-dump.md) is a simple cross-platform command line tool to collect a dump. Several other debugger tools such as [Visual Studio](/visualstudio-docs/docs/debugger/using-dump-files) or [windbg](/windows-hardware/drivers/debugger/-dump--create-dump-file-) also have dump collection features.

* If you are running your app in production or you are running it in a distributed manner (several services, replicas), [dotnet-monitor](dotnet-monitor.md) provides support for many common scenarios and ad-hoc diagnostic investigations, including dump collection and egress. It enables dumps to be collected remotely or with triggering conditions.

## Analyze dumps

* Navigate to [Debug Linux dumps](debug-linux-dumps.md) for information regarding analyzing dumps collected on Linux.

* Navigate to [Debug Windows Dumps](debug-windows-dumps.md) for information regarding analyzing dumps collected on Windows.

### Memory Analysis

You can perform memory analysis on your application if your app's memory continues to grow, but you are unsure why that is the case. [debug memory leak tutorial](debug-memory-leak.md) shows how to debug a memory leak using the dotnet CLI tools with the dotnet-sos commands dumpheap and gcroot.

[Visual Studio Memory Analysis](/visualstudio-docs/docs/profiling/analyze-memory-usage.md) can be used to diagnose a memory leak on Windows.

## See also

Learn more about how you can leverage dumps to help diagnose problems in your .NET application.

* [Debug Linux dumps](debug-linux-dumps.md) tutorial walks you through how to debug a dump that was collected in Linux.

* [Debug deadlock](debug-deadlock.md) tutorial walks you through how to debug a deadlock in your .NET application using dumps.
