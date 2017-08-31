---
title: "Introduction to COM Interop (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "interop assemblies"
  - "COM interop, about COM interop"
ms.assetid: 8bd62e68-383d-407f-998b-29aa0ce0fd67
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Introduction to COM Interop (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The Component Object Model (COM) lets an object expose its functionality to other components and to host applications. While COM objects have been fundamental to Windows programming for many years, applications designed for the common language runtime (CLR) offer many advantages.  
  
 [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications will eventually replace those developed with COM. Until then, you may have to use or create COM objects by using [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]. Interoperability with COM, or *COM interop*, enables you to use existing COM objects while transitioning to the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] at your own pace.  
  
 By using the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] to create COM components, you can use registration-free COM interop. This lets you control which DLL version is enabled when more than one version is installed on a computer, and lets end users use XCOPY or FTP to copy your application to an appropriate directory on their computer where it can be run. For more information, see [Registration-Free COM Interop](../Topic/Registration-Free%20COM%20Interop.md).  
  
## Managed Code and Data  
 Code developed for the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] is referred to as *managed code*, and contains metadata that is used by CLR. Data used by [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications is called *managed data* because the runtime manages data-related tasks such as allocating and reclaiming memory and performing type checking. By default, [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)] uses managed code and data, but you can access the unmanaged code and data of COM objects using interop assemblies (described later on this page).  
  
## Assemblies  
 An assembly is the primary building block of a [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] application. It is a collection of functionality that is built, versioned, and deployed as a single implementation unit containing one or more files. Each assembly contains an assembly manifest.  
  
## Type Libraries and Assembly Manifests  
 Type libraries describe characteristics of COM objects, such as member names and data types. Assembly manifests perform the same function for [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications. They include information about the following:  
  
-   Assembly identity, version, culture, and digital signature.  
  
-   Files that make up the assembly implementation.  
  
-   Types and resources that make up the assembly. This includes those that are exported from it.  
  
-   Compile-time dependencies on other assemblies.  
  
-   Permissions required for the assembly to run correctly.  
  
 For more information about assemblies and assembly manifests, see [Assemblies and the Global Assembly Cache](../Topic/Assemblies%20and%20the%20Global%20Assembly%20Cache%20\(C%23%20and%20Visual%20Basic\).md).  
  
### Importing and Exporting Type Libraries  
 [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] contains a utility, Tlbimp, that lets you import information from a type library into a [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] application. You can generate type libraries from assemblies by using the Tlbexp utility.  
  
 For information about Tlbimp and Tlbexp, see [Tlbimp.exe (Type Library Importer)](../Topic/Tlbimp.exe%20\(Type%20Library%20Importer\).md) and [Tlbexp.exe (Type Library Exporter)](../Topic/Tlbexp.exe%20\(Type%20Library%20Exporter\).md).  
  
## Interop Assemblies  
 Interop assemblies are [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] assemblies that bridge between managed and unmanaged code, mapping COM object members to equivalent [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] managed members. Interop assemblies created by [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)] handle many of the details of working with COM objects, such as interoperability marshaling.  
  
## Interoperability Marshaling  
 All [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] applications share a set of common types that enable interoperability of objects, regardless of the programming language that is used. The parameters and return values of COM objects sometimes use data types that differ from those used in managed code. *Interoperability marshaling* is the process of packaging parameters and return values into equivalent data types as they move to and from COM objects. For more information, see [Interop Marshaling](../Topic/Interop%20Marshaling.md).  
  
## See Also  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)   
 [Walkthrough: Implementing Inheritance with COM Objects](../../../visual-basic/programming-guide/com-interop/walkthrough-implementing-inheritance-with-com-objects.md)   
 [Interoperating with Unmanaged Code](../Topic/Interoperating%20with%20Unmanaged%20Code.md)   
 [Troubleshooting Interoperability](../../../visual-basic/programming-guide/com-interop/troubleshooting-interoperability.md)   
 [Assemblies and the Global Assembly Cache](../Topic/Assemblies%20and%20the%20Global%20Assembly%20Cache%20\(C%23%20and%20Visual%20Basic\).md)   
 [Tlbimp.exe (Type Library Importer)](../Topic/Tlbimp.exe%20\(Type%20Library%20Importer\).md)   
 [Tlbexp.exe (Type Library Exporter)](../Topic/Tlbexp.exe%20\(Type%20Library%20Exporter\).md)   
 [Interop Marshaling](../Topic/Interop%20Marshaling.md)   
 [Registration-Free COM Interop](../Topic/Registration-Free%20COM%20Interop.md)