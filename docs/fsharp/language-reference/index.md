---
title: Language Guide
description: A reference guide to F# language features and tools.
ms.date: 11/04/2021
---
# F# Language Reference

This section is a reference for F#, a multi-paradigm programming language targeting .NET. F# supports functional, object-oriented, and imperative programming models.

## Organizing F# Code

The following table shows reference articles related to organizing your F# code.

|Title|Description|
|-----|-----------|
|[Namespaces](namespaces.md)|Learn about namespace support in F#. A namespace lets you organize code into areas of related functionality by enabling you to attach a name to a grouping of program elements.|
|[Modules](modules.md)|Learn about modules. An F# module is like a namespace and can also include values and functions. Grouping code in modules helps keep related code together and helps avoid name conflicts in your program.|
|[`open` Declarations](import-declarations-the-open-keyword.md)|Learn about how `open` works. An `open` declaration specifies a module, namespace, or type whose elements you can reference without using a fully qualified name.|
|[Signatures](signature-files.md)|Learn about signatures and signature files. A signature file contains information about the public signatures of a set of F# program elements, such as types, namespaces, and modules. It can be used to specify the accessibility of these program elements.|
|[Access Control](access-control.md)|Learn about access control in F#. Access control means declaring what clients are able to use certain program elements, such as types, methods, functions, and so on.|
|[XML Documentation](xml-documentation.md)|Learn about support for generating documentation files for XML doc comments, also known as triple slash comments. You can produce documentation from code comments in F# as in other .NET languages.|

## Literals and Strings

The following table shows reference articles that describe literals and strings in F#.

|Title|Description|
|-----|-----------|
|[Literals](literals.md)|Learn about the syntax for literal values in F# and how to specify type information for F# literals.|
|[Strings](strings.md)|Learn about strings in F#. The `string` type represents immutable text, as a sequence of Unicode characters. `string` is an alias for `System.String` in .NET.|
|[Interpolated strings](interpolated-strings.md)|Learn about interpolated strings, a special form of string that allows you to embed F# expressions directly inside them.|

## Values and Functions

The following table shows reference articles that describe language concepts related to values, `let`-bindings, and functions.

|Title|Description|
|-----|-----------|
|[Values](./values/index.md)|Learn about values, which are immutable quantities that have a specific type; values can be integral or floating point numbers, characters or text, lists, sequences, arrays, tuples, discriminated unions, records, class types, or function values.|
|[Functions](./functions/index.md)|Functions are the fundamental unit of program execution in any programming language. An F# function has a name, can have parameters and take arguments, and has a body. F# also supports functional programming constructs such as treating functions as values, using unnamed functions in expressions, composition of functions to form new functions, curried functions, and the implicit definition of functions by way of the partial application of function arguments.|
|[Function Expressions](./functions/lambda-expressions-the-fun-keyword.md)|Learn how to use the F# 'fun' keyword to define a lambda expression, which is an anonymous function.|

## Loops and Conditionals

The following table lists articles that describe F# loops and conditionals.

|Title|Description|
|-----|-----------|
|[Conditional Expressions: `if...then...else`](conditional-expressions-if-then-else.md)|Learn about the `if...then...else` expression, which runs different branches of code and also evaluates to a different value depending on the Boolean expression given.|
|[Loops: `for...in` Expression](loops-for-in-expression.md)|Learn about the `for...in` expression, a looping construct that is used to iterate over the matches of a pattern in an enumerable collection such as a range expression, sequence, list, array, or other construct that supports enumeration.|
|[Loops: `for...to` Expression](loops-for-to-expression.md)|Learn about the `for...to` expression, which is used to iterate in a loop over a range of values of a loop variable.|
|[Loops: `while...do` Expression](loops-while-do-expression.md)|Learn about the `while...do` expression, which is used to perform iterative execution (looping) while a specified test condition is true.|

## Pattern Matching

The following table shows reference articles that describe language concepts.

|Title|Description|
|-----|-----------|
|[Pattern Matching](pattern-matching.md)|Learn about patterns, which are rules for transforming input data and are used throughout F#. You can compare data with a pattern, decompose data into constituent parts, or extract information from data in various ways.|
|[Match Expressions](match-expressions.md)|Learn about the `match` expression, which provides branching control that is based on the comparison of an expression with a set of patterns.|
|[Active Patterns](active-patterns.md)|Learn about active patterns. Active patterns enable you to define named partitions that subdivide input data. You can use active patterns to decompose data in a customized manner for each partition.|

## Exception Handling

The following table shows reference articles that describe language concepts related to exception handling.

|Title|Description|
|-----|-----------|
|[Exception Handling](./exception-handling/index.md)|Contains information about exception handling support in F#.|
|[The `try...with` Expression](exception-handling/the-try-with-expression.md)|Learn about how to use the `try...with` expression for exception handling.|
|[The `try...finally` Expression](exception-handling/the-try-finally-expression.md)|Learn about how the F# `try...finally` expression enables you to execute clean-up code even if a block of code throws an exception.|
|[The `use` Keyword](resource-management-the-use-keyword.md)|Learn about the keywords `use` and `using`, which can control the initialization and release of resources.|
|[Assertions](assertions.md)|Learn about the `assert` expression, which is a debugging feature that you can use to test an expression. Upon failure in Debug mode, an assertion generates a system error dialog box.|

## Types and Type Inference

The following table shows reference articles that describe how types and type inference work in F#.

|Title|Description|
|-----|-----------|
|[Types](fsharp-types.md)|Learn about the types that are used in F# and how F# types are named and described.|
|[Basic Types](basic-types.md)|Learn about the fundamental types that are used in F#. It also provides the corresponding .NET types and the minimum and maximum values for each type.|
|[Unit Type](unit-type.md)|Learn about the `unit` type, which is a type that indicates the absence of a specific value; the `unit` type has only a single value, which acts as a placeholder when no other value exists or is needed.|
|[Type Abbreviations](type-abbreviations.md)|Learn about type abbreviations, which are alternate names for types.|
|[Type Inference](type-inference.md)|Learn about how the F# compiler infers the types of values, variables, parameters, and return values.|
|[Casting and Conversions](casting-and-conversions.md)|Learn about support for type conversions in F#.|
|[Generics](./generics/index.md)|Learn about generic constructs in F#.|
|[Automatic Generalization](./generics/automatic-generalization.md)|Learn about how F# automatically generalizes the arguments and types of functions so that they work with multiple types when possible.|
|[Constraints](casting-and-conversions.md)|Learn about constraints that apply to generic type parameters to specify the requirements for a type argument in a generic type or function.|
|[Flexible Types](flexible-types.md)|Learn about flexible types. A flexible type annotation is an indication that a parameter, variable, or value has a type that is compatible with type specified, where compatibility is determined by position in an object-oriented hierarchy of classes or interfaces.|
|[Units of Measure](units-of-measure.md)|Learn about units of measure. Floating point values in F# can have associated units of measure, which are typically used to indicate length, volume, mass, and so on.|
|[Byrefs](byrefs.md)|Learn about byref and byref-like types in F#, which are used for low-level programming.|

## Tuples, Lists, Collections, Options

The following table shows reference articles that describe types supported by F#.

|Title|Description|
|-----|-----------|
|[Tuples](tuples.md)|Learn about tuples, which are groupings of unnamed but ordered values of possibly different types.|
|[Collections](fsharp-collection-types.md)|An overview of the F# functional collection types, including types for arrays, lists, sequences (seq), maps, and sets.|
|[Lists](lists.md)|Learn about lists. A list in F# is an ordered, immutable series of elements all of the same type.|
|[Options](options.md)|Learn about the option type. An option in F# is used when a value may or may not exist. An option has an underlying type and may either hold a value of that type or it may not have a value.|
|[Arrays](arrays.md)|Learn about arrays. Arrays are fixed-size, zero-based, mutable sequences of consecutive data elements, all of the same type.|
|[Sequences](sequences.md)|Learn about sequences. A sequence is a logical series of elements all of one type. Individual sequence elements are only computed if necessary, so the representation may be smaller than a literal element count indicates.|
|[Sequence Expressions](sequences.md)|Learn about sequence expressions, which let you generate sequences of data on-demand.|
|[Reference Cells](reference-cells.md)|Learn about reference cells, which are storage locations that enable you to create mutable variables with reference semantics.|

## Records and Discriminated Unions

The following table shows reference articles that describe record and discriminated union type definitions supported by F#.

|Title|Description|
|-----|-----------|
|[Records](records.md)|Learn about records. Records represent simple aggregates of named values, optionally with members.|
|[Anonymous Records](anonymous-records.md)|Learn how to construct and use anonymous records, a language feature that helps with the manipulation of data.|
|[Discriminated Unions](discriminated-unions.md)|Learn about discriminated unions, which provide support for values that may be one of a variety of named cases, each with possibly different values and types.|
|[Structs](structs.md)|Learn about structs, which are compact object types that can be more efficient than a class for types that have a small amount of data and simple behavior.|
|[Enumerations](enumerations.md)|Enumerations are types that have a defined set of named values. You can use them in place of literals to make code more readable and maintainable.|

## Object Programming

The following table shows reference articles that describe F# object programming.

|Title|Description|
|-----|-----------|
|[Classes](classes.md)|Learn about classes, which are types that represent objects that can have properties, methods, and events.|
|[Interfaces](interfaces.md)|Learn about interfaces, which specify sets of related members that other classes implement.|
|[Abstract Classes](abstract-classes.md)|Learn about abstract classes, which are classes that leave some or all members unimplemented, so that implementations can be provided by derived classes.|
|[Type Extensions](type-extensions.md)|Learn about type extensions, which let you add new members to a previously defined object type.|
|[Delegates](delegates.md)|Learn about delegates, which represent a function call as an object.|
|[Inheritance](inheritance.md)|Learn about inheritance, which is used to model the "is-a" relationship, or subtyping, in object-oriented programming.|
|[Members](./members/index.md)|Learn about members of F# object types.|
|[Parameters and Arguments](parameters-and-arguments.md)|Learn about language support for defining parameters and passing arguments to functions, methods, and properties. It includes information about how to pass by reference.|
|[Operator Overloading](operator-overloading.md)|Learn about how to overload arithmetic operators in a class or record type, and at the global level.|
|[Object Expressions](object-expressions.md)|Learn about object expressions, which are expressions that create new instances of a dynamically created, anonymous object type that is based on an existing base type, interface, or set of interfaces.|

## Async, Tasks and Lazy

The following table lists topics that describe F# async, task and lazy expressions.

|Title|Description|
|-----|-----------|
|[Async Expressions](async-expressions.md)|Learn about async expressions, which let you write asynchronous code in a way that is very close to the way you would naturally write synchronous code.|
|[Task Expressions](task-expressions.md)|Learn about task expressions, which are an alternative way of writing asynchronous code used when interoperating with .NET code that consumes or produces .NET tasks.|
|[Lazy Expressions](lazy-expressions.md)|Learn about lazy expressions, which are computations that are not evaluated immediately, but are instead evaluated when the result is actually needed.|

## Computation expressions and Queries

The following table lists topics that describe F# computation expressions and queries.

|Title|Description|
|-----|-----------|
|[Computation Expressions](computation-expressions.md)|Learn about computation expressions in F#, which provide a convenient syntax for writing computations that can be sequenced and combined using control flow constructs and bindings. They can be used to manage data, control, and side effects in functional programs.|
|[Query Expressions](query-expressions.md)|Learn about query expressions, a language feature that implements LINQ for F# and enables you to write queries against a data source or enumerable collection.|

## Attributes, Reflection, Quotations and Plain Text Formatting

The following table lists articles that describe F# reflective features, including attributes, quotations, `nameof`, and plain text formatting.

|Title|Description|
|-----|-----------|
|[Attributes](attributes.md)|Learn how F# Attributes enable metadata to be applied to a programming construct.|
|[nameof](nameof.md)|Learn about the `nameof` operator, a metaprogramming feature that allows you to produce the name of any symbol in your source code.|
|[Caller Information](caller-information.md)|Learn about how to use Caller Info Argument Attributes to obtain caller information from a method.|
|[Source Line, File, and Path Identifiers](source-line-file-path-identifiers.md)|Learn about the identifiers `__LINE__`, `__SOURCE_DIRECTORY__`, and `__SOURCE_FILE__`, which are built-in values that enable you to access the source line number, directory, and file name in your code.|
|[Code Quotations](code-quotations.md)|Learn about code quotations, a language feature that enables you to generate and work with F# code expressions programmatically.|
|[Plain Text Formatting](plaintext-formatting.md)|Learn how to use sprintf and other plain text formatting in F# applications and scripts.|

## Type Providers

The following table lists articles that describe F# type providers.

|Title|Description|
|-----|-----------|
|[Type Providers](../tutorials/type-providers/index.md)|Learn about type providers and find links to walkthroughs on using the built-in type providers to access databases and web services.|
|[Create a Type Provider](../tutorials/type-providers/creating-a-type-provider.md)|Learn how to create your own F# type providers by examining several simple type providers that illustrate the basic concepts.|

## F# Core Library API reference

[F# Core Library (FSharp.Core) API reference](https://fsharp.github.io/fsharp-core-docs/) is the reference for all F# Core Library namespaces, modules, types, and functions.

## Reference Tables

The following table shows reference articles that provide tables of keywords, symbols, and literals that are used as tokens in F#.

|Title|Description|
|-----|-----------|
|[Keyword Reference](keyword-reference.md)|Contains links to information about all F# language keywords.|
|[Symbol and Operator Reference](./symbol-and-operator-reference/index.md)|Contains a table of symbols and operators that are used in F#.|

## Compiler-supported Constructs

The following table lists topics that describe special compiler-supported constructs.

|Topic|Description|
|-----|-----------|
|[Compiler Options](compiler-options.md)|Describes the command-line options for the F# compiler.|
|[Compiler Directives](compiler-directives.md)|Describes the processor directives and compiler directives supported by the F# compiler.|
