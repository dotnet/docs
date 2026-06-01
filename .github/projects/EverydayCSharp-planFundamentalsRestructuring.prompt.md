# Draft Plan: Fundamentals Restructuring PR Breakdown

**TL;DR:** Break the ~91-article restructuring into ~35 small, independently mergeable PRs organized in proposed TOC order. Each PR aims for ~10 files (articles, snippets, toc.yml, redirects), adds its content to the live TOC immediately, and leaves the section in a publishable state. PR file budgets are advisory: a PR may exceed ~10 files when relocating text to other sections is the right call (Goal 11), and PRs that grow too large are split along a natural seam using letter suffixes (for example, PR 14a / PR 14b) so downstream PR numbers stay stable. Every new or revised article follows the example-heavy, latest-version-saturation style from Goals 4 and 8.

**Conventions for every PR:**

The Fundamentals audience is a developer who knows another language and is learning C#. An alternative audience is a new developer that has only months of experience with C# as their first programming language. They don't yet have C# vocabulary, can't recognize C#-specific idioms on sight, and don't share the project context an experienced C# developer takes for granted. The conventions below are grouped by the audience-derived principle they serve so each one's *why* stays visible.

*Sample readability (P1) — write samples that a new C# developer can read line-by-line:*

- All code examples are included from external snippet files (no inline code blocks), and every article has a corresponding snippet project.
- All snippet code uses the full "Everyday C#" feature set per the feature tables.
- Prefer file-based apps over larger project-based samples for simplicity and ease of understanding, unless a feature requires a more complex setup.
- For any construct the sample isn't teaching, pick the most familiar form: use `while` or `foreach` before `for` (reserve `for` for explicit index iteration); use a regular method before a static factory unless the article is about factories.
- Add a brief intent comment on any line whose purpose isn't immediately obvious — for example, lines like `_ = something;` or a literal argument with hidden significance.
- When a sample illustrates a decision, show *both* branches and include the result as a trailing comment (`// => …`) so readers correlate code to output without running it.
- Never place consecutive code snippets. They are hard to read and harder for readers to follow. Either intersperse explanatory text between snippets or combine related snippets into a single example.

*Terminology (P2) — treat every C# term as new until the article defines it:*

- Define concepts when they are first introduced. Don't assume readers know what a "type" or "namespace" is before those concepts are covered in the proposed TOC. Remember that this is "fundamentals" content. Any term likely to be unfamiliar to a new C# developer should be defined inline at first use — one short sentence — with a link to the deeper reference. This applies to terms the author considers obvious (for example, *dereference*, *type parameter* vs. *type argument*, *primary constructor*), not just terms the author considers new.
- When a symbol's meaning depends on context (`T?` differs between value types, constrained reference types, and unconstrained generics), spell out which form you mean before listing rules. Lead a constraints discussion with a one-line model of what is being constrained.
- Definitions are less important for concepts that aren't related to the C# language. The goal for Fundamentals is to teach readers how C# works. While we teach through examples, the libraries and packages used in the examples are less important than the language features being demonstrated. For example, when teaching about collections, it's more important to explain what a collection is and how to use them in C# than to provide an in-depth explanation of `List<T>` vs. `Dictionary<K,V>`.
- Cross reference liberally. It's assumed readers are familiar with content in the "Get started" section, so links there should be minimal and scoped to recommendations for beginners to start there instead. Links and cross references should encourage readers to learn more and dive deeper into the fundamental concepts covered in this section.
- If and only if a feature was first added in one of the last three released versions (C# 12–14), mention when it was first introduced.

*Reader's project frame (P3) — default to a current project, and teach how to verify settings:*

- Lead with the current-project assumption. "New projects from recent templates set `<Nullable>enable</Nullable>` in the project file" is the default framing for any setup or configuration statement — no opening hedge.
- Immediately follow such statements with a one- or two-sentence pointer that shows existing-project readers where to verify the setting in their own `.csproj` and how to enable it if it's missing.
- Reserve full migration guidance for the migration articles. When the existing-project path is more than a setting check (for example, planning a phased rollout), link out rather than inlining the strategy.
- When a feature is recommended as the fix for a diagnostic, run the code and confirm the diagnostic actually clears in the scenario being recommended. Reviewer skepticism ("does that actually work here?") usually means the verification wasn't done.
- When recommending a modern feature over an older alternative, always include a justification — state *why* the recommended approach is preferred. Never describe older features as obsolete or deprecated (Goal 9).

*Scope discipline (P4) — every section must earn its place in Fundamentals:*

- Apply the two-criteria fit test (Goal 11) to every section, not just every article. *Filter A — universality:* used by almost all C# developers almost all of the time. *Filter B — accessibility:* readable by a developer with less than one month of .NET and C# experience given the Fundamentals coverage that precedes the article.
- When a section fails Filter A, *cut the text from the Fundamentals draft and paste it into the most appropriate existing destination article* (Language Reference, a Deep dives section, or an Advanced section), with light editing for fit. Don't delete the content — pulled articles often carry valuable detail that simply belongs elsewhere. The canonical example is the nullable-reference-type migration article in PR 9: it targets large pre-C# 8 codebases and fails universality, so its migration-strategy text stays in the existing migration article and the Fundamentals NRT article links out instead of inlining.
- When an *entire* article fails Filter A, don't pull it into Fundamentals at all. Document the decision as an explicit "leave in place" line item in the affected PR, with a one-line reason. Revisit when that area of the docs is restructured.
- When content fails Filter B but passes Filter A, *rewrite — don't exclude.* Define vocabulary at first use, simplify the example, and lead with motivation. Accessibility failures are an editing problem, not a scoping problem.
- Identify destinations at planning time, not at review time. If a PR's draft includes redistributed sections, name the destination files in the PR description before writing so reviewers see the full picture and the destinations don't drift.
- Accept that redistribution may push a PR's file count above the ~10-file target. Exceeding the budget is acceptable when the alternative is losing content or merging an off-topic Fundamentals article. If the PR grows too large, split it along a natural seam (see the *Mechanics* group below).

*Structural hygiene that supports the principles above:*

- Each article follows concept → example → concept → example structure. The concept discussion should include motivating scenarios for the feature or concept being covered.
- One topic per paragraph. A new case (for example, "the same pitfall also applies to arrays of structs") starts a new paragraph.
- Promote a bold paragraph-lead to `###` when it anchors more than one paragraph of content. Inline bold disappears in the TOC and is harder to scan.
- Replace long "the rule is simple" prose with a short structured rule — a one-sentence lead, bold trigger words, then a two- or three-bullet list or a labeled example.
- Prefer articles that are between a 5- and 10-minute read (roughly 1000–2000 words). Longer and shorter articles are allowed, but should be the exception.

*Mechanics — TOC, metadata, links, redirects:*

- Update `toc.yml` incrementally so new content is navigable immediately.
- Add redirect entries for every moved file (use the "/.openpublishing/redirection.csharp.json" file).
- Every article must include a tip near the top that identifies where the article sits in the four-tier content structure (*Get started* → *Fundamentals* → *Deep dives* → *Reference*), describes who it's written for, and routes readers to the right tier based on their experience level (Goal 1).
- Set the `ms.topic` metadata value in each article's YAML front matter to match the article's content type (`overview`, `tutorial`, `concept`, `how-to`, `troubleshooting`, or `reference`).
- After writing content, verify the article's structure, required metadata, and sections against the template for its content type (see the [Include major topic types](EverydayCSharp-ProjectMap.md#include-major-topic-types) table for template links). This is mandatory for every article before it can be merged to ensure consistency and completeness across the Fundamentals section.
- Do not add F1 or helpviewer keywords to Fundamentals articles. When pulling content from the Reference section, remove any F1 or helpviewer keywords.
- Do not add links to files that will be created in future PRs until those files are live. For example, if PR 3 creates the `fundamentals/types/enums.md` article, then earlier PRs should not link to that file until PR 3 is merged. This may require some temporary duplication of content or placeholders for links, but it will prevent broken links in merged PRs. Instead, when an article is created, add appropriate links to it in earlier articles as needed to connect the content together.
- Every PR description lists redistributed content explicitly. For each section moved out of the Fundamentals draft, name the source (which planned Fundamentals article it was cut from), the destination (file path), and a one-line reason — formatted as `source draft article → destination file path → reason`. This keeps the trail visible for downstream review and for future restructuring of the destination area.
- Follow the *Fundamentals folder layout convention*: each section's `index.md` and concept articles live at the section's top level (for example, `fundamentals/strings/interpolation.md`); task-style articles ("how do I do X?") are grouped under a `<section>/common-tasks/` subfolder (for example, `fundamentals/strings/common-tasks/search.md`) with their snippets under `<section>/common-tasks/snippets/`; tutorials live flat under `fundamentals/tutorials/` rather than nested per section. The section's `toc.yml` renders a nested **Common tasks** group beneath the concept articles. Sections without task-style articles don't get a `common-tasks/` subfolder. See [Decision 11](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials) in the Project Map.

## Phase A: Program Structure (§7)

### PR 1 — Program structure: namespaces + preprocessor directives

[#52082](https://github.com/dotnet/docs/pull/52082) *Merged*

> ~10 files

1. Revise `fundamentals/program-structure/index.md` — add file-scoped namespaces, global usings as default style
2. Move+revise `fundamentals/types/namespaces.md` → `fundamentals/program-structure/namespaces.md` — add file-scoped namespaces (C# 10), global usings (C# 10), static using (C# 6), type/namespace aliases (subset)
3. New `fundamentals/program-structure/preprocessor-directives.md` — `#if`, `#region`, `#nullable`, `#pragma warning`
4. New `fundamentals/program-structure/organizing-programs.md` — assemblies, namespaces, and types as organizational tools (addresses [#34836](https://github.com/dotnet/docs/issues/34836))
5. Snippet files for new/revised articles
6. toc.yml + redirect for old namespaces path

### PR 2 — Tutorial: System.CommandLine

[#52592](https://github.com/dotnet/docs/pull/52592) *Merged*

> ~4 files

1. New `fundamentals/tutorials/system-commandline.md` — demonstrate `System.CommandLine` for commands, subcommands, arguments, and options
2. Snippet files + toc.yml

## Phase B: Type System (§8) — 5 PRs

### PR 3 — Type system: overview, built-in types, enums

[#52608](https://github.com/dotnet/docs/pull/52608) *Merged*

> ~10 files

1. Revise `fundamentals/types/index.md` — value vs. reference, unified type system
2. New `fundamentals/types/built-in-types.md` — numeric types (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literals, `default`, `var`, target-typed `new`, `dynamic`
3. New `fundamentals/types/enums.md` — core enum usage and patterns
4. Snippet files + toc.yml

### PR 4 — Type system: classes, structs, records

[#52605](https://github.com/dotnet/docs/pull/52605) *Merged*

1. Revise `fundamentals/types/classes.md` — static classes (C# 2), object/collection initializers (C# 3)
2. New `fundamentals/types/structs.md` — struct design, auto-default (C# 11), parameterless constructors (C# 10), readonly members (C# 8), record structs (C# 10)
3. Revise `fundamentals/types/records.md` — ensure record structs and `with` expressions covered
4. Snippet files + toc.yml

### PR 5 — Type system: tuples, interfaces, generics

[#52891](https://github.com/dotnet/docs/pull/52891) *Merged*

> ~10 files

1. Replace `fundamentals/types/anonymous-types.md` → `fundamentals/types/tuples.md` — merge existing tuples + deconstruct content; add inferred names (C# 7.1), tuple comparison (C# 7.3), `with` on tuples. Redirect old URL
2. Revise `fundamentals/types/interfaces.md` — declaring and implementing (exclude default interface members, static abstract members)
3. Revise `fundamentals/types/generics.md` — add collection expressions (C# 12), dictionary expressions (C# 14), spread `..`, co-/contra-variance
4. Snippet files + toc.yml + redirect

### PR 6 — Type system: conversions, delegates/lambdas, records tutorial

[#52973](https://github.com/dotnet/docs/pull/52973) *Merged*

> ~10 files

1. New `fundamentals/types/conversions.md` — pull+revise from `programming-guide/types/casting-and-type-conversions.md` and `programming-guide/types/boxing-and-unboxing.md`. Add redirects
2. New `fundamentals/types/delegates-lambdas.md` — `Func<>`/`Action<>`, lambda basics, static lambdas, discard params, brief events intro
3. Pull `tutorials/records.md` → `fundamentals/tutorials/records.md` + redirect
4. Snippet files + toc.yml + redirects

### PR 7 — Tutorial: Choosing between tuples, records, structs, and classes

[#53160](https://github.com/dotnet/docs/pull/53160) *Merged*

> ~4 files

1. New `fundamentals/tutorials/choosing-types.md` — teach readers to decide between using tuples, defining records, defining structs or classes, and defining interfaces
2. Snippet files + toc.yml

## Phase C: Null Safety — 2 PRs

### PR 8 — Null safety: overview, nullable value types, null operators

[#53509](https://github.com/dotnet/docs/pull/53509) *Merged*

> ~10 files

1. Create `fundamentals/null-safety/` directory
2. New `fundamentals/null-safety/index.md` — unified null safety story, NVT vs. NRT comparison
3. New `fundamentals/null-safety/nullable-value-types.md` — `T?` for value types, `HasValue`, `GetValueOrDefault`
4. New `fundamentals/null-safety/null-operators.md` — `?.`, `?[]`, `??`, `??=`, null-conditional assignment, `is null`/`is not null`
5. Snippet files + toc.yml

### PR 9 — Null safety: NRT, warnings, migration, tutorial

[#53542](https://github.com/dotnet/docs/pull/53542) *Merged*

> ~10 files

1. Consolidate `fundamentals/null-safety/nullable-reference-types.md` — pull from `nullable-references.md` + `tutorials/nullable-reference-types.md`
2. Pull `fundamentals/null-safety/common-tasks/resolve-warnings.md` — from existing nullable warnings content
3. Pull `fundamentals/null-safety/migration-strategies.md` — from `nullable-migration-strategies.md`
4. Pull `tutorials/nullable-reference-types.md` → `fundamentals/tutorials/nullable-reference-types.md` (flat under tutorials, not nested under null-safety)
5. toc.yml + redirects (4 redirect entries)

> *Folder layout note:* `resolve-warnings.md` is the only task-style article in this section, so it goes under `null-safety/common-tasks/`. The other articles in this PR are concept content at the section root, and the NRT tutorial lives flat under `fundamentals/tutorials/` per the [folder layout convention](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials).

## Phase D: Strings — 3 PRs

### PR 10 — Strings: overview, raw strings, nameof

[#53676](https://github.com/dotnet/docs/pull/53676) *Merged*

> ~10 files

1. Create `fundamentals/strings/` directory
2. New `fundamentals/strings/index.md` — basics, immutability, `string` vs `String`, verbatim strings, escape sequences, `\e` (C# 13)
3. New `fundamentals/strings/raw-string-literals.md` — `"""` syntax (C# 11), raw interpolated strings
4. New `fundamentals/strings/nameof.md` — `nameof` (C# 6)
5. Snippet files + toc.yml

> *Watch for redistribution:* the existing string content (verbatim, escape, raw-literal corners) often includes deep-cut detail (UTF-8 literals, custom interpolated string handlers, `Span<char>` manipulation, allocation comparisons) that fails universality. Cut those sub-sections to a Strings deep dive (or leave them in their current homes) and keep the Fundamentals overview, raw-literal, and `nameof` articles focused on everyday usage.

### PR 11 — Strings: interpolation + search + split

[#53991](https://github.com/dotnet/docs/pull/53991) *Merged*

> ~10 files

1. Pull+revise `fundamentals/strings/interpolation.md` — from `tutorials/string-interpolation.md`; add newlines (C# 11), constant interpolated (C# 10)
2. Pull `fundamentals/strings/common-tasks/search.md` — from `how-to/search-strings.md`
3. Pull `fundamentals/strings/common-tasks/split.md` — from `how-to/parse-strings-using-split.md`
4. toc.yml + redirects

> *Folder layout decision:* this PR introduces the `common-tasks/` subfolder convention for Fundamentals sections (now codified as [Decision 11](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials) in the Project Map). `interpolation.md` is a concept article and stays at the section root; `search.md` and `split.md` answer "how do I do X?" and go under `strings/common-tasks/` with snippets in `strings/common-tasks/snippets/`. The `toc.yml` renders **Common tasks** as a nested group beneath the concept articles in **Strings**.

> *Watch for redistribution:* the existing how-to articles for search and split include performance comparisons, regex-vs-method discussions, and `Span<char>`-based variants that fail universality. Cut those sub-sections to a Strings deep dive (or leave them in the existing how-to articles if those originals stay live), and pull only the everyday-usage core into Fundamentals.

### PR 12 — Strings: concatenate, modify, compare, interpolation tutorial

> ~10 files

1. Pull `fundamentals/strings/common-tasks/concatenate.md` — from `how-to/concatenate-multiple-strings.md`
2. Pull `fundamentals/strings/common-tasks/modify.md` — from `how-to/modify-string-contents.md`
3. Pull `fundamentals/strings/common-tasks/compare.md` — from `how-to/compare-strings.md`
4. Pull `tutorials/string-interpolation.md` → `fundamentals/tutorials/string-interpolation.md`
5. toc.yml + redirects

> *Watch for redistribution:* the existing concatenate, modify, and compare how-tos include `StringBuilder` vs. concatenation benchmarks, culture-sensitive comparison deep-dives, and `string.Create`-style allocation guidance. Those sections fail universality — cut them to a Strings deep dive (or globalization content for culture-sensitive comparison) rather than carrying them into Fundamentals.

## Phase E: Statements and Expressions (§12–§13) — 3 PRs

### PR 13 — Statements: selection + iteration

> ~8 files

1. Create `fundamentals/statements/` directory
2. New `fundamentals/statements/selection-statements.md` — `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions
3. New `fundamentals/statements/iteration-statements.md` — `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops
4. Snippet files + toc.yml

### PR 14a — Statements: collections + LINQ

> ~8 files

1. New `fundamentals/statements/collections.md` — Arrays, `List<T>`, `Dictionary<K,V>`; adding, removing, and searching elements; collection expressions (C# 12); ranges and indexes (C# 8) applied to collections
2. New `fundamentals/statements/linq.md` — query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios
3. Snippet files + toc.yml

### PR 14b — Type system: equality

> ~6 files

1. New `fundamentals/types/equality.md` — value equality vs. reference equality; `Equals`, `==`, `ReferenceEquals`; struct vs. class defaults; `IEquatable<T>`; record equality semantics
2. Snippet files + toc.yml

> *Split rationale:* equality lives in the Type system area while collections and LINQ live in Statements; the topics share no snippet code and no readers will reach for them together. Splitting also leaves room for the equality redistribution work (move `IEqualityComparer<T>` design, `GetHashCode` contract, and operator overloading rules to Language Reference / OOP deep dive) without crowding collections and LINQ.

> *Watch for redistribution:* the equality article will attract content that fails universality — `IEqualityComparer<T>` design, the full `GetHashCode` contract, operator overloading rules for `==` and `!=`, and equality semantics for ref structs. Move those topics to Language Reference (operator overloading, `GetHashCode` contract) or an OOP deep dive (`IEqualityComparer<T>`), and keep the Fundamentals article scoped to "what `==` and `Equals` do for the types you've already met."

## Phase F: Pattern Matching + Functional (§11–§12) — 5 PRs

### PR 15 — Pattern matching: overview + declaration/constant/var + type patterns

> ~10 files

1. Revise `fundamentals/functional/pattern-matching.md` — high-level introduction to pattern matching and switch expressions (C# 8); motivate when and why to use patterns vs. imperative branching
2. New `fundamentals/functional/declaration-constant-var-patterns.md` — declaration patterns, constant patterns, var patterns (combined into one article because each is brief on its own)
3. New `fundamentals/functional/type-patterns.md` — type-testing patterns, pattern matching with generics (C# 7.1)
4. Snippet files + toc.yml

### PR 16 — Pattern matching: property/positional + relational/logical + list patterns

> ~10 files

1. New `fundamentals/functional/property-positional-patterns.md` — property patterns (C# 8), extended property patterns (C# 10), positional patterns (C# 8)
2. New `fundamentals/functional/relational-logical-patterns.md` — relational patterns, combinator/logical patterns (`and`, `or`, `not`), parenthesized patterns (C# 9)
3. New `fundamentals/functional/list-patterns.md` — list patterns (C# 11), slice patterns
4. Snippet files + toc.yml

### PR 17 — Pattern matching: deconstruction + tutorial

> ~6 files

1. Revise `fundamentals/functional/deconstruct.md` — records, tuples, custom `Deconstruct`, mixed deconstructions
2. Pull `tutorials/patterns-objects.md` → `fundamentals/tutorials/pattern-matching.md`
3. Updated snippets + toc.yml + redirect

### PR 18 — Functional techniques

> ~10 files

1. Revise `fundamentals/functional/index.md` — (new overview article, C# as multi-paradigm)
2. New `fundamentals/functional/lambdas.md` — closures, captures, expression vs. statement lambdas, method group conversions
3. Pull `fundamentals/functional/local-functions.md` — from `programming-guide/classes-and-structs/local-functions.md`
4. Pull `fundamentals/functional/iterators.md` — from `iterators.md` + `programming-guide/concepts/iterators.md`
5. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing iterator content includes state-machine internals, `IAsyncEnumerable` mechanics, custom enumerator authoring, and exception-handling rules around `yield`. Those sections fail universality — move them to Language Reference (state-machine details, exception rules) or an Async/Iterators deep dive (`IAsyncEnumerable`, custom enumerators). Keep the Fundamentals iterators article on consuming and writing simple `yield return` iterators.

### PR 19 — Tutorial: Functional techniques in C#

> ~4 files

1. New `fundamentals/tutorials/functional-techniques.md` — breadth-focused tutorial demonstrating functional techniques (lambdas, local functions, pattern matching expressions, iterators, LINQ) in combination rather than depth in any single area
2. Snippet files + toc.yml

## Phase G: Namespaces (§14) + Object-Oriented Programming (§15) — 10 PRs

### PR 20 — Namespaces

> ~4 files

1. New `fundamentals/namespaces/overview.md` — motivation for using namespaces to organize programs and libraries; declaring namespaces; file-scoped namespaces (C# 10); importing with `using`; namespace aliases; nested namespaces
2. Snippet files + toc.yml

### PR 21 — OOP: overview, access modifiers, fields/constants

> ~10 files

1. Revise `fundamentals/object-oriented/index.md` — the OOP model in C#
2. Pull+revise `fundamentals/object-oriented/access-modifiers.md` — from `programming-guide/classes-and-structs/access-modifiers.md`; add `private protected` (C# 7.2)
3. Pull+merge `fundamentals/object-oriented/fields-constants.md` — from `programming-guide/classes-and-structs/fields.md` + `constants.md`; add backing field attributes (C# 7.3)
4. toc.yml + redirects

> *Watch for redistribution:* the existing fields content includes `volatile`, `readonly` interaction with structs in detail, `fixed`-size buffers, and ref fields — all of which fail universality. Move those sub-sections to Language Reference (`volatile`, `fixed`) or a memory-model deep dive (ref fields, low-level field semantics). Keep Fundamentals on declaring and using fields and constants.

### PR 22a — OOP: properties

> ~6 files

1. Pull+revise `fundamentals/object-oriented/properties.md` — from `programming-guide/classes-and-structs/properties.md` + related; add init-only (C# 9), required (C# 11), `field` keyword (C# 14)
2. Snippet files + toc.yml + redirects

### PR 22b — OOP: constructors

> ~6 files

1. Pull+revise `fundamentals/object-oriented/constructors.md` — from `programming-guide/classes-and-structs/constructors.md` + related; add primary constructors (C# 12)
2. Snippet files + toc.yml + redirects

> *Split rationale:* the properties article carries three substantial new features (init-only, required, `field`) and the constructors article carries primary constructors plus the redistribution of static-constructor ordering rules. Each is a focused topic with its own snippet code; combining them produced a PR that was both wide and deep.

> *Watch for redistribution:* the existing property and constructor content includes `ref` returns from properties, indexed properties on COM interop, `[ModuleInitializer]`, and detailed static-constructor ordering rules. Those sub-sections fail universality — move them to Language Reference (ref returns, static-constructor ordering, module initializers) or COM-interop content. Keep Fundamentals on declaring properties (including init-only, required, and `field`) and writing instance/primary constructors.

### PR 23 — OOP: methods + lambdas in OOP

> ~10 files

1. Pull+merge `fundamentals/object-oriented/methods.md` — from `programming-guide/classes-and-structs/methods.md` + `methods.md`; add `params` collections (C# 13), expression-bodied
2. New `fundamentals/object-oriented/lambdas-in-oop.md` — `Func<>`/`Action<>` as parameters, callback patterns, event handlers as lambdas
3. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing methods content includes `ref readonly` parameters, `in` parameters, conditional methods (`[Conditional]`), method-resolution and overload-resolution rule details, and unsafe-context interactions. Those fail universality — move them to Language Reference (overload resolution, conditional methods, parameter modifiers) or an interop/unsafe deep dive. Keep the Fundamentals methods article on declaring methods, parameter passing, optional and named arguments, and `params`.

### PR 24 — OOP: inheritance merge + interfaces

> ~10 files

1. Merge `inheritance.md` + `polymorphism.md` into single `inheritance.md` — add covariant returns (C# 9). Redirect polymorphism.md
2. Pull+revise `fundamentals/object-oriented/interfaces.md` — from `programming-guide/interfaces/`; implementing, explicit implementation, interfaces vs. abstract classes
3. toc.yml + redirects

### PR 25 — OOP: indexers, extensions, ranges tutorial

> ~10 files

1. Pull `fundamentals/object-oriented/indexers.md` — from `programming-guide/indexers/`; add ranges and indexes (C# 8)
2. New `fundamentals/object-oriented/extensions.md` — C# 14 extension syntax, extension properties; note legacy `this` syntax
3. Pull `tutorials/ranges-indexes.md` → `fundamentals/tutorials/ranges.md`
4. toc.yml + redirects

### PR 26a — OOP: events + partial types

> ~6 files

1. Pull subset `fundamentals/object-oriented/events.md` — from `programming-guide/events/`; subscribe/unsubscribe, standard pattern only
2. New `fundamentals/object-oriented/partial-types.md` — partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14)
3. Snippet files + toc.yml + redirects

### PR 26b — OOP: object lifetime

> ~5 files

1. New `fundamentals/object-oriented/object-lifetime.md` — `using` statement, `using` declaration (C# 8), dispose pattern
2. Snippet files + toc.yml

> *Split rationale:* events and partial types are both type-shape topics with shared snippet patterns; object lifetime is a separate concern about resource management with substantial redistribution work (full dispose pattern, finalizers, `SafeHandle`, async-dispose authoring all move to a deep dive). Splitting lets reviewers focus on one concern per PR.

> *Watch for redistribution:* the existing events content includes custom event accessors, weak-event patterns, and threading rules around event invocation — move those to an OOP deep dive. The full dispose pattern (finalizers, `SafeHandle`, suppress-finalize ordering, async-dispose authoring) and detailed garbage-collection interaction also fail universality — move them to a Deep dives article or the existing GC/Standard library content. Keep Fundamentals on subscribing to and raising events with the standard pattern, and on `using`/`using` declarations plus a brief "implement `IDisposable` when you wrap an unmanaged resource" pointer.

### PR 27 — OOP: encapsulation and composition

> ~6 files

1. New `fundamentals/object-oriented/encapsulation-composition.md` — encapsulation as information hiding; composition over inheritance; combining objects to build complex behavior; comparison with inheritance-based designs
2. Snippet files + toc.yml

## Phase H: Remaining Sections — 5 PRs

### PR 28a — Async basics

> ~6 files

1. Create `fundamentals/async/` directory
2. Pull `asynchronous-programming/index.md` → `fundamentals/async/index.md` — async programming overview; redirect old URL
3. New `fundamentals/async/consuming-async.md` — `async`/`await`, task-based pattern, async Main (C# 7.1), brief `await foreach`; link to Async focus section
4. Snippet files + toc.yml + redirect

### PR 28b — Attributes

> ~4 files

1. New `fundamentals/attributes.md` — common attributes, syntax, targets; defer custom attribute creation
2. Snippet files + toc.yml

> *Split rationale:* async and attributes share neither subject matter nor snippet code; they were combined only to fit the file budget. Each topic also has its own redistribution work (async → Async deep dive; attributes → Language Reference / reflection deep dive). Splitting keeps each PR focused.

> *Watch for redistribution:* the existing async overview includes `ConfigureAwait` rules, synchronization-context internals, `ValueTask`, `IAsyncDisposable`, custom awaiters, and `TaskCompletionSource` patterns — all of which fail universality. Move them to the Async deep dive. The existing attributes content includes custom-attribute authoring, attribute-target rules in detail, and reflection-based attribute reading — move those to Language Reference (attribute syntax and targets) or a reflection deep dive. Keep Fundamentals on consuming async APIs with `await` and on applying common attributes that already exist.

### PR 29 — XML docs + Coding style + Console app tutorial

> ~10 files

1. New or pull `fundamentals/xml-comments.md` — `///` comments, common tags
2. New `fundamentals/xml-comments/common-tasks/documentation-tools.md` — generating XML output with `dotnet build`; DocFX; Sandcastle; other current tools (task-style article under the `common-tasks/` subfolder per [Decision 11](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials))
3. New `fundamentals/coding-style/design-alternatives.md` — common design decisions: patterns vs. branching, class vs. struct, `record` modifier, tuples, interfaces vs. abstract classes, `enum` vs. sealed hierarchy, delegates vs. single-method interfaces, and others
4. Pull `tutorials/console-teleprompter.md` → `fundamentals/tutorials/console-app.md` + redirect
5. toc.yml + redirects

> Addresses [#34830](https://github.com/dotnet/docs/issues/34830) — XML documentation content from Language Reference moves into Fundamentals via the XML docs articles in this PR.

6. Cross-cutting: all Coding style articles should mention `.editorconfig` usage and link to the EditorConfig section in "Get started". Link to pertinent analyzer rules and code style rules relevant to each article's design decisions.

### PR 30 — Using .NET analyzers

> ~4 files

1. New `fundamentals/coding-style/analyzers.md` — Roslyn analyzers, .NET SDK analyzers, StyleCop, enabling/configuring via `.editorconfig` and `AnalysisLevel`; finding and fixing code issues
2. Snippet files + toc.yml

### PR 31 — Exceptions modernization pass

> ~9 files

1. Revise all 5 exception articles + 2 tutorials in `fundamentals/exceptions/` for latest feature saturation — update all code samples to use file-scoped namespaces, collection expressions, NRT, raw string literals, primary constructors where natural
2. Updated snippet files
3. toc.yml (reorder to match proposed TOC if needed)

> Addresses [#34831](https://github.com/dotnet/docs/issues/34831) — clean up the Exceptions section, move LINQ exceptions article to LINQ section, move Non-CLS exceptions to Advanced section.

> *Watch for redistribution:* in addition to the LINQ exceptions and Non-CLS exceptions articles already flagged for relocation, the existing exceptions content includes CLR exception model details, Structured Exception Handling (SEH) interop, first-chance exceptions, and corrupted-state exception rules. Those sub-sections fail universality — move them to a runtime/advanced deep dive. Keep the modernization pass focused on idiomatic everyday exception handling.

## Verification

- After each PR: verify redirect JSON entries resolve correctly
- After each "pull" PR: confirm the old URL redirects to the new location
- Spot-check 2–3 code samples per PR against the feature checklist (Goals 4 & 8)
- After all PRs: full link-check pass across the Fundamentals section and cross-referencing sections

## Decisions

- *~10 total files per PR* including toc.yml, redirects, and snippets; tutorial-only PRs may be smaller (~4 files)
- *Move + revise in same PR* rather than two-step
- *Incremental TOC updates* — each PR makes its section live immediately
- *Polymorphism → redirect to merged Inheritance article* (PR 24)
- *Pattern matching split into 3 PRs* (PRs 15–17) per project map decision: overview + basics | structural patterns | deconstruct + tutorial
- *Namespaces (§14) gets its own small PR (PR 20)* at the start of Phase G; single-article section
- *Using .NET analyzers gets its own PR (PR 30)* after the Coding style PR; keeps PR 29 at ~10 files
- *PRs within a phase are sequential* (e.g., Type system PRs 3→6 go in order); *phases are largely independent* and can run in parallel if multiple authors contribute
- *Two-criteria fit test applied per section* — universality and beginner accessibility (Goal 11). Sections that fail universality are relocated (text moved, not deleted) to Language Reference, Deep dives, or Advanced; sections that fail only accessibility are rewritten in place.
- *Out-of-scope full articles stay where they are.* Documented as explicit "leave in place" line items in the relevant PR; revisited when that area is restructured. The nullable-reference-type migration article is the canonical example.
- *PR file budgets are advisory when redistribution is required.* A PR may exceed ~10 files when relocating text to other sections is the right call.
- *Oversized PRs split along natural seams using letter suffixes* (e.g., PR 14a / PR 14b) so downstream PR numbers stay stable. Current splits: PR 14 → 14a (collections + LINQ) / 14b (equality); PR 22 → 22a (properties) / 22b (constructors); PR 26 → 26a (events + partial types) / 26b (object lifetime); PR 28 → 28a (async basics) / 28b (attributes).
