---
title: "Marshaling Data with COM Interop | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "COM interop, data marshaling"
  - "marshaling data, COM interop"
ms.assetid: 0bcdd7bf-5026-43eb-b08b-f03f90db9df9
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Marshaling Data with COM Interop
COM interop provides support for both using COM objects from managed code and exposing managed objects to COM. Support for marshaling data to and from COM is extensive and almost always provides the correct marshaling behavior.  
  
 The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] includes the following COM interop tools:  
  
-   [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md), which converts a COM type library to an interop assembly. From this assembly, the interop marshaling service generates wrappers that perform data marshaling between managed and unmanaged memory.  
  
-   [Type Library Exporter (Tlbexp.exe)](../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md), which produces a COM type library from an assembly and generates a wrapper that performs marshaling during method calls.  
  
 This section describes the processes for customizing interop wrappers when you can (or must) supply the marshaler with additional type information.  
  
## In This Section  
 [COM Data Types](http://msdn.microsoft.com/en-us/f93ae35d-a416-4218-8700-c8218cc90061)  
 Provides corresponding managed and unmanaged data types.  
  
 [Customizing COM Callable Wrappers](http://msdn.microsoft.com/en-us/825177d3-4b2c-4723-82be-ce6ca2c34ace)  
 Describes how to explicitly marshal data types using the **MarshalAsAttribute** attribute at design time.  
  
 [Customizing Runtime Callable Wrappers](http://msdn.microsoft.com/en-us/4652beaf-77d0-4f37-9687-ca193288c0be)  
 Describes how to adjust the marshaling behavior of types in an interop assembly and how to define COM types manually.  
  
 [How to: Migrate Managed-Code DCOM to WCF](../../../docs/framework/interop/how-to-migrate-managed-code-dcom-to-wcf.md)  
 Described how to migrate managed DCOM code to WCF for the most secure solution.  
  
## Related Sections  
 [Advanced COM Interoperability](http://msdn.microsoft.com/en-us/3ada36e5-2390-4d70-b490-6ad8de92f2fb)  
 Provides links to more information about incorporating COM components into your .NET Framework application.  
  
 [Assembly to Type Library Conversion Summary](http://msdn.microsoft.com/en-us/3a37eefb-a76c-4000-9080-7dbbf66a4896)  
 Describes the assembly to type library export conversion process.  
  
 [Type Library to Assembly Conversion Summary](http://msdn.microsoft.com/en-us/bf3f90c5-4770-4ab8-895c-3ba1055cc958)  
 Describes the type library to assembly import conversion process.  
  
 [Interoperating Using Generic Types](http://msdn.microsoft.com/en-us/26b88e03-085b-4b53-94ba-a5a9c709ce58)  
 Describes which actions are supported when using generic types for COM interoperability.