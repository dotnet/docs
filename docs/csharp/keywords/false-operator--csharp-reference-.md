---
title: "false Operator (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "false operator keyword [C#]"
ms.assetid: 81a888fd-011e-4589-b242-6c261fea505e
caps.latest.revision: 21
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
# false Operator (C# Reference)
Returns the [bool](../keywords/bool--csharp-reference-.md) value `true` to indicate that an operand is `false` and returns `false` otherwise.  
  
 Prior to C# 2.0, the `true` and `false` operators were used to create user-defined nullable value types that were compatible with types such as `SqlBool`. However, the language now provides built-in support for nullable value types, and whenever possible you should use those instead of overloading the `true` and `false` operators. For more information, see [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md).  
  
 With nullable Booleans, the expression `a != b` is not necessarily equal to `!(a == b)` because one or both of the values might be null. You have to overload both the `true` and `false` operators separately to correctly handle the null values in the expression. The following example shows how to overload and use the `true` and `false` operators.  
  
 [!code[csrefKeywordsOperator#16](../keywords/codesnippet/CSharp/false-operator--csharp-reference-_1.cs)]  
  
 A type that overloads the `true` and `false` operators can be used for the controlling expression in [if](../keywords/if-else--csharp-reference-.md), [do](../keywords/do--csharp-reference-.md), [while](../keywords/while--csharp-reference-.md), and [for](../keywords/for--csharp-reference-.md) statements and in [conditional expressions](../operators/---operator--csharp-reference-.md).  
  
 If a type defines operator `false`, it must also define operator [true](../keywords/true--csharp-reference-.md).  
  
 A type cannot directly overload the conditional logical operators [&&](../operators/---operator--csharp-reference-.md) and [&#124;&#124;](../operators/---operator--csharp-reference-.md), but an equivalent effect can be achieved by overloading the regular logical operators and operators `true` and `false`.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [true](../keywords/true--csharp-reference-.md)