---
title: "out parameter modifier (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "parameters [C#], out"
  - "out parameters [C#]"
ms.assetid: 3fce0dc5-03f4-4faa-bd61-36c41bc6baf1
caps.latest.revision: 9
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# out parameter modifier (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `out` keyword causes arguments to be passed by reference. This is like the [ref](../../../csharp/language-reference/keywords/ref.md) keyword, except that `ref` requires that the variable be initialized before it is passed. To use an `out` parameter, both the method definition and the calling method must explicitly use the `out` keyword. For example:  
  
 [!code-csharp[csrefKeywordsMethodParams#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#1)]  
  
 Although variables passed as `out` arguments do not have to be initialized before being passed, the called method is required to assign a value before the method returns.  
  
 Although the `ref` and `out` keywords cause different run-time behavior, they are not considered part of the method signature at compile time. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` argument and the other takes an `out` argument. The following code, for example, will not compile:  
  
 [!code-csharp[csrefKeywordsMethodParams#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#2)]  
  
 Overloading can be done, however, if one method takes a `ref` or `out` argument and the other uses neither, like this:  
  
 [!code-csharp[csrefKeywordsMethodParams#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#3)]  
  
 Properties are not variables and therefore cannot be passed as `out` parameters.  
  
 For information about passing arrays, see [Passing Arrays Using ref and out](../../../csharp/programming-guide/arrays/passing-arrays-using-ref-and-out.md).  
  
 You can't use the `ref` and `out` keywords for the following kinds of methods:  
  
-   Async methods, which you define by using the [async](../../../csharp/language-reference/keywords/async.md) modifier.  
  
-   Iterator methods, which include a [yield return](../../../csharp/language-reference/keywords/yield.md) or `yield break` statement.  
  
## Example  
 Declaring an `out` method is useful when you want a method to return multiple values. The following example uses `out` to return three variables with a single method call. Note that the third argument is assigned to null. This enables methods to return values optionally.  
  
 [!code-csharp[csrefKeywordsMethodParams#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsMethodParams/CS/csrefKeywordsMethodParams.cs#4)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Method Parameters](../../../csharp/language-reference/keywords/method-parameters.md)