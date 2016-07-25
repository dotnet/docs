---
title: Visual F# #
description: Visual F# #
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3a9255c1-fad9-44ec-ace1-d9b773337361 
---

# Visual F# #

F# is a programming language that provides support for functional programming in addition to traditional object-oriented and imperative (procedural) programming. The Visual F# product provides support for developing F# applications and extending other .NET Framework applications by using F# code. F# is a first-class member of the .NET Framework languages and retains a strong resemblance to the ML family of functional languages.

This version of Visual F# contains the F# 4.0 version of the language.


## Multiple-Paradigm Language
F# supports functional programming constructs such as the following:


- Functions as values, which enables flexible manipulation of functions. For more information, see [Functions as First-Class Values &#40;F&#35;&#41;](Functions-as-First-Class-Values-%5BFSharp%5D.md).
<br />

- Function composition and pipelining, which enables you to combine functions together to create new functions and to simplify the coding of successive operations on data. For more information, see [Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md).
<br />

- [Type inference](https://msdn.microsoft.com/library/1064b523-4917-424c-9c4e-e4bf96ecae6f), which reduces the requirement to explicitly call out types without sacrificing type safety.
<br />

- [Automatic generalization](https://msdn.microsoft.com/library/1a9ea094-2f91-445f-9a48-54e41b12f370), which promotes code reuse by making it easy to write code that works with a variety of different types without any additional effort.
<br />

- [Pattern matching](https://msdn.microsoft.com/library/dab9b934-5528-4283-8986-794d832f0a0b) support, which simplifies complex conditional code, and [discriminated unions](https://msdn.microsoft.com/library/93d78afb-0fb3-4357-8bcd-5c94720916ca), which are optimized to be used with pattern matching.
<br />

- Collection types for working with immutable data, including [list](https://msdn.microsoft.com/library/83102799-f251-42e1-93ef-64232e8c5b1d) and [sequence](https://msdn.microsoft.com/library/6b773b6b-9c9a-4af8-bd9e-d96585c166db) types.
<br />

- [Lambda expressions](https://msdn.microsoft.com/library/556283bc-c82d-4cb5-b20a-d24b346b619d), which are important to many functional programming constructs.
<br />

- Partial application of function arguments, which enables you to create new functions implicitly from existing ones. For more information, see [Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md).
<br />

- [Code Quotations](https://msdn.microsoft.com/library/6f055397-a1f0-4f9a-927c-f0d7c6951155), a feature that enables you to manipulate F# expressions programmatically.
<br />

F# supports object-oriented programming and .NET Framework capabilities such as the following:


- The .NET Framework object model, including objects that have properties, methods, and events; polymorphism or virtual functions; inheritance; and interfaces.
<br />

- Data encapsulation, or separating the public interface of a type from the implementation.
<br />

- [Operator overloading](https://msdn.microsoft.com/library/6217a7e4-863b-475a-9d79-b788cddfb6f9) that works well with generics and built-in primitive types.
<br />

- [Type extensions](https://msdn.microsoft.com/library/6e27449f-204f-43e1-b7d6-e99f12cb0bc2), which enable you to extend an existing type easily without the additional overhead work of creating a new derived type.
<br />

- [Object expressions](https://msdn.microsoft.com/library/c2b23aa3-63de-4bea-aa73-6b54fefb5252), which enable you to define small objects implicitly in expressions as needed, instead of declaring a new type and instantiating an object.
<br />

- Access to the .NET Framework and any managed code assembly.
<br />

- Access to native code through platform invoke.
<br />

Visual F# supports information-rich programming. This technology lets you program directly against rich spaces of data and services that often dominate enterprise and web programming today, such as databases, web services, web data feeds, and data brokers.

F# information-rich programming is code-focused and can be used in both scripts and projects. It also allows you to specify OData and SQL Server database connections directly in your code, while giving strong types with IntelliSense assistance. The mechanism is extensible, allowing you to write or reference new providers for data, code, and service technologies such as SharePoint, web ontologies, Windows Management Instrumentation (WMI), XML, and other information sources. Technically, F# information-rich programming includes the [F# Type Providers](https://msdn.microsoft.com/library/ee83de0a-f7a7-4ddd-b292-53c1684a8e9e) mechanism, [F# Query Expressions](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db), and a set of built-in type providers for database, OData, and web service programming.

F# also supports all the common imperative programming constructs, such as branching and looping constructs.


## F# Libraries
The Visual F# product also includes a core [F# library](https://msdn.microsoft.com/library/430e8455-57a5-46a1-b4b1-4e54ed7f4ef3) that has many useful functions and types. This includes APIs for collections such as [lists](https://msdn.microsoft.com/library/83102799-f251-42e1-93ef-64232e8c5b1d), [arrays](https://msdn.microsoft.com/library/70ad71f0-f4bf-42d7-b1a9-44a2f4bd2c6f), [maps](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664), [sets](https://msdn.microsoft.com/library/50cebdce-0cd7-4c5c-8ebc-f3a9e90b38d8), and [sequences](https://msdn.microsoft.com/library/6b773b6b-9c9a-4af8-bd9e-d96585c166db). The F# core library also supports reflection, events, and formatted I/O.

In addition, the core F# library includes support for asynchronous workflows to support parallel computations, and mechanisms for communicating among parallel workflows. For more information, see [Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md), [Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md), and [Control.MailboxProcessor&#60;'Msg&#62; Class &#40;F&#35;&#41;](Control.MailboxProcessor%5B%27Msg%5D-Class-%5BFSharp%5D.md).
Separately compiled versions of the F# Core library exist that support different versions of the .NET Framework.

The core F# library is FSharp.Core.dll. All .NET libraries can be used from F# and a vast
number of .NET libraries are available from [NuGet](http://nuget.org).  In addition, many
F#-specific libraries are also available from NuGet. The [F# Software Foundation](http://fsharp.org)
curates [a list of F#-specific community libraries](http://fsharp.org/community/projects/).



## Interactive Scripting
Visual F# provides an interactive window that is integrated into the Visual Studio development environment. This window enables you to enter F# code and have it immediately compiled and executed. This enables you to easily prototype code constructs and test your code while you write it. The interactive window runs the F# interactive tool, fsi.exe, which you can also run from the command line. This feature allows F# to be used as a scripting language. For more information, see [F&#35; Interactive &#40;fsi.exe&#41; Reference](FSharp-Interactive-%5Bfsi.exe%5D-Reference.md).


## Integration with Visual Studio
F# is integrated with Visual Studio, and has support for the following:


- Projects, including templates for common project types. For more information, see [Using Visual Studio to Write F&#35; Programs](Using-Visual-Studio-to-Write-FSharp-Programs.md) and [Configuring Projects &#40;F&#35;&#41;](Configuring-Projects-%5BFSharp%5D.md).
<br />

- IntelliSense. For more information, see [Using IntelliSense](https://msdn.microsoft.com/library/hcw1s69b.aspx).
<br />

- Debugging. For more information, see [Debugging in Visual Studio](https://msdn.microsoft.com/library/sc65sadd.aspx).
<br />

- For more information, see [F&#35; Development Environment Features](FSharp-Development-Environment-Features.md).
<br />


## Related Topics


|Title|Description|
|-----|-----------|
|[Visual F&#35; Development Portal](Visual-FSharp-Development-Portal.md)|A gateway to a wide variety of information about F#.|
|[Using Visual Studio to Write F&#35; Programs](Using-Visual-Studio-to-Write-FSharp-Programs.md)|Provides information about using F# in the Integrated Development Environment (IDE), including project settings and IntelliSense.|
|[F&#35; Language Reference](FSharp-Language-Reference.md)|Provides reference information about the F# language, including information about keywords, symbols, and operators.|
|[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)|Provides reference information about the F# core library, FSharp.Core.dll.|
|[F&#35; Compiler &#40;fsc.exe&#41; Reference](FSharp-Compiler-%5Bfsc.exe%5D-Reference.md)|Provides information about the F# compiler, fsc.exe, including information about compiler options.|
|[F&#35; Interactive &#40;fsi.exe&#41; Reference](FSharp-Interactive-%5Bfsi.exe%5D-Reference.md)|Provides information about F# Interactive, fsi.exe, including information about command-line options and diagnostic messages that are specific to F# Interactive.|
|[Visual F&#35; Samples and Walkthroughs](Visual-FSharp-Samples-and-Walkthroughs.md)|Provides links to F# samples and walkthroughs.|

## See Also
[Welcome to Visual Studio 2015](https://msdn.microsoft.com/library/dd831853.aspx)