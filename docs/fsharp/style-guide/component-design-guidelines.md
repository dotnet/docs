---
title: F# component design guidelines
description: Learn the guidelines for writing F# components intended for consumption by other callers.
ms.date: 05/14/2018
---
# F# component design guidelines

This document is a set of component design guidelines for F# programming, based on the F# Component Design Guidelines, v14, Microsoft Research, and [another version](https://fsharp.org/specs/component-design-guidelines/) originally curated and maintained by the F# Software Foundation.

This document assumes you are familiar with F# programming. Many thanks to the F# community for their contributions and helpful feedback on various versions of this guide.

## Overview

This document looks at some of the issues related to F# component design and coding. A component can mean any of the following:

* A layer in your F# project that has external consumers within that project.
* A library intended for consumption by F# code across assembly boundaries.
* A library intended for consumption by any .NET language across assembly boundaries.
* A library intended for distribution via a package repository, such as [NuGet](https://nuget.org).

Techniques described in this article follow the [Five principles of good F# code](index.md#five-principles-of-good-f-code), and thus utilize both functional and object programming as appropriate.

Regardless of the methodology, the component and library designer faces a number of practical and prosaic issues when trying to craft an API that is most easily usable by developers. Conscientious application of the [.NET Library Design Guidelines](../../standard/design-guidelines/index.md) will steer you towards creating a consistent set of APIs that are pleasant to consume.

## General guidelines

There are a few universal guidelines that apply to F# libraries, regardless of the intended audience for the library.

### Learn the .NET Library Design Guidelines

Regardless of the kind of F# coding you are doing, it is valuable to have a working knowledge of the [.NET Library Design Guidelines](../../standard/design-guidelines/index.md). Most other F# and .NET programmers will be familiar with these guidelines, and expect .NET code to conform to them.

The .NET Library Design Guidelines provide general guidance regarding naming, designing classes and interfaces, member design (properties, methods, events, etc.) and more, and are a useful first point of reference for a variety of design guidance.

### Add XML documentation comments to your code

XML documentation on public APIs ensure that users can get great Intellisense and Quickinfo when using these types and members, and enable building documentation files for the library. See the [XML Documentation](../language-reference/xml-documentation.md) about various xml tags that can be used for additional markup within xmldoc comments.

```fsharp
/// A class for representing (x,y) coordinates
type Point =

    /// Computes the distance between this point and another
    member DistanceTo : otherPoint:Point -> float
```

You can use either the short form XML comments (`/// comment`), or standard XML comments (`///<summary>comment</summary>`).

### Consider using explicit signature files (.fsi) for stable library and component APIs

Using explicit signatures files in an F# library provides a succinct summary of public API, which both helps to ensure that you know the full public surface of your library, as well as provides a clean separation between public documentation and internal implementation details. Note that signature files add friction to changing the public API, by requiring changes to be made in both the implementation and signature files. As a result, signature files should typically only be introduced when an API has become solidified and is no longer expected to change significantly.

### Always follow best practices for using strings in .NET

Follow [Best Practices for Using Strings in .NET](../../standard/base-types/best-practices-strings.md) guidance. In particular, always explicitly state *cultural intent* in the conversion and comparison of strings (where applicable).

## Guidelines for F#-facing libraries

This section presents recommendations for developing public F#-facing libraries; that is, libraries exposing public APIs that are intended to be consumed by F# developers. There are a variety of library-design recommendations applicable specifically to F#. In the absence of the specific recommendations that follow, the .NET Library Design Guidelines are the fallback guidance.

### Naming conventions

#### Use .NET naming and capitalization conventions

The following table follows .NET naming and capitalization conventions. There are small additions to also include F# constructs.

| Construct | Case | Part | Examples | Notes |
|-----------|------|------|----------|-------|
| Concrete types | PascalCase | Noun/ adjective | List, Double, Complex | Concrete types are structs, classes, enumerations, delegates, records, and unions. Though type names are traditionally lowercase in OCaml, F# has adopted the .NET naming scheme for types.
| DLLs           | PascalCase |                 | Fabrikam.Core.dll |  |
| Union tags     | PascalCase | Noun | Some, Add, Success | Do not use a prefix in public APIs. Optionally use a prefix when internal, such as `type Teams = TAlpha | TBeta | TDelta.` |
| Event          | PascalCase | Verb | ValueChanged / ValueChanging |  |
| Exceptions     | PascalCase |      | WebException | Name should end with “Exception”. |
| Field          | PascalCase | Noun | CurrentName  | |
| Interface types |  PascalCase | Noun/ adjective | IDisposable | Name should start with “I”. |
| Method |  PascalCase |  Verb | ToString | |
| Namespace | PascalCase | | Microsoft.FSharp.Core | Generally use `<Organization>.<Technology>[.<Subnamespace>]`, though drop the organization if the technology is independent of organization. |
| Parameters | camelCase | Noun |  typeName, transform, range | |
| let values (internal) | camelCase or PascalCase | Noun/ verb |  getValue, myTable |
| let values (external) | camelCase or PascalCase | Noun/verb  | List.map, Dates.Today | let-bound values are often public when following traditional functional design patterns. However, generally use PascalCase when the identifier can be used from other .NET languages. |
| Property  | PascalCase  | Noun/ adjective  | IsEndOfFile, BackColor  | Boolean properties generally use Is and Can and should be affirmative, as in IsEndOfFile, not IsNotEndOfFile.

#### Avoid abbreviations

The .NET guidelines discourage the use of abbreviations (for example, “use `OnButtonClick` rather than `OnBtnClick`”). Common abbreviations, such as `Async` for “Asynchronous”, are tolerated. This guideline is sometimes ignored for functional programming; for example, `List.iter` uses an abbreviation for “iterate”. For this reason, using abbreviations tends to be tolerated to a greater degree in F#-to-F# programming, but should still generally be avoided in public component design.

#### Avoid casing name collisions

The .NET guidelines say that casing alone cannot be used to disambiguate name collisions, since some client languages (for example, Visual Basic) are case-insensitive.

#### Use acronyms where appropriate

Acronyms such as XML are not abbreviations and are widely used in .NET libraries in uncapitalized form (Xml). Only well-known, widely recognized acronyms should be used.

#### Use PascalCase for generic parameter names

Do use PascalCase for generic parameter names in public APIs, including for F#-facing libraries. In particular, use names like `T`, `U`, `T1`, `T2` for arbitrary generic parameters, and when specific names make sense, then for F#-facing libraries use names like `Key`, `Value`, `Arg` (but not for example, `TKey`).

#### Use either PascalCase or camelCase for public functions and values in F# modules

camelCase is used for public functions that are designed to be used unqualified (for example, `invalidArg`), and for the “standard collection functions” (for example, List.map). In both these cases, the function names act much like keywords in the language.

### Object, Type, and Module design

#### Use namespaces or modules to contain your types and modules

Each F# file in a component should begin with either a namespace declaration or a module declaration.

```fsharp
namespace Fabrikam.BasicOperationsAndTypes

type ObjectType1() =
    ...

type ObjectType2() =
     ...

module CommonOperations =
    ...
```

or

```fsharp
module Fabrikam.BasicOperationsAndTypes

type ObjectType1() =
    ...

type ObjectType2() =
    ...

module CommonOperations =
    ...
```

The differences between using modules and namespaces to organize code at the top level are as follows:

* Namespaces can span multiple files
* Namespaces cannot contain F# functions unless they are within an inner module
* The code for any given module must be contained within a single file
* Top-level modules can contain F# functions without the need for an inner module

The choice between a top-level namespace or module affects the compiled form of the code, and thus will affect the view from other .NET languages should your API eventually be consumed outside of F# code.

#### Use methods and properties for operations intrinsic to object types

When working with objects, it is best to ensure that consumable functionality is implemented as methods and properties on that type.

```fsharp
type HardwareDevice() =

    member this.ID = ...

    member this.SupportedProtocols = ...

type HashTable<'Key,'Value>(comparer: IEqualityComparer<'Key>) =

    member this.Add(key, value) = ...

    member this.ContainsKey(key) = ...

    member this.ContainsValue(value) = ...
```

The bulk of functionality for a given member need not necessarily be implemented in that member, but the consumable piece of that functionality should be.

#### Use classes to encapsulate mutable state

In F#, this only needs to be done where that state is not already encapsulated by another language construct, such as a closure, sequence expression, or asynchronous computation.

```fsharp
type Counter() =
    // let-bound values are private in classes.
    let mutable count = 0

    member this.Next() =
        count <- count + 1
        count
```

#### Use interfaces to group related operations

Use interface types to represent a set of operations. This is preferred to other options, such as tuples of functions or records of functions.

```fsharp
type Serializer =
    abstract Serialize<'T> : preserveRefEq: bool -> value: 'T -> string
    abstract Deserialize<'T> : preserveRefEq: bool -> pickle: string -> 'T
```

In preference to:

```fsharp
type Serializer<'T> = {
    Serialize : bool -> 'T -> string
    Deserialize : bool -> string -> 'T
}
```

Interfaces are first-class concepts in .NET, which you can use to achieve what Functors would normally give you. Additionally, they can be used to encode existential types into your program, which records of functions cannot.

#### Use a module to group functions which act on collections

When you define a collection type, consider providing a standard set of operations like `CollectionType.map` and `CollectionType.iter`) for new collection types.

```fsharp
module CollectionType =
    let map f c =
        ...
    let iter f c =
        ...
```

If you include such a module, follow the standard naming conventions for functions found in FSharp.Core.

#### Use a module to group functions for common, canonical functions, especially in math and DSL libraries

For example, `Microsoft.FSharp.Core.Operators` is an automatically opened collection of top-level functions (like `abs` and `sin`) provided by FSharp.Core.dll.

Likewise, a statistics library might include a module with functions `erf` and `erfc`, where this module is designed to be explicitly or automatically opened.

#### Consider using RequireQualifiedAccess and carefully apply AutoOpen attributes

Adding the `[<RequireQualifiedAccess>]` attribute to a module indicates that the module may not be opened and that references to the elements of the module require explicit qualified access. For example, the `Microsoft.FSharp.Collections.List` module has this attribute.

This is useful when functions and values in the module have names that are likely to conflict with names in other modules. Requiring qualified access can greatly increase the long-term maintainability and evolvability of a library.

Adding the `[<AutoOpen>]` attribute to a module means the module will be opened when the containing namespace is opened. The `[<AutoOpen>]` attribute may also be applied to an assembly to indicate a module that is automatically opened when the assembly is referenced.

For example, a statistics library **MathsHeaven.Statistics** might contain a `module MathsHeaven.Statistics.Operators` containing functions `erf` and `erfc`. It is reasonable to mark this module as `[<AutoOpen>]`. This means `open MathsHeaven.Statistics` will also open this module and bring the names `erf` and `erfc` into scope. Another good use of `[<AutoOpen>]` is for modules containing extension methods.

Overuse of `[<AutoOpen>]` leads to polluted namespaces, and the attribute should be used with care. For specific libraries in specific domains, judicious use of `[<AutoOpen>]` can lead to better usability.

#### Consider defining operator members on classes where using well-known operators is appropriate

Sometimes classes are used to model mathematical constructs such as Vectors. When the domain being modeled has well-known operators, defining them as members intrinsic to the class is helpful.

```fsharp
type Vector(x:float) =

    member v.X = x

    static member (*) (vector:Vector, scalar:float) = Vector(vector.X * scalar)

    static member (+) (vector1:Vector, vector2:Vector) = Vector(vector1.X + vector2.X)

let v = Vector(5.0)

let u = v * 10.0
```

This guidance corresponds to general .NET guidance for these types. However, it can be additionally important in F# coding as this allows these types to be used in conjunction with F# functions and methods with member constraints, such as List.sumBy.

#### Consider using CompiledName to provide a .NET-friendly name for other .NET language consumers

Sometimes you may wish to name something in one style for F# consumers (such as a static member in lower case so that it appears as if it were a module-bound function), but have a different style for the name when it is compiled into an assembly. You can use the `[<CompiledName>]` attribute to provide a different style for non F# code consuming the assembly.

```fsharp
type Vector(x:float, y:float) =

    member v.X = x
    member v.Y = y

    [<CompiledName("Create")>]
    static member create x y = Vector (x, y)

let v = Vector.create 5.0 3.0
```

By using `[<CompiledName>]`, you can use .NET naming conventions for non F# consumers of the assembly.

#### Use method overloading for member functions, if doing so provides a simpler API

Method overloading is a powerful tool for simplifying an API that may need to perform similar functionality, but with different options or arguments.

```fsharp
type Logger() =

    member this.Log(message) =
        ...
    member this.Log(message, retryPolicy) =
        ...
```

In F#, it is more common to overload on number of arguments rather than types of arguments.

#### Hide the representations of record and union types if the design of these types is likely to evolve

Avoid revealing concrete representations of objects. For example, the concrete representation of <xref:System.DateTime> values is not revealed by the external, public API of the .NET library design. At run time, the Common Language Runtime knows the committed implementation that will be used throughout execution. However, compiled code doesn't itself pick up dependencies on the concrete representation.

#### Avoid the use of implementation inheritance for extensibility

In F#, implementation inheritance is rarely used. Furthermore, inheritance hierarchies are often complex and difficult to change when new requirements arrive. Inheritance implementation still exists in F# for compatibility and rare cases where it is the best solution to a problem, but alternative techniques should be sought in your F# programs when designing for polymorphism, such as interface implementation.

### Function and member signatures

#### Use tuples for return values when returning a small number of multiple unrelated values

Here is a good example of using a tuple in a return type:

```fsharp
val divrem : BigInteger -> BigInteger -> BigInteger * BigInteger
```

For return types containing many components, or where the components are related to a single identifiable entity, consider using a named type instead of a tuple.

#### Use `Async<T>` for async programming at F# API boundaries

If there is a corresponding synchronous operation named `Operation` that returns a `T`, then the async operation should be named `AsyncOperation` if it returns `Async<T>` or `OperationAsync` if it returns `Task<T>`. For commonly used .NET types that expose Begin/End methods, consider using `Async.FromBeginEnd` to write extension methods as a façade to provide the F# async programming model to those .NET APIs.

```fsharp
type SomeType =
    member this.Compute(x:int) : int =
        ...
    member this.AsyncCompute(x:int) : Async<int> =
        ...

type System.ServiceModel.Channels.IInputChannel with
    member this.AsyncReceive() =
        ...
```

### Exceptions

See [Error Management](conventions.md#error-management) to learn about appropriate use of exceptions, results, and options.

### Extension Members

#### Carefully apply F# extension members in F#-to-F# components

F# extension members should generally only be used for operations that are in the closure of intrinsic operations associated with a type in the majority of its modes of use. One common use is to provide APIs that are more idiomatic to F# for various .NET types:

```fsharp
type System.ServiceModel.Channels.IInputChannel with
    member this.AsyncReceive() =
        Async.FromBeginEnd(this.BeginReceive, this.EndReceive)

type System.Collections.Generic.IDictionary<'Key,'Value> with
    member this.TryGet key =
        let ok, v = this.TryGetValue key
        if ok then Some v else None
```

### Union Types

#### Use discriminated unions instead of class hierarchies for tree-structured data

Tree-like structures are recursively defined. This is awkward with inheritance, but elegant with Discriminated Unions.

```fsharp
type BST<'T> =
    | Empty
    | Node of 'T * BST<'T> * BST<'T>
```

Representing tree-like data with Discriminated Unions also allows you to benefit from exhaustiveness in pattern matching.

#### Use `[<RequireQualifiedAccess>]` on union types whose case names are not sufficiently unique

You may find yourself in a domain where the same name is the best name for different things, such as Discriminated Union cases. You can use `[<RequireQualifiedAccess>]` to disambiguate case names in order to avoid triggering confusing errors due to shadowing dependent on the ordering of `open` statements

#### Hide the representations of discriminated unions for binary compatible APIs if the design of these types is likely to evolve

Unions types rely on F# pattern-matching forms for a succinct programming model. As mentioned previously, you should avoid revealing concrete data representations if the design of these types is likely to evolve.

For example, the representation of a discriminated union can be hidden using a private or internal declaration, or by using a signature file.

```fsharp
type Union =
    private
    | CaseA of int
    | CaseB of string
```

If you reveal discriminated unions indiscriminately, you may find it hard to version your library without breaking user code. Instead, consider revealing one or more active patterns to permit pattern matching over values of your type.

Active patterns provide an alternate way to provide F# consumers with pattern matching while avoiding exposing F# Union Types directly.

### Inline Functions and Member Constraints

#### Define generic numeric algorithms using inline functions with implied member constraints and statically resolved generic types

Arithmetic member constraints and F# comparison constraints are a standard for F# programming. For example, consider the following code:

```fsharp
let inline highestCommonFactor a b =
    let rec loop a b =
        if a = LanguagePrimitives.GenericZero<_> then b
        elif a < b then loop a (b - a)
        else loop (a - b) b
    loop a b
```

The type of this function is as follows:

```fsharp
val inline highestCommonFactor : ^T -> ^T -> ^T
                when ^T : (static member Zero : ^T)
                and ^T : (static member ( - ) : ^T * ^T -> ^T)
                and ^T : equality
                and ^T : comparison
```

This is a suitable function for a public API in a mathematical library.

#### Avoid using member constraints to simulate type classes and duck typing

It is possible to simulate “duck typing” using F# member constraints. However, members that make use of this should not in general be used in F#-to-F# library designs. This is because library designs based on unfamiliar or non-standard implicit constraints tend to cause user code to become inflexible and tied to one particular framework pattern.

Additionally, there is a good chance that heavy use of member constraints in this manner can result in very long compile times.

### Operator Definitions

#### Avoid defining custom symbolic operators

Custom operators are essential in some situations and are highly useful notational devices within a large body of implementation code. For new users of a library, named functions are often easier to use. In addition, custom symbolic operators can be hard to document, and users find it more difficult to look up help on operators, due to existing limitations in IDE and search engines.

As a result, it is best to publish your functionality as named functions and members, and additionally expose operators for this functionality only if the notational benefits outweigh the documentation and cognitive cost of having them.

### Units of Measure

#### Carefully use units of measure for added type safety in F# code

Additional typing information for units of measure is erased when viewed by other .NET languages. Be aware that .NET components, tools, and reflection will see types-sans-units. For example, C# consumers will see `float` rather than `float<kg>`.

### Type Abbreviations

#### Carefully use type abbreviations to simplify F# code

.NET components, tools, and reflection will not see abbreviated names for types. Significant usage of type abbreviations can also make a domain appear more complex than it actually is, which could confuse consumers.

#### Avoid type abbreviations for public types whose members and properties should be intrinsically different to those available on the type being abbreviated

In this case, the type being abbreviated reveals too much about the representation of the actual type being defined. Instead, consider wrapping the abbreviation in a class type or a single-case discriminated union (or, when performance is essential, consider using a struct type to wrap the abbreviation).

For example, it is tempting to define a multi-map as a special case of an F# map, for example:

```fsharp
type MultiMap<'Key,'Value> = Map<'Key,'Value list>
```

However, the logical dot-notation operations on this type are not the same as the operations on a Map – for example, it is reasonable that the lookup operator map.[key] return the empty list if the key is not in the dictionary, rather than raising an exception.

## Guidelines for libraries for Use from other .NET Languages

When designing libraries for use from other .NET languages, it is important to adhere to the [.NET Library Design Guidelines](../../standard/design-guidelines/index.md). In this document, these libraries are labeled as vanilla .NET libraries, as opposed to F#-facing libraries that use F# constructs without restriction. Designing vanilla .NET libraries means providing familiar and idiomatic APIs consistent with the rest of the .NET Framework by minimizing the use of F#-specific constructs in the public API. The rules are explained in the following sections.

### Namespace and Type design (for libraries for use from other .NET Languages)

#### Apply the .NET naming conventions to the public API of your components

Pay special attention to the use of abbreviated names and the .NET capitalization guidelines.

```fsharp
type pCoord = ...
    member this.theta = ...

type PolarCoordinate = ...
    member this.Theta = ...
```

#### Use namespaces, types, and members as the primary organizational structure for your components

All files containing public functionality should begin with a `namespace` declaration, and the only public-facing entities in namespaces should be types. Do not use F# modules.

Use non-public modules to hold implementation code, utility types, and utility functions.

Static types should be preferred over modules, as they allow for future evolution of the API to use overloading and other .NET API design concepts that may not be used within F# modules.

For example, in place of the following public API:

```fsharp
module Fabrikam

module Utilities =
    let Name = "Bob"
    let Add2 x y = x + y
    let Add3 x y z = x + y + z
```

Consider instead:

```fsharp
namespace Fabrikam

[<AbstractClass; Sealed>]
type Utilities =
    static member Name = "Bob"
    static member Add(x,y) = x + y
    static member Add(x,y,z) = x + y + z
```

#### Use F# record types in vanilla .NET APIs if the design of the types won't evolve

F# record types compile to a simple .NET class. These are suitable for some simple, stable types in APIs. You should consider using the `[<NoEquality>]` and `[<NoComparison>]` attributes to suppress the automatic generation of interfaces. Also avoid using mutable record fields in vanilla .NET APIs as these exposes a public field. Always consider whether a class would provide a more flexible option for future evolution of the API.

For example, the following F# code exposes the public API to a C# consumer:

F#:

```fsharp
[<NoEquality; NoComparison>]
type MyRecord =
    { FirstThing : int
        SecondThing : string }
```

C#:

```csharp
public sealed class MyRecord
{
    public MyRecord(int firstThing, string secondThing);
    public int FirstThing { get; }
    public string SecondThing { get; }
}
```

#### Hide the representation of F# union types in vanilla .NET APIs

F# union types are not commonly used across component boundaries, even for F#-to-F# coding. They are an excellent implementation device when used internally within components and libraries.

When designing a vanilla .NET API, consider hiding the representation of a union type by using either a private declaration or a signature file.

```fsharp
type PropLogic =
    private
    | And of PropLogic * PropLogic
    | Not of PropLogic
    | True
```

You may also augment types that use a union representation internally with members to provide a desired .NET-facing API.

```fsharp
type PropLogic =
    private
    | And of PropLogic * PropLogic
    | Not of PropLogic
    | True

    /// A public member for use from C#
    member x.Evaluate =
        match x with
        | And(a,b) -> a.Evaluate && b.Evaluate
        | Not a -> not a.Evaluate
        | True -> true

    /// A public member for use from C#
    static member CreateAnd(a,b) = And(a,b)
```

#### Design GUI and other components using the design patterns of the framework

There are many different frameworks available within .NET, such as WinForms, WPF, and ASP.NET. Naming and design conventions for each should be used if you are designing components for use in these frameworks. For example, for WPF programming, adopt WPF design patterns for the classes you are designing. For models in user interface programming, use design patterns such as events and notification-based collections such as those found in <xref:System.Collections.ObjectModel>.

### Object and Member design (for libraries for use from other .NET Languages)

#### Use the CLIEvent attribute to expose .NET events

Construct a `DelegateEvent` with a specific .NET delegate type that takes an object and `EventArgs` (rather than an `Event`, which just uses the `FSharpHandler` type by default) so that the events are published in the familiar way to other .NET languages.

```fsharp
type MyBadType() =
    let myEv = new Event<int>()

    [<CLIEvent>]
    member this.MyEvent = myEv.Publish

type MyEventArgs(x:int) =
    inherit System.EventArgs()
    member this.X = x

    /// A type in a component designed for use from other .NET languages
type MyGoodType() =
    let myEv = new DelegateEvent<EventHandler<MyEventArgs>>()

    [<CLIEvent>]
    member this.MyEvent = myEv.Publish
```

#### Expose asynchronous operations as methods which return .NET tasks

Tasks are used in .NET to represent active asynchronous computations. Tasks are in general less compositional than F# `Async<T>` objects, since they represent “already executing” tasks and can’t be composed together in ways that perform parallel composition, or which hide the propagation of cancellation signals and other contextual parameters.

However, despite this, methods which return Tasks are the standard representation of asynchronous programming on .NET.

```fsharp
/// A type in a component designed for use from other .NET languages
type MyType() =

    let compute (x: int) : Async<int> = async { ... }

    member this.ComputeAsync(x) = compute x |> Async.StartAsTask
```

You will frequently also want to accept an explicit cancellation token:

```fsharp
/// A type in a component designed for use from other .NET languages
type MyType() =
    let compute(x:int) : Async<int> = async { ... }
    member this.ComputeAsTask(x, cancellationToken) = Async.StartAsTask(compute x, cancellationToken)
```

#### Use .NET delegate types instead of F# function types

Here “F# function types” mean “arrow” types like `int -> int`.

Instead of this:

```fsharp
member this.Transform(f:int->int) =
    ...
```

Do this:

```fsharp
member this.Transform(f:Func<int,int>) =
    ...
```

The F# function type appears as `class FSharpFunc<T,U>` to other .NET languages, and is less suitable for language features and tooling that understand delegate types. When authoring a higher-order method targeting .NET Framework 3.5 or higher, the `System.Func` and `System.Action` delegates are the right APIs to publish to enable .NET developers to consume these APIs in a low-friction manner. (When targeting .NET Framework 2.0, the system-defined delegate types are more limited; consider using predefined delegate types such as `System.Converter<T,U>` or defining a specific delegate type.)

On the flip side, .NET delegates are not natural for F#-facing libraries (see the next Section on F#-facing libraries). As a result, a common implementation strategy when developing higher-order methods for vanilla .NET libraries is to author all the implementation using F# function types, and then create the public API using delegates as a thin façade atop the actual F# implementation.

#### Use the TryGetValue pattern instead of returning F# option values, and prefer method overloading to taking F# option values as arguments

Common patterns of use for the F# option type in APIs are better implemented in vanilla .NET APIs using standard .NET design techniques. Instead of returning an F# option value, consider using the bool return type plus an out parameter as in the "TryGetValue" pattern. And instead of taking F# option values as parameters, consider using method overloading or optional arguments.

```fsharp
member this.ReturnOption() = Some 3

member this.ReturnBoolAndOut(outVal : byref<int>) =
    outVal <- 3
    true

member this.ParamOption(x : int, y : int option) =
    match y with
    | Some y2 -> x + y2
    | None -> x

member this.ParamOverload(x : int) = x

member this.ParamOverload(x : int, y : int) = x + y
```

#### Use the .NET collection interface types IEnumerable\<T\> and IDictionary\<Key,Value\> for parameters and return values

Avoid the use of concrete collection types such as .NET arrays `T[]`, F# types `list<T>`, `Map<Key,Value>` and `Set<T>`, and .NET concrete collection types such as `Dictionary<Key,Value>`. The .NET Library Design Guidelines have good advice regarding when to use various collection types like `IEnumerable<T>`. Some use of arrays (`T[]`) is acceptable in some circumstances, on performance grounds. Note especially that `seq<T>` is just the F# alias for `IEnumerable<T>`, and thus seq is often an appropriate type for a vanilla .NET API.

Instead of F# lists:

```fsharp
member this.PrintNames(names : string list) =
    ...
```

Use F# sequences:

```fsharp
member this.PrintNames(names : seq<string>) =
    ...
```

#### Use the unit type as the only input type of a method to define a zero-argument method, or as the only return type to define a void-returning method

Avoid other uses of the unit type. These are good:

```fsharp
✔ member this.NoArguments() = 3

✔ member this.ReturnVoid(x : int) = ()
```

This is bad:

```fsharp
member this.WrongUnit( x:unit, z:int) = ((), ())
```

#### Check for null values on vanilla .NET API boundaries

F# implementation code tends to have fewer null values, due to immutable design patterns and restrictions on use of null literals for F# types. Other .NET languages often use null as a value much more frequently. Because of this, F# code that is exposing a vanilla .NET API should check parameters for null at the API boundary, and prevent these values from flowing deeper into the F# implementation code. The `isNull` function or pattern matching on the `null` pattern can be used.

```fsharp
let checkNonNull argName (arg: obj) =
    match arg with
    | null -> nullArg argName
    | _ -> ()

let checkNonNull` argName (arg: obj) =
    if isNull arg then nullArg argName
    else ()
```

#### Avoid using tuples as return values

Instead, prefer returning a named type holding the aggregate data, or using out parameters to return multiple values. Although tuples and struct tuples exist in .NET (including C# language support for struct tuples), they will most often not provide the ideal and expected API for .NET developers.

#### Avoid the use of currying of parameters

Instead, use .NET calling conventions ``Method(arg1,arg2,…,argN)``.

```fsharp
member this.TupledArguments(str, num) = String.replicate num str
```

Tip: If you’re designing libraries for use from any .NET language, then there’s no substitute for actually doing some experimental C# and Visual Basic programming to ensure that your libraries "feel right" from these languages. You can also use tools such as .NET Reflector and the Visual Studio Object Browser to ensure that libraries and their documentation appear as expected to developers.

## Appendix

### End-to-end example of designing F# code for use by other .NET languages

Consider the following class:

```fsharp
open System

type Point1(angle,radius) =
    new() = Point1(angle=0.0, radius=0.0)
    member x.Angle = angle
    member x.Radius = radius
    member x.Stretch(l) = Point1(angle=x.Angle, radius=x.Radius * l)
    member x.Warp(f) = Point1(angle=f(x.Angle), radius=x.Radius)
    static member Circle(n) =
        [ for i in 1..n -> Point1(angle=2.0*Math.PI/float(n), radius=1.0) ]
```

The inferred F# type of this class is as follows:

```fsharp
type Point1 =
    new : unit -> Point1
    new : angle:double * radius:double -> Point1
    static member Circle : n:int -> Point1 list
    member Stretch : l:double -> Point1
    member Warp : f:(double -> double) -> Point1
    member Angle : double
    member Radius : double
```

Let’s take a look at how this F# type appears to a programmer using another .NET language. For example, the approximate C# “signature” is as follows:

```csharp
// C# signature for the unadjusted Point1 class
public class Point1
{
    public Point1();

    public Point1(double angle, double radius);

    public static Microsoft.FSharp.Collections.List<Point1> Circle(int count);

    public Point1 Stretch(double factor);

    public Point1 Warp(Microsoft.FSharp.Core.FastFunc<double,double> transform);

    public double Angle { get; }

    public double Radius { get; }
}
```

There are some important points to notice about how F# represents constructs here. For example:

* Metadata such as argument names has been preserved.

* F# methods that take two arguments become C# methods that take two arguments.

* Functions and lists become references to corresponding types in the F# library.

The following code shows how to adjust this code to take these things into account.

```fsharp
namespace SuperDuperFSharpLibrary.Types

type RadialPoint(angle:double, radius:double) =

    /// Return a point at the origin
    new() = RadialPoint(angle=0.0, radius=0.0)

    /// The angle to the point, from the x-axis
    member x.Angle = angle

    /// The distance to the point, from the origin
    member x.Radius = radius

    /// Return a new point, with radius multiplied by the given factor
    member x.Stretch(factor) =
        RadialPoint(angle=angle, radius=radius * factor)

    /// Return a new point, with angle transformed by the function
    member x.Warp(transform:Func<_,_>) =
        RadialPoint(angle=transform.Invoke angle, radius=radius)

    /// Return a sequence of points describing an approximate circle using
    /// the given count of points
    static member Circle(count) =
        seq { for i in 1..count ->
                RadialPoint(angle=2.0*Math.PI/float(count), radius=1.0) }
```

The inferred F# type of the code is as follows:

```fsharp
type RadialPoint =
    new : unit -> RadialPoint
    new : angle:double * radius:double -> RadialPoint
    static member Circle : count:int -> seq<RadialPoint>
    member Stretch : factor:double -> RadialPoint
    member Warp : transform:System.Func<double,double> -> RadialPoint
    member Angle : double
    member Radius : double
```

The C# signature is now as follows:

```csharp
public class RadialPoint
{
    public RadialPoint();

    public RadialPoint(double angle, double radius);

    public static System.Collections.Generic.IEnumerable<RadialPoint> Circle(int count);

    public RadialPoint Stretch(double factor);

    public RadialPoint Warp(System.Func<double,double> transform);

    public double Angle { get; }

    public double Radius { get; }
}
```

The fixes made to prepare this type for use as part of a vanilla .NET library are as follows:

* Adjusted several names: `Point1`, `n`, `l`, and `f` became `RadialPoint`, `count`, `factor`, and `transform`, respectively.

* Used a return type of `seq<RadialPoint>` instead of `RadialPoint list` by changing a list construction using `[ ... ]` to a sequence construction using `IEnumerable<RadialPoint>`.

* Used the .NET delegate type `System.Func` instead of an F# function type.

This makes it far nicer to consume in C# code.
