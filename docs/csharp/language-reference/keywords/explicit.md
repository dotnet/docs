---
title: "explicit (C# Reference) | Microsoft Docs"
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
  - "explicit_CSharpKeyword"
  - "explicit"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "explicit keyword [C#]"
ms.assetid: cfb8f42a-e411-4db2-af9b-796b05644846
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# explicit (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `explicit` keyword declares a user-defined type conversion operator that must be invoked with a cast. For example, this operator converts from a class called Fahrenheit to a class called Celsius:  
  
 [!code-csharp[csrefKeywordsConversion#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#2)]  
  
 This conversion operator can be invoked like this:  
  
 [!code-csharp[csrefKeywordsConversion#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#3)]  
  
 The conversion operator converts from a source type to a target type. The source type provides the conversion operator. Unlike implicit conversion, explicit conversion operators must be invoked by means of a cast. If a conversion operation can cause exceptions or lose information, you should mark it `explicit`. This prevents the compiler from silently invoking the conversion operation with possibly unforeseen consequences.  
  
 Omitting the cast results in compile-time error CS0266.  
  
 For more information, see [Using Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/using-conversion-operators.md).  
  
## Example  
 The following example provides a `Fahrenheit` and a `Celsius` class, each of which provides an explicit conversion operator to the other class.  
  
 [!code-csharp[csrefKeywordsConversion#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#1)]  
  
## Example  
 The following example defines a struct, `Digit`, that represents a single decimal digit. An operator is defined for conversions from `byte` to `Digit`, but because not all bytes can be converted to a `Digit`, the conversion is explicit.  
  
 [!code-csharp[csrefKeywordsConversion#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#4)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [implicit](../../../csharp/language-reference/keywords/implicit.md)   
 [operator (C# Reference)](../../../csharp/language-reference/keywords/operator-csharp-reference.md)   
 [How to: Implement User-Defined Conversions Between Structs](../../../csharp/programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)   
 [Chained user-defined explicit conversions in C#](http://go.microsoft.com/fwlink/?LinkId=112384)