---
title: "-target:module (C# Compiler Options) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "/target:module"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "-target compiler options [C#], /target:module"
  - "target compiler options [C#], /target:module"
  - "/target compiler options [C#], /target:module"
ms.assetid: 9af1e4fa-c749-44e7-ae58-90a3d05d4e72
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /target:module (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This option causes the compiler to not generate an assembly manifest.  
  
## Syntax  
  
```  
/target:module  
```  
  
## Remarks  
 By default, the output file created by compiling with this option will have an extension of .netmodule.  
  
 A file that does not have an assembly manifest cannot be loaded by the .NET Framework common language runtime. However, such a file can be incorporated into the assembly manifest of an assembly by means of [/addmodule](../../../csharp/language-reference/compiler-options/addmodule-csharp-compiler-options.md).  
  
 If more than one module is created in a single compilation, [internal](../../../csharp/language-reference/keywords/internal.md) types in one module will be available to other modules in the compilation. When code in one module references `internal` types in another module, then both modules must be incorporated into an assembly manifest, by means of **/addmodule**.  
  
 Creating a module is not supported in the Visual Studio development environment.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 Compile `in.cs`, creating `in.netmodule`:  
  
```  
csc /target:module in.cs  
```  
  
## See Also  
 [/target (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-csharp-compiler-options.md)   
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)