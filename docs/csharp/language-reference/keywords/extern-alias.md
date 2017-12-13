---
title: "extern alias (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "alias_CSharpKeyword"
helpviewer_keywords: 
  - "extern alias keyword [C#]"
  - "aliases [C#], extern keyword"
  - "aliases, extern keyword"
ms.assetid: f487bf4f-c943-4fca-851b-e540c83d9027
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# extern alias (C# Reference)
You might have to reference two versions of assemblies that have the same fully-qualified type names. For example, you might have to use two or more versions of an assembly in the same application. By using an external assembly alias, the namespaces from each assembly can be wrapped inside root-level namespaces named by the alias, which enables them to be used in the same file.  
  
> [!NOTE]
>  The [extern](../../../csharp/language-reference/keywords/extern.md) keyword is also used as a method modifier, declaring a method written in unmanaged code.  
  
 To reference two assemblies with the same fully-qualified type names, an alias must be specified at a command prompt, as follows:  
  
 `/r:GridV1=grid.dll`  
  
 `/r:GridV2=grid20.dll`  
  
 This creates the external aliases `GridV1` and `GridV2`. To use these aliases from within a program, reference them by using the `extern` keyword. For example:  
  
 `extern alias GridV1;`  
  
 `extern alias GridV2;`  
  
 Each extern alias declaration introduces an additional root-level namespace that parallels (but does not lie within) the global namespace. Thus types from each assembly can be referred to without ambiguity by using their fully qualified name, rooted in the appropriate namespace-alias.  
  
 In the previous example, `GridV1::Grid` would be the grid control from `grid.dll`, and `GridV2::Grid` would be the grid control from `grid20.dll`.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Namespace Keywords](../../../csharp/language-reference/keywords/namespace-keywords.md)  
 [:: Operator](../../../csharp/language-reference/operators/namespace-alias-qualifer.md)  
 [/reference (C# Compiler Options)](../../../csharp/language-reference/compiler-options/reference-compiler-option.md)
