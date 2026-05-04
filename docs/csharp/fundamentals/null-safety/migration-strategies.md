---
title: Nullable migration strategies
description: Learn how to enable nullable reference types in an existing C# codebase. Choose a default context, address warnings progressively, and fully migrate.
ms.date: 05/04/2026
ms.topic: concept-article
ms.subservice: null-safety
ai-usage: ai-assisted
---
# Nullable migration strategies

> [!TIP]
> **Starting a new project?** New projects created from .NET 6 or later templates already have `<Nullable>enable</Nullable>` set. You don't need a migration strategy—skip to [Resolve nullable warnings](resolve-warnings.md).
>
> **Maintaining an existing codebase?** Read [Nullable reference types](nullable-reference-types.md) first to understand contexts, annotations, and null-state. This article assumes you're familiar with those concepts and ready to plan a rollout.

When you turn on nullable reference types in a project that wasn't built for the feature, the compiler produces many warnings at once. Migration is about *sequencing* the work: choosing a default context, exposing warnings file by file or section by section, and converging on `<Nullable>enable</Nullable>` for the whole project. The right sequence depends on how active the codebase is and how much risk you can take in a single pass.

The end state is the same in every case—the project sets `<Nullable>enable</Nullable>` and contains no `#nullable` preprocessor directives.

## Choose a default context

The nullable context has two independent flags: *annotations* (whether `?` declares a nullable reference type) and *warnings* (whether the compiler emits diagnostics). You set them together as a single `<Nullable>` value:

| Default value         | Annotations | Warnings | Best for                                                              |
| --------------------- | :---------: | :------: | --------------------------------------------------------------------- |
| `disable` *(implicit)* |   off       |   off    | Stable libraries that won't take new feature work in this pass.        |
| `enable`              |   on        |   on     | Active codebases with frequent new files. New code starts opted in.   |
| `warnings`            |   off       |   on     | Two-phase migration: address warnings first, annotate later.          |
| `annotations`         |   on        |   off    | Annotate the public API before fixing the internal warnings.          |

Pick the strategy that makes the next file you create do the right thing automatically:

- **Disable as the default.** Add `#nullable enable` at the top of each file as you migrate it. Existing files stay nullable-oblivious until you touch them. This is the lowest-friction option for stable libraries because new feature work is rare.
- **Enable as the default.** Set `<Nullable>enable</Nullable>` and add `#nullable disable` at the top of every file you haven't migrated yet. Every new file is nullable-aware from the start, so the migration backlog can only shrink. This is the better choice when development is active.
- **Warnings as the default.** Choose this default for a two-phase migration: address warnings while every reference type is still treated as oblivious, then turn on annotations. The two-phase split keeps each step's diff focused.
- **Annotations as the default.** Start by annotating your public API (`?` on members that allow `null`) before chasing warnings. The compiler doesn't emit warnings yet, so you can settle the API surface without distraction.

Your project file controls the global default. The `#nullable` preprocessor directives override it locally:

:::code language="xml" source="snippets/migration-strategies/project-snippet.xml":::

:::code language="csharp" source="snippets/migration-strategies/Program.cs" id="DirectiveOverrides":::

## Migrate file by file

The most predictable way to migrate a large project is to enable warnings or annotations file by file. The pattern is the same regardless of which default you picked:

1. Pick a file. Start with the deepest leaf types in your dependency graph, then move outward. Annotating a type causes new warnings in its callers, so working bottom-up minimizes rework.
1. Add the `#nullable` directive that opts the file into the new behavior. Use `#nullable enable` if you want both flags. Use `#nullable enable warnings` for warning-only.
1. Address the warnings in the file using the techniques in [Resolve nullable warnings](resolve-warnings.md).
1. Repeat for the next file.
1. When every file in the project has its directive, remove the directives and set `<Nullable>enable</Nullable>` at the project level.

If your codebase already has `<Nullable>enable</Nullable>` and you're driving the *opposite* direction—suppressing warnings in unmigrated files until you're ready—use `#nullable disable` to opt files out, then remove the suppressions one at a time.

## Migrate in two phases

A two-phase migration separates the two kinds of work that nullable reference types involve:

1. **Phase 1 — Address warnings.** Set the project default to `warnings`. Reference types remain nullable-oblivious, so the type system doesn't change yet. The compiler emits warnings everywhere your existing code might already throw a <xref:System.NullReferenceException?displayProperty=nameWithType>. Add null checks, restructure flow, or apply attributes until the project is warning-clean. Each fix makes the production code more resilient even before annotations exist.
1. **Phase 2 — Add annotations.** Switch the project default to `enable`. Reference types are now non-nullable by default, and `var` locals become nullable. New warnings reflect declarations that don't match how the variables are used. Add `?` to types that should allow `null`. Tighten APIs that should require non-null inputs.

The advantage of separating the phases is that each diff is smaller and reviewable. Phase 1 changes only behavior; phase 2 changes only types. The disadvantage is that you visit each file twice. For mature, stable code where every change carries risk, the two passes are usually worth it.

## Generated code is excluded

The compiler treats files marked as generated as if the nullable context were disabled, regardless of the project's setting. A file is considered generated when any of the following is true:

- An `.editorconfig` rule sets `generated_code = true` for the file.
- The first comment in the file contains `<auto-generated>` or `<auto-generated/>`.
- The file name starts with `TemporaryGeneratedFile_`.
- The file name ends with `.designer.cs`, `.generated.cs`, `.g.cs`, or `.g.i.cs`.

Generators that produce nullable-aware output can opt back in by emitting `#nullable enable` at the top of the generated file.

## When you're done

After every file participates in the project default and the `<Nullable>enable</Nullable>` element is set:

- Remove every `#nullable` directive in your source.
- Remove `null!` and `default!` initializers that you added only to silence warnings during migration. Replace them with proper initialization, or change the member type to nullable.
- Spot-check the public API. Every member that returns or accepts `null` should be annotated with `?`. The annotations are part of your contract once the package ships.

You're now in the same state as new projects: nullable reference types are part of the type system, and any new warnings reflect a real mismatch between declarations and code. Use [Resolve nullable warnings](resolve-warnings.md) to address them as they come up.

## Related content

- [Nullable reference types](nullable-reference-types.md)
- [Resolve nullable warnings](resolve-warnings.md)
- [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md)
- [Working with nullable reference types in EF Core](/ef/core/miscellaneous/nullable-reference-types)
