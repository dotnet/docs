---
title: "explicit (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "explicit_CSharpKeyword"
  - "explicit"
helpviewer_keywords: 
  - "explicit keyword [C#]"
ms.assetid: cfb8f42a-e411-4db2-af9b-796b05644846
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# explicit (C# Reference)
The `explicit` keyword declares a user-defined type conversion operator that must be invoked with a cast. For example, this operator converts from a class called Fahrenheit to a class called Celsius:  
  
 [!code-csharp[csrefKeywordsConversion#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/explicit_1.cs)]  
  
 This conversion operator can be invoked like this:  
  
 [!code-csharp[csrefKeywordsConversion#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/explicit_2.cs)]  
  
 The conversion operator converts from a source type to a target type. The source type provides the conversion operator. Unlike implicit conversion, explicit conversion operators must be invoked by means of a cast. If a conversion operation can cause exceptions or lose information, you should mark it `explicit`. This prevents the compiler from silently invoking the conversion operation with possibly unforeseen consequences.  
  
 Omitting the cast results in compile-time error CS0266.  
  
 For more information, see [Using Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/using-conversion-operators.md).  
  
## Example  
 The following example provides a `Fahrenheit` and a `Celsius` class, each of which provides an explicit conversion operator to the other class.  
  
 [!code-csharp[csrefKeywordsConversion#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/explicit_3.cs)]  
  
## Example  
 The following example defines a struct, `Digit`, that represents a single decimal digit. An operator is defined for conversions from `byte` to `Digit`, but because not all bytes can be converted to a `Digit`, the conversion is explicit.  
  
 [!code-csharp[csrefKeywordsConversion#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/explicit_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [implicit](../../../csharp/language-reference/keywords/implicit.md)  
 [operator (C# Reference)](../../../csharp/language-reference/keywords/operator.md)  
 [How to: Implement User-Defined Conversions Between Structs](../../../csharp/programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)  
 [Chained user-defined explicit conversions in C#](https://blogs.msdn.microsoft.com/ericlippert/2007/04/16/chained-user-defined-explicit-conversions-in-c/)
