---
title: "^= Operator (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "^=_CSharpKeyword"
helpviewer_keywords: 
  - "^= operator [C#]"
ms.assetid: 3658ff9a-61cd-467e-ad6b-8fbf1cfbaae4
---
# ^= Operator (C# Reference)
The exclusive-OR assignment operator.  
  
## Remarks  
 An expression of the form  
  
```csharp  
x ^= y  
```  
  
 is evaluated as  
  
```csharp  
x = x ^ y  
```  
  
 except that `x` is only evaluated once. The [^ operator](../../../csharp/language-reference/operators/xor-operator.md) performs a bitwise exclusive-OR operation on integral operands and logical exclusive-OR on [bool](../../../csharp/language-reference/keywords/bool.md) operands.  
  
 The ^= operator cannot be overloaded directly, but user-defined types can overload the [^ operator](../../../csharp/language-reference/operators/xor-operator.md) (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#23](../../../csharp/language-reference/operators/codesnippet/CSharp/xor-assignment-operator_1.cs)]  
  
## See Also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Operators](../../../csharp/language-reference/operators/index.md)
