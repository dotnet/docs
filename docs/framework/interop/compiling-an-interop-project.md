---
title: "Compiling an Interop Project | Microsoft Docs"
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
  - "interoperation with unmanaged code, compiling"
  - "COM interop, compiling"
  - "exposing COM components to .NET Framework"
  - "compiling interop projects"
  - "interoperation with unmanaged code, exposing COM components"
  - "COM interop, exposing COM components"
ms.assetid: 6fcf6588-5e25-41af-b4ae-780974f2c3df
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Compiling an Interop Project
COM interop projects that reference one or more assemblies containing imported COM types are compiled like any other managed project. You can reference interop assemblies in a development environment such as Visual Studio, or you can reference them when you use a command-line compiler. In either case, to compile properly, the interop assembly must be in the same directory as the other project files.  
  
 There are two ways to reference interop assemblies:  
  
-   Embedded interop types: Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] and [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)], you can instruct the compiler to embed type information from an interop assembly into your executable. This is the recommended technique.  
  
-   Deploying interop assemblies: You can create a standard reference to an interop assembly. In this case, the interop assembly must be deployed with your application.  
  
 The differences between these two techniques are discussed in greater detail in [Using COM Types in Managed Code](https://msdn.microsoft.com/library/3y76b69k.aspx).  
  
 Embedding interop types with Visual Studio is demonstrated in [Walkthrough: Embedding Type Information from Microsoft Office Assemblies](http://msdn.microsoft.com/library/85b55e05-bc5e-4665-b6ae-e1ada9299fd3) and [Walkthrough: Embedding Types from Managed Assemblies](https://msdn.microsoft.com/library/dd409610.aspx).  
  
 To reference an interop assembly with a command-line compiler and embed type information in your executables, use the [/link (C# Compiler Options)](~/docs/csharp/language-reference/compiler-options/link-compiler-option.md) or the [/link (Visual Basic)](~/docs/visual-basic/reference/command-line-compiler/link.md) compiler switch and specify the name of the interop assembly.  
  
> [!NOTE]
>  Visual C++ applications cannot embed type information, but they can interoperate with applications or add-ins that do.  
  
 To compile an application that includes a primary interop assembly when it is deployed, use the **/reference** compiler switch and specify the name of the interop assembly.  
  
## See Also  
 [Exposing COM Components to the .NET Framework](../../../docs/framework/interop/exposing-com-components.md)   
 [Language Independence and Language-Independent Components](../../../docs/standard/language-independence-and-language-independent-components.md)   
 [Using COM Types in Managed Code](https://msdn.microsoft.com/library/3y76b69k.aspx)   
 [Walkthrough: Embedding Type Information from Microsoft Office Assemblies](https://msdn.microsoft.com/library/ee317478.aspx)   
 [Walkthrough: Embedding Types from Managed Assemblies](https://msdn.microsoft.com/library/dd409610.aspx)   
 [Importing a Type Library as an Assembly](../../../docs/framework/interop/importing-a-type-library-as-an-assembly.md)
