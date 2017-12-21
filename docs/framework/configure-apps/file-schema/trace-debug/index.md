---
title: "Trace and Debug Settings Schema"
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
  - "tracing [.NET Framework], trace and debug settings schema"
  - "configuration schema [.NET Framework], trace and debug settings"
  - "configuration settings [.NET Framework], tracing"
  - "schema configuration settings"
  - "configuration settings [.NET Framework], debugging"
  - "trace listeners, trace and debug settings schema"
  - "configuration sections [.NET Framework]"
  - "elements [.NET Framework], trace and debug settings"
ms.assetid: 277ca5f6-e1c4-41b6-a47f-3a67ce5b94ac
caps.latest.revision: 14
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Trace and Debug Settings Schema
Trace and debug settings specify trace listeners that collect, store, and route messages, and the level where a trace switch is set.  
  
 The following table describes the function of each trace and debug settings element.  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/add-element-for-listeners-for-source.md)|Adds a listener to the `Listeners` collection for a trace source.|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/add-element-for-listeners-for-trace.md)|Adds a listener to the `Listeners` collection.|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/add-element-for-sharedlisteners.md)|Adds a listener to the `sharedListeners` collection.|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/add-element-for-switches.md)|Specifies the level where a trace switch is set.|  
|[\<assert>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/assert-element.md)|Specifies whether to display a message box when you call the <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> method; also specifies the name of the file to write messages to.|  
|[\<clear>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/clear-element-for-listeners-for-source.md)|Clears the `Listeners` collection for a trace source.|  
|[\<clear>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/clear-element-for-listeners-for-trace.md)|Clears the `Listeners` collection for trace.|  
|[\<filter>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/filter-element-for-add-for-listeners-for-source.md)|Adds a filter to a listener in the `Listeners` collection for a trace source.|  
|[\<filter>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/filter-element-for-add-for-listeners-for-trace.md)|Adds a filter to a listener in the `Listeners` collection for trace.|  
|[\<filter>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/filter-element-for-add-for-sharedlisteners.md)|Adds a filter to a listener in the `sharedListeners` collection.|  
|[\<listeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/listeners-element-for-source.md)|Specifies listeners for the `Listeners` collection for a trace source.|  
|[\<listeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/listeners-element-for-trace.md)|Specifies listeners for the `Listeners` collection for trace.|  
|[\<performanceCounters>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/performancecounters-element.md)|Specifies the size of the global memory shared by performance counters.|  
|[\<remove>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/remove-element-for-listeners-for-trace.md)|Removes a listener from the `Listeners` collection for trace.|  
|[\<remove>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/remove-element-for-listeners-for-source.md)|Removes a listener from the `Listeners` collection for a trace source.|  
|[\<sharedListeners>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/sharedlisteners-element.md)|Contains listeners that any source or trace element can reference.|  
|[\<sources>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/sources-element.md)|Contains trace sources that initiate tracing messages.|  
|[\<source>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/source-element.md)|Specifies a trace source that initiates tracing messages.|  
|[\<switches>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/switches-element.md)|Contains trace switches and the level where the trace switches are set.|  
|[\<system.diagnostics>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/system-diagnostics-element.md)|Specifies trace listeners that collect, store, and route messages and the level where a trace switch is set.|  
|[\<trace>](../../../../../docs/framework/configure-apps/file-schema/trace-debug/trace-element.md)|Contains listeners that collect, store, and route tracing messages.|  
  
## See Also  
 <xref:System.Diagnostics.Trace>  
 <xref:System.Diagnostics.TraceSource>  
 <xref:System.Diagnostics.Debug>  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
