---
title: "Analytic Tracing Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "analytic tracing [WCF], overview"
ms.assetid: ae55e9cc-0809-442f-921f-d644290ebf15
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Analytic Tracing Overview
Analytic tracing in [!INCLUDE[netfx_current_long](../../../../../includes/netfx-current-long-md.md)] is a high performance and low verbosity tracing feature set on top of Event Tracing for Windows (ETW). ETW runs at the kernel-level to greatly reduce the overhead of tracing operations. It efficiently buffers user- and kernel-mode events, and allows dynamic enabling of logging without requiring service restarts. The tracing data is available in the event logs after it has been emitted and received.  
  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] ETW, see [Improve Debugging and Performance Tuning with ETW](http://go.microsoft.com/fwlink/?LinkId=164781).  
  
 In addition to using the Windows System, Security, and Application event logs to analyze application, [!INCLUDE[wv](../../../../../includes/wv-md.md)] and [!INCLUDE[lserver](../../../../../includes/lserver-md.md)] introduced additional logs under the Applications and Services Logs top-level node. The purpose of these new logs is to store events for a particular application or specific component instead of global events that have a system-wide impact (such as the type of events that the Security event log might record). [!INCLUDE[netfx_current_short](../../../../../includes/netfx-current-short-md.md)] unifies and correlates the logging of [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] Trace Events, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] Message Logs, and [!INCLUDE[wf1](../../../../../includes/wf1-md.md)] Tracking records to the Applications and Services Logs.  
  
## Concepts and Capabilities  
 The following concepts and capabilities apply to [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] Analytic Tracing.  
  
### Enabling WCF Diagnostics Settings  
 WCF diagnostics are enabled within the \<system.serviceModel>\<diagnostics> configuration section.  
  
```xml  
<system.serviceModel>  
  <diagnostics>  
```  
  
 WCF diagnostic settings for a Web-hosted IIS virtual application are enabled in its’ Web.config file. Another option is to create a Web.config in a sub-directory within the application.  This choice applies the settings to all of the services within a sub-directory.  To ensure that the diagnostics settings are initialized consistently for all services within the application, the settings should be within the Web.config in the application directory and not in one of the individual sub-directories within the application.  
  
### Channels  
 ETW allows software components to direct tracing events to a particular audience by use of channels. For example, you can send events for system administrators to one channel, and events that application developers care about to another channel. Channels are named and registered with Windows so that consumers can view a channel’s events using the Event Viewer.  
  
 The analytic tracing feature for [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] in [!INCLUDE[netfx_current_short](../../../../../includes/netfx-current-short-md.md)] writes to the Microsoft-Windows-Application-Server-Applications channel. This channel is specifically designed for users who want to monitor the health of [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] services in production. It defines a small, set of events that can be used in many health monitoring and troubleshooting scenarios.  
  
 To enable the Event Tracing for Windows manifest so that messages are decoded properly in the event log, use the ServiceModelReg tool on the command line as follows:  
  
 `ServiceModelReg.exe -i -c:etw`  
  
### Dynamic Configuration  
 The ETW infrastructure allows tracing to be enabled and configured dynamically using standard Windows tools. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Dynamically Enabling Analytic Tracing](../../../../../docs/framework/wcf/diagnostics/etw/dynamically-enabling-analytic-tracing.md).  
  
### Message Flow Tracing  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] how to enable message flow tracing, see [Configuring Message Flow Tracing](../../../../../docs/framework/wcf/diagnostics/etw/configuring-message-flow-tracing.md).  
  
### Keywords  
 Keywords are used to filter trace messages and define which component of the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] emitted the event. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Dynamically Enabling Analytic Tracing](../../../../../docs/framework/wcf/diagnostics/etw/dynamically-enabling-analytic-tracing.md).
