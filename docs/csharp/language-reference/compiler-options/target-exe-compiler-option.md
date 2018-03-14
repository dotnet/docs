---
title: "-target:exe (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/exe"
helpviewer_keywords: 
  - "target compiler options [C#], /target:exe"
  - "/target compiler options [C#], /target:exe"
  - "-target compiler options [C#], /target:exe"
ms.assetid: bda5717d-1b91-4848-956b-fcf85c30e432
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# -target:exe (C# Compiler Options)
The **-target:exe** option causes the compiler to create an executable (EXE), console application.  
  
## Syntax  
  
```console  
-target:exe  
```  
  
## Remarks  
 The **-target:exe** option is in effect by default. The executable file will be created with the .exe extension.  
  
 Use [-target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-compiler-option.md) to create a Windows program executable.  
  
 Unless otherwise specified with the [-out](../../../csharp/language-reference/compiler-options/out-compiler-option.md) option, the output file name takes the name of the input file that contains the [Main](../../../csharp/programming-guide/main-and-command-args/index.md) method.  
  
 When specified at the command line, all files up to the next **-out** or **-target:module** option are used to create the .exe file  
  
 One and only one **Main** method is required in the source code files that are compiled into an .exe file. The [-main](../../../csharp/language-reference/compiler-options/main-compiler-option.md) compiler option lets you specify which class contains the **Main** method, in cases where your code has more than one class with a **Main** method.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Output type** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 Each of the following command lines will compile `in.cs`, creating `in.exe`:  
  
```console  
csc -target:exe in.cs  
csc in.cs  
```  
  
## See Also  
 [-target (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-compiler-option.md)  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
