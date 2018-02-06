---
title: "&lt;etwEnable&gt; Element"
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
  - "etwEnable element"
  - "<etwEnable> element"
ms.assetid: 29dde982-6d8b-4099-8867-ad0d7733f6dc
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;etwEnable&gt; Element
Specifies whether to enable event tracing for Windows (ETW) for common language runtime events.  
  
 \<configuration> Element  
\<runtime> Element  
\<etwEnabled>  
  
## Syntax  
  
```xml  
<etwEnable enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether ETW should be enabled.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|true|Enable ETW. This is the default for versions of Windows beginning with the Windows Vista and Windows Server 2008 operating systems.|  
|false|Disable ETW. This is the default for earlier versions of Windows.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 Beginning with Windows Vista, ETW is enabled by default. Use this element to disable ETW for an application. In earlier versions of Windows, use this element to enable ETW for an application.  
  
> [!NOTE]
>  ETW can be enabled or disabled globally on a server by using a registry setting. See [Controlling .NET Framework Logging](../../../../../docs/framework/performance/controlling-logging.md).  
  
## Example  
 The following example shows how to enable ETW tracing for an application.  
  
```xml  
<configuration>  
   <runtime>  
      <etwEnable enabled="true" />  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Controlling .NET Framework Logging](../../../../../docs/framework/performance/controlling-logging.md)
