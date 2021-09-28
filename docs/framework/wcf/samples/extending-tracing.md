---
description: "Learn more about: Extend tracing"
title: "Extending Tracing"
ms.date: "03/30/2017"
ms.assetid: 2b971a99-16ec-4949-ad2e-b0c8731a873f
---
# Extend tracing

The [ExtendingTracing sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to extend the Windows Communication Foundation (WCF) tracing feature by writing user-defined activity traces in client and service code. Writing user-defined activity traces allows the user to create trace activities and group traces into logical units of work. It is also possible to correlate activities through transfers (within the same endpoint) and propagation (across endpoints). In this sample, tracing is enabled for both the client and the service. For more information about how to enable tracing in client and service configuration files, see [Tracing and Message Logging](tracing-and-message-logging.md).

This sample is based on the [Getting Started](getting-started-sample.md).

> [!NOTE]
> The set-up procedure and build instructions for this sample are located at the end of this topic.

## Tracing and Activity Propagation

User-defined activity tracing allows the user to create their own trace activities to group traces into logical units of work, correlate activities through transfers and propagation, and lessen the performance cost of WCF tracing (for example, the disk space cost of a log file).

### Add custom sources

User-defined traces can be added to both client and service code. Adding trace sources to the client or service configuration files allows for these custom traces to be recorded and displayed in the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../service-trace-viewer-tool-svctraceviewer-exe.md). The following code shows how to add a user-defined trace source named `ServerCalculatorTraceSource` to the configuration file.

```xml
<system.diagnostics>
    <sources>
        <source name="System.ServiceModel" switchValue="Warning" propagateActivity="true">
            <listeners>
                <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                    <filter type="" />
                </add>
                <add name="xml">
                    <filter type="" />
                </add>
            </listeners>
        </source>
        <source name="ServerCalculatorTraceSource" switchValue="Information,ActivityTracing">
            <listeners>
                <add type="System.Diagnostics.DefaultTraceListener" name="Default">
                    <filter type="" />
                </add>
                <add name="xml">
                    <filter type="" />
                </add>
            </listeners>
        </source>
    </sources>
    <sharedListeners>
       <add initializeData="C:\logs\ServerTraces.svclog" type="System.Diagnostics.XmlWriterTraceListener"
        name="xml" traceOutputOptions="Callstack">
            <filter type="" />
        </add>
    </sharedListeners>
    <trace autoflush="true" />
</system.diagnostics>
....
```

### Correlate activities

To correlate activities directly across endpoints, the `propagateActivity` attribute must be set to `true` in the `System.ServiceModel` trace source. Also, to propagate traces without going through WCF activities, ServiceModel Activity Tracing must be turned off. This can be seen in the following code example.

> [!NOTE]
> Turning off ServiceModel Activity Tracing is not the same as having the trace level, denoted by the `switchValue` property, set to off.

```xml
<system.diagnostics>
    <sources>
      <source name="System.ServiceModel" switchValue="Warning" propagateActivity="true">

    ...

       </source>
    </sources>
</system.diagnostics>
```

### Lessen performance cost

Setting `ActivityTracing` to off in the `System.ServiceModel` trace source generates a trace file that contains only user-defined activity traces, without any of the ServiceModel activity traces included. Excluding ServiceModel activity traces results in a much smaller log file. However, the opportunity to correlate WCF processing traces is lost.

## Set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
