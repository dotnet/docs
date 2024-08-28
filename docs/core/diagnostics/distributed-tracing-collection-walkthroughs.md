---
title: Collect a distributed trace - .NET
description: Tutorials to collect distributed traces in .NET applications using OpenTelemetry, Application Insights, or ActivityListener
ms.topic: tutorial
ms.date: 08/27/2024
---

# Collect a distributed trace

**This article applies to: ✔️** .NET Core 2.1 and later versions **✔️** .NET Framework 4.5 and later versions

Instrumented code can create <xref:System.Diagnostics.Activity> objects as part of a distributed trace, but the information
in these objects needs to be collected into centralized storage so that the entire trace can be
reviewed later. In this tutorial, you will collect the distributed trace telemetry in different ways so that it's
available to diagnose application issues when needed. See
[the instrumentation tutorial](distributed-tracing-instrumentation-walkthroughs.md) if you need to add new instrumentation.

## Collect traces using OpenTelemetry

[OpenTelemetry](https://opentelemetry.io/) is a vendor-neutral open-source project supported by the
[Cloud Native Computing Foundation](https://www.cncf.io/) that aims to standardize generating and collecting telemetry for
cloud-native software. In these examples, you'll collect and display distributed trace information on the console. To learn how to
configure OpenTelemetry to send information elsewhere, see the
[OpenTelemetry getting started guide](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/trace/getting-started-console/README.md).

### ASP.NET example

#### Prerequisites

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

#### Create an example application

First, create a new ASP.NET web app to use as the demo application.

```dotnetcli
dotnet new webapp
```

This app displays a web page, but no distributed tracing information is collected yet
if we browse the web page.

#### Configure collection

To use OpenTelemetry, you need to add references to several NuGet packages.

```dotnetcli
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.Console
dotnet add package OpenTelemetry.Extensions.Hosting
dotnet add package OpenTelemetry.Instrumentation.AspNetCore
```

Next, modify the source code in *Program.cs* so it looks like this:

```csharp
using OpenTelemetry;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddOpenTelemetry()
    .WithTracing(builder =>
    {
        builder.AddAspNetCoreInstrumentation();
        builder.AddConsoleExporter();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
```

Run the app and use a web browser to browse to the web page being hosted. Now that you enabled OpenTelemetry distributed
tracing, you should see information about the browser web requests printed to the console:

```
Activity.TraceId:            4510acfc49c6f8a582c6a40004df9a76
Activity.SpanId:             65fe2c5c15f05ed8
Activity.TraceFlags:         Recorded
Activity.ActivitySourceName: Microsoft.AspNetCore
Activity.DisplayName:        GET
Activity.Kind:               Server
Activity.StartTime:          2024-08-27T23:12:58.7837908Z
Activity.Duration:           00:00:00.1297070
Activity.Tags:
    server.address: localhost
    server.port: 5005
    http.request.method: GET
    url.scheme: http
    url.path: /
    network.protocol.version: 1.1
    user_agent.original: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36 Edg/127.0.0.0
    http.response.status_code: 200
Resource associated with Activity:
    telemetry.sdk.name: opentelemetry
    telemetry.sdk.language: dotnet
    telemetry.sdk.version: 1.9.0
    service.name: unknown_service:webapp
```

All of the OpenTelemetry configuration occurs in the new source lines that start with `builder.Services.AddOpenTelemetry()`. You used
`.WithTracing(...)` to enable distributed tracing. `AddAspNetCoreInstrumentation()` enabled OpenTelemetry to collect all the
distributed trace Activities that are produced by the ASP.NET Core web server, and `AddConsoleExporter()` instructs OpenTelemetry
to send that information to the console. For a less trivial app, you could add more instrumentation libraries to also collect
tracing for database queries or outbound HTTP requests. You'd also replace the console exporter with an exporter for Jaeger, Zipken, or
another monitoring service you've chosen to use.

### Console app example

#### Prerequisites

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

#### Create an example application

Before any distributed trace telemetry can be collected, you need to produce it. Often this instrumentation is
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

Replace the contents of the generated Program.cs with this example source:

```csharp
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
            using (Activity? a = s_source.StartActivity("SomeWork"))
            {
                await StepOne();
                await StepTwo();
            }
        }

        static async Task StepOne()
        {
            using (Activity? a = s_source.StartActivity("StepOne"))
            {
                await Task.Delay(500);
            }
        }

        static async Task StepTwo()
        {
            using (Activity? a = s_source.StartActivity("StepTwo"))
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

#### Configure collection

Add the [OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console/) NuGet package.

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Console
```

Update Program.cs with additional OpenTelemetry `using` directives:

```csharp
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
```

Update `Main()` to create the OpenTelemetry TracerProvider:

```csharp
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
Activity.TraceId:            48d7509cc4f06db6f48f2207f19c3918
Activity.SpanId:             406a1de6b5e8192e
Activity.TraceFlags:         Recorded
Activity.ParentSpanId:       345f5f98015b589a
Activity.ActivitySourceName: Sample.DistributedTracing
Activity.DisplayName:        StepOne
Activity.Kind:               Internal
Activity.StartTime:          2024-08-27T23:22:44.9900801Z
Activity.Duration:           00:00:00.5077426
Resource associated with Activity:
    service.name: MySample
    service.instance.id: a87f9e7d-d28c-4a91-9bb3-939a50cac7db
    telemetry.sdk.name: opentelemetry
    telemetry.sdk.language: dotnet
    telemetry.sdk.version: 1.9.0

Activity.TraceId:            48d7509cc4f06db6f48f2207f19c3918
Activity.SpanId:             458fb58342ca127a
Activity.TraceFlags:         Recorded
Activity.ParentSpanId:       345f5f98015b589a
Activity.ActivitySourceName: Sample.DistributedTracing
Activity.DisplayName:        StepTwo
Activity.Kind:               Internal
Activity.StartTime:          2024-08-27T23:22:45.5906581Z
Activity.Duration:           00:00:01.0023729
Resource associated with Activity:
    service.name: MySample
    service.instance.id: a87f9e7d-d28c-4a91-9bb3-939a50cac7db
    telemetry.sdk.name: opentelemetry
    telemetry.sdk.language: dotnet
    telemetry.sdk.version: 1.9.0

Activity.TraceId:            48d7509cc4f06db6f48f2207f19c3918
Activity.SpanId:             345f5f98015b589a
Activity.TraceFlags:         Recorded
Activity.ActivitySourceName: Sample.DistributedTracing
Activity.DisplayName:        SomeWork
Activity.Kind:               Internal
Activity.StartTime:          2024-08-27T23:22:44.9894135Z
Activity.Duration:           00:00:01.6059128
Resource associated with Activity:
    service.name: MySample
    service.instance.id: a87f9e7d-d28c-4a91-9bb3-939a50cac7db
    telemetry.sdk.name: opentelemetry
    telemetry.sdk.language: dotnet
    telemetry.sdk.version: 1.9.0

Example work done
```

##### Sources

In the example code, you invoked `AddSource("Sample.DistributedTracing")` so that OpenTelemetry would
capture the Activities produced by the ActivitySource that was already present in the code:

```csharp
static ActivitySource s_source = new ActivitySource("Sample.DistributedTracing");
```

Telemetry from any ActivitySource can be captured by calling `AddSource()` with the source's name.

##### Exporters

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

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

### Create an example application

First you will create an example application that has some distributed trace instrumentation but no trace data is being collected.

```dotnetcli
dotnet new console
```

Applications that target .NET 5 and later already have the necessary distributed tracing APIs included. For apps targeting older
.NET versions, add the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 5 or greater.

Replace the contents of the generated Program.cs with this example source:

```csharp
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
            using (Activity? a = s_source.StartActivity("SomeWork"))
            {
                await StepOne();
                await StepTwo();
            }
        }

        static async Task StepOne()
        {
            using (Activity? a = s_source.StartActivity("StepOne"))
            {
                await Task.Delay(500);
            }
        }

        static async Task StepTwo()
        {
            using (Activity? a = s_source.StartActivity("StepTwo"))
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

```csharp
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
