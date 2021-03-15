---
title: Collect a distributed trace - .NET
description: A tutorial to collect distributed traces in .NET applications
ms.topic: tutorial
ms.date: 03/14/2021
---

# Collect a distributed trace

**This article applies to: ✔️** .NET Core 5.0 and later versions **or** any .NET application using the 
[DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/5.0.1) version 5 or later

.NET applications can be instrumented using the <xref:System.Diagnostics.Activity?displayProperty=nameWithType> API to produce
distributed tracing telemetry. In this tutorial you will record this instrumented telemetry with different telemetry collection
libraries so that it is available to diagnose application issues. See 
[the instrumentation tutorial](distributed-tracing-instrumentation-walkthroughs.md) if you need to add new instrumentation.

## Collect using OpenTelemetry

### Prerequisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

### Create an example application

First you will create an example application that has some distributed trace instrumentation but nothing is being collected.

```dotnetcli
dotnet new console
```

Applications that target .NET 5 and later already have the necessary distributed tracing APIs included. For apps targeting older
.NET versions add the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 5.0.1 or greater.
```dotnetcli
dotnet add package System.Diagnostics.DiagnosticSource --version 5.0.1
```

Replace the contents of the generated Program.cs with this example source:
```C#
using System;
using System.Diagnostics;
using System.Net.Http;
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

Running the app does not log anything yet
```dotnetcli
> dotnet run
Example work done
```

### Add logging using OpenTelemetry

Add the [OpenTelemetry](https://www.nuget.org/packages/OpenTelemetry/) and 
[OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console/) NuGet packages.

```dotnetcli
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.Console
```

Update Program.cs with additional using statments:
```C#
using OpenTelemetry;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
```

And update Main() to create the OpenTelemetry TracerProvider:
```C#
        public static async Task Main()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                // Add more libraries
                .AddSource("Sample.DistributedTracing")
                // Add more exporters
                .AddConsoleExporter()
                .Build();

            await DoSomeWork();
            Console.WriteLine("Example work done");
        }
```

Now the app logs distributed trace information to the console:
```dotnetcli
> dotnet run
Activity.Id:          00-35c0e68b0dac3c49be08a9d9cab32579-0b7477e11aa20d40-01
Activity.ParentId:    00-35c0e68b0dac3c49be08a9d9cab32579-d95f666d24193f40-01
Activity.DisplayName: StepOne
Activity.Kind:        Internal
Activity.StartTime:   2021-03-15T01:58:10.7661575Z
Activity.Duration:    00:00:00.5013965
Resource associated with Activity:
    service.name: unknown_service:temp

Activity.Id:          00-35c0e68b0dac3c49be08a9d9cab32579-7ba0fc6d480c9841-01
Activity.ParentId:    00-35c0e68b0dac3c49be08a9d9cab32579-d95f666d24193f40-01
Activity.DisplayName: StepTwo
Activity.Kind:        Internal
Activity.StartTime:   2021-03-15T01:58:11.2894853Z
Activity.Duration:    00:00:01.0188689
Resource associated with Activity:
    service.name: unknown_service:temp

Activity.Id:          00-35c0e68b0dac3c49be08a9d9cab32579-d95f666d24193f40-01
Activity.DisplayName: SomeWork
Activity.Kind:        Internal
Activity.StartTime:   2021-03-15T01:58:10.7647839Z
Activity.Duration:    00:00:01.5450288
Resource associated with Activity:
    service.name: unknown_service:temp

Example work done
```

The console exporter is helpful for quick examples or local development but in a production deployment
you will probably want to send logs to a central logging store. OpenTelemetry supports a variety
of different logging destinations using different
[exporters](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/glossary.md#exporter-library).
See the [OpenTelemetry getting started](https://github.com/open-telemetry/opentelemetry-dotnet#getting-started)
instructions for more information on configuring OpenTelemetry.

## Collect using Application Insights

Distributed tracing telemetry is automatically captured after configuring the Application Insights SDK 
([.NET](https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net), [.NET Core](https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core))
or by enabling [code-less instrumentation](https://docs.microsoft.com/en-us/azure/azure-monitor/app/codeless-overview).

See the [Application Insights distributed tracing documentation](https://docs.microsoft.com/en-us/azure/azure-monitor/app/distributed-tracing) for more
information.

> [!NOTE]
> Currently Application Insights only supports collecting specific well-known Activity instrumentation and will ignore new user added Activities. Application
> Insights offers [TrackDependency](https://docs.microsoft.com/en-us/azure/azure-monitor/app/api-custom-events-metrics#trackdependency) as a vendor
> specific API for adding custom distributed tracing information.


## Collect using a custom logging implementation

### Prerequisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

### Create an example application

```dotnetcli
dotnet new console
```

Applications that target .NET 5 and later already have the necessary distributed tracing APIs included. For apps targeting older
.NET versions add the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 5.0.1 or greater.
```dotnetcli
dotnet add package System.Diagnostics.DiagnosticSource --version 5.0.1
```

Replace the contents of the generated Program.cs with this example source:
```C#
using System;
using System.Diagnostics;
using System.Net.Http;
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

Running the app does not log anything yet
```dotnetcli
> dotnet run
Example work done
```

### Add code to log the Activities

Update Main() with this code that logs Activities:
```C#
        static async Task Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
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

Setting <xref:System.Diagnostics.Activity.DefaultIdFormat?displayProperty=nameWithType> is optional
but helps ensure the sample produces similar output on different .NET runtime versions. .NET 5.0 uses
the W3C ID format by default but earlier .NET versions default to using 
<xref:System.Diagnostics.ActivityIdFormat.Hierarchical?displayProperty=nameWithType> as a precaution
to avoid compatibility issues with older distributed tracing systems. See
[Activity IDs](distributed-tracing-concepts.md#activity-ids) for more details.

<xref:System.Diagnostics.ActivityListener?displayProperty=nameWithType> is used to receive callbacks
during the lifetime of an Activity. 
 - <xref:System.Diagnostics.ActivityListener.ShouldListenTo?displayProperty=nameWithType> - Each
Activity is associated with an ActivitySource which acts as a namespace for a set of Activities.
This callback is invoked once for each ActivitySource in the process. Returning true indicates
the listener should be notified about Activities associated with this source.
 - <xref:System.Diagnostics.ActivityListener.Sample?displayProperty=nameWithType> - By default
<xref:System.Diagnostics.ActivitySource.StartActivity?displayProperty=nameWithType> does not
create an Activity object unless some ActivityListener indicates it should be sampled. Returning
<xref:System.Diagnostics.ActivitySamplingResult.AllDataAndRecorded?displayProperty=nameWithType>
indicates that the Activity should be created,
<xref:System.Diagnostics.Activity.IsAllDataRequested?displayProperty=nameWithType> should be set
to true, and <xref:System.Diagnostics.Activity.ActivityTraceFlags?displayProperty=nameWithType>
will have the <xref:System.Diagnostics.ActivityTraceFlags.Recorded?displayProperty=nameWithType>
flag set. IsAllDataRequested can be observed by the instrumented code as a hint that a listener
wants to ensure that auxilliary Activity information such as Tags and Events are populated.
The Recorded flag is encoded in the W3C ID and is a hint to other processes involved in the
distributed trace that this trace should be logged.
 - <xref:System.Diagnostics.ActivityListener.ActivityStarted?displayProperty=nameWithType> and
<xref:System.Diagnostics.ActivityListener.ActivityStopped?displayProperty=nameWithType> are
called when an Activity is started and stopped respectively. These callbacks provide an
oportunity to log any relevant information about the Activity. When an Activity has just
started much of the data may still be incomplete and it will be filled in before the Activity
stops.

Once an ActivityListener has been created and the callbacks are populated, invoking
<xref:System.Diagnostics.ActivitySource.AddActivityListener?displayProperty=nameWithType>
initiates invoking the callbacks. Call 
<xref:System.Diagnostics.ActivityListener.Dispose?displayProperty=nameWithType> to
stop the flow of callbacks. Beware that in multi-threaded code callback notifications in
progress could be received while Dispose() is running or even very shortly after it has
returned.
