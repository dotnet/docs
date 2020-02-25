---
title: F# Language Reference
description: F# Language Reference
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b1707be1-7b7c-4fdd-a717-d9c190bc5fb5
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/index 
---

# F# Language Reference

This section is a reference to the F# language, a multi-paradigm programming language targeting the .NET platform. The F# language supports functional, object-oriented and imperative programming models.


## F# Tokens
The following table shows reference topics that provide tables of keywords, symbols and literals used as tokens in F#.



|Title|Description|
|-----|-----------|
|[Keyword Reference &#40;F&#35;&#41;](Keyword-Reference-%5BFSharp%5D.md)|Contains links to information about all F# language keywords.|
|[Symbol and Operator Reference &#40;F&#35;&#41;](Symbol-and-Operator-Reference-%5BFSharp%5D.md)|Contains a table of symbols and operators that are used in the F# language.|
|[Literals &#40;F&#35;&#41;](Literals-%5BFSharp%5D.md)|Describes the syntax for literal values in F# and how to specify type information for F# literals.|

## F# Language Concepts
The following table shows reference topics available that describe language concepts.



|Title|Description|
|-----|-----------|
|[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)|Functions are the fundamental unit of program execution in any programming language. As in other languages, an F# function has a name, can have parameters and take arguments, and has a body. F# also supports functional programming constructs such as treating functions as values, using unnamed functions in expressions, composition of functions to form new functions, curried functions, and the implicit definition of functions by way of the partial application of function arguments.|
|[F&#35; Types](FSharp-Types.md)|Describes the types that are used in F# and how F# types are named and described.|
|[Type Inference &#40;F&#35;&#41;](Type-Inference-%5BFSharp%5D.md)|Describes how the F# compiler infers the types of values, variables, parameters and return values.|
|[Automatic Generalization &#40;F&#35;&#41;](Automatic-Generalization-%5BFSharp%5D.md)|Describes generic constructs in F#.|
|[Inheritance &#40;F&#35;&#41;](Inheritance-%5BFSharp%5D.md)|Describes inheritance, which is used to model the "is-a" relationship, or subtyping, in object-oriented programming.|
|[Members &#40;F&#35;&#41;](Members-%5BFSharp%5D.md)|Describes members of F# object types.|
|[Parameters and Arguments &#40;F&#35;&#41;](Parameters-and-Arguments-%5BFSharp%5D.md)|Describes language support for defining parameters and passing arguments to functions, methods, and properties. It includes information about how to pass by reference.|
|[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|Describes how to overload arithmetic operators in a class or record type, and at the global level.|
|[Casting and Conversions &#40;F&#35;&#41;](Casting-and-Conversions-%5BFSharp%5D.md)|Describes support for type conversions in F#.|
|[Access Control &#40;F&#35;&#41;](Access-Control-%5BFSharp%5D.md)|Describes access control in F#. Access control means declaring what clients are able to use certain program elements, such as types, methods, functions and so on.|
|[Pattern Matching &#40;F&#35;&#41;](Pattern-Matching-%5BFSharp%5D.md)|Describes patterns, which are rules for transforming input data that are used throughout the F# language to extract compare data with a pattern, decompose data into constituent parts, or extract information from data in various ways.|
|[Active Patterns &#40;F&#35;&#41;](Active-Patterns-%5BFSharp%5D.md)|Describes active patterns. Active patterns enable you to define named partitions that subdivide input data. You can use active patterns to decompose data in a customized manner for each partition.|
|[Assertions &#40;F&#35;&#41;](Assertions-%5BFSharp%5D.md)|Describes the `assert` expression, which is a debugging feature that you can use to test an expression. Upon failure in Debug mode, an assertion generates a system error dialog box.|
|[Exception Handling &#40;F&#35;&#41;](Exception-Handling-%5BFSharp%5D.md)|Contains information about exception handling support in the F# language.|
|[Attributes &#40;F&#35;&#41;](Attributes-%5BFSharp%5D.md)|Describes attributes, which enable metadata to be applied to a programming construct.|
|[Resource Management: The use Keyword &#40;F&#35;&#41;](Resource-Management-The-use-Keyword-%5BFSharp%5D.md)|Describes the keywords `use` and `using`, which can control the initialization and release of resources|
|[Namespaces &#40;F&#35;&#41;](Namespaces-%5BFSharp%5D.md)|Describes namespace support in F#. A namespace lets you organize code into areas of related functionality by enabling you to attach a name to a grouping of program elements.|
|[Modules &#40;F&#35;&#41;](Modules-%5BFSharp%5D.md)|Describes modules. An F# module is a grouping of F# code, such as values, types, and function values, in an F# program. Grouping code in modules helps keep related code together and helps avoid name conflicts in your program.|
|[Import Declarations: The open Keyword &#40;F&#35;&#41;](Import-Declarations-The-open-Keyword-%5BFSharp%5D.md)|Describes how `open` works. An import declaration specifies a module or namespace whose elements you can reference without using a fully qualified name.|
|[Signatures &#40;F&#35;&#41;](Signatures-%5BFSharp%5D.md)|Describes signatures and signature files. A signature file contains information about the public signatures of a set of F# program elements, such as types, namespaces, and modules. It can be used to specify the accessibility of these program elements.|
|[XML Documentation &#40;F&#35;&#41;](XML-Documentation-%5BFSharp%5D.md)|Describes support for generating documentation files for XML doc comments, also known as triple slash comments. You can produce documentation from code comments in F# just as in other .NET languages.|
|[Verbose Syntax &#40;F&#35;&#41;](Verbose-Syntax-%5BFSharp%5D.md)|Describes the syntax for F# constructs when lightweight syntax is not enabled. Verbose syntax is indicated by the `#light "off"` directive at the top of the code file.|

## F# Types
The following table shows reference topics available that describe types supported by the F# language.



|Title|Description|
|-----|-----------|
|[Values &#40;F&#35;&#41;](Values-%5BFSharp%5D.md)|Describes values, which are immutable quantities that have a specific type; values can be integral or floating point numbers, characters or text, lists, sequences, arrays, tuples, discriminated unions, records, class types, or function values.|
|[Primitive Types &#40;F&#35;&#41;](Primitive-Types-%5BFSharp%5D.md)|Describes the fundamental primitive types that are used in the F# language. It also provides the corresponding .NET types and the minimum and maximum values for each type.|
|[Unit Type &#40;F&#35;&#41;](Unit-Type-%5BFSharp%5D.md)|Describes the `unit` type, which is a type that indicates the absence of a specific value; the `unit` type has only a single value, which acts as a placeholder when no other value exists or is needed.|
|[Strings &#40;F&#35;&#41;](Strings-%5BFSharp%5D.md)|Describes strings in F#. The `string` type represents immutable text, as a sequence of Unicode characters. `string` is an alias for `System.String` in the .NET Framework.|
|[Tuples &#40;F&#35;&#41;](Tuples-%5BFSharp%5D.md)|Describes tuples, which are groupings of unnamed but ordered values of possibly different types.|
|[F&#35; Collection Types](FSharp-Collection-Types.md)|An overview of the F# functional collection types, including types for arrays, lists, sequences (seq), maps, and sets.|
|[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)|Describes lists. A list in F# is an ordered, immutable series of elements all of the same type.|
|[Options &#40;F&#35;&#41;](Options-%5BFSharp%5D.md)|Describes the option type. An option in F# is used when a value may or may not exist. An option has an underlying type and may either hold a value of that type or it may not have a value.|
|[Sequences &#40;F&#35;&#41;](Sequences-%5BFSharp%5D.md)|Describes sequences. A sequence is a logical series of elements all of one type. Individual sequence elements are only computed if required, so the representation may be smaller than a literal element count indicates.|
|[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)|Describes arrays. Arrays are fixed-size, zero-based, mutable sequences of consecutive data elements, all of the same type.|
|[Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md)|Describes records. Records represent simple aggregates of named values, optionally with members.|
|[Discriminated Unions &#40;F&#35;&#41;](Discriminated-Unions-%5BFSharp%5D.md)|Describes discriminated unions, which provides support for values which may be one of a variety of named cases, each with possibly different values and types.|
|[Enumerations &#40;F&#35;&#41;](Enumerations-%5BFSharp%5D.md)|Describes enumerations are types that have a defined set of named values. You can use them in place of literals to make code more readable and maintainable.|
|[Reference Cells &#40;F&#35;&#41;](Reference-Cells-%5BFSharp%5D.md)|Describes reference cells, which are storage locations that enable you to create mutable variables with reference semantics.|
|[Type Abbreviations &#40;F&#35;&#41;](Type-Abbreviations-%5BFSharp%5D.md)|Describes type abbreviations, which are alternate names for types.|
|[Classes &#40;F&#35;&#41;](Classes-%5BFSharp%5D.md)|Describes classes, which are types that represent objects that can have properties, methods, and events.|
|[Structures &#40;F&#35;&#41;](Structures-%5BFSharp%5D.md)|Describes structures, which are compact object types that can be more efficient than a class for types that have a small amount of data and simple behavior.|
|[Interfaces &#40;F&#35;&#41;](Interfaces-%5BFSharp%5D.md)|Describes interfaces, which specify sets of related members that other classes implement.|
|[Abstract Classes &#40;F&#35;&#41;](Abstract-Classes-%5BFSharp%5D.md)|Describes abstract classes, which are classes that leave some or all members unimplemented, so that implementations can be provided by derived classes.|
|[Type Extensions &#40;F&#35;&#41;](Type-Extensions-%5BFSharp%5D.md)|Describes type extensions, which let you add new members to a previously defined object type.|
|[Flexible Types &#40;F&#35;&#41;](Flexible-Types-%5BFSharp%5D.md)|Describes flexible types. A flexible type annotation is an indication that a parameter, variable or value has a type that is compatible with type specified, where compatibility is determined by position in an object-oriented hierarchy of classes or interfaces.|
|[Delegates &#40;F&#35;&#41;](Delegates-%5BFSharp%5D.md)|Describes delegates, which represent a function call as an object.|
|[Units of Measure &#40;F&#35;&#41;](Units-of-Measure-%5BFSharp%5D.md)|Describes units of measure. Floating point values in F# can have associated units of measure, which are typically used to indicate length, volume, mass, and so on.|
|[Type Providers](Type-Providers.md)|Describes type provides and provides links to walkthroughs on using the built-in type providers to access databases and web services.|

## F# Expressions
The following table lists topics that describe F# expressions.

|Title|Description|
|-----|-----------|
|[Conditional Expressions: if... then...else &#40;F&#35;&#41;](Conditional-Expressions-if...-then...else-%5BFSharp%5D.md)|Describes the `if...then...else` expression, which runs different branches of code and also evaluates to a different value depending on the Boolean expression given.|
|[Match Expressions &#40;F&#35;&#41;](Match-Expressions-%5BFSharp%5D.md)|Describes the `match` expression, which provides branching control that is based on the comparison of an expression with a set of patterns.|
|[Loops: for...to Expression &#40;F&#35;&#41;](Loops-for...to-Expression-%5BFSharp%5D.md)|Describes the `for...to` expression, which is used to iterate in a loop over a range of values of a loop variable.|
|[Loops: for...in Expression &#40;F&#35;&#41;](Loops-for...in-Expression-%5BFSharp%5D.md)|Describes the `for...in` expression, a looping construct that is used to iterate over the matches of a pattern in an enumerable collection such as a range expression, sequence, list, array, or other construct that supports enumeration.|
|[Loops: while...do Expression &#40;F&#35;&#41;](Loops-while...do-Expression-%5BFSharp%5D.md)|Describes the `while...do` expression, which is used to perform iterative execution (looping) while a specified test condition is true.|
|[Object Expressions &#40;F&#35;&#41;](Object-Expressions-%5BFSharp%5D.md)|Describes object expressions, which are expressions that create new instances of a dynamically created, anonymous object type that is based on an existing base type, interface, or set of interfaces.|
|[Lazy Computations &#40;F&#35;&#41;](Lazy-Computations-%5BFSharp%5D.md)|Describes lazy computations, which are computations that are not evaluated immediately, but are instead evaluated when the result is actually needed.|
|[Computation Expressions &#40;F&#35;&#41;](Computation-Expressions-%5BFSharp%5D.md)|Describes computation expressions in F#, which provide a convenient syntax for writing computations that can be sequenced and combined using control flow constructs and bindings. They can be used to provide a convenient syntax for *monads*, a functional programming feature that can be used to manage data, control and side effects in functional programs. One type of computation expression, the asynchronous workflow, provides support for asynchronous and parallel computations. For more information, see [Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md).|
|[Asynchronous Workflows &#40;F&#35;&#41;](Asynchronous-Workflows-%5BFSharp%5D.md)|Describes asynchronous workflows, a language feature that lets you write asynchronous code in a way that is very close to the way you would naturally write synchronous code.|
|[Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md)|Describes code quotations, a language feature that enables you to generate and work with F# code expressions programmatically.|
|[Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md)|Describes query expressions, a language feature that implements LINQ for F# and enables you to write queries against a data source or enumerable collection.|

## Compiler-supported Constructs
The following table lists topics that describe special compiler-supported constructs.

|Topic|Description|
|-----|-----------|
|[Compiler Directives &#40;F&#35;&#41;](Compiler-Directives-%5BFSharp%5D.md)|Describes processor directives and compiler directives.|
|[Source Line, File, and Path Identifiers &#40;F&#35;&#41;](Source-Line%2C-File%2C-and-Path-Identifiers-%5BFSharp%5D.md)|Describes the identifiers `__LINE__`, `__SOURCE_DIRECTORY__` and `__SOURCE_FILE__`, which are built-in values that enable you to access the source line number, directory and file name in your code.|

## See Also
[Visual F&#35;](Visual-FSharp.md)

[F&#35; Compiler &#40;fsc.exe&#41; Reference](FSharp-Compiler-%5Bfsc.exe%5D-Reference.md)