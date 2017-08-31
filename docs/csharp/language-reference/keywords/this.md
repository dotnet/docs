---
title: "this (C# Reference) | Microsoft Docs"
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
  - "this"
  - "this_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "this keyword [C#]"
ms.assetid: d4f827fe-4710-410b-89b8-867dad44b8a3
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# this (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `this` keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.  
  
> [!NOTE]
>  This article discusses the use of `this` with class instances. For more information about its use in extension methods, see [Extension Methods](../../../csharp/programming-guide/classes-and-structs/extension-methods.md).  
  
 The following are common uses of `this`:  
  
-   To qualify members hidden by similar names, for example:  
  
 [!code-csharp[csrefKeywordsAccess#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#4)]  
  
-   To pass an object as a parameter to other methods, for example:  
  
    ```  
    CalcTax(this);  
    ```  
  
-   To declare indexers, for example:  
  
 [!code-csharp[csrefKeywordsAccess#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#5)]  
  
 Static member functions, because they exist at the class level and not as part of an object, do not have a `this` pointer. It is an error to refer to `this` in a static method.  
  
## Example  
 In this example, `this` is used to qualify the `Employee` class members, `name` and `alias`, which are hidden by similar names. It is also used to pass an object to the method `CalcTax`, which belongs to another class.  
  
 [!code-csharp[csrefKeywordsAccess#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsAccess/CS/csrefKeywordsAccess.cs#3)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [base](../../../csharp/language-reference/keywords/base.md)   
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)