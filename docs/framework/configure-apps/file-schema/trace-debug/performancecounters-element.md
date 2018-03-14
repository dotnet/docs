---
title: "&lt;performanceCounters&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.diagnostics/performanceCounters"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#performanceCounters"
helpviewer_keywords: 
  - "performanceCounters element"
  - "<perfomanceCounters> element"
ms.assetid: a71f605b-c7d9-4501-a5c3-abcbb964a43f
caps.latest.revision: 10
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;performanceCounters&gt; Element
Specifies the size of the global memory shared by performance counters.  
  
 \<configuration>  
\<system.diagnostics>  
\<performanceCounters>  
  
## Syntax  
  
```xml  
<performanceCounters filemappingsize="524288" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|filemappingsize|Required attribute.<br /><br /> Specifies the size, in bytes, of the global memory shared by performance counters. The default is 524288.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`Configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`system.diagnostics`|Specifies the root element for the ASP.NET configuration section.|  
  
## Remarks  
 Performance counters use a memory mapped file, or shared memory, to publish performance data.  The size of the shared memory determines how many instances can be used at once.  There are two types of shared memory: global shared memory and separate shared memory.  The global shared memory is used by all performance counter categories installed with the .NET Framework versions 1.0 or 1.1.  Performance counter categories installed with the .NET Framework version 2.0 use separate shared memory, with each performance counter category having its own memory.  
  
 The size of global shared memory can be set only with a configuration file.  The default size is 524,288 byes, the maximum size is 33,554,432 bytes, and the minimum size is 32,768 bytes.  Since the global shared memory is shared by all processes and categories, the first creator specifies the size.  If you define the size in your application configuration file, that size is only used if your application is the first application that causes the performance counters to execute.  Therefore the correct location to specify the `filemappingsize` value is the Machine.config file.  Memory in the global shared memory cannot be released by individual performance counters, so eventually global shared memory is exhausted if a large number of performance counter instances with different names are created.  
  
 For the size of separate shared memory, the DWORD FileMappingSize value in the registry key HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\\*\<category name>*\Performance is referenced first, followed by the value specified for the global shared memory in the configuration file. If the FileMappingSize value does not exist, then the separate shared memory size is set to one fourth (1/4) the global setting in the configuration file.  
  
## See Also  
 <xref:System.Diagnostics.PerformanceCounter>  
 <xref:System.Diagnostics.PerformanceCounterCategory>  
 <xref:System.Diagnostics.PerformanceCounter.InstanceLifetime%2A>  
 <xref:System.Diagnostics.PerformanceCounterInstanceLifetime>
