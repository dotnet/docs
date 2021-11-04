---
title: Anonymous Records
description: Learn how to construct and use anonymous records, a language feature that helps with the manipulation of data.
ms.date: 11/04/2021
---
# Anonymous Records

Anonymous records are simple aggregates of named values that don't need to be declared before use. You can declare them as either structs or reference types. They're reference types by default.

## Syntax

The following examples demonstrate the anonymous record syntax. Items delimited as `[item]` are optional.

```fsharp
// Construct an anonymous record
let value-name = [struct] {| Label1: Type1; Label2: Type2; ...|}

// Use an anonymous record as a type parameter
let value-name = Type-Name<[struct] {| Label1: Type1; Label2: Type2; ...|}>

// Define a parameter with an anonymous record as input
let function-name (arg-name: [struct] {| Label1: Type1; Label2: Type2; ...|}) ...
```

## Basic usage

Anonymous records are best thought of as F# record types that don't need to be declared before instantiation.

For example, here how you can interact with a function that produces an anonymous record:

```fsharp
open System

let getCircleStats radius =
    let d = radius * 2.0
    let a = Math.PI * (radius ** 2.0)
    let c = 2.0 * Math.PI * radius

    {| Diameter = d; Area = a; Circumference = c |}

let r = 2.0
let stats = getCircleStats r
printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
    r stats.Diameter stats.Area stats.Circumference
```

The following example expands on the previous one with a `printCircleStats` function that takes an anonymous record as input:

```fsharp
open System

let getCircleStats radius =
    let d = radius * 2.0
    let a = Math.PI * (radius ** 2.0)
    let c = 2.0 * Math.PI * radius

    {| Diameter = d; Area = a; Circumference = c |}

let printCircleStats r (stats: {| Area: float; Circumference: float; Diameter: float |}) =
    printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
        r stats.Diameter stats.Area stats.Circumference

let r = 2.0
let stats = getCircleStats r
printCircleStats r stats
```

Calling `printCircleStats` with any anonymous record type that doesn't have the same "shape" as the input type will fail to compile:

```fsharp
printCircleStats r {| Diameter = 2.0; Area = 4.0; MyCircumference = 12.566371 |}
// Two anonymous record types have mismatched sets of field names
// '["Area"; "Circumference"; "Diameter"]' and '["Area"; "Diameter"; "MyCircumference"]'
```

## Struct anonymous records

Anonymous records can also be defined as struct with the optional `struct` keyword. The following example augments the previous one by producing and consuming a struct anonymous record:

```fsharp
open System

let getCircleStats radius =
    let d = radius * 2.0
    let a = Math.PI * (radius ** 2.0)
    let c = 2.0 * Math.PI * radius

    // Note that the keyword comes before the '{| |}' brace pair
    struct {| Area = a; Circumference = c; Diameter = d |}

// the 'struct' keyword also comes before the '{| |}' brace pair when declaring the parameter type
let printCircleStats r (stats: struct {| Area: float; Circumference: float; Diameter: float |}) =
    printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
        r stats.Diameter stats.Area stats.Circumference

let r = 2.0
let stats = getCircleStats r
printCircleStats r stats
```

### Structness inference

Struct anonymous records also allow for "structness inference" where you do not need to specify the `struct` keyword at the call site. In this example, you elide the `struct` keyword when calling `printCircleStats`:

```fsharp

let printCircleStats r (stats: struct {| Area: float; Circumference: float; Diameter: float |}) =
    printfn "Circle with radius: %f has diameter %f, area %f, and circumference %f"
        r stats.Diameter stats.Area stats.Circumference

printCircleStats r {| Area = 4.0; Circumference = 12.6; Diameter = 12.6 |}
```

The reverse pattern - specifying `struct` when the input type is not a struct anonymous record - will fail to compile.

## Embedding anonymous records within other types

It's useful to declare [discriminated unions](discriminated-unions.md) whose cases are records. But if the data in the records is the same type as the discriminated union, you must define all types as mutually recursive. Using anonymous records avoids this restriction. What follows is an example type and function that pattern matches over it:

```fsharp
type FullName = { FirstName: string; LastName: string }

// Note that using a named record for Manager and Executive would require mutually recursive definitions.
type Employee =
    | Engineer of FullName
    | Manager of {| Name: FullName; Reports: Employee list |}
    | Executive of {| Name: FullName; Reports: Employee list; Assistant: Employee |}

let getFirstName e =
    match e with
    | Engineer fullName -> fullName.FirstName
    | Manager m -> m.Name.FirstName
    | Executive ex -> ex.Name.FirstName
```

## Copy and update expressions

Anonymous records support construction with [copy and update expressions](copy-and-update-record-expressions.md). For example, here's how you can construct a new instance of an anonymous record that copies an existing one's data:

```fsharp
let data = {| X = 1; Y = 2 |}
let data' = {| data with Y = 3 |}
```

However, unlike named records, anonymous records allow you to construct entirely different forms with copy and update expressions. The follow example takes the same anonymous record from the previous example and expands it into a new anonymous record:

```fsharp
let data = {| X = 1; Y = 2 |}
let expandedData = {| data with Z = 3 |} // Gives {| X=1; Y=2; Z=3 |}
```

It is also possible to construct anonymous records from instances of named records:

```fsharp
type R = { X: int }
let data = { X = 1 }
let data' = {| data with Y = 2 |} // Gives {| X=1; Y=2 |}
```

You can also copy data to and from reference and struct anonymous records:

```fsharp
// Copy data from a reference record into a struct anonymous record
type R1 = { X: int }
let r1 = { X = 1 }

let data1 = struct {| r1 with Y = 1 |}

// Copy data from a struct record into a reference anonymous record
[<Struct>]
type R2 = { X: int }
let r2 = { X = 1 }

let data2 = {| r1 with Y = 1 |}

// Copy the reference anonymous record data into a struct anonymous record
let data3 = struct {| data2 with Z = r2.X |}
```

## Properties of anonymous records

Anonymous records have a number of characteristics that are essential to fully understanding how they can be used.

### Anonymous records are nominal

Anonymous records are [nominal types](https://en.wikipedia.org/wiki/Nominal_type_system). They are best thought as named [record](records.md) types (which are also nominal) that do not require an up-front declaration.

Consider the following example with two anonymous record declarations:

```fsharp
let x = {| X = 1 |}
let y = {| Y = 1 |}
```

The `x` and `y` values have different types and are not compatible with one another. They are not equatable and they are not comparable. To illustrate this, consider a named record equivalent:

```fsharp
type X = { X: int }
type Y = { Y: int }

let x = { X = 1 }
let y = { Y = 1 }
```

There isn't anything inherently different about anonymous records when compared with their named record equivalents when concerning type equivalency or comparison.

### Anonymous records use structural equality and comparison

Like record types, anonymous records are structurally equatable and comparable. This is only true if all constituent types support equality and comparison, like with record types. To support equality or comparison, two anonymous records must have the same "shape".

```fsharp
{| a = 1+1 |} = {| a = 2 |} // true
{| a = 1+1 |} > {| a = 1 |} // true

// error FS0001: Two anonymous record types have mismatched sets of field names '["a"]' and '["a"; "b"]'
{| a = 1 + 1 |} = {| a = 2;  b = 1|}
```

### Anonymous records are serializable

You can serialize anonymous records just as you can with named records. Here is an example using [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/):

```fsharp
open Newtonsoft.Json

let phillip' = {| name="Phillip"; age=28 |}
let philStr = JsonConvert.SerializeObject(phillip')

let phillip = JsonConvert.DeserializeObject<{|name: string; age: int|}>(philStr)
printfn $"Name: {phillip.name} Age: %d{phillip.age}"
```

Anonymous records are useful for sending lightweight data over a network without the need to define a domain for your serialized/deserialized types up front.

### Anonymous records interoperate with C# anonymous types

It is possible to use a .NET API that requires the use of [C# anonymous types](../../csharp/fundamentals/types/anonymous-types.md). C# anonymous types are trivial to interoperate with by using anonymous records. The following example shows how to use anonymous records to call a [LINQ](../../csharp/programming-guide/concepts/linq/index.md) overload that requires an anonymous type:

```fsharp
open System.Linq

let names = [ "Ana"; "Felipe"; "Emilia"]
let nameGrouping = names.Select(fun n -> {| Name = n; FirstLetter = n[0] |})
for ng in nameGrouping do
    printfn $"{ng.Name} has first letter {ng.FirstLetter}"
```

There are a multitude of other APIs used throughout .NET that require the use of passing in an anonymous type. Anonymous records are your tool for working with them.

## Limitations

Anonymous records have some restrictions in their usage. Some are inherent to their design, but others are amenable to change.

### Limitations with pattern matching

Anonymous records do not support pattern matching, unlike named records. There are three reasons:

1. A pattern would have to account for every field of an anonymous record, unlike named record types. This is because anonymous records do not support structural subtyping – they are nominal types.
2. Because of (1), there is no ability to have additional patterns in a pattern match expression, as each distinct pattern would imply a different anonymous record type.
3. Because of (2), any anonymous record pattern would be more verbose than the use of “dot” notation.

There is an open language suggestion to [allow pattern matching in limited contexts](https://github.com/fsharp/fslang-suggestions/issues/713).

### Limitations with mutability

It is not currently possible to define an anonymous record with `mutable` data. There is an [open language suggestion](https://github.com/fsharp/fslang-suggestions/issues/732) to allow mutable data.

### Limitations with struct anonymous records

It is not possible to declare struct anonymous records as `IsByRefLike` or `IsReadOnly`. There is an [open language suggestion](https://github.com/fsharp/fslang-suggestions/issues/712) to for `IsByRefLike` and `IsReadOnly` anonymous records.
