---
title: "&lt;NetFx40_PInvokeStackResilience&gt; Element"
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
  - "<NetFx40_PInvokeStackResilience> element"
  - "NetFx40_PInvokeStackResilience element"
ms.assetid: 39fb1588-72a4-4479-af74-0605233b68bd
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;NetFx40_PInvokeStackResilience&gt; Element
Specifies whether the runtime automatically fixes incorrect platform invoke declarations at run time, at the cost of slower transitions between managed and unmanaged code.  
  
 \<configuration>  
\<runtime>  
<NetFx40_PInvokeStackResilience>  
  
## Syntax  
  
```xml  
<NetFx40_PInvokeStackResilience  enabled="1|0"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime detects incorrect platform invoke declarations and automatically fixes the stack at run time on 32-bit platforms.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`0`|The runtime uses the faster interop marshaling architecture introduced in the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], which does not detect and fix incorrect platform invoke declarations. This is the default.|  
|`1`|The runtime uses slower transitions that detect and fix incorrect platform invoke declarations.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 This element enables you to trade faster interop marshaling for run-time resilience against incorrect platform invoke declarations.  
  
 Starting with the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)], a streamlined interop marshaling architecture provides a significant performance improvement for transitions from managed code to unmanaged code. In earlier versions of the .NET Framework, the marshaling layer detected incorrect platform invoke declarations on 32-bit platforms and automatically fixed the stack. The new marshaling architecture eliminates this step. As a result, transitions are very fast, but an incorrect platform invoke declaration can cause a program failure.  
  
 To make it easy to detect incorrect declarations during development, the Visual Studio debugging experience has been improved. The [pInvokeStackImbalance](../../../../../docs/framework/debug-trace-profile/pinvokestackimbalance-mda.md) managed debugging assistant (MDA) notifies you of incorrect platform invoke declarations when your application is running with the debugger attached.  
  
 To address scenarios where your application uses components that you cannot recompile, and that have incorrect platform invoke declarations, you can use the `NetFx40_PInvokeStackResilience` element. Adding this element to your application configuration file with `enabled="1"` opts into a compatibility mode with the behavior of earlier versions of the .NET Framework, at the cost of slower transitions. Assemblies that have been compiled against earlier versions of the .NET Framework are automatically opted into this compatibility mode, and do not need this element.  
  
## Configuration File  
 This element can be used only in the application configuration file.  
  
## Example  
 The following example shows how to opt into increased resilience against incorrect platform invoke declarations for an application, at the cost of slower transitions between managed and unmanaged code.  
  
```xml  
<configuration>  
   <runtime>  
      <NetFx40_PInvokeStackResilience enabled="1"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [pInvokeStackImbalance](../../../../../docs/framework/debug-trace-profile/pinvokestackimbalance-mda.md)
