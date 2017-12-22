---
title: "&lt;Thread_UseAllCpuGroups&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d30fe7c5-8469-46e2-b804-e3eec7b24256
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;Thread_UseAllCpuGroups&gt; Element
Specifies whether the runtime distributes managed threads across all CPU groups.  
  
 \<configuration>  
\<runtime>  
<Thread_UseAllCpuGroups>  
  
## Syntax  
  
```xml
<Thread_UseAllCpuGroups    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime distributes managed threads across all CPU groups.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|The runtime does not distribute managed threads across multiple CPU groups. This is the default.|  
|`true`|The runtime distributes managed threads across multiple CPU groups, if the computer has multiple CPU groups and the [\<GCCpuGroup>](../../../../../docs/framework/configure-apps/file-schema/runtime/gccpugroup-element.md) element is enabled.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 When a computer has multiple CPU groups, enabling this element causes the runtime to distribute managed threads across all CPU groups. To use this feature, you must also enable the [\<GCCpuGroup>](../../../../../docs/framework/configure-apps/file-schema/runtime/gccpugroup-element.md) element, which extends garbage collection to all CPU groups and takes all cores into account when creating and balancing heaps. Enabling the [\<GCCpuGroup>](../../../../../docs/framework/configure-apps/file-schema/runtime/gccpugroup-element.md) element requires enabling the [\<gcServer>](../../../../../docs/framework/configure-apps/file-schema/runtime/gcserver-element.md) element. If these elements are not enabled, enabling the `<Thread_UseAllCpuGroups>` element has no effect.  
  
## Example  
 The following example shows how to enable support for multiple CPU groups.  
  
```xml  
<configuration>  
   <runtime>  
      <Thread_UseAllCpuGroups enabled="true"/>  
      <GCCpuGroup enabled="true"/>  
      <gcServer enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<GCCpuGroup> Element](../../../../../docs/framework/configure-apps/file-schema/runtime/gccpugroup-element.md)
