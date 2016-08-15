# Tour of F# #

The best way to learn about F# is to read and write F# code.  This tour of some of the features of the language will highlight some things and give you some code snippets that you can execute on your machine.  To learn about setting up a development environment, check out [Getting Started](tutorials/getting-started/index.md).

There are two primary concepts in F#: functions and types.  This tour will emphasize features of the language which fall into these two concepts.

## How to Run the Code Samples

>![NOTE]
Eventually, this documentation site will have the ability to run these code samples directly in your browser.

The quickest way to run these code samples is to use [F# Interactive](tutorials/fsharp-interactive/index.md).  Just copy/paste the code samples and run them there.  Alternatively you can set up a project to compile and run the code as a Console Application in [Visual Studio](tutorials/getting-started/getting-started-with-visual-studio.md) or [Visual Studio Code and Ionide](tutorials/getting-started/getting-started-with-vscode.md).

## Functions and Modules

The most fundamental pieces of any F# program are Functions organized into Modules.  [Functions](language-reference/functions/index.md) perform work on inputs to produce outputs, and they are organized under Modules, which are the primary way you group things in F#.  They are defined using the [`let` binding](language-reference/functions/let-bindings.md), which give the function a name and define its arguments.

[!code-fsharp[BasicFunctions]](../../samples/snippets/fsharp/tour.fs#25-51)

`let` bindings are also how you bind a value to a name, similar to a variable in other languages.  However, unlike language such as C#, these values are immutable by default.  The lines between values and functions are a bit blurred, and that's intentional.  More on that later.

## Integers, Booleans, and Strings

As a .NET language, F# supports the same underlying [primitive types](language-reference/primitive-types.md) that exist in .NET.

Here's some Integer values, generated in different ways:

[!code-fsharp[Integers]](../../samples/snippets/fsharp/tour.fs#L8-22)

Here's what Boolean values and performing basic conditional logic looks like:

[!code-fsharp[Bools]](../../samples/snippets/fsharp/tour.fs#L59-66)

And here's what basic [string](language-reference/strings.md) manipulation looks like:

[!code-fsharp[Strings]](../../samples/snippets/fsharp/tour.fs#L74-90)

## Tuples

[Tuples](language-reference/tuples.md) are a big deal in F#.  They are a grouping of unnamed, but ordered values, that can be treated as values themselves.  Think of them as values which are aggregated from other values.  They have many uses, such as conveniently returning multiple values from a function, or grouping values for some ad-hoc convenience.

[!code-fsharp[Tuples]](../../samples/snippets/fsharp/tour.fs#L98-112)

You can also use *struct tuples* with the `struct` keyword.  This tells the compiler that the tuple is allocated on the program Stack, rather than the program Heap.  This is helpful for some high-performance scenarios.

[!code-fsharp[Tuples]](../../samples/snippets/fsharp/tour.fs#L114-121)

Note that struct tuples and "regular" tuples are distinct types.  You cannot "fool" the compiler into thinking one is the other.  Instead, you must explicitly transfer the values from one tuple type to the other if you wish to work with both types of tuples.

## Arrays, Lists, and Sequences

Arrays, Lists, and Sequences are three primary collection types in the F# core library.

[Arrays](language-reference/arrays.md) are fixed-size, *mutable* collections of elements of the same type.  They are also all loaded into memory, thus they support fast random access of elements.

[!code-fsharp[Arrays]](../../samples/snippets/fsharp/tour.fs#L246-276)

[Lists](language-reference/lists.md) are ordered, immutable collections of elements of the same type.  Under the covers, they are singly-linked lists, which makes them lightweight and good for enumeration, but a poor choice for random access and concatenation if they're large.

[!code-fsharp[Lists]](../../samples/snippets/fsharp/tour.fs#L129-161)

[Sequences](language-reference/sequences.md) are a logical series of elements, all of the same type.  These are a more general type that Lists and Arrays, capable of being your "view" into any logical series of types.  They also stand out because they are *lazy*, which means that elements are computed only when they are needed.

[!code-fsharp[Sequences]](../../samples/snippets/fsharp/tour.fs#L289-315)

## Recursive Functions

Processing collections or sequences of elements is typically done with [recursion](link-to-wikipedia) in F#.  Although F# has support for loops and imperative programming, recursion is preferred because it is easier to guarantee correctness.

>![NOTE]
This same makes use of the pattern matching via the `match` expression.  This fundamental construct is covered later in this article.

[!code-fsharp[RecursiveFunctions]](../../samples/snippets/fsharp/tour.fs#L323-349)

F# also has full support for "tail call optimization", which for the uninitiated is a way to optimize recursive calls so that they are just as fast as a loop construct.  This is fairly unique, as most languages require implementing things like Stack Trampolines to avoid overflowing the program Stack with recursive calls.

## Record and Discriminated Union Types

Record and Union types are two fundamental data types used in F# code, and are generally the best way to represent data in an F# program.  Although this makes them similar to classes in other languages, one of their primary differences is that they have structural equality semantics.  This means that they are "natively" comparable and equality is straightforward - just check if one is equal to the other.

[Records](language-reference/records.md) are an aggregate of named values, with optional members (such as methods).  If you're familiar with C# or Java, then these should feel similar to POCOs or POJOs - just with less ceremony and structural equality.

[!code-fsharp[Records]](../../samples/snippets/fsharp/tour.fs#L357-373)

[Discriminated Unions](language-reference/discriminated-unions.md) are values which could be a number of named forms or cases.  Data stored in the type can be one of several distinct values.

[[!code-fsharp[Unions]](../../samples/snippets/fsharp/tour.fs#L381-432)

You can also use Unions as *single-case unions*, to help with domain modeling over primitive types.  Often times, strings and other primitive types are used to represent types of information that shouldn't be interchangeable.  However, using only the string representation can lead to that mistake quite easily!  Representing each type of information as a distinct single-case union can enforce correctness in this scenario.

[[!code-fsharp[Unions]](../../samples/snippets/fsharp/tour.fs#L434-437)

Additionally, Discriminated Unions also support recursive definitions, allowing you to easily represent trees and inherently recursive data.  For example, here's how you can represent a Binary Search Tree with `exists` and `insert` functions.

[[!code-fsharp[Unions]](../../samples/snippets/fsharp/tour.fs#L439-466)

Because Discriminated Unions allow you to represent the recursive structure of the tree in the data type, operating on it is very straightforward and nets you correctness guarantees with pattern matching.  See below for more.

## Pattern Matching

[Pattern Matching](language-reference/pattern-matching.md) is the F# languag feature which enables correctness for operating on F# types.  In the above samples, you probably noticed quite a bit of `match x with ...` syntax.  This construct allows the compiler, which can understand the "shape" of data types, to enforce you to account for all possible cases when using a data type through what is known as Exhausting Pattern Matching.  This is incredibly powerful for correctness, and can be cleverly used to "lift" what would normally be a runtime concern into compile-time.

[[!code-fsharp[PatternMatching]](../../samples/snippets/fsharp/tour.fs#L496-528)

You can also use the shorthand `function` construct for pattern matching, which is useful when you're writing functions which make use of [Partial Application](https://en.wikipedia.org/wiki/Partial_application):

[[!code-fsharp[PatternMatching]](../../samples/snippets/fsharp/tour.fs#L530-547)

Something you may have noticed is the use of the `_` pattern.  This is known as the "wildcard" pattern, which is basically a way of saying "I don't care what it is, since it doesn't matter to me".  Although convenient, you can accidentaly bypass Exhaustive Pattern Matching and no longer benefit from compile-time enforcements if you aren't careful.

[Active Patterns](language-reference/active-patterns.md) are another powerful construct to use with pattern matching.  They allow you to partition input data into custom forms, decomposing them at the pattern match call site.  They can also be parameterized, thus allowing to define the partition as a function.  Expanding the previous example to support Active Patterns looks something like this:

[[!code-fsharp[ActivePatterns]](../../samples/snippets/fsharp/tour.fs#L530-564)

>![NOTE]
The previous above example creates a `Result` type.  This has been added to the language with F# 4.1.  This document will be updated once F# 4.1 is shipped.

## Optional Types

One special case of Discriminated Union types is the Option Type, which is so useful that it's a part of the F# core library.

[The Option Type](language-reference/options.md) is a type which represents one of two cases: a value, or nothing at all.  It is used in any scenario where a value may or may not result from a particular operation.  This then forces you to account for both cases, making it a compile-time concern rather than a runtime concern.  These are often used in APIs where `null` is used to represent "nothing" instead, thus eliminating the need to worry about `NulReferenceException` in many circumstances.

[[!code-fsharp[Options]](../../samples/snippets/fsharp/tour.fs#L472-489)

## Units of Measure

One unique feature of F#'s type system is the ability to provide context for numeric literals through Units of Measure.

[Units of Measure](language-reference/units-of-measure.md) allow you to associate a numeric type to a unit, such as Meters, and have functions perform work on units rather than numeric literals.  This enables the compiler to verify that the types of numeric literals passed in make sense under a certain context, and eliminate runtime errors associated with that kind of work.

[[!code-fsharp[UnitsOfMeasure]](../../samples/snippets/fsharp/tour.fs#L570-585)

The F# Core library defines many SI unit types and unit conversions.  To learn more, check out the [Microsoft.FSharp.Data.UnitSystems.SI Namespace](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/microsoft.fsharp.data.unitsystems.si-namespace-%5bfsharp%5d).

## Classes and Interfaces

F# also has full support for .NET classes, [Interfaces](language-reference/interfaces), [Abstract Classes](language-reference/abstract-classes.md), [Inheritance](language-reference/inheritance.md), and so on.

[Classes](language-reference/classes.md) are types that represent .NET objects, which can have properties, methods, and events as its [Members](language-reference/members/index.md).

[[!code-fsharp[Classes]](../../samples/snippets/fsharp/tour.fs#L169-192)

Defining generic classes is also very straightforward.

[[!code-fsharp[Classes]](../../samples/snippets/fsharp/tour.fs#L200-221)

To implement an Interface, you can use `interface ... with` syntax.

[[!code-fsharp[Classes]](../../samples/snippets/fsharp/tour.fs#L229-238) 