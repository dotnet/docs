---
title: "ref (C# Reference)"
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
  - "ref_CSharpKeyword"
  - "ref"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "parameters [C#], ref"
  - "ref keyword [C#]"
ms.assetid: b8a5e59c-907d-4065-b41d-95bf4273c0bd
caps.latest.revision: 32
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
# ref (C# Reference)
The `ref` keyword causes an argument to be passed by reference, not by value. The effect of passing by reference is that any change to the parameter in the called method is reflected in the calling method. For example, if the caller passes a local variable expression or an array element access expression, and the called method replaces the object to which the ref parameter refers, then the caller’s local variable or the array element now refer to the new object.  
  
> [!NOTE]
>  Do not confuse the concept of passing by reference with the concept of reference types. The two concepts are not the same. A method parameter can be modified by `ref` regardless of whether it is a value type or a reference type. There is no boxing of a value type when it is passed by reference.  
  
 To use a `ref` parameter, both the method definition and the calling method must explicitly use the `ref` keyword, as shown in the following example.  
  
 [!code[csrefKeywordsMethodParams#6](../keywords/codesnippet/CSharp/ref--csharp-reference-_1.cs)]  
  
 An argument that is passed to a `ref` parameter must be initialized before it is passed. This differs from `out` parameters, whose arguments do not have to be explicitly initialized before they are passed. For more information, see [out](../keywords/out--csharp-reference-.md).  
  
 Members of a class can't have signatures that differ only by `ref` and `out`. A compiler error occurs if the only difference between two members of a type is that one of them has a `ref` parameter and the other has an `out` parameter. The following code, for example, doesn't compile.  
  
 [!code[csrefKeywordsMethodParams#2](../keywords/codesnippet/CSharp/ref--csharp-reference-_2.cs)]  
  
 However, overloading can be done when one method has a `ref` or `out` parameter and the other has a value parameter, as shown in the following example.  
  
 [!code[csrefKeywordsMethodParams#7](../keywords/codesnippet/CSharp/ref--csharp-reference-_3.cs)]  
  
 In other situations that require signature matching, such as hiding or overriding, `ref` and `out` are part of the signature and don't match each other.  
  
 Properties are not variables. They are methods, and cannot be passed to `ref` parameters.  
  
 For information about how to pass arrays, see [Passing Arrays Using ref and out](../arrays/passing-arrays-using-ref-and-out--csharp-programming-guide-.md).  
  
 You can't use the `ref` and `out` keywords for the following kinds of methods:  
  
-   Async methods, which you define by using the [async](../keywords/async--csharp-reference-.md) modifier.  
  
-   Iterator methods, which include a [yield return](../keywords/yield--csharp-reference-.md) or `yield break` statement.  
  
## Example  
 The previous examples demonstrate what happens when you pass value types by reference. You can also use the `ref` keyword to pass reference types. Passing a reference type by reference enables the called method to replace the object in the calling method to which the reference parameter refers. The storage location of the object is passed to the method as the value of the reference parameter. If you change the value in the storage location of the parameter (to point to a new object), you also change the storage location to which the caller refers. The following example passes an instance of a reference type as a `ref` parameter. For more information about how to pass reference types by value and by reference, see [Passing Reference-Type Parameters](../classes-and-structs/passing-reference-type-parameters--csharp-programming-guide-.md).  
  
 [!code[csrefKeywordsMethodParams#8](../keywords/codesnippet/CSharp/ref--csharp-reference-_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Passing Parameters](../classes-and-structs/passing-parameters--csharp-programming-guide-.md)   
 [Method Parameters](../keywords/method-parameters--csharp-reference-.md)   
 [C# Keywords](../keywords/csharp-keywords.md)