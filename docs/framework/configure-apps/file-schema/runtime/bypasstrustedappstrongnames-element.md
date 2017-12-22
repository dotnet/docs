---
title: "&lt;bypassTrustedAppStrongNames&gt; Element"
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
  - "strong-name bypass feature"
  - "bypassTrustedAppStrongNames element"
  - "strong-named assemblies, loading into trusted application domains"
  - "<bypassTrustedAppStrongNames> element"
ms.assetid: 71b2ebf6-3843-41e2-ad52-ffa5cd083a40
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bypassTrustedAppStrongNames&gt; Element
Specifies whether to bypass the validation of strong names on full-trust assemblies that are loaded into a full-trust <xref:System.AppDomain>.  
  
 \<configuration>  
\<runtime>  
\<bypassTrustedAppStrongNames>  
  
## Syntax  
  
```xml  
<bypassTrustedAppStrongNames    
   enabled="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether the bypass feature that avoids validating strong names for full-trust assemblies is enabled. When this feature is enabled, strong names are not validated for correctness when the assembly is loaded. The default is `true`.|  
  
## enabled Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`true`|Strong-name signatures on full-trust assemblies are not validated when the assemblies are loaded into a full-trust <xref:System.AppDomain>. This is the default.|  
|`false`|Strong-name signatures on full-trust assemblies are validated when the assemblies are loaded into a full-trust <xref:System.AppDomain>. The strong-name signature is checked only for signature correctness; it is not compared to another strong name for a match.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 The strong-name bypass feature avoids the overhead of strong-name signature verification of full-trust assemblies.  
  
 The bypass feature applies to any assembly that is signed with a strong name and that has the following characteristics:  
  
-   Fully trusted without the <xref:System.Security.Policy.StrongName> evidence (for example, has `MyComputer` zone evidence).  
  
-   Loaded into a fully trusted <xref:System.AppDomain>.  
  
-   Loaded from a location under the <xref:System.AppDomainSetup.ApplicationBase%2A> property of that <xref:System.AppDomain>.  
  
-   Not delay-signed.  
  
> [!NOTE]
>  If the bypass feature has been turned off for all applications on the computer by using a registry key, this configuration file setting has no effect. For more information, see [How to: Disable the Strong-Name Bypass Feature](../../../../../docs/framework/app-domains/how-to-disable-the-strong-name-bypass-feature.md).  
  
## Example  
 The following example shows how to specify the behavior that validates the strong-name signature on full-trust assemblies.  
  
```xml  
<configuration>  
   <runtime>  
      <bypassTrustedAppStrongNames enabled="false"/>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [How to: Disable the Strong-Name Bypass Feature](../../../../../docs/framework/app-domains/how-to-disable-the-strong-name-bypass-feature.md)
