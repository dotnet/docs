---
title: "out (C# Reference) | Microsoft Docs"
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
  - "out_CSharpKeyword"
  - "out"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "out [C#]"
  - "out keyword [C#]"
ms.assetid: 7e911a0c-3f98-4536-87be-d539b7536ca8
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# out (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

You can use the `out` contextual keyword in two contexts (each is a link to detailed information), as a [parameter modifier](../../../csharp/language-reference/keywords/out-parameter-modifier.md) or in [generic type parameter declarations](../../../csharp/language-reference/keywords/out-generic-modifier.md) in interfaces and delegates.  This topic discusses the parameter modifier, but you can see [this other topic](../../../csharp/language-reference/keywords/out-generic-modifier.md) for information on the generic type parameter declarations.  
  
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
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)