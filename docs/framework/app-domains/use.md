---
title: "Using Application Domains"
description: Use application domains, which provide a unit of isolation for the common language runtime (CLR). Application domains are created and run inside a process.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application domains, about"
  - "common language runtime, application domains"
  - "runtime, application domains"
ms.assetid: c6d99815-e022-4d2c-9420-1d7ab5b9d504
---
# Using Application Domains

Application domains provide a unit of isolation for the common language runtime. They are created and run inside a process. Application domains are usually created by a runtime host, which is an application responsible for loading the runtime into a process and executing user code within an application domain. The runtime host creates a process and a default application domain, and runs managed code inside it. Runtime hosts include ASP.NET, Microsoft Internet Explorer, and the Windows shell.  
  
For most applications, you do not need to create your own application domain; the runtime host creates any necessary application domains for you. However, you can create and configure additional application domains if your application needs to isolate code or to use and unload DLLs.  
  
## In This Section  

[How to: Create an Application Domain](how-to-create-an-application-domain.md)  
Describes how to programmatically create an application domain.  
  
[How to: Unload an Application Domain](how-to-unload-an-application-domain.md)  
Describes how to programmatically unload an application domain.  
  
[How to: Configure an Application Domain](how-to-configure-an-application-domain.md)  
Provides an introduction to configuring an application domain.  
  
[Retrieving Setup Information from an Application Domain](retrieve-setup-information.md)  
Describes how to retrieve setup information from an application domain.  
  
[How to: Load Assemblies into an Application Domain](how-to-load-assemblies-into-an-application-domain.md)  
Describes how to load an assembly into an application domain.  
  
[How to: Obtain Type and Member Information from an Assembly](../reflection-and-codedom/get-type-member-information.md)  
Describes how to retrieve information about an assembly.  
  
[Shadow Copying Assemblies](shadow-copy-assemblies.md)  
Describes how shadow copying allows updates to assemblies while they are in use, and how to configure shadow copying.  
  
[How to: Receive First-Chance Exception Notifications](how-to-receive-first-chance-exception-notifications.md)  
Explains how you can receive a notification that an exception has been thrown, before the common language runtime has begun searching for exception handlers.  
  
[Resolving Assembly Loads](../../standard/assembly/resolve-loads.md)  
Provides guidance on using the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event to resolve assembly load failures.  
  
## Reference  

<xref:System.AppDomain>  
Represents an application domain. Provides methods for creating and controlling application domains.  
  
## Related Sections  

[Assemblies in .NET](../../standard/assembly/index.md)  
Provides an overview of the functions performed by assemblies.  
  
[Programming with Assemblies](../../standard/assembly/index.md)  
Describes how to create, sign, and set attributes on assemblies.  
  
[Emitting Dynamic Methods and Assemblies](../reflection-and-codedom/emitting-dynamic-methods-and-assemblies.md)  
Describes how to create dynamic assemblies.  
  
[Application Domains](application-domains.md)  
Provides a conceptual overview of application domains.  
  
[Reflection Overview](../reflection-and-codedom/reflection.md)  
Describes how to use the **Reflection** class to obtain information about an assembly.
