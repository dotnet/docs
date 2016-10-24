---
title: "-target:exe (C# Compiler Options)"
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
  - "/exe"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "target compiler options [C#], /target:exe"
  - "/target compiler options [C#], /target:exe"
  - "-target compiler options [C#], /target:exe"
ms.assetid: bda5717d-1b91-4848-956b-fcf85c30e432
caps.latest.revision: 12
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
# /target:exe (C# Compiler Options)
The **/target:exe** option causes the compiler to create an executable (EXE), console application.  
  
## Syntax  
  
```  
/target:exe  
```  
  
## Remarks  
 The **/target:exe** option is in effect by default. The executable file will be created with the .exe extension.  
  
 Use [/target:winexe](../compiler-options/-target-winexe--csharp-compiler-options-.md) to create a Windows program executable.  
  
 Unless otherwise specified with the [/out](../compiler-options/-out--csharp-compiler-options-.md) option, the output file name takes the name of the input file that contains the [Main](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md) method.  
  
 When specified at the command line, all files up to the next **/out** or **/target:module** option are used to create the .exe file  
  
 One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [/main](../compiler-options/-main--csharp-compiler-options-.md) compiler option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Output type** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType*>.  
  
## Example  
 Each of the following command lines will compile `in.cs`, creating `in.exe`:  
  
```  
csc /target:exe in.cs  
csc in.cs  
```  
  
## See Also  
 [/target (C# Compiler Options)](../compiler-options/-target--csharp-compiler-options-.md)   
 [C# Compiler Options](../compiler-options/csharp-compiler-options.md)