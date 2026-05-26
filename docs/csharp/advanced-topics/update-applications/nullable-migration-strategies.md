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
> **Starting a new project?** New projects created from .NET 6 or later templates already have `<Nullable>enable</Nullable>` set. You don't need a migration strategy: skip to [Resolve nullable warnings](../../fundamentals/null-safety/resolve-warnings.md).
>
> **Maintaining an existing codebase?** Read [Nullable reference types](../../fundamentals/null-safety/nullable-reference-types.md) first to understand contexts, annotations, and null-state. This article assumes you're familiar with those concepts and ready to plan a rollout.

When you turn on nullable reference types on a large project that started before nullable reference types were introduced, the compiler produces many warnings at once. Migration is about *sequencing* the work: choosing a default context, exposing warnings file by file or section by section, and converging on `<Nullable>enable</Nullable>` for the whole project. The right sequence depends on how active the codebase is and how much risk you can take in a single pass.

The end state is the same in every case: the project sets `<Nullable>enable</Nullable>` and contains no `#nullable` preprocessor directives.

## Choose a default context

The nullable context has two independent flags: *annotations* (whether `?` declares a nullable reference type) and *warnings* (whether the compiler emits diagnostics). Set them together as a single `<Nullable>` value:

| Default value          | Annotations | Warnings | Best for                                                              |
| ---------------------- | :---------: | :------: | --------------------------------------------------------------------- |
| `disable` *(implicit)* |   off       |   off    | Stable libraries that won't take new feature work in this pass.       |
| `enable`               |   on        |   on     | Active codebases with frequent new files. New code starts opted in.   |
| `warnings`             |   off       |   on     | Two-phase migration: address warnings first, annotate later.          |
| `annotations`          |   on        |   off    | Annotate the public API before fixing the internal warnings.          |

Pick the strategy that best matches the goals for your project migration:

- **Disable as the default.** Set `<Nullable>disable</Nullable>` and add `#nullable enable` at the top of each file as you migrate it. Existing files stay nullable-oblivious until you touch them. This option has the lowest friction for stable libraries because new feature work is rare.
- **Enable as the default.** Set `<Nullable>enable</Nullable>` and add `#nullable disable` at the top of every file you haven't migrated yet. Every new file is nullable-aware from the start, so the migration backlog can only shrink. This choice is better when development is active.
- **Warnings as the default.** Set `<Nullable>warnings</Nullable>`. Choose this default for a two-phase migration: address warnings while every reference type is still treated as oblivious, then turn on annotations. The two-phase split keeps each step's diff focused.
- **Annotations as the default.** Set `<Nullable>annotations</Nullable>`. Start by annotating your public API (`?` on members that allow `null`) before chasing warnings. The compiler doesn't emit warnings yet, so you can settle the API surface without distraction.

Your project file controls the global default. `#nullable` [preprocessor directives](../../language-reference/preprocessor-directives.md) override that default for a region of code:

:::code language="xml" source="snippets/nullable-migration-strategies/project-snippet.xml":::

Inside source files, the directive opts a region in or out of the project's nullable setting:

:::code language="csharp" source="snippets/nullable-migration-strategies/Program.cs" id="DirectiveOverrides":::

## Migrate file by file

The most predictable way to migrate a large project is to enable warnings or annotations file by file. The pattern is the same regardless of which default you pick:

1. Pick a file. Start with the deepest leaf types in your dependency graph, then move outward. Annotating a type causes new warnings in its callers, so working bottom-up minimizes rework.
1. Add the `#nullable` directive that opts the file into the new behavior. Use `#nullable enable` if you want both flags. Use `#nullable enable warnings` for warning-only.
1. Address the warnings in the file using the techniques in [Resolve nullable warnings](../../fundamentals/null-safety/resolve-warnings.md).
1. Repeat for the next file.
1. When every file in the project has its directive, remove the directives and set `<Nullable>enable</Nullable>` at the project level.

If your codebase already has `<Nullable>enable</Nullable>`, you're driving the *opposite* direction. Suppress warnings in unmigrated files until you're ready. Use `#nullable disable` to opt files out, then remove the suppressions one at a time.

## Migrate in two phases

A two-phase migration separates the two kinds of work that nullable reference types involve. You can sequence the phases either way, depending on which form of stability matters more to you.

### Warnings first, then annotations

Lead with warnings when fixing latent <xref:System.NullReferenceException?displayProperty=nameWithType> bugs is the priority:

1. **Phase 1: Address warnings.** Set the project default to `warnings`. Reference types remain nullable-oblivious, so the type system doesn't change yet. The compiler emits warnings everywhere your existing code might already throw a <xref:System.NullReferenceException?displayProperty=nameWithType>. Add null checks, restructure flow, or apply attributes until the project is warning-clean. Each fix makes the production code more resilient even before annotations exist.
1. **Phase 2: Add annotations.** Switch the project default to `enable`. Reference types are now non-nullable by default, and `var` locals become nullable. New warnings reflect declarations that don't match how the variables are used. Add `?` to types that should allow `null`. Tighten APIs that should require non-null inputs.

### Annotations first, then warnings

Lead with annotations when stabilizing the public API surface is the priority. This sequence suits libraries: you can ship annotated signatures so consumers see the right contracts, then close out the internal warnings on your own schedule.

1. **Phase 1: Add annotations.** Set the project default to `annotations`. Reference types become non-nullable by default, but the compiler doesn't emit warnings, so the noise stays out of your way. Walk the public API and add `?` to every member that may legitimately return or accept `null`. Tighten the signatures that shouldn't. Because warnings are off, you can settle the API shape in focused commits without untangling the implementation at the same time.
1. **Phase 2: Address warnings.** Switch the project default to `enable`. The annotations you added in phase 1 now feed null-state analysis, so the warnings the compiler emits are higher quality from the start: each one points at code whose behavior doesn't match the contract you already published. Resolve them with the techniques in [Resolve nullable warnings](../../fundamentals/null-safety/resolve-warnings.md).

### Choosing between the orderings

Each ordering separates the phases into smaller, more reviewable diffs. One phase changes only behavior, and the other changes only types. The disadvantage is that you visit each file twice. For mature, stable code where every change carries risk, the two passes are usually worth it. Pick *warnings first* when you most want to harden running code. Pick *annotations first* when you most want to publish a stable contract.

## Generated code is excluded

The compiler treats files marked as generated as if the nullable context were disabled, regardless of the project's setting. A file is considered generated when any of the following conditions are true:

- An `.editorconfig` rule sets `generated_code = true` for the file.
- The first comment in the file contains `<auto-generated>` or `<auto-generated/>`.
- The file name starts with `TemporaryGeneratedFile_`.
- The file name ends with `.designer.cs`, `.generated.cs`, `.g.cs`, or `.g.i.cs`.

Generators that produce nullable-aware output can opt back in by emitting `#nullable enable` at the top of the generated file.

## When you're done

After every file participates in the project default and the `<Nullable>enable</Nullable>` element is set:

- Remove every `#nullable` directive in your source.
- Remove `null!` and `default!` initializers that you added only to silence warnings during migration. Replace them with proper initialization, or make type a nullable reference type.
- Spot-check the public API. Every member that returns or accepts `null` should be annotated with `?`. The annotations are part of your contract once the package ships.

You're now in the same state as new projects: nullable reference types are part of the type system, and any new warnings reflect a real mismatch between declarations and code. Use [Resolve nullable warnings](../../fundamentals/null-safety/resolve-warnings.md) to address them as they come up.

## Related content

- [Nullable reference types](../../fundamentals/null-safety/nullable-reference-types.md)
- [Resolve nullable warnings](../../fundamentals/null-safety/resolve-warnings.md)
- [Nullable static analysis attributes](../../language-reference/attributes/nullable-analysis.md)
- [Working with nullable reference types in EF Core](/ef/core/miscellaneous/nullable-reference-types)
