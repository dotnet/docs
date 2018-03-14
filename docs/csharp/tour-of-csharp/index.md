---
title: A Tour of C# - C# Guide
description: New to C#? Learn the basics of the language.
keywords: .NET, .NET Core, C#, C# Primer, C# Guide
author: BillWagner
ms.author: wiwagn
ms.date: 08/10/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: ebc727cd-8112-42e7-b59c-3c2873ad661c
---

# A Tour of the C# Language  

C# (pronounced "See Sharp") is a simple, modern, object-oriented, and type-safe programming language. C# has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers.

C# is an object-oriented language, but C# further includes support for ***component-oriented*** programming. Contemporary software design increasingly relies on software components in the form of self-contained and self-describing packages of functionality. Key to such components is that they present a programming model with properties, methods, and events; they have attributes that provide declarative information about the component; and they incorporate their own documentation. C# provides language constructs to support directly these concepts, making C# a very natural language in which to create and use software components.

Several C# features aid in the construction of robust and durable applications: ***Garbage collection*** automatically reclaims memory occupied by unreachable unused objects; ***exception handling*** provides a structured and extensible approach to error detection and recovery; and the ***type-safe*** design of the language makes it impossible to read from uninitialized variables, to index arrays beyond their bounds, or to perform unchecked type casts.

C# has a ***unified type system***. All C# types, including primitive types such as `int` and `double`, inherit from a single root `object` type. Thus, all types share a set of common operations, and values of any type can be stored, transported, and operated upon in a consistent manner. Furthermore, C# supports both user-defined reference types and value types, allowing dynamic allocation of objects as well as in-line storage of lightweight structures.

To ensure that C# programs and libraries can evolve over time in a compatible manner, much emphasis has been placed on ***versioning*** in C#’s design. Many programming languages pay little attention to this issue, and, as a result, programs written in those languages break more often than necessary when newer versions of dependent libraries are introduced. Aspects of C#’s design that were directly influenced by versioning considerations include the separate `virtual` and `override` modifiers, the rules for method overload resolution, and support for explicit interface member declarations.

## Hello world

The "Hello, World" program is traditionally used to introduce a programming language. Here it is in C#:

[!code-csharp[Hello World](../../../samples/snippets/csharp/tour/hello/Program.cs#L1-L8)]

C# source files typically have the file extension `.cs`. Assuming that the "Hello, World" program is stored in the file `hello.cs`, the program might be compiled using the command line:

```console
csc hello.cs
```

which produces an executable assembly named hello.exe. The output produced by this application when it is run is:

```console
Hello, World
```

> [!IMPORTANT]
> The `csc` command compiles for the full framework, and may not be available on all platforms.


The "Hello, World" program starts with a `using` directive that references the `System` namespace. Namespaces provide a hierarchical means of organizing C# programs and libraries. Namespaces contain types and other namespaces—for example, the `System` namespace contains a number of types, such as the `Console` class referenced in the program, and a number of other namespaces, such as `IO` and `Collections`. A `using` directive that references a given namespace enables unqualified use of the types that are members of that namespace. Because of the `using` directive, the program can use `Console.WriteLine` as shorthand for `System.Console.WriteLine`.

The `Hello` class declared by the "Hello, World" program has a single member, the method named `Main`. The `Main` method is declared with the static modifier. While instance methods can reference a particular enclosing object instance using the keyword `this`, static methods operate without reference to a particular object. By convention, a static method named `Main` serves as the entry point of a program.

The output of the program is produced by the `WriteLine` method of the `Console` class in the `System` namespace. This class is provided by the standard class libraries, which, by default, are automatically referenced by the compiler.

There's a lot more to learn about C#.  The following topics provide an overview of the elements of the C# language. These overviews will provide basic information about all elements of the language and give you the information necessary to dive deeper into elements of the C# language:

* [Program Structure](program-structure.md)
    - Learn the key organizational concepts in the C# language: ***programs***, ***namespaces***, ***types***, ***members***, and ***assemblies***.
* [Types and Variables](types-and-variables.md)
    - Learn about ***value types***, ***reference types***, and ***variables*** in the C# language.
* [Expressions](expressions.md)
	- ***Expressions*** are constructed from ***operands*** and ***operators***. Expressions produce a value.
* [Statements](statements.md)
	- You use ***statements*** to express the actions of a program.
* [Classes and objects](classes-and-objects.md)
	- ***Classes*** are the most fundamental of C#'s types. ***Objects*** are instances of a class. Classes are built using ***members***, which are also covered in this topic.
* [Structs](structs.md)
	- ***Structs*** are data structures that, unlike classes, are value types.
* [Arrays](arrays.md)
	- An ***array*** is a data structure that contains a number of variables that are accessed through computed indices.
* [Interfaces](interfaces.md)
	- An ***interface*** defines a contract that can be implemented by classes and structs. An interface can contain methods, properties, events, and indexers. An interface does not provide implementations of the members it defines—it merely specifies the members that must be supplied by classes or structs that implement the interface.
* [Enums](enums.md)
	- An ***enum type*** is a distinct value type with a set of named constants.
* [Delegates](delegates.md)
	- A ***delegate type*** represents references to methods with a particular parameter list and return type. Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. Delegates are similar to the concept of function pointers found in some other languages, but unlike function pointers, delegates are object-oriented and type-safe.
* [Attributes](attributes.md)
 	* ***Attributes*** enable programs to specify additional declarative information about types, members, and other entities.

>[!div class="step-by-step"]
[Next](program-structure.md)
