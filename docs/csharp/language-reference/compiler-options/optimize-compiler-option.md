---
title: "-optimize (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/optimize"
helpviewer_keywords: 
  - "/optimize compiler option [C#]"
  - "-o compiler option [C#]"
  - "optimize compiler option [C#]"
  - "/o compiler option [C#]"
  - "-optimize compiler option [C#]"
  - "compiler optimization [C#]"
  - "o compiler option [C#]"
ms.assetid: 6dd5b6f2-cd1d-4593-a9f4-1c2ed9404ca0
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# -optimize (C# Compiler Options)
The **-optimize** option enables or disables optimizations performed by the compiler to make your output file smaller, faster, and more efficient.  
  
## Syntax  
  
```console  
-optimize[+ | -]  
```  
  
## Remarks  
 **-optimize** also tells the common language runtime to optimize code at runtime.  
  
 By default, optimizations are disabled. Specify **-optimize+** to enable optimizations.  
  
 When building a module to be used by an assembly, use the same **-optimize** settings as those of the assembly.  
  
 **-o** is the short form of **-optimize**.  
  
 It is possible to combine the **-optimize** and [-debug](../../../csharp/language-reference/compiler-options/debug-compiler-option.md) options.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Modify the **Optimize Code** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.Optimize%2A>.  
  
## Example  
 Compile `t2.cs` and enable compiler optimizations:  
  
```console  
csc t2.cs -optimize  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
