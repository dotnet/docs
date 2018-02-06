---
title: "Marshaling Data with COM Interop"
ms.custom: ""
ms.date: "09/07/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "COM interop, data marshaling"
  - "marshaling data, COM interop"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Marshaling Data with COM Interop
COM interop provides support for both using COM objects from managed code and exposing managed objects to COM. Support for marshaling data to and from COM is extensive and almost always provides the correct marshaling behavior.  
  
 The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] includes the following COM interop tools:  
  
-   [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md), which converts a COM type library to an interop assembly. From this assembly, the interop marshaling service generates wrappers that perform data marshaling between managed and unmanaged memory.  
  
-   [Type Library Exporter (Tlbexp.exe)](../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md), which produces a COM type library from an assembly and generates a wrapper that performs marshaling during method calls.  
  
 The following sections link to topics that describe the processes for customizing interop wrappers when you can (or must) supply the marshaler with additional type information.  
  
## In This Section  
[How to: Create Wrappers Manually](how-to-create-wrappers-manually.md)   
Describes how to create a COM wrapper manually in managed source code. 
 
 [How to: Migrate Managed-Code DCOM to WCF](../../../docs/framework/interop/how-to-migrate-managed-code-dcom-to-wcf.md)  
 Describes how to migrate managed DCOM code to WCF for the most secure solution.  
  
## Related Sections  
 [COM Data Types](https://msdn.microsoft.com/library/sak564ww(v=vs.100).aspx)  
 Provides corresponding managed and unmanaged data types.  
  
 [Customizing COM Callable Wrappers](https://msdn.microsoft.com/library/3bwc828w(v=vs.100).aspx)  
 Describes how to explicitly marshal data types using the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute at design time.  
  
 [Customizing Runtime Callable Wrappers](https://msdn.microsoft.com/library/e753eftz(v=vs.100).aspx)  
 Describes how to adjust the marshaling behavior of types in an interop assembly and how to define COM types manually.  
  
 [Advanced COM Interoperability](https://msdn.microsoft.com/library/bd9cdfyx(v=vs.100).aspx)  
 Provides links to more information about incorporating COM components into your .NET Framework application.  
  
 [Assembly to Type Library Conversion Summary](https://msdn.microsoft.com/library/xk1120c3(v=vs.100).aspx)  
 Describes the assembly to type library export conversion process.  
  
 [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/k83zzh38(v=vs.100).aspx)  
 Describes the type library to assembly import conversion process.  
  
 [Interoperating Using Generic Types](https://msdn.microsoft.com/library/ms229590(v=vs.100).aspx)  
 Describes which actions are supported when using generic types for COM interoperability.
