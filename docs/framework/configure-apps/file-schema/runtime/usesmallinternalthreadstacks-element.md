---
title: "&lt;UseSmallInternalThreadStacks&gt; Element"
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
  - "UseSmallInternalThreadStacks element"
  - "<UseSmallInternalThreadStacks> element"
ms.assetid: 1e3f6ec0-1cac-4e1c-9c81-17d948ae5874
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;UseSmallInternalThreadStacks&gt; Element
Requests that the common language runtime (CLR) reduce memory use by specifying explicit stack sizes when it creates certain threads that it uses internally, instead of using the default stack size for those threads.  
  
 \<configuration> Element  
\<runtime> Element  
\<UseSmallInternalThreadStacks> Element  
  
## Syntax  
  
```xml  
<UseSmallInternalThreadStacks enabled="true|false" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether to request that the CLR use explicit stack sizes instead of the default stack size when it creates certain threads that it uses internally. The explicit stack sizes are smaller than the default stack size of 1 MB.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|true|Request explicit stack sizes.|  
|false|Use the default stack size. This is the default for the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)].|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 This configuration element is used to request reduced virtual memory use in a process, because the explicit thread sizes that the CLR uses for its internal threads, if the request is honored, are smaller than the default size.  
  
> [!IMPORTANT]
>  This configuration element is a request to the CLR rather than an absolute requirement. In the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)], the request is honored only for the x86 architecture. This element might be ignored completely in future versions of the CLR, or replaced by explicit stack sizes that are always used for selected internal threads.  
  
 Specifying this configuration element trades reliability for smaller virtual memory use if the CLR honors the request, because smaller stack sizes could potentially make stack overflows more likely.  
  
## Example  
 The following example shows how to request that the CLR use explicit stack sizes for certain threads that it uses internally.  
  
```xml  
<configuration>  
   <runtime>  
      <UseSmallInternalThreadStacks enabled="true" />  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
