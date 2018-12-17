---
title: Computation Expressions (F#)
description: Learn how to create convenient syntax for writing computations in F# that can be sequenced and combined using control flow constructs and bindings.
ms.date: 07/27/2018
---
# Computation Expressions

Computation expressions in F# provide a convenient syntax for writing computations that can be sequenced and combined using control flow constructs and bindings. Depending on the kind of computation expression, they can be thought of as a way to express monads, monoids, monad transformers, and applicative functors. However, unlike other languages (such as *do-notation* in Haskell), they are not tied to a single abstraction, and do not rely on macros or other forms of metaprogramming to accomplish a convenient and context-sensitive syntax.

## Overview

Computations can take many forms. The most common form of computation is single-threaded execution, which is easy to understand and modify. However, not all forms of computation are as straightforward as single-threaded execution. Some examples include:

* Non-deterministic computations
* Asynchronous computations
* Effectful computations
* Generative computations

More generally, there are *context-sensitive* computations that you must perform in certain parts of an application. Writing context-sensitive code can be challenging, as it is easy to "leak" computations outside of a given context without abstractions to prevent you from doing so. These abstractions are often challenging to write by yourself, which is why F# has a generalized way to do so called **computation expressions**.

Computation expressions offer a uniform syntax and abstraction model for encoding context-sensitive computations.

Every computation expression is backed by a *builder* type. The builder type defines the operations that are available for the computation expression. See [Creating a New Type of Computation Expression](computation-expressions.md#creating-a-new-type-of-computation-expression), which shows how to create a custom computation expression.

### Syntax overview

All computation expressions have the following form:

```
builder-expr { cexper }
```

where `builder-expr` is the name of a builder type that defines the computation expression, and `cexper` is the expression body of the computation expression. For example, `async` computation expression code can look like this:

```fsharp
let fetchAndDownload url =
    async {
        let! data = downloadData url

        let processedData = processData data

        return processedData
    }
```

There is a special, additional syntax available within a computation expression, as shown in the previous example. The following expression forms are possible with computation expressions:

```fsharp
expr { let! ... }
expr { do! ... }
expr { yield ... }
expr { yield! ... }
expr { return ... }
expr { return! ... }
expr { match! ... }
```

Each of these keywords, and other standard F# keywords are only available in a computation expression if they have been defined in the backing builder type. The only exception to this is `match!`, which is itself syntactic sugar for the use of `let!` followed by a pattern match on the result.

The builder type is an object that defines special methods that govern the way the fragments of the computation expression are combined; that is, its methods control how the computation expression behaves. Another way to describe a builder class is to say that it enables you to customize the operation of many F# constructs, such as loops and bindings.

### `let!`

The `let!` keyword binds the result of a call to another computation expression to a name:

```fsharp
let doThingsAsync url =
    async {
        let! data = getDataAsync url
        ...
    }
```

If you bind the call to a computation expression with `let`, you will not get the result of the computation expression. Instead, you will have bound the value of the *unrealized* call to that computation expression. Use `let!` to bind to the result.

`let!` is defined by the `Bind(x, f)` member on the builder type.

### `do!`

The `do!` keyword is for calling a computation expression that returns a `unit`-like type (defined by the `Zero` member on the builder):

```fsharp
let doThingsAsync data url =
    async {
        do! submitData data url
        ...
    }
```

For the [async workflow](asynchronous-workflows.md), this type is `Async<unit>`. For other computation expressions, the type is likely to be `CExpType<unit>`.

`do!` is defined by the `Bind(x, f)` member on the builder type, where `f` produces a `unit`.

### `yield`

The `yield` keyword is for returning a value from the computation expression so that it can be consumed as an <xref:System.Collections.Generic.IEnumerable%601>:

```fsharp
let squares =
    seq {
        for i in 1..10 do
            yield i * i
    }

for sq in squares do
    printfn "%d" sq
```

As with the [yield keyword in C#](../../csharp/language-reference/keywords/yield.md), each element in the computation expression is yielded back as it is iterated.

`yield` is defined by the `Yield(x)` member on the builder type, where `x` is the item to yield back.

### `yield!`

The `yield!` keyword is for flattening a collection of values from a computation expression:

```fsharp
let squares =
    seq {
        for i in 1..3 -> i * i
    }

let cubes =
    seq {
        for i in 1..3 -> i * i * i
    }

let squaresAndCubes =
    seq {
        yield! squares
        yield! cubes
    }

printfn "%A" squaresAndCubes // Prints - 1; 4; 9; 1; 8; 27
```

When evaluated, the computation expression called by `yield!` will have its items yielded back one-by-one, flattening the result.

`yield!` is defined by the `YieldFrom(x)` member on the builder type, where `x` is a collection of values.

### `return`

The `return` keyword wraps a value in the type corresponding to the computation expression. Aside from computation expressions using `yield`, it is used to "complete" a computation expression:

```fsharp
let req = // 'req' is of type is 'Async<data>'
    async {
        let! data = fetch url
        return data
    }

// 'result' is of type 'data'
let result = Async.RunSynchronously req
```

`return` is defined by the `Return(x)` member on the builder type, where `x` is the item to wrap.

### `return!`

The `return!` keyword realizes the value of a computation expression and wraps that result in the type corresponding to the computation expression:

```fsharp
let req = // 'req' is of type is 'Async<data>'
    async {
        return! fetch url
    }

// 'result' is of type 'data'
let result = Async.RunSynchronously req
```

`return!` is defined by the `ReturnFrom(x)` member on the builder type, where `x` is another computation expression.

### `match!`

Starting with F# 4.5, the `match!` keyword allows you to inline a call to another computation expression and pattern match on its result:

```fsharp
let doThingsAsync url =
    async {
        match! callService url with
        | Some data -> ...
        | None -> ...
    }
```

When calling a computation expression with `match!`, it will realize the result of the call like `let!`. This is often used when calling a computation expression where the result is an [optional](options.md).

## Built-in computation expressions

The F# core library defines three built-in computation expressions: [Sequence Expressions](sequences.md), [Asynchronous Workflows](asynchronous-workflows.md), and [Query Expressions](query-expressions.md).

## Creating a New Type of Computation Expression

You can define the characteristics of your own computation expressions by creating a builder class and defining certain special methods on the class. The builder class can optionally define the methods as listed in the following table.

The following table describes methods that can be used in a workflow builder class.

|**Method**|**Typical signature(s)**|**Description**|
|----|----|----|
|`Bind`|`M<'T> * ('T -> M<'U>) -> M<'U>`|Called for `let!` and `do!` in computation expressions.|
|`Delay`|`(unit -> M<'T>) -> M<'T>`|Wraps a computation expression as a function.|
|`Return`|`'T -> M<'T>`|Called for `return` in computation expressions.|
|`ReturnFrom`|`M<'T> -> M<'T>`|Called for `return!` in computation expressions.|
|`Run`|`M<'T> -> M<'T>` or<br /><br />`M<'T> -> 'T`|Executes a computation expression.|
|`Combine`|`M<'T> * M<'T> -> M<'T>` or<br /><br />`M<unit> * M<'T> -> M<'T>`|Called for sequencing in computation expressions.|
|`For`|`seq<'T> * ('T -> M<'U>) -> M<'U>` or<br /><br />`seq<'T> * ('T -> M<'U>) -> seq<M<'U>>`|Called for `for...do` expressions in computation expressions.|
|`TryFinally`|`M<'T> * (unit -> unit) -> M<'T>`|Called for `try...finally` expressions in computation expressions.|
|`TryWith`|`M<'T> * (exn -> M<'T>) -> M<'T>`|Called for `try...with` expressions in computation expressions.|
|`Using`|`'T * ('T -> M<'U>) -> M<'U> when 'U :> IDisposable`|Called for `use` bindings in computation expressions.|
|`While`|`(unit -> bool) * M<'T> -> M<'T>`|Called for `while...do` expressions in computation expressions.|
|`Yield`|`'T -> M<'T>`|Called for `yield` expressions in computation expressions.|
|`YieldFrom`|`M<'T> -> M<'T>`|Called for `yield!` expressions in computation expressions.|
|`Zero`|`unit -> M<'T>`|Called for empty `else` branches of `if...then` expressions in computation expressions.|

Many of the methods in a builder class use and return an `M<'T>` construct, which is typically a separately defined type that characterizes the kind of computations being combined, for example, `Async<'T>` for asynchronous workflows and `Seq<'T>` for sequence workflows. The signatures of these methods enable them to be combined and nested with each other, so that the workflow object returned from one construct can be passed to the next. The compiler, when it parses a computation expression, converts the expression into a series of nested function calls by using the methods in the preceding table and the code in the computation expression.

The nested expression is of the following form:

```fsharp
builder.Run(builder.Delay(fun () -> {| cexpr |}))
```

In the above code, the calls to `Run` and `Delay` are omitted if they are not defined in the computation expression builder class. The body of the computation expression, here denoted as `{| cexpr |}`, is translated into calls involving the methods of the builder class by the translations described in the following table. The computation expression `{| cexpr |}` is defined recursively according to these translations where `expr` is an F# expression and `cexpr` is a computation expression.

|Expression|Translation|
|----------|-----------|
|<code>{&#124; let binding in cexpr &#124;}</code>|<code>let binding in {&#124; cexpr &#124;}</code>|
|<code>{&#124; let! pattern = expr in cexpr &#124;}</code>|<code>builder.Bind(expr, (fun pattern -> {&#124; cexpr &#124;}))</code>|
|<code>{&#124; do! expr in cexpr &#124;}</code>|<code>builder.Bind(expr, (fun () -> {&#124; cexpr &#124;}))</code>|
|<code>{&#124; yield expr &#124;}</code>|`builder.Yield(expr)`|
|<code>{&#124; yield! expr &#124;}</code>|`builder.YieldFrom(expr)`|
|<code>{&#124; return expr &#124;}</code>|`builder.Return(expr)`|
|<code>{&#124; return! expr &#124;}</code>|`builder.ReturnFrom(expr)`|
|<code>{&#124; use pattern = expr in cexpr &#124;}</code>|<code>builder.Using(expr, (fun pattern -> {&#124; cexpr &#124;}))</code>|
|<code>{&#124; use! value = expr in cexpr &#124;}</code>|<code>builder.Bind(expr, (fun value -> builder.Using(value, (fun value -> {&#124; cexpr &#124;}))))</code>|
|<code>{&#124; if expr then cexpr0 &#124;}</code>|<code>if expr then {&#124; cexpr0 &#124;} else binder.Zero()</code>|
|<code>{&#124; if expr then cexpr0 else cexpr1 &#124;}</code>|<code>if expr then {&#124; cexpr0 &#124;} else {&#124; cexpr1 &#124;}</code>|
|<code>{&#124; match expr with &#124; pattern_i -> cexpr_i &#124;}</code>|<code>match expr with &#124; pattern_i -> {&#124; cexpr_i &#124;}</code>|
|<code>{&#124; for pattern in expr do cexpr &#124;}</code>|<code>builder.For(enumeration, (fun pattern -> {&#124; cexpr &#124;}))</code>|
|<code>{&#124; for identifier = expr1 to expr2 do cexpr &#124;}</code>|<code>builder.For(enumeration, (fun identifier -> {&#124; cexpr &#124;}))</code>|
|<code>{&#124; while expr do cexpr &#124;}</code>|<code>builder.While(fun () -> expr), builder.Delay({&#124;cexpr &#124;})</code>|
|<code>{&#124; try cexpr with &#124; pattern_i -> expr_i &#124;}</code>|<code>builder.TryWith(builder.Delay({&#124; cexpr &#124;}), (fun value -> match value with &#124; pattern_i -> expr_i &#124; exn -> reraise exn)))</code>|
|<code>{&#124; try cexpr finally expr &#124;}</code>|<code>builder.TryFinally(builder.Delay( {&#124; cexpr &#124;}), (fun () -> expr))</code>|
|<code>{&#124; cexpr1; cexpr2 &#124;}</code>|<code>builder.Combine({&#124;cexpr1 &#124;}, {&#124; cexpr2 &#124;})</code>|
|<code>{&#124; other-expr; cexpr &#124;}</code>|<code>expr; {&#124; cexpr &#124;}</code>|
|<code>{&#124; other-expr &#124;}</code>|`expr; builder.Zero()`|

In the previous table, `other-expr` describes an expression that is not otherwise listed in the table. A builder class does not need to implement all of the methods and support all of the translations listed in the previous table. Those constructs that are not implemented are not available in computation expressions of that type. For example, if you do not want to support the `use` keyword in your computation expressions, you can omit the definition of `Use` in your builder class.

The following code example shows a computation expression that encapsulates a computation as a series of steps that can be evaluated one step at a time. A discriminated union type, `OkOrException`, encodes the error state of the expression as evaluated so far. This code demonstrates several typical patterns that you can use in your computation expressions, such as boilerplate implementations of some of the builder methods.

```fsharp
// Computations that can be run step by step
type Eventually<'T> =
    | Done of 'T
    | NotYetDone of (unit -> Eventually<'T>)

module Eventually =
    // The bind for the computations. Append 'func' to the
    // computation.
    let rec bind func expr =
        match expr with
        | Done value -> func value
        | NotYetDone work -> NotYetDone (fun () -> bind func (work()))

    // Return the final value wrapped in the Eventually type.
    let result value = Done value

    type OkOrException<'T> =
        | Ok of 'T
        | Exception of System.Exception

    // The catch for the computations. Stitch try/with throughout
    // the computation, and return the overall result as an OkOrException.
    let rec catch expr =
        match expr with
        | Done value -> result (Ok value)
        | NotYetDone work ->
            NotYetDone (fun () ->
                let res = try Ok(work()) with | exn -> Exception exn
                match res with
                | Ok cont -> catch cont // note, a tailcall
                | Exception exn -> result (Exception exn))

    // The delay operator.
    let delay func = NotYetDone (fun () -> func())

    // The stepping action for the computations.
    let step expr =
        match expr with
        | Done _ -> expr
        | NotYetDone func -> func ()

    // The rest of the operations are boilerplate.
    // The tryFinally operator.
    // This is boilerplate in terms of "result", "catch", and "bind".
    let tryFinally expr compensation =
        catch (expr)
        |> bind (fun res -> 
            compensation();
            match res with
            | Ok value -> result value
            | Exception exn -> raise exn)

    // The tryWith operator.
    // This is boilerplate in terms of "result", "catch", and "bind".
    let tryWith exn handler =
        catch exn
        |> bind (function Ok value -> result value | Exception exn -> handler exn)

    // The whileLoop operator.
    // This is boilerplate in terms of "result" and "bind".
    let rec whileLoop pred body =
        if pred() then body |> bind (fun _ -> whileLoop pred body)
        else result ()

    // The sequential composition operator.
    // This is boilerplate in terms of "result" and "bind".
    let combine expr1 expr2 =
        expr1 |> bind (fun () -> expr2)

    // The using operator.
    let using (resource: #System.IDisposable) func =
        tryFinally (func resource) (fun () -> resource.Dispose())

    // The forLoop operator.
    // This is boilerplate in terms of "catch", "result", and "bind".
    let forLoop (collection:seq<_>) func =
        let ie = collection.GetEnumerator()
        tryFinally 
            (whileLoop 
                (fun () -> ie.MoveNext()) 
                (delay (fun () -> let value = ie.Current in func value)))
            (fun () -> ie.Dispose())

// The builder class.
type EventuallyBuilder() =
    member x.Bind(comp, func) = Eventually.bind func comp
    member x.Return(value) = Eventually.result value
    member x.ReturnFrom(value) = value
    member x.Combine(expr1, expr2) = Eventually.combine expr1 expr2
    member x.Delay(func) = Eventually.delay func
    member x.Zero() = Eventually.result ()
    member x.TryWith(expr, handler) = Eventually.tryWith expr handler
    member x.TryFinally(expr, compensation) = Eventually.tryFinally expr compensation
    member x.For(coll:seq<_>, func) = Eventually.forLoop coll func
    member x.Using(resource, expr) = Eventually.using resource expr

let eventually = new EventuallyBuilder()

let comp = eventually {
    for x in 1..2 do
        printfn " x = %d" x
    return 3 + 4 }

// Try the remaining lines in F# interactive to see how this
// computation expression works in practice.
let step x = Eventually.step x

// returns "NotYetDone <closure>"
comp |> step

// prints "x = 1"
// returns "NotYetDone <closure>"
comp |> step |> step

// prints "x = 1"
// prints "x = 2"
// returns "Done 7"
comp |> step |> step |> step |> step 
```

A computation expression has an underlying type, which the expression returns. The underlying type may represent a computed result or a delayed computation that can be performed, or it may provide a way to iterate through some type of collection. In the previous example, the underlying type was **Eventually**. For a sequence expression, the underlying type is <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>. For a query expression, the underlying type is <xref:System.Linq.IQueryable?displayProperty=nameWithType>. For an asynchronous workflow, the underlying type is [`Async`](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7). The `Async` object represents the work to be performed to compute the result. For example, you call [`Async.RunSynchronously`](https://msdn.microsoft.com/library/0a6663a9-50f2-4d38-8bf3-cefd1a51fd6b) to execute a computation and return the result.

## Custom Operations

You can define a custom operation on a computation expression and use a custom operation as an operator in a computation expression. For example, you can include a query operator in a query expression. When you define a custom operation, you must define the Yield and For methods in the computation expression. To define a custom operation, put it in a builder class for the computation expression, and then apply the [`CustomOperationAttribute`](https://msdn.microsoft.com/library/199f3927-79df-484b-ba66-85f58cc49b19). This attribute takes a string as an argument, which is the name to be used in a custom operation. This name comes into scope at the start of the opening curly brace of the computation expression. Therefore, you shouldn’t use identifiers that have the same name as a custom operation in this block. For example, avoid the use of identifiers such as `all` or `last` in query expressions.

### Extending existing Builders with new Custom Operations

If you already have a builder class, its custom operations can be extended from outside of this builder class. Extensions must be declared in modules. Namespaces cannot contain extension members except in the same file and the same namespace declaration group where the type is defined.

The following example shows the extension of the existing `Microsoft.FSharp.Linq.QueryBuilder` class.

```fsharp
type Microsoft.FSharp.Linq.QueryBuilder with

    [<CustomOperation("existsNot")>]
    member __.ExistsNot (source: QuerySource<'T, 'Q>, predicate) =
        Enumerable.Any (source.Source, Func<_,_>(predicate)) |> not
```

## See also

- [F# Language Reference](index.md)
- [Asynchronous Workflows](asynchronous-workflows.md)
- [Sequences](https://msdn.microsoft.com/library/6b773b6b-9c9a-4af8-bd9e-d96585c166db)
- [Query Expressions](query-expressions.md)
