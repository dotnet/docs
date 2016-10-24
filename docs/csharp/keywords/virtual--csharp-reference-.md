---
title: "virtual (C# Reference)"
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
  - "virtual_CSharpKeyword"
  - "virtual"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "virtual keyword [C#]"
ms.assetid: 5da9abae-bc1e-434f-8bea-3601b8dcb3b2
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
# virtual (C# Reference)
The `virtual` keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. For example, this method can be overridden by any class that inherits it:  
  
```  
public virtual double Area()   
{  
    return x * y;  
}  
```  
  
 The implementation of a virtual member can be changed by an [overriding member](../keywords/override--csharp-reference-.md) in a derived class. For more information about how to use the `virtual` keyword, see [Versioning with the Override and New Keywords](../classes-and-structs/versioning-with-the-override-and-new-keywords--csharp-programming-guide-.md) and [Knowing When to Use Override and New Keywords](../classes-and-structs/knowing-when-to-use-override-and-new-keywords--csharp-programming-guide-.md).  
  
## Remarks  
 When a virtual method is invoked, the run-time type of the object is checked for an overriding member. The overriding member in the most derived class is called, which might be the original member, if no derived class has overridden the member.  
  
 By default, methods are non-virtual. You cannot override a non-virtual method.  
  
 You cannot use the `virtual` modifier with the `static`, `abstract, private`, or `override` modifiers. The following example shows a virtual property:  
  
 [!code[csrefKeywordsModifiers#26](../keywords/codesnippet/CSharp/virtual--csharp-reference-_1.cs)]  
  
 Virtual properties behave like abstract methods, except for the differences in declaration and invocation syntax.  
  
-   It is an error to use the `virtual` modifier on a static property.  
  
-   A virtual inherited property can be overridden in a derived class by including a property declaration that uses the `override` modifier.  
  
## Example  
 In this example, the `Shape` class contains the two coordinates `x`, `y`, and the `Area()` virtual method. Different shape classes such as `Circle`, `Cylinder`, and `Sphere` inherit the `Shape` class, and the surface area is calculated for each figure. Each derived class has it own override implementation of `Area()`.  
  
 Notice that the inherited classes `Circle`, `Sphere`, and `Cylinder` all use constructors that initialize the base class, as shown in the following declaration.  
  
```  
public Cylinder(double r, double h): base(r, h) {}  
```  
  
 The following program calculates and displays the appropriate area for each figure by invoking the appropriate implementation of the `Area()` method, according to the object that is associated with the method.  
  
 [!code[csrefKeywordsModifiers#23](../keywords/codesnippet/CSharp/virtual--csharp-reference-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Polymorphism](../classes-and-structs/polymorphism--csharp-programming-guide-.md)   
 [abstract](../keywords/abstract--csharp-reference-.md)   
 [override](../keywords/override--csharp-reference-.md)   
 [new](../keywords/new--csharp-reference-.md)