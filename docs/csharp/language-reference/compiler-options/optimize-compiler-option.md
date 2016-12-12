---
title: "-optimize (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/optimize"
dev_langs: 
  - "CSharp"
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
# /optimize (C# Compiler Options)
The **/optimize** option enables or disables optimizations performed by the compiler to make your output file smaller, faster, and more efficient.  
  
## Syntax  
  
```  
/optimize[+ | -]  
```  
  
## Remarks  
 **/optimize** also tells the common language runtime to optimize code at runtime.  
  
 By default, optimizations are disabled. Specify **/optimize+** to enable optimizations.  
  
 When building a module to be used by an assembly, use the same **/optimize** settings as those of the assembly.  
  
 **/o** is the short form of **/optimize**.  
  
 It is possible to combine the **/optimize** and [/debug](../../../csharp/language-reference/compiler-options/debug-compiler-option.md) options.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Modify the **Optimize Code** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.Optimize%2A>.  
  
## Example  
 Compile `t2.cs` and enable compiler optimizations:  
  
```  
csc t2.cs /optimize  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)