---
title: "Packaging an Assembly for COM"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "exposing .NET Framework components to COM"
  - "COM interop, packaging assemblies"
  - "packaging assemblies for COM"
  - "Tlbexp.exe"
  - "TypeLibConverter class"
  - ".NET Services Installation tool"
  - "Assembly Registration tool"
  - "Type Library Exporter"
  - "Reqsvcs.exe"
  - "interoperation with unmanaged code, exposing .NET Framework components"
  - "interoperation with unmanaged code, packaging assemblies"
  - "COM interop, exposing COM components"
  - "Reqasm.exe"
ms.assetid: 39dc55aa-f2a1-4093-87bb-f1c0edb6e761
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Packaging an Assembly for COM
COM developers can benefit from the following information about the managed types they plan to incorporate in their application:  
  
-   A list of types that COM applications can consume  
  
     Some managed types are invisible to COM; some are visible but not creatable; and some are both visible and creatable. An assembly can comprise any combination of invisible, visible, not creatable, and creatable types. For completeness, identify the types in an assembly that you intend to expose to COM, especially when those types are a subset of the types exposed to the .NET Framework.  
  
     For additional information, see [Qualifying .NET Types for Interoperation](qualifying-net-types-for-interoperation.md).  
  
-   Versioning instructions  
  
     Managed classes that implement the class interface (a COM interop-generated interface) are subject to versioning restrictions.  
  
     For guidelines on using the class interface, see [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface).  
  
-   Deployment instructions  
  
     Strong-named assemblies that are signed by a publisher can be installed into the global assembly cache. Unsigned assemblies must be installed on the user's machine as private assemblies.  
  
     For additional information, see [Assembly Security Considerations](../app-domains/assembly-security-considerations.md).  
  
-   Type library inclusion  
  
     Most types require a type library when consumed by a COM application. You can generate a type library or have COM developers perform this task. The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] provides the following options for generating a type library:  
  
    -   [Type Library Exporter](#cpconpackagingassemblyforcomanchor1)  
  
    -   [TypeLibConverter Class](#cpconpackagingassemblyforcomanchor2)  
  
    -   [Assembly Registration Tool](#cpconpackagingassemblyforcomanchor3)  
  
    -   [.NET Services Installation Tool](#cpconpackagingassemblyforcomanchor4)  
  
     Regardless of the mechanism you choose, only public types defined in the assembly you supply are included in the generated type library.  
  
     You can package a type library as a separate file or embed it as Win32 resource file within a .NET-based application. Microsoft Visual Basic 6.0 performed this task for you automatically; however, when using [!INCLUDE[vbprvbext](../../../includes/vbprvbext-md.md)], you must embed your type library manually. For instructions, see [How to: Embed Type Libraries as Win32 Resources in .NET-Based Applications](https://msdn.microsoft.com/library/c97b4b8c-2ab7-4ac7-8fc8-0ba5c5d59c44(v=vs.100)).  
  
<a name="cpconpackagingassemblyforcomanchor1"></a>   
## Type Library Exporter  
 The [Type Library Exporter (Tlbexp.exe)](../tools/tlbexp-exe-type-library-exporter.md) is a command-line tool that converts the classes and interfaces contained in an assembly to a COM type library. Once the type information of the class is available, COM clients can create an instance of the .NET class and call the methods of the instance, just as if it were a COM object. Tlbexp.exe converts an entire assembly at one time. You cannot use Tlbexp.exe to generate type information for a subset of the types defined in an assembly.  
  
<a name="cpconpackagingassemblyforcomanchor2"></a>   
## TypeLibConverter Class  
 The <xref:System.Runtime.InteropServices.TypeLibConverter> class, located in the **System.Runtime.Interop** namespace, converts the classes and interfaces contained in an assembly to a COM type library. This API produces the same type information as the Type Library Exporter, described in the previous section.  
  
 The **TypeLibConverter class** implements the <xref:System.Runtime.InteropServices.ITypeLibConverter>.  
  
<a name="cpconpackagingassemblyforcomanchor3"></a>   
## Assembly Registration Tool  
 The [Assembly Registration Tool (Regasm.exe)](../tools/regasm-exe-assembly-registration-tool.md) can generate and register a type library when you apply the **/tlb:** option. COM clients require that type libraries be installed in the Windows registry. Without this option, Regasm.exe only registers the types in an assembly, not the type library. Registering the types in an assembly and registering the type library are distinct activities.  
  
<a name="cpconpackagingassemblyforcomanchor4"></a>   
## .NET Services Installation Tool  
 The [.NET Services Installation Tool (Regsvcs.exe)](../tools/regsvcs-exe-net-services-installation-tool.md) adds managed classes to Windows 2000 Component Services and combines several tasks within a single tool. In addition to loading and registering an assembly, Regsvcs.exe can generate, register, and install the type library into an existing COM+ 1.0 application.  
  
## See Also  
 <xref:System.Runtime.InteropServices.TypeLibConverter>  
 <xref:System.Runtime.InteropServices.ITypeLibConverter>  
 [Exposing .NET Framework Components to COM](exposing-dotnet-components-to-com.md)  
 [Qualifying .NET Types for Interoperation](qualifying-net-types-for-interoperation.md)  
 [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface)  
 [Assembly Security Considerations](../app-domains/assembly-security-considerations.md)  
 [Tlbexp.exe (Type Library Exporter)](../tools/tlbexp-exe-type-library-exporter.md)  
 [Registering Assemblies with COM](registering-assemblies-with-com.md)  
 [How to: Embed Type Libraries as Win32 Resources in Applications](https://msdn.microsoft.com/library/c97b4b8c-2ab7-4ac7-8fc8-0ba5c5d59c44(v=vs.100))
