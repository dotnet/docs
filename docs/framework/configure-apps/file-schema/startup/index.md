---
title: "Startup settings schema"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "startup settings schema"
  - "schema startup settings"
  - "configuration schema [.NET Framework], startup settings"
ms.assetid: 03de6972-442a-4648-9f3e-efa654e3b949
---
# Startup settings schema

Startup settings specify the version of the common language runtime that should run the application.  
  
|Element|Description|  
|-------------|-----------------|  
|[\<requiredRuntime>](requiredruntime-element.md)|Specifies that the application supports only version 1.0 of the common language runtime. Applications built with runtime version 1.1 should use the **\<supportedRuntime>** element.|  
|[\<supportedRuntime>](supportedruntime-element.md)|Specifies which versions of the common language runtime the application supports.|  
|[\<startup>](startup-element.md)|Contains the **\<requiredRuntime>** and **\<supportedRuntime>** elements.|  
  
## See also

- [Configuration File Schema](../index.md)
- [How to: Configure an app to support .NET Framework 4 or later versions](../../../migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)
