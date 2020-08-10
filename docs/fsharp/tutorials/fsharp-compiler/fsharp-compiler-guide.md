---
title: F# compiler guide
description: Learn about the F# compiler, its various phases, and terminology in the F# compiler codebase.
ms.date: 08/06/2020
---

# F# compiler guide

This guide discusses the F# compiler source code and implementation from a technical point of view. The source code for the F# compiler and tools can be found at [`dotnet/fsharp` on GitHub](https://github.com/dotnet/fsharp).

## Overview

There are several artifacts involved in the development of F#:

* The [F# compiler library](https://github.com/dotnet/fsharp/tree/master/src/fsharp/FSharp.Compiler.Private), called `FSharp.Compiler.Private`. Contains all logic for F# compilation - including parsing, syntax tree processing, typechecking, constraint solving, optimizations, IL importing, IL writing, pretty printing of F# constructs, and F# metadata format processing - and the F# compiler APIs for tooling.

* The [F# compiler executable](https://github.com/dotnet/fsharp/tree/master/src/fsharp/fsc), called `fsc`, which is called as a console app. It sets the .NET GC into batch mode and then invokes `FSharp.Compiler.Private` with command-line arguments.

* The [F# Core Library](https://github.com/dotnet/fsharp/tree/master/src/fsharp/FSharp.Core), called `FSharp.Core`. Contains all primitive F# types and logic for how they interact, core data structures and library functions for operating on them, structured printing logic, units of measure for scientific programming, core numeric functionality, F# quotations, F# type reflection logic, and asynchronous programming types and logic.

* The [F# Interactive tool](https://github.com/dotnet/fsharp/tree/master/src/fsharp/fsi), called `fsi`. A REPL for F# that supports execution and pretty-printing of F# code and results, loading F# script files, referencing assemblies, and referencing packages from NuGet.

* The [F# Compiler Service](https://github.com/dotnet/fsharp/tree/master/fcs), called `FSharp.Compiler.Service` or abbreviated to FCS. It is mostly identical to `FSharp.Compiler.Private`, but critically contains the "Expression API" that allows other environments to inspect and operate on type-checked F# expressions (such as transpiling F# code to a different runtime target).

The `FSharp.Compiler.Private` is by far the largest of these components and contains nearly all logic that `fsc` and `fsi` use. It is the primary subject of this guide.

The F# compiler repositories are used to produce a range of different artifacts. For the purposes of this
guide, the important ones are:

## Key data formats and representations

The following are the key data formats and internal data representations of the F# compiler code in its various configurations:

* _Input source files_  Read as Unicode text, or binary for referenced assemblies.

* _Input command-line arguments_  See [CompileOptions.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/CompileOptions.fs) for the full code implementing the arguments table. Command-line arguments are also accepted by the F# Compiler Service API in project specifications, and as optional input to F# Interactive.

* _Tokens_, see [pars.fsy](https://github.com/dotnet/fsharp/blob/master/src/fsharp/pars.fsy), [lex.fsl](https://github.com/dotnet/fsharp/blob/master/src/fsharp/lex.fsl), [lexhelp.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/lexhelp.fs) and related files.

* _Abstract Syntax Tree (AST)_, see [SyntaxTree.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/SyntaxTree.fs), the untyped syntax tree resulting from parsing.

* _Typed Abstract Syntax Tree (Typed Tree)_, see [TypedTree.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTree.fs), [TypedTreeBasics.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTree.fs), [TypedTreeOps.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTreeOps.fs), and related files. The typed, bound syntax tree including both type/module definitions and their backing expressions, resulting from type checking and the subject of successive phases of optimization and representation change.

* _Type checking context/state_, see for example [`TcState` in CompileOps.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/CompileOps.fsi) and its constituent parts, particularly `TcEnv` in [TypeChecker.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypeChecker.fsi) and `NameResolutionEnv` in [NameResolution.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/NameResolution.fsi). A set of tables representing the available names, assemblies etc. in scope during type checking, plus associated information.

* _Abstract IL_, the output of code generation, then used for binary generation, and the input format when reading .NET assemblies, see [`ILModuleDef` in il.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/il.fsi).

* _The .NET Binary format_ (with added "pickled" F# Metadata resource), the final output of fsc.exe, see the ECMA 335 specification and the [ilread.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/ilread.fs) and [ilwrite.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/ilwrite.fs) binary reader/generator implementations. The added F# metadata is stored in a binary resource, see [TypedTreePickle.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTreePickle.fs).

* _The incrementally emitted .NET reflection assembly,_ the incremental output of fsi.exe. See [ilreflect.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/ilreflect.fs).

## Key constructs and APIs for F# tooling

The following are the most relevant parts of the F# compiler tooling, making up the "engine" and API surface area of `FSharp.Compiler.Service`.

* The incremental project build engine state in [IncrementalBuild.fsi](https://github.com/fsharp/FSharp.Compiler.Service/tree/master/src/fsharp/service/IncrementalBuild.fsi)/[IncrementalBuild.fs](https://github.com/fsharp/FSharp.Compiler.Service/tree/master/src/fsharp/service/IncrementalBuild.fs), a part of the F# Compiler Service API.

* The corresponding APIs wrapping and accessing these structures in the public-facing [`FSharp.Compiler.Service` API](https://github.com/dotnet/fsharp/tree/master/src/fsharp/service) and [Symbol API](https://github.com/dotnet/fsharp/tree/master/src/fsharp/symbols).

* The [F# Compiler Service Operations Queue](fsharp-compiler-service-queue.md), the mechanism used to sequentially process requests that require semantic information.

* The [F# Compiler Service Caches](fsharp-compiler-service-caches.md), the various caches maintained by an instance of an `FSharpChecker`.

## Key compiler phases

The following is a diagram of how different phases of F# compiler work:

![F# compiler phases](../../../images/fsharp/fsharp-compiler-phases.png)

The following are the key phases and high-level logical operations of the F# compiler code in its various configurations:

* _Basic lexing_. Produces a token stream from input source file text.

* _White-space sensitive lexing_. Accepts and produces a token stream, augmenting per the F# Language Specification.

* _Parsing_. Accepts a token stream and produces an AST per the grammar in the F# Language Specification.

* _Resolving references_. See [ReferenceResolver.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/ReferenceResolver.fs) for the abstract definition of compiler reference resolution. See [LegacyMSBuildReferenceResolver.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/LegacyMSBuildReferenceResolver.fs) for reference resolution used by the .NET Framework F# compiler when running on .NET Framework. See [SimulatedMSBuildReferenceResolver.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/SimulatedMSBuildReferenceResolver.fs) when not using the .NET Framework F# compiler. See [Microsoft.DotNet.DependencyManager](https://github.com/dotnet/fsharp/tree/master/src/fsharp/Microsoft.DotNet.DependencyManager) for reference resolution and package management used in `fsi`.

* _Importing referenced .NET binaries_, see [import.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/import.fsi)/[import.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/import.fs). Accepts file references and produces a Typed Tree node for each referenced assembly, including information about its type definitions (and type forwarders if any).

* _Importing referenced F# binaries and optimization information as Typed Tree data structures_, see [TypedTreePickle.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTreePickle.fs). Accepts binary data and produces  Typed Tree nodes for each referenced assembly, including information about its type/module/function/member definitions.

* _Sequentially type checking files_, see [TypeChecker.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypeChecker.fsi)/[TypeChecker.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypeChecker.fs). Accepts an AST plus a type checking context/state and produces new Typed Tree nodes
  incorporated into an updated type checking state, plus additional Typed Tree Expression nodes used during code generation.

* _Pattern match compilation_, see [PatternMatchCompilation.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/PatternMatchCompilation.fsi)/[PatternMatchCompilation.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/PatternMatchCompilation.fs). Accepts a subset of checked Typed Tree nodes representing F# pattern matching and produces Typed Tree expressions implementing the pattern matching. Called during type checking as each construct involving pattern matching is processed.

* _Constraint solving_, see [ConstraintSolver.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/ConstraintSolver.fsi)/[ConstraintSolver.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/ConstraintSolver.fs).A constraint solver state is maintained during type checking of a single file, and constraints are progressively asserted (i.e. added to this state). Fresh inference variables are generated and variables are eliminated (solved). Variables are also generalized at various language constructs, or explicitly declared, making them "rigid". Called during type checking as each construct is processed.

* _Post-inference type checks_, see [PostInferenceChecks.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/PostInferenceChecks.fsi)/[PostInferenceChecks.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/PostInferenceChecks.fs). Called at the end of type checking/inference for each file. A range of checks that can only be enforced after type checking on a file is complete, such as analysis when using `byref<'T>` or other `IsByRefLike` structs.

* _Quotation translation_, see [QuotationTranslator.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/QuotationTranslator.fsi)/[QuotationTranslator.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/QuotationTranslator.fs)/[QuotationPickler.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/QuotationPickler.fsi)/[QuotationPickler.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/QuotationPickler.fs). Generates the stored information for F# quotation nodes, generated from the Typed Tree expression structures of the F# compiler. Quotations are ultimately stored as binary data plus some added type references. "ReflectedDefinition" quotations are collected and stored in a single blob.

* _Optimization phases_, primarily the "Optimize" (peephole/inlining) and "Top Level Representation" (lambda lifting) phases, see [Optimizer.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/Optimizer.fsi)/[Optimizer.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/Optimizer.fs) and [InnerLambdasToTopLevelFuncs.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/InnerLambdasToTopLevelFuncs.fsi)/[InnerLambdasToTopLevelFuncs.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/InnerLambdasToTopLevelFuncs.fs) and [LowerCallsAndSeqs.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/LowerCallsAndSeqs.fs). Each of these takes Typed Tree nodes for types and expressions and either modifies the nodes in place or produces new Typed Tree nodes. These phases are orchestrated in [CompileOptions.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/CompileOptions.fs)

* _Code generation_, see [IlxGen.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/IlxGen.fsi)/[IlxGen.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/IlxGen.fs). Accepts Typed Tree nodes and produces Abstract IL nodes, sometimes applying optimizations.

* _Abstract IL code rewriting_, see [EraseClosures.fs](https://github.com/dotnet/fsharp/blob/master/src/ilx/EraseClosures.fs) and
  [EraseUnions.fs](https://github.com/dotnet/fsharp/blob/master/src/ilx/EraseUnions.fs). Eliminates some constructs by rewriting Abstract IL nodes.
  
* _Binary emit_, see [ilwrite.fsi](https://github.com/dotnet/fsharp/blob/master/src/absil/ilwrite.fsi)/[ilwrite.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/ilwrite.fs).

* _Reflection-Emit_, see [ilreflect.fs](https://github.com/dotnet/fsharp/blob/master/src/absil/ilreflect.fs).

These and transformations used to build the following:

* _The F# Compiler Service API_, see the [Symbol API](https://github.com/dotnet/fsharp/tree/master/src/fsharp/symbols) and [Service API](https://github.com/dotnet/fsharp/tree/master/src/fsharp/service)

* _The F# Interactive Shell_, see [fsi.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/fsi/fsi.fs).

* _The F# Compiler Shell_, see [fsc.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/fsc.fs) and [fscmain.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/fscmain.fs).

## Coding standards and idioms

The compiler codebase uses various abbreviations. Here are some of the most common ones.

| Abbreviation             |   Meaning  |  
|:------------------------------|:-----------|
| `ad`                | Accessor domain, meaning the permissions the accessing code has to access other constructs |
| `amap`                | Assembly map, saying how to map IL references to F# CCUs |
| `arg`                | Argument (parameter) |
| `argty`                | Argument (parameter) type |
| `arginfo`                | Argument (parameter) metadata  |
| `ccu`                | Reference to an F# compilation unit = an F# DLL (possibly including the DLL being compiled)  |
| `celem`               | Custom attribute element |
| `cenv`                | Compilation environment. Means different things in different contexts, but usually a parameter for a singlecompilation state object being passed through a set of related functions in a single phase. The compilation state is often mutable. |
| `cpath`                | Compilation path, meaning A.B.C for the overall names containing a type or module definition |
| `css`                | Constraint solver state. |
| `denv`                | Display Environment. Parameters guiding the formatting of types |
| `einfo`              | An info object for an event  (whether a .NET event, an F# event or a provided event) |
| `e`                   | Expression |
| `env`                | Environment. Means different things in different contexts, but usually immutable state being passed and adjusted  through a set of related functions in a single phase. |
| `finfo`              | An info object for a field (whether a .NET field or a provided field) |
| `fref`              | A reference to an ILFieldRef Abstract IL node for a field reference. Would normally be modernized to `ilFieldRef` |
| `g`                   | The TcGlobals value |
| `id`                   | Identifier |
| `lid`                   | Long Identifier |
| `m`                   | A source code range marker |
| `mimpl`               | IL interface method implementation |
| `minfo`              | An info object for a method (whet a .NET method, an F# method or a provided method) |
| `modul`                | a Typed Tree structure for a namespace or F# module |
| `pat`              | Pattern, a syntactic AST node representing part of a pattern in a pattern match |
| `pinfo`              | An info object for a property  (whether a .NET property, an F# property or a provided property) |
| `rfref`              | Record or class field  reference, a reference to a Typed Tree node for a record or class field |
| `scoref`              | The scope of a reference in IL metadata, either assembly, `.netmodule` or local |
| `spat`              | Simple Pattern, a syntactic AST node representing part of a pattern in a pattern match |
| `tau`              | A type with the "forall" nodes stripped off (i.e. the nodes which represent generic type parameters). Comes from the notation _𝛕_ used in type theory  |
| `tcref`              | Type constructor  reference (an `EntityRef`) |
| `tinst`              | Type instantiation |
| `tpenv`              | Type parameter environment, tracks the type parameters in scope during type checking |
| `ty`, `typ`                 |  Type, usually a Typed Tree type |
| `tys`, `typs`                 |  List of types, usually Typed Tree types |
| `typar`                 |  Type Parameter |
| `tyvar`                | Type Variable, usually referring to an IL type variable, the compiled form of an F# type parameter |
| `ucref`              | Union case reference, a reference to a Typed Tree node for a union case |
| `vref`              | Value reference, a reference to a Typed Tree node for a value |

| Phase Abbreviation             |   Meaning  |  
|:------------------------------|:-----------|
| `Syn`                  | Abstract Syntax Tree |
| `Tc`                  | Type-checker |
| `IL`                 | Abstract  IL = F# representation of .NET IL |
| `Ilx`                 | Extended Abstract IL = .NET IL plus a coulpe of contructs that get erased |

## Adding Error Messages

Adding or adjusting errors emitted by the compiler is usually straightforward (though it can sometimes imply deeper compiler work). Here's the general process:

1. Reproduce the compiler error or warning with the latest F# compiler built from the [F# compiler repository](https://github.com/dotnet/fsharp).
2. Find the error code (such as `FS0020`) in the message.
3. Use a search tool and search for a part of the message. You should find it in `FSComp.fs` with a title, such as `parsMissingTypeArgs`.
4. Use another search tool or a tool like Find All References / Find Usages to see where it's used in the compiler source code.
5. Set a breakpoint at the location in source you found. If you debug the compiler with the same steps, it should trigger the breakpoint you set. This verifies that the location you found is the one that emits the error or warning you want to improve.

From here, you can either simply update the error test, or you can use some of the information at the point in the source code you identified to see if there is more information to include in the error message. For example, if the error message doesn't contain information about the identifier the user is using incorrectly, you may be able to include the name of the identifier based on data the compiler has available at that stage of compilation.

If you're including data from user code in an error message, it's important to also write a test that verifies the exact error message for a given string of F# code.

## Formatting User Text from Typed Tree items

When formatting Typed Tree objects such as `TyconRef`s as text, you normally use either

* The functions in the `NicePrint` module such as `NicePrint.outputTyconRef`. These take a `DisplayEnv` that records the context in which a type was referenced, for example, the open namespaces. Opened namespaces are not shown in the displayed output.

* The `DisplayName` properties on the relevant object. This drops the `'n` text that .NET adds to the compiled name of a type, and uses the F#-facing name for a type rather than the compiled name for a type (for example, the name given in a `CompiledName` attribute).

* The functions such as `Tastops.fullTextOfTyconRef`, used to show the full, qualified name of an item.

When formatting "info" objects, see the functions in the `NicePrint` module.

## Notes on displaying types

When displaying a type, you will normally want to "prettify" the type first. This converts any remaining type inference variables to new, better user-friendly type variables with names like `'a`. Various functions prettify types prior to display, for example, `NicePrint.layoutPrettifiedTypes` and others.

When displaying multiple types in a comparative way, for example, two types that didn't match, you will want to display the minimal amount of infomation to convey the fact that the two types are different, for example, `NicePrint.minimalStringsOfTwoTypes`.

When displaying a type, you have the option of displaying the constraints implied by any type variables mentioned in the types, appended as `when ...`. For example, `NicePrint.layoutPrettifiedTypeAndConstraints`.

## Processing large inputs

The compiler accepts large inputs such as:

* Large literals, such as `let str = "a1" + "a2" + ... + "a1000"`
* Large array expressions
* Large list expressions
* Long lists of sequential expressions
* Long lists of bindings, such as `let v1 = e1 in let v2 = e2 in ....`
* Long sequences of `if .. then ... else` expressions
* Long sequences of `match x with ... | ...` expressions
* Combinations of these

The compiler performs constant folding for large constants so there are no costs to using them at runtime. However, this is subject to a machine's stack size when compiling, leading to `StackOverflow` exceptions if those constants are very large. The same can be observed for certain kinds of array, list, or sequence expressions. This appears to be more prominent when compiling on macOS because macOS has a smaller stack size.

Many sources of `StackOverflow` exceptions prior to F# 4.7 when processing these kinds of constructs were resolved by processing them on the heap via continuation passing techniques. This avoids filling data on the stack and appears to have negligible effects on overall throughout or memory usage of the compiler.

Aside from array expressions, most of the previously-listed inputs are called "linear" expressions. This means that there is a single linear hole in the shape of expressions. For example:

* `expr :: HOLE` (list expressions or other right-linear constructions)
* `expr; HOLE` (sequential expressions)
* `let v = expr in HOLE` (let expressions)
* `if expr then expr else HOLE` (conditional expression)
* `match expr with pat[vs] -> e1[vs] | pat2 -> HOLE` (for example, `match expr with Some x -> ... | None -> ...`)

Processing these constructs with continuation passing is more difficult than a more "natural" approach that would use the stack.

For example, consider the following contrived example:

```fsharp
and remapLinearExpr g compgen tmenv expr contf =
    match expr with
    | Expr.Let (bind, bodyExpr, m, _) ->
        ...
        // tailcall for the linear position
        remapLinearExpr g compgen tmenvinner bodyExpr (contf << (fun bodyExpr' ->
            ...))

    | Expr.Sequential (expr1, expr2, dir, spSeq, m)  ->
        ...
        // tailcall for the linear position
        remapLinearExpr g compgen tmenv expr2 (contf << (fun expr2' ->
            ...))

    | LinearMatchExpr (spBind, exprm, dtree, tg1, expr2, sp2, m2, ty) ->
        ...
        // tailcall for the linear position
        remapLinearExpr g compgen tmenv expr2 (contf << (fun expr2' ->  ...))

    | LinearOpExpr (op, tyargs, argsFront, argLast, m) ->
        ...
        // tailcall for the linear position
        remapLinearExpr g compgen tmenv argLast (contf << (fun argLast' -> ...))

    | _ -> contf (remapExpr g compgen tmenv e)

and remapExpr (g: TcGlobals) (compgen:ValCopyFlag) (tmenv:Remap) expr =
    match expr with
    ...
    | LinearOpExpr _
    | LinearMatchExpr _
    | Expr.Sequential _
    | Expr.Let _ -> remapLinearExpr g compgen tmenv expr (fun x -> x)
```

The `remapExpr` operation becomes two functions, `remapExpr` (for non-linear cases) and `remapLinearExpr` (for linear cases). `remapLinearExpr` uses tailcalls for constructs in the `HOLE` positions mentioned previously, passing the result to the continuation.

Some common aspects of this style of programming are:

* The tell-tale use of `contf` (continuation function)
* The processing of the body expression `e` of a let-expression is tail-recursive, if the next construct is also a let-expression.
* The processing of the `e2` expression of a sequential-expression is tail-recursive
* The processing of the second expression in a cons is tail-recursive

The previous example is considered incomplete, because arbitrary _combinations_ of `let` and sequential expressions aren't going to be dealt with in a tail-recursive way. The compiler generally tries to do these combinations as well.

## Code Optimizations

Code optimizations are performed in [`Optimizer.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/Optimizer.fs), [`DetupleArgs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/DetupleArgs.fs), [`InnerLambdasToTopLevelFuncs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/InnerLambdasToTopLevelFuncs.fs) and [`LowerCallsAndSeqs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/LowerCallsAndSeqs.fs).

Some of the optimizations performed in [`Optimizer.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/Optimizer.fs) are:

* Propagation of known values (constants, x = y, lambdas, tuples/records/union-cases of known values)
* Inlining of known lambda values
* Eliminating unused bindings
* Eliminating sequential code when there is no side-effect
* Eliminating switches when we determine definite success or failure of pattern matching
* Eliminating getting fields from an immutable record/tuple/union-case of known value
* Expansion of tuple bindings "let v = (x1,...x3)" to avoid allocations if it's not used as a first class value
* Splitting large functions into multiple methods, especially at match cases, to avoid massive methods that take a long time to JIT
* Removing tailcalls when it is determined that no code in the transitive closure does a tailcall nor recurses

In [`DetupleArgs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/DetupleArgs.fs), tuples at call sites are eliminated if possible. Concretely, functions that accept a tuple at all call sites are replaced by functions that accept each of the tuple's arguments individually. This may require inlining to activate.

Considering the following example:

```fsharp
let max3 t =
    let (x, y, z) = t
    max x (max y z)

max3 (1, 2, 3)
```

The `max3` function gets rewritten to simply accept three arguments, and depending on how it gets called it will either get inlined at the call site or called with 3 arguments instead of a new tuple. In either case, the tuple allocation is eliminated.

However, sometimes this optimization is not applied unless a function is marked `inline`. Consider a more complicated case:

```fsharp
let rec runWithTuple t offset times =
    let offsetValues x y z offset =
        (x + offset, y + offset, z + offset)
    if times <= 0 then
        t
    else
        let (x, y, z) = t
        let r = offsetValues x y z offset
        runWithTuple r offset (times - 1)
```

The inner function `offsetValues` will allocate a new tuple when called. However, if `offsetValues` is marked as `inline` then it will no longer allocate a tuple.

Currently, these optimizations are not applied to `struct` tuples or explicit `ValueTuple`s passed to a function. In most cases, this doesn't matter because the handling of `ValueTuple` is well-optimized and may be erased at runtime. However, in the previous `runWithTuple` function, the overhead of allocating a `ValueTuple` each call ends up being higher than the previous example with `inline` applied to `offsetValues`. This may be addressed in the future.

In [`InnerLambdasToTopLevelFuncs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/InnerLambdasToTopLevelFuncs.fs), inner functions and lambdas are analyzed and, if possible, rewritten into separate methods that do not require an `FSharpFunc` allocation.

Consider the following implementation of `sumBy` on an F# list:

```fsharp
let sumBy f xs =
    let rec loop xs acc =
        match xs with
        | [] -> acc
        | x :: t -> loop t (f x + acc)
    loop xs 0
```

The inner `loop` function is emitted as a separate static method named `loop@2` and incurs no overhead involved with allocatin an `FSharpFunc` at runtime.

In [`LowerCallsAndSeqs.fs`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/LowerCallsAndSeqs.fs), a few optimizations are performed:

* Performs eta-expansion on under-applied values applied to lambda expressions and does a beta-reduction to bind any known arguments
* Analyzes a sequence expression and translates it into a state machine so that operating on sequences doesn't incur significant closure overhead

### Potential future optimizations: Better Inlining

Consider the following example:

```fsharp
let inline f k = (fun x -> k (x + 1))
let inline g k = (fun x -> k (x + 2))

let res = (f << g) id 1 // 4
```

Intermediate values that inherit from `FSharpFunc` are allocated at the call set of `res` to support function composition, even if the functions are marked as `inline`. Currently, if this overhead needs removal, you need to rewrite the code to be more like this:

```fsharp
let f x = x + 1
let g x = x + 2

let res = id 1 |> g |> f // 4
```

The downside of course being that the `id` function can't propagate to composed functions, meaning the code is now different despite yielding the same result.

More generally, any time a first-order function is passed as an argument to a second-order function, the first-order function is not inlined even if everything is marked as `inline`. This results in a performance penalty.

## Compiler Startup Performance

Compiler startup performance is a key factor affecting happiness of F# users. If the compiler took 10sec to start up, then far fewer people would use F#.

On all platforms, the following factors affect startup performance:

* Time to load compiler binaries. This depends on the size of the generated binaries, whether they are pre-compiled (for example, using NGEN or CrossGen), and the way the .NET implementation loads them.

* Time to open referenced assemblies (for example, `mscorlib.dll`, `FSharp.Core.dll`) and analyze them for the types and namespaces defined. This depends particularly on whether this is correctly done in an on-demand way.

* Time to process "open" declarations are the top of each file. Processing these declarations have been observed to take time in some cases of  F# compilation.

* Factors specific to the specific files being compiled.

On Windows, the compiler delivered with Visual Studio currently uses NGEN to pre-compile `fsc`, `fsi`, and some assemblies used in Visual Studio tooling. For .NET Core, the CrossGen tool is used to accomplish the same thing. Visual Studio will use _delayed_ NGEN, meaning that it does not run NGEN on every binary up front. This means that F# compilation through Visual Studio may be slow for a few times before it gets NGENed.

## Compiler Memory Usage

Overall memory usage is a primary determinant of the usability of the F# compiler and instances of the F# compiler service. Overly high memory usage results in poor throughput (particularly due to increased GC times) and low user interface responsivity in tools such as Visual Studio or other editing environments. In some extreme cases, it can lead to Visual Studio crashing or another IDE becoming unusable due to constant paging from absurdly high memory usage. Luckily, these extreme cases are very rare.

### Why memory usage matters

When you do a single compilation to produce a binary, memory usage typically doesn't matter much. It's often fine to allocate a lot of memory because it will just be reclaimed after compilation is over.

However, the F# compiler is not simply a batch process that accepts source code as input and produces an assembly as output. When you consider the needs of editor and project tooling in IDEs, the F# compiler is:

* An engine that processes syntax trees and outputs data at various stages of compilation
* A database of syntactic and semantic data about the code hosted in an IDE
* A server process that accepts requests for syntactic and semantic information
* An API layer for tools to request tooling-specific data (e.g., F# tooltip information)

Thinking about the F# compiler in these ways makes performance far more complicated than just throughput of a batch compilation process.

### Kinds of data processed and served in F# tooling

The following tables are split into two categories: syntactic and semantic. They contain common kinds of information requested, the kind of data that is involved, and roughly how expensive the operation is.

#### IDE actions based on syntax

|  Action | Data inspected | Data returned | Cost (S/M/L/XL) |
|---------|---------------|---------------|-----------------|
| Syntactic Classification | Current document's source text | Text span and classification type for each token in the document | S |
| Breakpoint Resolution | Current document's syntax tree | Text span representing where breakpoing where resolve | S |
| Debugging data tip info | Current document's source text | Text span representing the token being inspected | S |
| Brace pair matching | Current document's source text | Text spans representing brace pairs that match in the input document | S |
| "Smart" indentation | Current document's source text | Indentation location in a document | S |
| Code fixes operating only on syntax | Current document's source text | Small text change for document | S |
| XML doc template generation | Current document's syntax tree | Small (usually) text change for document | S |
| Brace pair completion | Current line in a source document | Additional brace pair inserted into source text | S |
| Souce document navigation (usually via dropdowns) | Current document's syntax tree | "Navigation Items" with optional child navigation items containing ranges in source code | S |
| Code outlining | Current document's source text | Text spans representing blocks of F# code that are collapsable as a group | S - M |
| Editor formatting | Current document's source text | New source text for the document | S - L |
| Syntax diagnostics | Current document's source text | List of diagnostic data including the span of text corresponding to the diagnostic | S |
| Global construct search and navigation | All syntax trees for all projects | All items that match a user's search pattern with spans of text that represent where a given item is located | S-L |

You likely noticed that nearly all of the syntactical operations are marked `S`. Aside from extreme cases, like files with 50k lines or higher, syntax-only operations typically finish very quickly. In addition to being computationally inexpensive, they are also run asynchronously and free-threaded.

Editor formatting is a bit of an exception. Most IDEs offer common commands for format an entire document, and although they also offer commands to format a given text selection, users typically choose to format the whole document. This means an entire document has to be inspected and potentially rewritten based on often complex rules. In practice this isn't bad when working with a document that has already been formatted, but it can be expensive for larger documents with strange stylistic choices.

Most of the syntax operations require an entire document's source text or parse tree. It stands to reason that this could be improved by operating on a diff of a parse tree instead of the whole thing. This is likely a very complex thing to implement though, since none of the F# compiler infrastructure works in this way today.

#### IDE actions based on semantics

|  Action | Data inspected | Data returned | Cost (S/M/L/XL) |
|---------|---------------|---------------|-----------------|
| Most code fixes | Current document's typecheck data | Set (1 or more) of suggested text replacements | S-M |
| Semantic classification | Current document's typecheck data | Spans of text with semantic classification type for all constructs in a document | S-L |
| Code lenses | Current document's typecheck data and top-level declarations (for showing signatures); graph of all projects that reference the current one (for showing references) | Signature data for each top-level construct; spans of text for each reference to a top-level construct with navigation information | S-XL |
| Code generation / refactorings | Current document's typecheck data and/or current resolved symbol/symbols | Text replacement(s) | S-L |
| Code completion | Current document's typecheck data and currently-resolved symbol user is typing at | List of all symbols in scope that are "completable" based on where completion is invoked | S-L |
| Editor tooltips | Current document's typecheck data and resolved symbol where user invoked a tooltip | F# tooltip data based on inspecting a type and its declarations, then pretty-printing them | S-XL |
| Diagnostics based on F# semantics | Current document's typecheck data | Diagnostic info for each symbol with diagnostics to show, including the range of text associated with the diagnostic | M-XL |
| Symbol highlighting in a document | Current document's typecheck data and currently-resolved symbol where user's caret is located | Ranges of text representing instances of that symbol in the document | S-M |
| Semantic navigation (for example, Go to Definition) | Current document's typecheck data and currently-resolved symbol where the user invoked navigation | Location of a symbol's declaration | S-M |
| Rename | Graph of all projects that use the symbol that rename is triggered on and the typecheck data for each of those projects | List of all uses of all symbols that are to be renamed | S-XL |
| Find all references | Graph of all projects that Find References is triggered on and the typecheck data for each of those projects | List of all uses of all symbols that are found | S-XL |
| Unused value/symbol analysis | Typecheck data for the current document | List of all symbols that aren't a public API and are unused | S-M |
| Unused `open` analysis | Typecheck data for the current document and all symbol data brought into scope by each `open` declaration | List of `open` declarations whose symbols it exposes aren't used in the current document | S-L |
| Missing `open` analysis | Typecheck data for the current document, resolved symbol with an error, and list of available namespaces or modules | List of candidate namespaces or modules that can be opened | S-M |
| Misspelled name suggestion analysis | Typecheck data for the current document and resolved symbol with an error | List of candidates that are in scope and best match the misspelled name based on a string distance algorithm | S-M |
| Name simplification analysis | Typecheck data for the current document and all symbol data brought into scope by each `open` declaration | List of text changes available for any fully- or partially-qualified symbol that can be simplified | S-XL |

You likely noticed that every cost associated with an action has a range. This is based on two factors:

1. If the semantic data being operated on is cached
2. How much semantic data must be processed for the action to be completed

Most actions are `S` if they operate on cached data and the compiler determines that no data needs to be re-computed. The size of their range is influenced largely by the _kind_ of semantic operations each action has to do, such as:

* Typechecking a single document and processing the resulting data
* Typechecking a document and its containing project and then processing the resulting data
* Resolving a single symbol in a document
* Resolving the definition of a single symbol in a codebase
* Inspecting all symbols brought into scope by a given `open` declaration
* Inspecting all symbols in a document
* Inspecting all symbols in all documents contained in a graph of projects

For example, commands like Find All References and Rename can be cheap if a codebase is small, hence the lower bound being `S`. But if the symbol in question is used across many documents in a large project graph, they are very expensive because the entire graph must be crawled and all symbols contained in its documents must be inspected.

In contrast, actions like highlighting all symbols in a document aren't terribly expensive even for very large file files. That's because the symbols to be inspected are ultimately only in a single document.

Operations that use typecheck data execute on a single background thread (see [Reactor.fsi](https://github.com/dotnet/fsharp/blob/master/src/fsharp/service/Reactor.fsi)/[Reactor.fs](https://github.com/dotnet/fsharp/blob/master/src/fsharp/service/Reactor.fs)). Each operation is cancellable - for example, if you run an expensive Find All References but decide to do something else, the next action you take that requires semantic data will cancel the Find All References operation and start the one you requested.

TODO for don --> why single-threaded? why no priority queue if can't be multithreaded?

### Analyzing compiler memory usage

In general, the F# compiler allocates a lot of memory. More than it needs to. However, most of the "easy" sources of allocations have been squashed out and what remains are many smaller sources of allocations. The remaining "big" pieces allocate as a result of their current architecture, so it isn't straightforward to address them.

To analyze memory usage of F# tooling, you have two primary avenues:

1. Take a process dump on your machine and analyze it with process dump analysis tools like [dotMemory](https://www.jetbrains.com/dotmemory/)
2. Use a sampling tool like [PerfView](https://github.com/Microsoft/perfview) or [dotTrace](https://www.jetbrains.com/profiler/) to collect a trace of your system while you perform various tasks in an IDE, ideally for 60 seconds or more.

#### Analyzing a process dump file

Process dump files are extremely information-rich data files that can be used to see the distribution of memory usage across various types. Tools like [dotMemory](https://www.jetbrains.com/dotmemory/) will show these distributions and intelligently group things to help identify the biggest areas worth improving. Additionally, they will notice things like duplicate strings and sparse arrays, which are often great ways to improve memory usage since it means more memory is being used than is necessary.

As of F# 5, one of the most prominent sources of memory usage is `ILModuleReader`, often making up more than 20% of total memory usage for a given session. There is a considerably large "long tail" of small chunks of memory usage that in aggreate add up to a lot of resource utilization. Many can be improved.

#### Analyzing a sample trace of IDE usage

The other important tool to understand memory and CPU usage for a given sample of IDE usage is a trace file. These are collected and analyzed by tools like [PerfView](https://github.com/Microsoft/perfview) and [dotTrace](https://www.jetbrains.com/profiler/).

When analyzing a trace, there are a few things to look out for:

1. Overall GC statistics for the sample to give an overall picture of what was going on in the IDE for your sample:
   a. How much CPU time was spent in the GC as a percentage of total CPU time for the IDE process?
   b. What was the peak working set (total memory usage)?
   c. What was the peak allocations per second?
   d. How many allocations were Gen0? Gen1? Gen2?
2. Memory allocations for the sample, typically also ignoring object deaths:
   a. Is `LargeObject` showing up anywhere prominently? If so, that's a problem!
   b. Which objects show up highest on the list? Does their presence that high make sense?
   c. For a type such as `System.String`, which caller allocates it the most? Can that be improved?
3. CPU sampling data, sorted by most CPU time
   a. Are any methods showing up that correspond with high memory allocations? Something showing up prominently in both places is often a sign that it needs work!

After analyzing a trace, you should have a good idea of places that could see improvement. Often times a tuple can be made into a struct tuple, or some convenient string processing could be adjusted to use a `ReadonlySpan<'T>` or turned into a more verbose loop that avoids allocations.

### The cross-project references problem

The compiler is generally built to compile one assembly: the assumption that the compiler is compiling one assembly is baked into several aspects of the design of the Typed Tree.

In contract, FCS supports compiling a graph of projects, each for a different assembly. The Typed Tree nodes are **not** shared between different project compilations. This means that representation of project references is roughly O(n^2) in memory usage. In practice it's not strictly O(n^2), but for very large codebases the proportionality is felt.

Some key things to understand are:

* The `RawFSharpAssemblyData` is the data blob that would normally be stuffed in the F# resource in the generated DLL  in a normal compilation. That's the "output" of checking each project.

* This is used as "input" for the assembly reference of each consuming project (instead of an on-disk DLL)

* Within each consuming project that blob is then resurrected to Typed Tree nodes in `TypedTreePickle.fs`.

The biggest question is: could the compiler share this data across projects? In theory, yes. In practice, it's very tricky business.

From a correctness point of view: the process of generating this blob (TypedTreePickle `p_XYZ`) and resurrecting it (TypedTreePickle `u_*`) does some transformations to the Typed Tree that are necessary for correctness of compilation, for example, [in `TypedTreePickle`](https://github.com/dotnet/fsharp/blob/master/src/fsharp/TypedTreePickle.fs#L737). Basically, the Typed Tree nodes from the compilation of one assembly are _not_ valid when compiling a different assembly.

The Typed Tree nodes include `CcuData` nodes, which have access to a number of callbacks into the `TcImports` compilation context for the assembly being compiled. TypedTree nodes are effectively tied to a particular compilation of a particular assembly due to this.

There isn't any way to share this data without losing correctness and invalidating many invariants held in the current design.

From a lifetime point of view: the Typed Tree nodes are tied together in a graph, so sharing one or two of them might drag across the entire graph and extend lifetimes of that graph. None of these interrelated nodes were designed to be shared across assemblies.

## `eventually` computations

Some parts of the F# codebase (specifically, the type checker) are written using `eventually` computation expressions. These define resumption-like computations which can be  time-sliced, suspended or discarded at "bind" points.

This is done to ensure that long-running type-checking and other computations in the F# Compiler Service can be interrupted and cancelled. The documentation of the [F# Compiler Service Operations Queue](fsharp-compiler-service-queue.md) covers some aspects of this.

When compiling code with `fsc` or executing code with `fsi`, these computations are not time-sliced and simply run synchronously and without interruption (unless the user requests it).

TODO for don --> is the below stuff still accurate?

Instances of the F# compiler service use time slicing for two things:

1. The low-priority computations of the reactor thread (i.e. the background typechecking of the incremental builder)
2. The typechecking phase of TypeCheckOneFile which are high-priority computations on the reactor thread.

The first can be interrupted by having the incremental builder dependency graph
(see [IncrementalBuild.fsi](https://github.com/fsharp/FSharp.Compiler.Service/tree/master/src/fsharp/service/IncrementalBuild.fsi)/[IncrementalBuild.fs](https://github.com/fsharp/FSharp.Compiler.Service/tree/master/src/fsharp/service/IncrementalBuild.fs))
decide not to bother continuing with the computation (it drops it on the floor)

The second can be interrupted via having `isResultObsolete` to the F# Compiler Service API return true.

### The F# Compiler Service Operations Queue

See [F# Compiler Service Queue](fsharp-compiler-service-queue.md).

### The F# Compiler Service Caches

See [F# Compiler Service Caches](fsharp-compiler-service-caches.md).

## Bootstrapping

The F# compiler is boostrapped. That is, an existing F# compiler is used to build a "proto" compiler from the current source code. That "proto" compiler is then used to compile itself, producing a "final" compiler. This ensures the final compiler is compiled with all relevant optimizations and fixes.

## FSharp.Build

TODO - Update, especially as it pertains to .NET Core/.NET SDK

`FSharp.Build.dll` and `Microsoft.FSharp.targets` give MSBuild support for F# projects (`.fsproj`). Although not strictly part of the F# compiler, these components are always found in F# tool distributions for Mono and Windows.

### How F# handles EmbeddedResource items differently to C# (details)

TODO - update

F# differs subtly to C# in how EmbeddedResource items in `.fsproj` files are handled.

When the `Sample_VS2012_FSharp_ConsoleApp_net45_with_resource` EmbeddedResource specifications
(minus the FsSrGen one) are used in a C# project we get roughly these command line arguments:

```console
/resource:obj\Debug\ResxResource.resources
/resource:obj\Debug\ResxResourceWithLogicalName.resources,The.Explicit.Name.Of.ResxResourceWithLogicalName
/resource:obj\Debug\SubDir.ResxResourceInSubDir.resources
/resource:obj\Debug\SubDir.ResxResourceWithLogicalNameInSubDir.resources,The.Explicit.Name.Of.ResxResourceWithLogicalNameInSubDir
/resource:NonResxResourceWithLogicalName.txt,The.Explicit.Name.Of.NonResxResourceWithLogicalName
/resource:NonResxResource.txt,NonResxResource.txt
/resource:SubDir\NonResxResourceInSubDir.txt,SubDir.NonResxResourceInSubDir.txt
/resource:SubDir\NonResxResourceWithLogicalNameInSubDir.txt,The.Explicit.Name.Of.NonResxResourceWithLogicalNameInSubDir
```

This gives a .NET Binary with these resource names:

```console
.mresource public ResxResource.resources
.mresource public The.Explicit.Name.Of.ResxResourceWithLogicalName
.mresource public SubDir.ResxResourceInSubDir.resources
.mresource public The.Explicit.Name.Of.ResxResourceWithLogicalNameInSubDir
.mresource public The.Explicit.Name.Of.NonResxResourceWithLogicalName
.mresource public NonResxResource.txt
.mresource public SubDir.NonResxResourceInSubDir.txt
.mresource public The.Explicit.Name.Of.NonResxResourceWithLogicalNameInSubDir
```

For F# on Windows using MSBuild we get these command line arguments:

```console
--resource:obj\Debug\ResxResource.resources
--resource:obj\Debug\ResxResourceWithLogicalName.resources
--resource:obj\Debug\SubDir.ResxResourceInSubDir.resources
--resource:obj\Debug\SubDir.ResxResourceWithLogicalNameInSubDir.resources
--resource:NonResxResourceWithLogicalName.txt
--resource:NonResxResource.txt
--resource:SubDir\NonResxResourceInSubDir.txt
--resource:SubDir\NonResxResourceWithLogicalNameInSubDir.txt
--resource:obj\Debug\FSComp.resources
```

This gives a .NET Binary with these resource names:

```console
.mresource public ResxResource.resources
.mresource public ResxResourceWithLogicalName.resources
.mresource public SubDir.ResxResourceInSubDir.resources
.mresource public SubDir.ResxResourceWithLogicalNameInSubDir.resources
.mresource public NonResxResourceWithLogicalName.txt
.mresource public NonResxResource.txt
.mresource public NonResxResourceInSubDir.txt
.mresource public NonResxResourceWithLogicalNameInSubDir.txt
.mresource public FSComp.resources
```

For F# on Linux/OSX using Mono and XBuild we get:

```console
--resource:obj/Debug/ResxResource.resources
--resource:obj/Debug/ResxResourceWithLogicalName.resources
--resource:obj/Debug/ResxResourceInSubDir.resources
--resource:obj/Debug/ResxResourceWithLogicalNameInSubDir.resources
--resource:obj/Debug/FSComp.resources
--resource:obj/Debug/FSCompLinkedInSuperDir.resources
--resource:obj/Debug/FSCompLinkedInSameDir.resources
--resource:obj/Debug/FSCompLinkedInSubDir.resources
--resource:obj/Debug/NonResxResourceWithLogicalName.txt
--resource:obj/Debug/NonResxResource.txt
--resource:obj/Debug/NonResxResourceInSubDir.txt
--resource:obj/Debug/NonResxResourceWithLogicalNameInSubDir.txt
```

This gives a .NET Binary with these resource names:

```console
.mresource public ResxResource.resources
.mresource public ResxResourceWithLogicalName.resources
.mresource public ResxResourceInSubDir.resources
.mresource public ResxResourceWithLogicalNameInSubDir.resources
.mresource public FSComp.resources
.mresource public FSCompLinkedInSuperDir.resources
.mresource public FSCompLinkedInSameDir.resources
.mresource public FSCompLinkedInSubDir.resources
.mresource public NonResxResourceWithLogicalName.txt
.mresource public NonResxResource.txt
.mresource public NonResxResourceInSubDir.txt
.mresource public NonResxResourceWithLogicalNameInSubDir.txt
```

Note that for both C# and F# on Windows ResX resources in subdirectories have `SubDir` prefixed. This is correct (C# also adds a default namespace, but the `RootNamespace` property is not set by default in F# projects - I've removed it from the C# project).

### Attribution

This document is based heavily on an [original document](http://fsharp.github.io/2015/09/29/fsharp-compiler-guide.html) published in 2015 by the [F# Software Foundation](http://fsharp.org).
