---
title: "Classes (C# Programming Guide) | Microsoft Docs"
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
  - "classes [C#]"
  - "C# language, classes"
ms.assetid: e8848524-7273-429f-8aba-c658d5eff5ad
caps.latest.revision: 40
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Classes (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A *class* is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events. A class is like a blueprint. It defines the data and behavior of a type. If the class is not declared as static, client code can use it by creating *objects* or *instances* which are assigned to a variable. The variable remains in memory until all references to it go out of scope. At that time, the CLR marks it as eligible for garbage collection. If the class is declared as [static](../../../csharp/language-reference/keywords/static.md), then only one copy exists in memory and client code can only access it through the class itself, not an *instance variable*. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
 Unlike structs, classes support *inheritance*, a fundamental characteristic of object-oriented programming. For more information, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md).  
  
## Declaring Classes  
 Classes are declared by using the [class](../../../csharp/language-reference/keywords/class.md) keyword, as shown in the following example:  
  
 [!code-csharp[csProgGuideObjects#79](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#79)]  
  
 The `class` keyword is preceded by the access level. Because [public](../../../csharp/language-reference/keywords/public.md) is used in this case, anyone can create objects from this class. The name of the class follows the `class` keyword. The remainder of the definition is the class body, where the behavior and data are defined. Fields, properties, methods, and events on a class are collectively referred to as *class members*.  
  
## Creating Objects  
 Although they are sometimes used interchangeably, a class and an object are different things. A class defines a type of object, but it is not an object itself. An object is a concrete entity based on a class, and is sometimes referred to as an instance of a class.  
  
 Objects can be created by using the [new](../../../csharp/language-reference/keywords/new.md) keyword followed by the name of the class that the object will be based on, like this:  
  
 [!code-csharp[csProgGuideObjects#80](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#80)]  
  
 When an instance of a class is created, a reference to the object is passed back to the programmer. In the previous example, `object1` is a reference to an object that is based on `Customer`. This reference refers to the new object but does not contain the object data itself. In fact, you can create an object reference without creating an object at all:  
  
 [!code-csharp[csProgGuideObjects#81](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#81)]  
  
 We do not recommend creating object references such as this one that does not refer to an object because trying to access an object through such a reference will fail at run time. However, such a reference can be made to refer to an object, either by creating a new object, or by assigning it to an existing object, such as this:  
  
 [!code-csharp[csProgGuideObjects#82](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#82)]  
  
 This code creates two object references that both refer to the same object. Therefore, any changes to the object made through `object3` will be reflected in subsequent uses of `object4`. Because objects that are based on classes are referred to by reference, classes are known as reference types.  
  
## Class Inheritance  
 Inheritance is accomplished by using a *derivation*, which means a class is declared by using a *base class* from which it inherits data and behavior. A base class is specified by appending a colon and the name of the base class following the derived class name, like this:  
  
 [!code-csharp[csProgGuideObjects#83](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#83)]  
  
 When a class declares a base class, it inherits all the members of the base class except the constructors.  
  
 Unlike C++, a class in C# can only directly inherit from one base class. However, because a base class may itself inherit from another class, a class may indirectly inherit multiple base classes. Furthermore, a class can directly implement more than one interface. For more information, see [Interfaces](../../../csharp/programming-guide/interfaces/index.md).  
  
 A class can be declared [abstract](../../../csharp/language-reference/keywords/abstract.md). An abstract class contains abstract methods that have a signature definition but no implementation. Abstract classes cannot be instantiated. They can only be used through derived classes that implement the abstract methods. By constrast, a [sealed](../../../csharp/language-reference/keywords/sealed.md) class does not allow other classes to derive from it. For more information, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
 Class definitions can be split between different source files. For more information, see [Partial Classes and Methods](../../../csharp/programming-guide/classes-and-structs/partial-classes-and-methods.md).  
  
## Description  
 In the following example, a public class that contains a single field, a method, and a special method called a constructor is defined. For more information, see [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md). The class is then instantiated with the `new` keyword.  
  
## Example  
 [!code-csharp[csProgGuideObjects#84](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#84)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Object-Oriented Programming](../Topic/Object-Oriented%20Programming%20\(C%23%20and%20Visual%20Basic\).md)   
 [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md)   
 [Members](../../../csharp/programming-guide/classes-and-structs/members.md)   
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)   
 [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)   
 [Destructors](../../../csharp/programming-guide/classes-and-structs/destructors.md)   
 [Objects](../../../csharp/programming-guide/classes-and-structs/objects.md)