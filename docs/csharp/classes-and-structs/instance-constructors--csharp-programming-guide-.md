---
title: "Instance Constructors (C# Programming Guide)"
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
  - "constructors [C#], instance constructors"
  - "instance constructors [C#]"
ms.assetid: 24663779-c1e5-4af4-a942-ca554e4c542d
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
# Instance Constructors (C# Programming Guide)
Instance constructors are used to create and initialize any instance member variables when you use the [new](../keywords/new--csharp-reference-.md) expression to create an object of a [class](../keywords/class--csharp-reference-.md). To initialize a [static](../keywords/static--csharp-reference-.md) class, or static variables in a non-static class, you must define a static constructor. For more information, see [Static Constructors](../classes-and-structs/static-constructors--csharp-programming-guide-.md).  
  
 The following example shows an instance constructor:  
  
 [!code[csProgGuideObjects#5](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_1.cs)]  
  
> [!NOTE]
>  For clarity, this class contains public fields. The use of public fields is not a recommended programming practice because it allows any method anywhere in a program unrestricted and unverified access to an object's inner workings. Data members should generally be private, and should be accessed only through class methods and properties.  
  
 This instance constructor is called whenever an object based on the `CoOrds` class is created. A constructor like this one, which takes no arguments, is called a *default constructor*. However, it is often useful to provide additional constructors. For example, we can add a constructor to the `CoOrds` class that allows us to specify the initial values for the data members:  
  
 [!code[csProgGuideObjects#76](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_2.cs)]  
  
 This allows `CoOrd` objects to be created with default or specific initial values, like this:  
  
 [!code[csProgGuideObjects#77](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_3.cs)]  
  
 If a class does not have a constructor, a default constructor is automatically generated and default values are used to initialize the object fields. For example, an [int](../keywords/int--csharp-reference-.md) is initialized to 0. For more information on default values, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md). Therefore, because the `CoOrds` class default constructor initializes all data members to zero, it can be removed altogether without changing how the class works. A complete example using multiple constructors is provided in Example 1 later in this topic, and an example of an automatically generated constructor is provided in Example 2.  
  
 Instance constructors can also be used to call the instance constructors of base classes. The class constructor can invoke the constructor of the base class through the initializer, as follows:  
  
 [!code[csProgGuideObjects#78](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_4.cs)]  
  
 In this example, the `Circle` class passes values representing radius and height to the constructor provided by `Shape` from which `Circle` is derived. A complete example using `Shape` and `Circle` appears in this topic as Example 3.  
  
## Example 1  
 The following example demonstrates a class with two class constructors, one without arguments and one with two arguments.  
  
 [!code[csProgGuideObjects#4](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_5.cs)]  
  
## Example 2  
 In this example, the class `Person` does not have any constructors, in which case, a default constructor is automatically provided and the fields are initialized to their default values.  
  
 [!code[csProgGuideObjects#8](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_6.cs)]  
  
 Notice that the default value of `age` is `0` and the default value of `name` is `null`. For more information on default values, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md).  
  
## Example 3  
 The following example demonstrates using the base class initializer. The `Circle` class is derived from the general class `Shape`, and the `Cylinder` class is derived from the `Circle` class. The constructor on each derived class is using its base class initializer.  
  
 [!code[csProgGuideObjects#9](../classes-and-structs/codesnippet/CSharp/instance-constructors--csharp-programming-guide-_7.cs)]  
  
 For more examples on invoking the base class constructors, see [virtual](../keywords/virtual--csharp-reference-.md), [override](../keywords/override--csharp-reference-.md), and [base](../keywords/base--csharp-reference-.md).  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)   
 [Destructors](../classes-and-structs/destructors--csharp-programming-guide-.md)   
 [static](../keywords/static--csharp-reference-.md)