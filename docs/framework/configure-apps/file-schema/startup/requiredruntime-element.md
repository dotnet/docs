---
title: "&lt;requiredRuntime&gt; Element"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#requiredRuntime"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/startup/requiredRuntime"
helpviewer_keywords: 
  - "requiredRuntime element"
  - "<requiredRuntime> element"
  - "container tags, <requiredRuntime> element"
ms.assetid: 9fa1639e-beb8-43be-b7a4-12f7b229c34b
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# &lt;requiredRuntime&gt; Element
Specifies that the application supports only version 1.0 of the common language runtime. This element is deprecated and should no longer be used. The [`supportedRuntime`](supportedruntime-element.md) element should be used instead.
  
 \<configuration>  
\<startup>  
\<requiredRuntime>  
  
## Syntax  
  
```xml  
   <requiredRuntime    
version="runtime version"  
safemode="true|false"/>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`version`|Optional attribute.<br /><br /> A string value that specifies the version of the .NET Framework that this application supports. The string value must match the directory name found under the .NET Framework installation root. The contents of the string value are not parsed.|  
|`safemode`|Optional attribute.<br /><br /> Specifies whether the runtime startup code searches the registry to determine the runtime version.|  
  
## safemode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|The runtime startup code looks in the registry. This is the default value.|  
|`true`|The runtime startup code does not look in the registry.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`startup`|Contains the `<requiredRuntime>` element.|  
  
## Remarks  
 Applications built to support only version 1.0 of the runtime must use the `<requiredRuntime>` element. Applications built using version 1.1 or later of the runtime must use the `<supportedRuntime>` element.  
  
> [!NOTE]
>  If you use the [CorBindToRuntimeByCfg](../../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimebycfg-function.md) function to specify the configuration file, you must use the `<requiredRuntime>` element for all versions of the runtime. The `<supportedRuntime>` element is ignored when you use [CorBindToRuntimeByCfg](../../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimebycfg-function.md).  
  
 The `version` attribute string must match the installation folder name for the specified version of the .NET Framework. This string is not interpreted. If the runtime startup code does not find a matching folder, the runtime is not loaded; the startup code shows an error message and quits.  
  
> [!NOTE]
>  The startup code for an application that is hosted in Microsoft Internet Explorer ignores the `<requiredRuntime>` element.  
  
## Example  
 The following example shows how to specify the runtime version in a configuration file.  
  
```xml  
<configuration>  
   <startup>  
      <requiredRuntime version="v1.0.3705" safemode="true"/>  
   </startup>  
</configuration>  
```  
  
## See Also  
 [Startup Settings Schema](../../../../../docs/framework/configure-apps/file-schema/startup/index.md)  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<PaveOver> Specifying Which Runtime Version to Use](http://msdn.microsoft.com/library/c376208d-980d-42b4-865b-fbe0d9cc97c2)
