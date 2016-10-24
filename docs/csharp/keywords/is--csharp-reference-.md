---
title: "is (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
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
 [!code[csrefKeywordsOperator#4](../keywords/codesnippet/CSharp/is--csharp-reference-_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [typeof](../keywords/typeof--csharp-reference-.md)   
 [as](../keywords/as--csharp-reference-.md)   
 [Operator Keywords](../keywords/operator-keywords--csharp-reference-.md)