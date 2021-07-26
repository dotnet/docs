---
description: "Learn more about: Analytic tracing overview"
title: "Analytic Tracing Overview"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "analytic tracing [WCF], overview"
ms.assetid: ae55e9cc-0809-442f-921f-d644290ebf15
---
# Analytic tracing overview

Analytic tracing in [!INCLUDE[netfx_current_long](../../../../../includes/netfx-current-long-md.md)] is a high performance and low verbosity tracing feature set on top of Event Tracing for Windows (ETW). ETW runs at the kernel-level to greatly reduce the overhead of tracing operations. It efficiently buffers user- and kernel-mode events, and allows dynamic enabling of logging without requiring service restarts. The tracing data is available in the event logs after it has been emitted and received.

For more information about ETW, see [Improve Debugging and Performance Tuning with ETW](/archive/msdn-magazine/2007/april/event-tracing-improve-debugging-and-performance-tuning-with-etw).

 In addition to using the Windows System, Security, and Application event logs to analyze application, Windows Vista and Windows Server 2008 introduced additional logs under the Applications and Services Logs top-level node. The purpose of these new logs is to store events for a particular application or specific component instead of global events that have a system-wide impact (such as the type of events that the Security event log might record). [!INCLUDE[netfx_current_short](../../../../../includes/netfx-current-short-md.md)] unifies and correlates the logging of WCF Trace Events, WCF Message Logs, and WF Tracking records to the Applications and Services Logs.

The following sections cover concepts and capabilities that apply to WCF analytic tracing.

## Enable WCF Diagnostics Settings

WCF diagnostics are enabled within the `<system.serviceModel><diagnostics>` configuration section.

```xml
<system.serviceModel>
  <diagnostics>
```

WCF diagnostic settings for a Web-hosted IIS virtual application are enabled in its *Web.config* file. Another option is to create a *Web.config* file in a subdirectory within the application. This choice applies the settings to all of the services within a subdirectory. To ensure that the diagnostics settings are initialized consistently for all services within the application, the settings should be within the *Web.config* file in the application directory and not in one of the individual subdirectories within the application.

## Channels

ETW allows software components to direct tracing events to a particular audience by use of channels. For example, you can send events for system administrators to one channel and events that application developers care about to another channel. Channels are named and registered with Windows so that consumers can view a channel's events using Event Viewer.

 The analytic tracing feature for WCF in [!INCLUDE[netfx_current_short](../../../../../includes/netfx-current-short-md.md)] writes to the Microsoft-Windows-Application-Server-Applications channel. This channel is designed for users who want to monitor the health of WCF services in production. It defines a small set of events that can be used in many health monitoring and troubleshooting scenarios.

 To enable the Event Tracing for Windows manifest so that messages are decoded properly in the event log, use the ServiceModelReg tool on the command line as follows:

 `ServiceModelReg.exe -i -c:etw`

## Dynamic Configuration

The ETW infrastructure allows tracing to be enabled and configured dynamically using standard Windows tools. For more information, see [Dynamically Enabling Analytic Tracing](dynamically-enabling-analytic-tracing.md).

## Message Flow Tracing

For more information about how to enable message flow tracing, see [Configuring Message Flow Tracing](configuring-message-flow-tracing.md).

## Keywords

Keywords are used to filter trace messages and define which component of the .NET Framework emitted the event. For more information, see [Dynamically Enabling Analytic Tracing](dynamically-enabling-analytic-tracing.md).
