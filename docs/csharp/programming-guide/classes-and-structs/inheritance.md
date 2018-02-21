---
title: "Inheritance (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "abstract methods [C#]"
  - "abstract classes [C#]"
  - "inheritance [C#]"
  - "derived classes [C#]"
  - "virtual methods [C#]"
  - "C# language, inheritance"
ms.assetid: 81d64ee4-50f9-4d6c-a8dc-257c348d2eea
caps.latest.revision: 38
author: "BillWagner"
ms.author: "wiwagn"
---
# Inheritance (C# Programming Guide)

Inheritance, together with encapsulation and polymorphism, is one of the three primary characteristics of object-oriented programming. Inheritance enables you to create new classes that reuse, extend, and modify the behavior that is defined in other classes. The class whose members are inherited is called the *base class*, and the class that inherits those members is called the *derived class*. A derived class can have only one direct base class. However, inheritance is transitive. If ClassC is derived from ClassB, and ClassB is derived from ClassA, ClassC inherits the members declared in ClassB and ClassA.  
  
> [!NOTE]
>  Structs do not support inheritance, but they can implement interfaces. For more information, see [Interfaces](../../../csharp/programming-guide/interfaces/index.md).  
  
 Conceptually, a derived class is a specialization of the base class. For example, if you have a base class `Animal`, you might have one derived class that is named `Mammal` and another derived class that is named `Reptile`. A `Mammal` is an `Animal`, and a `Reptile` is an `Animal`, but each derived class represents different specializations of the base class.  
  
 When you define a class to derive from another class, the derived class implicitly gains all the members of the base class, except for its constructors and finalizers. The derived class can thereby reuse the code in the base class without having to re-implement it. In the derived class, you can add more members. In this manner, the derived class extends the functionality of the base class.  
  
 The following illustration shows a class `WorkItem` that represents an item of work in some business process. Like all classes, it derives from <xref:System.Object?displayProperty=nameWithType> and inherits all its methods. `WorkItem` adds five members of its own. These include a constructor, because constructors are not inherited. Class `ChangeRequest` inherits from `WorkItem` and represents a particular kind of work item. `ChangeRequest` adds two more members to the members that it inherits from `WorkItem` and from <xref:System.Object>. It must add its own constructor, and it also adds `originalItemID`. Property `originalItemID` enables the `ChangeRequest` instance to be associated with the original `WorkItem` to which the change request applies.  
  
 ![Class Inheritance](../../../csharp/programming-guide/classes-and-structs/media/class_inheritance.png "Class_Inheritance")  
Class inheritance  
  
 The following example shows how the class relationships demonstrated in the previous illustration are expressed in C#. The example also shows how `WorkItem` overrides the virtual method <xref:System.Object.ToString%2A?displayProperty=nameWithType>, and how the `ChangeRequest` class inherits the `WorkItem` implementation of the method.  
  
 [!code-csharp[csProgGuideInheritance#49](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/inheritance_1.cs)]  
  
## Abstract and Virtual Methods  
 When a base class declares a method as [virtual](../../../csharp/language-reference/keywords/virtual.md), a derived class can [override](../../../csharp/language-reference/keywords/override.md) the method with its own implementation. If a base class declares a member as [abstract](../../../csharp/language-reference/keywords/abstract.md), that method must be overridden in any non-abstract class that directly inherits from that class. If a derived class is itself abstract, it inherits abstract members without implementing them. Abstract and virtual members are the basis for polymorphism, which is the second primary characteristic of object-oriented programming. For more information, see [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md).  
  
## Abstract Base Classes  
 You can declare a class as [abstract](../../../csharp/language-reference/keywords/abstract.md) if you want to prevent direct instantiation by using the [new](../../../csharp/language-reference/keywords/new.md) keyword. If you do this, the class can be used only if a new class is derived from it. An abstract class can contain one or more method signatures that themselves are declared as abstract. These signatures specify the parameters and return value but have no implementation (method body). An abstract class does not have to contain abstract members; however, if a class does contain an abstract member, the class itself must be declared as abstract. Derived classes that are not abstract themselves must provide the implementation for any abstract methods from an abstract base class. For more information, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
## Interfaces  
 An *interface* is a reference type that is somewhat similar to an abstract base class that consists of only abstract members. When a class implements an interface, it must provide an implementation for all the members of the interface. A class can implement multiple interfaces even though it can derive from only a single direct base class.  
  
 Interfaces are used to define specific capabilities for classes that do not necessarily have an "is a" relationship. For example, the <xref:System.IEquatable%601?displayProperty=nameWithType> interface can be implemented by any class or struct that has to enable client code to determine whether two objects of the type are equivalent (however the type defines equivalence). <xref:System.IEquatable%601> does not imply the same kind of "is a" relationship that exists between a base class and a derived class (for example, a `Mammal` is an `Animal`). For more information, see [Interfaces](../../../csharp/programming-guide/interfaces/index.md).  
  
## Preventing Further Derivation  
 A class can prevent other classes from inheriting from it, or from any of its members, by declaring itself or the member as [sealed](../../../csharp/language-reference/keywords/sealed.md). For more information, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
## Derived Class Hiding of Base Class Members  
 A derived class can hide base class members by declaring members with the same name and signature. The [new](../../../csharp/language-reference/keywords/new.md) modifier can be used to explicitly indicate that the member is not intended to be an override of the base member. The use of [new](../../../csharp/language-reference/keywords/new.md) is not required, but a compiler warning will be generated if [new](../../../csharp/language-reference/keywords/new.md) is not used. For more information, see [Versioning with the Override and New Keywords](../../../csharp/programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords.md) and [Knowing When to Use Override and New Keywords](../../../csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [class](../../../csharp/language-reference/keywords/class.md)  
 [struct](../../../csharp/language-reference/keywords/struct.md)
