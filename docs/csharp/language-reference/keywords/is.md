---
title: "is (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "is_CSharpKeyword"
  - "is"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "is keyword [C#]"
ms.assetid: bc62316a-d41f-4f90-8300-c6f4f0556e43
caps.latest.revision: 20
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
# is (C# Reference)
Checks if an object is compatible with a given type. For example, the following code can determine if an object is an instance of the `MyObject` type, or a type that derives from `MyObject`:  
  
```  
if (obj is MyObject)  
{  
}  
```  
  
 An `is` expression evaluates to `true` if the provided expression is non-null, and the provided object can be cast to the provided type without causing an exception to be thrown.  
  
 The `is` keyword causes a compile-time warning if the expression is known to always be `true` or to always be `false`, but typically evaluates type compatibility at run time.  
  
 The `is` operator cannot be overloaded.  
  
 Note that the `is` operator only considers reference conversions, boxing conversions, and unboxing conversions. Other conversions, such as user-defined conversions, are not considered.  
  
 Anonymous methods are not allowed on the left side of the `is` operator. This exception includes lambda expressions.  
  
## Example  
 [!code-cs[csrefKeywordsOperator#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/is_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [typeof](../../../csharp/language-reference/keywords/typeof.md)   
 [as](../../../csharp/language-reference/keywords/as.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)