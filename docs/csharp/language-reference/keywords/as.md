---
title: "as (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "as_CSharpKeyword"
  - "as"
helpviewer_keywords: 
  - "type conversion [C#], as keyword"
  - "as keyword [C#]"
ms.assetid: a9be126b-cbf4-4990-a70d-d0e1983cad0e
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# as (C# Reference)
You can use the `as` operator to perform certain types of conversions between compatible reference types or [nullable types](../../../csharp/programming-guide/nullable-types/index.md). The following code shows an example.  
  
 [!code-csharp[csrefKeywordsOperator#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/as_1.cs)]  
  
## Remarks  
 The `as` operator is like a cast operation. However, if the conversion isn't possible, `as` returns `null` instead of raising an exception. Consider the following example:  
  
```  
expression as type  
```  
  
 The code is equivalent to the following expression except that the `expression` variable is evaluated only one time.  
  
```  
expression is type ? (type)expression : (type)null  
```  
  
 Note that the `as` operator performs only reference conversions, nullable conversions, and boxing conversions. The `as` operator can't perform other conversions, such as user-defined conversions, which should instead be performed by using cast expressions.  
  
## Example  
 [!code-csharp[csrefKeywordsOperator#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/as_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [is](../../../csharp/language-reference/keywords/is.md)  
 [?: Operator](../../../csharp/language-reference/operators/conditional-operator.md)  
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)
