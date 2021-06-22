---
title: Microsoft.Diagnostics.NETCore.Client API
description: In this article, you'll learn about the Microsoft.Diagnostics.NETCore.Client APIs.
ms.date: 06/22/2021
author: tommcdon
ms.author: tommcdon
ms.topic: reference
---

# Microsoft.Diagnostics.NETCore.Client API

This section describes the APIs of the diagnostics client library.

## DiagnosticsClient class

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

### Constructor

```csharp
public DiagnosticsClient(int processId);
```

Creates a new instance of `DiagnosticsClient` for a compatible .NET process running with process ID of `processId`.

`processID` : Process ID of the target application.

### StartEventPipeSession methods

```csharp
public EventPipeSession StartEventPipeSession(
    IEnumerable<EventPipeProvider> providers,
    bool requestRundown = true,
    int circularBufferMB = 256)
```

Starts an EventPipe tracing session using the given providers and settings.

* `providers` : An `IEnumerable` of [`EventPipeProvider`](#eventpipeprovider-class)s to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.

```csharp
public EventPipeSession StartEventPipeSession(EventPipeProvider providers, bool requestRundown=true, int circularBufferMB=256)
```

* `providers` : An [`EventPipeProvider`](#eventpipeprovider-class) to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.

> [!NOTE]
> Rundown events contain payloads that may be needed for post analysis, such as resolving method names of thread samples. Unless you know you do not want this, we recommend setting this to true. In large applications, this may take a while.

* `circularBufferMB` : The size of the circular buffer to be used as a buffer for writing events within the runtime.

### WriteDump method

```csharp
public void WriteDump(DumpType dumpType, string dumpPath, bool logDumpGeneration=false);
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#dumptype-enum) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `logDumpGeneration` : If set to `true`, the target application will write out diagnostic logs during dump generation.

### AttachProfiler method

```csharp
public void AttachProfiler(TimeSpan attachTimeout, Guid profilerGuid, string profilerPath, byte[] additionalData=null);
```

Request to attach an ICorProfiler to the target application.

* `attachTimeout` : A `TimeSpan` after which attach will be aborted.
* `profilerGuid` :  `Guid` of the ICorProfiler to be attached.
* `profilerPath` : Path to the ICorProfiler dll to be attached.
* `additionalData` : Optional additional data that can be passed to the runtime during profiler attach.

### GetPublishedProcesses method

```csharp
public static IEnumerable<int> GetPublishedProcesses();
```

Get an `IEnumerable` of process IDs of all the active .NET processes that can be attached to.

## EventPipeProvider class

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

### Constructor

```csharp
public EventPipeProvider(
    string name,
    EventLevel eventLevel,
    long keywords = 0,
    IDictionary<string, string> arguments = null)
```

Creates a new instance of `EventPipeProvider` with the given provider name, <xref:System.Diagnostics.Tracing.EventLevel>, keywords, and arguments.

### Name property

```csharp
public string Name { get; }
```

Gets the name of the Provider.

### EventLevel property

```csharp
public EventLevel EventLevel { get; }
```

Gets the `EventLevel` of the given instance of [`EventPipeProvider`](#eventpipeprovider-class).

### Keywords property

```csharp
public long Keywords { get; }
```

Gets a value that represents bitmask for keywords of the `EventSource`.

### Arguments property

```csharp
public IDictionary<string, string> Arguments { get; }
```

Gets an `IDictionary` of key-value pair strings representing optional arguments to be passed to `EventSource` representing the given `EventPipeProvider`.

### Remarks

This class is immutable, because EventPipe does not allow a provider's configuration to be modified during an EventPipe session as of .NET Core 3.1.

## EventPipeSession class

```csharp
public class EventPipeSession : IDisposable
{
    public Stream EventStream { get; }
    public void Stop();
}
```

This class represents an ongoing EventPipe session. It is immutable and acts as a handle to an EventPipe session of the given runtime.

## EventStream property

```csharp
public Stream EventStream { get; }
```

Gets a `Stream` that can be used to read the event stream.

## Stop method

```csharp
public void Stop();
```

Stops the given `EventPipe` session.

## DumpType enum

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

## Exceptions

Exceptions that are thrown from the library are of type `DiagnosticsClientException` or a derived type.

```csharp
public class DiagnosticsClientException : Exception
```

### UnsupportedCommandException

```csharp
public class UnsupportedCommandException : DiagnosticsClientException
```

This may be thrown when the command is not supported by either the library or the target process's runtime.

### UnsupportedProtocolException

```csharp
public class UnsupportedProtocolException : DiagnosticsClientException
```

This may be thrown when the target process's runtime is not compatible with the diagnostics IPC protocol used by the library.

### ServerNotAvailableException

```csharp
public class ServerNotAvailableException : DiagnosticsClientException
```

This may be thrown when the runtime is not available for diagnostics IPC commands, such as early during runtime startup before the runtime is ready for diagnostics commands, or when the runtime is shutting down.

### ServerErrorException

```csharp
public class ServerErrorException : DiagnosticsClientException
```

This may be thrown when the runtime responds with an error to a given command.
