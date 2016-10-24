---
title: "override (C# Reference)"
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
# override (C# Reference)
The `override` modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.  
  
## Example  
 In this example, the `Square` class must provide an overridden implementation of `Area` because `Area` is inherited from the abstract `ShapesClass`:  
  
 [!code[csrefKeywordsModifiers#1](../keywords/codesnippet/CSharp/override--csharp-reference-_1.cs)]  
  
 An `override` method provides a new implementation of a member that is inherited from a base class. The method that is overridden by an `override` declaration is known as the overridden base method. The overridden base method must have the same signature as the `override` method. For information about inheritance, see [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md).  
  
 You cannot override a non-virtual or static method. The overridden base method must be `virtual`, `abstract`, or `override`.  
  
 An `override` declaration cannot change the accessibility of the `virtual` method. Both the `override` method and the `virtual` method must have the same [access level modifier](../keywords/access-modifiers--csharp-reference-.md).  
  
 You cannot use the `new`, `static`, or `virtual` modifiers to modify an `override` method.  
  
 An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property, and the overridden property must be `virtual`, `abstract`, or `override`.  
  
 For more information about how to use the `override` keyword, see [Versioning with the Override and New Keywords](../classes-and-structs/versioning-with-the-override-and-new-keywords--csharp-programming-guide-.md) and [Knowing when to use Override and New Keywords](../classes-and-structs/knowing-when-to-use-override-and-new-keywords--csharp-programming-guide-.md).  
  
## Example  
 This example defines a base class named `Employee`, and a derived class named `SalesEmployee`. The `SalesEmployee` class includes an extra property, `salesbonus`, and overrides the method `CalculatePay` in order to take it into account.  
  
 [!code[csrefKeywordsModifiers#9](../keywords/codesnippet/CSharp/override--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [abstract](../keywords/abstract--csharp-reference-.md)   
 [virtual](../keywords/virtual--csharp-reference-.md)   
 [new](../keywords/new--csharp-reference-.md)   
 [Polymorphism](../classes-and-structs/polymorphism--csharp-programming-guide-.md)