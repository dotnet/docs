---
title: What's new in F# 7 - F# Guide
description: Find information on the new features available in F# 7.
ms.date: 11/17/2023
ms.topic: whats-new
ai-usage: ai-assisted
---
# What's new in F# 7

F# 7 introduces several enhancements that improve interoperability with .NET, simplify common programming patterns, and enhance developer productivity. This article highlights the major changes in F# 7, developed in the [F# open source code repository](https://github.com/dotnet/fsharp).

F# 7 is available in .NET 7. You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Static abstract members in interfaces

F# 7 adds support for static abstract members in interfaces, aligning with the feature introduced in C# 11 and .NET 7. This feature enables you to define interfaces that require implementing types to provide static members, which is particularly useful for generic math scenarios and other generic programming patterns.

You can define an interface with static abstract members using the `static abstract` keywords:

```fsharp
type IAddition<'T when 'T :> IAddition<'T>> =
    static abstract member (+) : 'T * 'T -> 'T
    static abstract member Zero : 'T
```

Types can implement these interfaces by providing the required static members:

```fsharp
type Number(value: int) =
    member _.Value = value
    
    interface IAddition<Number> with
        static member (+) (x: Number, y: Number) = 
            Number(x.Value + y.Value)
        static member Zero = Number(0)
```

This feature enables you to write generic algorithms that work across different types:

```fsharp
let inline addAll (items: 'T list) =
    items |> List.fold (+) 'T.Zero
```

For more information, see [Interfaces](../language-reference/interfaces.md).

## Required members

F# 7 introduces support for required members, allowing you to mark properties and fields that must be initialized when creating an instance. This feature improves interoperability with C# 11's required members feature.

While F# has always encouraged initialization through primary constructors and immutable record types, this feature enables better interaction with .NET libraries that use required members:

```fsharp
[<Class>]
type Person() =
    [<Required>]
    member val FirstName = "" with get, set
    
    [<Required>]
    member val LastName = "" with get, set
    
    member val MiddleName = "" with get, set
```

This improves the ability to consume and create types that are designed for use across both F# and C# codebases.

## Simplified SRTP syntax

Statically Resolved Type Parameters (SRTP) constraints have been simplified in F# 7. Previously, when using member constraints, you had to repeat the constraint even when calling simple members. Now you can use more concise syntax.

Before F# 7:

```fsharp
let inline add (x: ^T) (y: ^T) : ^T 
    when ^T : (static member (+) : ^T * ^T -> ^T) =
    ((^T) : (static member (+) : ^T * ^T -> ^T) (x, y))
```

Starting with F# 7, you can use the simpler syntax:

```fsharp
let inline add (x: ^T) (y: ^T) : ^T 
    when ^T : (static member (+) : ^T * ^T -> ^T) =
    x + y
```

Additionally, you can now use `'a.Zero()` instead of having to repeat the constraint:

```fsharp
let inline sum (values: ^T list) : ^T
    when ^T : (static member (+) : ^T * ^T -> ^T)
    and ^T : (static member Zero : ^T) =
    List.fold (+) ^T.Zero values
```

This simplification makes SRTP constraints more approachable and reduces boilerplate code.

For more information, see [Statically Resolved Type Parameters](../language-reference/generics/statically-resolved-type-parameters.md).

## Nested record updates with copy-and-update expressions

F# 7 enhances copy-and-update expressions to support updating nested record fields directly. This feature allows for more concise syntax when working with deeply nested records.

Before F# 7, updating a nested field required multiple `with` expressions:

```fsharp
type SteeringWheel = { Type: string }
type CarInterior = { Steering: SteeringWheel; Seats: int }
type Car = { Interior: CarInterior; ExteriorColor: string option }

let updateCar car =
    { car with 
        Interior = { car.Interior with
                       Steering = { car.Interior.Steering with Type = "sport" }
                       Seats = 4 } }
```

Starting with F# 7, you can use dot notation to reach nested fields and update them directly:

```fsharp
let updateCar car =
    { car with 
        Interior.Steering.Type = "sport"
        Interior.Seats = 4 }
```

This syntax eliminates the need for multiple nested `with` expressions while still allowing multiple fields at different levels of nesting to be updated in the same expression. The feature also works with anonymous records:

```fsharp
let updatedRecord =
    {| car with
        Interior.Seats = 4
        Price = 35000 |}
```

For more information, see [Copy and Update Record Expressions](../language-reference/copy-and-update-record-expressions.md).

## Performance improvements

F# 7 includes several performance improvements:

- **Parallel type checking**: The compiler now uses graph-based type checking, enabling parallel type checking of files using a dependency graph. This significantly speeds up compilation for large projects.
- **Reduced memory consumption**: Various optimizations reduce memory usage during compilation and runtime.
- **Better cancellation handling**: Improved handling of canceled user actions provides better responsiveness in development environments.

## Tooling improvements

F# 7 brings significant improvements to the development experience in Visual Studio and other editors:

- **Enhanced code fixes**: Over 30 new code fixes for common development issues help streamline the coding process and reduce errors.
- **Improved IntelliSense**: Better type inference information and more accurate completions make it easier to discover and use APIs.
- **Performance improvements**: Faster response times for editor features like code completion, navigation, and refactoring.

These tooling enhancements lower the barrier of entry for new F# developers and improve productivity for experienced developers.

## See also

- [F# Language Reference](../language-reference/index.md)
- [What's new in F# 8](fsharp-8.md)
- [What's new in .NET 7](../../core/whats-new/dotnet-7.md)
