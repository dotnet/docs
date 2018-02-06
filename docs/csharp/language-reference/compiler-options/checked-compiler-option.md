---
title: "-checked (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/checked"
helpviewer_keywords: 
  - "checked compiler option [C#]"
  - "-checked compiler option [C#]"
  - "/checked compiler option [C#]"
ms.assetid: fb7475d3-e6a6-4e6d-b86c-69e7a74c854b
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# -checked (C# Compiler Options)
The **-checked** option specifies whether an integer arithmetic statement that results in a value that is outside the range of the data type, and that is not in the scope of a [checked](../../../csharp/language-reference/keywords/checked.md) or [unchecked](../../../csharp/language-reference/keywords/unchecked.md) keyword, causes a run-time exception.  
  
## Syntax  
  
```console  
-checked[+ | -]  
```  
  
## Remarks  
 An integer arithmetic statement that is in the scope of a `checked` or `unchecked` keyword is not subject to the effect of the **-checked** option.  
  
 If an integer arithmetic statement that is not in the scope of a `checked` or `unchecked` keyword results in a value outside the range of the data type, and **-checked+** (**-checked**) is used in the compilation, that statement causes an exception at run time. If **-checked-** is used in the compilation, that statement does not cause an exception at run time.  
  
 The default value for this option is **-checked-**. One scenario for using **-checked-** is in building large applications. Sometimes automated tools are used to build such applications, and such a tool might automatically set **-checked** to +. You can override the tool's global default by specifying **-checked-**.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page. For more information, see [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp).  
  
2.  Click the **Build** property page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **Check for arithmetic overflow/underflow** property.  
  
 To access this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.CheckForOverflowUnderflow%2A>.  
  
## Example  
 The following command compiles `t2.cs`. The use of `-checked` in the command specifies that any integer arithmetic statement in the file that is not in the scope of a `checked` or `unchecked` keyword, and that results in a value that is outside the range of the data type, causes an exception at run time.  
  
```console  
csc t2.cs -checked  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  
