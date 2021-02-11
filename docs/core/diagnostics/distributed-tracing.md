---
title: Distributed tracing - .NET
description: An introduction to .NET distributed tracing.
ms.date: 02/02/2021
---
# .NET Distributed Tracing

Distributed tracing is the way to publish and observe tracing data in a distributed system.
.NET Framework and .NET Core has been supporting tracing through the <xref:System.Diagnostics> APIs.

- <xref:System.Diagnostics.Activity?displayProperty=nameWithType> class which allows storing and accessing diagnostics context and consuming it with logging system.
- <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> that allows code to be instrumented for production-time logging of rich data payloads for consumption within the process that was instrumented.

Here is an example that shows how to publish tracing data from the HTTP incoming requests:

```csharp
   public void OnIncomingRequest(DiagnosticListener httpListener, HttpContext context)
   {
       if (httpListener.IsEnabled("Http_In"))
       {
           var activity = new Activity("Http_In");

           //add tags, baggage, etc.
           activity.SetParentId(context.Request.headers["Request-id"])
           foreach (var pair in context.Request.Headers["Correlation-Context"])
           {
               var baggageItem = NameValueHeaderValue.Parse(pair);
               activity.AddBaggage(baggageItem.Key, baggageItem.Value);
           }
           httpListener.StartActivity(activity, new { context });
           try
           {
               //process request ...
           }
           finally
           {
               //stop activity
               httpListener.StopActivity(activity, new {context} );
           }
       }
   }
```

Here is example for how to listen to the Activity events:

```csharp
    DiagnosticListener.AllListeners.Subscribe(delegate (DiagnosticListener listener)
    {
        if (listener.Name == "MyActivitySource")
        {
            listener.Subscribe(delegate (KeyValuePair<string, object> value)
            {
                if (value.Key.EndsWith("Start", StringComparison.Ordinal))
                    LogActivityStart();
                else if (value.Key.EndsWith("Stop", StringComparison.Ordinal))
                    LogActivityStop();
            });
        }
    }
```

.NET 5.0 has extended the capability of the distributed tracing to allow the [OpenTelemetry](https://opentelemetry.io/) tracing scenarios, added Sampling capabilities, simplified the tracing coding pattern, and made listening to the Activity events easier and flexible.

> [!NOTE]
> To access all added .NET 5.0 capabilities, ensure your project references the [System.Diagnostics.DiagnosticSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/) NuGet package version 5.0 or later. This package can be used in libraries and apps targeting any supported version of the .NET Framework, .NET Core, and .NET Standard. If targeting .NET 5.0 or later, there is no need to manually reference the package as it is included in the shared library installed with the .NET Runtime.

## Getting Started With Tracing

Applications and libraries can easily publish tracing data by simply using the <xref:System.Diagnostics.ActivitySource?displayProperty=nameWithType> and the <xref:System.Diagnostics.Activity?displayProperty=nameWithType> classes.

### ActivitySource

The first step to publish tracing data is to create an instance of the ActivitySource class. The ActivitySource is the class that provides APIs to create and start Activity objects and to register ActivityListener objects to listen to the Activity events.

```csharp
    private static ActivitySource source = new ActivitySource("MyCompany.MyComponent.SourceName", "v1");
```

#### Best Practices

- Create the ActivitySource once and store it in a static variable and use that instance as long as needed.

- The source name passed to the constructor has to be unique to avoid the conflicts with any other sources. It is recommended to use a hierarchical name contains the company name, the component name, and the source name. For example, `Microsoft.System.HttpClient.HttpInOutRequests`.

- The version parameter is optional. It is recommended to provide the version in case you plan to release multiple versions of the library or the application and want to distinguish between the sources of different versions.

### Activity Creation

Now the created ActivitySource object can be used to create and start Activity objects which are used to log any tracing data in any desired places in the code.

```csharp
        using (Activity activity = source.StartActivity("OperationName"))
        {
            // Do something

            activity?.AddTag("key", "value"); // log the tracing
        }
```

This sample code tries to create the Activity object and then logs some tracing tag `key` and `value`.

#### Notes

- `ActivitySource.StartActivity` tries to create and start the activity at the same time. The listed code pattern is using the `using` block which automatically disposes the created Activity object after executing the block. Disposing the Activity object will stop this started activity and the code doesn't have to explicitly stop the activity. That simplifies the coding pattern.

- `ActivitySource.StartActivity` internally figures out if there are any listeners to such events. If there are no registered listeners or there are listeners which are not interested in such an event, `ActivitySource.StartActivity` simply will return `null` and avoid creating the Activity object. That is why the code used the nullable operator `?`  in the statement `activity?.AddTag`. In general, inside the `using` block, always use the nullable operator `?` after the activity object name.

## Listening to the Activity Events

.NET provides the class <xref:System.Diagnostics.ActivityListener?displayProperty=nameWithType> which can be used to listen to the Activity events triggered from one or more ActivitySources.
The listener can be used to collect tracing data, sample, or force creating the Activity object.

The `ActivityListener` class provides a different callbacks to handle different events.

```csharp

ActivityListener listener = new ActivityListener()

ShouldListenTo = (activitySource) => object.ReferenceEquals(source, activitySource),
ActivityStarted = activity => /* Handle the Activity start event here */ DoSomething(),
ActivityStopped = activity => /* Handle the Activity stop event here */ DoSomething(),
SampleUsingParentId = (ref ActivityCreationOptions<string> activityOptions) => ActivitySamplingResult.AllData,
Sample = (ref ActivityCreationOptions<ActivityContext> activityOptions) => ActivitySamplingResult.AllData

// Enable the listener
ActivitySource.AddActivityListener(listener);
```

- `ShouldListenTo` enables listening to specific `ActivitySource` objects. In the example, it enables listening to the `ActivitySource` object we have previously created. There is more flexibility to listen to any other `ActivitySource` objects by checking the `Name` and `Version` of the input `ActivitySource`.

- `ActivityStarted` and `ActivityStopped` enable getting the `Activity` Start and Stop events for all `Activity` objects created by the `ActivitySource` objects which were enabled by the `ShouldListenTo` callback.

- `Sample` and `SampleUsingParentId` are the main callbacks which intended for sampling. These two callbacks return the `ActivitySamplingResult` enum value which can tell either to sample in or out the current `Activity` creation request. If the callback returns `ActivitySamplingResult.None` and no other enabled listeners return different value, then the Activity will not get created and `ActivitySource.StartActivity` will return `null`. Otherwise, the `Activity` object will get created.

## .NET 5.0 New Features

For awhile the `Activity` class has been supporting tracing scenarios. It allowed adding tags which are key-value pairs of tracing data. It has been supporting Baggage which is are key-value pairs intended to be propagated across the wire.

.NET 5.0 supports more features mainly to enable OpenTelemetry scenarios.

### ActivityContext

<xref:System.Diagnostics.ActivityContext?displayProperty=nameWithType> is the struct carrying the context of the tracing operations (e.g. the trace Id, Span Id, trace flags, and trace state). Now it is possible to create a new `Activity` providing the parent tracing context. Also, it is easy to extract the tracing context from any `Activity` object by calling `Activity.Context` property.

### ActivityLink

<xref:System.Diagnostics.ActivityLink?displayProperty=nameWithType> is the struct containing the tracing context instance which can be linked to casually related `Activity` objects. Links can be added to the `Activity` object by passing the links list to `ActivitySource.StartActivity` method when creating the `Activity`. The `Activity` object attached links can be retrieved using the property `Activity.Links`.

### ActivityEvent

<xref:System.Diagnostics.ActivityEvent?displayProperty=nameWithType> represents an event containing a name and a timestamp, as well as an optional list of tags. Events can be added to the `Activity` object by calling `Activity.AddEvent` method. The whole list of the `Activity` object Events can be retrieved using the property `Activity.Events`.

### ActivityKind

<xref:System.Diagnostics.ActivityKind?displayProperty=nameWithType> describes the relationship between the activity, its parents and its children in a trace. Kind can be set to the `Activity` object by passing the kind value to `ActivitySource.StartActivity` method when creating the `Activity`. The `Activity` object kind can be retrieved using the property `Activity.Kind`.

### IsAllDataRequested

<xref:System.Diagnostics.Activity.IsAllDataRequested?displayProperty=nameWithType> indicates whether this activity should be populated with all the propagation information, as well as all the other properties, such as links, tags, and events. The value of `IsAllDataRequested` is determined from the result returned from all listeners `Sample` and `SampleUsingParentId` callbacks. The value can be retrieved using `Activity.IsAllDataRequested` property.

### Activity.Source

<xref:System.Diagnostics.Activity.Source?displayProperty=nameWithType> gets the activity source associated with this activity.

### Activity.DisplayName

<xref:System.Diagnostics.Activity.DisplayName?displayProperty=nameWithType> allows getting or setting a display name for the activity.

### Activity.TagObjects

`Activity` class has the property `Activity.Tags` which return the a key-value pair list of the tags of type string for the key and value. Such Tags can be added to the `Activity` using the method `AddTag(string, string)`. `Activity` has extended the support of tags by providing the overloaded method `AddTag(string, object)` allowing values of any type.  The complete list of such tags can be retrieved using <xref:System.Diagnostics.Activity.TagObjects?displayProperty=nameWithType>.

## Sampling

Sampling is a mechanism to control the noise and overhead by reducing the number of samples of traces collected and sent to the backend. Sampling is an important OpenTelemetry scenario. In .NET 5.0 it is easy to allow sampling. A good practice is to create the new `Activity` objects using `ActivitySource.StartActivity` and try to provide all possible available data (e.g. tags, kind, links, ...etc.) when calling this method. Providing the data will allow the samplers implemented using the `ActivityListener` to have a proper sampling decision. If the performance is critical to avoid creating the data before creating the `Activity` object, the property `ActivitySource.HasListeners` comes in handy to check if there are any listeners before creating the needed data.

## OpenTelemetry

OpenTelemetry SDK comes with many features that support end-to-end distributed tracing scenarios. It provides multiple samplers and exporters which you can choose from. It allows creating a custom samplers and exporters too.

OpenTelemetry supports exporting the collected tracing data to different backends (e.g. Jaeger, Zipkin, New Relic,...etc.). Refer to [OpenTelemetry-dotnet](https://github.com/open-telemetry/opentelemetry-dotnet/) for more details and search Nuget.org for packages starting with `OpenTelemetry.Exporter.` to get the exporter packages list.

Here is sample code ported from [OpenTelemetry-dotnet getting started](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/trace/getting-started) showing how easy it is to sample and export tracing data to the console.

```csharp
// <copyright file="Program.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;

public class Program
{
    private static readonly ActivitySource MyActivitySource = new ActivitySource(
        "MyCompany.MyProduct.MyLibrary");

    public static void Main()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetSampler(new AlwaysOnSampler())
            .AddSource("MyCompany.MyProduct.MyLibrary")
            .AddConsoleExporter()
            .Build();

        using (var activity = MyActivitySource.StartActivity("SayHello"))
        {
            activity?.SetTag("foo", 1);
            activity?.SetTag("bar", "Hello, World!");
            activity?.SetTag("baz", new int[] { 1, 2, 3 });
        }
    }
}
```

The sample needs to reference the package [OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console/1.0.0-rc2).
