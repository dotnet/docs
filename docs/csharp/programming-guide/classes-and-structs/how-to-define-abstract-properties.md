---
title: "How to: Define Abstract Properties (C# Programming Guide) | Microsoft Docs"
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
  - "properties [C#], abstract"
  - "abstract properties [C#]"
ms.assetid: 672a90eb-47b9-4ae0-9914-af53852fddcb
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Define Abstract Properties (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The following example shows how to define [abstract](../../../csharp/language-reference/keywords/abstract.md) properties. An abstract property declaration does not provide an implementation of the property accessors -- it declares that the class supports properties, but leaves the accessor implementation to derived classes. The following example demonstrates how to implement the abstract properties inherited from a base class.  
  
 This sample consists of three files, each of which is compiled individually and its resulting assembly is referenced by the next compilation:  
  
-   abstractshape.cs: the `Shape` class that contains an abstract `Area` property.  
  
-   shapes.cs: The subclasses of the `Shape` class.  
  
-   shapetest.cs: A test program to display the areas of some `Shape`-derived objects.  
  
 To compile the example, use the following command:  
  
 `csc abstractshape.cs shapes.cs shapetest.cs`  
  
 This will create the executable file shapetest.exe.  
  
## Example  
 This file declares the `Shape` class that contains the `Area` property of the type `double`.  
  
 [!code-csharp[csProgGuideInheritance#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#1)]  
  
-   Modifiers on the property are placed on the property declaration itself. For example:  
  
    ```  
    public abstract double Area  
    ```  
  
-   When declaring an abstract property (such as `Area` in this example), you simply indicate what property accessors are available, but do not implement them. In this example, only a [get](../../../csharp/language-reference/keywords/get.md) accessor is available, so the property is read-only.  
  
## Example  
 The following code shows three subclasses of `Shape` and how they override the `Area` property to provide their own implementation.  
  
 [!code-csharp[csProgGuideInheritance#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#2)]  
  
## Example  
 The following code shows a test program that creates a number of `Shape`-derived objects and prints out their areas.  
  
 [!code-csharp[csProgGuideInheritance#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#3)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)   
 [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)   
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)   
 [How to: Create and Use Assemblies Using the Command Line](../Topic/How%20to:%20Create%20and%20Use%20Assemblies%20Using%20the%20Command%20Line%20\(C%23%20and%20Visual%20Basic\).md)