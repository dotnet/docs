---
title: "Introduction to COM Interop (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "interop assemblies"
  - "COM interop [Visual Basic], about COM interop"
ms.assetid: 8bd62e68-383d-407f-998b-29aa0ce0fd67
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Introduction to COM Interop (Visual Basic)
The Component Object Model (COM) lets an object expose its functionality to other components and to host applications. While COM objects have been fundamental to Windows programming for many years, applications designed for the common language runtime (CLR) offer many advantages.  
  
 [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] applications will eventually replace those developed with COM. Until then, you may have to use or create COM objects by using [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)]. Interoperability with COM, or *COM interop*, enables you to use existing COM objects while transitioning to the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] at your own pace.  
  
 By using the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] to create COM components, you can use registration-free COM interop. This lets you control which DLL version is enabled when more than one version is installed on a computer, and lets end users use XCOPY or FTP to copy your application to an appropriate directory on their computer where it can be run. For more information, see [Registration-Free COM Interop](http://msdn.microsoft.com/library/90f308b9-82dc-414a-bce1-77e0155e56bd).  
  
## Managed Code and Data  
 Code developed for the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] is referred to as *managed code*, and contains metadata that is used by the CLR. Data used by [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] applications is called *managed data* because the runtime manages data-related tasks such as allocating and reclaiming memory and performing type checking. By default, Visual Basic .NET uses managed code and data, but you can access the unmanaged code and data of COM objects using interop assemblies (described later on this page).  
  
## Assemblies  
 An assembly is the primary building block of a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] application. It is a collection of functionality that is built, versioned, and deployed as a single implementation unit containing one or more files. Each assembly contains an assembly manifest.  
  
## Type Libraries and Assembly Manifests  
 Type libraries describe characteristics of COM objects, such as member names and data types. Assembly manifests perform the same function for [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] applications. They include information about the following:  
  
-   Assembly identity, version, culture, and digital signature.  
  
-   Files that make up the assembly implementation.  
  
-   Types and resources that make up the assembly. This includes those that are exported from it.  
  
-   Compile-time dependencies on other assemblies.  
  
-   Permissions required for the assembly to run correctly.  
  
 For more information about assemblies and assembly manifests, see [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md).  
  
### Importing and Exporting Type Libraries  
 [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] contains a utility, Tlbimp, that lets you import information from a type library into a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] application. You can generate type libraries from assemblies by using the Tlbexp utility.  
  
 For information about Tlbimp and Tlbexp, see [Tlbimp.exe (Type Library Importer)](../../../framework/tools/tlbimp-exe-type-library-importer.md) and [Tlbexp.exe (Type Library Exporter)](http://msdn.microsoft.com/library/a487d61b-d166-467b-a7ca-d8b52fbff42d).  
  
## Interop Assemblies  
 Interop assemblies are [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies that bridge between managed and unmanaged code, mapping COM object members to equivalent [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] managed members. Interop assemblies created by Visual Basic .NET handle many of the details of working with COM objects, such as interoperability marshaling.  
  
## Interoperability Marshaling  
 All [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] applications share a set of common types that enable interoperability of objects, regardless of the programming language that is used. The parameters and return values of COM objects sometimes use data types that differ from those used in managed code. *Interoperability marshaling* is the process of packaging parameters and return values into equivalent data types as they move to and from COM objects. For more information, see [Interop Marshaling](../../../framework/interop/interop-marshaling.md).  
  
## See Also  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Walkthrough: Implementing Inheritance with COM Objects](../../../visual-basic/programming-guide/com-interop/walkthrough-implementing-inheritance-with-com-objects.md)  
 [Interoperating with Unmanaged Code](../../../framework/interop/index.md)  
 [Troubleshooting Interoperability](../../../visual-basic/programming-guide/com-interop/troubleshooting-interoperability.md)  
 [Assemblies and the Global Assembly Cache](../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [Tlbimp.exe (Type Library Importer)](../../../framework/tools/tlbimp-exe-type-library-importer.md)  
 [Tlbexp.exe (Type Library Exporter)](http://msdn.microsoft.com/library/a487d61b-d166-467b-a7ca-d8b52fbff42d)  
 [Interop Marshaling](../../../framework/interop/interop-marshaling.md)  
 [Registration-Free COM Interop](http://msdn.microsoft.com/library/90f308b9-82dc-414a-bce1-77e0155e56bd)
