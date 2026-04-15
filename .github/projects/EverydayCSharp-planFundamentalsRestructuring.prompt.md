# Draft Plan: Fundamentals Restructuring PR Breakdown

**TL;DR:** Break the ~91-article restructuring into ~31 small, independently mergeable PRs organized in proposed TOC order. Each PR touches ≤10 files (articles, snippets, toc.yml, redirects), adds its content to the live TOC immediately, and leaves the section in a publishable state. Every new or revised article follows the example-heavy, latest-version-saturation style from Goals 4 and 8.

**Conventions for every PR:**
- Update `toc.yml` incrementally so new content is navigable immediately.
- Add redirect entries for every moved file (use the "/.openpublishing/redirection.csharp.json" file).
- All snippet code uses the full "Everyday C#" feature set per the feature tables.
- Prefer file based apps over larger project-based samples for simplicity and ease of understanding, unless a feature requires a more complex setup.
- All code examples are included from external snippet files (no inline code blocks), and every article has a corresponding snippet project.
- Each article follows concept → example → concept → example structure. The concept discussion should include motivating scenarios for the feature or concept being covered.
- Prefer articles that are between a 5 and 10 minute read (roughly 1000–2000 words). Longer and shorter artiles are allowed, but should be the exception.
- Cross reference liberally. However, it's assumed that readers are familiar with content in the "Get started" section. Links to that section should be minimal, and possibly scoped to recommendations for beginners to start there instead. Links and cross references should encourage readers to learn more and dive deeper into the fundamental concepts covered in this section.
- If and only if a feature was first added in one of the last three released versions (C# 12 - 14) mention the first it was first introduced.
- Every article must include a tip near the top that identifies where the article sits in the four-tier content structure (*Get started* → *Fundamentals* → *Deep dives* → *Reference*), describes who it's written for, and routes readers to the right tier based on their experience level (Goal 1).
- Define concepts when they are first introduced. Don't assume readers know what a "type" or "namespace" is before those concepts are covered in the proposed TOC. When defining a concept, link to articles that provide more detail. Definitions are less important for concepts that aren't related to the C# language: Remember the goal for Fundamentals is to teach readers how C# works. While we teach through examples, the libraries and packages used in the examples are less important than the language features being demonstrated. For example, when teaching about collections, it's more important to explain what a collection is and how to use them in C# than to provide an in-depth explanation of `List<T>` vs. `Dictionary<K,V>`.
- Similarly, define all terms that may be unfamiliar to the reader when they are first introduced. Link to articles that provide more detail on these terms. Remember that the audience for Fundamentals articles may not be familiar with all C# terminology, or all compputer science terminology. Provide clear definitions and context.
- Set the `ms.topic` metadata value in each article's YAML front matter to match the article's content type (`overview`, `tutorial`, `concept`, `how-to`, `troubleshooting`, or `reference`).
- After writing content, verify the article's structure, required metadata, and sections against the template for its content type (see the [Include major topic types](EverydayCSharp-ProjectMap.md#include-major-topic-types) table for template links).
- Do not add F1 or helpviewer keywords to Fundamentals articles. When pulling content from the Reference section, remove any F1 or helpviewer keywords.
- When recommending a modern feature over an older alternative, always include a justification—state *why* the recommended approach is preferred. Never describe older features as obsolete or deprecated (Goal 9).
- Do not add links to files that will be created in future PRs until those files are live. For example, if PR 3 creates the `fundamentals/types/enums.md` article, then earlier PRs should not link to that file until PR 3 is merged. This may require some temporary duplication of content or placeholders for links, but it will prevent broken links in merged PRs. Instead, when an article is created, add appropriate links to it in earlier articles as needed to connect the content together.
- Never place consecutive code snippets. They are hard to read and harder for readers to follow. Either intersperse explanatory text between snippets or combine related snippets into a single example.

## Phase A: Program Structure (§7)

### PR 1 — Program structure: namespaces + preprocessor directives

> ~10 files

1. Revise `fundamentals/program-structure/index.md` — add file-scoped namespaces, global usings as default style
2. Move+revise `fundamentals/types/namespaces.md` → `fundamentals/program-structure/namespaces.md` — add file-scoped namespaces (C# 10), global usings (C# 10), static using (C# 6), type/namespace aliases (subset)
3. New `fundamentals/program-structure/preprocessor-directives.md` — `#if`, `#region`, `#nullable`, `#pragma warning`
4. New `fundamentals/program-structure/organizing-programs.md` — assemblies, namespaces, and types as organizational tools (addresses [#34836](https://github.com/dotnet/docs/issues/34836))
5. Snippet files for new/revised articles
6. toc.yml + redirect for old namespaces path

### PR 2 — Tutorial: System.CommandLine

> ~4 files

1. New `fundamentals/tutorials/system-commandline.md` — demonstrate `System.CommandLine` for commands, subcommands, arguments, and options
2. Snippet files + toc.yml

## Phase B: Type System (§8) — 5 PRs

### PR 3 — Type system: overview, built-in types, enums

> ~10 files

1. Revise `fundamentals/types/index.md` — value vs. reference, unified type system
2. New `fundamentals/types/built-in-types.md` — numeric types (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literals, `default`, `var`, target-typed `new`, `dynamic`
3. New `fundamentals/types/enums.md` — core enum usage and patterns
4. Snippet files + toc.yml

### PR 4 — Type system: classes, structs, records

> ~10 files

1. Revise `fundamentals/types/classes.md` — static classes (C# 2), object/collection initializers (C# 3)
2. New `fundamentals/types/structs.md` — struct design, auto-default (C# 11), parameterless constructors (C# 10), readonly members (C# 8), record structs (C# 10)
3. Revise `fundamentals/types/records.md` — ensure record structs and `with` expressions covered
4. Snippet files + toc.yml

### PR 5 — Type system: tuples, interfaces, generics

> ~10 files

1. Replace `fundamentals/types/anonymous-types.md` → `fundamentals/types/tuples.md` — merge existing tuples + deconstruct content; add inferred names (C# 7.1), tuple comparison (C# 7.3), `with` on tuples. Redirect old URL
2. Revise `fundamentals/types/interfaces.md` — declaring and implementing (exclude default interface members, static abstract members)
3. Revise `fundamentals/types/generics.md` — add collection expressions (C# 12), dictionary expressions (C# 14), spread `..`, co-/contra-variance
4. Snippet files + toc.yml + redirect

### PR 6 — Type system: conversions, delegates/lambdas, records tutorial

> ~10 files

1. New `fundamentals/types/conversions.md` — pull+revise from `programming-guide/types/casting-and-type-conversions.md` and `programming-guide/types/boxing-and-unboxing.md`. Add redirects
2. New `fundamentals/types/delegates-lambdas.md` — `Func<>`/`Action<>`, lambda basics, static lambdas, discard params, brief events intro
3. Pull `tutorials/records.md` → `fundamentals/tutorials/records.md` + redirect
4. Snippet files + toc.yml + redirects

### PR 7 — Tutorial: Choosing between tuples, records, structs, and classes

> ~4 files

1. New `fundamentals/tutorials/choosing-types.md` — teach readers to decide between using tuples, defining records, defining structs or classes, and defining interfaces
2. Snippet files + toc.yml

## Phase C: Null Safety — 2 PRs

### PR 8 — Null safety: overview, nullable value types, null operators

> ~10 files

1. Create `fundamentals/null-safety/` directory
2. New `fundamentals/null-safety/index.md` — unified null safety story, NVT vs. NRT comparison
3. New `fundamentals/null-safety/nullable-value-types.md` — `T?` for value types, `HasValue`, `GetValueOrDefault`
4. New `fundamentals/null-safety/null-operators.md` — `?.`, `?[]`, `??`, `??=`, null-conditional assignment, `is null`/`is not null`
5. Snippet files + toc.yml

### PR 9 — Null safety: NRT, warnings, migration, tutorial

> ~10 files

1. Consolidate `fundamentals/null-safety/nullable-reference-types.md` — pull from `nullable-references.md` + `tutorials/nullable-reference-types.md`
2. Pull `fundamentals/null-safety/resolve-warnings.md` — from existing nullable warnings content
3. Pull `fundamentals/null-safety/migration-strategies.md` — from `nullable-migration-strategies.md`
4. Pull `tutorials/nullable-reference-types.md` → `fundamentals/tutorials/nullable-reference-types.md`
5. toc.yml + redirects (4 redirect entries)

## Phase D: Strings — 3 PRs

### PR 10 — Strings: overview, raw strings, nameof

> ~10 files

1. Create `fundamentals/strings/` directory
2. New `fundamentals/strings/index.md` — basics, immutability, `string` vs `String`, verbatim strings, escape sequences, `\e` (C# 13)
3. New `fundamentals/strings/raw-string-literals.md` — `"""` syntax (C# 11), raw interpolated strings
4. New `fundamentals/strings/nameof.md` — `nameof` (C# 6)
5. Snippet files + toc.yml

### PR 11 — Strings: interpolation + search + split

> ~10 files

1. Pull+revise `fundamentals/strings/interpolation.md` — from `tutorials/string-interpolation.md`; add newlines (C# 11), constant interpolated (C# 10)
2. Pull `fundamentals/strings/search.md` — from `how-to/search-strings.md`
3. Pull `fundamentals/strings/split.md` — from `how-to/parse-strings-using-split.md`
4. toc.yml + redirects

### PR 12 — Strings: concatenate, modify, compare, interpolation tutorial

> ~10 files

1. Pull `fundamentals/strings/concatenate.md` — from `how-to/concatenate-multiple-strings.md`
2. Pull `fundamentals/strings/modify.md` — from `how-to/modify-string-contents.md`
3. Pull `fundamentals/strings/compare.md` — from `how-to/compare-strings.md`
4. Pull `tutorials/string-interpolation.md` → `fundamentals/tutorials/string-interpolation.md`
5. toc.yml + redirects

## Phase E: Statements and Expressions (§12–§13) — 2 PRs

### PR 13 — Statements: selection + iteration

> ~8 files

1. Create `fundamentals/statements/` directory
2. New `fundamentals/statements/selection-statements.md` — `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions
3. New `fundamentals/statements/iteration-statements.md` — `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops
4. Snippet files + toc.yml

### PR 14 — Statements: collections + LINQ + equality

> ~10 files

1. New `fundamentals/statements/collections.md` — Arrays, `List<T>`, `Dictionary<K,V>`; adding, removing, and searching elements; collection expressions (C# 12); ranges and indexes (C# 8) applied to collections
2. New `fundamentals/statements/linq.md` — query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios
3. New `fundamentals/types/equality.md` — value equality vs. reference equality; `Equals`, `==`, `ReferenceEquals`; struct vs. class defaults; `IEquatable<T>`; record equality semantics
4. Snippet files + toc.yml

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

### PR 19 — Tutorial: Functional techniques in C#

> ~4 files

1. New `fundamentals/tutorials/functional-techniques.md` — breadth-focused tutorial demonstrating functional techniques (lambdas, local functions, pattern matching expressions, iterators, LINQ) in combination rather than depth in any single area
2. Snippet files + toc.yml

## Phase G: Namespaces (§14) + Object-Oriented Programming (§15) — 8 PRs

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

### PR 22 — OOP: properties + constructors

> ~10 files

1. Pull+revise `fundamentals/object-oriented/properties.md` — from `programming-guide/classes-and-structs/properties.md` + related; add init-only (C# 9), required (C# 11), `field` keyword (C# 14)
2. Pull+revise `fundamentals/object-oriented/constructors.md` — from `programming-guide/classes-and-structs/constructors.md` + related; add primary constructors (C# 12)
3. toc.yml + redirects

### PR 23 — OOP: methods + lambdas in OOP

> ~10 files

1. Pull+merge `fundamentals/object-oriented/methods.md` — from `programming-guide/classes-and-structs/methods.md` + `methods.md`; add `params` collections (C# 13), expression-bodied
2. New `fundamentals/object-oriented/lambdas-in-oop.md` — `Func<>`/`Action<>` as parameters, callback patterns, event handlers as lambdas
3. Snippet files + toc.yml + redirects

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

### PR 26 — OOP: events, partial types, object lifetime

> ~10 files

1. Pull subset `fundamentals/object-oriented/events.md` — from `programming-guide/events/`; subscribe/unsubscribe, standard pattern only
2. New `fundamentals/object-oriented/partial-types.md` — partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14)
3. New `fundamentals/object-oriented/object-lifetime.md` — `using` statement, `using` declaration (C# 8), dispose pattern
4. Snippet files + toc.yml + redirects

### PR 27 — OOP: encapsulation and composition

> ~6 files

1. New `fundamentals/object-oriented/encapsulation-composition.md` — encapsulation as information hiding; composition over inheritance; combining objects to build complex behavior; comparison with inheritance-based designs
2. Snippet files + toc.yml

## Phase H: Remaining Sections — 4 PRs

### PR 28 — Async basics + Attributes

> ~10 files

1. Create `fundamentals/async/` directory
2. Pull `asynchronous-programming/index.md` → `fundamentals/async/index.md` — async programming overview; redirect old URL
3. New `fundamentals/async/consuming-async.md` — `async`/`await`, task-based pattern, async Main (C# 7.1), brief `await foreach`; link to Async focus section
4. New `fundamentals/attributes.md` — common attributes, syntax, targets; defer custom attribute creation
5. Snippet files + toc.yml + redirect

### PR 29 — XML docs + Coding style + Console app tutorial

> ~10 files

1. New or pull `fundamentals/xml-comments.md` — `///` comments, common tags
2. New `fundamentals/xml-comments/documentation-tools.md` — generating XML output with `dotnet build`; DocFX; Sandcastle; other current tools
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
