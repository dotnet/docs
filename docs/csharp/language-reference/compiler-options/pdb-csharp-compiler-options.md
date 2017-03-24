---
title: "-pdb (C# Compiler Options) | Microsoft Docs"
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
  - "/pdb"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "-pdb compiler option [C#]"
  - "pdb compiler option [C#]"
  - "/pdb compiler option [C#]"
ms.assetid: e9d0f96a-5b75-45d6-9765-92538dd5f823
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /pdb (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/pdb** compiler option specifies the name and location of the debug symbols file.  
  
## Syntax  
  
```  
/pdb:filename  
```  
  
## Arguments  
 `filename`  
 The name and location of the debug symbols file.  
  
## Remarks  
 When you specify [/debug (C# Compiler Options)](../../../csharp/language-reference/compiler-options/debug-csharp-compiler-options.md), the compiler will create a .pdb file in the same directory where the compiler will create the output file (.exe or .dll) with a file name that is the same as the name of the output file.  
  
 **/pdb** allows you to specify a non-default file name and location for the .pdb file.  
  
 This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically.  
  
## Example  
 Compile `t.cs` and create a .pdb file called tt.pdb:  
  
```  
csc /debug /pdb:tt t.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)