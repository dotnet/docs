---
title: "-recurse (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/recurse"
helpviewer_keywords: 
  - "/recurse compiler option [C#]"
  - "recurse compiler option [C#]"
  - "-recurse compiler option [C#]"
ms.assetid: 4e8212e5-04e3-45b1-8a42-41bc50e683b0
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# -recurse (C# Compiler Options)
The -recurse option enables you to compile source code files in all child directories of either the specified directory (dir) or of the project directory.  
  
## Syntax  
  
```console  
-recurse:[dir\]file  
```  
  
## Arguments  
 `dir` (optional)  
 The directory in which you want the search to begin. If this is not specified, the search begins in the project directory.  
  
 `file`  
 The file(s) to search for. Wildcard characters are allowed.  
  
## Remarks  
 The **-recurse** option lets you compile source code files in all child directories of either the specified directory (`dir`) or of the project directory.  
  
 You can use wildcards in a file name to compile all matching files in the project directory without using **-recurse**.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## Example  
 Compiles all C# files in the current directory:  
  
```console  
csc *.cs  
```  
  
 Compiles all of the C# files in the dir1\dir2 directory and any directories below it and generates dir2.dll:  
  
```console  
csc -target:library -out:dir2.dll -recurse:dir1\dir2\*.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
