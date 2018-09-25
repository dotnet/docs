---
title: "Startup Settings Schema"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "startup settings schema"
  - "schema startup settings"
  - "configuration schema [.NET Framework], startup settings"
ms.assetid: 03de6972-442a-4648-9f3e-efa654e3b949
author: "mcleblanc"
ms.author: "markl"
---
# Startup Settings Schema
Startup settings specify the version of the common language runtime that should run the application.  
  
|Element|Description|  
|-------------|-----------------|  
|[\<requiredRuntime>](../../../../../docs/framework/configure-apps/file-schema/startup/requiredruntime-element.md)|Specifies that the application supports only version 1.0 of the common language runtime. Applications built with runtime version 1.1 should use the **\<supportedRuntime>** element.|  
|[\<supportedRuntime>](../../../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md)|Specifies which versions of the common language runtime the application supports.|  
|[\<startup>](../../../../../docs/framework/configure-apps/file-schema/startup/startup-element.md)|Contains the **\<requiredRuntime>** and **\<supportedRuntime>** elements.|  
  
## See Also  
 [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)  
 [\<PaveOver> Specifying Which Runtime Version to Use](https://msdn.microsoft.com/library/c376208d-980d-42b4-865b-fbe0d9cc97c2)
