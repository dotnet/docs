---
title: What's new in F# 7 - F# Guide
description: Find information on the new features available in F# 7.
ms.date: 11/17/2023
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in F# 7

F# 7 introduces enhancements that make F# simpler and more performant while improving interop with new C# features. This article highlights the major changes in F# 7, developed in the [F# open source code repository](https://github.com/dotnet/fsharp).

F# 7 is available in .NET 7. You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Static abstract members in interfaces

[Static abstract members in interfaces](/dotnet/csharp/advanced-topics/interface-implementation/static-virtual-interface-members) is a new feature in C# 11 with [generic math](/dotnet/csharp/advanced-topics/interface-implementation/static-virtual-interface-members#generic-math) being one notable application.
F# 7 adds a corresponding feature described in the [F# RFC 1124](https://github.com/fsharp/fslang-design/blob/main/FSharp-7.0/FS-1124-interfaces-with-static-abstract-members.md) - interfaces with static abstract members.

F# 7 adds the ability to declare, call, and implement static abstract members in interfaces.

First, declare an interface with a static abstract member:

```fsharp
type IAddition<'T when 'T :> IAddition<'T>> =
    static abstract op_Addition: 'T * 'T -> 'T
```

> [!NOTE]
> The code above produces the `FS3535` warning: `Declaring "interfaces with static abstract methods" is an advanced feature. See https://aka.ms/fsharp-iwsams for guidance. You can disable this warning by using '#nowarn "3535"' or '--nowarn:3535'.`

Next, implement it:

```fsharp
type Number(value: int) =
    member _.Value = value
    interface IAddition<Number> with
        static member op_Addition(a, b) = Number(a.Value + b.Value)
```

This allows you to write generic functions that can be used with any type that implements the `IAddition` interface:

```fsharp
let add<'T when IAddition<'T>>(x: 'T) (y: 'T) = 'T.op_Addition(x, y)
```

Or in operator form:

```fsharp
let add<'T when IAddition<'T>>(x: 'T) (y: 'T) = x + y
```

This is a runtime feature and can be used with any static methods or properties. Here's another example:

```fsharp
type ISinOperator<'T when 'T :> ISinOperator<'T>> =
    static abstract Sin: 'T -> 'T

let sin<'T when ISinOperator<'T>>(x: 'T) = 'T.Sin(x)
```

This feature can also be used with BCL built-in types, such as `INumber<'T>`:

```fsharp
open System.Numerics

let sum<'T, 'TResult when INumber<'T> and INumber<'TResult>>(values: 'T seq) =
    let mutable result = 'TResult.Zero
    for value in values do
        result <- result + 'TResult.CreateChecked(value)
    result
```

These examples show how static abstract members in interfaces work. You're most likely to use this feature if you're a library author or you write specialized arithmetic functions.

## Making working with SRTPs easier

[Statically Resolved Type Parameters (SRTPs)](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/statically-resolved-type-parameters) are type parameters that are replaced with an actual type at compile time instead of at run time. F# 7 simplifies the syntax used for defining SRTPs.

As a quick refresher on what SRTPs are and how they're used, let's declare a function named `average` that takes an array of type `T` where type `T` has at least the following members:

* An addition operator (`(+)` or `op_Addition`)
* A `DivideByInt` static method that takes a `T` and an `int` and returns a `T`
* A static property named `Zero` that returns a `T`

Previously, you had to write:

```fsharp
let inline average< ^T
                   when ^T: (static member (+): ^T * ^T -> ^T)
                   and  ^T: (static member DivideByInt : ^T * int -> ^T)
                   and  ^T: (static member Zero : ^T)>
                   (xs: ^T array) =
    let mutable sum : ^T = (^T : (static member Zero: ^T) ())
    for x in xs do
        sum <- (^T : (static member op_Addition: ^T * ^T -> ^T) (sum, x))
    (^T : (static member DivideByInt: ^T * int -> ^T) (sum, xs.Length))
```

You no longer need to use a dedicated type parameter character (`^`). A single tick character (`'`) can be used instead. The compiler decides whether it's static or generic based on the context—whether the function is `inline` and if it has constraints.

F# 7 also adds a new simpler syntax for calling constraints, which is more readable and easier to write:

```fsharp
let inline average<'T
                when 'T: (static member (+): 'T * 'T -> 'T)
                and  'T: (static member DivideByInt : 'T * int -> 'T)
                and  'T: (static member Zero : 'T)>
                (xs: 'T array) =
    let mutable sum = 'T.Zero
    for x in xs do
        sum <- sum + x
    'T.DivideByInt(sum, xs.Length)
```

F# 7 adds the ability to declare constraints in groups:

```fsharp
type AverageOps<'T when 'T: (static member (+): 'T * 'T -> 'T)
                   and  'T: (static member DivideByInt : 'T * int -> 'T)
                   and  'T: (static member Zero : 'T)> = 'T
```

And a simpler syntax for self-constraints, which are constraints that refer to the type parameter itself:

```fsharp
let inline average<'T when AverageOps<'T>>(xs: 'T array) =
    let mutable sum = 'T.Zero
    for x in xs do
        sum <- sum + x
    'T.DivideByInt(sum, xs.Length)
```

Simplified call syntax also works with instance members:

```fsharp
type Length<'T when 'T: (member Length: int)> = 'T

let inline len<'T when Length<'T>>(x: 'T) =
    x.Length
```

These changes make working with SRTPs easier and more readable.

## Required properties checking

C# 11 introduced a new [required modifier for properties](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required). F# 7 supports consuming classes with required properties and enforcing the constraint.

Consider the following data type, defined in a C# library:

```csharp
public sealed class Person
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
}
```

When using this type from F# code, the compiler makes sure required properties are properly initialized:

```fsharp
let person = Person(Name = "John", Surname = "Doe")
```

If you try to omit any of the required properties, you get a compile-time diagnostic:

```fsharp
let person = Person(Name = "John")
// FS3545: The following required properties have to be initialized:
//     property Person.Surname: string with get, set
```

### Init scope and init-only properties

In F# 7, the rules for `init-only` properties are tightened so that they can only be initialized within the `init` scope. This is a new compile-time check and is a breaking change that only applies starting in F# 7.

Given the following C# data type:

```csharp
public sealed class Person
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Person Set() => this;
}
```

Previously, in F# 6, the following code would compile and mutate the property `Id` of the `Person`:

```fsharp
let person = Person(Id = 42, Name = "John", Surname = "Doe")
person.Id <- 123
person.set_Id(123)
person.Set(Id = 123)
```

In F# 7, this is a compile-time error:

```fsharp
// Error FS0810: Init-only property 'Id' cannot be set outside the initialization code.
// Error FS0810: Cannot call 'set_Id' - a setter for init-only property, please use object initialization instead.
// Error FS0810: Init-only property 'Id' cannot be set outside the initialization code.
```

## Reference assemblies support

Starting with F# 7, the compiler can generate and properly consume [reference assemblies](https://learn.microsoft.com/en-us/dotnet/standard/assembly/reference-assemblies).

You can generate reference assemblies by:

* Adding the `ProduceReferenceAssembly` MSBuild project property to your `.fsproj` file (`<ProduceReferenceAssembly>true</ProduceReferenceAssembly>`) or using MSBuild flags (`/p:ProduceReferenceAssembly=true`).
* Using the `--refout` or `--refonly` compiler options.

## Other changes

Other changes in F# 7 include:

* Added support for N-d arrays up to rank 32.
* Result module functions parity with Option.
* Fixes in resumable state machines codegen for the tasks builds.
* Better codegen for compiler-generated side-effect-free property getters.
* For better trimmability, a reflection-free codegen flag for the F# compiler (`--reflectionfree`):
  * Skips emitting `%A` ToString implementation for records, unions, and structs.
* Trimmability improvements for FSharp.Core—added `ILLink.LinkAttributes.xml` for `FSharp.Core`, which allows trimming compile-time resources and attributes for runtime-only FSharp.Core dependency.
* ARM64 platform-specific compiler and ARM64 target support in the F# compiler.
* Dependency manager `#r` caching support.
* Parallel type-checking and project-checking support (experimental, can be enabled via Visual Studio setting or by tooling authors).
* Miscellaneous bug fixes and improvements.

RFCs for F# 7 can be found in the [F# language design repository](https://github.com/fsharp/fslang-design/tree/main/FSharp-7.0).

## General improvements in .NET 7

.NET 7 brought many improvements that F# 7 benefits from, including [various ARM64 performance improvements](https://devblogs.microsoft.com/dotnet/arm64-performance-improvements-in-dotnet-7/) and [general performance improvements](https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/).
