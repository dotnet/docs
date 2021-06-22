---
title: Diagnostics client library
description: In this article, you'll learn how to use Microsoft.Diagnostics.NETCore.Client library to write your custom diagnostic tool.
ms.date: 06/22/2021
author: tommcdon
ms.author: tommcdon
---

# Diagnostics client library

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions for target apps, .NET Standard 2.0 to use the library.

Microsoft.Diagnostics.NETCore.Client (also known as the Diagnostics client library) is a managed library that lets you interact with .NET Core runtime (CoreCLR) for various diagnostics related tasks, such as tracing via [EventPipe](eventpipe.md), requesting a dump, or attaching an ICorProfiler. This library is the backing library behind many diagnostics tools such as [`dotnet-counters`](dotnet-counters.md), [`dotnet-trace`](dotnet-trace.md), [`dotnet-gcdump`](dotnet-gcdump.md), and [`dotnet-dump`](dotnet-dump.md). Using this library, you can write your own diagnostics tools customized for your particular scenario.

You can acquire [Microsoft.Diagnostics.NETCore.Client](https://www.nuget.org/packages/Microsoft.Diagnostics.NETCore.Client/) by adding a `PackageReference` to your project. The package is hosted on `NuGet.org`.

The samples in the following sections show how to use Microsoft.Diagnostics.NETCore.Client library. Some of these examples also show parsing the event payloads by using [TraceEvent](https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.TraceEvent/) library.

## Attach to a process and print out all GC events

This snippet shows how to start an EventPipe session using the [.NET runtime provider](../../fundamentals/diagnostics/runtime-events.md) with the GC keyword at informational level. It also shows how to use the `EventPipeEventSource` class provided by the [TraceEvent library](https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.TraceEvent/) to parse the incoming events and print their names to the console in real time.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintRuntimeGCEvents.cs":::

## Write a core dump

This sample shows how to trigger the collection of a [core dump](dumps.md) using `DiagnosticsClient`.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TriggerCoreDump.cs":::

## Trigger a core dump when CPU usage goes above a threshold

This sample shows how to monitor the `cpu-usage` counter published by the .NET runtime and request a dump when the CPU usage grows beyond a certain threshold.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TriggerDumpOnCpuUsage.cs":::

## Trigger a CPU trace for given number of seconds

This sample shows how to trigger an EventPipe session for certain period of time with the default CLR trace keyword as well as the sample profiler. Afterward, it reads the output stream and writes the bytes out to a file. Essentially this is what [`dotnet-trace`](dotnet-trace.md) uses internally to write a trace file.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TraceProcessForDuration.cs":::

## Print names of processes that published a diagnostics channel

This sample shows how to use `DiagnosticsClient.GetPublishedProcesses` API to print the names of the .NET processes that published a diagnostics IPC channel.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintProcessStatus.cs":::

## Parse events in real time

This sample shows an example where we create two tasks, one that parses the events coming in live with `EventPipeEventSource` and one that reads the console input for a user input signaling the program to end. If the target app exists before the users presses enter, the app exists gracefully. Otherwise, `inputTask` will send the Stop command to the pipe and exit gracefully.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintEventsLive.cs":::

## Attach an ICorProfiler profiler

This sample shows how to attach an ICorProfiler to a process via profiler attach.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/ProfilerAttach.cs":::
