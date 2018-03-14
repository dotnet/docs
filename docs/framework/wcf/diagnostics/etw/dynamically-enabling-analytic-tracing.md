---
title: "Dynamically Enabling Analytic Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 58b63cfc-307a-427d-b69d-9917ff9f44ac
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Dynamically Enabling Analytic Tracing
Using tools that ship with the Windows operating system, you can enable or disable tracing dynamically using Event Tracing for Windows (ETW). For all [!INCLUDE[netfx_current_long](../../../../../includes/netfx-current-long-md.md)] [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] services, analytic tracing can be enabled and disabled dynamically without modifying the application’s Web.config file or restarting the service. This allows the application that emits the trace events to remain undisturbed.  
  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] tracing options can be configured in a similar way. For example, you can change the severity level from **Error** to **Information** without disturbing the application. This can be done using the following tools:  
  
-   **Logman** – A command line tool for configuring, controlling, and querying tracing data. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Logman Create Trace](http://go.microsoft.com/fwlink/?LinkId=165426) and [Logman Update Trace](http://go.microsoft.com/fwlink/?LinkId=165427).  
  
-   **EventViewer** - Windows graphical management tool for viewing the results of tracing. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [WCF Services and Event Tracing for Windows](../../../../../docs/framework/wcf/samples/wcf-services-and-event-tracing-for-windows.md) and [Event Viewer](http://go.microsoft.com/fwlink/?LinkId=165428).  
  
-   **Perfmon** – Windows graphical management tool that uses counters to monitor tracing counters and the effects of tracing on performance. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Create a Data Collector Set Manually](http://go.microsoft.com/fwlink/?LinkId=165429).  
  
### Keywords  
 When using the <xref:System.ServiceModel.Activation.Configuration.ServiceModelActivationSectionGroup.Diagnostics%2A> class, .NET Framework trace messages are generally filtered by the severity level (for example, Error, Warning, and Information). ETW supports the severity level concept, but introduces a new, flexible filter mechanism using keywords. Keywords are arbitrary textual values that let tracing events provide additional context about what that event means.  
  
 For [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] analytic tracing, each trace event has two types of keywords. First, each event has one or more scenario keywords. These keywords denote the scenarios that this event is intended to support. There are three scenario keywords, each designed for a specific purpose as shown in the following table. Filtering using keywords can be changed dynamically without disturbing the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service. That means that you can dynamically change your current tracing scenario and the amount of tracing information you gather. For example, you can change `HealthMonitoring` to `Troubleshooting` and increase Tracing Event granularity.  
  
|Keyword|Description|  
|-------------|-----------------|  
|`HealthMonitoring`|Very lightweight, minimal tracing that lets you monitor your service’s activity.|  
|`EndToEndMonitoring`|Events used to support message flow tracing.|  
|`Troubleshooting`|More granular events around the extensibility points of [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)].|  
  
 The second group of keywords define which component of the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] emitted the event.  
  
|Keyword|Description|  
|-------------|-----------------|  
|`UserEvents`|Events emitted by the user code and not the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)].|  
|`ServiceModel`|Events emitted by the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] runtime.|  
|`ServiceHost`|Events emitted by the service host.|  
|`WCFMessageLogging`|[!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] message logging events.|  
  
## See Also  
 [WCF Services and Event Tracing for Windows](../../../../../docs/framework/wcf/samples/wcf-services-and-event-tracing-for-windows.md)
