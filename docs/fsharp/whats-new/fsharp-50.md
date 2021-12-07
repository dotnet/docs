---
title: What's new in F# 5 - F# Guide
description: Get an overview of the new features available in F# 5.
ms.date: 11/04/2021
---
# What's new in F# 5

F# 5 adds several improvements to the F# language and F# Interactive. It is released with **.NET 5**.

You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Get started

F# 5 is available in all .NET Core distributions and Visual Studio tooling. For more information, see [Get started with F#](../get-started/index.md) to learn more.

## Package references in F# scripts

F# 5 brings support for package references in F# scripts with `#r "nuget:..."` syntax. For example, consider the following package reference:

```fsharp
#r "nuget: Newtonsoft.Json"

open Newtonsoft.Json

let o = {| X = 2; Y = "Hello" |}

printfn $"{JsonConvert.SerializeObject o}"
```

You can also supply an explicit version after the name of the package like this:

```fsharp
#r "nuget: Newtonsoft.Json,11.0.1"
```

Package references support packages with native dependencies, such as ML.NET.

Package references also support packages with special requirements about referencing dependent `.dll`s. For example, the [FParsec](https://www.nuget.org/packages/FParsec/) package used to require that users manually ensure that its dependent `FParsecCS.dll` was referenced first before `FParsec.dll` was referenced in F# Interactive. This is no longer needed, and you can reference the package as follows:

```fsharp
#r "nuget: FParsec"

open FParsec

let test p str =
    match run p str with
    | Success(result, _, _)   -> printfn $"Success: {result}"
    | Failure(errorMsg, _, _) -> printfn $"Failure: {errorMsg}"

test pfloat "1.234"
```

This feature implements [F# Tooling RFC FST-1027](https://github.com/fsharp/fslang-design/blob/main/tooling/FST-1027-fsi-references.md). For more information on package references, see the [F# Interactive](../tools/fsharp-interactive/index.md) tutorial.

## String interpolation

F# interpolated strings are fairly similar to C# or JavaScript interpolated strings, in that they let you write code in "holes" inside of a string literal. Here's a basic example:

```fsharp
let name = "Phillip"
let age = 29
printfn $"Name: {name}, Age: {age}"

printfn $"I think {3.0 + 0.14} is close to {System.Math.PI}!"
```

However, F# interpolated strings also allow for typed interpolations, just like the `sprintf` function, to enforce that an expression inside of an interpolated context conforms to a particular type. It uses the same format specifiers.

```fsharp
let name = "Phillip"
let age = 29

printfn $"Name: %s{name}, Age: %d{age}"

// Error: type mismatch
printfn $"Name: %s{age}, Age: %d{name}"
```

In the preceding typed interpolation example, the `%s` requires the interpolation to be of type `string`, whereas the `%d` requires the interpolation to be an `integer`.

Additionally, any arbitrary F# expression (or expressions) can be placed in side of an interpolation context. It is even possible to write a more complicated expression, like so:

```fsharp
let str =
    $"""The result of squaring each odd item in {[1..10]} is:
{
    let square x = x * x
    let isOdd x = x % 2 <> 0
    let oddSquares xs =
        xs
        |> List.filter isOdd
        |> List.map square
    oddSquares [1..10]
}
"""
```

Although we don't recommend doing this too much in practice.

This feature implements [F# RFC FS-1001](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1001-StringInterpolation.md).

## Support for nameof

F# 5 supports the `nameof` operator, which resolves the symbol it's being used for and produces its name in F# source. This is useful in various scenarios, such as logging, and protects your logging against changes in source code.

```fsharp
let months =
    [
        "January"; "February"; "March"; "April";
        "May"; "June"; "July"; "August"; "September";
        "October"; "November"; "December"
    ]

let lookupMonth month =
    if (month > 12 || month < 1) then
        invalidArg (nameof month) (sprintf "Value passed in was %d." month)

    months[month-1]

printfn $"{lookupMonth 12}"
printfn $"{lookupMonth 1}"
printfn $"{lookupMonth 13}"
```

The last line will throw an exception and "month" will be shown in the error message.

You can take a name of nearly every F# construct:

```fsharp
module M =
    let f x = nameof x

printfn $"{M.f 12}"
printfn $"{nameof M}"
printfn $"{nameof M.f}"
```

Three final additions are changes to how operators work: the addition of the `nameof<'type-parameter>` form for generic type parameters, and the ability to use `nameof` as a pattern in a pattern match expression.

Taking a name of an operator gives its source string. If you need the compiled form, use the compiled name of an operator:

```fsharp
nameof(+) // "+"
nameof op_Addition // "op_Addition"
```

Taking the name of a type parameter requires a slightly different syntax:

```fsharp
type C<'TType> =
    member _.TypeName = nameof<'TType>
```

This is similar to the `typeof<'T>` and `typedefof<'T>` operators.

F# 5 also adds support for a `nameof` pattern that can be used in `match` expressions:

```fsharp
[<Struct; IsByRefLike>]
type RecordedEvent = { EventType: string; Data: ReadOnlySpan<byte> }

type MyEvent =
    | AData of int
    | BData of string

let deserialize (e: RecordedEvent) : MyEvent =
    match e.EventType with
    | nameof AData -> AData (JsonSerializer.Deserialize<int> e.Data)
    | nameof BData -> BData (JsonSerializer.Deserialize<string> e.Data)
    | t -> failwithf "Invalid EventType: %s" t
```

The preceding code uses 'nameof' instead of the string literal in the match expression.

This feature implements [F# RFC FS-1003](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1003-nameof-operator.md).

## Open type declarations

F# 5 also adds support for open type declarations. An open type declaration is like opening a static class in C#, except with some different syntax and some slightly different behavior to fit F# semantics.

With open type declarations, you can `open` any type to expose static contents inside of it. Additionally, you can `open` F#-defined unions and records to expose their contents. For example, this can be useful if you have a union defined in a module and want to access its cases, but don't want to open the entire module.

```fsharp
open type System.Math

let x = Min(1.0, 2.0)

module M =
    type DU = A | B | C

    let someOtherFunction x = x + 1

// Open only the type inside the module
open type M.DU

printfn $"{A}"
```

Unlike C#, when you `open type` on two types that expose a member with the same name, the member from the last type being `open`ed shadows the other name. This is consistent with F# semantics around shadowing that exist already.

This feature implements [F# RFC FS-1068](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1068-open-type-declaration.md).

## Consistent slicing behavior for built-in data types

Behavior for slicing the built-in `FSharp.Core` data types (array, list, string, 2D array, 3D array, 4D array) used to not be consistent prior to F# 5. Some edge-case behavior threw an exception and some wouldn't. In F# 5, all built-in types now return empty slices for slices that are impossible to generate:

```fsharp
let l = [ 1..10 ]
let a = [| 1..10 |]
let s = "hello!"

// Before: would return empty list
// F# 5: same
let emptyList = l[-2..(-1)]

// Before: would throw exception
// F# 5: returns empty array
let emptyArray = a[-2..(-1)]

// Before: would throw exception
// F# 5: returns empty string
let emptyString = s[-2..(-1)]
```

This feature implements [F# RFC FS-1077](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1077-tolerant-slicing.md).

## Fixed-index slices for 3D and 4D arrays in FSharp.Core

F# 5 brings support for slicing with a fixed index in the built-in 3D and 4D array types.

To illustrate this, consider the following 3D array:

*z = 0*

| x\y   | 0 | 1 |
|-------|---|---|
| **0** | 0 | 1 |
| **1** | 2 | 3 |

*z = 1*

| x\y   | 0 | 1 |
|-------|---|---|
| **0** | 4 | 5 |
| **1** | 6 | 7 |

What if you wanted to extract the slice `[| 4; 5 |]` from the array? This is now very simple!

```fsharp
// First, create a 3D array to slice

let dim = 2
let m = Array3D.zeroCreate<int> dim dim dim

let mutable count = 0

for z in 0..dim-1 do
    for y in 0..dim-1 do
        for x in 0..dim-1 do
            m[x,y,z] <- count
            count <- count + 1

// Now let's get the [4;5] slice!
m[*, 0, 1]
```

This feature implements [F# RFC FS-1077b](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1077-3d-4d-fixed-index-slicing.md).

## F# quotations improvements

F# [code quotations](../language-reference/code-quotations.md) now have the ability to retain type constraint information. Consider the following example:

```fsharp
open FSharp.Linq.RuntimeHelpers

let eval q = LeafExpressionConverter.EvaluateQuotation q

let inline negate x = -x
// val inline negate: x: ^a ->  ^a when  ^a : (static member ( ~- ) :  ^a ->  ^a)

<@ negate 1.0 @>  |> eval
```

The constraint generated by the `inline` function is retained in the code quotation. The `negate` function's quoted form can now be evaluated.

This feature implements [F# RFC FS-1071](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1071-witness-passing-quotations.md).

## Applicative Computation Expressions

[Computation expressions (CEs)](../language-reference/computation-expressions.md) are used today to model "contextual computations", or in more functional programming-friendly terminology, monadic computations.

F# 5 introduces applicative CEs, which offer a different computational model. Applicative CEs allow for more efficient computations provided that every computation is independent, and their results are accumulated at the end. When computations are independent of one another, they are also trivially parallelizable, allowing CE authors to write more efficient libraries. This benefit comes at a restriction, though: computations that depend on previously computed values are not allowed.

The follow example shows a basic applicative CE for the `Result` type.

```fsharp
// First, define a 'zip' function
module Result =
    let zip x1 x2 =
        match x1,x2 with
        | Ok x1res, Ok x2res -> Ok (x1res, x2res)
        | Error e, _ -> Error e
        | _, Error e -> Error e

// Next, define a builder with 'MergeSources' and 'BindReturn'
type ResultBuilder() =
    member _.MergeSources(t1: Result<'T,'U>, t2: Result<'T1,'U>) = Result.zip t1 t2
    member _.BindReturn(x: Result<'T,'U>, f) = Result.map f x

let result = ResultBuilder()

let run r1 r2 r3 =
    // And here is our applicative!
    let res1: Result<int, string> =
        result {
            let! a = r1
            and! b = r2
            and! c = r3
            return a + b - c
        }

    match res1 with
    | Ok x -> printfn $"{nameof res1} is: %d{x}"
    | Error e -> printfn $"{nameof res1} is: {e}"

let printApplicatives () =
    let r1 = Ok 2
    let r2 = Ok 3 // Error "fail!"
    let r3 = Ok 4

    run r1 r2 r3
    run r1 (Error "failure!") r3
```

If you're a library author who exposes CEs in their library today, there are some additional considerations you'll need to be aware of.

This feature implements [F# RFC FS-1063](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1063-support-letbang-andbang-for-applicative-functors.md).

## Interfaces can be implemented at different generic instantiations

You can now implement the same interface at different generic instantiations:

```fsharp
type IA<'T> =
    abstract member Get : unit -> 'T

type MyClass() =
    interface IA<int> with
        member x.Get() = 1
    interface IA<string> with
        member x.Get() = "hello"

let mc = MyClass()
let iaInt = mc :> IA<int>
let iaString = mc :> IA<string>

iaInt.Get() // 1
iaString.Get() // "hello"
```

This feature implements [F# RFC FS-1031](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1031-Allow%20implementing%20the%20same%20interface%20at%20different%20generic%20instantiations%20in%20the%20same%20type.md).

## Default interface member consumption

F# 5 lets you consume [interfaces with default implementations](../../csharp/whats-new/tutorials/default-interface-methods-versions.md).

Consider an interface defined in C# like this:

```csharp
using System;

namespace CSharp
{
    public interface MyDim
    {
        public int Z => 0;
    }
}
```

You can consume it in F# through any of the standard means of implementing an interface:

```fsharp
open CSharp

// You can implement the interface via a class
type MyType() =
    member _.M() = ()

    interface MyDim

let md = MyType() :> MyDim
printfn $"DIM from C#: %d{md.Z}"

// You can also implement it via an object expression
let md' = { new MyDim }
printfn $"DIM from C# but via Object Expression: %d{md'.Z}"
```

This lets you safely take advantage of C# code and .NET components written in modern C# when they expect users to be able to consume a default implementation.

This feature implements [F# RFC FS-1074](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1074-default-interface-member-consumption.md).

## Simplified interop with nullable value types

[Nullable (value) types](/dotnet/api/system.nullable-1) (called Nullable Types historically) have long been supported by F#, but interacting with them has traditionally been somewhat of a pain since you'd have to construct a `Nullable` or `Nullable<SomeType>` wrapper every time you wanted to pass a value. Now the compiler will implicitly convert a value type into a `Nullable<ThatValueType>` if the target type matches. The following code is now possible:

```fsharp
#r "nuget: Microsoft.Data.Analysis"

open Microsoft.Data.Analysis

let dateTimes = PrimitiveDataFrameColumn<DateTime>("DateTimes")

// The following line used to fail to compile
dateTimes.Append(DateTime.Parse("2019/01/01"))

// The previous line is now equivalent to this line
dateTimes.Append(Nullable<DateTime>(DateTime.Parse("2019/01/01")))
```

This feature implements [F# RFC FS-1075](https://github.com/fsharp/fslang-design/blob/main/FSharp-5.0/FS-1075-nullable-interop.md).

## Preview: reverse indexes

F# 5 also introduces a preview for allowing reverse indexes. The syntax is `^idx`. Here's how you can an element 1 value from the end of a list:

```fsharp
let xs = [1..10]

// Get element 1 from the end:
xs[^1]

// From the end slices

let lastTwoOldStyle = xs[(xs.Length-2)..]

let lastTwoNewStyle = xs[^1..]

lastTwoOldStyle = lastTwoNewStyle // true
```

You can also define reverse indexes for your own types. To do so, you'll need to implement the following method:

```fsharp
GetReverseIndex: dimension: int -> offset: int
```

Here's an example for the `Span<'T>` type:

```fsharp
open System

type Span<'T> with
    member sp.GetSlice(startIdx, endIdx) =
        let s = defaultArg startIdx 0
        let e = defaultArg endIdx sp.Length
        sp.Slice(s, e - s)

    member sp.GetReverseIndex(_, offset: int) =
        sp.Length - offset

let printSpan (sp: Span<int>) =
    let arr = sp.ToArray()
    printfn $"{arr}"

let run () =
    let sp = [| 1; 2; 3; 4; 5 |].AsSpan()

    // Pre-# 5.0 slicing on a Span<'T>
    printSpan sp[0..] // [|1; 2; 3; 4; 5|]
    printSpan sp[..3] // [|1; 2; 3|]
    printSpan sp[1..3] // |2; 3|]

    // Same slices, but only using from-the-end index
    printSpan sp[..^0] // [|1; 2; 3; 4; 5|]
    printSpan sp[..^2] // [|1; 2; 3|]
    printSpan sp[^4..^2] // [|2; 3|]

run() // Prints the same thing twice
```

This feature implements [F# RFC FS-1076](https://github.com/fsharp/fslang-design/blob/main/preview/FS-1076-from-the-end-slicing.md).

## Preview: overloads of custom keywords in computation expressions

Computation expressions are a powerful feature for library and framework authors. They allow you to greatly improve the expressiveness of your components by letting you define well-known members and form a DSL for the domain you're working in.

F# 5 adds preview support for overloading custom operations in Computation Expressions. It allows the following code to be written and consumed:

```fsharp
open System

type InputKind =
    | Text of placeholder:string option
    | Password of placeholder: string option

type InputOptions =
  { Label: string option
    Kind : InputKind
    Validators : (string -> bool) array }

type InputBuilder() =
    member t.Yield(_) =
      { Label = None
        Kind = Text None
        Validators = [||] }

    [<CustomOperation("text")>]
    member this.Text(io, ?placeholder) =
        { io with Kind = Text placeholder }

    [<CustomOperation("password")>]
    member this.Password(io, ?placeholder) =
        { io with Kind = Password placeholder }

    [<CustomOperation("label")>]
    member this.Label(io, label) =
        { io with Label = Some label }

    [<CustomOperation("with_validators")>]
    member this.Validators(io, [<ParamArray>] validators) =
        { io with Validators = validators }

let input = InputBuilder()

let name =
    input {
    label "Name"
    text
    with_validators
        (String.IsNullOrWhiteSpace >> not)
    }

let email =
    input {
    label "Email"
    text "Your email"
    with_validators
        (String.IsNullOrWhiteSpace >> not)
        (fun s -> s.Contains "@")
    }

let password =
    input {
    label "Password"
    password "Must contains at least 6 characters, one number and one uppercase"
    with_validators
        (String.exists Char.IsUpper)
        (String.exists Char.IsDigit)
        (fun s -> s.Length >= 6)
    }
```

Prior to this change, you could write the `InputBuilder` type as it is, but you couldn't use it the way it's used in the example. Since overloads, optional parameters, and now `System.ParamArray` types are allowed, everything just works as you'd expect it to.

This feature implements [F# RFC FS-1056](https://github.com/fsharp/fslang-design/blob/main/preview/FS-1056-allow-custom-operation-overloads.md).
