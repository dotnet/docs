---
title: Use Microsoft.Diagnostics.NETCore.Client library to write your own diagnostics tool
description: In this article, you'll learn how to use Microsoft.Diagnostics.NETCore.Client library to write your custom diagnostic tool.
ms.date: 12/08/2020
---

# Microsoft.Diagnostics.NETCore.Client

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions for target apps, .NET Standard 2.0 to use the library.

Microsoft.Diagnostics.NETCore.Client (also known as the Diagnostics Client library) is a managed library that lets you interact with .NET Core runtime (CoreCLR) for various diagnostics related tasks, such as tracing via [EventPipe](eventpipe.md), requesting a dump, or attaching an ICorProfiler. This library is the backing library behind many diagnostics tools such as [`dotnet-counters`](dotnet-counters.md), [`dotnet-trace`](dotnet-trace.md), [`dotnet-gcdump`](dotnet-gcdump.md), and [`dotnet-dump`](dotnet-dump.md). Using this library, you can write your own diagnostics tools customized for your particular scenario.

## Install

You can acquire [Microsoft.Diagnostics.NETCore.Client](https://www.nuget.org/packages/Microsoft.Diagnostics.NETCore.Client/) by adding a `PackageReference` to your project. The package is hosted on `NuGet.org`.

## Write your own diagnostic tool

These samples show how to use Microsoft.Diagnostics.NETCore.Client library. Some of these examples also show parsing the event payloads by using [TraceEvent](https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.TraceEvent/) library.

### Attach to a process and print out all the runtime GC events in real time to the console

This snippet shows how to start an EventPipe session using the [.NET runtime provider](../../fundamentals/diagnostics/runtime-events.md) with the GC keyword at informational level and how to use the `EventPipeEventSource` class provided by the [TraceEvent library](https://www.nuget.org/packages/Microsoft.Diagnostics.Tracing.TraceEvent/) to parse the incoming events and print their names to the console in real time.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintRuntimeGCEvents.cs":::

### Write a core dump

This sample shows how to trigger the collection of a [core dump](dumps.md) using `DiagnosticsClient`.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TriggerCoreDump.cs":::

### Trigger a core dump when CPU usage goes above a certain threshold

This sample shows how to monitor the `cpu-usage` counter published by the .NET runtime and request a dump when the CPU usage grows beyond a certain threshold.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TriggerDumpOnCpuUsage.cs":::

### Trigger a CPU trace for given number of seconds

This sample shows how to trigger an EventPipe session for certain period of time with the default CLR trace keyword as well as the sample profiler. Afterward, it reads the output stream and writes the bytes out to a file. Essentially this is what [`dotnet-trace`](dotnet-trace.md) uses internally to write a trace file.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/TraceProcessForDuration.cs":::

### Print names of all .NET processes that published a diagnostics server to connect

This sample shows how to use `DiagnosticsClient.GetPublishedProcesses` API to print the names of the .NET processes that published a diagnostics IPC channel.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintProcessStatus.cs":::

### Parse events in real-time for a specified period of time

This sample shows an example where we create two tasks, one that parses the events coming in live with `EventPipeEventSource` and one that reads the console input for a user input signaling the program to end. If the target app exists before the users presses enter, the app exists gracefully. Otherwise, `inputTask` will send the Stop command to the pipe and exit gracefully.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/PrintEventsLive.cs":::

### Attach an ICorProfiler profiler

This sample shows how to attach an ICorProfiler to a process via profiler attach.

:::code language="csharp" source="snippets/Microsoft.Diagnostics.NETCore.Client/csharp/ProfilerAttach.cs":::

## API Description

This section describes the APIs of the library.

### DiagnosticsClient class

```cs
public DiagnosticsClient
{
    public DiagnosticsClient(int processId);
    
    public EventPipeSession StartEventPipeSession(
        IEnumerable<EventPipeProvider> providers,
        bool requestRundown = true,
        int circularBufferMB = 256);
    
    public void WriteDump(
        DumpType dumpType,
        string dumpPath,
        bool logDumpGeneration = false);
    
    public void AttachProfiler(
        TimeSpan attachTimeout,
        Guid profilerGuid,
        string profilerPath,
        byte[] additionalData = null);
    
    public static IEnumerable<int> GetPublishedProcesses();
}
```

```csharp
public DiagnosticsClient(int processId);
```

Creates a new instance of `DiagnosticsClient` for a compatible .NET process running with process ID of `processId`.

`processID` : Process ID of the target application.

```csharp
public EventPipeSession StartEventPipeSession(
    IEnumerable<EventPipeProvider> providers,
    bool requestRundown = true,
    int circularBufferMB = 256)
```

Starts an EventPipe tracing session using the given providers and settings.

* `providers` : An `IEnumerable` of [`EventPipeProvider`](#class-eventpipeprovider)s to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.

```csharp
public EventPipeSession StartEventPipeSession(EventPipeProvider providers, bool requestRundown=true, int circularBufferMB=256)
```

* `providers` : An [`EventPipeProvider`](#class-eventpipeprovider) to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.

> [!NOTE]
> Rundown events contain payloads that may be needed for post analysis, such as resolving method names of thread samples. Unless you know you do not want this, we recommend setting this to true. In large applications, this may take a while.

* `circularBufferMB` : The size of the circular buffer to be used as a buffer for writing events within the runtime.

```csharp
public void WriteDump(DumpType dumpType, string dumpPath, bool logDumpGeneration=false);
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#enum-dumptype) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `logDumpGeneration` : If set to `true`, the target application will write out diagnostic logs during dump generation.

```csharp
public void AttachProfiler(TimeSpan attachTimeout, Guid profilerGuid, string profilerPath, byte[] additionalData=null);
```

Request to attach an ICorProfiler to the target application.

* `attachTimeout` : A `TimeSpan` after which attach will be aborted.
* `profilerGuid` :  `Guid` of the ICorProfiler to be attached.
* `profilerPath` : Path to the ICorProfiler dll to be attached.
* `additionalData` : Optional additional data that can be passed to the runtime during profiler attach.

```csharp
public static IEnumerable<int> GetPublishedProcesses();
```

Get an `IEnumerable` of process IDs of all the active .NET processes that can be attached to.

#### EventPipeProvider class

```cs
public class EventPipeProvider
{
    public EventPipeProvider(
        string name,
        EventLevel eventLevel,
        long keywords = 0,
        IDictionary<string, string> arguments = null)

    public string Name { get; }

    public EventLevel EventLevel { get; }

    public long Keywords { get; }

    public IDictionary<string, string> Arguments { get; }

    public override string ToString();

    public override bool Equals(object obj);

    public override int GetHashCode();

    public static bool operator ==(Provider left, Provider right);

    public static bool operator !=(Provider left, Provider right);
}
```

```csharp
public EventPipeProvider(
    string name,
    EventLevel eventLevel,
    long keywords = 0,
    IDictionary<string, string> arguments = null)
```

Creates a new instance of `EventPipeProvider` with the given provider name, <xref:System.Diagnostics.Tracing.EventLevel>, keywords, and arguments.

```csharp
public string Name { get; }
```

The name of the Provider

```csharp
public EventLevel EventLevel { get; }
```

The EventLevel of the given instance of [`EventPipeProvider`](#class-eventpipeprovider).

```csharp
public long Keywords { get; }
```

A long that represents bitmask for keywords of the EventSource.

```csharp
public IDictionary<string, string> Arguments { get; }
```

An `IDictionary` of key-value pair string representing optional arguments to be passed to EventSource representing the given `EventPipeProvider`.

#### Remarks

This class is immutable as EventPipe does not allow a provider's configuration to be modified during an EventPipe session as of .NET Core 3.1.

### class EventPipeSession

```csharp
public class EventPipeSession : IDisposable
{
    public Stream EventStream { get; }
    public void Stop();
}
```

This class represents an ongoing EventPipe session. It is immutable and acts as a handle to an EventPipe session of the given runtime.

```csharp
public Stream EventStream { get; }
```

Returns a `Stream` that can be used to read the event stream.

```csharp
public void Stop();
```

Stops the given EventPipe session.

### enum DumpType

```csharp
public enum DumpType
{
    Normal = 1,
    WithHeap = 2,
    Triage = 3,
    Full = 4
}
```

Represents the type of dump that can be requested.

* `Normal`: Include just the information necessary to capture stack traces for all existing traces for all existing threads in a process. Limited GC heap memory and information.
* `WithHeap`: Includes the GC heaps and information necessary to capture stack traces for all existing threads in a process.
* `Triage`: Include just the information necessary to capture stack traces for all existing traces for all existing threads in a process. Limited GC heap memory and information.
* `Full`: Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can be mapped directly without the raw memory information. This option can result in a very large dump file.

### Exceptions

Exceptions that are thrown from the library are `DiagnosticsClientException`s or a derived class of it.

```csharp
public class DiagnosticsClientException : Exception
```

#### UnsupportedCommandException

```csharp
public class UnsupportedCommandException : DiagnosticsClientException
```

This may be thrown when the command is not supported by either the library or the target process' runtime.

#### UnsupportedProtocolException

```csharp
public class UnsupportedProtocolException : DiagnosticsClientException
```

This may be thrown when the target process' runtime is not compatible with the diagnostics IPC protocol used by the library.

#### ServerNotAvailableException

```csharp
public class ServerNotAvailableException : DiagnosticsClientException
```

This may be thrown when the runtime is not available for diagnostics IPC commands, such as early during runtime startup before the runtime is ready for diagnostics commands, or when the runtime is shutting down.

#### ServerErrorException

```csharp
public class ServerErrorException : DiagnosticsClientException
```

This may be thrown when the runtime responds with an error to a given command.
