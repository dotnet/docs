---
title: "Web Settings Schema"
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
  - "Web.config configuration file [ASP.NET]"
  - "ASP.NET configuration system, Web settings schema"
  - "schema Web settings"
  - "Web settings, schema [ASP.NET]"
  - "configuration files [ASP.NET]"
  - "configuration schema [.NET Framework], Web settings"
ms.assetid: ae1ac356-267d-4753-8d7a-7a04eb45a9be
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Web Settings Schema
Web settings specify CPU and execution-level ASP.NET settings that apply to process-wide behavior managed by the ASP.NET hosting layer. These settings differ from application domain-type settings that are specified in the Web.config file of an ASP.NET application.  
  
 Web settings are contained in Aspnet.config files, which are located in the installation folders for versions of the .NET Framework. For example, the Aspnet.config file for [!INCLUDE[dnprdnext](../../../../../includes/dnprdnext-md.md)] is in the following folder:  
  
 `C:\Windows\Microsoft.NET\Framework\v2.0.50727\`  
  
 Web settings are not used in any other configuration files such as the machine.config file, the root Web.config, or application-level Web.config files.  
  
 [\<configuration> Element](../../../../../docs/framework/configure-apps/file-schema/configuration-element.md)  
  
 [\<system.web> Element (Web Settings)](../../../../../docs/framework/configure-apps/file-schema/web/system-web-element-web-settings.md)  
  
 [\<applicationPool> Element (Web Settings)](../../../../../docs/framework/configure-apps/file-schema/web/applicationpool-element-web-settings.md)  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.web>](../../../../../docs/framework/configure-apps/file-schema/web/system-web-element-web-settings.md)|Contains information that the ASP.NET hosting layer uses.|  
|[\<applicationPool>](../../../../../docs/framework/configure-apps/file-schema/web/applicationpool-element-web-settings.md)|Specifies CPU and execution-level ASP.NET settings that apply to process-wide behavior managed by the ASP.NET hosting layer.|  
  
## See Also  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
