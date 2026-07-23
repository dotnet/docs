---
title: Nullable reference types
description: Use nullable reference types to express your intent about which variables can be null. The compiler then warns when your code might dereference null.
ms.date: 05/04/2026
ms.topic: concept-article
ms.subservice: nullable-reference-types
ai-usage: ai-assisted
---
# Nullable reference types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials.
>
> **Experienced in another language?** If you worked with Kotlin's nullable types, TypeScript's `strictNullChecks`, or Swift's optionals, the model is familiar. C# uses static analysis and warning diagnostics instead of a separate type. Skim [Express intent with annotations](#express-intent-with-annotations) and [Null-state analysis](#null-state-analysis), and then jump to the [Tutorial: Express your design intent with nullable and non-nullable reference types](../tutorials/nullable-reference-types.md) to apply the feature.

*Nullable reference types* are a group of features that minimize the chance your code throws <xref:System.NullReferenceException?displayProperty=nameWithType>. You declare which variables are intended to hold `null` and which aren't, and the compiler warns when those declarations don't match how your code uses them. The runtime behavior of your program is unchanged. Nullable reference types are entirely a compile-time feature.

Three building blocks work together:

- *Variable annotations* (`string` vs. `string?`) express which references are intended to allow `null`.
- *Null-state analysis* tracks whether the value of an expression is *not-null* or *maybe-null* at each point in your code.
- *Attributes* on APIs describe more nuanced contracts, such as "this argument can be `null`, but the return value is null only when the argument is null."

The compiler combines these signals to produce diagnostics. Warnings on a non-nullable variable mean the variable might receive `null`. Warnings on a nullable variable mean the code might *dereference* it without a null check. *Dereference* means to use the value the variable refers to. For example, to call a method on it (`variable.Method()`), read a property (`variable.Property`), or index into it (`variable[0]`). Dereferencing a variable that has a value of `null` throws an exception at run time. Either kind of warning means the code's behavior doesn't match its stated design.

## Nullable context

Projects created from recent .NET templates set `<Nullable>enable</Nullable>` in the project file, so the guidance in this article applies as written. If you're working in an older project, open the `.csproj` and check that the `<PropertyGroup>` contains the following line; add it if it's missing:

```xml
<Nullable>enable</Nullable>
```

For more information on migrating a large application, see the article on [nullable migration strategies](../../advanced-topics/update-applications/nullable-migration-strategies.md) for more settings and directives.

## Express intent with annotations

Every reference type variable is *non-nullable* by default. Append `?` to declare a *nullable* reference type:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="Annotations":::

The annotation doesn't change the runtime type. `string` and `string?` are both <xref:System.String?displayProperty=nameWithType>. The `?` informs the compiler of your design intent. That intent shapes the warnings the compiler produces:

- A non-nullable variable has a default *null-state* of *not-null*. The compiler warns if you assign a value that might be `null`.
- A nullable variable has a default *null-state* of *maybe-null*. The compiler warns if you dereference the variable without first checking it.

Use the annotation to make required and optional values visible in the type system. The following `Person` type declares `FirstName` and `LastName` as non-nullable—every person must have both—and `MiddleName` as nullable, because not everyone has one:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="DesignIntent":::

The annotations drive the implementation of `ToString`. Because `FirstName` and `LastName` are non-nullable, the override uses them directly in an [interpolated string](../../language-reference/tokens/interpolated.md) (the `$"..."` syntax that embeds expressions in `{}` placeholders) with no null check. `MiddleName` is nullable, so the override checks it against `null` first and only includes it when it's present. The compiler enforces the difference: code that passes a maybe-null value where a non-nullable one is expected produces a warning, and a constructor that leaves a non-nullable member uninitialized also produces a warning.

## Null-state analysis

The compiler tracks the *null-state* of every expression. The state is one of two values:

- *not-null*: the expression is known to be not `null`.
- *maybe-null*: the expression might be `null`.

A local variable's null-state is updated as the compiler analyzes your code. Two things change it: **assignments** and **null checks**. After an assignment, the variable's null-state matches the expression on the right-hand side. If the expression is null or nullable, the variable becomes maybe-null. If the expression is a non-null literal, the variable becomes not-null. After a null check, the variable's null-state reflects whichever branch is taken.

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullStateTracking":::

In the preceding example, the first dereference produces a warning because `message` is *maybe-null*. After the assignment to a non-null literal, the compiler knows `message` is *not-null*, so the second dereference is safe.

Null-state analysis works across `if` checks, [pattern matching](../../language-reference/operators/patterns.md) (expressions such as `is null` or `is { }` that test the shape of a value), and control flow that loops or returns early:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="FlowAnalysis":::

The analysis doesn't trace into the bodies of methods. If you need a method to communicate null-state to its callers, use [nullable analysis attributes](../../language-reference/attributes/nullable-analysis.md) on its signature.

## Override the warnings with `!`

Sometimes you know more than the compiler. The *null-forgiving operator* `!` declares that an expression is *not-null*, even when the analysis says otherwise:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullForgiving":::

Use `!` sparingly. Each occurrence is a place the compiler can no longer protect you. Prefer adding a null check, restructuring the code, or annotating the relevant API so the compiler reaches the right conclusion on its own.

## Attributes that describe API contracts

Annotations on a parameter or return type aren't always expressive enough. A method might accept a possibly null argument but guarantee a non-null result. A test method might return `true` only when its argument isn't null. Use the [nullable analysis attributes](../../language-reference/attributes/nullable-analysis.md) to convey these contracts:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="NullAnalysisAttributes":::

The <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute> tells the compiler that when `IsPresent` returns `true`, the argument is *not-null*. Inside the `if` block, the compiler treats `value` as *not-null* with no null-forgiving operator required. As of .NET 5, all .NET runtime APIs are annotated, so the analysis benefits any code that calls them.

## Known pitfalls

Two patterns can leave a non-nullable reference holding `null` without a warning. Both patterns are limitations of the static analysis, not bugs in your code.

### Default structs

You can create a struct with non-nullable reference fields by using `default` or `new()`. This approach leaves the struct's fields uninitialized:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="DefaultStructPitfall":::

The fields hold `null` at run time, but the compiler doesn't warn. If you must use a struct, prefer [required members](../../language-reference/keywords/required.md), which are members the caller must initialize through an object initializer, or a parameterized constructor that callers must invoke.

### Arrays of references and structs

A new array of a non-nullable reference type contains all `null` elements until you assign each one:

:::code language="csharp" source="snippets/nullable-reference-types/Program.cs" id="ArrayPitfall":::

The same pitfall applies to arrays of structs: every element starts as the struct's default value, so each element's non-nullable reference fields start as `null`.

Initialize array elements as part of creating the array. [Collection expressions](../../language-reference/operators/collection-expressions.md) (the `[1, 2, 3]` literal syntax) and [target-typed `new`](../../language-reference/operators/new-operator.md#target-typed-new) (writing `new()` when the compiler can infer the type) make full initialization concise.

## Related content

- [Tutorial: Express your design intent with nullable and non-nullable reference types](../tutorials/nullable-reference-types.md)
- [Resolve nullable warnings](./common-tasks/resolve-warnings.md)
- [Nullable migration strategies](../../advanced-topics/update-applications/nullable-migration-strategies.md)
- [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md)
- [Resolve nullable warnings (compiler reference)](../../language-reference/compiler-messages/nullable-warnings.md)
