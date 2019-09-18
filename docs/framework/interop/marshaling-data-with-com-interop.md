---
title: "Marshaling Data with COM Interop"
ms.date: "09/07/2017"
helpviewer_keywords: 
  - "COM interop, data marshaling"
  - "marshaling data, COM interop"
author: "rpetrusha"
ms.author: "ronpet"
---
# Marshaling Data with COM Interop
COM interop provides support for both using COM objects from managed code and exposing managed objects to COM. Support for marshaling data to and from COM is extensive and almost always provides the correct marshaling behavior.  
  
 The Windows SDK includes the following COM interop tools:  
  
- [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md), which converts a COM type library to an interop assembly. From this assembly, the interop marshaling service generates wrappers that perform data marshaling between managed and unmanaged memory.  
  
- [Type Library Exporter (Tlbexp.exe)](../tools/tlbexp-exe-type-library-exporter.md), which produces a COM type library from an assembly and generates a wrapper that performs marshaling during method calls.  
  
 The following sections link to topics that describe the processes for customizing interop wrappers when you can (or must) supply the marshaler with additional type information.  
  
## In This Section  
[How to: Create Wrappers Manually](how-to-create-wrappers-manually.md)   
Describes how to create a COM wrapper manually in managed source code. 
 
 [How to: Migrate Managed-Code DCOM to WCF](how-to-migrate-managed-code-dcom-to-wcf.md)  
 Describes how to migrate managed DCOM code to WCF for the most secure solution.  
  
## Related Sections  
 [COM Data Types](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/sak564ww(v=vs.100))  
 Provides corresponding managed and unmanaged data types.  
  
 [Customizing COM Callable Wrappers](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/3bwc828w(v=vs.100))  
 Describes how to explicitly marshal data types using the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute at design time.  
  
 [Customizing Runtime Callable Wrappers](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/e753eftz(v=vs.100))  
 Describes how to adjust the marshaling behavior of types in an interop assembly and how to define COM types manually.  
  
 [Advanced COM Interoperability](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bd9cdfyx(v=vs.100))  
 Provides links to more information about incorporating COM components into your .NET Framework application.  
  
 [Assembly to Type Library Conversion Summary](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/xk1120c3(v=vs.100))  
 Describes the assembly to type library export conversion process.  
  
 [Type Library to Assembly Conversion Summary](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/k83zzh38(v=vs.100))  
 Describes the type library to assembly import conversion process.  
  
 [Interoperating Using Generic Types](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ms229590(v=vs.100))  
 Describes which actions are supported when using generic types for COM interoperability.
