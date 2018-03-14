---
title: "-target:library (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/dll"
helpviewer_keywords: 
  - "-target compiler options [C#], /target:library"
  - "target compiler options [C#], /target:library"
  - "/target compiler options [C#], /target:library"
ms.assetid: c5670e88-2126-47c1-8d1c-217923837d17
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# -target:library (C# Compiler Options)
The **-target:library** option causes the compiler to create a dynamic-link library (DLL) rather than an executable file (EXE).  
  
## Syntax  
  
```console  
-target:library  
```  
  
## Remarks  
 The DLL will be created with the .dll extension.  
  
 Unless otherwise specified with the [-out](../../../csharp/language-reference/compiler-options/out-compiler-option.md) option, the output file name takes the name of the first input file.  
  
 When specified at the command line, all files up to the next **-out** or **-target:module** option are used to create the .dll file.  
  
 When building a .dll file, a [Main](../../../csharp/programming-guide/main-and-command-args/index.md) method is not required.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Output type** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 Compile `in.cs`, creating `in.dll`:  
  
```console  
csc -target:library in.cs  
```  
  
## See Also  
 [-target (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-compiler-option.md)  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
