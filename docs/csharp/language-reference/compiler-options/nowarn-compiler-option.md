---
title: "-nowarn (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/nowarn"
helpviewer_keywords: 
  - "nowarn compiler option [C#]"
  - "/nowarn compiler option [C#]"
  - "-nowarn compiler option [C#]"
ms.assetid: 6dcbc5e8-ae67-4566-9df3-f63cfdd9c4e4
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# -nowarn (C# Compiler Options)
The **-nowarn** option lets you suppress the compiler from displaying one or more warnings. Separate multiple warning numbers with a comma.  
  
## Syntax  
  
```console  
-nowarn:number1[,number2,...]  
```  
  
## Arguments  
 `number1`, `number2`  
 Warning number(s) that you want the compiler to suppress.  
  
## Remarks  
 You should only specify the numeric part of the warning identifier. For example, if you want to suppress CS0028, you could specify `-nowarn:28`.  
  
 The compiler will silently ignore warning numbers passed to `-nowarn` that were valid in previous releases, but that have been removed from the compiler. For example, CS0679 was valid in the compiler in Visual Studio .NET 2002 but was subsequently removed.  
  
 The following warnings cannot be suppressed by the `-nowarn` option:  
  
-   Compiler Warning (level 1) CS2002  
  
-   Compiler Warning (level 1) CS2023  
  
-   Compiler Warning (level 1) CS2029  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the **Properties** page for the project. For details, see [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp).  
  
2.  Click the **Build** property page.  
  
3.  Modify the **Suppress Warnings** property.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.DelaySign%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  
 [C# Compiler Errors](../../../csharp/language-reference/compiler-messages/index.md)
