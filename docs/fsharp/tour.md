---
title: Tour of F#
description: Examine some of the key features of the F# programming language in this tour with code samples.
keywords: visual f#, f#, functional programming, .NET, tour
author: cartermp
ms.author: phcart
ms.date: 02/28/2018
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 49775139-082e-442f-b5a2-dd402399b5d2
---

# Tour of F# #

The best way to learn about F# is to read and write F# code.  This article will act as a tour through some of the key features of the F# language and give you some code snippets that you can execute on your machine.  To learn about setting up a development environment, check out [Getting Started](tutorials/getting-started/index.md).

There are two primary concepts in F#: functions and types.  This tour will emphasize features of the language which fall into these two concepts.

## Functions and Modules

The most fundamental pieces of any F# program are ***functions*** organized into ***modules***.  [Functions](language-reference/functions/index.md) perform work on inputs to produce outputs, and they are organized under [Modules](language-reference/modules.md), which are the primary way you group things in F#.  They are defined using the [`let` binding](language-reference/functions/let-bindings.md), which give the function a name and define its arguments.

[!code-fsharp[BasicFunctions](../../samples/snippets/fsharp/tour.fs#L101-L133)]

`let` bindings are also how you bind a value to a name, similar to a variable in other languages.  `let` bindings are ***immutable*** by default, which means that once a value or function is bound to a name, it cannot be changed in-place.  This is in contrast to variables in other languages, which are ***mutable***, meaning their values can be changed at any point in time.  If you require a mutable binding, you can use `let mutable ...` syntax.

[!code-fsharp[Immutability](../../samples/snippets/fsharp/tour.fs#L75-L94)]

## Numbers, Booleans, and Strings

As a .NET language, F# supports the same underlying [primitive types](language-reference/primitive-types.md) that exist in .NET.

Here is how various numeric types are represented in F#:

[!code-fsharp[Numbers](../../samples/snippets/fsharp/tour.fs#L49-L68)]

Here's what Boolean values and performing basic conditional logic looks like:

[!code-fsharp[Bools](../../samples/snippets/fsharp/tour.fs#L142-L152)]

And here's what basic [string](language-reference/strings.md) manipulation looks like:

[!code-fsharp[Strings](../../samples/snippets/fsharp/tour.fs#L158-L180)]

## Tuples

[Tuples](language-reference/tuples.md) are a big deal in F#.  They are a grouping of unnamed, but ordered values, that can be treated as values themselves.  Think of them as values which are aggregated from other values.  They have many uses, such as conveniently returning multiple values from a function, or grouping values for some ad-hoc convenience.

[!code-fsharp[Tuples](../../samples/snippets/fsharp/tour.fs#L186-L203)]

As of F# 4.1, you can also create `struct` tuples.  These also interoperate fully with C#7/Visual Basic 15 tuples, which are also `struct` tuples:

[!code-fsharp[Tuples](../../samples/snippets/fsharp/tour.fs#L205-L218)]

It's important to note that because `struct` tuples are value types, they cannot be implicitly converted to reference tuples, or vice versa.  You must explicitly convert between a reference and struct tuple.

## Pipelines and Composition

Pipe operators (`|>`, `<|`, `||>`, `<||`, `|||>`, `<|||`) and composition operators (`>>` and `<<`) are used extensively when processing data in F#.  These operators are functions which allow you to establish "pipelines" of functions in a flexible manner.  The following example walks through how you could take advantage of these operators to build a simple functional pipeline.

[!code-fsharp[Pipelines](../../samples/snippets/fsharp/tour.fs#L227-L300)]

The above sample made use of many features of F#, including list processing functions, first-class functions, and [partial application](language-reference/functions/index.md#partial-application-of-arguments).  Although a deep understanding of each of those concepts can become somewhat advanced, it should be clear how easily functions can be used to process data when building pipelines.

## Lists, Arrays, and Sequences

Lists, Arrays, and Sequences are three primary collection types in the F# core library.

[Lists](language-reference/lists.md) are ordered, immutable collections of elements of the same type.  They are singly-linked lists, which means they are meant for enumeration, but a poor choice for random access and concatenation if they're large.  This in contrast to Lists in other popular languages, which typically do not use a singly-linked list to represent Lists.

[!code-fsharp[Lists](../../samples/snippets/fsharp/tour.fs#L309-L359)]

[Arrays](language-reference/arrays.md) are fixed-size, *mutable* collections of elements of the same type.  They support fast random access of elements, and are faster than F# lists because they are just contiguous blocks of memory.

[!code-fsharp[Arrays](../../samples/snippets/fsharp/tour.fs#L368-L407)]

[Sequences](language-reference/sequences.md) are a logical series of elements, all of the same type.  These are a more general type than Lists and Arrays, capable of being your "view" into any logical series of elements.  They also stand out because they can be ***lazy***, which means that elements can be computed only when they are needed.

[!code-fsharp[Sequences](../../samples/snippets/fsharp/tour.fs#L418-L452)]

## Recursive Functions

Processing collections or sequences of elements is typically done with [recursion](language-reference/functions/index.md#recursive-functions) in F#.  Although F# has support for loops and imperative programming, recursion is preferred because it is easier to guarantee correctness.

>[!NOTE]
The following example makes use of the pattern matching via the `match` expression.  This fundamental construct is covered later in this article.

[!code-fsharp[RecursiveFunctions](../../samples/snippets/fsharp/tour.fs#L461-L500)]

F# also has full support for Tail Call Optimization, which is a way to optimize recursive calls so that they are just as fast as a loop construct.

## Record and Discriminated Union Types

Record and Union types are two fundamental data types used in F# code, and are generally the best way to represent data in an F# program.  Although this makes them similar to classes in other languages, one of their primary differences is that they have structural equality semantics.  This means that they are "natively" comparable and equality is straightforward - just check if one is equal to the other.

[Records](language-reference/records.md) are an aggregate of named values, with optional members (such as methods).  If you're familiar with C# or Java, then these should feel similar to POCOs or POJOs - just with structural equality and less ceremony.

[!code-fsharp[Records](../../samples/snippets/fsharp/tour.fs#L507-L559)]

As of F# 4.1, you can also represent Records as `struct`s.  This is done with the `[<Struct>]` attribute:

[!code-fsharp[Records](../../samples/snippets/fsharp/tour.fs#L561-L568)]

[Discriminated Unions (DUs)](language-reference/discriminated-unions.md) are values which could be a number of named forms or cases.  Data stored in the type can be one of several distinct values.

[!code-fsharp[Unions](../../samples/snippets/fsharp/tour.fs#L575-L631)]

You can also use DUs as *Single-Case Discriminated Unions*, to help with domain modeling over primitive types.  Often times, strings and other primitive types are used to represent something, and are thus given a particular meaning.  However, using only the primitive representation of the data can result in mistakenly assigning an incorrect value!  Representing each type of information as a distinct single-case union can enforce correctness in this scenario.

[!code-fsharp[Unions](../../samples/snippets/fsharp/tour.fs#L633-L654)]

As the above sample demonstrates, to get the underlying value in a single-case Discriminated Union, you must explicitly unwrap it.

Additionally, DUs also support recursive definitions, allowing you to easily represent trees and inherently recursive data.  For example, here's how you can represent a Binary Search Tree with `exists` and `insert` functions.

[!code-fsharp[Unions](../../samples/snippets/fsharp/tour.fs#L656-L683)]

Because DUs allow you to represent the recursive structure of the tree in the data type, operating on this recursive structure is straightforward and guarantees correctness.  It is also supported in pattern matching, as shown below.

Additionally, you can represent DUs as `struct`s with the `[<Struct>]` attribute:

[!code-fsharp[Unions](../../samples/snippets/fsharp/tour.fs#L685-L696)]

However, there are two key things to keep in mind when doing so:

1. A struct DU cannot be recursively-defined.
2. A struct DU must have unique names for each of its cases.

Failure to follow the above will result in a compilation error.

## Pattern Matching

[Pattern Matching](language-reference/pattern-matching.md) is the F# language feature which enables correctness for operating on F# types.  In the above samples, you probably noticed quite a bit of `match x with ...` syntax.  This construct allows the compiler, which can understand the "shape" of data types, to force you to account for all possible cases when using a data type through what is known as Exhaustive Pattern Matching.  This is incredibly powerful for correctness, and can be cleverly used to "lift" what would normally be a runtime concern into compile-time.

[!code-fsharp[PatternMatching](../../samples/snippets/fsharp/tour.fs#L705-L739)]

You can also use the shorthand `function` construct for pattern matching, which is useful when you're writing functions which make use of [Partial Application](language-reference/functions/index.md#partial-application-of-arguments):

[!code-fsharp[PatternMatching](../../samples/snippets/fsharp/tour.fs#L741-L759)]

Something you may have noticed is the use of the `_` pattern.  This is known as the [Wildcard Pattern](language-reference/pattern-matching.md#wildcard-pattern), which is a way of saying "I don't care what something is".  Although convenient, you can accidentally bypass Exhaustive Pattern Matching and no longer benefit from compile-time enforcements if you aren't careful in using `_`.  It is best used when you don't care about certain pieces of a decomposed type when pattern matching, or the final clause when you have enumerated all meaningful cases in a pattern matching expression.

[Active Patterns](language-reference/active-patterns.md) are another powerful construct to use with pattern matching.  They allow you to partition input data into custom forms, decomposing them at the pattern match call site.  They can also be parameterized, thus allowing to define the partition as a function.  Expanding the previous example to support Active Patterns looks something like this:

[!code-fsharp[ActivePatterns](../../samples/snippets/fsharp/tour.fs#L761-L783)]

## Optional Types

One special case of Discriminated Union types is the Option Type, which is so useful that it's a part of the F# core library.

[The Option Type](language-reference/options.md) is a type which represents one of two cases: a value, or nothing at all.  It is used in any scenario where a value may or may not result from a particular operation.  This then forces you to account for both cases, making it a compile-time concern rather than a runtime concern.  These are often used in APIs where `null` is used to represent "nothing" instead, thus eliminating the need to worry about `NullReferenceException` in many circumstances.

[!code-fsharp[Options](../../samples/snippets/fsharp/tour.fs#L791-L811)]

## Units of Measure

One unique feature of F#'s type system is the ability to provide context for numeric literals through Units of Measure.

[Units of Measure](language-reference/units-of-measure.md) allow you to associate a numeric type to a unit, such as Meters, and have functions perform work on units rather than numeric literals.  This enables the compiler to verify that the types of numeric literals passed in make sense under a certain context, thus eliminating runtime errors associated with that kind of work.

[!code-fsharp[UnitsOfMeasure](../../samples/snippets/fsharp/tour.fs#L818-L839)]

The F# Core library defines many SI unit types and unit conversions.  To learn more, check out the [Microsoft.FSharp.Data.UnitSystems.SI Namespace](https://msdn.microsoft.com/visualfsharpdocs/conceptual/microsoft.fsharp.data.unitsystems.si-namespace-%5bfsharp%5d).

## Classes and Interfaces

F# also has full support for .NET classes, [Interfaces](language-reference/interfaces.md), [Abstract Classes](language-reference/abstract-classes.md), [Inheritance](language-reference/inheritance.md), and so on.

[Classes](language-reference/classes.md) are types that represent .NET objects, which can have properties, methods, and events as its [Members](language-reference/members/index.md).

[!code-fsharp[Classes](../../samples/snippets/fsharp/tour.fs#L848-L877)]

Defining generic classes is also very straightforward.

[!code-fsharp[Classes](../../samples/snippets/fsharp/tour.fs#L884-L905)]

To implement an Interface, you can use either `interface ... with` syntax or an [Object Expression](language-reference/object-expressions.md).

[!code-fsharp[Classes](../../samples/snippets/fsharp/tour.fs#L912-L931)]

## Which Types to Use

The presence of Classes, Records, Discriminated Unions, and Tuples leads to an important question: which should you use?  Like most everything in life, the answer depends on your circumstances.

Tuples are great for returning multiple values from a function, and using an ad-hoc aggregate of values as a value itself.

Records are a "step up" from Tuples, having named labels and support for optional members.  They are great for a low-ceremony representation of data in-transit through your program.  Because they have structural equality, they are easy to use with comparison.

Discriminated Unions have many uses, but the core benefit is to be able to utilize them in conjunction with Pattern Matching to account for all possible "shapes" that a data can have.  

Classes are great for a huge number of reasons, such as when you need to represent information and also tie that information to functionality.  As a rule of thumb, when you have functionality which is conceptually tied to some data, using Classes and the principles of Object-Oriented Programming is a big benefit.  Classes are also the preferred data type when interoperating with C# and Visual Basic, as these languages use classes for nearly everything.

## Next Steps

Now that you've seen some of the primary features of the language, you should be ready to write your first F# programs!  Check out [Getting Started](tutorials/getting-started/index.md) to learn how to set up your development environment and write some code.

The next steps for learning more can be whatever you like, but we recommend [Functions as First-Class Values](introduction-to-functional-programming/functions-as-first-class-values.md)<!--[Introduction to Functional Programming in F#](introduction-to-functional-programming/index.md)--> to get comfortable with core Functional Programming concepts.  These will be essential in building robust programs in F#.

Also, check out the [F# Language Reference](language-reference/index.md) to see a comprehensive collection of conceptual content on F#.
