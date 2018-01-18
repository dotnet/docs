---
title: Classes - C# Guide
description: Learn about the class types and how you create them
keywords: .NET, .NET Core, C#
author: BillWagner
ms.author: wiwagn
ms.date: 10/10/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 95c686ba-ae4f-440e-8e94-0dbd6e04d11f
---

# Classes
A *class* is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events. A class is like a blueprint. It defines the data and behavior of a type. If the class is not declared as static, client code can use it by creating *objects* or *instances* which are assigned to a variable. The variable remains in memory until all references to it go out of scope. At that time, the CLR marks it as eligible for garbage collection. If the class is declared as [static](language-reference/keywords/static.md), then only one copy exists in memory and client code can only access it through the class itself, not an *instance variable*. For more information, see [Static classes and static class members](programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  

## Reference types  
A type that is defined as a [class](language-reference/keywords/class.md) is a *reference type*. At run time, when you declare a variable of a reference type, the variable contains the value [null](language-reference/keywords/null.md) until you explicitly create an instance of the object by using the [new](language-reference/keywords/new.md) operator, or assign it an object that has been created elsewhere by using [new](language-reference/keywords/new.md), as shown in the following example:  

[!code-csharp[Reference Types](../../samples/snippets/csharp/concepts/classes/reference-type.cs)]
  
When the object is created, the memory is allocated on the managed heap, and the variable holds only a reference to the location of the object. Types on the managed heap require overhead both when they are allocated and when they are reclaimed by the automatic memory management functionality of the CLR, which is known as *garbage collection*. However, garbage collection is also highly optimized, and in most scenarios, it does not create a performance issue. For more information about garbage collection, see [Automatic memory management and garbage collection](../standard/garbage-collection/gc.md).  
  
Reference types fully support *inheritance*, a fundamental characteristic of object-oriented programming. When you create a class, you can inherit from any other interface or class that is not defined as [sealed](language-reference/keywords/sealed.md), and other classes can inherit from your class and override your virtual methods. For more information, see [Inheritance](programming-guide/classes-and-structs/inheritance.md).

## Declaring classes  
Classes are declared by using the [class](language-reference/keywords/class.md) keyword, as shown in the following example:  
  
[!code-csharp[Declaring Classes](../../samples/snippets/csharp/concepts/classes/declaring-classes.cs)]  
  
The **class** keyword is preceded by the access modifier. Because [public](language-reference/keywords/public.md) is used in this case, anyone can create objects from this class. The name of the class follows the **class** keyword. The remainder of the definition is the class body, where the behavior and data are defined. Fields, properties, methods, and events on a class are collectively referred to as *class members*.  
  
## Creating objects  
A class defines a type of object, but it is not an object itself. An object is a concrete entity based on a class, and is sometimes referred to as an instance of a class.  
  
Objects can be created by using the [new](language-reference/keywords/new.md) keyword followed by the name of the class that the object will be based on, like this:  
  
[!code-csharp[Creating Objects](../../samples/snippets/csharp/concepts/classes/creating-objects.cs)]   
  
When an instance of a class is created, a reference to the object is passed back to the programmer. In the previous example, `object1` is a reference to an object that is based on `Customer`. This reference refers to the new object but does not contain the object data itself. In fact, you can create an object reference without creating an object at all:  
  
[!code-csharp[Creating Objects](../../samples/snippets/csharp/concepts/classes/creating-objects2.cs)]  
  
We do not recommend creating object references such as this one that does not refer to an object because trying to access an object through such a reference will fail at run time. However, such a reference can be made to refer to an object, either by creating a new object, or by assigning it to an existing object, such as this:  
  
[!code-csharp[Creating Objects](../../samples/snippets/csharp/concepts/classes/creating-objects3.cs)]  
  
This code creates two object references that both refer to the same object. Therefore, any changes to the object made through `object3` will be reflected in subsequent uses of `object4`. Because objects that are based on classes are referred to by reference, classes are known as reference types.  
  
## Class inheritance  
Inheritance is accomplished by using a *derivation*, which means a class is declared by using a *base class* from which it inherits data and behavior. A base class is specified by appending a colon and the name of the base class following the derived class name, like this:  
  
[!code-csharp[Inheritance](../../samples/snippets/csharp/concepts/classes/inheritance.cs)]  
  
When a class declares a base class, it inherits all the members of the base class except the constructors.  
  
Unlike C++, a class in C# can only directly inherit from one base class. However, because a base class may itself inherit from another class, a class may indirectly inherit multiple base classes. Furthermore, a class can directly implement more than one interface. For more information, see [Interfaces](programming-guide/interfaces/index.md).  
  
A class can be declared [abstract](language-reference/keywords/abstract.md). An abstract class contains abstract methods that have a signature definition but no implementation. Abstract classes cannot be instantiated. They can only be used through derived classes that implement the abstract methods. By contrast, a [sealed](language-reference/keywords/sealed.md) class does not allow other classes to derive from it. For more information, see [Abstract and sealed classes and class members](programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
Class definitions can be split between different source files. For more information, see [Partial class definitions](programming-guide/classes-and-structs/partial-classes-and-methods.md).  
  
 
## Example
In the following example, a public class that contains a single field, a method, and a special method called a constructor is defined. For more information, see [Constructors](programming-guide/classes-and-structs/constructors.md). The class is then instantiated with the **new** keyword.

[!code-csharp[Class Example](../../samples/snippets/csharp/concepts/classes/class-example.cs)]  
  
## C# language specification  
For more information, see the [C# language specification](language-reference/language-specification/index.md). The language specification is the definitive source for C# syntax and usage.
  
## See also  
[C# programming guide](programming-guide/index.md)   
[Polymorphism](programming-guide/classes-and-structs/polymorphism.md)   
[Class and struct members](programming-guide/classes-and-structs/members.md)   
[Class and struct methods](programming-guide/classes-and-structs/methods.md)   
[Constructors](programming-guide/classes-and-structs/constructors.md)   
[Finalizers](programming-guide/classes-and-structs/destructors.md)   
[Objects](programming-guide/classes-and-structs/objects.md)

