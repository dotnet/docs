---
title: "&lt;codeBase&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#codeBase"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/runtime/assemblyBinding/dependentAssembly/codeBase"
helpviewer_keywords: 
  - "<codeBase> element"
  - "container tags, <codeBase> element"
  - "codeBase element"
ms.assetid: d48a3983-2297-43ff-a14d-1f29d3995822
caps.latest.revision: 10
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;codeBase&gt; Element
Specifies where the common language runtime can find an assembly.  
  
 \<configuration>  
\<runtime>  
\<assemblyBinding>  
\<dependentAssembly>  
\<codeBase>  
  
## Syntax  
  
```xml  
   <codeBase    
version="Assembly version"  
href="URL of assembly"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`href`|Required attribute.<br /><br /> Specifies the URL where the runtime can find the specified version of the assembly.|  
|`version`|Required attribute.<br /><br /> Specifies the version of the assembly the codebase applies to. The format of an assembly version number is *major.minor.build.revision*.|  
  
## version Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Valid values for each part of the version number are 0 to 65535.|Not applicable.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`buildproviders`|Defines a collection of build providers used to compile custom resource files. You can have any number of build providers.|  
|`compilation`|Configures all the compilation settings that ASP.NET uses.|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`System.web`|Specifies the root element for the ASP.NET configuration section.|  
  
## Remarks  
 For the runtime to use the **\<codeBase>** setting in a machine configuration file or publisher policy file, the file must also redirect the assembly version. Application configuration files can have a codebase setting without redirecting the assembly version. After determining which assembly version to use, the runtime applies the codebase setting from the file that determines the version. If no codebase is indicated, the runtime probes for the assembly in the usual way.  
  
 If the assembly has a strong name, the codebase setting can be anywhere on the local intranet or the Internet. If the assembly is a private assembly, the codebase setting must be a path relative to the application's directory.  
  
 For assemblies without a strong name, version is ignored and the loader uses the first appearance of \<codebase> inside \<dependentAssembly>. If there is an entry in the application configuration file that redirects binding to another assembly, the redirection will take precedence even if the assembly version doesnt match the binding request.  
  
## Example  
 The following example shows how to specify where the runtime can find an assembly.  
  
```xml  
<configuration>  
   <runtime>  
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">  
         <dependentAssembly>  
            <assemblyIdentity name="myAssembly"  
                              publicKeyToken="32ab4ba45e0a69a1"  
                              culture="neutral" />  
            <codeBase version="2.0.0.0"  
                      href="http://www.litwareinc.com/myAssembly.dll"/>  
         </dependentAssembly>  
      </assemblyBinding>  
   </runtime>  
</configuration>  
```  
  
## See Also  
 [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [Specifying an Assembly's Location](../../../../../docs/framework/configure-apps/specify-assembly-location.md)  
 [How the Runtime Locates Assemblies](../../../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)
