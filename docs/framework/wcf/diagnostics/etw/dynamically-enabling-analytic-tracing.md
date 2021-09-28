---
description: "Learn more about: Dynamically Enabling Analytic Tracing"
title: "Dynamically Enabling Analytic Tracing"
ms.date: "03/30/2017"
ms.assetid: 58b63cfc-307a-427d-b69d-9917ff9f44ac
---
# Dynamically Enabling Analytic Tracing

Using tools that ship with the Windows operating system, you can enable or disable tracing dynamically using Event Tracing for Windows (ETW). For all [!INCLUDE[netfx_current_long](../../../../../includes/netfx-current-long-md.md)] Windows Communication Foundation (WCF) services, analytic tracing can be enabled and disabled dynamically without modifying the application’s Web.config file or restarting the service. This allows the application that emits the trace events to remain undisturbed.  
  
 WCF tracing options can be configured in a similar way. For example, you can change the severity level from **Error** to **Information** without disturbing the application. This can be done using the following tools:  
  
- **Logman** – A command line tool for configuring, controlling, and querying tracing data. For more information, see [Logman Create Trace](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc788036(v=ws.10)) and [Logman Update Trace](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc788128(v=ws.10)).  
  
- **EventViewer** - Windows graphical management tool for viewing the results of tracing. For more information, see [WCF Services and Event Tracing for Windows](../../samples/wcf-services-and-event-tracing-for-windows.md) and [Event Viewer](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc766042(v=ws.11)).  
  
- **Perfmon** – Windows graphical management tool that uses counters to monitor tracing counters and the effects of tracing on performance. For more information, see [Create a Data Collector Set Manually](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc766404(v=ws.11)).  
  
### Keywords  

 When using the <xref:System.ServiceModel.Activation.Configuration.ServiceModelActivationSectionGroup.Diagnostics%2A> class, .NET Framework trace messages are generally filtered by the severity level (for example, Error, Warning, and Information). ETW supports the severity level concept, but introduces a new, flexible filter mechanism using keywords. Keywords are arbitrary textual values that let tracing events provide additional context about what that event means.  
  
 For WCF analytic tracing, each trace event has two types of keywords. First, each event has one or more scenario keywords. These keywords denote the scenarios that this event is intended to support. There are three scenario keywords, each designed for a specific purpose as shown in the following table. Filtering using keywords can be changed dynamically without disturbing the WCF service. That means that you can dynamically change your current tracing scenario and the amount of tracing information you gather. For example, you can change `HealthMonitoring` to `Troubleshooting` and increase Tracing Event granularity.  
  
|Keyword|Description|  
|-------------|-----------------|  
|`HealthMonitoring`|Very lightweight, minimal tracing that lets you monitor your service’s activity.|  
|`EndToEndMonitoring`|Events used to support message flow tracing.|  
|`Troubleshooting`|More granular events around the extensibility points of WCF.|  
  
 The second group of keywords define which component of the .NET Framework emitted the event.  
  
|Keyword|Description|  
|-------------|-----------------|  
|`UserEvents`|Events emitted by the user code and not the .NET Framework.|  
|`ServiceModel`|Events emitted by the WCF runtime.|  
|`ServiceHost`|Events emitted by the service host.|  
|`WCFMessageLogging`|WCF message logging events.|  
  
## See also

- [WCF Services and Event Tracing for Windows](../../samples/wcf-services-and-event-tracing-for-windows.md)
