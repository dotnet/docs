---
title: "How to: Define Abstract Properties (C# Programming Guide)"
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
# How to: Define Abstract Properties (C# Programming Guide)
The following example shows how to define [abstract](../keywords/abstract--csharp-reference-.md) properties. An abstract property declaration does not provide an implementation of the property accessors -- it declares that the class supports properties, but leaves the accessor implementation to derived classes. The following example demonstrates how to implement the abstract properties inherited from a base class.  
  
 This sample consists of three files, each of which is compiled individually and its resulting assembly is referenced by the next compilation:  
  
-   abstractshape.cs: the `Shape` class that contains an abstract `Area` property.  
  
-   shapes.cs: The subclasses of the `Shape` class.  
  
-   shapetest.cs: A test program to display the areas of some `Shape`-derived objects.  
  
 To compile the example, use the following command:  
  
 `csc abstractshape.cs shapes.cs shapetest.cs`  
  
 This will create the executable file shapetest.exe.  
  
## Example  
 This file declares the `Shape` class that contains the `Area` property of the type `double`.  
  
 [!code[csProgGuideInheritance#1](../classes-and-structs/codesnippet/CSharp/how-to--define-abstract-properties--csharp-programming-guide-_1.cs)]  
  
-   Modifiers on the property are placed on the property declaration itself. For example:  
  
    ```  
    public abstract double Area  
    ```  
  
-   When declaring an abstract property (such as `Area` in this example), you simply indicate what property accessors are available, but do not implement them. In this example, only a [get](../keywords/get--csharp-reference-.md) accessor is available, so the property is read-only.  
  
## Example  
 The following code shows three subclasses of `Shape` and how they override the `Area` property to provide their own implementation.  
  
 [!code[csProgGuideInheritance#2](../classes-and-structs/codesnippet/CSharp/how-to--define-abstract-properties--csharp-programming-guide-_2.cs)]  
  
## Example  
 The following code shows a test program that creates a number of `Shape`-derived objects and prints out their areas.  
  
 [!code[csProgGuideInheritance#3](../classes-and-structs/codesnippet/CSharp/how-to--define-abstract-properties--csharp-programming-guide-_3.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Abstract and Sealed Classes and Class Members](../classes-and-structs/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-.md)   
 [Properties](../classes-and-structs/properties--csharp-programming-guide-.md)   
 [How to: Create and Use Assemblies Using the Command Line](../Topic/How%20to:%20Create%20and%20Use%20Assemblies%20Using%20the%20Command%20Line%20\(C%23%20and%20Visual%20Basic\).md)