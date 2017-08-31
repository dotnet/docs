---
title: "override (C# Reference) | Microsoft Docs"
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
  - "override"
  - "override_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "override keyword [C#]"
ms.assetid: dd1907a8-acf8-46d3-80b9-c2ca4febada8
caps.latest.revision: 26
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# override (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `override` modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.  
  
## Example  
 In this example, the `Square` class must provide an overridden implementation of `Area` because `Area` is inherited from the abstract `ShapesClass`:  
  
 [!code-csharp[csrefKeywordsModifiers#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#1)]  
  
 An `override` method provides a new implementation of a member that is inherited from a base class. The method that is overridden by an `override` declaration is known as the overridden base method. The overridden base method must have the same signature as the `override` method. For information about inheritance, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md).  
  
 You cannot override a non-virtual or static method. The overridden base method must be `virtual`, `abstract`, or `override`.  
  
 An `override` declaration cannot change the accessibility of the `virtual` method. Both the `override` method and the `virtual` method must have the same [access level modifier](../../../csharp/language-reference/keywords/access-modifiers.md).  
  
 You cannot use the `new`, `static`, or `virtual` modifiers to modify an `override` method.  
  
 An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property, and the overridden property must be `virtual`, `abstract`, or `override`.  
  
 For more information about how to use the `override` keyword, see [Versioning with the Override and New Keywords](../../../csharp/programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing when to use Override and New Keywords](../../../csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).  
  
## Example  
 This example defines a base class named `Employee`, and a derived class named `SalesEmployee`. The `SalesEmployee` class includes an extra property, `salesbonus`, and overrides the method `CalculatePay` in order to take it into account.  
  
 [!code-csharp[csrefKeywordsModifiers#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#9)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)   
 [abstract](../../../csharp/language-reference/keywords/abstract.md)   
 [virtual](../../../csharp/language-reference/keywords/virtual.md)   
 [new](../../../csharp/language-reference/keywords/new.md)   
 [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md)