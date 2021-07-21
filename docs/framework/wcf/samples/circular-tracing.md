---
description: "Learn more about: Circular Tracing"
title: "Circular Tracing"
ms.date: "03/30/2017"
ms.assetid: 5ff139f9-8806-47bc-8f33-47fe6c436b92
---
# Circular Tracing

The [CircularTracing sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the implementation of a circular buffer trace listener. A common scenario for production services is to have services that are available for long periods of time and to have trace logging enabled at a low level. These services consume a lot of disk space. When troubleshooting a service, the most recent data in the trace log is relevant to solving a problem. This sample demonstrates an implementation of a circular buffer trace listener in which only the most recent traces are kept on disk up to a configurable amount of data. This sample is based on the [Getting Started](getting-started-sample.md) and includes a custom tracing listener.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

This sample assumes that you are familiar with the [Tracing and Message Logging](tracing-and-message-logging.md) sample and have read the documentation provided for the [Tracing and Message Logging](tracing-and-message-logging.md) sample.

## Circular Buffer Trace Listener

The concept behind the implementation of the Circular Buffer Trace Listener is to have two files that can each store up to half of the total desired trace log data. The listener creates one file and writes to that file until it reaches the limit of half of the data size, at which point it switches to a second file. When the listener reaches the limit for the second file - it overwrites the first file with new traces.

This listener derives from the `XmlWriteTraceListener` and allows the logs to be viewed with the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../service-trace-viewer-tool-svctraceviewer-exe.md). When attempting to view the logs, the two log files can be easily recombined by opening both of the log files at the same time in the Service Trace Viewer tool. The Service Trace Viewer tool automatically takes care of sorting the traces so that they appear in the correct order.

## Configuration

A service can be configured to use the Circular Buffer Trace Listener by adding the following code for a listener and source elements. The max file size is specified by setting the `maxFileSizeKB` attribute in the circular trace listener's configuration. This is demonstrated in the following code.

```xml
<system.diagnostics>
  <sources>
    <source name="System.ServiceModel" switchValue="Information,ActivityTracing" propagateActivity="true">
      <listeners>
        <add name="CircularTraceListener" />
      </listeners>
    </source>
  </sources>
  <sharedListeners>
    <add name="CircularTraceListener" type="Microsoft. Samples.ServiceModel.CircularTraceListener,CircularTraceListener"
         initializeData="c:\logs\CircularTracing-service.svclog" maxFileSizeKB="100" />
  </sharedListeners>
  <trace autoflush="true" />
</system.diagnostics>
```

#### To set up, build, and run the sample

1. Be sure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
