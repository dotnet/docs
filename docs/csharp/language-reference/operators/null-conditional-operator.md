---
title: "?? Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "??_CSharpKeyword"
helpviewer_keywords: 
  - "coalesce operator [C#]"
  - "?? operator [C#]"
  - "conditional-AND operator (&&) [C#]"
ms.assetid: 088b1f0d-c1af-4fe1-b4b8-196fd5ea9132
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# ?? Operator (C# Reference)
The `??` operator is called the null-coalescing operator.  It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.  
  
## Remarks  
 A nullable type can represent a value from the type’s domain, or the value can be undefined (in which case the value is null). You can use the `??` operator’s syntactic expressiveness to return an appropriate value (the right hand operand) when the left operand has a nullable type whose value is null. If you try to assign a nullable value type to a non-nullable value type without using the `??` operator, you will generate a compile-time error. If you use a cast, and the nullable value type is currently undefined, an `InvalidOperationException` exception will be thrown.  
  
 For more information, see [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md).  
  
 The result of a ?? operator is not considered to be a constant even if both its arguments are constants.  
  
## Example  
 [!code-csharp[csRefOperators#53](../../../csharp/language-reference/operators/codesnippet/CSharp/null-conditional-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
 [What Exactly Does 'Lifted' mean?](https://blogs.msdn.microsoft.com/ericlippert/2007/06/27/what-exactly-does-lifted-mean/)
