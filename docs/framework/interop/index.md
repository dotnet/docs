---
title: "Interoperating with unmanaged code"
ms.date: "01/17/2018"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "unmanaged code, interoperation"
  - "managed code, interoperation with unmanaged code"
  - ".NET Framework, interoperation with unmanaged code"
  - "unmanaged code"
  - "interoperation with unmanaged code"
  - "interoperation with unmanaged code, about interoperation"
  - "components [.NET Framework], interoperation with unmanaged code"
ms.assetid: ccb68ce7-b0e9-4ffb-839d-03b1cd2c1258
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Interoperating with unmanaged code

The .NET Framework promotes interaction with COM components, COM+ services, external type libraries, and many operating system services. Data types, method signatures, and error-handling mechanisms vary between managed and unmanaged object models. To simplify interoperation between .NET Framework components and unmanaged code and to ease the migration path, the common language runtime conceals from both clients and servers the differences in these object models.

Code that executes under the control of the runtime is called managed code. Conversely, code that runs outside the runtime is called unmanaged code. COM components, ActiveX interfaces, and Win32 API functions are examples of unmanaged code.

## In this section

[Exposing COM Components to the .NET Framework](exposing-com-components.md)  
Describes how to use COM components from .NET Framework applications.

[Exposing .NET Framework Components to COM](exposing-dotnet-components-to-com.md)  
Describes how to use .NET Framework components from COM applications.

[Consuming Unmanaged DLL Functions](consuming-unmanaged-dll-functions.md)  
Describes how to call unmanaged DLL functions using platform invoke.

[Interop Marshaling](interop-marshaling.md)  
Describes marshaling for COM interop and platform invoke.

[How to: Map HRESULTs and Exceptions](how-to-map-hresults-and-exceptions.md)  
Describes the mapping between exceptions and HRESULTs.

[COM Wrappers](com-wrappers.md)  
Describes the wrappers provided by COM interop.

[Type Equivalence and Embedded Interop Types](type-equivalence-and-embedded-interop-types.md)  
Describes how type information for COM types is embedded in assemblies, and how the common language runtime determines the equivalence of embedded COM types.

[How to: Generate Primary Interop Assemblies Using Tlbimp.exe](how-to-generate-primary-interop-assemblies-using-tlbimp-exe.md)  
Describes how to produce primary interop assemblies using *Tlbimp.exe* (Type Library Importer).

[How to: Register Primary Interop Assemblies](how-to-register-primary-interop-assemblies.md)  
Describes how to register the primary interop assemblies before you can reference them in your projects.

[Registration-Free COM Interop](registration-free-com-interop.md)  
Describes how COM interop can activate components without using the Windows registry.

[How to: Configure .NET Framework-Based COM Components for Registration-Free Activation](configure-net-framework-based-com-components-for-reg.md)  
Describes how to create an application manifest and how to create and embed a component manifest.
