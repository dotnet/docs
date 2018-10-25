---
title: F# coding conventions
description: Learn general guidelines and idioms when writing F# code.
ms.date: 05/14/2018
---
# F# coding conventions

The following conventions are formulated from experience working with large F# codebases. The [Five principles of good F# code](index.md#five-principles-of-good-f-code) are the foundation of each recommendation. They are related to the [F# component design guidelines](component-design-guidelines.md), but are applicable for any F# code, not just components such as libraries.

## Organizing code

F# features two primary ways to organize code: modules and namespaces. These are similar, but do have the following differences:

* Namespaces are compiled as .NET namespaces. Modules are compiled as static classes.
* Namespaces are always top level. Modules can be top-level and nested within other modules.
* Namespaces can span multiple files. Modules cannot.
* Modules can be decorated with `[<RequireQualifiedAccess>]` and `[<AutoOpen>]`.

The following guidelines will help you use these to organize your code.

### Prefer namespaces at the top level

For any publicly consumable code, namespaces are preferential to modules at the top level. Because they are compiled as .NET namespaces, they are consumable from C# with no issue.

```fsharp
// Good!
namespace MyCode

type MyClass() =
    ...
```

Using a top-level module may not appear different when called only from F#, but for C# consumers, callers may be surprised by having to qualify `MyClass` with the `MyCode` module.

```fsharp
// Bad!
module MyCode

type MyClass() =
    ...
```

### Carefully apply `[<AutoOpen>]`

The `[<AutoOpen>]` construct can pollute the scope of what is available to callers, and the answer to where something comes from is "magic". This is generally not a good thing. An exception to this rule is the F# Core Library itself (though this fact is also a bit controversial).

However, it is a convenience if you have helper functionality for a public API that you wish to organize separately from that public API.

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

Additionally, exposing extension methods and expression builders at the namespace level can be neatly expressed with `[<AutoOpen>]`.

### Use `[<RequireQualifiedAccess>]` whenever names could conflict or you feel it helps with readability

Adding the `[<RequireQualifiedAccess>]` attribute to a module indicates that the module may not be opened and that references to the elements of the module require explicit qualified access. For example, the `Microsoft.FSharp.Collections.List` module has this attribute.

This is useful when functions and values in the module have names that are likely to conflict with names in other modules. Requiring qualified access can greatly increase the long-term maintainability and evolvability of a library.

```fsharp
[<RequireQualifiedAccess>]
module StringTokenization =
    let parse s = ...

...

let s = getAString()
let parsed = StringTokenization.parse s // Must qualify to use 'parse'
```

### Sort `open` statements topologically

In F#, the order of declarations matters, including with `open` statements. This is unlike C#, where the effect of `using` and `using static` is independent of the ordering of those statements in a file.

In F#, elements opened into a scope can shadow others already present. This means that reordering `open` statements could alter the meaning of code. As a result, any arbitrary sorting of all `open` statements (for example, alphanumerically) is generally not recommended, lest you generate different behavior that you might expect.

Instead, we recommend that you sort them [topologically](https://en.wikipedia.org/wiki/Topological_sorting); that is, order your `open` statements in the order in which _layers_ of your system are defined. Doing alphanumeric sorting within different topological layers may also be considered.

As an example, here is the topological sorting for the F# compiler service public API file:

```fsharp
namespace Microsoft.FSharp.Compiler.SourceCodeServices

open System
open System.Collections.Generic
open System.Collections.Concurrent
open System.Diagnostics
open System.IO
open System.Reflection
open System.Text

open Microsoft.FSharp.Compiler
open Microsoft.FSharp.Compiler.AbstractIL
open Microsoft.FSharp.Compiler.AbstractIL.Diagnostics
open Microsoft.FSharp.Compiler.AbstractIL.IL
open Microsoft.FSharp.Compiler.AbstractIL.ILBinaryReader
open Microsoft.FSharp.Compiler.AbstractIL.Internal
open Microsoft.FSharp.Compiler.AbstractIL.Internal.Library

open Microsoft.FSharp.Compiler.AccessibilityLogic
open Microsoft.FSharp.Compiler.Ast
open Microsoft.FSharp.Compiler.CompileOps
open Microsoft.FSharp.Compiler.CompileOptions
open Microsoft.FSharp.Compiler.Driver
open Microsoft.FSharp.Compiler.ErrorLogger
open Microsoft.FSharp.Compiler.Infos
open Microsoft.FSharp.Compiler.InfoReader
open Microsoft.FSharp.Compiler.Lexhelp
open Microsoft.FSharp.Compiler.Layout
open Microsoft.FSharp.Compiler.Lib
open Microsoft.FSharp.Compiler.NameResolution
open Microsoft.FSharp.Compiler.PrettyNaming
open Microsoft.FSharp.Compiler.Parser
open Microsoft.FSharp.Compiler.Range
open Microsoft.FSharp.Compiler.Tast
open Microsoft.FSharp.Compiler.Tastops
open Microsoft.FSharp.Compiler.TcGlobals
open Microsoft.FSharp.Compiler.TypeChecker
open Microsoft.FSharp.Compiler.SourceCodeServices.SymbolHelpers

open Internal.Utilities
open Internal.Utilities.Collections
```

Note that a line break separates topological layers, with each layer being sorted alphanumerically afterwards. This cleanly organizes code without accidentally shadowing values.

## Use classes to contain values that have side effects

There are many times when initializing a value can have side effects, such as instantiating a context to a database or other remote resource. It is tempting to initialize such things in a module and use it in subsequent functions:

```fsharp
// This is bad!
module MyApi =
    let dep1 = File.ReadAllText "/Users/{your name}/connectionstring.txt"
    let dep2 = Environment.GetEnvironmentVariable "DEP_2"

    let private r = Random()
    let dep3() = r.Next() // Problematic if multiple threads use this

    let function1 arg = doStuffWith dep1 dep2 dep3 arg
    let function2 arg = doSutffWith dep1 dep2 dep3 arg
```

This is frequently a bad idea for a few reasons:

First, application configuration is pushed into the codebase with `dep1` and `dep2`. This is difficult to maintain in larger codebases.

Second, statically initialized data should not include values that are not thread safe if your component will itself use multiple threads. This is clearly violated by `dep3`.

Finally, module initialization compiles into a static constructor for the entire compilation unit. If any error occurs in let-bound value initialization in that module, it manifests as a `TypeInitializationException` that is then cached for the entire lifetime of the application. This can be difficult to diagnose. There is usually an inner exception that you can attempt to reason about, but if there is not, then there is no telling what the root cause is.

Instead, just use a simple class to hold dependencies:

```fsharp
type MyParametricApi(dep1, dep2, dep3) =
    member __.Function1 arg1 = doStuffWith dep1 dep2 dep3 arg1
    member __.Function2 arg2 = doStuffWith dep1 dep2 dep3 arg2
```

This enables the following:

1. Pushing any dependent state outside of the API itself.
2. Configuration can now be done outside of the API.
3. Errors in initialization for dependent values are not likely to manifest as a `TypeInitializationException`.
4. The API is now easier to test.

## Error management

Error management in large systems is a complex and nuanced endeavor, and there are no silver bullets in ensuring your systems are fault-tolerant and behave well. The following guidelines should offer guidance in navigating this difficult space.

### Represent error cases and illegal state in types intrinsic to your domain

With [Discriminated Unions](../language-reference/discriminated-unions.md), F# gives you the ability to represent faulty program state in your type system. For example:

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
    | UndisclosedFailure -> printfn "Failed: unknown"
```

In general, if you can model the different ways that something can **fail** in your domain, then error handling code is no longer treated as something you must deal with in addition to regular program flow. It is simply a part of normal program flow, and not considered **exceptional**. There are two primary benefits to this:

1. It is easier to maintain as your domain changes over time.
2. Error cases are easier to unit test.

### Use exceptions when errors cannot be represented with types

Not all errors can be represented in a problem domain. These kinds of faults are *exceptional* in nature, hence the ability to raise and catch exceptions in F#.

First, it is recommended that you read the [Exception Design Guidelines](../../standard/design-guidelines/exceptions.md). These are also applicable to F#.

The main constructs available in F# for the purposes of raising exceptions should be considered in the following order of preference:

| Function | Syntax | Purpose |
|----------|--------|---------|
| `nullArg` | `nullArg "argumentName"` | Raises a `System.ArgumentNullException` with the specified argument name. |
| `invalidArg` | `invalidArg "argumentName" "message"` | Raises a `System.ArgumentException` with a specified argument name and message. |
| `invalidOp` | `invalidOp "message"` | Raises a `System.InvalidOperationException` with the specified message. |
|`raise`| `raise (ExceptionType("message"))` | General-purpose mechanism for throwing exceptions. |
| `failwith` | `failwith "message"` | Raises a `System.Exception` with the specified message. |
| `failwithf` | `failwithf "format string" argForFormatString` | Raises a `System.Exception` with a message determined by the format string and its inputs. |

Use `nullArg`, `invalidArg` and `invalidOp` as the mechanism to throw `ArgumentNullException`, `ArgumentException` and `InvalidOperationException` when appropriate.

The `failwith` and `failwithf` functions should generally be avoided because they raise the base `Exception` type, not a specific exception. As per the [Exception Design Guidelines](../../standard/design-guidelines/exceptions.md), you want to raise more specific exceptions when you can.

### Using exception-handling syntax

F# supports exception patterns via the `try...with` syntax:

```fsharp
try
    tryGetFileContents()
with
| :? System.IO.FileNotFoundException as e -> // Do something with it here
| :? System.Security.SecurityException as e -> // Do something with it here
```

Reconciling functionality to perform in the face of an exception with pattern matching can be a bit tricky if you wish to keep the code clean. One such way to handle this is to use [active patterns](../language-reference/active-patterns.md) as a means to group functionality surrounding an error case with an exception itself. For example, you may be consuming an API that, when it throws an exception, encloses valuable information in the exception metadata. Unwrapping a useful value in the body of the captured exception inside the Active Pattern and returning that value can be helpful in some situations.

### Do not use monadic error handling to replace exceptions

Exceptions are seen as somewhat taboo in functional programming. Indeed, exceptions violate purity, so it's safe to consider them not-quite functional. However, this ignores the reality of where code must run, and that runtime errors can occur. In general, write code on the assumption that most things are neither pure nor total, to minimize unpleasant surprises.

It is important to consider the following core strengths/aspects of Exceptions with respect to their relevance and appropriateness in the .NET runtime and cross-language ecosystem as a whole:

1. They contain detailed diagnostic information, which is very helpful when debugging an issue.
2. They are well-understood by the runtime and other .NET languages.
3. They can reduce significant boilerplate when compared with code that goes out of its way to *avoid* exceptions by implementing some subset of their semantics on an ad-hoc basis.

This third point is critical. For nontrivial complex operations, failing to use exceptions can result in dealing with structures like this:

```fsharp
Result<Result<MyType, string>, string list>
```

Which can easily lead to fragile code like pattern matching on "stringly-typed" errors:

```fsharp
let result = doStuff()
match result with
| Ok r -> ...
| Error e ->
    if e.Contains "Error string 1" then ...
    elif e.Contains "Error string 2" then ...
    else ... // Who knows?
```

Additionally, it can be tempting to swallow any exception in the desire for a "simple" function that returns a "nicer" type:

```fsharp
// This is bad!
let tryReadAllText (path : string) =
    try System.IO.File.ReadAllText path |> Some
    with _ -> None
```

Unfortunately, `tryReadAllText` can throw numerous exceptions based on the myriad of things that can happen on a file system, and this code discards away any information about what might actually be going wrong in your environment. If you replace this code with a result type, then you're back to "stringly-typed" error message parsing:

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

And placing the exception object itself in the `Error` constructor just forces you to properly deal with the exception type at the call site rather than in the function. Doing this effectively creates checked exceptions, which are notoriously unfun to deal with as a caller of an API.

A good alternative to the above examples is to catch *specific* exceptions and return a meaningful value in the context of that exception. If you modify the `tryReadAllText` function as follows, `None` has more meaning:

```fsharp
let tryReadAllTextIfPresent (path : string) =
    try System.IO.File.ReadAllText path |> Some
    with :? FileNotFoundException -> None
```

Instead of functioning as a catch-all, this function will now properly handle the case when a file was not found and assign that meaning to a return. This return value can map to that error case, while not discarding any contextual information or forcing callers to deal with a case that may not be relevant at that point in the code.

Types such as `Result<'Success, 'Error>` are appropriate for basic operations where they aren't nested, and F# optional types are perfect for representing when something could either return *something* or *nothing*. They are not a replacement for exceptions, though, and should not be used in an attempt to replace exceptions. Rather, they should be applied judiciously to address specific aspects of exception and error management policy in targeted ways.

## Partial application and point-free programming

F# supports partial application, and thus, various ways to program in a point-free style. This can be beneficial for code reuse within a module or the implementation of something, but it is generally not something to expose publicly. In general, point-free programming is not a virtue in and of itself, and can add a significant cognitive barrier for people who are not immersed in the style.

### Do not use partial application and currying in public APIs

With little exception, the use of partial application in public APIs can be confusing for consumers. Usually, `let`-bound values in F# code are **values**, not **function values**. Mixing together values and function values can result in saving a small number of lines of code in exchange for quite a bit of cognitive overhead, especially if combined with operators such as `>>` to compose functions.

### Consider the tooling implications for point-free programming

Curried functions do not label their arguments. This has tooling implications. Consider the following two functions:

```fsharp
let func name age =
    printfn "My name is %s and I am %d years old!" name age

let funcWithApplication =
    printfn "My name is %s and I am %d years old!"
```

Both are valid functions, but `funcWithApplication` is a curried function. When you hover over their types in an editor, you see this:

```fsharp
val func : name:string -> age:int -> unit

val funcWithApplication : (string -> int -> unit)
```

At the call site, tooltips in tooling such as Visual Studio will not give you meaningful information as to what the `string` and `int` input types actually represent.

If you encounter point-free code like `funcWithApplication` that is publicly consumable, it is recommended to do a full η-expansion so that tooling can pick up on meaningful names for arguments.

Furthermore, debugging point-free code can be challenging, if not impossible. Debugging tools rely on values bound to names (for example, `let` bindings) so that you can inspect intermediate values midway through execution. When your code has no values to inspect, there is nothing to debug. In the future, debugging tools may evolve to synthesize these values based on previously executed paths, but it's not a good idea to hedge your bets on *potential* debugging functionality.

### Consider partial application as a technique to reduce internal boilerplate

In contrast to the previous point, partial application is a wonderful tool for reducing boilerplate inside of an application or the deeper internals of an API. It can be helpful for unit testing the implementation of more complicated APIs, where boilerplate is often a pain to deal with. For example, the following code shows how you can accomplish what most mocking frameworks give you without taking an external dependency on such a framework and having to learn a related bespoke API.

For example, consider the following solution topography:

```
MySolution.sln
|_/ImplementationLogic.fsproj
|_/ImplementationLogic.Tests.fsproj
|_/API.fsproj
```

`ImplementationLogic.fsproj` might expose code such as:

```fsharp
module Transactions =
    let doTransaction txnContext txnType balance =
        ...

type Transactor(ctx, currentBalance) =
    member __.ExecuteTransaction(txnType) =
        Transactions.doTransaction ctx txtType currentBalance
        ...
```

Unit testing `Transactions.doTransaction` in `ImplementationLogic.Tests.fspoj` is easy:

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

* Prefer non-`public` types and members until you need them to be publicly consumable. This also minimizes what consumers couple to.
* Strive to keep all helper functionality `private`.
* Consider the use of `[<AutoOpen>]` on a private module of helper functions if they become numerous.

## Type inference and generics

Type inference can save you from typing a lot of boilerplate. And automatic generalization in the F# compiler can help you write more generic code with almost no extra effort on your part. However, these features are not universally good.

* Consider labeling argument names with explicit types in public APIs and do not rely on type inference for this.

    The reason for this is that **you** should be in control of the shape of your API, not the compiler. Although the compiler can do a fine job at inferring types for you, it is possible to have the shape of your API change if the internals it relies on have changed types. This may be what you want, but it will almost certainly result in a breaking API change that downstream consumers will then have to deal with. Instead, if you explicitly control the shape of your public API, then you can control these breaking changes. In DDD terms, this can be thought of as an Anti-corruption layer.

* Consider giving a meaningful name to your generic arguments.

    Unless you are writing truly generic code that is not specific to a particular domain, a meaningful name can help other programmers understanding the domain they're working in. For example, a type parameter named `'Document` in the context of interacting with a document database makes it clearer that generic document types can be accepted by the function or member you are working with.

* Consider naming generic type parameters with PascalCase.

    This is the general way to do things in .NET, so it's recommended that you use PascalCase rather than snake_case or camelCase.

Finally, automatic generalization is not always a boon for people who are new to F# or a large codebase. There is cognitive overhead in using components that are generic. Furthermore, if automatically generalized functions are not used with different input types (let alone if they are intended to be used as such), then there is no real benefit to them being generic at that point in time. Always consider if the code you are writing will actually benefit from being generic.

## Performance

F# values are immutable by default, which allows you to avoid certain classes of bugs (especially those involving concurrency and parallelism). However, in certain cases, in order to achieve optimal (or even reasonable) efficiency of execution time or memory allocations, a span of work may best be implemented by using in-place mutation of state. This is possible in an opt-in basis with F# with the `mutable` keyword.

However, use of `mutable` in F# may feel at odds with functional purity. This is fine, if you adjust expectations from purity to [referential transparency](https://en.wikipedia.org/wiki/Referential_transparency). Referential transparency - not purity - is the end goal when writing F# functions. This allows you to write a functional interface over a mutation-based implementation for performance critical code.

### Wrap mutable code in immutable interfaces

With referential transparency as a goal, it is critical to write code that does not expose the mutable underbelly of performance-critical functions. For example, the following code implements the `Array.contains` function in the F# core library:

```fsharp
[<CompiledName("Contains")>]
let inline contains value (array:'T[]) =
    checkNonNull "array" array
    let mutable state = false
    let mutable i = 0
    while not state && i < array.Length do
        state <- value = array.[i]
        i <- i + 1
    state
```

Calling this function multiple times does not change the underlying array, nor does it require you to maintain any mutable state in consuming it. It is referentially transparent, even though almost every line of code within it uses mutation.

### Consider encapsulating mutable data in classes

The previous example used a single function to encapsulate operations using mutable data. This is not always sufficient for more complex sets of data. Consider the following sets of functions:

```fsharp
open System.Collections.Generic

let addToClosureTable (key, value) (t: Dictionary<_,_>) =
    if not (t.ContainsKey(key)) then
        t.Add(key, value)
    else
        t.[key] <- value

let closureTableCount (t: Dictionary<_,_>) = t.Count

let closureTableContains (key, value) (t: Dictionary<_, HashSet<_>>) =
    match t.TryGetValue(key) with
    | (true, v) -> v.Equals(value)
    | (false, _) -> false
```

This code is performant, but it exposes the mutation-based data structure that callers are responsible for maintaining. This can be wrapped inside of a class with no underlying members that can change:

```fsharp
open System.Collections.Generic

/// The results of computing the LALR(1) closure of an LR(0) kernel
type Closure1Table() =
    let t = Dictionary<Item0, HashSet<TerminalIndex>>()

    member __.Add(key, value) =
        if not (t.ContainsKey(key)) then
            t.Add(key, value)
        else
            t.[key] <- value

    member __.Count = t.Count

    member __.Contains(key, value) =
        match t.TryGetValue(key) with
        | (true, v) -> v.Equals(value)
        | (false, _) -> false
```

`Closure1Table` encapsulates the underlying mutation-based data structure, thereby not forcing callers to maintain the underlying data structure. Classes are a powerful way to encapsulate data and routines that are mutation-based without exposing the details to callers.

### Prefer `let mutable` to reference cells

Reference cells are a way to represent the reference to a value rather than the value itself. Although they can be used for performance-critical code, they are generally not recommended. Consider the following example:

```fsharp
let kernels =
    let acc = ref Set.empty

    processWorkList startKernels (fun kernel ->
        if not ((!acc).Contains(kernel)) then
            acc := (!acc).Add(kernel)
        ...)

    !acc |> Seq.toList
```

The use of a reference cell now "pollutes" all subsequent code with having to dereference and re-reference the underlying data. Instead, consider `let mutable`:

```fsharp
let kernels =
    let mutable acc = Set.empty

    processWorkList startKernels (fun kernel ->
        if not (acc.Contains(kernel)) then
            acc <- acc.Add(kernel)
        ...)

    acc |> Seq.toList
```

Aside from the single point of mutation in the middle of the lambda expression, all other code that touches `acc` can do so in a manner that is no different to the usage of a normal `let`-bound immutable value. This will make it easier to change over time.

## Object programming

F# has full support for objects and object-oriented (OO) concepts. Although many OO concepts are powerful and useful, not all of them are ideal to use. The following lists offer guidance on categories of OO features at a high level.

**Consider using these features in many situations:**

* Dot notation (`x.Length`)
* Instance members
* Implicit constructors
* Static members
* Indexer notation (`arr.[x]`)
* Named and Optional arguments
* Interfaces and interface implementations

**Don't reach for these features first, but do judiciously apply them when they are convenient to solve a problem:**

* Method overloading
* Encapsulated mutable data
* Operators on types
* Auto properties
* Implementing `IDisposable` and `IEnumerable`
* Type extensions
* Events
* Structs
* Delegates
* Enums

**Generally avoid these features unless you must use them:**

* Inheritance-based type hierarchies and implementation inheritance
* Nulls and `Unchecked.defaultof<_>`

### Prefer composition over inheritance

[Composition over inheritance](https://en.wikipedia.org/wiki/Composition_over_inheritance) is a long-standing idiom that good F# code can adhere to. The fundamental principle is that you should not expose a base class and force callers to inherit from that base class to get functionality.

### Use object expressions to implement interfaces if you don't need a class

[Object Expressions](../language-reference/object-expressions.md) allow you to implement interfaces on the fly, binding the implemented interface to a value without needing to do so inside of a class. This is convenient, especially if you _only_ need to implement the interface and have no need for a full class.

For example, here is the code that is run in [Ionide](http://ionide.io/) to provide a code fix action if you've added a symbol that you don't have an `open` statement for:

```fsharp
    let private createProvider () =
        { new CodeActionProvider with
            member this.provideCodeActions(doc, range, context, ct) =
                let diagnostics = context.diagnostics
                let diagnostic = diagnostics |> Seq.tryFind (fun d -> d.message.Contains "Unused open statement")
                let res =
                    match diagnostic with
                    | None -> [||]
                    | Some d ->
                        let line = doc.lineAt d.range.start.line
                        let cmd = createEmpty<Command>
                        cmd.title <- "Remove unused open"
                        cmd.command <- "fsharp.unusedOpenFix"
                        cmd.arguments <- Some ([| doc |> unbox; line.range |> unbox; |] |> ResizeArray)
                        [|cmd |]
                res
                |> ResizeArray
                |> U2.Case1
        }
```

Because there is no need for a class when interacting with the Visual Studio Code API, Object Expressions are an ideal tool for this. They are also valuable for unit testing, when you want to stub out an interface with test routines in an ad hoc manner.

## Type Abbreviations

[Type Abbreviations](../language-reference/type-abbreviations.md) are a convenient way to assign a label to another type, such as a function signature or a more complex type. For example, the following alias assigns a label to what's needed to define a computation with [CNTK](https://www.microsoft.com/en-us/cognitive-toolkit/), a deep learning library:

```fsharp
open CNTK

// DeviceDescriptor, Variable, and Function all come from CNTK
type Computation = DeviceDescriptor -> Variable -> Function
```

The `Computation` name is a convenient way to denote any function that matches the signature it is aliasing. Using Type Abbreviations like this is convenient and allows for more succinct code.

### Avoid using Type Abbreviations to represent your domain

Although Type Abbreviations are convenient for giving a name to function signatures, they can be confusing when abbreviating other types. Consider this abbreviation:

```fsharp
// Does not actually abstract integers.
type BufferSize = int
```

This can be confusing in multiple ways:

* `BufferSize` is not an abstraction; it is just another name for an integer.
* If `BufferSize` is exposed in a public API, it can easily be misinterpreted to mean more than just `int`. Generally, domain types have multiple attributes to them and are not primitive types like `int`. This abbreviation violates that assumption.
* The casing of `BufferSize` (PascalCase) implies that this type holds more data.
* This alias does not offer increased clarity compared with providing a named argument to a function.
* The abbreviation will not manifest in compiled IL; it is just an integer and this alias is a compile-time construct.

```fsharp
module Networking =
    ...
    let send data (bufferSize: int) =
        ...
```

In summary, the pitfall with Type Abbreviations is that they are **not** abstractions over the types they are abbreviating. In the previous example, `BufferSize` is just an `int` under the covers, with no additional data, nor any benefits from the type system besides what `int` already has.
