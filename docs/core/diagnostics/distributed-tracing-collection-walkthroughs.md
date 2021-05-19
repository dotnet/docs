---
title: Collect a distributed trace - .NET
description: Tutorials to collect distributed traces in .NET applications using OpenTelemetry, Application Insights, or ActivityListener
ms.topic: tutorial
ms.date: 03/14/2021
---

# Collect a distributed trace

**This article applies to: ✔️** .NET Core 2.1 and later versions **✔️** .NET Framework 4.5 and later versions

Instrumented code can create <xref:System.Diagnostics.Activity> objects as part of a distributed trace, but the information
in these objects needs to be collected into centralized storage so that the entire trace can be
reviewed later. In this tutorial, you will collect the distributed trace telemetry in different ways so that it's
available to diagnose application issues when needed. See
[the instrumentation tutorial](distributed-tracing-instrumentation-walkthroughs.md) if you need to add new instrumentation.

## Collect traces using OpenTelemetry

### Prerequisites

- [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

### Create an example application

Before any distributed trace telemetry can be collected, we need to produce it. Often this instrumentation might be
in libraries, but for simplicity, you'll create a small app that has some example instrumentation using
<xref:System.Diagnostics.ActivitySource.StartActivity%2A>. At this point, no collection has happened, and
StartActivity() has no side-effect and returns null. See
[the instrumentation tutorial](distributed-tracing-instrumentation-walkthroughs.md) for more details.

```dotnetcli
dotnet new console
```

Applications that target .NET 5 and later already have the necessary distributed tracing APIs included. For apps targeting older
.NET versions, add the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 5 or greater.

```dotnetcli
dotnet add package System.Diagnostics.DiagnosticSource
```

Replace the contents of the generated Program.cs with this example source:

```C#
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sample.DistributedTracing
{
    class Program
    {
        static ActivitySource s_source = new ActivitySource("Sample.DistributedTracing");

        static async Task Main(string[] args)
        {
            await DoSomeWork();
            Console.WriteLine("Example work done");
        }

        static async Task DoSomeWork()
        {
            using (Activity a = s_source.StartActivity("SomeWork"))
            {
                await StepOne();
                await StepTwo();
            }
        }

        static async Task StepOne()
        {
            using (Activity a = s_source.StartActivity("StepOne"))
            {
                await Task.Delay(500);
            }
        }

        static async Task StepTwo()
        {
            using (Activity a = s_source.StartActivity("StepTwo"))
            {
                await Task.Delay(1000);
            }
        }
    }
}
```

Running the app does not collect any trace data yet:

```dotnetcli
> dotnet run
Example work done
```

### Collect using OpenTelemetry

[OpenTelemetry](https://opentelemetry.io/) is a vendor-neutral open-source project supported by the
[Cloud Native Computing Foundation](https://www.cncf.io/) that aims to standardize generating and collecting telemetry for
cloud-native software. In this example, you will collect and display distributed trace information on the console though
OpenTelemetry can be reconfigured to send it elsewhere. For more information, see the
[OpenTelemetry getting started guide](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/trace/getting-started/README.md).

Add the [OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console/) NuGet package.

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```

Update Program.cs with additional OpenTelemetry `using` directives:

```C#
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
```

Update `Main()` to create the OpenTelemetry TracerProvider:

```C#
        public static async Task Main()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MySample"))
                .AddSource("Sample.DistributedTracing")
                .AddConsoleExporter()
                .Build();

            await DoSomeWork();
            Console.WriteLine("Example work done");
        }
```

Now the app collects distributed trace information and displays it to the console:

```dotnetcli
> dotnet run
Activity.Id:          00-7759221f2c5599489d455b84fa0f90f4-6081a9b8041cd840-01
Activity.ParentId:    00-7759221f2c5599489d455b84fa0f90f4-9a52f72c08a9d447-01
Activity.DisplayName: StepOne
Activity.Kind:        Internal
Activity.StartTime:   2021-03-18T10:46:46.8649754Z
Activity.Duration:    00:00:00.5069226
Resource associated with Activity:
    service.name: MySample
    service.instance.id: 909a4624-3b2e-40e4-a86b-4a2c8003219e

Activity.Id:          00-7759221f2c5599489d455b84fa0f90f4-d2b283db91cf774c-01
Activity.ParentId:    00-7759221f2c5599489d455b84fa0f90f4-9a52f72c08a9d447-01
Activity.DisplayName: StepTwo
Activity.Kind:        Internal
Activity.StartTime:   2021-03-18T10:46:47.3838737Z
Activity.Duration:    00:00:01.0142278
Resource associated with Activity:
    service.name: MySample
    service.instance.id: 909a4624-3b2e-40e4-a86b-4a2c8003219e

Activity.Id:          00-7759221f2c5599489d455b84fa0f90f4-9a52f72c08a9d447-01
Activity.DisplayName: SomeWork
Activity.Kind:        Internal
Activity.StartTime:   2021-03-18T10:46:46.8634510Z
Activity.Duration:    00:00:01.5402045
Resource associated with Activity:
    service.name: MySample
    service.instance.id: 909a4624-3b2e-40e4-a86b-4a2c8003219e

Example work done
```

#### Sources

In the example code, you invoked `AddSource("Sample.DistributedTracing")` so that OpenTelemetry would
capture the Activities produced by the ActivitySource that was already present in the code:

```csharp
static ActivitySource s_source = new ActivitySource("Sample.DistributedTracing");
```

Telemetry from any ActivitySource can be captured by calling `AddSource()` with the source's name.

#### Exporters

The console exporter is helpful for quick examples or local development but in a production deployment
you will probably want to send traces to a centralized store. OpenTelemetry supports various destinations using different
[exporters](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/glossary.md#exporter-library).
For more information about configuring OpenTelemetry, see the [OpenTelemetry getting started guide](https://github.com/open-telemetry/opentelemetry-dotnet#getting-started).

## Collect traces using Application Insights

Distributed tracing telemetry is automatically captured after configuring the Application Insights SDK for
[ASP.NET](/azure/azure-monitor/app/asp-net) or [ASP.NET Core](/azure/azure-monitor/app/asp-net-core) apps,
or by enabling [code-less instrumentation](/azure/azure-monitor/app/codeless-overview).

For more
information, see the [Application Insights distributed tracing documentation](/azure/azure-monitor/app/distributed-tracing).

> [!NOTE]
> Currently, Application Insights only supports collecting specific well-known Activity instrumentation and ignores new user-added Activities. Application Insights offers [TrackDependency](/azure/azure-monitor/app/api-custom-events-metrics#trackdependency) as a vendor-specific API for adding custom distributed tracing information.

## Collect traces using custom logic

Developers are free to create their own customized collection logic for Activity trace data. This example collects the
telemetry using the <xref:System.Diagnostics.ActivityListener?displayProperty=nameWithType> API provided by .NET and prints
it to the console.

### Prerequisites

- [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

### Create an example application

First you will create an example application that has some distributed trace instrumentation but no trace data is being collected.

```dotnetcli
dotnet new console
```

Applications that target .NET 5 and later already have the necessary distributed tracing APIs included. For apps targeting older
.NET versions, add the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 5 or greater.

```dotnetcli
dotnet add package System.Diagnostics.DiagnosticSource
```

Replace the contents of the generated Program.cs with this example source:

```C#
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sample.DistributedTracing
{
    class Program
    {
        static ActivitySource s_source = new ActivitySource("Sample.DistributedTracing");

        static async Task Main(string[] args)
        {
            await DoSomeWork();
            Console.WriteLine("Example work done");
        }

        static async Task DoSomeWork()
        {
            using (Activity a = s_source.StartActivity("SomeWork"))
            {
                await StepOne();
                await StepTwo();
            }
        }

        static async Task StepOne()
        {
            using (Activity a = s_source.StartActivity("StepOne"))
            {
                await Task.Delay(500);
            }
        }

        static async Task StepTwo()
        {
            using (Activity a = s_source.StartActivity("StepTwo"))
            {
                await Task.Delay(1000);
            }
        }
    }
}
```

Running the app does not collect any trace data yet:

```dotnetcli
> dotnet run
Example work done
```

### Add code to collect the traces

Update Main() with this code:

```C#
        static async Task Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            Console.WriteLine("         {0,-15} {1,-60} {2,-15}", "OperationName", "Id", "Duration");
            ActivitySource.AddActivityListener(new ActivityListener()
            {
                ShouldListenTo = (source) => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded,
                ActivityStarted = activity => Console.WriteLine("Started: {0,-15} {1,-60}", activity.OperationName, activity.Id),
                ActivityStopped = activity => Console.WriteLine("Stopped: {0,-15} {1,-60} {2,-15}", activity.OperationName, activity.Id, activity.Duration)
            });

            await DoSomeWork();
            Console.WriteLine("Example work done");
        }
```

The output now includes logging:

```dotnetcli
> dotnet run
         OperationName   Id                                                           Duration
Started: SomeWork        00-bdb5faffc2fc1548b6ba49a31c4a0ae0-c447fb302059784f-01
Started: StepOne         00-bdb5faffc2fc1548b6ba49a31c4a0ae0-a7c77a4e9a02dc4a-01
Stopped: StepOne         00-bdb5faffc2fc1548b6ba49a31c4a0ae0-a7c77a4e9a02dc4a-01      00:00:00.5093849
Started: StepTwo         00-bdb5faffc2fc1548b6ba49a31c4a0ae0-9210ad536cae9e4e-01
Stopped: StepTwo         00-bdb5faffc2fc1548b6ba49a31c4a0ae0-9210ad536cae9e4e-01      00:00:01.0111847
Stopped: SomeWork        00-bdb5faffc2fc1548b6ba49a31c4a0ae0-c447fb302059784f-01      00:00:01.5236391
Example work done
```

Setting <xref:System.Diagnostics.Activity.DefaultIdFormat> and
<xref:System.Diagnostics.Activity.ForceDefaultIdFormat> is optional
but helps ensure the sample produces similar output on different .NET runtime versions. .NET 5 uses
the W3C TraceContext ID format by default but earlier .NET versions default to using
<xref:System.Diagnostics.ActivityIdFormat.Hierarchical> ID format. For more information, see
[Activity IDs](distributed-tracing-concepts.md#activity-ids).

<xref:System.Diagnostics.ActivityListener?displayProperty=nameWithType> is used to receive callbacks
during the lifetime of an Activity.

- <xref:System.Diagnostics.ActivityListener.ShouldListenTo> - Each
Activity is associated with an ActivitySource, which acts as its namespace and producer.
This callback is invoked once for each ActivitySource in the process. Return true
if you are interested in performing sampling or being notified about start/stop events
for Activities produced by this source.
- <xref:System.Diagnostics.ActivityListener.Sample> - By default
<xref:System.Diagnostics.ActivitySource.StartActivity%2A> does not
create an Activity object unless some ActivityListener indicates it should be sampled. Returning
<xref:System.Diagnostics.ActivitySamplingResult.AllDataAndRecorded>
indicates that the Activity should be created,
<xref:System.Diagnostics.Activity.IsAllDataRequested> should be set
to true, and <xref:System.Diagnostics.Activity.ActivityTraceFlags>
will have the <xref:System.Diagnostics.ActivityTraceFlags.Recorded>
flag set. IsAllDataRequested can be observed by the instrumented code as a hint that a listener
wants to ensure that auxiliary Activity information such as Tags and Events are populated.
The Recorded flag is encoded in the W3C TraceContext ID and is a hint to other processes
involved in the distributed trace that this trace should be sampled.
- <xref:System.Diagnostics.ActivityListener.ActivityStarted> and
<xref:System.Diagnostics.ActivityListener.ActivityStopped> are
called when an Activity is started and stopped respectively. These callbacks provide an
opportunity to record relevant information about the Activity or potentially to modify it.
When an Activity has just started, much of the data may still be incomplete and it will
be populated before the Activity stops.

Once an ActivityListener has been created and the callbacks are populated, calling
<xref:System.Diagnostics.ActivitySource.AddActivityListener(System.Diagnostics.ActivityListener)?displayProperty=nameWithType>
initiates invoking the callbacks. Call
<xref:System.Diagnostics.ActivityListener.Dispose?displayProperty=nameWithType> to
stop the flow of callbacks. Be aware that in multi-threaded code, callback notifications in
progress could be received while `Dispose()` is running or even shortly after it has
returned.
