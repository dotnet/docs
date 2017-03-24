---
title: "-fullpaths (C# Compiler Options) | Microsoft Docs"
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
  - "/fullpaths"
dev_langs: 
  - "CSharp"
  - "CSharp"
helpviewer_keywords: 
  - "/fullpaths compiler option [C#]"
  - "absolute paths [C#]"
  - "fullpaths compiler option [C#]"
  - "full paths [C#]"
  - "-fullpaths compiler option [C#]"
ms.assetid: d2a5f857-cbb2-430b-879c-d648aaf0b8c4
caps.latest.revision: 10
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /fullpaths (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/fullpaths** option causes the compiler to specify the full path to the file when listing compilation errors and warnings.  
  
## Syntax  
  
```  
/fullpaths  
```  
  
## Remarks  
 By default, errors and warnings that result from compilation specify the name of the file in which an error was found. The **/fullpaths** option causes the compiler to specify the full path to the file.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)