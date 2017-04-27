---
title: "var (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "var"
  - "var_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "var keyword [C#]"
ms.assetid: 0777850a-2691-4e3e-927f-0c850f5efe15
caps.latest.revision: 13
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
# var (C# Reference)
Beginning in Visual C# 3.0, variables that are declared at method scope can have an implicit "type" `var`. An implicitly typed local variable is strongly typed just as if you had declared the type yourself, but the compiler determines the type. The following two declarations of `i` are functionally equivalent:  
  
```  
var i = 10; // implicitly typed  
int i = 10; //explicitly typed  
```  
  
 For more information, see [Implicitly Typed Local Variables](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) and [Type Relationships in LINQ Query Operations](../../../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md).  
  
## Example  
 The following example shows two query expressions. In the first expression, the use of `var` is permitted but is not required, because the type of the query result can be stated explicitly as an `IEnumerable<string>`. However, in the second expression, `var` must be used because the result is a collection of anonymous types, and the name of that type is not accessible except to the compiler itself. Note that in Example #2, the `foreach` iteration variable `item` must also be implicitly typed.  
  
 [!code-cs[csrefKeywordsTypes#18](../../../csharp/language-reference/keywords/codesnippet/CSharp/var_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Implicitly Typed Local Variables](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md)
