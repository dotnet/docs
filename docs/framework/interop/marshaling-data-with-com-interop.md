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
 [COM Data Types](https://msdn.microsoft.com/library/sak564ww.aspx)  
 Provides corresponding managed and unmanaged data types.  
  
 [Customizing COM Callable Wrappers](https://msdn.microsoft.com/library/3bwc828w.aspx)  
 Describes how to explicitly marshal data types using the **MarshalAsAttribute** attribute at design time.  
  
 [Customizing Runtime Callable Wrappers](https://msdn.microsoft.com/library/e753eftz.aspx)  
 Describes how to adjust the marshaling behavior of types in an interop assembly and how to define COM types manually.  
  
 [How to: Migrate Managed-Code DCOM to WCF](../../../docs/framework/interop/how-to-migrate-managed-code-dcom-to-wcf.md)  
 Described how to migrate managed DCOM code to WCF for the most secure solution.  
  
## Related Sections  
 [Advanced COM Interoperability](https://msdn.microsoft.com/library/bd9cdfyx.aspx)  
 Provides links to more information about incorporating COM components into your .NET Framework application.  
  
 [Assembly to Type Library Conversion Summary](https://msdn.microsoft.com/library/xk1120c3.aspx)  
 Describes the assembly to type library export conversion process.  
  
 [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/k83zzh38.aspx)  
 Describes the type library to assembly import conversion process.  
  
 [Interoperating Using Generic Types](https://msdn.microsoft.com/library/ms229590.aspx)  
 Describes which actions are supported when using generic types for COM interoperability.
