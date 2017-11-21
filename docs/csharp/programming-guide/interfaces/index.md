---
title: "Interfaces (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "interfaces [C#]"
  - "C# language, interfaces"
ms.assetid: 2feda177-ce11-432d-81b4-d50f5f35fd37
caps.latest.revision: 45
author: "BillWagner"
ms.author: "wiwagn"
---
# Interfaces (C# Programming Guide)
An interface contains definitions for a group of related functionalities that a [class](../../../csharp/language-reference/keywords/class.md) or a [struct](../../../csharp/language-reference/keywords/struct.md) can implement.  
  
 By using interfaces, you can, for example, include behavior from multiple sources in a class. That capability is important in C# because the language doesn't support multiple inheritance of classes. In addition, you must use an interface if you want to simulate inheritance for structs, because they can't actually inherit from another struct or class.  
  
 You define an interface by using the [interface](../../../csharp/language-reference/keywords/interface.md) keyword, as the following example shows.  
  
 [!code-csharp[csProgGuideInheritance#47](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/interfaces_1.cs)]  
  
 Any class or struct that implements the <xref:System.IEquatable%601> interface must contain a definition for an <xref:System.IEquatable%601.Equals%2A> method that matches the signature that the interface specifies. As a result, you can count on a class that implements `IEquatable<T>` to contain an `Equals` method with which an instance of the class can determine whether it's equal to another instance of the same class.  
  
 The definition of `IEquatable<T>` doesn’t provide an implementation for `Equals`. The interface defines only the signature. In that way, an interface in C# is similar to an abstract class in which all the methods are abstract. However, a class or struct can implement multiple interfaces, but a class can inherit only a single class, abstract or not. Therefore, by using interfaces, you can include behavior from multiple sources in a class.  
  
 For more information about abstract classes, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
 Interfaces can contain methods, properties, events, indexers, or any combination of those four member types. For links to examples, see [Related Sections](../../../csharp/programming-guide/interfaces/index.md#BKMK_RelatedSections). An interface can't contain constants, fields, operators, instance constructors, finalizers, or types. Interface members are automatically public, and they can't include any access modifiers. Members also can't be [static](../../../csharp/language-reference/keywords/static.md).  
  
 To implement an interface member, the corresponding member of the implementing class must be public, non-static, and have the same name and signature as the interface member.  
  
 When a class or struct implements an interface, the class or struct must provide an implementation for all of the members that the interface defines. The interface itself provides no functionality that a class or struct can inherit in the way that it can inherit base class functionality. However, if a base class implements an interface, any class that's derived from the base class inherits that implementation.  
  
 The following example shows an implementation of the IEquatable<T\> interface. The implementing class, `Car`, must provide an implementation of the <xref:System.IEquatable%601.Equals%2A> method.  
  
 [!code-csharp[csProgGuideInheritance#48](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/interfaces_2.cs)]  
  
 Properties and indexers of a class can define extra accessors for a property or indexer that's defined in an interface. For example, an interface might declare a property that has a [get](../../../csharp/language-reference/keywords/get.md) accessor. The class that implements the interface can declare the same property with both a `get` and [set](../../../csharp/language-reference/keywords/set.md) accessor. However, if the property or indexer uses explicit implementation, the accessors must match. For more information about explicit implementation, see [Explicit Interface Implementation](../../../csharp/programming-guide/interfaces/explicit-interface-implementation.md) and [Interface Properties](../../../csharp/programming-guide/classes-and-structs/interface-properties.md).  
  
 Interfaces can implement other interfaces. A class might include an interface multiple times through base classes that it inherits or through interfaces that other interfaces implement. However, the class can provide an implementation of an interface only one time and only if the class declares the interface as part of the definition of the class (`class ClassName : InterfaceName`). If the interface is inherited because you inherited a base class that implements the interface, the base class provides the implementation of the members of the interface. However, the derived class can reimplement the interface members instead of using the inherited implementation.  
  
 A base class can also implement interface members by using virtual members. In that case, a derived class can change the interface behavior by overriding the virtual members. For more information about virtual members, see [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md).  
  
## Interfaces Summary  
 An interface has the following properties:  
  
-   An interface is like an abstract base class. Any class or struct that implements the interface must implement all its members.  
  
-   An interface can't be instantiated directly. Its members are implemented by any class or struct that implements the interface.  
  
-   Interfaces can contain events, indexers, methods, and properties.  
  
-   Interfaces contain no implementation of methods.  
  
-   A class or struct can implement multiple interfaces. A class can inherit a base class and also implement one or more interfaces.  
  
## In This Section  
 [Explicit Interface Implementation](../../../csharp/programming-guide/interfaces/explicit-interface-implementation.md)  
 Explains how to create a class member that’s specific to an interface.  
  
 [How to: Explicitly Implement Interface Members](../../../csharp/programming-guide/interfaces/how-to-explicitly-implement-interface-members.md)  
 Provides an example of how to explicitly implement members of interfaces.  
  
 [How to: Explicitly Implement Members of Two Interfaces](../../../csharp/programming-guide/interfaces/how-to-explicitly-implement-members-of-two-interfaces.md)  
 Provides an example of how to explicitly implement members of interfaces with inheritance.  
  
##  <a name="BKMK_RelatedSections"></a> Related Sections  
  
-   [Interface Properties](../../../csharp/programming-guide/classes-and-structs/interface-properties.md)  
  
-   [Indexers in Interfaces](../../../csharp/programming-guide/indexers/indexers-in-interfaces.md)  
  
-   [How to:  Implement Interface Events](../../../csharp/programming-guide/events/how-to-implement-interface-events.md)  
  
-   [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
  
-   [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)  
  
-   [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
  
-   [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md)  
  
-   [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)  
  
-   [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)  
  
-   [Events](../../../csharp/programming-guide/events/index.md)  
  
-   [Indexers](../../../csharp/programming-guide/indexers/index.md)  
  
## Featured Book Chapter  
 [Interfaces](http://msdn.microsoft.com/library/orm-9780596521066-01-13.aspx) in [Learning C# 3.0: Master the Fundamentals of C# 3.0](http://msdn.microsoft.com/library/orm-9780596521066-01.aspx)  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)
