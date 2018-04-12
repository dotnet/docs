# F# coding conventions

The following conventions are formulated from experience working with large F# codebases. The [Five principles of good F# code](index.md#five-principles-of-good-f-code) are the foundation of each recommendation. They are related to the [F# component design guidelines](component-design-guidelines.md), but are generally applicable for any F# code, not just components such as libraries.

## Using namespaces and modules for code organization

F# features two primarily ways to organize code: modules and namespaces. They are very similar, but do have the following differences:

* Namespaces are compiled as .NET namespaces. Modules are compared as static classes.
* Namespaces are always top-level. Modules can be top-level and nested within other modules.
* Namespaces can span mutiple files. Modules cannot.
* Modules can be decorated with `[<RequireQualifiedAccess>]` and `[<AutoOpen>]`.

The following guidelines will help you use these to organize your code.

### Prefer namespaces at the top level

For any publically consumable code, namespaces are preferential to modules at the top level. Because they are compiled as .NET namespaces, they are consumable from C# with no issue.

```fsharp
// Good!
namespace MyCode

type MyClass() =
    ...
```

Using a top-level module may not appear different when called only from F#, but should your code change to be consumed by C#, callers may be surprised.

```fsharp
// Bad!
module MyCode

type MyClass() =
    ...
```

### Only use `[<AutoOpen>]` for nested private modules

The `[<AutoOpen>]` can pollute callers and the answer to where something comes from is "magic". The only exception to this rule is the F# Core Library itself (though this fact is also a bit controversial).

However, it is a great convenience if you have more complicated helper functionality for a public API that you wish to organize separately from that public API.

```fsharp
module MyAPI =
    [<AutoOpen>]
    module private Helpers =
        let helper1 x y z =
            ...


    let myFunction1 x =
        let y = ...
        let z = ...

        helper1 x y z
```

This lets you cleanly separate implementation details from the public API of a function without having to fully qualify a helper each time you call it.

### Use `[<RequireQualifiedAccess>]` whenever names could conflict or you feel it helps with readability

Adding the `[<RequireQualifiedAccess>]` attribute to a module indicates that the module may not be opened and that references to the elements of the module require explicit qualified access. For example, the Microsoft.FSharp.Collections.List module has this attribute.

This is useful when functions and values in the module have names that are likely to conflict with names in other modules. Requiring qualified access can greatly increase the long-term maintainability and evolvability of a library.

```fsharp
[<RequireQualifiedAccess>]
module StringHelpers =
    let parse s = ...

...

let s = getAString()
let parsed = StringHepers.parse s // Must qualify to use 'parse'
```

### Do not sort `open` statements alphanumerically

Although it is possible to sort `open` statements, doing so could have confusing consequences. The order of declarations matters in F#, and this also includes `open` statements. Sorting them alphanumerically can shadow values, thus allowing you to interact with values which are likely not what you think they are.

## Use classes to contain values which have side effects

There are many times when initializing a value can have side effects, such as instantiating a context to a database or other remote resource. It is tempting to initialize such things in a module and use it in subsequent functions:

```fsharp
// This is bad!
module MyApi =
    let dep1 = File.ReadAllText "/Users/{your name}/connectionstring.txt"
    let dep2 = Environment.GetEnvironmentVariable "DEP_2"
    let dep3 = Random().Next()
 
    let function1 arg = doStuffWith dep1 dep2 dep3 arg
    let function2 arg = doSutffWith dep1 dep2 dep3 arg
```

This is a very bad idea for a few reasons:

First, it makes the API itself reliant on global state. Secondly, it pushes application configuration into the codebase itself. This is very difficult to maintain for larger codebases.

Finally, and this is perhaps the most insidious, is that module initialization compiles into a static constructor for the entire compilation unit. If any error occurs in let-bound value initialization in that module, it manifests as a `TypeInitializationException` which is then cached for the entire lifetime of the application. There is no way to tell what actually went wrong when this happens.

Instead, just use a simple class to hold dependencies:

```fsharp
type MyParametricApi(dep1, dep2, dep3) =
    member __.Function1 arg1 = doStuffWith dep1 dep2 dep3 arg1
    member __.Function2 arg2 = doStuffWith' dep1 dep2 dep3 arg2
```

This enables the following:

1. Pushing any dependent state outside of the API itself.
2. Configuration can now be done outsie of the API.
3. Errors in initialization for dependent values are not likely to manifest as a `TypeInitializationException`.
4. The API is now easier to test.

One could even argue that the example with classes is more "functional" than the example with let-bound values in a module.

## Error handling

Error handling in large systems is a difficult endeavor, and there are no silver bullets in ensuring your systems are fault-tolerant and behave well. The following guidelines should help in this difficult space.

### Represent error cases and illegal state in your types

With Discriminated Unions, F# gives you the ability to represent faulty program state in your type system. For example:

```fsharp
type MoneyWithdrawalResult =
    | Success of amount:decimal
    | InsufficientFunds of balance:decimal
    | CardExpired of DateTime
    | UndisclosedFailure
```

In this case, there are three known ways that withdrawing money from a bank account can fail. Each error case is represented in the type, and can thus be dealt with safely throughout the program.

```fsharp
let handleWithdrawal amount =
    let w = withdrawMoney amount
    match w with
    | Success am -> printfn "Successfully withdrew %f" am
    | InsufficientFunds balance -> printfn "Failed: balance is %f" balance
    | CardExpired expiredDate -> printfn "Failed: card expired on %O" expiredDate
    | UndisclosedFailure -> printfn "Failed: unknown - retry perhaps?"
```

In general, if you can model the different ways that something can **fail** in your domain, then error handling code is no longer treated as something you must deal with in addition to regular program flow. It is simply a part of normal program flow. There are two primary benefits to this:

1. It is easier to maintain as your domain changes over time.
2. Error cases are easier to unit test.

### Use exceptions when errors cannot be represented with types

Not all errors can be represented in a problem domain. These kinds of faults are *exceptional* in nature, hence the ability to raise and catch exceptions in F#.

First, it is recommended that you read the [Exception Design Guidelines](../../standard/design-guidelines/exceptions.md). They are also applicable to F#.

There are four primary ways to raise exceptions in F#:

1. The `raise` function with built-in exception types.
2. The `raise` function with custom exception types.
3. The `invalidArg` function, which is an alternative to `raise System.ArgumentException`
4. The `failwith` function, which is an alternative to `raise Exception`
5. The `failwithf` function, which is like `failwith` but lets you specify a format string for the error message.

This list is also ordered in preferential order. That is, you should consider them as such:

1. Try to use `raise` for built-in exception types whenever you can.
2. If you need a custom exception type, prefer `raise` with that type.

`invalidArg`, `failwith`, and `failwithf` should generally not be used in favor of `raise`. That said, they are perfectly fine alternatives if the exception you are raising is `ArgumentException` or `Exception`, and their syntax is succinct for that.

### Using exception-handling syntax

F# supports exception patterns via the `try...with` syntax:

```fsharp
try
    tryGetFileContents()
with
| :? System.IO.FileNotFoundException as e -> // Do something with it here
| :? System.Security.SecurityException as e -> // Do something with it here
```

Reconciling functionality to perform in the face of an exception with pattern matching can be a bit tricky if you wish to keep the code clean. One such way to handle this isto use [active patterns](../language-reference/active-patterns.md) as a means to group functionality surrounding an error case with an exception itself. For example, consider consuming an API which, when it throws an exception, wraps valuable information in that exception:

```fsharp
// TODO
```

### Do not use monadic error handling to replace exceptions

It is seen as somewhat taboo in functional programming to use exceptions. Indeed, exceptions violate purity and totality, so it's safe to consider them not-quite functional. However, this ignores the reality of where code must run. Even in purely functional languages like Haskell, programs such as ```2 `div` 0``` produce a runtime exception.

F# runs on .NET, and exceptions are a key piece of .NET. This is not something to ignore or attempt to work around.

There are 3 reasons why exceptions are good constructs in F# code:

1. They contain detailed diagnostic information, which is very helpful when debugging an issue.
2. They are well-understood by the runtime and other .NET languages.
3. They can reduce significant boilerplate when compared with code which goes out of its way to *avoid* exceptions by implementing some subset of their semantics on an ad-hoc basis.

This third point is quite critical. For sufficiently complex operations, failing to use exceptions can result in dealing with structures like this:

```fsharp
Result<Result<MyType, string>, string list>
```

Which can easily lead to absurd code like pattern matching on "stringly-typed" errors:

```fsharp
let result = doStuff()
match result with
| Ok r -> ...
| Error e ->
    if e.Contains "Error string 1" then ...
    elif e.Contains "Error string 2" then ...
    else ... // Who knows?
```

Additionally, it can be tempting to simply swallow any exception in the desire for a "simple" function which returns a nicer type:

```fsharp
// This is bad!
let tryReadAllText (path : string) =
    try System.IO.File.ReadAllText path |> Some
    with _ -> None
```

Unfortunately, `ReadAllText` can throw numerous exceptions based on the strange things which can happen on a file system, and this code throws away any information about what might actually be going wrong in your environment. If you were to replace this code with a result type, then you're back to stringly-typed error message parsing:

```fsharp
// This is bad!
let tryReadAllText (path : string) =
    try System.IO.File.ReadAllText path |> Ok
    with e -> Error e.Message

let r = tryReadAllText "path-to-file"
match r with
| Ok text -> ...
| Error e ->
    if e.Contains "uh oh, here we go again..." then ...
    else ...
```

And placing the exception object itself in the `Error` constructor just forces you to properly deal with the exception type at the call site rather than in the function.

That said, types such as `Result<'Success, 'Error>` are perfectly fine for basic operations where they aren't nested, and F# optional types are perfect for representing when something could either reutrn *something* or *nothing*. They are not a replacement for exceptions, though, and should not be used in an attempt to replace exceptions.

## Partial application and point-free programming

F# supports partial application, and thus, various ways to program in a point-free style. This can be beneficial for code re-use within a module or the implmentation of something, but it is generally not something to expose publically. In general, point-free programming is not a virtue in and of itself, and comes with a cognitive cost for people who are not familiar with the style.

### Do not use partial application and currying in public APIs

With little exception, the use of partial application in public APIs can be confusing for consumers. Generally speaking, `let`-bound values in F# code are **values**, not **function values**. Mixing together values and function values can result in saving a very small number of lines of code in exchange for quite a bit of cognitive overhead, especially if combined with operators such as `>>` to compose functions together.

### Consider the tooling implications for point-free programming

Curried functions do not label their arguments, which has tooling implications. Consider the following two functions.

```fsharp
let foo name age =
    printfn "My name is %s and I am %d years old!" name age

let foo' =
    printfn "My name is %s and I am %d years old!"
```

Both are valid functions, but `foo'` is a curried function. When you hover over their types, you see this:

```fsharp
val foo : name:string -> age:int -> unit

val foo' : (string -> int -> unit)
```

At the call site, tooltips in tooling such as Visual Studio will not give you meaningful information as to what the `string` and `int` input types actually represent.

If you encounter point-free code like `foo'` that is publically consumable, we recommend a full η-expansion so that tooling can pick up on meaningful names for arguments.

Furthermore, debugging point-free code can be very challenging, if not impossible. Debugging tools rely on values bound to names (e.g., `let` bindings) so that you can inspect intermmediate values midway through execution. When your code has no values to inspect, there is nothing to debug. In the future, debugging tools may evolve to construct these values based on previously-executed functionality, but it's not a good idea to hedge your bets on *potential* debugging functionality.

### Consider partial application as a technique to reduce internal boilerplate

In contrast to the previous point, partial application is a wonderful tool for reducing boilerplate inside of an application. It can be particularly helpful for unit testing the implementation of more complicated APIs, where boilerplate is often a pain to deal with. For example, the following code shows how you can accomplish what most mocking frameworks give you without taking an external dependency on such a framework.

For example, consider the following module solution topography:

```
MySolution.sln
|_/ImplementationLogic.fsproj
|_/ImplementationLogic.Tests.fsproj
|_/API.fsproj
```

`ImplementationLogic.fsproj` can expose a code like this:

```fsharp
module Transactions =
    let doTransaction txnContext txnType balance =
        ...

type Transactionater(ctx, currentBalance) =
    member __.ExecuteTransaction(txnType) =
        Transactions.doTransaction ctx txtType currentBalance
        ...
```

Unit testing `Transactions.doTransaction` in `ImplementationLogic.Tests.fspoj` is very easy:

```fsharp
namespace TransactionsTestingUtil

open Transactions

module TransactionsTestable =
    let getTestableTransactionRoutine mockContext = Transactions.doTransaction mockContext
```

Partially applying `doTransaction` with a mocking context object lets you call the function in all of your unit tests without needing to construct a mocked context each time:

```fsharp
namespace TransactionTests

open Xunit
open TransactionTypes
open TransactionsTestingUtil
open TransactionsTestingUtil.TransactionsTestable

let testableContext =
    { new ITransactionContext with
        member __.TheFirstMember() = ...
        member __.TheSecondMember() = ... }

let transactionRoutine = getTestableTransactionRoutine testableContext

[<Fact>]
let ``Test withdrawal transaction with 0.0 for balance``() =
    let expected = ...
    let actual = transactionRoutine TransactionType.Withdraw 0.0
    Assert.Equal(expected, actual)
```

This technique should not be universally applied to your entire codebase, but it is a good way to reduce boilerplate for complicated internals and unit testing those internals.

## Access control

F# has multiple options for [Access control](../language-reference/access-control.md), inherited from what is available in the .NET runtime. These are not just usable for types - you can use them for functions, too.

* Prefer keeping functions from being `public` unless you know you'll need to consume them elsewhere.
* Strive to keep all helper functionality `private`.
* Consider the use of `[<AutoOpen>]` on a private module of helper functions if they become numerous.

## Type inference and generics

Type inference can save you from typing a lot of boilerplate. And automatic generalization in the F# compiler can help you write more generic code with almost no extra effort on your part. However, these features are not universally good.

Consider labeling argument names with explicit types in public APIs and do not rely on type inference for this. The reason for this is that **you** should be in control of the shape of your API, not the compiler. Although the compiler can do a fine job at infering types for you, it is possible to have the shape of your API change if the internals it relies on have changed types. This may be what you want, but it will almost certainly result in a breaking API change that downstream consumers will then have to deal with. Instead, if you explicitly control the shape of your public API, then you can control these breaking changes.

Finally, automatic generalization is not always a boon for people who are new to F# or the codebase. There is cognitive overhead in using components which are generic, and if they not used with different input types (let alone if they are intended to be used as such), then there is no benefit to them being generic.