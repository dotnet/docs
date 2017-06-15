---
title: "&lt;configuration&gt; Element | Microsoft Docs"
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
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "<configuration> element"
  - "configuration element"
  - "container tags, <configuration> element"
ms.assetid: 2ec1c9dc-2e5c-4ef0-9958-81670ab88449
caps.latest.revision: 15
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# &lt;configuration&gt; Element
The root element in every configuration file used by the common language runtime and .NET Framework applications.  
  
 **\<configuration>**  
  
## Syntax  
  
```xml  
<configuration>   
   <!-- configuration settings -->   
</configuration>  
```  
  
## Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<assemblyBinding> Element](../../../../docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md)|Specifies assembly binding policy at the configuration level.|  
|[Startup Settings Schema](../../../../docs/framework/configure-apps/file-schema/startup/index.md)|All elements in the startup settings schema.|  
|[Runtime Settings Schema](../../../../docs/framework/configure-apps/file-schema/runtime/index.md)|All elements in the runtime settings schema.|  
|[Remoting Settings Schema](http://msdn.microsoft.com/en-us/dc2d1e62-9af7-4ca1-99fd-98b93bb4db9e)|All elements in the remoting settings schema.|  
|[Network Settings Schema](../../../../docs/framework/configure-apps/file-schema/network/index.md)|All elements in the network settings schema.|  
|[Cryptography Settings Schema](../../../../docs/framework/configure-apps/file-schema/cryptography/index.md)|All elements in the crypto settings schema.|  
|[Configuration Sections Schema](../../../../docs/framework/configure-apps/file-schema/configuration-sections-schema.md)|All elements in the configuration section settings schema.|  
|[Trace and Debug Settings Schema](../../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)|All elements in the trace and debug settings schema.|  
|[ASP.NET Settings Schema](http://msdn.microsoft.com/en-us/116608f3-c03d-4413-9fc7-978703e18b0f)|All elements in the ASP.NET configuration schema, which includes elements for configuring ASP.NET Web sites and applications. Used in Web.config files.|  
|[XML Web Services Settings Schema](http://msdn.microsoft.com/en-us/f84d6d55-1add-4eb7-ae46-33df5833ea2e)|All elements in the Web services settings schema.|  
|[Web Settings Schema](../../../../docs/framework/configure-apps/file-schema/web/index.md)|All elements in the Web settings schema, which includes elements for configuring how ASP.NET works with a host application such as IIS. Used in aspnet.config files.|  
  
## Remarks  
 Each configuration file must contain exactly one **\<configuration>** element.  
  
## See Also  
 [Configuration File Schema](../../../../docs/framework/configure-apps/file-schema/index.md)
