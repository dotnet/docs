---
title: Tour of .NET
description: A guided tour through some of the prominent features of the .NET platform.
keywords: .NET, .NET Core, Tour, Programming Languages, 
author: richlander
manager: wpickett
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: bbfe6465-329d-4982-869d-472e7ef85d93
---

# Tour of .NET

.NET is a general purpose development platform.  It has several key features, such as multiple programming languages, asynchronous and concurrent programming models, and native interoperability which enable a wide range of scenarios across multiple platforms.

This article offers a guided tour through some of the key features of the .NET platform.

See the [.NET Architectural Components](components.md) to learn about each of the architectural "pieces" of .NET and what they're used for.

## How to run the code samples

> ![NOTE]
In the future, this documentation site will have the ability to run these code samples in your browser.

To learn how to set up a development environment to run the code samples, check out [Getting Started](getting-started.md).  You can copy and paste code samples from this page into your environment to execute them. 

## Programming languages

.NET supports multiple programming languages.  .NET runtimes implement the [Common Language Infrastructure (CLI)](https://www.visualstudio.com/en-us/mt639507), which (among other things) specifies a language-independent runtime and language interoperability.  This means that you can choose any .NET language to build apps and services on .NET.

Microsoft actively developes and supports three .NET languages: C#, F#, and Visual Basic .NET. 

* C# is simple, powerful, type-safe, and object-oriented while retaining the expressiveness and elegance of C-style languages. Anyone familiar with C and similar languages will find few problems in adapting to C#.  Check out the [C# Guide](../csharp/index.md) to learn more about C#.

* F# is a cross-platform, functional-first programming language that also supports traditional object-oriented and imperative programming.  Check out the [F# Guide](../fsharp/index.md) to learn more about F#.

* Visual Basic is an easy language to learn that you can use to build a variety of applications that run on .NET.

## Automatic memory management

.NET uses [garbage collection](garbage-collection/index.md) to provide automatic memory management for programs.  The GC operates on a lazy approach to memory management, preferring application throughput to the immediate collection of memory.  To learn more about the .NET GC, check out [Fundamentals of garbage collection](garbage-collection/fundamentals.md).

The following two lines both allocate memory:

```cs
var title = ".NET Primer";
var list = new List<string>();
```

There is no analogous keyword to de-allocate memory, as de-allocation happens automatically when the garbage collector reclaims the memory through its scheduled run.

Types within a given scope normally go out of scope once a method completes, at which point they can be collected. However, you can indicate to the GC that a particular object is out of scope sooner than method exit using the `using` statement:

```cs
using (FileStream stream = GetFileStream(context))
{
    // Operations on the stream
}
```

Once the `using` block completes, the GC will know that the `stream` object in the example above is free to be collected and its memory reclaimed.

Rules for this have slightly different semantics in F#.  To learn more about resource management in F#, check out [Resource Management: The `use` Keyword](../fsharp/language-reference/resource-management-the-use-keyword.md)

One of the less obvious but quite far-reaching features that a garbage collector enables is memory safety. The invariant of memory safety is very simple: a program is memory safe if it accesses only memory that has been allocated (and not freed). Dangling pointers are always bugs, and tracking them down is often quite difficult.

The .NET runtime provides additional services, to complete the promise of memory safety, not naturally offered by a GC. It ensures that programs do not index off the end of an array or accessing a phantom field off the end of an object.

The following example will throw an exception as a result of memory safety.

```cs
int[] numbers = new int[42];
int number = numbers[42]; // will throw (indexes are 0-based)
```

## Type safety

Objects are allocated in terms of types. The only operations allowed for a given object, and the memory it consumes, are those of its type. A `Dog` type may have `Jump` and `WagTail` methods, but not likely a `SumTotal` method. A program can only call the declared methods of a given type. All other calls will result either in a compile-time error or a run-time exception (in case of using dynamic features or `object`).

.NET languages are object-oriented, with hierarchies of base and derived classes. The .NET runtime will only allow object casts and calls that align with the object hierarchy. Remember that every type defined in any .NET language derives from the base `object` type.

```cs
Dog dog = AnimalShelter.AdoptDog(); // Returns a Dog type.
Pet pet = (Pet)dog; // Dog derives from Pet.
Car car = (Car)dog; // Will throw - no relationship between Car and Dog.
object temp = (object)dog; // Legal - a Dog is an object.
car = (Car)temp; // Will throw - the runtime isn't fooled.
```

Type safety is also used to help enforce encapsulation by guaranteeing the fidelity of the accessor keywords. Accessor keywords are artifacts which control access to members of a given type by other code. These are usually used for various kinds of data within a type that are used to manage its behavior.

```cs
Dog dog = Dog._nextDogToBeAdopted; // will throw - this is a private field
```

C#, Visual Basic, and F# support local **type inference**. Type inference means that the compiler will deduce the type of the expression on the left-hand side from the expression on the right-hand side. This doesn't mean that the type safety is broken or avoided. The resulting type **has** a strong type with everything that implies. Let's rewrite the first two lines of the previous example to introduce type inference. You will note that the rest of the example is completely the same.

```cs
var dog = Dog.AdoptDog();
var pet = (Pet)dog;
pet.ActCute();
Car car = (Car)dog; // will throw - no relationship between Car and Dog
object temp = (object)dog; // legal - a Dog is an object
car = (Car)temp; // will throw - the runtime isn't fooled
car.Accelerate() // the dog won't like this, nor will the program get this far
```

F# has even further type inference capabilities than method-local type inference found in C# and Visual Basic.  To learn more, check out [Type Inferece](../fsharp/language-reference/type-inference.md).

## Delegates and lambdas

Delegates are like C++ function pointers, with a big difference that they are type safe. They are a kind of disconnected method within the CLR type system. Regular methods are attached to a class and only directly callable through static or instance calling conventions.

Delegates are used in various APIs and places in the .NET world, especially through lambda expressions, which are a cornerstone of LINQ.

Read more about it in the [Delegates and lambdas](delegates-lambdas.md) document.

## Generics

Generics are a feature that was added in .NET Framework 2.0. In short, generics allow the programmer to introduce a "type parameter" when designing their classes, that will allow the client code (the users of the type) to specify the exact type to use in place of the type parameter.

Generics were added in order to help programmers implement generic data structures. Before their arrival, in order for a, say, _List_ type to be generic, it would have to work with elements that were of type _object_. This would have various performance as well as semantic problems, not to mention possible subtle runtime errors. The most notorious of the latter is when a data structure contains, for instance, both integers and strings, and an _InvalidCastException_ is thrown on working with the list's members.

The below sample shows a basic program running using an instance of @System.Collections.Generic.List%601 types.

```cs
using System;
using System.Collections.Generic;

namespace GenericsSampleShort
{
    public static void Main(string[] args)
    {
        // List<string> is the client way of specifying the actual type for the type parameter T
        List<string> listOfStrings = new List<string> { "First", "Second", "Third" };

        // listOfStrings can accept only strings, both on read and write.
        listOfStrings.Add("Fourth");

        // Below will throw a compile-time error, since the type parameter
        // specifies this list as containing only strings.
        listOfStrings.Add(1);
    }
}
```

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

The `ToString()` method from the [StringBuilder class](https://github.com/dotnet/coreclr/blob/master/src/mscorlib/src/System/Text/StringBuilder.cs#L327) illustrates how using `unsafe` code can efficiently implement an algorithm by moving around chunks of memory directly:

```cs
public override String ToString() {
    Contract.Ensures(Contract.Result<String>() != null);

    VerifyClassInvariant();

    if (Length == 0)
        return String.Empty;

    string ret = string.FastAllocateString(Length);
    StringBuilder chunk = this;
    unsafe {
        fixed (char* destinationPtr = ret)
        {
            do
            {
                if (chunk.m_ChunkLength > 0)
                {
                    // Copy these into local variables so that they are stable even in the presence of ----s (hackers might do this)
                    char[] sourceArray = chunk.m_ChunkChars;
                    int chunkOffset = chunk.m_ChunkOffset;
                    int chunkLength = chunk.m_ChunkLength;

                    // Check that we will not overrun our boundaries.
                    if ((uint)(chunkLength + chunkOffset) <= ret.Length && (uint)chunkLength <= (uint)sourceArray.Length)
                    {
                        fixed (char* sourcePtr = sourceArray)
                            string.wstrcpy(destinationPtr + chunkOffset, sourcePtr, chunkLength);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("chunkLength", Environment.GetResourceString("ArgumentOutOfRange_Index"));
                    }
                }
                chunk = chunk.m_ChunkPrevious;
            } while (chunk != null);
        }
    }
    return ret;
}
```

## Next Steps

blah blah getting started, standard library, languages, concepts