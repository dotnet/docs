# Draft Plan: Fundamentals Restructuring PR Breakdown

**TL;DR:** Break the ~72-article restructuring into ~21 small, independently mergeable PRs organized in proposed TOC order. Each PR touches ≤10 files (articles, snippets, toc.yml, redirects), adds its content to the live TOC immediately, and leaves the section in a publishable state. Every new or revised article follows the example-heavy, modern-feature-saturation style from Goals 3 and 7.

**Conventions for every PR:**
- Update `toc.yml` incrementally so new content is navigable immediately.
- Add redirect entries for every moved file (use the "/.openpublishing/redirection.csharp.json" file).
- All snippet code uses the full "Everyday C#" feature set per the feature tables.
- Prefer file based apps over larger project-based samples for simplicity and ease of understanding, unless a feature requires a more complex setup.
- All code examples are included from external snippet files (no inline code blocks), and every article has a corresponding snippet project.
- Each article follows concept → example → concept → example structure. The concept discussion should include motivating scenarios for the feature or concept being covered.
- Prefer articles that are between a 5 and 10 minute read (roughly 1000–2000 words). Longer and shorter artiles are allowed, but should be the exception.
- Cross reference liberally. However, it's assumed that readers are familiar with content in the "Get started" section. Links to that section should be minimal, and possibly scoped to recommendations for beginners to start there instead. Links and cross references should encourage readers to learn more and dive deeper into the fundamental concepts covered in this section.

## Phase A: Program Structure (§7)

### PR 1 — Program structure: namespaces + preprocessor directives

> ~10 files

1. Revise `fundamentals/program-structure/index.md` — add file-scoped namespaces, global usings as default style
2. Move+revise `fundamentals/types/namespaces.md` → `fundamentals/program-structure/namespaces.md` — add file-scoped namespaces (C# 10), global usings (C# 10), static using (C# 6), type/namespace aliases (subset)
3. New `fundamentals/program-structure/preprocessor-directives.md` — `#if`, `#region`, `#nullable`, `#pragma warning`
4. Snippet files for both new/revised articles
5. toc.yml + redirect for old namespaces path

## Phase B: Type System (§8) — 4 PRs

### PR 2 — Type system: overview, built-in types, enums

> ~10 files

1. Revise `fundamentals/types/index.md` — value vs. reference, unified type system
2. New `fundamentals/types/built-in-types.md` — numeric types (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literals, `default`, `var`, target-typed `new`, `dynamic`
3. New `fundamentals/types/enums.md` — core enum usage and patterns
4. Snippet files + toc.yml

### PR 3 — Type system: classes, structs, records

> ~10 files

1. Revise `fundamentals/types/classes.md` — static classes (C# 2), object/collection initializers (C# 3)
2. New `fundamentals/types/structs.md` — struct design, auto-default (C# 11), parameterless constructors (C# 10), readonly members (C# 8), record structs (C# 10)
3. Revise `fundamentals/types/records.md` — ensure record structs and `with` expressions covered
4. Snippet files + toc.yml

### PR 4 — Type system: tuples, interfaces, generics

> ~10 files

1. Replace `fundamentals/types/anonymous-types.md` → `fundamentals/types/tuples.md` — merge existing tuples + deconstruct content; add inferred names (C# 7.1), tuple comparison (C# 7.3), `with` on tuples. Redirect old URL
2. Revise `fundamentals/types/interfaces.md` — declaring and implementing (exclude default interface members, static abstract members)
3. Revise `fundamentals/types/generics.md` — add collection expressions (C# 12), dictionary expressions (C# 14), spread `..`, co-/contra-variance
4. Snippet files + toc.yml + redirect

### PR 5 — Type system: conversions, delegates/lambdas, records tutorial

> ~10 files

1. New `fundamentals/types/conversions.md` — pull+revise from `programming-guide/types/casting-and-type-conversions.md` and `programming-guide/types/boxing-and-unboxing.md`. Add redirects
2. New `fundamentals/types/delegates-lambdas.md` — `Func<>`/`Action<>`, lambda basics, static lambdas, discard params, brief events intro
3. Pull `tutorials/records.md` → `fundamentals/tutorials/records.md` + redirect
4. Snippet files + toc.yml + redirects

## Phase C: Null Safety — 2 PRs

### PR 6 — Null safety: overview, nullable value types, null operators

> ~10 files

1. Create `fundamentals/null-safety/` directory
2. New `fundamentals/null-safety/index.md` — unified null safety story, NVT vs. NRT comparison
3. New `fundamentals/null-safety/nullable-value-types.md` — `T?` for value types, `HasValue`, `GetValueOrDefault`
4. New `fundamentals/null-safety/null-operators.md` — `?.`, `?[]`, `??`, `??=`, null-conditional assignment, `is null`/`is not null`
5. Snippet files + toc.yml

### PR 7 — Null safety: NRT, warnings, migration, tutorial

> ~10 files

1. Consolidate `fundamentals/null-safety/nullable-reference-types.md` — pull from `nullable-references.md` + `tutorials/nullable-reference-types.md`
2. Pull `fundamentals/null-safety/resolve-warnings.md` — from existing nullable warnings content
3. Pull `fundamentals/null-safety/migration-strategies.md` — from `nullable-migration-strategies.md`
4. Pull `tutorials/nullable-reference-types.md` → `fundamentals/tutorials/nullable-reference-types.md`
5. toc.yml + redirects (4 redirect entries)

## Phase D: Strings — 3 PRs

### PR 8 — Strings: overview, raw strings, nameof

> ~10 files

1. Create `fundamentals/strings/` directory
2. New `fundamentals/strings/index.md` — basics, immutability, `string` vs `String`, verbatim strings, escape sequences, `\e` (C# 13)
3. New `fundamentals/strings/raw-string-literals.md` — `"""` syntax (C# 11), raw interpolated strings
4. New `fundamentals/strings/nameof.md` — `nameof` (C# 6)
5. Snippet files + toc.yml

### PR 9 — Strings: interpolation + search + split

> ~10 files

1. Pull+revise `fundamentals/strings/interpolation.md` — from `tutorials/string-interpolation.md`; add newlines (C# 11), constant interpolated (C# 10)
2. Pull `fundamentals/strings/search.md` — from `how-to/search-strings.md`
3. Pull `fundamentals/strings/split.md` — from `how-to/parse-strings-using-split.md`
4. toc.yml + redirects

### PR 10 — Strings: concatenate, modify, compare, interpolation tutorial

> ~10 files

1. Pull `fundamentals/strings/concatenate.md` — from `how-to/concatenate-multiple-strings.md`
2. Pull `fundamentals/strings/modify.md` — from `how-to/modify-string-contents.md`
3. Pull `fundamentals/strings/compare.md` — from `how-to/compare-strings.md`
4. Pull `tutorials/string-interpolation.md` → `fundamentals/tutorials/string-interpolation.md`
5. toc.yml + redirects

## Phase E: Pattern Matching + Functional (§11–§12) — 2 PRs

### PR 11 — Pattern matching revision

> ~8 files

1. Major revise `fundamentals/functional/pattern-matching.md` — comprehensive coverage of all pattern types through C# 11 list patterns. May split into two articles
2. Revise `fundamentals/functional/deconstruct.md` — records, tuples, custom `Deconstruct`, mixed deconstructions
3. Pull `tutorials/patterns-objects.md` → `fundamentals/tutorials/pattern-matching-explore.md`
4. Updated snippets + toc.yml + redirect

### PR 12 — Functional techniques

> ~10 files

1. Revise `fundamentals/functional/index.md` — (new overview article, C# as multi-paradigm)
2. New `fundamentals/functional/lambdas.md` — closures, captures, expression vs. statement lambdas, method group conversions
3. Pull `fundamentals/functional/local-functions.md` — from `programming-guide/classes-and-structs/local-functions.md`
4. Pull `fundamentals/functional/iterators.md` — from `iterators.md` + `programming-guide/concepts/iterators.md`
5. Snippet files + toc.yml + redirects

## Phase F: Object-Oriented Programming (§15) — 6 PRs

### PR 13 — OOP: overview, access modifiers, fields/constants

> ~10 files

1. Revise `fundamentals/object-oriented/index.md` — the OOP model in C#
2. Pull+revise `fundamentals/object-oriented/access-modifiers.md` — from `programming-guide/classes-and-structs/access-modifiers.md`; add `private protected` (C# 7.2)
3. Pull+merge `fundamentals/object-oriented/fields-constants.md` — from `programming-guide/classes-and-structs/fields.md` + `constants.md`; add backing field attributes (C# 7.3)
4. toc.yml + redirects

### PR 14 — OOP: properties + constructors

> ~10 files

1. Pull+revise `fundamentals/object-oriented/properties.md` — from `programming-guide/classes-and-structs/properties.md` + related; add init-only (C# 9), required (C# 11), `field` keyword (C# 14)
2. Pull+revise `fundamentals/object-oriented/constructors.md` — from `programming-guide/classes-and-structs/constructors.md` + related; add primary constructors (C# 12)
3. toc.yml + redirects

### PR 15 — OOP: methods + lambdas in OOP

> ~10 files

1. Pull+merge `fundamentals/object-oriented/methods.md` — from `programming-guide/classes-and-structs/methods.md` + `methods.md`; add `params` collections (C# 13), expression-bodied
2. New `fundamentals/object-oriented/lambdas-in-oop.md` — `Func<>`/`Action<>` as parameters, callback patterns, event handlers as lambdas
3. Snippet files + toc.yml + redirects

### PR 16 — OOP: inheritance merge + interfaces

> ~10 files

1. Merge `inheritance.md` + `polymorphism.md` into single `inheritance.md` — add covariant returns (C# 9). Redirect polymorphism.md
2. Pull+revise `fundamentals/object-oriented/interfaces.md` — from `programming-guide/interfaces/`; implementing, explicit implementation, interfaces vs. abstract classes
3. toc.yml + redirects

### PR 17 — OOP: indexers, extensions, ranges tutorial

> ~10 files

1. Pull `fundamentals/object-oriented/indexers.md` — from `programming-guide/indexers/`; add ranges and indexes (C# 8)
2. New `fundamentals/object-oriented/extensions.md` — C# 14 extension syntax, extension properties; note legacy `this` syntax
3. Pull `tutorials/ranges-indexes.md` → `fundamentals/tutorials/ranges.md`
4. toc.yml + redirects

### PR 18 — OOP: events, partial types, object lifetime

> ~10 files

1. Pull subset `fundamentals/object-oriented/events.md` — from `programming-guide/events/`; subscribe/unsubscribe, standard pattern only
2. New `fundamentals/object-oriented/partial-types.md` — partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14)
3. New `fundamentals/object-oriented/object-lifetime.md` — `using` statement, `using` declaration (C# 8), dispose pattern
4. Snippet files + toc.yml + redirects

## Phase G: Remaining Sections — 3 PRs

### PR 19 — Async basics + Attributes

> ~8 files

1. Create `fundamentals/async/` directory
2. New `fundamentals/async/consuming-async.md` — `async`/`await`, task-based pattern, async Main (C# 7.1), brief `await foreach`; link to Async focus section
3. New `fundamentals/attributes.md` — common attributes, syntax, targets; defer custom attribute creation
4. Snippet files + toc.yml

### PR 20 — XML docs + Coding style + Console app tutorial

> ~10 files

1. New or pull `fundamentals/xml-comments.md` — `///` comments, common tags
2. Add `coding-style/documenting-code.md` and `coding-style/self-documenting-code.md` to TOC (verify if files already exist; create if not)
3. Pull `tutorials/console-teleprompter.md` → `fundamentals/tutorials/console-app.md` + redirect
4. toc.yml + redirects

### PR 21 — Exceptions modernization pass

> ~9 files

1. Revise all 5 exception articles + 2 tutorials in `fundamentals/exceptions/` for modern feature saturation — update all code samples to use file-scoped namespaces, collection expressions, NRT, raw string literals, primary constructors where natural
2. Updated snippet files
3. toc.yml (reorder to match proposed TOC if needed)

## Verification

- After each PR: verify redirect JSON entries resolve correctly
- After each "pull" PR: confirm the old URL redirects to the new location
- Spot-check 2–3 code samples per PR against the feature checklist (Goals 3 & 7)
- After all PRs: full link-check pass across the Fundamentals section and cross-referencing sections

## Decisions

- *~10 total files per PR* including toc.yml, redirects, and snippets
- *Move + revise in same PR* rather than two-step
- *Incremental TOC updates* — each PR makes its section live immediately
- *Polymorphism → redirect to merged Inheritance article* (PR 16)
- *PRs within a phase are sequential* (e.g., Type system PRs 2→5 go in order); *phases are largely independent* and can run in parallel if multiple authors contribute
