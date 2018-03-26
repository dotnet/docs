---
title: "How to: Build a Single-File Assembly"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "assembly manifest, single-file assemblies"
  - "library assemblies"
  - "command-line compilers"
  - "assemblies [.NET Framework], single-file"
  - "output file name for assemblies"
  - "code modules"
  - "single-file assemblies"
ms.assetid: a6063221-43a5-4d3e-814c-288a4ec69aec
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Build a Single-File Assembly
A single-file assembly, which is the simplest type of assembly, contains type information and implementation, as well as the [assembly manifest](../../../docs/framework/app-domains/assembly-manifest.md). You can use command-line compilers or [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] to create a single-file assembly. By default, the compiler creates an assembly file with an .exe extension.  
  
> [!NOTE]
>  [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] for C# and Visual Basic can be used only to create single-file assemblies. If you want to create multifile assemblies, you must use command-line compilers or [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] for Visual C++.  
  
 The following procedures show how to create single-file assemblies using command-line compilers.  
  
### To create an assembly with an .exe extension  
  
1.  At the command prompt, type the following command:  
  
     \<*compiler command*> \<*module name*>  
  
     In this command, *compiler command* is the compiler command for the language used in your code module, and *module name* is the name of the code module to compile into the assembly.  
  
 The following example creates an assembly named `myCode.exe` from a code module called `myCode`.  
  
```console
csc myCode.cs  
```  

```console
vbc myCode.vb  
```  
  
#### To create an assembly with an .exe extension and specify the output file name  
  
1.  At the command prompt, type the following command:  
  
     \<*compiler command*> **/out:**\<*file name*> \<*module name*>  
  
     In this command, *compiler command* is the compiler command for the language used in your code module, *file name* is the output file name, and *module name* is the name of the code module to compile into the assembly.  
  
 The following example creates an assembly named `myAssembly.exe` from a code module called `myCode`.  
  
```console  
csc -out:myAssembly.exe myCode.cs  
```  
  
```console
vbc -out:myAssembly.exe myCode.vb  
```  
  
## Creating Library Assemblies  
 A library assembly is similar to a class library. It contains types that will be referenced by other assemblies, but it has no entry point to begin execution.  
  
#### To create a library assembly  
  
1.  At the command prompt, type the following command:  
  
     \<*compiler command*> **-t:library** \<*module name*>  
  
     In this command, *compiler command* is the compiler command for the language used in your code module, and *module name* is the name of the code module to compile into the assembly. You can also use other compiler options, such as the **-out:** option.  
  
 The following example creates a library assembly named `myCodeAssembly.dll` from a code module called `myCode`.  
  
```console  
csc -out:myCodeLibrary.dll -t:library myCode.cs  
```  
  
```console
vbc -out:myCodeLibrary.dll -t:library myCode.vb  
```  
  
## See Also  
 [Creating Assemblies](../../../docs/framework/app-domains/create-assemblies.md)  
 [Multifile Assemblies](../../../docs/framework/app-domains/multifile-assemblies.md)  
 [How to: Build a Multifile Assembly](../../../docs/framework/app-domains/how-to-build-a-multifile-assembly.md)  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)
