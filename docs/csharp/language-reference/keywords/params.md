---
title: "params (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "params_CSharpKeyword"
  - "params"
helpviewer_keywords: 
  - "parameters [C#], params"
  - "params keyword [C#]"
ms.assetid: 1690815e-b52b-4967-8380-5780aff08012
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# params (C# Reference)
By using the `params` keyword, you can specify a [method parameter](../../../csharp/language-reference/keywords/method-parameters.md) that takes a variable number of arguments.  
  
 You can send a comma-separated list of arguments of the type specified in the parameter declaration or an array of arguments of the specified type. You also can send no arguments. If you send no arguments, the length of the `params` list is zero.  
  
 No additional parameters are permitted after the `params` keyword in a method declaration, and only one `params` keyword is permitted in a method declaration.  
  
## Example  
 The following example demonstrates various ways in which arguments can be sent to a `params` parameter.  
  
 [!code-csharp[csrefKeywordsMethodParams#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/params_1.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Method Parameters](../../../csharp/language-reference/keywords/method-parameters.md)
