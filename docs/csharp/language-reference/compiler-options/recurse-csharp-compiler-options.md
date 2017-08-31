---
title: "-recurse (C# Compiler Options) | Microsoft Docs"
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
  - "/recurse"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/recurse compiler option [C#]"
  - "recurse compiler option [C#]"
  - "-recurse compiler option [C#]"
ms.assetid: 4e8212e5-04e3-45b1-8a42-41bc50e683b0
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /recurse (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The /recurse option enables you to compile source code files in all child directories of either the specified directory (dir) or of the project directory.  
  
## Syntax  
  
```  
/recurse:[dir\]file  
```  
  
## Arguments  
 `dir` (optional)  
 The directory in which you want the search to begin. If this is not specified, the search begins in the project directory.  
  
 `file`  
 The file(s) to search for. Wildcard characters are allowed.  
  
## Remarks  
 The **/recurse** option lets you compile source code files in all child directories of either the specified directory (`dir`) or of the project directory.  
  
 You can use wildcards in a file name to compile all matching files in the project directory without using **/recurse**.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## Example  
 Compiles all C# files in the current directory:  
  
```  
csc *.cs  
```  
  
 Compiles all of the C# files in the dir1\dir2 directory and any directories below it and generates dir2.dll:  
  
```  
csc /target:library /out:dir2.dll /recurse:dir1\dir2\*.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)