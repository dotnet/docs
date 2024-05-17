---
title: "Tracing and Message Logging"
description: Learn how to use the Service Trace Viewer Tool (SvcTraceViewer.exe) to view traces and message logs by using this WFC sample.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Tracing and logging"
ms.assetid: a4f39bfc-3c5e-4d51-a312-71c5c3ce0afd
---
# Tracing and Message Logging

The [TracingAndLogging sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to enable tracing and message logging. The resulting traces and message logs are viewed using the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../service-trace-viewer-tool-svctraceviewer-exe.md). This sample is based on the [Getting Started](getting-started-sample.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

## Tracing

Windows Communication Foundation (WCF) uses the tracing mechanism defined in the <xref:System.Diagnostics> namespace. In this tracing model, trace data is produced by trace sources that applications implement. Each source is identified by a name. Trace consumers create trace listeners for the trace sources for which they want to retrieve information. To receive trace data, you must create a listener for the trace source. In WCF, this can be done by adding the following code to either the service's or client's configuration file by setting the Service Model trace source `switchValue`:

```xml
<system.diagnostics>
    <sources>
      <source name="System.ServiceModel" switchValue="Information,ActivityTracing"
        propagateActivity="true">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
      <source name="System.ServiceModel.MessageLogging">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData="C:\logs\TracingAndLogging-service.svclog" type="System.Diagnostics.XmlWriterTraceListener"
        name="xml" />
    </sharedListeners>
    <trace autoflush="true" />
</system.diagnostics>
```

For more information about trace sources, see the Trace Source section in the [Configuring Tracing](../diagnostics/tracing/configuring-tracing.md) topic.

## Activity Tracing and Propagation

Having `ActivityTracing` enabled and `propagateActivity` set to `true` in the `system.ServiceModel` trace sources for both the client and service provide correlation of traces within logical units of processing (activities), across activities within endpoints (through activity transfers), and across activities spanning multiple endpoints (through activity ID propagation).

These three mechanisms (activities, transfers, and propagation) can help you locate the root cause of an error more quickly using the Service Trace Viewer tool. For more information, see [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md).

It is possible to extend the tracing that is provided by the ServiceModel by creating user-defined activity traces. User-defined activity tracing allows the user to create trace activities to:

- Group traces into logical units of work.

- Correlate activities through transfers and propagation.

- Lessen the performance cost of WCF tracing (for example, the disk space cost of a log file).

For more information about user-defined activity trace, please see the [Extending Tracing](extending-tracing.md) sample.

## Message Logging

Message logging can be enabled both on the client and service of any WCF application. To enable message logging, you must add the following code to either the client or service:

```xml
<configuration>
  <system.serviceModel>
    <diagnostics>
      <!-- Enable Message Logging here. -->
      <!-- log all messages received or sent at the transport or service model levels -->
      <messageLogging logEntireMessage="true"
                      maxMessagesToLog="300"
                      logMessagesAtServiceLevel="true"
                      logMalformedMessages="true"
                      logMessagesAtTransportLevel="true" />
    </diagnostics>
  </system.serviceModel>
</configuration>
```

When a message is recorded, the trace type depends on whether it is being traced at the client or the server. For example, an "Add" message that is sent to a client is traced under the "TransportWrite" category at the client, whereas the same message is traced under the "TransportRead" category at the service.

Configure the trace listener by adding the following code to the <xref:System.Diagnostics> section of the client's App.config file or the service's Web.config file:

```xml
<system.diagnostics>
    <sources>
      <source name="System.ServiceModel" switchValue="Information,ActivityTracing"
        propagateActivity="true">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
      <source name="System.ServiceModel.MessageLogging">
        <listeners>
          <add name="xml" />
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData="C:\logs\TracingAndLogging-client.svclog" type="System.Diagnostics.XmlWriterTraceListener"
        name="xml" />
    </sharedListeners>
    <trace autoflush="true" />
  </system.diagnostics>
```

Messages are logged in XML format in the target directory specified in the configuration file.

> [!NOTE]
> Trace files are not created without initially creating the log directory. Make sure that the directory C:\logs\ exists, or specify an alternate logging directory in the listener configuration. See the initial setup instructions at the end of this document for more information.

For more information about message logging, see the [Configuring Message Logging](../diagnostics/configuring-message-logging.md) topic.

#### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Before running the Tracing and Message Logging sample, create the directory C:\logs\ for the service to write the .svclog files to. The name of this directory is defined in the configuration file as the path for the traces and messages to be logged and can be changed. Give the user Network Service write access to the logs directory.

3. To build the C#, C++, or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- [Tracing](../diagnostics/tracing/index.md)
- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
