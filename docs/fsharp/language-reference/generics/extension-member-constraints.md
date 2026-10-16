---
title: Extension members for SRTP constraints
description: Adapt existing F# and .NET types to generic inline algorithms, and configure extension-member resolution across library boundaries.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# Extension members for SRTP constraints

An inline function with [statically resolved type parameters](statically-resolved-type-parameters.md) can require a member with a particular name and signature. F# 11.2 lets an in-scope extension member satisfy that requirement, even when the type comes from another assembly.

Use this capability to separate a generic algorithm from adapters for particular types. You don't need to wrap those types or add a nominal interface to them.

> [!NOTE]
> In the .NET 11.0.100 SDK, enable `<LangVersion>preview</LangVersion>` where the compiler resolves extensions. See [F# 11.2 language settings](../compiler-options.md#language-version-and-indentation) for the planned feature band. The path and mapping examples use an F# 11.0 library and a preview consumer; see [Compile libraries and consumers](#compile-libraries-and-consumers).

## Adapt a property for a shared algorithm

The following application code measures paths represented by two existing framework types. Both paths have a length of `8`:

:::code language="fsharp" source="../snippets/extension-member-constraints/consumer/Program.fs" id="Paths":::

The [library source](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/library/Library.fs) defines `Structural.Adapters` and `Structural.Algorithms`. The adapters expose the same coordinate property on types with different native APIs:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="Coordinates":::

The algorithm asks for a `Coordinates` property returning a pair of floating-point values:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="PathLength":::

At each concrete call, the compiler selects a `Coordinates` member, called the constraint's *witness*. The inline algorithm accepts either an intrinsic or extension property; empty and single-point paths have length zero.

## Share an operation across collection types

Extension constraints also support static members. The library's `Structural.Adapters` module defines adapters using the existing `List.map` and `Option.map` functions:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

In the library's `Structural.Algorithms` module, request a `Map` member on the complete input type:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="Map":::

The application can then share a transformation, change the element type, and compose mapping over a nested collection:

:::code language="fsharp" source="../snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

The compiler checks member names and types, not interfaces or mapping laws. This isn't higher-kinded polymorphism: no parameter represents a container constructor such as `F<_>`.

## Operator extensions

Operators can use the same mechanism. For example, define a mapping operator for lists and options:

:::code language="fsharp" source="../snippets/extension-member-constraints/operators/Operators.fs" id="Operators":::

A consumer opens `StructuralOperators` and uses the operator:

```fsharp
open StructuralOperators

let incremented: int list = [1; 2; 3] |>> ((+) 10)
let length: int option = Some "hello" |>> String.length
// [11; 12; 13] and Some 5
```

Built-in primitive operator solutions retain priority for matching types. An extension doesn't provide arbitrary mixed-numeric widening or replace all built-in operators.

F# 11.0 mode can accept an ordinary extension-operator declaration with FS1215, but can't use it as an SRTP solution. The [operator project](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/operators/Operators.fsproj) uses preview.

### Tuple operators and context

A collection of observations and a pair of independently accumulated results can participate in the same combination protocol. The following consumer defines its generic algorithm after opening the library's adapters:

:::code language="fsharp" source="../snippets/extension-member-constraints/composition-consumer/Program.fs" id="CombineUse":::

These library extensions give the operator a meaning for integers, lists, and pairs:

:::code language="fsharp" source="../snippets/extension-member-constraints/composition/Composition.fs" id="CombineAdapters":::

`combineAll` requires a nonempty list because it uses `List.reduce`. The operation preserves list order; the compiler doesn't enforce associativity or supply an identity for an empty input.

Native headers `type ('T1 * 'T2) with` and `type struct ('T1 * 'T2) with` extend CLR reference and value tuples. Both are F# 11.2 features and support two through seven elements; larger headers produce FS3915.

Tuples can also carry context alongside a value. The following operator appends a trail while applying a contextual function:

:::code language="fsharp" source="../snippets/extension-member-constraints/composition-consumer/Program.fs" id="ContextUse":::

:::code language="fsharp" source="../snippets/extension-member-constraints/composition/Composition.fs" id="ContextAdapters":::

Tuple dot-instance calls and native function-type headers such as `type ('a -> 'b) with` aren't supported.

The [composition library](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/composition/Composition.fsproj) and [consumer](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/composition-consumer/CompositionConsumer.fsproj) both use preview. Keep `combineAll` in the consumer: exporting that reduction can produce FS0193 for tuple `++`. The separate path and mapping examples export their algorithms.

### Return-directed construction

For an operation that introduces a plain value into a container, the output type can identify which member should construct it:

:::code language="fsharp" source="../snippets/extension-member-constraints/composition/Composition.fs" id="ReturnAdapters":::

:::code language="fsharp" source="../snippets/extension-member-constraints/composition/Composition.fs" id="Return":::

:::code language="fsharp" source="../snippets/extension-member-constraints/composition-consumer/Program.fs" id="ReturnUse":::

The consumer's result annotation selects the output type's `Return` extension. The input alone can't choose a container.

Each container supplies its own member. For return-only overloads on a single type, use the separate [`AllowOverloadOnReturnType` attribute](../parameters-and-arguments.md#select-by-return-type).

## Compile libraries and consumers

Language settings apply per project, not transitively through references. The following matrix uses the .NET 11.0.100 SDK's settings for F# 11.2 features:

| Library implementation | Consumer use | Preview requirement |
|---|---|---|
| Declares native tuple-extension headers. | Resolves their extension operators. | Both need preview; the new header syntax itself is preview. |
| Defines ordinary extensions and exports an unresolved inline member constraint. | Supplies concrete types whose extensions solve that constraint. | Consumer needs preview. The library can use F# 11.0. |
| Solves an extension constraint internally and exposes an ordinary or already-resolved inline API. | Calls that API without further extension resolution. | Library needs preview; the consumer can use F# 11.0. |
| Solves extensions and exports constraints that the consumer also resolves through extensions. | Resolves remaining constraints. | Both need preview. |

The path and mapping [library](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/library/Library.fsproj) uses `11.0`; its [consumer](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/extension-member-constraints/consumer/Consumer.fsproj) uses `preview`. From the consumer directory, run `dotnet run` with a supporting F# 11 SDK.

### Extension scope across assemblies

Use public extensions and open their module before defining dependent inline functions. For an imported unresolved constraint, also open the adapters in the consumer; the producer's `open` declarations don't transfer. An already-resolved API doesn't require the consumer to reopen its adapters.

### Inference and signatures

F# 11.2 resolution defers some choices that F# 11.0 mode makes earlier. Consider an inline helper defined with a `DateTime` receiver:

```fsharp
let inline shift (date: System.DateTime) offset = date + offset
```

In F# 11.0 mode, this form can infer `DateTime -> TimeSpan -> DateTime`. With F# 11.2 extension resolution enabled, it can retain a constraint for `(DateTime or ^Offset) : (static member (+) : DateTime * ^Offset -> ^Result)`. A consumer can then select a public, in-scope extension for a different offset type.

A consumer can't recover generality lost in an F# 11.0 library. Check exported signatures; the producer might also need F# 11.2 inference enabled.

## Preview limitations and troubleshooting

- For FS0001 or FS0193, check language settings, public visibility, and adapter scope.
- If a later producer file resolves the path example for `Complex`, code generation can fail with FS0971, `Undefined value 'get_Coordinates'`. Keep that resolution with its definitions or in a separate consumer.
- Competing adapters can make member selection ambiguous.

## See also

- [Statically resolved type parameters](statically-resolved-type-parameters.md)
- [Type extensions](../type-extensions.md)
- [Inline functions](../functions/inline-functions.md)
- [What's new in F# 11](../../whats-new/fsharp-11.md)
- [F# RFC FS-1043](https://github.com/fsharp/fslang-design/blob/2214fd07959e9cd8e48ecd499c0f3c83252218ab/RFCs/FS-1043-extension-members-for-operators-and-srtp-constraints.md)
