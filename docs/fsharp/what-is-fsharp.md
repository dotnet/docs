---
title: What is F#
description: Learn about what the F# programming language is and what F# programming is like. Learn about rich types, functions, and how they fit together.
ms.date: 11/04/2021
---
# What is F\#

F# is an open-source, cross-platform, interoperable programming language for writing succinct, robust and performant code.
Your focus remains on your problem domain, rather than the details of programming.

F# programming is data-oriented, where code involves transforming data with functions.

```fsharp
open System // Gets access to functionality in System namespace.

// Defines a list of names
let names = [ "Peter"; "Julia"; "Xi" ]

// Defines a function that takes a name and produces a greeting.
let getGreeting name = $"Hello, {name}"

// Prints a greeting for each name!
names
|> List.map getGreeting
|> List.iter (fun greeting -> printfn $"{greeting}! Enjoy your F#")
```

F# has numerous features, including:

* Lightweight syntax
* Immutable by default
* Type inference and automatic generalization
* First-class functions
* Powerful data types
* Pattern matching
* Async programming

A full set of features are documented in the [F# language guide](./language-reference/index.md).

## Rich data types

Types such as [Records](./language-reference/records.md) and [Discriminated Unions](./language-reference/discriminated-unions.md)
let you represent your data.

```fsharp
// Group data with Records
type SuccessfulWithdrawal =
    { Amount: decimal
      Balance: decimal }

type FailedWithdrawal =
    { Amount: decimal
      Balance: decimal
      IsOverdraft: bool }

// Use discriminated unions to represent data of 1 or more forms
type WithdrawalResult =
    | Success of SuccessfulWithdrawal
    | InsufficientFunds of FailedWithdrawal
    | CardExpired of System.DateTime
    | UndisclosedFailure
```

F# records and discriminated unions are non-null, immutable, and comparable by default, making them very easy to use.

## Correctness with functions and pattern matching

F# functions are easy to define. When combined with [pattern matching](./language-reference/pattern-matching.md), they allow you to define behavior whose correctness is enforced by the compiler.

```fsharp
// Returns a WithdrawalResult
let withdrawMoney amount = // Implementation elided

let handleWithdrawal amount =
    let w = withdrawMoney amount

    // The F# compiler enforces accounting for each case!
    match w with
    | Success s -> printfn "Successfully withdrew %f{s.Amount}"
    | InsufficientFunds f -> printfn "Failed: balance is %f{f.Balance}"
    | CardExpired d -> printfn "Failed: card expired on {d}"
    | UndisclosedFailure -> printfn "Failed: unknown :("
```

F# functions are also first-class, meaning they can be passed as parameters and returned from other functions.

## Functions to define operations on objects

F# has full support for objects, which are useful when you need to blend data and functionality. F# members and functions can be defined to manipulate objects.

```fsharp
type Set<'T when 'T: comparison>(elements: seq<'T>) =
    member s.IsEmpty = // Implementation elided
    member s.Contains (value) =// Implementation elided
    member s.Add (value) = // Implementation elided
    // ...
    // Further Implementation elided
    // ...
    interface IEnumerable<‘T>
    interface IReadOnlyCollection<‘T>

module Set =
    let isEmpty (set: Set<'T>) = set.IsEmpty

    let contains element (set: Set<'T>) = set.Contains(element)

    let add value (set: Set<'T>) = set.Add(value)
```

In F#, you will often write code that treats objects as a type for functions to manipulate. Features such as [generic interfaces](./language-reference/interfaces.md), [object expressions](./language-reference/object-expressions.md), and judicious use of [members](./language-reference/members/index.md) are common in larger F# programs.

## Next steps

To learn more about a larger set of F# features, check out the [F# Tour](tour.md).
