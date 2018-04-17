---
title: "How to: Reference .NET Types from COM"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "cpp"
helpviewer_keywords: 
  - "importing type library"
  - "COM interop, referencing .NET types"
  - "interoperation with unmanaged code, referencing .NET types"
  - "referencing .NET types"
  - "interoperation with unmanaged code, importing type library"
  - "type libraries"
  - "COM interop, importing type library"
ms.assetid: 54917f6f-cb18-4103-b622-856b55da93f3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Reference .NET Types from COM
From the point of view of client and server code, the differences between COM and the .NET Framework are largely invisible. Microsoft Visual Basic clients can view a .NET object in the object browser, which exposes the object methods and syntax, properties, and fields exactly as if it were any other COM object.  
  
 The process for importing a type library is slightly more complicated for C++ clients, although you use the same tools to export metadata to a COM type library. To reference .NET object members from an unmanaged C++ client, reference the TLB file (produced with Tlbexp.exe) with the **#import** directive. When referencing a type library from C++, you must either specify the **raw_interfaces_only** option or import the definitions in the base class library, Mscorlib.tlb.  
  
### To import a library  
  
-   Specify the **raw_interfaces_only** option in the **#import** directive. For example:  
  
    ```cpp  
    #import "..\LoanLib\LoanLib.tlb" raw_interfaces_only  
    ```  
  
     -or-  
  
-   Include an #import directive for Mscorlib.tlb. For example:  
  
    ```cpp  
    #import "mscorlib.tlb"  
    #import "..\LoanLib\LoanLib.tlb"  
    ```  
  
## See Also  
 [Exposing .NET Framework Components to COM](exposing-dotnet-components-to-com.md)  
 [Registering Assemblies with COM](registering-assemblies-with-com.md)  
 [Calling a .NET Object](https://msdn.microsoft.com/library/40c9626c-aea6-4bad-b8f0-c1de462efd33(v=vs.100))  
 [Deploying an Application for COM Access](https://msdn.microsoft.com/library/fb63564c-c1b9-4655-a094-a235625882ce(v=vs.100))
