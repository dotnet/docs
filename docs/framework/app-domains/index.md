---
title: "Programming with Application Domains and Assemblies"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
  - "application domains, programming"
  - "programming application domains"
ms.assetid: 96d3b8e3-bef8-4da0-9a81-9841e23a94e9
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Programming with Application Domains and Assemblies
Hosts such as Microsoft Internet Explorer, ASP.NET, and the Windows shell load the common language runtime into a process, create an [application domain](../../../docs/framework/app-domains/application-domains.md) in that process, and then load and execute user code in that application domain when running a .NET Framework application. In most cases, you do not have to worry about creating application domains and loading assemblies into them because the runtime host performs those tasks.  
  
 However, if you are creating an application that will host the common language runtime, creating tools or code you want to unload programmatically, or creating pluggable components that can be unloaded and reloaded on the fly, you will be creating your own application domains. Even if you are not creating a runtime host, this section provides important information on how to work with application domains and assemblies loaded in these application domains.  
  
## In This Section  
 [Application Domains and Assemblies How-to Topics](../../../docs/framework/app-domains/application-domains-and-assemblies-how-to-topics.md)  
 Provides links to all How-to topics found in the conceptual documentation for programming with application domains and assemblies.  
  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)  
 Provides examples of creating, configuring, and using application domains.  
  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)  
 Describes how to create, sign, and set attributes on assemblies.  
  
## Related Sections  
 [Emitting Dynamic Methods and Assemblies](../../../docs/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)  
 Describes how to create dynamic assemblies.  
  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 Provides a conceptual overview of assemblies.  
  
 [Application Domains](../../../docs/framework/app-domains/application-domains.md)  
 Provides a conceptual overview of application domains.  
  
 [Reflection Overview](../../../docs/framework/reflection-and-codedom/reflection.md)  
 Describes how to use the **Reflection** class to obtain information about an assembly.
