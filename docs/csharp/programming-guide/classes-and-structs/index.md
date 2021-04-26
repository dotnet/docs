---
title: "Classes, structs, and records - C# Programming Guide"
description: Describes the use of classes, structures (structs), and records in C#.
ms.date: 04/06/2021
helpviewer_keywords: 
  - "structs [C#], about structs"
  - "records [C#], about records"
  - "classes [C#], overview"
  - "C# language, structs"
  - "C# language, records"
  - "C# language, objects"
  - "objects [C#]"
  - "C# language, classes"
---
# Classes, structs, and records (C# programming guide)

Classes and structs are two of the basic constructs of the common type system in .NET. C# 9 adds records, which are a kind of class. Each is essentially a data structure that encapsulates a set of data and behaviors that belong together as a logical unit. The data and behaviors are the *members* of the class, struct, or record, and they include its methods, properties, events, and so on, as listed later in this article.

A class, struct, or record declaration is like a blueprint that is used to create instances or objects at run time. If you define a class, struct, or record named `Person`, `Person` is the name of the type. If you declare and initialize a variable `p` of type `Person`, `p` is said to be an object or instance of `Person`. Multiple instances of the same `Person` type can be created, and each instance can have different values in its properties and fields.  
  
A class or a record is a reference type. When an object of the type is created, the variable to which the object is assigned holds only a reference to that memory. When the object reference is assigned to a new variable, the new variable refers to the original object. Changes made through one variable are reflected in the other variable because they both refer to the same data.
  
A struct is a value type. When a struct is created, the variable to which the struct is assigned holds the struct's actual data. When the struct is assigned to a new variable, it is copied. The new variable and the original variable therefore contain two separate copies of the same data. Changes made to one copy do not affect the other copy.  
  
In general, classes are used to model more complex behavior, or data that is intended to be modified after a class object is created. Structs are best suited for small data structures that contain primarily data that isn't intended to be modified after the struct is created. Record types are for larger data structures that contain primarily data that isn't intended to be modified after the object is created.
  
## Example

 In the following example, `CustomClass` in the `ProgrammingGuide` namespace has three members: an instance constructor, a property named `Number`, and a method named `Multiply`. The `Main` method in the `Program` class creates an instance (object) of `CustomClass`, and the object's method and property are accessed by using dot notation.
  
 :::code language="csharp" source="../../../../samples/snippets/csharp/programming-guide/classes-and-structs/class1.cs" id="Snippet1":::  
  
## Encapsulation  

 *Encapsulation* is sometimes referred to as the first pillar or principle of object-oriented programming. According to the principle of encapsulation, a class or struct can specify how accessible each of its members is to code outside of the class or struct. Methods and variables that are not intended to be used from outside of the class or assembly can be hidden to limit the potential for coding errors or malicious exploits. For more information, see [Object-oriented programming](../../tutorials/intro-to-csharp/object-oriented-programming.md).

## Members

All methods, fields, constants, properties, and events must be declared within a type; these are called the *members* of the type. In C#, there are no global variables or methods as there are in some other languages. Even a program's entry point, the `Main` method, must be declared within a class or struct (implicitly in the case of [top-level statements](../main-and-command-args/top-level-statements.md)).

The following list includes all the various kinds of members that may be declared in a class, struct, or record.
  
- [Fields](./fields.md)  
- [Constants](./constants.md)
- [Properties](./properties.md)
- [Methods](./methods.md)
- [Constructors](./constructors.md)
- [Events](../events/index.md)
- [Finalizers](./destructors.md)
- [Indexers](../indexers/index.md)
- [Operators](../../language-reference/operators/index.md)
- [Nested Types](./nested-types.md)
  
## Accessibility  

 Some methods and properties are meant to be called or accessed from code outside a class or struct, known as *client code*. Other methods and properties might be only for use in the class or struct itself. It is important to limit the accessibility of your code so that only the intended client code can reach it. You specify how accessible your types and their members are to client code by using the following access modifiers:

- [public](../../language-reference/keywords/public.md)
- [protected](../../language-reference/keywords/protected.md)
- [internal](../../language-reference/keywords/internal.md)
- [protected internal](../../language-reference/keywords/protected-internal.md)
- [private](../../language-reference/keywords/private.md)
- [private protected](../../language-reference/keywords/private-protected.md).

The default accessibility is `private`. For more information, see [Access Modifiers](./access-modifiers.md).  
  
## Inheritance  

Classes (but not structs) support the concept of inheritance. A class that derives from another class (the *base class*) automatically contains all the public, protected, and internal members of the base class except its constructors and finalizers. For more information, see [Inheritance](./inheritance.md) and [Polymorphism](./polymorphism.md).
  
Classes may be declared as [abstract](../../language-reference/keywords/abstract.md), which means that one or more of their methods have no implementation. Although abstract classes cannot be instantiated directly, they can serve as base classes for other classes that provide the missing implementation. Classes can also be declared as [sealed](../../language-reference/keywords/sealed.md) to prevent other classes from inheriting from them. For more information, see [Abstract and sealed classes and class members](./abstract-and-sealed-classes-and-class-members.md).
  
## Interfaces  

Classes, structs, and records can inherit multiple interfaces. To inherit from an interface means that the type implements all the methods defined in the interface. For more information, see [Interfaces](../interfaces/index.md).  
  
## Generic Types  

 Classes, structs, and records can be defined with one or more type parameters. Client code supplies the type when it creates an instance of the type. For example The <xref:System.Collections.Generic.List%601> class in the <xref:System.Collections.Generic> namespace is defined with one type parameter. Client code creates an instance of a `List<string>` or `List<int>` to specify the type that the list will hold. For more information, see [Generics](../generics/index.md).  
  
## Static Types  

Classes (but not structs or records) can be declared as [static](../../language-reference/keywords/static.md). A static class can contain only static members and can't be instantiated with the `new` keyword. One copy of the class is loaded into memory when the program loads, and its members are accessed through the class name. Classes, structs, and records can contain static members. For more information, see [Static classes and static class members](./static-classes-and-static-class-members.md).
  
## Nested Types

A class, struct, or record can be nested within another class, struct, or record. For more information, see [Nested Types](./nested-types.md).
  
## Partial Types  

You can define part of a class, struct or method in one code file and another part in a separate code file. For more information, see [Partial Classes and methods](./partial-classes-and-methods.md).
  
## Object Initializers  

You can instantiate and initialize class or struct objects, and collections of objects, without explicitly calling their constructor. For more information, see [Object and collection initializers](./object-and-collection-initializers.md).  
  
## Anonymous Types  

In situations where it is not convenient or necessary to create a named class, for example when you are populating a list with data structures that you do not have to persist or pass to another method, you use anonymous types. For more information, see [Anonymous types](./anonymous-types.md).
  
## Extension Methods  

You can "extend" a class without creating a derived class by creating a separate type whose methods can be called as if they belonged to the original type. For more information, see [Extension methods](./extension-methods.md).
  
## Implicitly Typed Local Variables  

Within a class or struct method, you can use implicit typing to instruct the compiler to determine a variable's type at compile time. For more information, see [Implicitly Typed Local Variables](./implicitly-typed-local-variables.md).

## Records

C# 9 introduces the `record` type, a reference type that you can create instead of a class or a struct. Records are classes with built-in behavior for encapsulating data in immutable types. A record provides the following features:

* Concise syntax for creating a reference type with immutable properties.

* Value equality.

  Two variables of a record type are equal if the record type definitions are identical, and if for every field, the values in both records are equal. This differs from classes, which use reference equality: two variables of a class type are equal if they refer to the same object.

* Concise syntax for nondestructive mutation.

  A `with` expression lets you create a new record instance that is a copy of an existing instance but with specified property values changed.

* Built-in formatting for display.

  The `ToString` method prints out the record type name and the names and values of public properties.

* Support for inheritance hierarchies.

  Inheritance is supported because a record is a class under the covers, not a struct.

For more information, see [Records](../../language-reference/builtin-types/record.md).

## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [Classes](./classes.md)
- [Objects](./objects.md)
- [Structure types](../../language-reference/builtin-types/struct.md)
- [Records](../../language-reference/builtin-types/record.md)  
- [C# Programming Guide](../index.md)
