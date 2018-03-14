---
title: "&lt;gcConcurrent&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/gcConcurrent"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#gcConcurrent"
helpviewer_keywords: 
  - "container tags, <gcConcurrent> element"
  - "gcConcurrent element"
  - "<gcConcurrent> element"
ms.assetid: 503f55ba-26ed-45ac-a2ea-caf994da04cd
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;gcConcurrent&gt; Element
Specifies whether the common language runtime runs garbage collection on a separate thread.  
  
 \<configuration>  
\<runtime>  
\<gcConcurrent>  
  
## Syntax  
  
```xml  
<gcConcurrent    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime runs garbage collection concurrently.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Does not run garbage collection concurrently.|  
|`true`|Runs garbage collection concurrently. This is the default.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 Prior to the .NET Framework 4, workstation garbage collection supported concurrent garbage collection, which performed garbage collection in the background on a separate thread. In the .NET Framework 4, concurrent garbage collection was replaced by background GC, which also performs garbage collection in the background on a separate thread. Starting with the .NET Framework 4.5, background collection became available in server garbage collection. The `<gcConcurrent>` element controls whether the runtime performs either concurrent or background garbage collection, if it is available, or whether it performs garbage collection in the foreground.  
  
> [!WARNING]
>  Starting with the .NET Framework 4, concurrent garbage collection is replaced by background garbage collection. The terms *concurrent* and *background* are used interchangeably in the .NET Framework documentation. To disable background garbage collection, use the `<gcConcurrent>` element, as discussed in this article.  
  
 By default, the runtime uses concurrent or background garbage collection, which is optimized for latency. If your application involves heavy user interaction, leave concurrent garbage collection enabled to minimize the application's pause time to perform garbage collection. If you set the `enabled` attribute of the `<gcConcurrent>` element to `false`, the runtime uses non-concurrent garbage collection, which is optimized for throughput. The following configuration file disables background garbage collection.  
  
```xml  
<configuration>  
   <runtime>  
      <gcConcurrent enabled="false"/>  
   </runtime>  
</configuration>  
```  
  
 If there is a `<gcConcurrentSetting>` setting in the machine configuration file, it defines the default value for all .NET Framework applications. The machine configuration file setting overrides the application configuration file setting.  
  
 For more information on concurrent and background garbage collection, see the "Concurrent garbage collection" section in the [Fundamentals of Garbage Collection](../../../../../docs/standard/garbage-collection/fundamentals.md) topic.  
  
## Example  
 The following example enables concurrent garbage collection.  
  
```xml  
<configuration>  
   <runtime>  
      <gcConcurrent enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Fundamentals of Garbage Collection](../../../../../docs/standard/garbage-collection/fundamentals.md)
