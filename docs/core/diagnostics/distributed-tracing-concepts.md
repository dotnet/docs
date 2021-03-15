---
title: Distributed tracing concepts - .NET
description: .NET distributed tracing concepts
ms.date: 03/14/2021
---

# Distributed Tracing

Distributed tracing is a diagnostic technique that helps engineers localize failures and 
performance issues within applications, especially those that may be distributed across
multiple machines or processes. See the [Distributed Tracing Overview](distributed-tracing.md)
for general information about where distributed tracing is useful and example code to get
started.

## Concepts

### Traces and Activities

Each time a new request is received by an application a new trace can be initiated. In
application components written in .NET, units of work in a trace are represented by instances of
<xref:System.Diagnostics.Activity?displayProperty=nameWithType> and the trace as a whole forms
a tree of these Activities, potentially spanning across many distinct processes. The first
Activity created for a new request forms the root of the trace tree and it tracks the overall
duration and success/failure handling the request. Child activities can be optionally created
to sub-divide the work into different steps that can be tracked individually.
For example given an Activity that tracked a specific inbound HTTP request in a web server,
child activites could be created to track each of the database queries that was necessary to
complete the request. This allows the duration and success for each query to be recorded independently. 
Activities can record other information for each unit of work such as a name (
<xref:System.Diagnostics.Activity.OperationName%2A?displayProperty=nameWithType>), name-value pairs
called tags (
<xref:System.Diagnostics.Activity.Tags%2A?displayProperty=nameWithType>), and events (
<xref:System.Diagnostics.Activity.Events%2A?displayProperty=nameWithType>). The name identifies
the type of work being performed, tags can record descriptive parameters of the work, and events
are a simple logging mechanism to record timestamped diagnostic messages.

> [!NOTE]
> Another common industry name for units of work in a distributed trace are 'Spans'.
> .NET adopted the term 'Activity' many years ago, before the name 'Span' was well
> established for this concept.

### Activity IDs

Parent-Child relationships between Activities in the distributed trace tree are established
using unique IDs. .NET's implementation of distributed tracing supports two ID schemes, the W3C
standard [TraceContext](https://www.w3.org/TR/trace-context/) which is the default in .NET 5 and
an older .NET convention called 'Hierarchical' that is available for backwards compatibility.
<xref:System.Diagnostics.Activity.DefaultIdFormat%2A?displayProperty=nameWithType> controls which
ID scheme is used. In the W3C TraceContext standard every trace is assigned a globally unique 16
byte trace-id (<xref:System.Diagnostics.Activity.TraceId%2A?displayProperty=nameWithType>) and
every Activity within the trace is assigned a unique 8 byte span-id (
<xref:System.Diagnostics.Activity.SpanId%2A?displayProperty=nameWithType>). Each Activity
records the trace-id, its own span-id, and the span-id of its parent (
<xref:System.Diagnostics.Activity.ParentSpanId%2A?displayProperty=nameWithType>). Because
distributed traces can track work across process boundaries parent and child Activities may
not be in the same process. The combination of a trace-id and parent span-id can uniquely
identify the parent Activity globally, regardless of what process it resides in. The
<xref:System.Diagnostics.Activity.Parent%2A?displayProperty=nameWithType> property will also
reference the parent Activity whenever the parent resides in the same process.

### Starting and stopping Activities

Each thread in a process may have a corresponding Activity object that is tracking the work
occuring on that thread, accessible via 
<xref:System.Diagnostics.Activity.Current%2A?displayProperty=nameWithType>. The current activity
automatically flows along all synchronous calls on a thread as well as following async calls
that are processed on different threads. If Activity A is the current activity on a thread and
code starts a new Activity B then B becomes the new current activity on that thread. By default
activity B will also treat Activity A as its parent. When Activity B is later stopped activity
A will be restored as the current Activity on the thread. When an Activity is started it
captures the current time as the 
<xref:System.Diagnostics.Activity.StartTimeUtc%2A?displayProperty=nameWithType>. When it
stops <xref:System.Diagnostics.Activity.Duration%2A?displayProperty=nameWithType> is calculated
as the difference between the current time and the start time.

### Coordinating across process boundaries

In order to track work across process boundaries Activity parent IDs need to be transmitted across
the network so that the receiving process can create Activities that refer to them. When using
W3C standard Activity IDs (<xref:System.Diagnostics.ActivityIdFormat.W3C%2A?displayProperty=nameWithType>)
.NET will also use [W3C standard networking protocols](https://www.w3.org/TR/trace-context/) to
transmit this information. When using the 
<xref:System.Diagnostics.ActivityIdFormat.Hierarchical%2A?displayProperty=nameWithType> ID format
.NET uses a custom request-id HTTP header to transmit the ID. Unlike many other language runtimes
.NET in-box libraries natively understand how to decode and encode Activity IDs on HTTP messages
as well as how to flow the ID through sychronous and asynchronous calls. This means that .NET
applications that receive and emit HTTP messages participate in flowing distributed trace IDs
automatically, with no special coding by the app developer nor 3rd party library dependencies.
3rd party libraries may add support for transmitting IDs over non-HTTP message protocols or
supporting custom encoding conventions for HTTP.

### Logging Activities

After creating the <xref:System.Diagnostics.Activity?displayProperty=nameWithType> objects the
app developer typically wants to log the tracing information to a persistant store so it can be
later reviewed by engineers on-demand. There are several telemetry collection libraries that can
do this such as
[Application Insights](https://docs.microsoft.com/en-us/azure/azure-monitor/app/distributed-tracing),
[OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/trace/getting-started/README.md),
or a library provided by a 3rd party logging or APM vendor. Alternately developers can author
their own custom Activity logging by using
<xref:System.Diagnostics.ActivityListener?displayProperty=nameWithType> or 
<xref:System.Diagnostics.DiagnosticListener?displayProperty=nameWithType>. ActivityListener
supports logging any Activity regardless whether the logging library has any a-priori knowledge
which makes it a simple and flexible general purpose solution. By contrast using DiagnosticListener
is a more complex scenario that requires the Activity creator to opt-in by invoking a specific API,
<xref:System.Diagnostics.DiagnosticSource.StartActivity%2A?displayProperty=nameWithType>, and
the logging library needs to know the exact naming information that the Activity creator chose to
use when starting it. Using DiagnosticSource and DiagnosticListener allows the Activity creator
and Activity logger to exchange arbitrary .NET objects and establish customized information passing
conventions.

### Sampling

For improved performance in high throughput applications, distributed tracing on .NET supports
sampling only a subset of requests rather than logging all of them. For activites created with
the recommended newer <xref:System.Diagnostics.ActivitySource.StartActivity%2A?displayProperty=nameWithType>
API, logging libraries can control sampling with the
<xref:System.Diagnostics.ActivityListener.Sample%2A?displayProperty=nameWithType> callback.
The logging library can elect not to create the Activity at all, to create it with minimal
information necessary to propagate distributing tracing IDs, or to populate it with complete
diagnostic information. These choices trade-off increasing performance overhead for
increasing diagnostic utility. Activities that are started using the older pattern of invoking
<xref:System.Diagnostics.Activity..ctor%2A?displayProperty=nameWithType> and 
<xref:System.Diagnostics.DiagnosticSource.StartActivity%2A?displayProperty=nameWithType> may
also support DiagnosticListener sampling by first calling 
<xref:System.Diagnostics.DiagnosticSource.IsEnabled%2A?displayProperty=nameWithType>.
Even when capturing full diagnostic information the .NET
implementation is designed to be fast - coupled with an efficient logger an Activity can be
created, populated, and logged in about a microsecond on modern hardware. Sampling
can reduce the instrumentation cost to less than 100 nanoseconds for each Activity that isn't
logged.

## Next steps

See the [Distributed Tracing Overview](distributed-tracing.md) for example code to get started
using distributed tracing in .NET applications.