---
title: Extension members for SRTP constraints
description: Adapt existing F# and .NET types to generic inline algorithms, and configure extension-member resolution across library boundaries.
ms.date: 09/29/2026
ai-usage: ai-generated
---

# Extension members for SRTP constraints

An inline function with [statically resolved type parameters](statically-resolved-type-parameters.md) can require a member with a particular name and signature. F# 11 preview lets an in-scope extension member satisfy that requirement, even when the type comes from another assembly.

Use this capability to separate a generic algorithm from adapters for particular types. You don't need to wrap those types or add a nominal interface to them.

> [!NOTE]
> Extension-based constraint resolution requires `<LangVersion>preview</LangVersion>` in each compilation that performs it. Referencing a library built in preview doesn't by itself require preview. See [Compile libraries and consumers](#compile-libraries-and-consumers) for the distinct cases.

## Adapt a property for a shared algorithm

The following consumer measures paths represented by two existing framework types. Both paths have a length of `8`:

:::code language="fsharp" source="../snippets/extension-member-constraints/consumer/Program.fs" id="Paths":::

The [library source](../snippets/extension-member-constraints/library/Library.fs) defines `Structural.Adapters` and `Structural.Algorithms`. The adapters expose the same coordinate property on types with different native APIs:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="Coordinates":::

The algorithm asks for a `Coordinates` property returning a pair of floating-point values:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="PathLength":::

`^Point` is a statically resolved type parameter. The expression `(^Point : (member Coordinates: float * float) point)` states the member's shape and invokes it. The concrete member selected to satisfy a constraint is sometimes called its *witness*.

The function is inline because member selection happens when the compiler specializes it for concrete types. `pathLength` itself doesn't name `Complex` or `Vector2`; a type with an intrinsic `Coordinates` property also works. Empty and single-point paths have length zero.

Before this preview capability, an ordinary extension property could work in a direct call but couldn't satisfy this member constraint. An explicit coordinate projection function remains a simpler alternative when a member-based API isn't needed.

## Share an operation across collection types

Extension constraints also support static members. Define adapters in `Structural.Adapters` that use the existing `List.map` and `Option.map` functions:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="MapAdapters":::

In `Structural.Algorithms`, request a `Map` member on the complete input type:

:::code language="fsharp" source="../snippets/extension-member-constraints/library/Library.fs" id="Map":::

The consumer can then share a transformation, change the element type, and compose mapping over a nested collection:

:::code language="fsharp" source="../snippets/extension-member-constraints/consumer/Program.fs" id="Mapping":::

This is structural member selection: the compiler checks a member's name and type rather than requiring a declared interface implementation. It isn't higher-kinded polymorphism. No type parameter represents a generic container constructor such as `F<_>`, and the constraint doesn't enforce that an arbitrary adapter preserves a container or obeys mapping laws.

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

In numbered F# 11 mode, an optional extension operator declaration emits FS1215 but can still produce a library. A preview consumer can resolve that operator as a constraint solution. Treating warnings as errors rejects that producer; suppressing the warning doesn't enable extension-based resolution in a numbered consumer. The [operator project](../snippets/extension-member-constraints/operators/Operators.fsproj) uses preview to avoid this declaration warning.

## Compile libraries and consumers

Language settings apply per project, not transitively through references. With a compiler containing this F# 11 implementation, choose the setting for the work each compilation performs:

| Library implementation | Consumer use | Preview requirement |
|---|---|---|
| Defines ordinary extensions and exports an unresolved inline member constraint. | Supplies concrete types whose extensions solve that constraint. | Consumer needs preview. The library can use numbered F# 11. |
| Solves an extension constraint internally and exposes an ordinary or already-resolved inline API. | Calls that API without further extension resolution. | Library needs preview; the consumer can use numbered F# 11. |
| Solves extensions itself and also exports unresolved constraints. | Resolves those remaining constraints through extensions. | Both compilations need preview. |
| Relies on preview-specific inference to retain an unresolved generic constraint. | Uses an extension case of that inferred API. | Both can need preview; inspect the exported signature. |
| Exports ordinary extensions or intrinsic-member SRTP APIs. | Uses normal extension calls or intrinsic-member solutions. | Neither inherently requires this preview feature. |

The path and mapping examples use the first arrangement. The complete [library project](../snippets/extension-member-constraints/library/Library.fsproj) selects `11.0`; the [consumer project](../snippets/extension-member-constraints/consumer/Consumer.fsproj) selects `preview` and has a project reference to the library. From the consumer directory, run `dotnet run` with an F# 11 SDK containing the feature.

### Extension scope across assemblies

For an imported **unresolved** constraint, extensions must be in the consumer's scope. Keep `open Structural.Adapters` in the consumer even though the library's `Algorithms` module also opens it. Importing the function doesn't import the producer's candidate environment.

Within a compilation, the compiler captures the relevant extension scope when it defines the constraint. Don't assume that an `open` placed later changes an earlier definition. Open adapter modules before you define inline functions that rely on them.

Use public extension members for these constraints. The preview solver requires public witnesses; ordinary same-assembly access to an internal member doesn't establish that it can satisfy a constraint. Optional extensions don't become members of the underlying .NET type, and callers in other .NET languages don't acquire these F# extension-resolution rules.

Already-resolved APIs differ from unresolved ones. For example, a preview library can resolve an extension call at a concrete type and expose `unit -> string`, either ordinary or inline. A numbered consumer can call that API without reopening its adapters. Don't apply that result to a still-generic API that asks the consumer to find a member.

### Inference and signatures

Preview resolution defers some choices that numbered mode makes earlier. Consider an inline helper defined with a `DateTime` receiver:

```fsharp
let inline shift (date: System.DateTime) offset = date + offset
```

In numbered F# 11, this form can infer `DateTime -> TimeSpan -> DateTime`. With the extension-resolution preview, it can retain a constraint for `(DateTime or ^Offset) : (static member (+) : DateTime * ^Offset -> ^Result)`. A consumer can then select a public, in-scope extension for a different offset type.

A preview consumer can't recover generality that the library already compiled away. Check generated signatures and `.fsi` declarations when you introduce these rules; previously monomorphic helpers or ambiguous overload sets can need annotations.

`AllowOverloadOnReturnTypeAttribute` is a separate facility for [return-directed overloads](../parameters-and-arguments.md#select-by-return-type). Its availability doesn't enable extension constraint resolution.

## Preview limitations and troubleshooting

- If an ordinary extension call works but an SRTP call doesn't, check the language mode of the compilation solving the constraint and its adapter scope.
- A missing extension or a disabled resolution feature can produce FS0001 or FS0193. Warning suppression isn't a substitute for the language setting.
- An observed cross-file case can fail code generation with FS0971, `Undefined value 'get_Coordinates'`: one producer file defines the property adapter and inline path algorithm, and a later file resolves it for `Complex` in an exported function. The equivalent single-file producer succeeds. Keeping that concrete resolution with its definitions, or resolving the generic API in a separate consumer, avoids this particular case. This isn't a general prohibition on separate-assembly inline calls.
- Extension visibility and overload selection remain significant. Two modules can provide competing members; these adapters don't form a globally unique implementation registry.
- Static selection isn't a blanket zero-allocation guarantee. These examples still create lists, tuples, and mapped results; measure performance for the intended workload.

## See also

- [Statically resolved type parameters](statically-resolved-type-parameters.md)
- [Type extensions](../type-extensions.md)
- [Inline functions](../functions/inline-functions.md)
- [What's new in F# 11](../../whats-new/fsharp-11.md)
- [F# RFC FS-1043](https://github.com/fsharp/fslang-design/blob/2214fd07959e9cd8e48ecd499c0f3c83252218ab/RFCs/FS-1043-extension-members-for-operators-and-srtp-constraints.md)
