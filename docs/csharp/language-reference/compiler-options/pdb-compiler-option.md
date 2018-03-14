---
title: "-pdb (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/pdb"
helpviewer_keywords: 
  - "-pdb compiler option [C#]"
  - "pdb compiler option [C#]"
  - "/pdb compiler option [C#]"
ms.assetid: e9d0f96a-5b75-45d6-9765-92538dd5f823
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
---
# -pdb (C# Compiler Options)
The **-pdb** compiler option specifies the name and location of the debug symbols file.  
  
## Syntax  
  
```console  
-pdb:filename  
```  
  
## Arguments  
 `filename`  
 The name and location of the debug symbols file.  
  
## Remarks  
 When you specify [-debug (C# Compiler Options)](../../../csharp/language-reference/compiler-options/debug-compiler-option.md), the compiler will create a .pdb file in the same directory where the compiler will create the output file (.exe or .dll) with a file name that is the same as the name of the output file.  
  
 **-pdb** allows you to specify a non-default file name and location for the .pdb file.  
  
 This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically.  
  
## Example  
 Compile `t.cs` and create a .pdb file called tt.pdb:  
  
```console  
csc -debug -pdb:tt t.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
