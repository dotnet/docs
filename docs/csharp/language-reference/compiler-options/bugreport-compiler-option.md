---
title: "-bugreport (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/bugreport"
helpviewer_keywords: 
  - "/bugreport compiler option [C#]"
  - "-bugreport compiler option [C#]"
  - "bugreport compiler option [C#]"
ms.assetid: f39665e3-4f6f-4357-88a2-3274c7bec0c1
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# -bugreport (C# Compiler Options)
Specifies that debug information should be placed in a file for later analysis.  
  
## Syntax  
  
```console  
-bugreport:file  
```  
  
## Arguments  
 `file`  
 The name of the file that you want to contain your bug report.  
  
## Remarks  
 The **-bugreport** option specifies that the following information should be placed in `file`:  
  
-   A copy of all source code files in the compilation.  
  
-   A listing of the compiler options used in the compilation.  
  
-   Version information about your compiler, run time, and operating system.  
  
-   Referenced assemblies and modules, saved as hexadecimal digits, except assemblies that ship with the .NET Framework and SDK.  
  
-   Compiler output, if any.  
  
-   A description of the problem, which you will be prompted for.  
  
-   A description of how you think the problem should be fixed, which you will be prompted for.  
  
 If this option is used with **-errorreport:prompt** or **-errorreport:send**, the information in the file will be sent to Microsoft Corporation.  
  
 Because a copy of all source code files will be placed in `file`, you might want to reproduce the suspected code defect in the shortest possible program.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
 Notice that contents of the generated file expose source code that could result in inadvertent information disclosure.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [-errorreport (C# Compiler Options)](../../../csharp/language-reference/compiler-options/errorreport-compiler-option.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
