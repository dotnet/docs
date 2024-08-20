---
title: "Programming with Application Domains and Assemblies"
description: Get to know programming with application domains and assemblies in .NET. See links to how-to topics & examples about creating application domains & assemblies.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "assemblies [.NET Framework], programming"
  - "programming assemblies"
  - "application domains, programming"
  - "programming application domains"
ms.assetid: 96d3b8e3-bef8-4da0-9a81-9841e23a94e9
---
# Programming with Application Domains and Assemblies

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

Hosts such as ASP.NET and the Windows shell load the common language runtime into a process, create an [application domain](application-domains.md) in that process, and then load and execute user code in that application domain when running a .NET Framework application. In most cases, you do not have to worry about creating application domains and loading assemblies into them because the runtime host performs those tasks.

However, if you're creating an application that will host the common language runtime, creating tools or code you want to unload programmatically, or creating pluggable components that can be unloaded and reloaded on the fly, you will be creating your own application domains. Even if you are not creating a runtime host, this section provides important information on how to work with application domains and assemblies loaded in these application domains.

## In This Section

[Using Application Domains](use.md)\
Provides examples of creating, configuring, and using application domains.

[Programming with Assemblies](../../standard/assembly/index.md)\
Describes how to create, sign, and set attributes on assemblies.

## Related Sections

[Emitting Dynamic Methods and Assemblies](../../fundamentals/reflection/emitting-dynamic-methods-and-assemblies.md)\
Describes how to create dynamic assemblies.

[Assemblies in .NET](../../standard/assembly/index.md)\
Provides a conceptual overview of assemblies.

[Application Domains](application-domains.md)\
Provides a conceptual overview of application domains.

[Reflection Overview](../../fundamentals/reflection/reflection.md)\
Describes how to use the **Reflection** class to obtain information about an assembly.
