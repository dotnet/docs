---
title: "&lt;assemblyBinding&gt; Element for &lt;configuration&gt; | Microsoft Docs"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/assemblyBinding"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "assemblyBinding Element"
  - "<assemblyBinding> Element"
ms.assetid: 6cc55983-b894-449b-8e26-b258e53939cd
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# &lt;assemblyBinding&gt; Element for &lt;configuration&gt;
Specifies assembly binding policy at the configuration level.  
  
 \<configuration> Element  
\<assemblyBinding> Element for \<configuration>  
  
## Syntax  
  
```  
<assemblyBinding    
   xmlns="urn:schemas-microsoft-com:asm.v1">  
</assemblyBinding>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`xmlns`|Required attribute.<br /><br /> Specifies the XML namespace required for assembly binding. Use the string "urn:schemas-microsoft-com:asm.v1" as the value.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<linkedConfiguration> Element](../../../../docs/framework/configure-apps/file-schema/linkedconfiguration-element.md)|Specifies a configuration file to include.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../../../../docs/framework/configure-apps/file-schema/configuration-element.md)|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
  
## Remarks  
 The [\<linkedConfiguration> Element](../../../../docs/framework/configure-apps/file-schema/linkedconfiguration-element.md) simplifies the management of component assemblies by allowing application configuration files to include assembly configuration files in well-known locations, rather than duplicating assembly configuration settings.  
  
> [!NOTE]
>  The `<linkedConfiguration>` element is not supported for applications with Windows side-by-side manifests.  
  
## Example  
 The following code example shows how to include a configuration file on the local hard disk.  
  
```  
<configuration>  
   <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
      <linkedConfiguration href="file://c:\Program Files\Contoso\sharedConfig.xml"/>  
   </assemblyBinding>  
</configuration>  
```  
  
## See Also  
 [Configuration File Schema](../../../../docs/framework/configure-apps/file-schema/index.md)
