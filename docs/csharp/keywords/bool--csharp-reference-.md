---
title: "bool (C# Reference)"
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
  - "bool_CSharpKeyword"
  - "bool"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "bool keyword [C#]"
ms.assetid: 551cfe35-2632-4343-af49-33ad12da08e2
caps.latest.revision: 30
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
# bool (C# Reference)
The `bool` keyword is an alias of <xref:System.Boolean?displayProperty=fullName>. It is used to declare variables to store the Boolean values, [true](../keywords/true--csharp-reference-.md) and [false](../keywords/false--csharp-reference-.md).  
  
> [!NOTE]
>  If you require a Boolean variable that can also have a value of `null`, use `bool?`. For more information, see [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md).  
  
## Literals  
 You can assign a Boolean value to a `bool` variable. You can also assign an expression that evaluates to `bool` to a `bool` variable.  
  
 [!code[csrefKeywordsTypes#1](../keywords/codesnippet/CSharp/bool--csharp-reference-_1.cs)]  
  
 The default value of a `bool` variable is `false`. The default value of a `bool?` variable is `null`.  
  
## Conversions  
 In C++, a value of type `bool` can be converted to a value of type `int`; in other words, `false` is equivalent to zero and `true` is equivalent to nonzero values. In C#, there is no conversion between the `bool` type and other types. For example, the following `if` statement is invalid in C#:  
  
 [!code[csrefKeywordsTypes#2](../keywords/codesnippet/CSharp/bool--csharp-reference-_2.cs)]  
  
 To test a variable of the type `int`, you have to explicitly compare it to a value, such as zero, as follows:  
  
 [!code[csrefKeywordsTypes#3](../keywords/codesnippet/CSharp/bool--csharp-reference-_3.cs)]  
  
## Example  
 In this example, you enter a character from the keyboard and the program checks if the input character is a letter. If it is a letter, it checks if it is lowercase or uppercase. These checks are performed with the <xref:System.Char.IsLetter*>, and <xref:System.Char.IsLower*>, both of which return the `bool` type:  
  
 [!code[csrefKeywordsTypes#4](../keywords/codesnippet/CSharp/bool--csharp-reference-_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Integral Types Table](../keywords/integral-types-table--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md)   
 [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md)