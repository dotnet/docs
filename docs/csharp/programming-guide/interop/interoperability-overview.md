---
title: "Interoperability Overview (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "COM interop"
  - "C# language, interoperability"
  - "C++ Interop"
  - "interoperability, about interoperability"
  - "platform invoke"
ms.assetid: c025b2e0-2357-4c27-8461-118f0090aeff
caps.latest.revision: 43
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Interoperability Overview (C# Programming Guide)
The topic describes methods to enable interoperability between C# managed code and unmanaged code.  
  
## Platform Invoke  
 *Platform invoke* is a service that enables managed code to call unmanaged functions that are implemented in dynamic link libraries (DLLs), such as those in the Microsoft Win32 API. It locates and invokes an exported function and marshals its arguments (integers, strings, arrays, structures, and so on) across the interoperation boundary as needed.  
  
 For more information, see [Consuming Unmanaged DLL Functions](../../../framework/interop/consuming-unmanaged-dll-functions.md) and [How to: Use Platform Invoke to Play a Wave File](../../../csharp/programming-guide/interop/how-to-use-platform-invoke-to-play-a-wave-file.md).  
  
> [!NOTE]
>  The [Common Language Runtime](../../../standard/clr.md) (CLR) manages access to system resources. Calling unmanaged code that is outside the CLR bypasses this security mechanism, and therefore presents a security risk. For example, unmanaged code might call resources in unmanaged code directly, bypassing CLR security mechanisms. For more information, see [.NET Framework Security](http://go.microsoft.com/fwlink/?LinkId=37122).  
  
## C++ Interop  
 You can use C++ interop, also known as It Just Works (IJW), to wrap a native C++ class so that it can be consumed by code that is authored in C# or another .NET Framework language. To do this, you write C++ code to wrap a native DLL or COM component. Unlike other .NET Framework languages, [!INCLUDE[vcprvc](../../../csharp/programming-guide/interop/includes/vcprvc_md.md)] has interoperability support that enables managed and unmanaged code to be located in the same application and even in the same file. You then build the C++ code by using the **/clr** compiler switch to produce a managed assembly. Finally, you add a reference to the assembly in your C# project and use the wrapped objects just as you would use other managed classes.  
  
## Exposing COM Components to C#  
 You can consume a COM component from a C# project. The general steps are as follows:  
  
1.  Locate a COM component to use and register it. Use regsvr32.exe to register or un–register a COM DLL.  
  
2.  Add to the project a reference to the COM component or type library.  
  
     When you add the reference, [!INCLUDE[vsprvs](../../../csharp/includes/vsprvs_md.md)] uses the [Tlbimp.exe (Type Library Importer)](http://msdn.microsoft.com/library/ec0a8d63-11b3-4acd-b398-da1e37e97382), which takes a type library as input, to output a .NET Framework interop assembly. The assembly, also named a runtime callable wrapper (RCW), contains managed classes and interfaces that wrap the COM classes and interfaces that are in the type library. [!INCLUDE[vsprvs](../../../csharp/includes/vsprvs_md.md)] adds to the project a reference to the generated assembly.  
  
3.  Create an instance of a class that is defined in the RCW. This, in turn, creates an instance of the COM object.  
  
4.  Use the object just as you use other managed objects. When the object is reclaimed by garbage collection, the instance of the COM object is also released from memory.  
  
 For more information, see [Exposing COM Components to the .NET Framework](http://msdn.microsoft.com/library/e78b14f1-e487-43cd-9c6d-1a07483f1730).  
  
## Exposing C# to COM  
 COM clients can consume C# types that have been correctly exposed. The basic steps to expose C# types are as follows:  
  
1.  Add interop attributes in the C# project.  
  
     You can make an assembly COM visible by modifying [!INCLUDE[csprcs](../../../csharp/includes/csprcs_md.md)] project properties. For more information, see [Assembly Information Dialog Box](https://docs.microsoft.com/visualstudio/ide/reference/assembly-information-dialog-box).  
  
2.  Generate a COM type library and register it for COM usage.  
  
     You can modify [!INCLUDE[csprcs](../../../csharp/includes/csprcs_md.md)] project properties to automatically register the C# assembly for COM interop. [!INCLUDE[vsprvs](../../../csharp/includes/vsprvs_md.md)] uses the [Regasm.exe (Assembly Registration Tool)](http://msdn.microsoft.com/library/e190e342-36ef-4651-a0b4-0e8c2c0281cb), using the `/tlb` command-line switch, which takes a managed assembly as input, to generate a type library. This type library describes the `public` types in the assembly and adds registry entries so that COM clients can create managed classes.  
  
 For more information, see [Exposing .NET Framework Components to COM](http://msdn.microsoft.com/library/e42a65f7-1e61-411f-b09a-aca1bbce24c6) and [Example COM Class](../../../csharp/programming-guide/interop/example-com-class.md).  
  
## See Also  
 [Improving Interop Performance](http://go.microsoft.com/fwlink/?LinkId=99564)   
 [Introduction to COM Interop](http://go.microsoft.com/fwlink/?LinkId=112406)   
 [Marshaling between Managed and Unmanaged Code](http://go.microsoft.com/fwlink/?LinkId=112398)   
 [Interoperating with Unmanaged Code](https://msdn.microsoft.com/library/sd10k43k)   
 [Advanced COM Interoperability](http://msdn.microsoft.com/en-us/3ada36e5-2390-4d70-b490-6ad8de92f2fb)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)