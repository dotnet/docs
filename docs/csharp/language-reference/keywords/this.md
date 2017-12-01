---
title: "this (C# Reference)"
description: this keyword (C# Reference)
keywords: this (C#), this keyword (C#), this keyword (C# reference), this keyword (C# language reference)
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "this"
  - "this_CSharpKeyword"
helpviewer_keywords: 
  - "this keyword [C#]"
ms.assetid: d4f827fe-4710-410b-89b8-867dad44b8a3
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# this (C# Reference)
The `this` keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.  
  
> [!NOTE]
>  This article discusses the use of `this` with class instances. For more information about its use in extension methods, see [Extension Methods](../../../csharp/programming-guide/classes-and-structs/extension-methods.md).  
  
 The following are common uses of `this`:  
  
-   To qualify members hidden by similar names, for example:  
  
 [!code-csharp[csrefKeywordsAccess#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/this_1.cs)]  
  
-   To pass an object as a parameter to other methods, for example:  
  
    ```  
    CalcTax(this);  
    ```  
  
-   To declare indexers, for example:  
  
 [!code-csharp[csrefKeywordsAccess#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/this_2.cs)]  
  
 Static member functions, because they exist at the class level and not as part of an object, do not have a `this` pointer. It is an error to refer to `this` in a static method.  
  
## Example  
 In this example, `this` is used to qualify the `Employee` class members, `name` and `alias`, which are hidden by similar names. It is also used to pass an object to the method `CalcTax`, which belongs to another class.  
  
 [!code-csharp[csrefKeywordsAccess#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/this_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [base](../../../csharp/language-reference/keywords/base.md)  
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)
