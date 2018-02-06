---
title: "-codepage (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/codepage"
helpviewer_keywords: 
  - "/codepage compiler option [C#]"
  - "codepage compiler option [C#]"
  - "-codepage compiler option [C#]"
ms.assetid: 75942989-b69a-4308-90a0-840c73d2c478
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# -codepage (C# Compiler Options)
This option specifies which codepage to use during compilation if the required page is not the current default codepage for the system.  
  
## Syntax  
  
```console  
-codepage:id  
```  
  
## Arguments  
 `id`  
 The id of the code page to use for all source code files in the compilation.  
  
## Remarks  
 If you compile one or more source code files that were not created to use the default code page on your computer, you can use the **-codepage** option to specify which code page should be used. **-codepage** applies to all source code files in your compilation.  
  
 If the source code files were created with the same codepage that is in effect on your computer or if the source code files were created with UNICODE or UTF-8, you need not use **-codepage**.  
  
 See [GetCPInfo](https://msdn.microsoft.com/library/dd318078(VS.85).aspx) for information on how to find which code pages are supported on your system.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
