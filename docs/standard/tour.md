---
title: Tour of .NET
description: A guided tour through some of the prominent features of the .NET platform.
keywords: .NET, .NET Core, Tour, Programming Languages, Unsafe, Memory Management, Type Safety, Async
author: cartermp
ms.author: wiwagn
ms.date: 02/09/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: bbfe6465-329d-4982-869d-472e7ef85d93
---

# Tour of .NET

.NET is a general purpose development platform.  It has several key features, such as multiple programming languages, asynchronous and concurrent programming models, and native interoperability which enable a wide range of scenarios across multiple platforms.

This article offers a guided tour through some of the key features of the .NET platform.

See the [.NET Architectural Components](components.md) to learn about each of the architectural "pieces" of .NET and what they're used for.

## How to run the code samples

To learn how to set up a development environment to run the code samples, check out [Getting Started](get-started.md).  You can copy and paste code samples from this page into your environment to execute them. 

> [!NOTE]
In the future, this documentation site will have the ability to run these code samples in your browser.

## Programming languages

.NET supports multiple programming languages.  .NET runtimes implement the [Common Language Infrastructure (CLI)](https://www.visualstudio.com/license-terms/ecma-c-common-language-infrastructure-standards/), which (among other things) specifies a language-independent runtime and language interoperability.  This means that you can choose any .NET language to build apps and services on .NET.

Microsoft actively develops and supports three .NET languages: C#, F#, and Visual Basic .NET. 

* C# is simple, powerful, type-safe, and object-oriented while retaining the expressiveness and elegance of C-style languages. Anyone familiar with C and similar languages will find few problems in adapting to C#.  Check out the [C# Guide](../csharp/index.md) to learn more about C#.

* F# is a cross-platform, functional-first programming language that also supports traditional object-oriented and imperative programming.  Check out the [F# Guide](../fsharp/index.md) to learn more about F#.

* Visual Basic is an easy language to learn that you can use to build a variety of applications that run on .NET.

## Automatic memory management

.NET uses [garbage collection](garbagecollection/index.md) to provide automatic memory management for programs.  The GC operates on a lazy approach to memory management, preferring application throughput to the immediate collection of memory.  To learn more about the .NET GC, check out [Fundamentals of garbage collection (GC)](garbagecollection/fundamentals.md).

The following two lines both allocate memory:

[!code-csharp[MemoryManagement](../../samples/csharp/snippets/tour/MemoryManagement.csx#L1-L2)]

There is no analogous keyword to de-allocate memory, as de-allocation happens automatically when the garbage collector reclaims the memory through its scheduled run.

The garbage collector is just one of the services that help ensure *memory safety*.  The invariant of memory safety is very simple: a program is memory safe if it accesses only memory that has been allocated (and not freed).  For instance, the runtime ensures that programs do not index off the end of an array or access a phantom field off the end of an object.

In the following example, the runtime will throw an `InvalidIndexException` exception, to enforce memory safety.

[!code-csharp[MemoryManagement](../../samples/csharp/snippets/tour/MemoryManagement.csx#L4-L5)]

## Working with unmanaged resources

Some objects reference *unmanaged resources*. Unmanaged resources are resources that are not automatically maintained by the .NET runtime.  For example, a file handle is an unmanaged resource.  A @System.IO.FileStream object is a managed object, but it references a file handle, which is unmanaged.  When you are done using the FileStream, you need to release the file handle.

In .NET, objects that reference unmanaged resources implement the @System.IDisposable interface.  When you are done using the object, you call the object's @System.IDisposable.Dispose method, which is responsible for releasing any unmanaged resources.  .NET languages provide a convenient `using` syntax for such objects, as in the following example:

[!code-csharp[UnmanagedResources](../../samples/csharp/snippets/tour/UnmanagedResources.csx#L1-L6)]

Once the `using` block completes, the .NET runtime will automatically call the `stream` object's @System.IDisposable.Dispose method, which releases the file handle.  The runtime will also do this if an exception causes control to leave the block.

For more details, check out the following pages:

* For C#, [using Statement](../csharp/language-reference/keywords/using-statement.md)
* For F#, [Resource Management: The `use` Keyword](../fsharp/language-reference/resource-management-the-use-keyword.md)
* For Visual Basic, [Using Statement](../visual-basic/language-reference/statements/using-statement.md)

## Type safety

Objects are allocated in terms of types. The only operations allowed for a given object, and the memory it consumes, are those of its type. A `Dog` type may have `Jump` and `WagTail` methods, but not likely a `SumTotal` method. A program can only call the declared methods of a given type. All other calls will result either in a compile-time error or a run-time exception (in case of using dynamic features or `object`).

.NET languages are object-oriented, with hierarchies of base and derived classes. The .NET runtime will only allow object casts and calls that align with the object hierarchy. Remember that every type defined in any .NET language derives from the base `object` type.

[!code-csharp[TypeSafety](../../samples/csharp/snippets/tour/TypeSafety.csx#L18-L23)]

Type safety is also used to help enforce encapsulation by guaranteeing the fidelity of the accessor keywords. Accessor keywords are artifacts which control access to members of a given type by other code. These are usually used for various kinds of data within a type that are used to manage its behavior.

[!code-csharp[TypeSafety](../../samples/csharp/snippets/tour/TypeSafety.csx#L3-L3)]

C#, Visual Basic, and F# support local **type inference**. Type inference means that the compiler will deduce the type of the expression on the left-hand side from the expression on the right-hand side. This doesn't mean that the type safety is broken or avoided. The resulting type **has** a strong type with everything that implies. Let's rewrite the first two lines of the previous example to introduce type inference. Note that the rest of the example is completely the same.

[!code-csharp[TypeSafety](../../samples/csharp/snippets/tour/TypeSafety.csx#L28-L34)]

F# has even further type inference capabilities than method-local type inference found in C# and Visual Basic.  To learn more, check out [Type Inference](../fsharp/language-reference/type-inference.md).

## Delegates and lambdas

Delegates are like C++ function pointers, with a big difference that they are type safe. They are a kind of disconnected method within the CLR type system. Regular methods are attached to a class and only directly callable through static or instance calling conventions.

Delegates are used in various APIs and places in the .NET world, especially through lambda expressions, which are a cornerstone of LINQ.

Read more about it in the [Delegates and lambdas](delegates-lambdas.md) document.

## Generics

Generics are a feature that was added in .NET Framework 2.0. In short, generics allow the programmer to introduce a "type parameter" when designing their classes, that allows the client code (the users of the type) to specify the exact type to use in place of the type parameter.

Generics were added to help programmers implement generic data structures. Before their arrival, in order for a, say, `List` type to be generic, it would have to work with elements that were of type `object`. This would have various performance as well as semantic problems, not to mention possible subtle runtime errors. The most notorious of the latter is when a data structure contains, for instance, both integers and strings, and an `InvalidCastException` is thrown on working with the list's members.

The following sample shows a basic program running using an instance of @System.Collections.Generic.List%601 types.

[!code-csharp[GenericsShort](../../samples/csharp/snippets/tour/GenericsShort.csx)]

For more information, see the [Generic types (Generics) overview](generics.md) article.

## Async programming

Async programming is a first-class concept within .NET, with async support in the runtime, the framework libraries, and .NET language constructs. Internally, they are based off of objects (such as `Task`) which take advantage of the operating system to perform I/O-bound jobs as efficiently as possible.

To learn more about async programming in .NET, start with the [Async overview](async.md).

## Language Integrated Query (LINQ)

LINQ is a powerful set of features for C# and VB that allow you to write simple, declarative code for operating on data. The data can be in many forms (such as in-memory objects, in a SQL database, or an XML document), but the LINQ code you write typically won't look different for each data source!

To learn more and see some samples, check out [LINQ (Language Integrated Query)](using-linq.md).

## Native interoperability

Every operating system in current use provides a lot of platform support for various programming tasks. .NET provides several ways to tap into those APIs. Collectively, this support is called "native interoperability" and in this section we will take a look at how to access native APIs from managed, .NET code.

The main way to do native interoperability is via "platform invoke" or P/Invoke for short. This support in .NET Core is available across Linux and Windows platforms. Another, Windows-only way of doing native interoperability is known as "COM interop" which is used to work with [COM components](https://msdn.microsoft.com/library/bwa2bx93.aspx) in managed code. It is built on top of P/Invoke infrastructure, but it works in subtly different ways.

Most of Mono's (and thus Xamarin's) interoperability support for Java and Objective-C are built similarly, that is, they use the same principles.

Read more about it in the [Native interoperability](native-interop.md) document.

## Unsafe code

The CLR enables the ability to access native memory and do pointer arithmetic via `unsafe` code. These operations are needed for certain algorithms and system interoperability. Although powerful, use of unsafe code is discouraged unless it is necessary to interop with system APIs or implement the most efficient algorithm. Unsafe code may not execute the same way in different environments, and also loses the benefits of a garbage collector and type safety. It's recommended to confine and centralize unsafe code as much as possible, and test that code thoroughly.

The following example is a modified version of the `ToString()` method from the `StringBuilder` class.  It illustrates how using `unsafe` code can efficiently implement an algorithm by moving around chunks of memory directly:

[!code-csharp[Unsafe](../../samples/csharp/snippets/tour/Unsafe.csx)]

## Next Steps

If you're interested in a tour of C# features, check out [Tour of C#](../csharp/tour-of-csharp/index.md).

If you're interested in a tour of F# features, check out [Tour of F#](../fsharp/tour.md).

If you want to get started with writing code of your own, check out [Getting Started](get-started.md).

To learn about important components of .NET, check out [.NET Architectural Components](components.md).
