---
title: "&lt;NetFx40_LegacySecurityPolicy&gt; Element"
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
  - "<NetFx40_LegacySecurityPolicy> element"
  - "NetFx40_LegacySecurityPolicy element"
ms.assetid: 07132b9c-4a72-4710-99d7-e702405e02d4
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;NetFx40_LegacySecurityPolicy&gt; Element
Specifies whether the runtime uses legacy code access security (CAS) policy.  
  
 \<configuration>  
\<runtime>  
<NetFx40_LegacySecurityPolicy>  
  
## Syntax  
  
```xml  
<NetFx40_LegacySecurityPolicy  
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the runtime uses legacy CAS policy.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|The runtime does not use legacy CAS policy. This is the default.|  
|`true`|The runtime uses legacy CAS policy.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks  
 In the .NET Framework version 3.5 and earlier versions, CAS policy is always in effect. In the [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)], CAS policy must be enabled.  
  
 CAS policy is version-specific. Custom CAS policies that exist in earlier versions of the .NET Framework must be respecified in the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)].  
  
 Applying the `<NetFx40_LegacySecurityPolicy>` element to a [!INCLUDE[net_v40_long](../../../../../includes/net-v40-long-md.md)] assembly does not affect [security-transparent code](../../../../../docs/framework/misc/security-transparent-code.md); the transparency rules still apply.  
  
> [!IMPORTANT]
>  Applying the `<NetFx40_LegacySecurityPolicy>` element can result in significant performance penalties for native image assemblies created by the [Native Image Generator (Ngen.exe)](../../../../../docs/framework/tools/ngen-exe-native-image-generator.md) that are not installed in the [global assembly cache](../../../../../docs/framework/app-domains/gac.md). The performance degradation is caused by the inability of the runtime to load the assemblies as native images when the attribute is applied, resulting in their being loaded as just-in-time assemblies.  
  
> [!NOTE]
>  If you specify a target .NET Framework version that is earlier than the [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] in the project settings for your Visual Studio project, CAS policy will be enabled, including any custom CAS policies you specified for that version. However, you will not be able to use new [!INCLUDE[net_v40_short](../../../../../includes/net-v40-short-md.md)] types and members. You can also specify an earlier version of the .NET Framework by using the [\<supportedRuntime> element](../../../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) in the startup settings schema in your [application configuration file](../../../../../docs/framework/configure-apps/index.md).  
  
> [!NOTE]
>  Configuration file syntax is case-sensitive. You should use the syntax as provided in the Syntax and Example sections.  
  
## Configuration File  
 This element can be used only in the application configuration file.  
  
## Example  
 The following example shows how to enable legacy CAS policy for an application.  
  
```xml  
<configuration>  
   <runtime>  
      <NetFx40_LegacySecurityPolicy enabled="true"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
