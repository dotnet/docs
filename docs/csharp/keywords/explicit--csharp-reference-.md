---
title: "explicit (C# Reference)"
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
# explicit (C# Reference)
The `explicit` keyword declares a user-defined type conversion operator that must be invoked with a cast. For example, this operator converts from a class called Fahrenheit to a class called Celsius:  
  
 [!code[csrefKeywordsConversion#2](../keywords/codesnippet/CSharp/explicit--csharp-reference-_1.cs)]  
  
 This conversion operator can be invoked like this:  
  
 [!code[csrefKeywordsConversion#3](../keywords/codesnippet/CSharp/explicit--csharp-reference-_2.cs)]  
  
 The conversion operator converts from a source type to a target type. The source type provides the conversion operator. Unlike implicit conversion, explicit conversion operators must be invoked by means of a cast. If a conversion operation can cause exceptions or lose information, you should mark it `explicit`. This prevents the compiler from silently invoking the conversion operation with possibly unforeseen consequences.  
  
 Omitting the cast results in compile-time error CS0266.  
  
 For more information, see [Using Conversion Operators](../statements-expressions-operators/using-conversion-operators--csharp-programming-guide-.md).  
  
## Example  
 The following example provides a `Fahrenheit` and a `Celsius` class, each of which provides an explicit conversion operator to the other class.  
  
 [!code[csrefKeywordsConversion#1](../keywords/codesnippet/CSharp/explicit--csharp-reference-_3.cs)]  
  
## Example  
 The following example defines a struct, `Digit`, that represents a single decimal digit. An operator is defined for conversions from `byte` to `Digit`, but because not all bytes can be converted to a `Digit`, the conversion is explicit.  
  
 [!code[csrefKeywordsConversion#4](../keywords/codesnippet/CSharp/explicit--csharp-reference-_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [implicit](../keywords/implicit--csharp-reference-.md)   
 [operator (C# Reference)](../keywords/operator--csharp-reference-2.md)   
 [How to: Implement User-Defined Conversions Between Structs](../statements-expressions-operators/97839aef-8fbc-40d5-9769-6b569bc2710b.md)   
 [Chained user-defined explicit conversions in C#](http://go.microsoft.com/fwlink/?LinkId=112384)