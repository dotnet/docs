---
title: "Importing a Type Library as an Assembly"
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
  - "importing type library"
  - "type metadata"
  - "custom wrappers"
  - "metadata"
  - "exposing COM components to .NET Framework"
  - "Type Library Importer"
  - "interoperation with unmanaged code, importing type library"
  - "interoperation with unmanaged code, exposing COM components"
  - "type libraries"
  - "TypeLibConverter class, importing type library as assembly"
  - "COM interop, importing type library"
  - "COM interop, exposing COM components"
ms.assetid: d1898229-cd40-426e-a275-f3eb65fbc79f
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Importing a Type Library as an Assembly
COM type definitions usually reside in a type library. In contrast, CLS-compliant compilers produce type metadata in an assembly. The two sources of type information are quite different. This topic describes techniques for generating metadata from a type library. The resulting assembly is called an interop assembly, and the type information it contains enables .NET Framework applications to use COM types.  
  
 There are two ways to make this type information available to your application:  
  
-   Using design-time-only interop assemblies: Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can instruct the compiler to embed type information from the interop assembly into your executable. The compiler embeds only the type information that your application uses. You do not have to deploy the interop assembly with your application. This is the recommended technique.  
  
-   Deploying interop assemblies: You can create a standard reference to the interop assembly. In this case, the interop assembly must be deployed with your application. If you employ this technique, and you are not using a private COM component, always reference the primary interop assembly (PIA) published by the author of the COM component you intend to incorporate in your managed code. For more information about producing and using primary interop assemblies, see [Primary Interop Assemblies](https://msdn.microsoft.com/library/b977a8be-59a0-40a0-a806-b11ffba5c080(v=vs.100)).  
  
 When you use design-time-only interop assemblies, you can embed type information from the primary interop assembly published by the author of the COM component. However, you do not have to deploy the primary interop assembly with your application.  
  
 Using design-time-only interop assemblies reduces the size of your application, because most applications do not use all the features of a COM component. The compiler is very efficient when it embeds type information; if your application uses only some of the methods on a COM interface, the compiler does not embed the unused methods. When an application that has embedded type information interacts with another such application, or interacts with an application that uses a primary interop assembly, the common language runtime uses type equivalence rules to determine whether two types with the same name represent the same COM type. You do not have to know these rules to use COM objects. However, if you are interested in the rules, see [Type Equivalence and Embedded Interop Types](../../../docs/framework/interop/type-equivalence-and-embedded-interop-types.md).  
  
## Generating Metadata  
 COM type libraries can be stand-alone files that have a .tlb extension, such as Loanlib.tlb. Some type libraries are embedded in the resource section of a .dll or .exe file. Other sources of type library information are .olb and .ocx files.  
  
 After you locate the type library that contains the implementation of your target COM type, you have the following options for generating an interop assembly containing type metadata:  
  
-   Visual Studio  
  
     Visual Studio automatically converts COM types in a type library to metadata in an assembly. For instructions, see [How to: Add References to Type Libraries](../../../docs/framework/interop/how-to-add-references-to-type-libraries.md) and [Walkthrough: Embedding Type Information from Microsoft Office Assemblies](https://msdn.microsoft.com/library/85b55e05-bc5e-4665-b6ae-e1ada9299fd3(v=vs.100)).  
  
-   [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md)  
  
     The Type Library Importer provides command-line options to adjust metadata in the resulting interop file, imports types from an existing type library, and generates an interop assembly and a namespace. For instructions, see [How to: Generate Interop Assemblies from Type Libraries](../../../docs/framework/interop/how-to-generate-interop-assemblies-from-type-libraries.md).  
  
-   <xref:System.Runtime.InteropServices.TypeLibConverter?displayProperty=nameWithType> class  
  
     This class provides methods to convert coclasses and interfaces in a type library to metadata within an assembly. It produces the same metadata output as Tlbimp.exe. However, unlike Tlbimp.exe, the <xref:System.Runtime.InteropServices.TypeLibConverter> class can convert an in-memory type library to metadata.  
  
-   Custom wrappers  
  
     When a type library is unavailable or incorrect, one option is to create a duplicate definition of the class or interface in managed source code. You then compile the source code with a compiler that targets the runtime to produce metadata in an assembly.  
  
     To define COM types manually, you must have access to the following items:  
  
    -   Precise descriptions of the coclasses and interfaces being defined.  
  
    -   A compiler, such as the C# compiler, that can generate the appropriate .NET Framework class definitions.  
  
    -   Knowledge of the type library-to-assembly conversion rules.  
  
     Writing a custom wrapper is an advanced technique. For additional information about how to generate a custom wrapper, see [Customizing Standard Wrappers](https://msdn.microsoft.com/library/c40d089b-6a3c-41b5-a20d-d760c215e49d(v=vs.100)).  
  
 For more information about the COM interop import process, see [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/bf3f90c5-4770-4ab8-895c-3ba1055cc958(v=vs.100)).  
  
## See Also  
 <xref:System.Runtime.InteropServices.TypeLibConverter>  
 [Exposing COM Components to the .NET Framework](../../../docs/framework/interop/exposing-com-components.md)  
 [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/bf3f90c5-4770-4ab8-895c-3ba1055cc958(v=vs.100))  
 [Tlbimp.exe (Type Library Importer)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md)  
 [Customizing Standard Wrappers](https://msdn.microsoft.com/library/c40d089b-6a3c-41b5-a20d-d760c215e49d(v=vs.100))  
 [Using COM Types in Managed Code](https://msdn.microsoft.com/library/1a95a8ca-c8b8-4464-90b0-5ee1a1135b66(v=vs.100))  
 [Compiling an Interop Project](../../../docs/framework/interop/compiling-an-interop-project.md)  
 [Deploying an Interop Application](../../../docs/framework/interop/deploying-an-interop-application.md)  
 [How to: Add References to Type Libraries](../../../docs/framework/interop/how-to-add-references-to-type-libraries.md)  
 [How to: Generate Interop Assemblies from Type Libraries](../../../docs/framework/interop/how-to-generate-interop-assemblies-from-type-libraries.md)  
 [Walkthrough: Embedding Type Information from Microsoft Office Assemblies](https://msdn.microsoft.com/library/85b55e05-bc5e-4665-b6ae-e1ada9299fd3(v=vs.100))
