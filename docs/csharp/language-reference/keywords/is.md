---
title: "is (C# Reference) | Microsoft Docs"
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
---
# is (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

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
 [!code-csharp[csrefKeywordsOperator#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#4)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [typeof](../../../csharp/language-reference/keywords/typeof.md)   
 [as](../../../csharp/language-reference/keywords/as.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)