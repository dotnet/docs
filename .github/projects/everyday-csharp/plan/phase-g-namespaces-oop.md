> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase G: Namespaces (§14) + Object-Oriented Programming (§15) — 10 PRs

### PR 24 — Namespaces (CONSOLIDATE, Decision 12b)

> ~5 files

1. New `fundamentals/namespaces/overview.md` — **canonical §14 Namespaces article**: motivation for using namespaces to organize programs and libraries; declaring namespaces; file-scoped namespaces (C# 10); importing with `using`; `global using` directives; namespace aliases; nested namespaces
2. **Slim the already-shipped `fundamentals/program-structure/namespaces.md`** to a brief intro + cross-reference to the canonical article (avoid duplicate coverage). This is a build-clean change to shipped content — **add a redirect and fix inbound links** that pointed at the program-structure article
3. Snippet files + toc.yml + redirect + inbound-link fix

> *Consolidation rationale (2b):* §14 Namespaces gets one canonical home under `fundamentals/namespaces/`.
> The Program-structure "Namespaces and using directives" article (shipped in PR 1) is reduced to a short
> orientation pointer so beginners meet the concept early without the section duplicating the full §14
> treatment. Because the program-structure article already shipped, verify the build stays clean:
> add the redirect and update every inbound cross-link.

> *Coherence check:* after this PR §14 has exactly one canonical article (`namespaces/overview.md`);
> the shipped `program-structure/namespaces.md` is a slim intro + cross-reference (not a stub — it
> still reads as a complete short article and routes onward); redirect + repo-wide inbound-link fixes
> land in this same PR, so nothing is duplicated, orphaned, or broken after merge.

### PR 25 — OOP: overview, access modifiers, fields/constants

> ~10 files

1. Revise `fundamentals/object-oriented/index.md` — the OOP model in C#
2. Pull+revise `fundamentals/object-oriented/access-modifiers.md` — from `programming-guide/classes-and-structs/access-modifiers.md`; add `private protected` (C# 7.2)
3. Pull+merge `fundamentals/object-oriented/fields-constants.md` — from `programming-guide/classes-and-structs/fields.md` + `constants.md`; add backing field attributes (C# 7.3)
4. toc.yml + redirects

> *Watch for redistribution:* the existing fields content includes `volatile`, `readonly` interaction with structs in detail, `fixed`-size buffers, and ref fields — all of which fail universality. Move those sub-sections to Language Reference (`volatile`, `fixed`) or a memory-model deep dive (ref fields, low-level field semantics). Keep Fundamentals on declaring and using fields and constants.

### PR 26 — OOP: properties

> ~6 files

1. Pull+revise `fundamentals/object-oriented/properties.md` — from `programming-guide/classes-and-structs/properties.md` + related; add init-only (C# 9), required (C# 11), `field` keyword (C# 14)
2. Snippet files + toc.yml + redirects

### PR 27 — OOP: constructors

> ~6 files

1. Pull+revise `fundamentals/object-oriented/constructors.md` — from `programming-guide/classes-and-structs/constructors.md` + related; add primary constructors (C# 12)
2. Snippet files + toc.yml + redirects

> *Split rationale:* the properties article carries three substantial new features (init-only, required, `field`) and the constructors article carries primary constructors plus the redistribution of static-constructor ordering rules. Each is a focused topic with its own snippet code; combining them produced a PR that was both wide and deep.

> *Watch for redistribution:* the existing property and constructor content includes `ref` returns from properties, indexed properties on COM interop, `[ModuleInitializer]`, and detailed static-constructor ordering rules. Those sub-sections fail universality — move them to Language Reference (ref returns, static-constructor ordering, module initializers) or COM-interop content. Keep Fundamentals on declaring properties (including init-only, required, and `field`) and writing instance/primary constructors.

### PR 28 — OOP: methods + lambdas in OOP

> ~10 files

1. Pull+merge `fundamentals/object-oriented/methods.md` — from `programming-guide/classes-and-structs/methods.md` + `methods.md`; add `params` collections (C# 13), expression-bodied
2. New `fundamentals/object-oriented/lambdas-in-oop.md` — `Func<>`/`Action<>` as parameters, callback patterns, event handlers as lambdas
3. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing methods content includes `ref readonly` parameters, `in` parameters, conditional methods (`[Conditional]`), method-resolution and overload-resolution rule details, and unsafe-context interactions. Those fail universality — move them to Language Reference (overload resolution, conditional methods, parameter modifiers) or an interop/unsafe deep dive. Keep the Fundamentals methods article on declaring methods, parameter passing, optional and named arguments, and `params`.

### PR 29 — OOP: inheritance merge + interfaces

> ~10 files

1. Merge `inheritance.md` + `polymorphism.md` into single `inheritance.md` — add covariant returns (C# 9). Redirect polymorphism.md
2. Pull+revise `fundamentals/object-oriented/interfaces.md` — from `programming-guide/interfaces/`; implementing, explicit implementation, interfaces vs. abstract classes
3. toc.yml + redirects

### PR 30 — OOP: indexers, extensions, ranges tutorial

> ~10 files

1. Pull `fundamentals/object-oriented/indexers.md` — from `programming-guide/indexers/`; add ranges and indexes (C# 8)
2. New `fundamentals/object-oriented/extensions.md` — C# 14 extension syntax, extension properties; note legacy `this` syntax
3. Pull `tutorials/ranges-indexes.md` → `fundamentals/tutorials/ranges.md`
4. toc.yml + redirects

### PR 31 — OOP: events + partial types

> ~6 files

1. Pull subset `fundamentals/object-oriented/events.md` — from `programming-guide/events/`; subscribe/unsubscribe, standard pattern only
2. New `fundamentals/object-oriented/partial-types.md` — partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14)
3. Snippet files + toc.yml + redirects

### PR 32 — OOP: object lifetime

> ~5 files

1. New `fundamentals/object-oriented/object-lifetime.md` — `using` statement, `using` declaration (C# 8), dispose pattern
2. Snippet files + toc.yml

> *Split rationale:* events and partial types are both type-shape topics with shared snippet patterns; object lifetime is a separate concern about resource management with substantial redistribution work (full dispose pattern, finalizers, `SafeHandle`, async-dispose authoring all move to a deep dive). Splitting lets reviewers focus on one concern per PR.

> *Watch for redistribution:* the existing events content includes custom event accessors, weak-event patterns, and threading rules around event invocation — move those to an OOP deep dive. The full dispose pattern (finalizers, `SafeHandle`, suppress-finalize ordering, async-dispose authoring) and detailed garbage-collection interaction also fail universality — move them to a Deep dives article or the existing GC/Standard library content. Keep Fundamentals on subscribing to and raising events with the standard pattern, and on `using`/`using` declarations plus a brief "implement `IDisposable` when you wrap an unmanaged resource" pointer.

### PR 33 — OOP: encapsulation and composition

> ~6 files

1. New `fundamentals/object-oriented/encapsulation-composition.md` — encapsulation as information hiding; composition over inheritance; combining objects to build complex behavior; comparison with inheritance-based designs
2. Snippet files + toc.yml

