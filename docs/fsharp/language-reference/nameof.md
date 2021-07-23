---
title: Nameof
description: Learn about the nameof operator, a metaprogramming feature that allows you to produce the name of any symbol in your source code.
ms.date: 11/12/2020
---

# Nameof

The `nameof` expression produces a string constant that matches the name in source for nearly any F# construct in source.

## Syntax

```fsharp
nameof symbol
nameof<'TGeneric>
```

## Remarks

`nameof` works by resolving the symbol passed to it and produces the name of that symbol as it is declared in your source code. This is useful in various scenarios, such as logging, and protects your logging against changes in source code.

```fsharp
let months =
    [
        "January"; "February"; "March"; "April";
        "May"; "June"; "July"; "August"; "September";
        "October"; "November"; "December"
    ]

let lookupMonth month =
    if (month > 12 || month < 1) then
        invalidArg (nameof month) ($"Value passed in was %d{month}.")

    months.[month-1]

printfn "%s" (lookupMonth 12)
printfn "%s" (lookupMonth 1)
printfn "%s" (lookupMonth 13)
```

The last line will throw an exception and `"month"` will be shown in the error message.

You can take a name of nearly every F# construct:

```fsharp
module M =
    let f x = nameof x

printfn $"{(M.f 12)]}"
printfn $"{(nameof M)}"
printfn $"{(nameof M.f)}"
```

`nameof` is not a first-class function and cannot be used as such. That means it cannot be partially applied and values cannot be piped into it via F# pipeline operators.

## Nameof on operators

Operators in F# can be used in two ways, as an operator text itself, or a symbol representing the compiled form. `nameof` on an operator will produce the name of the operator as it is declared in source. To get the compiled name, use the compiled name in source:

```fsharp
nameof(+) // "+"
nameof op_Addition // "op_Addition"
```

## Nameof on generics

You can also take a name of a generic type parameter, but the syntax is different:

```fsharp
let f<'a> () = nameof<'a>
f() // "a"
```

`nameof<'TGeneric>` will take the name of the symbol as defined in source, not the name of the type substituted at a call site.

The reason why the syntax is different is to align with other F# intrinsic operators like `typeof<>` and `typedefof<>`. This makes F# consistent with respect to operators that act on generic types and anything else in source.

## Nameof in pattern matching

The [`nameof` pattern](pattern-matching.md#nameof-pattern) lets you use `nameof` in a pattern match expression like so:

```fsharp
let f (str: string) =
    match str with
    | nameof str -> "It's 'str'!"
    | _ -> "It is not 'str'!"

f "str" // matches
f "asdf" // does not match
```

## Nameof with instance members

F# requries an instance in order to extract the name of an instance member with `nameof`.  If an instance is not easily available, then one can be obtained using `Unchecked.defaultof`.

```fsharp
type MyRecord = { MyField: int }
type MyClass() =
    member _.MyProperty = ()
    member _.MyMethod () = ()

nameof Unchecked.defaultof<MyRecord>.MyField   // MyField
nameof Unchecked.defaultof<MyClass>.MyProperty // MyProperty
nameof Unchecked.defaultof<MyClass>.MyMethod   // MyMethod
```
