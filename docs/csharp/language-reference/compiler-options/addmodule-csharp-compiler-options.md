---
title: "-addmodule (C# Compiler Options) | Microsoft Docs"
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
  - "/addmodule"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/addmodule compiler option [C#]"
  - "-addmodule compiler option [C#]"
  - "addmodule compiler option [C#]"
ms.assetid: ed604546-0dc2-4bd4-9a3e-610a8d973e58
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /addmodule (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This option adds a module that was created with the target:module switch to the current compilation.  
  
## Syntax  
  
```  
/addmodule:file[;file2]  
```  
  
## Arguments  
 `file`, `file2`  
 An output file that contains metadata. The file cannot contain an assembly manifest. To import more than one file, separate file names with either a comma or a semicolon.  
  
## Remarks  
 All modules added with **/addmodule** must be in the same directory as the output file at run time. That is, you can specify a module in any directory at compile time but the module must be in the application directory at run time. If the module is not in the application directory at run time, you will get a <xref:System.TypeLoadException>.  
  
 `file` cannot contain an assembly. For example, if the output file was created with [/target:module](../../../csharp/language-reference/compiler-options/target-module-csharp-compiler-options.md), its metadata can be imported with **/addmodule**.  
  
 If the output file was created with a **/target** option other than **/target:module**, its metadata cannot be imported with **/addmodule** but can be imported with [/reference](../../../csharp/language-reference/compiler-options/reference-csharp-compiler-options.md).  
  
 This compiler option is unavailable in Visual Studio; a project cannot reference a module. In addition, this compiler option cannot be changed programmatically.  
  
## Example  
 Compile source file `input.cs` and add metadata from `metad1.netmodule` and `metad2.netmodule` to produce `out.exe`:  
  
```  
csc /addmodule:metad1.netmodule;metad2.netmodule /out:out.exe input.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 [Multifile Assemblies](../Topic/Multifile%20Assemblies.md)   
 [How to: Build a Multifile Assembly](../Topic/How%20to:%20Build%20a%20Multifile%20Assembly.md)