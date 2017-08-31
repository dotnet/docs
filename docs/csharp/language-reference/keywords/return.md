---
title: "return (C# Reference) | Microsoft Docs"
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
  - "return_CSharpKeyword"
  - "return"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "return statement [C#]"
  - "return keyword [C#]"
ms.assetid: 6da6e152-5b58-4448-8f3f-470dd0617ecd
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# return (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `return` statement terminates execution of the method in which it appears and returns control to the calling method. It can also return an optional value. If the method is a `void` type, the `return` statement can be omitted.  
  
 If the return statement is inside a `try` block, the `finally` block, if one exists, will be executed before control returns to the calling method.  
  
## Example  
 In the following example, the method `A()` returns the variable `Area` as a [double](../../../csharp/language-reference/keywords/double.md) value.  
  
 [!code-csharp[csrefKeywordsJump#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#6)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [return Statement](/visual-cpp/cpp/return-statement-cpp)   
 [Jump Statements](../../../csharp/language-reference/keywords/jump-statements.md)