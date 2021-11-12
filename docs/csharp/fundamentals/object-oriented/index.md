---
title: "Classes, structs, and records"
description: Describes the use of classes, structures (structs), and records in C#.
ms.date: 09/30/2021
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
# Object-oriented programming

## Encapsulation  

 *Encapsulation* is sometimes referred to as the first pillar or principle of object-oriented programming. A class or struct can specify how accessible each of its members is to code outside of the class or struct. Methods and variables that aren't intended to be used from outside of the class or assembly can be hidden to limit the potential for coding errors or malicious exploits. For more information, see [Object-oriented programming](../tutorials/oop.md).

## Members

The *members* of a type include all methods, fields, constants, properties, and events. In C#, there are no global variables or methods as there are in some other languages. Even a program's entry point, the `Main` method, must be declared within a class or struct (implicitly when you use [top-level statements](../program-structure/top-level-statements.md)).

The following list includes all the various kinds of members that may be declared in a class, struct, or record.
  
- Fields
- Constants
- Properties
- Methods
- Constructors
- Events
- Finalizers
- Indexers
- Operators
- Nested Types
  
## Accessibility  

 Some methods and properties are meant to be called or accessed from code outside a class or struct, known as *client code*. Other methods and properties might be only for use in the class or struct itself. It's important to limit the accessibility of your code so that only the intended client code can reach it. You specify how accessible your types and their members are to client code by using the following access modifiers:

- [public](../../language-reference/keywords/public.md)
- [protected](../../language-reference/keywords/protected.md)
- [internal](../../language-reference/keywords/internal.md)
- [protected internal](../../language-reference/keywords/protected-internal.md)
- [private](../../language-reference/keywords/private.md)
- [private protected](../../language-reference/keywords/private-protected.md).

The default accessibility is `private`.
  
## Inheritance  

Classes (but not structs) support the concept of inheritance. A class that derives from another class, called the *base class*, automatically contains all the public, protected, and internal members of the base class except its constructors and finalizers. For more information, see [Inheritance](./inheritance.md) and [Polymorphism](./polymorphism.md).
  
Classes may be declared as [abstract](../../language-reference/keywords/abstract.md), which means that one or more of their methods have no implementation. Although abstract classes cannot be instantiated directly, they can serve as base classes for other classes that provide the missing implementation. Classes can also be declared as [sealed](../../language-reference/keywords/sealed.md) to prevent other classes from inheriting from them.
  
## Interfaces  

Classes, structs, and records can implement multiple interfaces. To implement from an interface means that the type implements all the methods defined in the interface. For more information, see [Interfaces](../types/interfaces.md).  
  
## Generic Types  

Classes, structs, and records can be defined with one or more type parameters. Client code supplies the type when it creates an instance of the type. For example, The <xref:System.Collections.Generic.List%601> class in the <xref:System.Collections.Generic> namespace is defined with one type parameter. Client code creates an instance of a `List<string>` or `List<int>` to specify the type that the list will hold. For more information, see [Generics](../types/generics.md).  
  
## Static Types  

Classes (but not structs or records) can be declared as `static`. A static class can contain only static members and can't be instantiated with the `new` keyword. One copy of the class is loaded into memory when the program loads, and its members are accessed through the class name. Classes, structs, and records can contain static members.
  
## Nested Types

A class, struct, or record can be nested within another class, struct, or record.
  
## Partial Types  

You can define part of a class, struct, or method in one code file and another part in a separate code file.
  
## Object Initializers  

You can instantiate and initialize class or struct objects, and collections of objects, by assigning values to its properties.
  
## Anonymous Types  

In situations where it isn't convenient or necessary to create a named class you use anonymous types. Anonymous types are defined by their named data members.
  
## Extension Methods  

You can "extend" a class without creating a derived class by creating a separate type. That type contains methods that can be called as if they belonged to the original type.
  
## Implicitly Typed Local Variables  

Within a class or struct method, you can use implicit typing to instruct the compiler to determine a variable's type at compile time.

## Records

C# 9 introduces the `record` type, a reference type that you can create instead of a class or a struct. Records are classes with built-in behavior for encapsulating data in immutable types. C# 10 introduces the `record struct` value type. A record (either `record class` or `record struct`) provides the following features:

* Concise syntax for creating a reference type with immutable properties.
* Value equality.
  Two variables of a record type are equal if they have the same type, and if, for every field, the values in both records are equal. Classes use reference equality: two variables of a class type are equal if they refer to the same object.
* Concise syntax for nondestructive mutation.
  A `with` expression lets you create a new record instance that is a copy of an existing instance but with specified property values changed.
* Built-in formatting for display.
  The `ToString` method prints the record type name and the names and values of public properties.
* Support for inheritance hierarchies in record classes.
  Record classes support inheritance. Record structs don't support inheritance.

For more information, see [Records](../../language-reference/builtin-types/record.md).

## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
