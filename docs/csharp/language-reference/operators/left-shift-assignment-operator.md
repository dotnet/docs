---
title: "&lt;&lt;= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "<<=_CSharpKeyword"
helpviewer_keywords: 
  - "<<= operator (left-shift assignment) [C#]"
  - "left shift assignment operator (<<=) [C#]"
ms.assetid: 3bc99c78-1edb-4827-86fc-bce6c3048871
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;&lt;= Operator (C# Reference)
The left-shift assignment operator.  
  
## Remarks  
 An expression of the form  
  
```  
x <<= y  
```  
  
 is evaluated as  
  
```  
x = x << y  
```  
  
 except that `x` is only evaluated once. The [<< operator](../../../csharp/language-reference/operators/left-shift-operator.md) shifts `x` left by the number of bits specified by `y`.  
  
 The `<<=` operator cannot be overloaded directly, but user-defined types can overload the [<< operator](../../../csharp/language-reference/operators/left-shift-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#12](../../../csharp/language-reference/operators/codesnippet/CSharp/left-shift-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
