---
title: Nullable reference types
description: Use nullable reference types to express your intent about which variables can be null. The compiler then warns when your code might dereference null.
ms.date: 05/04/2026
ms.topic: concept-article
ms.subservice: null-safety
ai-usage: ai-assisted
---
# Nullable reference types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll see warnings about possible `null` values once you compile any project that has nullable reference types enabled.
>
> **Experienced in another language?** If you've worked with Kotlin's nullable types, TypeScript's `strictNullChecks`, or Swift's optionals, the model is familiar. C# uses static analysis and warning diagnostics instead of a separate type. Skim [Express intent with annotations](#express-intent-with-annotations) and [Null-state analysis](#null-state-analysis), then jump to the [Tutorial: Express your design intent with nullable and non-nullable reference types](../tutorials/nullable-reference-types.md) to apply the feature.

*Nullable reference types* are a group of features that minimize the chance your code throws <xref:System.NullReferenceException?displayProperty=nameWithType>. You declare which variables are intended to hold `null` and which aren't, and the compiler warns when those declarations don't match how your code uses them. The runtime behavior of your program is unchanged—nullable reference types are entirely a compile-time feature.

Three building blocks work together:

- *Variable annotations* (`string` vs. `string?`) express which references are intended to allow `null`.
- *Null-state analysis* tracks whether the value of an expression is known to be `null` or known not to be `null` at each point in your code.
- *Attributes* on APIs describe more nuanced contracts, such as "this argument can be `null`, but the return value is null only when the argument is null."

The compiler combines these signals to produce diagnostics. Warnings on a non-nullable variable mean the variable might receive `null`. Warnings on a nullable variable mean the code might dereference it without a null check. Either kind of warning is a hint that the code's behavior doesn't match its stated design.

## Enable nullable reference types

For new projects targeting .NET 6 or later, the `<Nullable>enable</Nullable>` element is in the project template by default. To enable the feature in an existing project, add it manually:

:::code language="xml" source="snippets/nullable-reference-types/project-snippet.xml":::

For migration approaches that enable the feature gradually—file by file or warning-only first—see [Nullable migration strategies](migration-strategies.md).

## Express intent with annotations

When the feature is enabled, every reference type variable is *non-nullable* by default. Append `?` to declare a *nullable* reference type:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="Annotations":::

The annotation doesn't change the runtime type. `string` and `string?` are both <xref:System.String?displayProperty=nameWithType>. The `?` is a hint to the compiler about your intent. That intent shapes the warnings the compiler produces:

- A non-nullable variable has a default *null-state* of *not-null*. The compiler warns if you assign a value that might be `null`.
- A nullable variable has a default *null-state* of *maybe-null*. The compiler warns if you dereference the variable without first checking it.

Use the annotation to make required and optional values visible in the type system. A `Person` whose name must always be set is different from a `Person` whose middle name might be missing:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="DesignIntent":::

The compiler enforces the difference: code that passes a maybe-null value where a non-nullable one is expected produces a warning. The compiler also warns when a constructor leaves a non-nullable member uninitialized.

## Null-state analysis

The compiler tracks the *null-state* of every expression. The state is one of two values:

- *not-null* — the expression is known to be not `null`.
- *maybe-null* — the expression might be `null`.

Local variables move between these states as your code runs. Assigning a non-null value or checking against `null` makes a variable *not-null*. Assigning a *maybe-null* expression or returning from a method without further information makes it *maybe-null*:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullStateTracking":::

In the preceding example, the first dereference produces a warning because `message` is *maybe-null*. After the assignment to a non-null literal, the compiler knows `message` is *not-null*, so the second dereference is safe. The third statement warns because `originalMessage` was captured while it was still `null`.

Null-state analysis works across `if` checks, pattern matching, and control flow that loops or returns early:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="FlowAnalysis":::

The analysis doesn't trace into the bodies of methods. If you need a method to communicate null-state to its callers, use [nullable analysis attributes](../../language-reference/attributes/nullable-analysis.md) on its signature.

## Override the warnings with `!`

Sometimes you know more than the compiler. The *null-forgiving operator* `!` declares that an expression is *not-null*, even when the analysis says otherwise:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullForgiving":::

Use `!` sparingly. Each occurrence is a place the compiler can no longer protect you. Prefer adding a null check, restructuring the code, or annotating the relevant API so the compiler reaches the right conclusion on its own.

## Attributes that describe API contracts

Annotations on a parameter or return type aren't always expressive enough. A method might accept a possibly-null argument but guarantee a non-null result. A test method might return `true` only when its argument isn't null. Use the [nullable analysis attributes](../../language-reference/attributes/nullable-analysis.md) to convey these contracts:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullAnalysisAttributes":::

The <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute> tells the compiler that when `IsPresent` returns `true`, the argument is *not-null*. Inside the `if` block, the compiler treats `value` as *not-null* with no null-forgiving operator required. As of .NET 5, all .NET runtime APIs are annotated, so the analysis benefits any code that calls them.

## Generics

Generic type parameters can be reference types or value types, so `T?` follows different rules depending on the type argument:

- If `T` is a non-nullable reference type, `T?` is the corresponding nullable reference type.
- If `T` is a value type, `T?` is the same value type. (Add the `struct` constraint to get <xref:System.Nullable%601> behavior.)
- If `T` is already nullable, `T?` is the same type.

Constraints refine the rules:

- `class` requires a non-nullable reference type.
- `class?` allows either a nullable or a non-nullable reference type.
- `notnull` requires a non-nullable reference or value type.

The constraints help the compiler reason about how a generic type parameter is used:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="Generics":::

## Known pitfalls

Two patterns can leave a non-nullable reference holding `null` without a warning. Both are limitations of the static analysis, not bugs in your code.

**Default structs.** A struct with non-nullable reference fields can be created with `default` or `new()`, leaving its fields uninitialized:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="DefaultStructPitfall":::

The fields hold `null` at run time, but the compiler doesn't warn. If you must use a struct, prefer required members or a parameterized constructor that callers must invoke.

**Arrays of references.** A new array of a non-nullable reference type contains all `null` elements until you assign each one:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="ArrayPitfall":::

Initialize array elements as soon as you create the array. Collection expressions and target-typed `new` make full initialization concise.

## Related content

- [Tutorial: Express your design intent with nullable and non-nullable reference types](../tutorials/nullable-reference-types.md)
- [Resolve nullable warnings](resolve-warnings.md)
- [Nullable migration strategies](migration-strategies.md)
- [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md)
- [Resolve nullable warnings (compiler reference)](../../language-reference/compiler-messages/nullable-warnings.md)
