---
title: "-&gt; Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "->_CSharpKeyword"
helpviewer_keywords: 
  - "member access operator (->) [C#]"
  - "-> operator [C#]"
ms.assetid: e39ccdc1-f1ff-4a92-bf1d-ac2c8c11316a
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# -&gt; Operator (C# Reference)
The `->` operator combines pointer dereferencing and member access.  
  
## Remarks  
 An expression of the form,  
  
```  
x->y  
```  
  
 (where `x` is a pointer of type `T*` and `y` is a member of `T`) is equivalent to,  
  
```  
(*x).y  
```  
  
 The `->` operator can be used only in code that is marked as [unsafe](../../../csharp/language-reference/keywords/unsafe.md).  
  
 The `->` operator cannot be overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#15](../../../csharp/language-reference/operators/codesnippet/CSharp/dereference-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
