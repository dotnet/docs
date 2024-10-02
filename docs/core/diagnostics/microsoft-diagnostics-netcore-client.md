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

    public Task<EventPipeSession> StartEventPipeSessionAsync(
        IEnumerable<EventPipeProvider> providers,
        bool requestRundown,
        int circularBufferMB = 256,
        CancellationToken token = default);

    public void WriteDump(
        DumpType dumpType,
        string dumpPath,
        bool logDumpGeneration = false);

    public async Task WriteDumpAsync(
        DumpType dumpType,
        string dumpPath,
        bool logDumpGeneration,
        CancellationToken token);

    public void AttachProfiler(
        TimeSpan attachTimeout,
        Guid profilerGuid,
        string profilerPath,
        byte[] additionalData = null);

    public void SetStartupProfiler(
        Guid profilerGuid,
        string profilerPath);

    public void ResumeRuntime();

    public void SetEnvironmentVariable(
        string name,
        string value);

    public Dictionary<string, string> GetProcessEnvironment();

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
    int circularBufferMB = 256);
public Task<EventPipeSession> StartEventPipeSessionAsync(
    IEnumerable<EventPipeProvider> providers,
    bool requestRundown,
    int circularBufferMB = 256,
    CancellationToken token = default);
```

Starts an EventPipe tracing session using the given providers and settings.

* `providers` : An `IEnumerable` of [`EventPipeProvider`](#eventpipeprovider-class)s to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.
* `token` (for the Async overload): The token to monitor for cancellation requests.

```csharp
public EventPipeSession StartEventPipeSession(EventPipeProvider provider, bool requestRundown = true, int circularBufferMB = 256)
public Task<EventPipeSession> StartEventPipeSessionAsync(EventPipeProvider provider, bool requestRundown, int circularBufferMB = 256, CancellationToken token = default)
```

* `provider` : An [`EventPipeProvider`](#eventpipeprovider-class) to start tracing.
* `requestRundown`: A `bool` specifying whether rundown provider events from the target app's runtime should be requested.
* `circularBufferMB`: An `int` specifying the total size of circular buffer used by the target app's runtime on collecting events.
* `token` (for the Async overload): The token to monitor for cancellation requests.

> [!NOTE]
> Rundown events contain payloads that may be needed for post analysis, such as resolving method names of thread samples. Unless you know you do not want this, we recommend setting `requestRundown` to true. In large applications, this may take a while.

### WriteDump method

```csharp
public void WriteDump(
    DumpType dumpType,
    string dumpPath,
    bool logDumpGeneration=false);
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#dumptype-enum) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `logDumpGeneration` : If set to `true`, the target application will write out diagnostic logs during dump generation.

```csharp
public void WriteDump(DumpType dumpType, string dumpPath, WriteDumpFlags flags)
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#dumptype-enum) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `flags` : logging and crash report flags. On runtimes less than 6.0, only LoggingEnabled is supported.

```csharp
public async Task WriteDumpAsync(DumpType dumpType, string dumpPath, bool logDumpGeneration, CancellationToken token)
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#dumptype-enum) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `logDumpGeneration` : If set to `true`, the target application will write out diagnostic logs during dump generation.
* `token` : The token to monitor for cancellation requests.

```csharp
public async Task WriteDumpAsync(DumpType dumpType, string dumpPath, WriteDumpFlags flags, CancellationToken token)
```

Request a dump for post-mortem debugging of the target application. The type of the dump can be specified using the [`DumpType`](#dumptype-enum) enum.

* `dumpType` : Type of the dump to be requested.
* `dumpPath` : The path to the dump to be written out to.
* `flags` : logging and crash report flags. On runtimes less than 6.0, only LoggingEnabled is supported.
* `token` : The token to monitor for cancellation requests.

### AttachProfiler method

```csharp
public void AttachProfiler(
    TimeSpan attachTimeout,
    Guid profilerGuid,
    string profilerPath,
    byte[] additionalData=null);
```

Request to attach an ICorProfiler to the target application.

* `attachTimeout` : A `TimeSpan` after which attach will be aborted.
* `profilerGuid` :  `Guid` of the ICorProfiler to be attached.
* `profilerPath` : Path to the ICorProfiler dll to be attached.
* `additionalData` : Optional additional data that can be passed to the runtime during profiler attach.

### SetStartupProfiler method

```csharp
public void SetStartupProfiler(
        Guid profilerGuid,
        string profilerPath);
```

Set a profiler as the startup profiler. It is only valid to issue this command while the runtime is paused at startup.

* `profilerGuid` : `Guid` for the profiler to be attached.
* `profilerPath` : Path to the profiler to be attached.

### ResumeRuntime method

```csharp
public void ResumeRuntime();
```

Tell the runtime to resume execution after being paused at startup.

### SetEnvironmentVariable method

```csharp
public void SetEnvironmentVariable(
    string name,
    string value);
```

Set an environment variable in the target process.

* `name` : The name of the environment variable to set.
* `value` : The value of the environment variable to set.

### GetProcessEnvironment

```csharp
public Dictionary<string, string> GetProcessEnvironment()
```

Gets all environment variables and their values from the target process.

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
* `Triage`: Include just the information necessary to capture stack traces for all existing traces for all existing threads in a process. Limited GC heap memory and information. Some content that is known to contain potentially sensitive information such as full module paths will be redacted. While this is intended to mitigate some cases of sensitive data exposure, there is no guarantee this redaction feature on its own is sufficient to comply with any particular law or standard regarding data privacy.
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
