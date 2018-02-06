---
title: "&lt;GCCpuGroup&gt; Element"
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
  - "GCCpuGroup element"
  - "<GCCpuGroup> element"
ms.assetid: c1fc7d6c-7220-475c-a312-5b8b201f66e0
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;GCCpuGroup&gt; Element
Specifies whether garbage collection supports multiple CPU groups.  
  
 \<configuration>  
\<runtime>  
\<GCCpuGroup>  
  
## Syntax  
  
```xml  
<GCCpuGroup    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether garbage collection supports multiple CPU groups.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Garbage collection does not support multiple CPU groups. This is the default.|  
|`true`|Garbage collection supports multiple CPU groups, if server garbage collection is enabled.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 When a computer has multiple CPU groups and server garbage collection is enabled (see the [\<gcServer>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcserver-element.md) element), enabling this element extends garbage collection across all CPU groups and takes all cores into account when creating and balancing heaps.  
  
> [!NOTE]
>  This element applies only to garbage collection threads. To enable the runtime to distribute user threads across all CPU groups, you must also enable the [<Thread_UseAllCpuGroups>](../../../../../docs/framework/configure-apps/file-schema/runtime/thread-useallcpugroups-element.md) element.  
  
## Example  
 The following example shows how to enable garbage collection for multiple CPU groups.  
  
```xml  
<configuration>  
   <runtime>  
      <GCCpuGroup enabled="true"/>  
      <gcServer enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [How to: Disable Concurrent Garbage Collection](http://msdn.microsoft.com/library/ba2c6c67-5778-497c-9fac-5f793b5500c7)  
 [Workstation and server garbage collection](../../../../../docs/standard/garbage-collection/fundamentals.md#workstation_and_server_garbage_collection)
