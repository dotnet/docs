---
title: "-noconfig (C# Compiler Options) | Microsoft Docs"
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
  - "/noconfig"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/noconfig compiler option [C#]"
  - "csc.rsp"
  - "-noconfig compiler option [C#]"
  - "noconfig compiler option [C#]"
ms.assetid: cd26967e-e494-4c8c-b5c9-af13b2f78b2e
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /noconfig (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/noconfig** option tells the compiler not to compile with the csc.rsp file, which is located in and loaded from the same directory as the csc.exe file.  
  
## Syntax  
  
```  
/noconfig  
```  
  
## Remarks  
 The csc.rsp file references all the assemblies shipped with the .NET Framework. The actual references that the Visual Studio .NET development environment includes depend on the project type.  
  
 You can modify the csc.rsp file and specify additional compiler options that should be included in every compilation from the command line with csc.exe (except the **/noconfig** option).  
  
 The compiler processes the options passed to the **csc** command last. Therefore, any option on the command line overrides the setting of the same option in the csc.rsp file.  
  
 If you do not want the compiler to look for and use the settings in the csc.rsp file, specify **/noconfig**.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)