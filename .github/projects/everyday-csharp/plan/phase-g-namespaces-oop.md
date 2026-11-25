> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase G: Namespaces (§14)

> **Approved plan (2026-10-29, Decision 16):** Phase G owns Namespaces alone. The old mixed OOP
> inventory is assigned to standard-aligned construct phases and Building software.
> Namespace consolidation is complete; subsequent OOP redistribution stays with its assigned phases.
> PR #56333's shipped Building software placement isn't reopened. No later phase is started here.

### PR 24 — Namespaces (CONSOLIDATE, Decision 12b)

**✅ Shipped:** [dotnet/docs#56771](https://github.com/dotnet/docs/pull/56771), opened 2026-11-05,
merged 2026-11-12 at [`678c15c744ffe9f18ad6d721a9553635f755db41`](https://github.com/dotnet/docs/commit/678c15c744ffe9f18ad6d721a9553635f755db41),
closes [#56747](https://github.com/dotnet/docs/issues/56747). Reconciled **2026-11-16** against
the final merged diff, final files, and public review threads, not an intermediate draft.
The rebased planning checkout matches the merged namespace articles, snippets, TOC, and redirects.

> **As shipped:** 16 changed files, including 10 snippet/project files; no files deleted or moved.
> This replaces the earlier ~5-file estimate, not the scope of later phases.

**Outcome:** After expressions/statements/patterns, readers can organize types and resolve a
naming collision before deeper class work. G is a completed checkpoint in the
[execution sequence](README.md#execution-sequence); H follows it, with PR 25's later framework
delivery recorded in [Legacy PR routing](#legacy-pr-routing).

| Delivered unit | Final owner and scope | Evidence at completion |
|---|---|---|
| Canonical depth | [Organize types with namespaces](../../../../docs/csharp/fundamentals/namespaces/overview.md), H1 and TOC title, at `fundamentals/namespaces/overview.md`. | Growth → organization → file-scoped declarations; global namespace early; repeated matching declarations, nested/dotted names, qualification, simple names, aliases, and project/file import choices. |
| Early orientation | [Namespaces and using directives](../../../../docs/csharp/fundamentals/program-structure/namespaces.md) remains a complete short introduction at its existing URL. | Simplified `Greeter` example, declarations/imports recognized in context, implicit-usings orientation, and onward link to depth; no redirect from this retained URL. |
| Navigation and reference | `docs/csharp/toc.yml` adds Namespaces → Organize types with namespaces after Build software and before Object-oriented programming. | Program-structure entry remains at lines 40-41; new depth entry is at lines 163-166 in the merge. Both `language-reference/keywords/namespace.md` and `using-directive.md` now link to depth. |

### Shipped teaching scope

- Small programs needn't declare a named namespace. Introduce the global namespace before named
  declarations, then motivate organization as programs grow; prefer file-scoped declarations for
  the common one-namespace-per-file layout.
- Matching namespace declarations can repeat across a program, including the same file-scoped
  namespace in different files. A file-scoped declaration still can't share its file with another
  namespace declaration or top-level statements. Folder names don't assign namespaces.
- Explain dotted components through both dotted declarations and nested blocks. The hierarchy
  groups names, not inheritance or private-member access.
- Start type lookup with qualification; define simple names before imports and ambiguity.
  Show type and namespace aliases, including tuple aliases; aliases don't create new types.
  Imports cover directly contained types, not nested namespaces.
- Choose SDK implicit imports, explicit global imports, regular imports, then static imports.
  SDK-generated defaults depend on project type; global imports apply to the same compilation,
  typically a project, not referencing projects. Regular imports apply to a file or namespace body.
- Keep project/assembly/package references in a short note: neither an import nor a fully
  qualified name adds a reference. `global::` gets a brief explanation and reference link;
  `extern alias` only a pointer. No assembly-loading tutorial or binding-rule catalog shipped.

### Snippets and source disposition

The depth article **reuses**, rather than relocates, the existing
`docs/csharp/fundamentals/program-structure/snippets/namespaces/namespaces.csproj`
(`net10.0`, nullable and implicit usings enabled). No separate namespace-depth project was created.
The project now selects equivalent `Customer` definitions with `NamespaceStyle=FileScoped`
(default, excludes `BlockScoped.cs`) or `NamespaceStyle=BlockScoped`
(excludes `FileScopedExample.cs`).

- Added `Products.cs` (`NestedNamespaces`), `ProductNames.cs` (`QualifiedNames`, `Aliases`),
  `Imports.cs` (`UsingDirective`), and `GlobalMessage.cs` (`GlobalUsingConsumer`).
- Revised `Basics.cs`, `BlockScoped.cs`, `FileScopedExample.cs`, `GlobalUsings.cs` (only
  `System.Text`), `TupleAlias.cs` (`System.Math`), and the project selection above.
  Existing `Aliases.cs` and `StaticUsing.cs` remain in use; the driver exercises the examples.
- The harvested source is PR 1's namespace introduction. Its declaration/import depth is
  consolidated into the new article; its early teaching role and snippet home remain.
  **No Programming Guide article or class/OOP/reflection source was deleted, moved, or
  completed by #56771.** Preserve class/member sources for H, applied extracts for R and BS12's
  [shared-source holds](programming-guide-inventory.md#shared-source-retirement-holds), and
  reflection/attribute work for [O](phase-o-attributes.md). The namespace checkpoint doesn't
  authorize wholesale OOP redistribution or start applied drafting before P.

### Redirects as shipped

Five **existing** entries in `.openpublishing.redirection.csharp.json` were retargeted to
`/dotnet/csharp/fundamentals/namespaces/overview`:
`docs/csharp/fundamentals/types/namespaces.md`, `docs/csharp/namespaces-and-assemblies.md`,
and `docs/csharp/programming-guide/namespaces/{index,using-namespaces,how-to-use-the-my-namespace}.md`.
Those legacy sources were already retired before this PR; retargeting isn't a new deletion.
The retained `program-structure/namespaces.md` is not redirected.

### Review lessons and evidence limits

The final article implements the supplied November 9 review summary's motivation-first opening,
early global namespace, simple-name terminology, import ordering, and short reference note.
The supplied November 10 Cray/Harrison checkpoint reported no substantive reader stalls and
supported growth → organization → file-scoped declarations; the conclusion explicitly contrasts
project-wide global imports with per-file regular imports. These are presentation lessons,
not new requirements to rewrite adjacent articles.

Public review independently confirms clarification of
[direct versus nested namespace imports](https://github.com/dotnet/docs/pull/56771#discussion_r4553616819),
[SDK-generated implicit imports](https://github.com/dotnet/docs/pull/56771#discussion_r4530295535),
and [same-compilation global scope](https://github.com/dotnet/docs/pull/56771#discussion_r4530302349).
The customer-intent metadata was expanded after a reviewer questioned project-import scope;
the content remained. Final review also [standardized code formatting for `using`](https://github.com/dotnet/docs/pull/56771#discussion_r4553690815),
except when defining a multi-word term. Genevieve Warren approved on November 10 and 12.

The [linked November 9 gist](https://gist.github.com/BillWagner/4090a4881790e92cda694bb8486df553)
returned 404 through both GitHub API and web retrieval on 2026-11-16 (and `gh gist view` returned
not found). Its review history couldn't be independently re-read; the supplied summary above
is distinguished from the verified final files and public PR reviews. No unresolved design
choice or navigation/redirect repair is inferred from that access limitation.

## Legacy PR routing

Historical identifiers are retained; their work isn't scheduled twice.

**Later delivery, reconciled 2026-11-25:** PR 25's class/record framework shipped in
[#56923](https://github.com/dotnet/docs/pull/56923), not under the historical
`object-oriented/` destinations below. [Phase H](phase-h-classes.md) records the three new
`fundamentals/classes/` articles, revised introductions, and two source retirements.
PR 26-28 and later class follow-ons remain; the OOP index only gains a repaired member link.

| Legacy task | Current plan owner |
|---|---|
| PR 25-28: class members | [Phase H](phase-h-classes.md); design extracts in [BS02-BS04](phase-r-building-software.md) |
| PR 29: inheritance plus interfaces | Inheritance in [Phase H](phase-h-classes.md); interfaces in [PR 41](phase-k-interfaces.md); design in BS01/BS05 |
| PR 30: indexers, extensions, ranges | [Phase J](phase-j-arrays-indexes-ranges.md); extensions in [PR 46](phase-h-classes.md#pr-46--extension-members) |
| PR 31: events plus partial types | Partial types in [Phase H](phase-h-classes.md); events in [PR 44](phase-m-delegates.md#pr-44--basic-events) |
| PR 32: object lifetime | [BS07 / PR 32](phase-r-building-software.md#bs07--resource-ownership-and-lifetime-legacy-pr-32) |
| PR 33: encapsulation/composition | [BS01 / PR 33](phase-r-building-software.md#bs01--object-roles-encapsulation-and-composition-legacy-pr-33) |

The following historical inventory is retained for traceability only. Its `object-oriented/`
destinations and mixed task boundaries are superseded by the linked plans above.

<details>
<summary>Historical OOP inventory (superseded, not an additional delivery list)</summary>

### Historical PR 25 — OOP: overview, access modifiers, fields/constants

> Split the paradigm overview (Part 2 candidate) from access-modifier, field, and constant construct
> coverage (Part 1 candidates).

> ~10 files

1. Revise `fundamentals/object-oriented/index.md` — the OOP model in C#
2. Pull+revise `fundamentals/object-oriented/access-modifiers.md` — from `programming-guide/classes-and-structs/access-modifiers.md`; add `private protected` (C# 7.2)
3. Pull+merge `fundamentals/object-oriented/fields-constants.md` — from `programming-guide/classes-and-structs/fields.md` + `constants.md`; add backing field attributes (C# 7.3)
4. toc.yml + redirects

> *Watch for redistribution:* the existing fields content includes `volatile`, `readonly` interaction with structs in detail, `fixed`-size buffers, and ref fields — all of which fail universality. Move those sub-sections to Language Reference (`volatile`, `fixed`) or a memory-model deep dive (ref fields, low-level field semantics). Keep Fundamentals on declaring and using fields and constants.

### Historical PR 26 — OOP: properties

> ~6 files

1. Pull+revise `fundamentals/object-oriented/properties.md` — from `programming-guide/classes-and-structs/properties.md` + related; add init-only (C# 9), required (C# 11), `field` keyword (C# 14)
2. Snippet files + toc.yml + redirects

### Historical PR 27 — OOP: constructors

> ~6 files

1. Pull+revise `fundamentals/object-oriented/constructors.md` — from `programming-guide/classes-and-structs/constructors.md` + related; add primary constructors (C# 12)
2. Snippet files + toc.yml + redirects

> *Split rationale:* the properties article carries three substantial new features (init-only, required, `field`) and the constructors article carries primary constructors plus the redistribution of static-constructor ordering rules. Each is a focused topic with its own snippet code; combining them produced a PR that was both wide and deep.

> *Watch for redistribution:* the existing property and constructor content includes `ref` returns from properties, indexed properties on COM interop, `[ModuleInitializer]`, and detailed static-constructor ordering rules. Those sub-sections fail universality — move them to Language Reference (ref returns, static-constructor ordering, module initializers) or COM-interop content. Keep Fundamentals on declaring properties (including init-only, required, and `field`) and writing instance/primary constructors.

### Historical PR 28 — OOP: methods + lambdas in OOP

> Methods are a Part 1 construct candidate. Callback, event-handler, and API-design guidance is a
> Part 2 candidate.

> ~10 files

1. Pull+merge `fundamentals/object-oriented/methods.md` — from `programming-guide/classes-and-structs/methods.md` + `methods.md`; add `params` collections (C# 13), expression-bodied
2. New `fundamentals/object-oriented/lambdas-in-oop.md` — `Func<>`/`Action<>` as parameters, callback patterns, event handlers as lambdas
3. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing methods content includes `ref readonly` parameters, `in` parameters, conditional methods (`[Conditional]`), method-resolution and overload-resolution rule details, and unsafe-context interactions. Those fail universality — move them to Language Reference (overload resolution, conditional methods, parameter modifiers) or an interop/unsafe deep dive. Keep the Fundamentals methods article on declaring methods, parameter passing, optional and named arguments, and `params`.

### Historical PR 29 — OOP: inheritance merge + interfaces

> Keep declaration and dispatch mechanics in Part 1; classify interfaces-versus-abstract-classes and
> inheritance design guidance for Part 2.

> ~10 files

1. Merge `inheritance.md` + `polymorphism.md` into single `inheritance.md` — add covariant returns (C# 9). Redirect polymorphism.md
2. Pull+revise `fundamentals/object-oriented/interfaces.md` — from `programming-guide/interfaces/`; implementing, explicit implementation, interfaces vs. abstract classes
3. toc.yml + redirects

### Historical PR 30 — OOP: indexers, extensions, ranges tutorial

> ~10 files

1. Pull `fundamentals/object-oriented/indexers.md` — from `programming-guide/indexers/`; add ranges and indexes (C# 8)
2. New `fundamentals/object-oriented/extensions.md` — C# 14 extension syntax, extension properties; note legacy `this` syntax
3. Pull `tutorials/ranges-indexes.md` → `fundamentals/tutorials/ranges.md`
4. toc.yml + redirects

### Historical PR 31 — OOP: events + partial types

> ~6 files

1. Pull subset `fundamentals/object-oriented/events.md` — from `programming-guide/events/`; subscribe/unsubscribe, standard pattern only
2. New `fundamentals/object-oriented/partial-types.md` — partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14)
3. Snippet files + toc.yml + redirects

### Historical PR 32 — OOP: object lifetime

> ~5 files

1. New `fundamentals/object-oriented/object-lifetime.md` — `using` statement, `using` declaration (C# 8), dispose pattern
2. Snippet files + toc.yml

> *Split rationale:* events and partial types are both type-shape topics with shared snippet patterns; object lifetime is a separate concern about resource management with substantial redistribution work (full dispose pattern, finalizers, `SafeHandle`, async-dispose authoring all move to a deep dive). Splitting lets reviewers focus on one concern per PR.

> *Watch for redistribution:* the existing events content includes custom event accessors, weak-event patterns, and threading rules around event invocation — move those to an OOP deep dive. The full dispose pattern (finalizers, `SafeHandle`, suppress-finalize ordering, async-dispose authoring) and detailed garbage-collection interaction also fail universality — move them to a Deep dives article or the existing GC/Standard library content. Keep Fundamentals on subscribing to and raising events with the standard pattern, and on `using`/`using` declarations plus a brief "implement `IDisposable` when you wrap an unmanaged resource" pointer.

### Historical PR 33 — OOP: encapsulation and composition

> Part 2 guidance candidate; don't use it to define the canonical home for class or inheritance
> syntax.

> ~6 files

1. New `fundamentals/object-oriented/encapsulation-composition.md` — encapsulation as information hiding; composition over inheritance; combining objects to build complex behavior; comparison with inheritance-based designs
2. Snippet files + toc.yml

</details>
