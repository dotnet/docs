---
title: "&lt;bindingRedirect&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/dependentAssembly/bindingRedirect"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#bindingRedirect"
helpviewer_keywords: 
  - "<bindingRedirect> element"
  - "container tags, <bindingRedirect> element"
  - "bindingRedirect element"
ms.assetid: 67784ecd-9663-434e-bd6a-26975e447ac0
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;bindingRedirect&gt; Element
Redirects one assembly version to another.  
  
 \<configuration>  
\<runtime>  
\<assemblyBinding>  
\<dependentAssembly>  
\<bindingRedirect>  
  
## Syntax  
  
```xml  
   <bindingRedirect    
oldVersion="existing assembly version"  
newVersion="new assembly version"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`oldVersion`|Required attribute.<br /><br /> Specifies the version of the assembly that was originally requested. The format of an assembly version number is *major.minor.build.revision*. Valid values for each part of this version number are 0 to 65535.<br /><br /> You can also specify a range of versions in the following format:<br /><br /> *n.n.n.n - n.n.n.n*|  
|`newVersion`|Required attribute.<br /><br /> Specifies the version of the assembly to use instead of the originally requested version in the format: *n.n.n.n*<br /><br /> This value can specify an earlier version than `oldVersion`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|None||  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`assemblyBinding`|Contains information about assembly version redirection and the locations of assemblies.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`dependentAssembly`|Encapsulates binding policy and assembly location for each assembly. Use one dependentAssembly element for each assembly.|  
|`runtime`|Contains information about assembly binding and garbage collection.|  
  
## Remarks  
 When you build a .NET Framework application against a strong-named assembly, the application uses that version of the assembly at run time by default, even if a new version is available. However, you can configure the application to run against a newer version of the assembly. For details on how the runtime uses these files to determine which assembly version to use, see [How the Runtime Locates Assemblies](../../../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md).  
  
 You can redirect more than one assembly version by including multiple `bindingRedirect` elements in a `dependentAssembly` element. You can also redirect from a newer version to an older version of the assembly.  
  
 Explicit assembly binding redirection in an application configuration file requires a security permission. This applies to redirection of .NET Framework assemblies and assemblies from third parties. The permission is granted by setting the <xref:System.Security.Permissions.SecurityPermissionFlag> flag on the <xref:System.Security.Permissions.SecurityPermission>. For more information, see [Assembly Binding Redirection Security Permission](../../../../../docs/framework/configure-apps/assembly-binding-redirection-security-permission.md).  
  
## Example  
 The following example shows how to redirect one assembly version to another.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <bindingRedirect oldVersion="1.0.0.0"  
                             newVersion="2.0.0.0"/>  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Redirecting Assembly Versions](../../../../../docs/framework/configure-apps/redirect-assembly-versions.md)
