---
title: What's new in F# 6 - F# Guide
description: Get an overview of the new features available in F# 6.
ms.date: 13/10/2021
---
# What's new in F# 6

F# 6 adds several improvements to the F# language and F# Interactive. It is released with **.NET 6**.

You can download the latest .NET SDK from the [.NET downloads page](https://dotnet.microsoft.com/download).

## Get started

F# 6 is available in all .NET Core distributions and Visual Studio tooling. For more information, see [Get started with F#](../get-started/index.md) to learn more.

## task {…}

F# 6 includes native support for authoring .NET tasks in F# code. For example, consider the following F# code to create a .NET-compatible task:

```fsharp
let readFilesTask (path1, path2) =
   async {
        let! bytes1 = File.ReadAllBytesAsync(path1) |> Async.AwaitTask
        let! bytes2 = File.ReadAllBytesAsync(path2) |> Async.AwaitTask
        return Array.append bytes1 bytes2
   } |> Async.StartAsTask
```

This code now becomes

```fsharp
let readFilesTask (path1, path2) =
   task {
        let! bytes1 = File.ReadAllBytesAsync(path1)
        let! bytes2 = File.ReadAllBytesAsync(path2)
        return Array.append bytes1 bytes2
   }
```

Task support has previously been available for F# 5.0 through the excellent TaskBuilder.fs and Ply libraries. Migrating code to the built-in support should be straightforward. There are however some differences: namespaces and type-inference differ slightly between the built-in support and these libraries, and some additional type annotations may be needed. If necessary, these community libraries can still be used with F# 6, if explicitly referenced, and the correct namespaces opened in each file.  

Using `task {…}` is very similar to `async {…}`, and the two will both be options  Using `task {…}` has several advantages over `async {…}`:

* The performance of `task {…}` is much better
* Debugging stepping and stack traces for `task {…}` is better
* Interoperating with .NET packages expecting or producing tasks is easier

If you’re familiar with `async {…}`, there are some differences to be aware of:

* `task {…}` immediately executes the task to the first await point
* `task {…}` does not implicitly propagate a cancellation token
* `task {…}` does not nor perform implicit cancellation checks
* `task {…}` does not support asynchronous tailcalls. This means using `return! ..` recursively may result in stack overflows if there are no intervening asynchronous waits.

In general, you should consider using `task {…}` over `async {…}` in new code if interoperating with .NET libraries that tasks, and you are not relying on asynchronous code tailcalls or implicit cancellation token propagation. In existing code, you should only switch to `task {…}` once you have reviewed your code to ensure you are not relying on the above characteristics of `async {…}`.

The `task {…}` support of F# 6 is built on a foundation called “resumable code” [RFC FS-1087](https://github.com/fsharp/fslang-design/blob/main/preview/FS-1087-resumable-code.md). Resumable code is a core technical feature which can be used to build many kinds of high-performance asynchronous and yielding state machines.

This feature implements [F# RFC FS-1097](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1097-task-builder.md).

## Struct representations for partial active patterns

F# 6 augments the "active patterns" feature optional struct representations for partial active patterns. This allows you to use an attribute to constrain a partial active pattern to return a value option:

```fsharp
[<return: Struct>]
let (|Int|_|) str =
   match System.Int32.TryParse(str) with
   | true, int -> ValueSome(int)
   | _ -> ValueNone
```

The use of the attribute is required. At usage sites, code doesn't change. The net result is that allocations are reduced.

This feature implements [F# RFC FS-1039](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1039-struct-representation-for-active-patterns.md).

## InlineIfLambda

The F# compiler includes an optimizer that performs inlining of code.  In F# 6 we've added a new declarative feature that allows code to optionally indicate that, if an argument is determined to be a lambda function, then that argument should itself always be inlined at callsites.

For example, consider the following `iterate` function to traverse an array:

```fsharp
let inline iterateTwice ([<InlineIfLambda>] action) (array: 'T[]) = 
    for j = 0 to array.Length-1 do 
        action array.[j]
    for j = 0 to array.Length-1 do 
        action array.[j]
```

If the callsite is

```fsharp
let arr = [| 1.. 100 |]
let mutable sum = 0
arr  |> iterateTwice (fun x -> 
    sum <- sum + x) 
```

then after inlining and other optimizations the code becomes:

```fsharp
let arr = [| 1.. 100 |]
let mutable sum = 0
for j = 0 to array.Length-1 do 
    sum <- array.[i] + x
for j = 0 to array.Length-1 do 
    sum <- array.[i] + x
```

Unlike previous versions of F#, this optimization applied regardless of the size of the lambda expression involved. This feature can also be used to implement loop unrolling and similar transformations more reliably, rather than leaving the optimizations .

An opt-in warning (`/warnon:3517`, off by default) can be turned on to indicate places in your code where `InlineIfLambda` arguments are not bound to lambda expressions at callsites.  In normal situations, this warning should not be enabled, however in certain kinds of high-performance programming it can be useful to ensure all code is inlined and flattened.

This feature implements [F# RFC FS-1098](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1098-inline-if-lambda.md).

## expr[idx]

In F# 6, we begin allowing the syntax `expr[idx]` for indexing collections.

Up to and including F# 5.0, F# has used `expr.[idx]` as indexing syntax and this syntax was based on a similar approach used in OCaml, which uses this notation for string indexed lookup. In F# a well-known indexable type has been needed for expr.

Allowing the use of `expr[idx]` is based on repeated feedback from those learning F# or seeing F# for the first time that the use of dot-notation indexing comes across as an unnecessary divergence from standard industry practice. Looked at broadly, nearly every major language uses `expr[idx]` (C, C++, C#, Java, JavaScript and many more). There is no deeply significant reason for F# to diverge here.

This is not a breaking change – by default no warnings are emitted on the use of `expr.[idx]`.  However, some informational messages are emitted related to this change suggesting code clarifications, and some further informational messages can be optionally activated. For example, an optional informational warning (`/warnon:3566`) can be activated to start reporting uses of the `expr.[idx]` notation.  See [Indexer Notation]( https://aka.ms/fsharp-index-notation) for details.

In new code, we recommend the systematic use of `expr[idx]` as the indexing syntax.

This feature implements [F# RFC FS-1110](https://github.com/fsharp/fslang-design/blob/main/FSharp6.0/FS-1110-index-syntax.md).

## Additional implicit conversions

In F# 6 we have activated support for additional “implicit” and “type-directed” conversions in F#, as described in [RFC FS-1093](https://github.com/fsharp/fslang-design/blob/main/6.0/FS-1093-additional-conversions.md).

This change achieves three things:

1. Fewer explicit upcasts are required
2. Fewer explicit integer conversions are required
3. First-class support for .NET-style implicit conversions is added

For example, in F# 5.0 and before upcasts were needed for the return expression when implementing a function where the expressions have different subtypes on different branches, even when a type annotation was present.  Consider the following F# 5.0 code:

```fsharp
open System
open System.IO
  
let findInputSource () : TextReader = 
    if DateTime.Now.DayOfWeek = DayOfWeek.Monday then  
        // On Monday a TextReader
        Console.In
    else
        // On other days a StreamReader
        File.OpenText("path.txt") :> TextReader
```

Here the branches of the conditional compute a TextReader and StreamReader respectively, and the upcast was added to make both branches have type StreamReader. In F# 6, these upcasts are generally now added automatically based on the presence of type annotations and other strong type information. This means the code can now be simpler:

```fsharp
let findInputSource () : TextReader = 
    if DateTime.Now.DayOfWeek = DayOfWeek.Monday then  
        // On Monday a TextReader
        Console.In
    else
        // On other days a StreamReader
        File.OpenText("path.txt")
```

Some upcasts may still be needed but many fewer than previously.

Type-directed conversions also allow for automatically widening 32-bit integers to 64-bit integers more often.  For example, the use of 64-bit integers is now ubiquitous in machine-learning libraries. Consider a typical API shape:

```fsharp
type Tensor(…) =
    static member Create(sizes: seq<int64>) = Tensor(…)
```

In F# 5.0, integer literals for int64 must be used:

```fsharp
Tensor.Create([100L; 10L; 10L])
```

or

```fsharp
Tensor.Create([int64 100; int64 10; int64 10])
```

In F# 6, widening happens automatically for int32  int64, when both source and destination type are strongly known, so in such cases int32 literals can be used:

```fsharp
Tensor.Create([100; 10; 10])
```

> NOTE: High-performance modern tensor implementations are available through TorchSharp and TensorFlow.NET

Finally, the addition of type-directed conversions allows .NET “op_Implicit” conversions to be applied automatically in F# code when calling methods.  For example, in F# 5.0 it was necessary to use `XName.op_Implicit` when working with .NET APIs for XML:

```fsharp
open System.Xml.Linq

let purchaseOrder = XElement.Load("PurchaseOrder.xml")

let partNos = purchaseOrder.Descendants(XName.op_Implicit "Item")
```

In F# 6, op_Implicit conversions are applied automatically when strong types are available for source expression and target type:

```fsharp
open System.Xml.Linq

let purchaseOrder = XElement.Load("PurchaseOrder.xml")

let partNos = purchaseOrder.Descendants("Item")
```

When used widely, or inappropriately, type-directed and implicit conversions can interact poorly with type inference and lead to code that is harder to understand. For this reason, some mitigations are in-place to help ensure this feature is not widely abused in F# code. First, both source and destination type must be strongly known, with no ambiguity or additional type unifications arising

Second, any “op_Implicit” implicit conversion at any position besides a method argument will give a warning (number 3391).  This is similar to other implicit conversions to delegates and LINQ expressions implemented by F# for .NET interoperability.

Third, opt-in warnings can be activated to report any use of implicit conversions.  These are:

* `/warnon:3388` (additional implicit upcast conversions)
* `/warnon:3389` (implicit numeric widening)
* `/warnon:3390` (op_Implicit at method arguments)

If your team wants to ban all uses of implicit conversions you can combine these with `/warnaserror`.

This feature implements [F# RFC FS-1093](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1093-additional-conversions.md).

## Indentation syntax revisions

F# 6 includes the removal of a number of inconsistencies and limitations in F#'s use of indentation-aware syntax, see [RFC FS-1108]( https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1108-undentation-frenzy.md). This resolved 10 significant issues highlighted by the F# users since F# 4.0.

For example, in F# 5.0 the following was allowed:

```fsharp
let c = (
    printfn "aaaa"
    printfn "bbbb"
)
```

However  the following was not (producing a warning)

```fsharp
let c = [
    1
    2
]
```

In F# 6 both are allowed. This makes F# simpler and easier to learn. The F# community contributor [Hadrian Tang]( https://github.com/Happypig375) has led the way on this including remarkable and highly valuable systematic testing of the feature.

This feature implements [F# RFC FS-1108](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1108-undentation-frenzy.md).

## “as” patterns

In F# 6, the right hand side of an “as” pattern can now itself be a pattern.  This is important when a type test has given a stronger type to an input.  For example, consider the code

```fsharp
type Pair = Pair of int * int

let analyzeObject (input: obj) =
    match input with
    | :? (int * int) as (x, y) -> printfn $"A tuple: {x}, {y}"
    | :? Pair as Pair (x, y) -> printfn $"A DU: {x}, {y}"
    | _ -> printfn "Nope"
 
let input = box (1, 2)
```

In each pattern case the input object is type-tested.  The right-hand-side of the “as” pattern is now allowed to be a further pattern which can itself match the object at the stronger type.

This feature implements [F# RFC FS-1105](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1105-Non-variable-patterns-to-the-right-of-as-patterns.md).

## Formatting for binary numbers

F# 6 adds the `%B` pattern to the avilable format specifiers, for binary number formats. The following F# code:

```fs
printf "%o" 123
printf "%B" 123
```

will print

```
173
1111011
```

This feature implements [F# RFC FS-1100](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1100-Printf-binary.md).

## Discards on use bindings

F# 6 allows `_` to be used in a `use` binding, e.g.

```fsharp
let doSomething () =
    use _ = System.IO.File.OpenText("input.txt")
    printfn "reading the file"
```

This feature implements [F# RFC FS-1102](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1102-discards-on-use-bindings.md).

## Overloaded custom operations in computation expressions

F# 6 lets you consume [interfaces with default implementations](../../csharp/whats-new/tutorials/default-interface-methods-versions.md).

Consider the following use of a computation expression builder `content`:

```fsharp
let mem = new System.IO.MemoryStream("Stream"B)
let content = ContentBuilder()
let ceResult =
    content {
        body "Name"
        body (ArraySegment<_>("Email"B, 0, 5))
        body "Password"B 2 4
        body "BYTES"B
        body mem
        body "Description" "of" "content"
    }
```

Here the `body` custom operation takes a varying number of arguments of different types. This is supported by the implementation of the builder below, which uses overloading:

```fsharp
type Content = ArraySegment<byte> list

type ContentBuilder() =
    member _.Run(c: Content) =
        let crlf = "\r\n"B
        [|for part in List.rev c do
            yield! part.Array[part.Offset..(part.Count+part.Offset-1)]
            yield! crlf |]

    member _.Yield(_) = []

    [<CustomOperation("body")>]
    member _.Body(c: Content, segment: ArraySegment<byte>) =
        segment::c

    member _.Body(c: Content, bytes: byte[]) =
        ArraySegment<byte>(bytes, 0, bytes.Length)::c

    [<CustomOperation("body")>]
    member _.Body(c: Content, bytes: byte[], offset, count) =
        ArraySegment<byte>(bytes, offset, count)::c

    member _.Body(c: Content, content: System.IO.Stream) =
        let mem = new System.IO.MemoryStream()
        content.CopyTo(mem)
        let bytes = mem.ToArray()
        ArraySegment<byte>(bytes, 0, bytes.Length)::c

    [<CustomOperation("body")>]
    member _.Body(c: Content, [<ParamArray>] contents: string[]) =
        List.rev [for c in contents -> let b = Text.Encoding.ASCII.GetBytes c in ArraySegment<_>(b,0,b.Length)] @ c
```

This feature implements [F# RFC FS-1056](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1056-allow-custom-operation-overloads.md).

## Additional collection functions

FSharp.Core 6.0.0 sees the addition of five new operations to the core collection functions. These are

* List/Array/Seq.insertAt
* List/Array/Seq.removeAt
* List/Array/Seq.updateAt
* List/Array/Seq.insertManyAt
* List/Array/Seq.removeManyAt

These all perform copy-and-update operations on the corresponding collection type or sequence, making the given adjustment.  This is a form of “functional update”.  Examples of using these functions can be seen in the documentation, e.g. for [List.insertAt](https://aka.ms/fsharp-core-reference/reference/fsharp-collections-listmodule.html#insertAt).

As an example, consider the model, message and update logic for a simple “Todo List” application written in the Elmish style. Here the user interacts with the application, generating messages, and the `update` function processes these messages, producing a new model:

```fsharp
type Model =
    { ToDo: string list }

type Message =
    | InsertToDo of index: int * what: string
    | RemoveToDo of index: int
    | LoadedToDos of index: int * what: string list

let update (model: Model) (message: Message) =
    match message with
    | InsertToDo (index, what) -> 
        { model with ToDo = model.ToDo |> List.insertAt index what }
    | RemoveToDo index -> 
        { model with ToDo = model.ToDo |> List.removeAt index }
    | LoadedToDos (index, what) -> 
        { model with ToDo = model.ToDo |> List.insertManyAt index what }
```

With these new functions, the logic is clear and simple and relies only on immutable data.

This feature implements [F# RFC FS-1113](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1113-insert-remove-update-functions.md).

## Map has Keys and Values

In FSharp.Core 6.0.0.0 the `Map` type new supports [Keys](https://aka.ms/fsharp-core-reference/reference/fsharp-collections-fsharpmap-2.html#Keys) and [Values](https://aka.ms/fsharp-core-reference/reference/fsharp-collections-fsharpmap-2.html#Values) properties. These do not copy the underlying collection.

This feature is documented in [F# RFC FS-1113](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1113-insert-remove-update-functions.md).

## Additional intrinsics for NativePtr

In FSharp.Core 6.0.0.0 we add new intrinsics to the [NativePtr](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-nativeinterop-nativeptrmodule.html) module:

* `NativePtr.nullPtr`
* `NativePtr.isNullPtr`
* `NativePtr.initBlock`
* `NativePtr.clear`
* `NativePtr.copy`
* `NativePtr.copyBlock`
* `NativePtr.ofILSigPtr`
* `NativePtr.toILSigPtr`

As with other functions in `NativePtr` these functions are inlined and their use emits warnings unless `/nowarn:9` is used.  The use of these functions is restricted to unmanaged types.

This feature is documented in [F# RFC FS-1109](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1109-Additional-intrinsics-for-the-NativePtr-module.md).

## Additional numeric types with unit annotations

In F# 6, the following types or type abbreviation aliases now support unit-of-measure annotations, the new additions are shown in bold:

 F# alias     | CLR Type
--------------|------------------
`float32`/**`single`**     | `System.Single`
`float`/**`double`**     | `System.Double`
`decimal` | `System.Decimal`
`sbyte`/**`int8`**       | `System.SByte`
`int16`       | `System.Int16`
`int`/**`int32`**      | `System.Int32`
`int64`      | `System.Int64`
**`byte`**/**`uint8`**       | `System.Byte`
**`uint16`**     | `System.UInt16`
**`uint`**/**`uint32`**     | `System.UInt32`
**`uint64`**     | `System.UIn64`
**`nativeint`**  | `System.IntPtr`
**`unativeint`** | `System.UIntPtr`

For example, you can annotate an unsigned integer as follows:

```fsharp
[<Measure>] 
type days

let better_age = 3u<days>
```

This feature is documented in [F# RFC FS-1091](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1091-Extend-Units-of-Measure.md).

## Informational warnings for rarely used symbolic operators  

F# 6 adds soft guidance that de-normalizes the use of `:=`, `!`, `incr` and `decr` in F# 6 and beyond. Using these operators and functions will now given informational messages asking you to replace your code with explicit use of the `Value` property.

In F# programming, reference cells can be used for heap-allocated mutable registers. While they are occasionally useful, in modern F# coding these are rarely needed as `let mutable` can normally be used instead. The F# core library includes two operators `:=` and `!` and two functions `incr` and `decr` specifically related to reference calls.  The presence of these operators makes reference cells more central to F# programming than they need to be, requiring all F# programmers to know these operators. Further, the `!` operator can be easily confused with the `not` operation in C# and other languages, a potentially subtle source of bugs when translating code.

The rationale for this change is to reduce the number of operators the F# programmer needs to know, and thus simplify F# for beginners.

For example, consider the following F# 5.0 code:

```fsharp
let r = ref 0

let doSomething() =
    printfn "doing something”
    r := !r + 1
```

First, in modern F# coding reference cells are rarely needed, as `let mutable` can normally be used instead:

```fsharp
let mutable r = 0

let doSomething() =
    printfn "doing something”
    r <- r + 1
```

If reference cells are used, then the in F# 6 an informational warning is emitted asking you to change the last line to `r.Value <- r.Value + 1`, and linking you to further guidance on the appropriate use of reference cells.

```fsharp
let r = ref 0

let doSomething() =
    printfn "doing something”
    r.Value <- r.Value + 1
```

These messages are not warnings - they are "informational messages" shown in the IDE and compiler output. F# remains backwards-compatible.

This feature implements [F# RFC FS-1111](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1111-refcell-op-information-messages.md).

## Removing legacy features

Sice F# 2.0, some deprecated legacy features have long given warnings. Using these now give errors unless you explicitly use `/langversion:5.0`. The features that now give errors are:

* Multiple generic parameters using a postfix type name, for example `(int, int) Dictionary`. This becomes an error in F# 6 and the standard `Dictionary<int,int>` should be used instead.
* `#indent "off"`. This becomes an error.
* `x.(expr)`. This becomes an error.
* `module M = struct … end` . This becomes an error.
* Use of inputs `*.ml` and `*.mli`. This becomes an error.
* Use of `(*IF-CAML*)` or `(*IF-OCAML*)`. This becomes an error.
* Use of `land`, `lor`, `lxor`, `lsl`, `lsr` or `asr` as infix operators. These are infix keywords in F# because they were infix keywords in OCaml and are not defined in FSharp.Core. Using these keywords will now emit a warning.

This implements [F# RFC FS-1114](https://github.com/fsharp/fslang-design/blob/main/FSharp-6.0/FS-1114-ml-compat-revisions.md)
