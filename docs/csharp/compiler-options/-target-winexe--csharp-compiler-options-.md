---
title: "-target:winexe (C# Compiler Options)"
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
  - "/target:winexe"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/target compiler options [C#], /target:winexe"
  - "-target compiler options [C#], /target:winexe"
  - "target compiler options [C#], /target:winexe"
ms.assetid: b5a0619c-8caa-46a5-a743-1cf68408ad7a
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# /target:winexe (C# Compiler Options)
The **/target:winexe** option causes the compiler to create an executable (EXE), Windows program.  
  
## Syntax  
  
```  
/target:winexe  
```  
  
## Remarks  
 The executable file will be created with the .exe extension. A Windows program is one that provides a user interface from either the .NET Framework library or with the Win32 APIs.  
  
 Use [/target:exe](../compiler-options/-target-exe--csharp-compiler-options-.md) to create a console application.  
  
 Unless otherwise specified with the [/out](../compiler-options/-out--csharp-compiler-options-.md) option, the output file name takes the name of the input file that contains the [Main](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md) method.  
  
 When specified at the command line, all files until the next **/out** or [/target](../compiler-options/-target--csharp-compiler-options-.md) option are used to create the Windows program.  
  
 One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [/main](../compiler-options/-main--csharp-compiler-options-.md) option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Output type** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType*>.  
  
## Example  
 Compile `in.cs` into a Windows program:  
  
```  
csc /target:winexe in.cs  
```  
  
## See Also  
 [/target (C# Compiler Options)](../compiler-options/-target--csharp-compiler-options-.md)   
 [C# Compiler Options](../compiler-options/csharp-compiler-options.md)