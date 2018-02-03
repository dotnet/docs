---
title: "&lt;shadowCopyVerifyByTimestamp&gt; Element"
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
  - "<shadowCopyTimeStampVerification> element"
  - "shadowCopyTimeStampVerification element"
ms.assetid: 2f1648e5-997b-435e-a4f9-d236c574c66c
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;shadowCopyVerifyByTimestamp&gt; Element
Specifies whether shadow copying uses the default startup behavior introduced in the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], or reverts to the startup behavior of earlier versions of the .NET Framework.  
  
 \<configuration> Element  
\<runtime> Element  
\<shadowCopyVerifyByTimestamp> Element  
  
## Syntax  
  
```xml  
<shadowCopyVerifyByTimestamp enabled="true|false" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|enabled|Required attribute.<br /><br /> Specifies whether application domains that use shadow copying compare assembly time stamps when starting up, to determine whether an assembly has been updated before shadow copying the assembly.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|true|At startup, copies only assemblies that have been updated since they were last copied to the shadow copy directory. This is the default for the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)].|  
|false|Reverts to the startup behavior of previous versions of the .NET Framework, which was to copy all files at startup.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 Starting with the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)], assemblies are shadow copied only if their time stamps indicate that they have changed since they were last copied to the shadow copy directory. This improves startup times for many applications that use shadow copying, as described in [Shadow Copying Assemblies](../../../../../docs/framework/app-domains/shadow-copy-assemblies.md). Applications that have a high percentage and frequency of assembly updates might not benefit from this change in behavior. In that case, you can use this element to restore the behavior of previous versions of the .NET Framework.  
  
## Example  
 The following example shows how to disable the default startup behavior of shadow copying in the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)], and revert to the startup behavior of previous versions of the .NET Framework.  
  
```xml  
<configuration>  
   <runtime>  
      <shadowCopyVerifyByTimestamp enabled="false" />  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Shadow Copying Assemblies](../../../../../docs/framework/app-domains/shadow-copy-assemblies.md)
