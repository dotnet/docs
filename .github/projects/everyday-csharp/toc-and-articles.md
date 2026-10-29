> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Planned Fundamentals TOC

The following outline shows article coverage in the approved Fundamentals plan, its implementation status (existing, needs revision, new, or pulled from another location), and key content notes. Planned paths aren't live destinations; conditional outputs still require their assigned gap reviews.

> **IA/status reconciliation (2026-10-29):** Phase F is complete. Building software's four direct
> guides shipped in [#56333](https://github.com/dotnet/docs/pull/56333) on 2026-10-19, and its
> follow-on tutorial shipped in [#56528](https://github.com/dotnet/docs/pull/56528) on 2026-10-29.
> The live H1/TOC label is **Build software**; the folder remains `building-software/`.
> [Decision 14](decisions.md#decision-14-building-software-purpose-and-initial-structure) supersedes
> the retired Functional techniques grouping and pending label/initial-placement questions.
> We adopted the language-foundations/applied-guidance organization and expanded task coverage
> on 2026-10-29 in [Decision 16](decisions.md#decision-16-adopt-language-foundations-and-applied-guidance-as-the-governing-plan),
> supported by the explicit phases and 82-article source inventory from 2026-10-16.
> Resolve detailed OOP splits, final paths, and redirects during assigned work after Phase G's
> namespace checkpoint. This approval doesn't move articles or start phase work. The October target
> #55930 is delivered. Unrelated rows retain their previous status; this isn't a full-project audit.

**Execution, not a live TOC move:** [Decision 17](decisions.md#decision-17-foundations-first-execution-and-source-harvesting)
orders remaining delivery as G Namespaces → H Classes → I Structs → J Arrays/indexes/ranges →
K Interfaces → L Enums → M Delegates/events → N Exceptions → O Attributes → P Documentation
comments, then R's applied harvesting batches. Expressions/statements/patterns are completed
prerequisites. Q stays dependency-based supporting work. The shipped Build software node stays
where it is; its early placement does not imply the new applied backlog should run before foundations.

### Program structure (§7)

| # | Article | Status | Notes |
|---|---|---|---|
| 1 | Overview | 🟡 Revise | Add file-scoped namespaces, global usings as default style. Distinguish the uses of file-based apps, top-level statements / project-based apps, and `Main`-style project-based apps. |
| 2 | Main method and entry points | ✅ Exists | Include async Main (C# 7.1). Include file-based apps |
| 3 | Top-level statements | ✅ Exists | Mention file-local types (C# 11) as helpers |
| 4 | Namespaces and using directives | 📝 New | *Slimmed to a brief intro + cross-reference* per [Decision 12b](decisions.md#decision-12-expressions-and-operators-section): the canonical §14 treatment lives in the standalone [Namespaces (§14)](#namespaces-14) section (article #100). This article keeps a short intro to file-scoped namespaces and using directives in the context of program structure and links to #100. Needs a redirect + repo-wide inbound-link fix (shipped article). |
| 5 | Preprocessor directives | 📝 New | `#if`, `#region`, `#nullable`, `#pragma warning` only |
| 67 | Tutorial: Build file-based apps | ✅ Exists | |
| 68 | Tutorial: Display command-line arguments | ✅ Exists | Consider a top-level statements pivot, and a file-based apps pivot. File-based apps pivot should be the default. |
| 77 | Tutorial: Console application | 📥 Pull from Tutorials | |
| 90 | Tutorial: Build a command-line app with System.CommandLine | 📝 New | Demonstrate `System.CommandLine` for commands, subcommands, arguments, and options |
| 98 | Organizing programs | 📝 New | Assemblies, namespaces, and types as organizational tools. Addresses [#34836](https://github.com/dotnet/docs/issues/34836). |

### Type system (§8)

| # | Article | Status | Notes |
|---|---|---|---|
| 6 | Overview | 🟡 Revise | Value vs. reference, unified type system, built-in types overview. Discuss use cases for tuples vs. records vs. structs vs. classes vs. interfaces. |
| 7 | Built-in types and literals | 📝 New | Numeric (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literal syntax (binary, digit separators, raw string literals), `default` expressions, `var`, target-typed `new` (C# 9), `dynamic` (C# 4) |
| 13 | Tuples and deconstruction | 🟡 Revise | Merge existing articles; inferred names (C# 7.1), comparison (C# 7.3), `with` on tuples |
| 14 | Generics | 📝 New | Consuming generic types/methods, type inference, basic constraints, consuming variance, collection expressions and ordinary dictionary initializers; no preview dictionary-expression syntax |
| 15 | Type conversions, casting, and boxing | 📥 Pull | From programming guide: casting, conversions, boxing/unboxing, `is`/`as` |
| 69 | Tutorial: Introduction to classes | ✅ Exists | |
| 72 | Tutorial: Explore record types | 📥 Pull from Tutorials | |
| 79 | Tutorial: Converting types | ✅ Exists | |
| 91 | Tutorial: Choosing between tuples, records, structs, and classes | 📝 New | Teach readers to decide between using tuples, defining records, defining structs or classes, and defining interfaces |

The existing class/struct/record/interface/enum/delegate introductions remain at their current canonical
URLs, but their detailed roadmap rows now appear at the corresponding standard-aligned checkpoints
below. The Type system overview links to those introductions rather than owning duplicate articles.

### Null safety

| # | Article | Status | Notes |
|---|---|---|---|
| 17 | Overview | 📝 New | Unified null safety story, NVT vs. NRT comparison |
| 18 | Nullable value types | 📝 New/Pull | `T?` for value types (C# 2), `HasValue`, `GetValueOrDefault` |
| 19 | Nullable reference types | 📥 Consolidate | Pull from tutorials + concepts: enable NRT, annotating, `?`, `!`, flow analysis |
| 20 | Null operators | 📝 New | `?.`, `?[]`, `??`, `??=` (C# 8), `is null`/`is not null`. Include how pattern matching (`is null`, `is not null`) helps with null checks. |
| 21 | Resolve nullable warnings | 📥 Pull | Existing nullable warnings content. Lives under `null-safety/common-tasks/` per [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 22 | Nullable migration strategies | 📥 Pull | Existing migration content |
| 74 | Tutorial: Explore nullable reference types | 📥 Pull from Tutorials | |

> This section's unified Null safety design (NVT overview + NRT overview + shared operators article) addresses [#36934](https://github.com/dotnet/docs/issues/36934) by consolidating nullable documentation for both value and reference types under one section.

### Strings

| # | Article | Status | Notes |
|---|---|---|---|
| 23 | Overview | 📝 New | Basics, immutability, `string` vs. `String`, verbatim strings, escape sequences, `\e` (C# 13). Include discussion of UTF-8 string literals (`u8` suffix) in the context of HTTP usage. |
| 24 | String interpolation | 📥 Pull/Revise | `$""` (C# 6), newlines (C# 11), constant interpolated strings (C# 10) |
| 25 | Raw string literals | 📝 New | `"""` syntax (C# 11), raw interpolated strings |
| 26 | `nameof` operator | 📝 New | `nameof` (C# 6) |
| 27 | Search strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/` per [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 28 | Split strings into substrings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 29 | Concatenate strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 30 | Modify string contents | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 31 | Compare strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 76 | Tutorial: Explore string interpolation | 📥 Pull from Tutorials | |

### Pattern matching (§11)

Sequenced before Expressions (§12) and Statements (§13) to mirror the C# standard's clause order
(§11 → §12 → §13). Pattern-matching articles live under `fundamentals/patterns/` (their own §11
section). The older `fundamentals/functional/` destination is retired.

| # | Article | Status | Notes |
|---|---|---|---|
| 32 | Overview | ✅ Shipped ([#55966](https://github.com/dotnet/docs/pull/55966), revised again in [#56113](https://github.com/dotnet/docs/pull/56113)) | High-level introduction to pattern matching and switch expressions (C# 8). Motivate when and why to use patterns vs. imperative branching. |
| 92 | Declaration, constant, and var patterns | ✅ Shipped ([#55966](https://github.com/dotnet/docs/pull/55966)) | Declaration patterns, constant patterns, var patterns. Combined into one article because each is brief on its own. |
| 93 | Type patterns | ✅ Shipped ([#55966](https://github.com/dotnet/docs/pull/55966)) | Type-testing patterns, pattern matching with generics (C# 7.1) |
| 94 | Property and positional patterns | ✅ Shipped ([#56113](https://github.com/dotnet/docs/pull/56113)) | Property patterns (C# 8), extended property patterns (C# 10), positional patterns (C# 8) |
| 95 | Relational, logical, and parenthesized patterns | ✅ Shipped ([#56113](https://github.com/dotnet/docs/pull/56113)) | Relational patterns, combinator/logical patterns (`and`, `or`, `not`), parenthesized patterns (C# 9). **Title as shipped:** "Relational, logical, and parenthesized patterns" (was "Relational and logical patterns" in this plan) |
| 96 | List and slice patterns | ✅ Shipped ([#56113](https://github.com/dotnet/docs/pull/56113)) | List patterns (C# 11), slice patterns. **Title as shipped:** "List and slice patterns" (was "List patterns" in this plan) |
| 33 | Discards and the discard pattern | ✅ Shipped ([#55966](https://github.com/dotnet/docs/pull/55966)) | Moved/reworked at `fundamentals/patterns/discards.md`, with its snippet project and redirects. |
| 34 | Deconstruct tuples and other types | ✅ Shipped ([#56286](https://github.com/dotnet/docs/pull/56286)) | `fundamentals/patterns/deconstruct.md`; tuples, records, custom/extension `Deconstruct`, mixed declarations, and discards. H1/TOC as shown; metadata title retains "Deconstructing tuples and other types". |
| 73 | Tutorial: Pattern matching basics | ✅ Shipped ([#56286](https://github.com/dotnet/docs/pull/56286)) | Canal-lock tutorial moved from `tutorials/patterns-objects.md` to `fundamentals/tutorials/pattern-matching-basics.md`. |
| 78 | Tutorial: Build algorithms using pattern matching | ✅ Relocated ([#56286](https://github.com/dotnet/docs/pull/56286)) | Existing toll-calculator tutorial now at `fundamentals/tutorials/build-algorithms-using-pattern-matching.md`, not either earlier proposed `pattern-matching`/`pattern-matching-advanced` slug. |

### Expressions and operators (§12)

Fills the §12 operator gap (see [Decision 12](decisions.md#decision-12-expressions-and-operators-section)).
Sequenced before Statements (§13) per the standard. Articles live under `fundamentals/expressions/`.

| # | Article | Status | Notes |
|---|---|---|---|
| 102 | Overview and operator precedence | 📝 New | What an expression is; expression vs. statement; expression classifications (value vs. variable); operands and operators; the operator precedence and associativity table; evaluation order and side effects. Cross-links to switch expression (Pattern matching) and LINQ (Statements). |
| 103 | Arithmetic, comparison, logical, and assignment operators | 📝 New | Arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`), relational (`< > <= >=`), equality operators (`== !=`, survey; cross-link to Reference vs. value equality for semantics), conditional-logical (`&& ||` with short-circuiting), the conditional operator (`?:`, §12.20), simple and compound assignment (`= += -= *= /= %=`) |

> *Excluded from Fundamentals (stay in Language Reference, cross-linked out):* shift operators
> (`<< >> >>>`, §12.13), integer/bitwise logical operators (`& | ^ ~`, §12.15/§12.9.5), and
> `checked`/`unchecked` (§12.8.20). They fail Filter A universality for everyday code.

### Statements (§13)

| # | Article | Status | Notes |
|---|---|---|---|
| 83 | Selection statements | 📝 New | `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions |
| 84 | Iteration statements | 📝 New | `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops |
| 85 | Working with collections | 📝 New | Arrays, `List<T>`, `Dictionary<TKey,TValue>`; adding, removing, and searching elements; collection expressions (C# 12) including spread elements (`..`) to compose sequences; ranges and indexes (C# 8) applied to collections. Lead indexes/ranges with what they're for; show indexing from the start and from the end; distinguish range `..` from spread `..`; use *index* rather than *position*; and emphasize that a range end is ***exclusive***. |
| 86 | LINQ and query expressions | 📝 New | Query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios. Introduce query syntax, method syntax, providers, and deferred vs. eager execution near the top; use identical output for equivalent query/method examples; and annotate where deferred execution happens in code. |
| 99 | Equality comparisons | ✅ Shipped ([#54849](https://github.com/dotnet/docs/pull/54849)) | Value equality vs. reference equality; the five members `==`, `!=`, `Equals`, `GetHashCode`, `ReferenceEquals`; struct vs. class defaults; record equality semantics (records-first framing; `IEquatable<T>` deemphasized to an optional optimization). **Shipped at `fundamentals/expressions/equality.md`** (relocated from the planned Type system location into the new `fundamentals/expressions/` folder), titled "C# Equality comparisons", rendering as the first child of the combined "Expressions and statements" TOC node. Cross-linked from the Expressions equality-operator survey (deferred to PR 16). |

> *Note:* the conditional `?:` operator is taught in the Expressions and operators section (§12.20).
> Trimming the `ternary conditional operator` mention in Selection statements to a cross-reference is
> a **deferred later-cleanup item**, not part of this reorder batch.

### Building software

**Shipped:** [#56333](https://github.com/dotnet/docs/pull/56333), merged 2026-10-19
(`7a5a9cf8549d`), adds four direct guides after Expressions and statements and before
Object-oriented programming in `docs/csharp/toc.yml`. The live H1 and section label are **Build
software**; the overview metadata title remains "Building software". There is no Functional
techniques subgroup. All four guides are present on this rebased planning branch.

The section's durable purpose is to compare valid algorithmic approaches and what their shape,
names, scope, dependencies, and timing communicate to developers and coding agents. It isn't
limited to the current feature set. See [Decision 14](decisions.md#decision-14-building-software-purpose-and-initial-structure)
and [Decision 15](decisions.md#decision-15-durable-overviews-and-contextual-comparisons).

| # | Article | Status | Notes |
|---|---|---|---|
| 35 | Overview | ✅ Shipped in #56333 | `fundamentals/building-software/index.md`: long-term design-intent framing; contextual paragraphs with small inline examples compare inline/named behavior, local/private helpers, parameters/capture, and completed/deferred results. Combined example retained; #56528 adds the tutorial link. |
| 36 | Lambda expressions | ✅ Shipped in #56333 | `fundamentals/building-software/lambdas.md`: pass short behavior, parameter forms, expression/statement bodies, capture and `static`, lambda vs. method group/local function. Supersedes the planned "in depth" title; links to complete syntax reference. |
| 37 | Local functions | ✅ Shipped in #56333 | `fundamentals/building-software/local-functions.md`: helper scope, parameters vs. capture, `static`, recursion, and local function vs. lambda/type-level method. Replaces the Programming Guide article; don't infer coverage of every former inventory item, such as attributes. |
| 38 | Iterators | ✅ Shipped in #56333 | `fundamentals/building-software/iterators.md`: synchronous `IEnumerable<T>`, `yield return`/`yield break`, `foreach`, deferred execution, and choice of iterator, completed collection, loop, or standard LINQ operation. Consolidates two legacy iterator articles. |

Four snippet projects accompany these articles under `fundamentals/building-software/snippets/`:
`overview/`, `lambdas/`, `local-functions/`, and `iterators/`. Redirects preserve the retired
functional URLs and the consolidated legacy sources; inbound links and old TOC entries are
updated in the PR. See [source reconciliation](content-sources.md#building-software-source-reconciliation).
The final commit changes the overview and lightly reframes companion prose only; snippets are
unchanged in that editorial pass.

**Follow-on tutorial, shipped separately from #56333:**

| # | Article | Status | Notes |
|---|---|---|---|
| 97 | Tutorial: Combine C# techniques to generate badge labels | ✅ Shipped ([#56528](https://github.com/dotnet/docs/pull/56528)) | `fundamentals/tutorials/functional-techniques.md`, under Tutorials; linked from Build software. One incremental sample combines lambdas, LINQ, an iterator, patterns, and a local function. #55930 is complete; [PR 23's dependency gate](plan/phase-f-patterns-functional.md#dependency-gate-reconcile-with-pr-56333) is satisfied. |

**Approved future task coverage, not part of Phase F:**

| # | Article | Status | Notes |
|---|---|---|---|
| 39 / 87 | Object roles, encapsulation, and composition | 📝 Planned merge, BS01 / PR 33 | Harvest the existing OOP overview and encapsulation inventory into planned `building-software/object-design.md`, not two competing overviews. |
| 106 | Construction and initialization choices | 📝 Planned, BS02 | `building-software/object-initialization.md`; constructors, required inputs, initializers, defaults, and mutation. |
| 107 | Member-shape choices | 📝 Planned, BS03 | `building-software/member-design.md`; fields, properties, methods, and indexers as caller contracts. |
| 46 | Callbacks and notifications | 📝 Planned, BS04 | `building-software/callbacks-and-events.md`; replaces "lambdas in OOP", building on existing practical guides. |
| 108 | Contracts and dependencies | 📝 Planned, BS05 | `building-software/contracts-and-dependencies.md`; interface, base implementation, and collaborator choices. |
| 109 | Collection and sequence contracts | 📝 Planned, BS06 | `building-software/collection-contracts.md`; mutation, lookup, output shape, and timing without duplicating collections/iterators. |
| 53 | Resource ownership and lifetime | 📝 Planned, BS07 / PR 32 | `building-software/resource-lifetime.md`; everyday ownership/cleanup, not finalizer/dispose-pattern authoring. |
| 110 | Failure contracts | 📝 Planned, BS08 | `building-software/failure-contracts.md`; expected failed input versus exceptions. |
| 111 | Values, identity, equality, and copying | 📝 Planned, BS09 | `building-software/value-and-identity-design.md`; link existing equality and type introductions. |
| 112 | Extensions versus wrappers | 📝 Planned, BS10 | `building-software/extensions-or-wrappers.md`; ownership/state/API choices rather than repeated syntax. |
| 113 | Parse input | 📝 Conditional task, BS11 | Proposed `building-software/common-tasks/parse-input.md` only if BS08/existing string tasks leave a distinct procedure to teach. |
| 66 | Design-alternatives inventory | 📝 Redistribute, no separate article | The former Coding style commitment feeds BS01-BS11; the existing Building software overview owns the comparison frame. |

These are **future backlog**, not additions to Phase F's shipped scope. See
[Phase R](plan/phase-r-building-software.md) for source paths, dependencies, and done criteria.
BS12 tracks preservation/retirement and doesn't create a reader-facing article.

### Namespaces (§14)

| # | Article | Status | Notes |
|---|---|---|---|
| 100 | Namespaces | 📝 New | **Canonical §14 article** (Decision 12b). Motivation for using namespaces to organize programs and libraries; declaring namespaces; file-scoped namespaces (C# 10); importing with `using`; namespace aliases; `extern alias` mention; nested namespaces. The Program-structure "Namespaces and using directives" article (#4) is slimmed to a brief intro + link here. |

### Classes (§15)

Approved construct-first ownership in [Phase H](plan/phase-h-classes.md). Retain current canonical
introductions, and resolve deeper destinations during assigned work before moving articles. Design extracts belong to
Building software, not a competing OOP paradigm section.

Classes supplies the shared baseline for the later Structs and Interfaces differences. Record-class
coverage belongs here; Structs owns the explicit record-class/record-struct comparison. Both use
the same retained records article instead of independent guides.

| # | Article | Status | Notes |
|---|---|---|---|
| 8 | Classes introduction | ✅ Exists; review | Retain `fundamentals/types/classes.md`; link deeper class/member coverage. |
| 10 | Records | ✅ Exists; revise in PR 25/39 | Retain `fundamentals/types/records.md`; Classes owns record-class declarations, synthesized members, value equality, and shallow `with` copies; Structs owns the record-class/record-struct comparison. |
| 40 | Objects | ✅ Exists | |
| 114 | Class members | 📝 Proposed orientation, PR 25 | Proposed `fundamentals/classes/index.md`; short member map, not a second class/OOP overview. |
| 41 | Access modifiers | 📥 Pull | From programming guide; all modifiers incl. `private protected` (C# 7.2) |
| 42 | Fields and constants | 📥 Pull | From programming guide; attributes on backing fields (C# 7.3) |
| 43 | Properties | 📥 Pull | Auto-properties (C# 3), initializers (C# 6), getter-only (C# 6), init-only (C# 9), required (C# 11), `field` keyword (C# 14), expression-bodied, separate accessibility (C# 2) |
| 44 | Constructors | 📥 Pull | Instance, static, primary (C# 12) |
| 45 | Methods | 📥 Pull | Named/optional args (C# 4), non-trailing named (C# 7.2), expression-bodied (C# 6+), `ref`/`out`, `params` → `params` collections (C# 13), out variables (C# 7) |
| 47 | Inheritance and polymorphism | 🟡 Merge | Reconcile existing Inheritance and Polymorphism articles; `virtual`/`override`/`new`, `sealed`, covariant returns (C# 9), `abstract`/`base`. |
| 50 | Extensions | 📝 New | C# 14 syntax, extension properties; note legacy `this` syntax |
| 52 | Partial types and members | 📝 New | Brief: partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14); source generator context |
| 70 | Tutorial: Object-oriented C# | ✅ Exists | |
| 71 | Tutorial: Inheritance in C# and .NET | ✅ Exists | |

### Structs (§16)

| # | Article | Status | Notes |
|---|---|---|---|
| 9 | Structs | ✅ Exists; revise in PR 39 | Retain `fundamentals/types/structs.md`; explain differences from classes: value/copy semantics, initialization, readonly members, inheritance restrictions. Compare `record class` / `record struct` assignment, shallow `with` copies, equality, and positional-property mutability in the canonical records article. |

### Arrays, indexes, and ranges (§17-18)

| # | Article | Status | Notes |
|---|---|---|---|
| 104 | Array semantics | 📝 Planned gap review, PR 40 | Expand existing collections teaching first; candidate `fundamentals/collections/arrays.md` only if distinct depth is justified. |
| 49 | Indexers | 📥 Pull, PR 30 | Proposed `fundamentals/collections/indexers.md`; property/indexer syntax distinct from API-shape choices in BS03. |
| 105 | Indexes and ranges | 📝 Proposed, PR 30 | `fundamentals/collections/indexes-ranges.md`; exclusive end, supported receivers, and verified copy/view behavior. |
| 75 | Tutorial: Explore indexes and ranges | 📥 Pull, PR 30 | Proposed `fundamentals/tutorials/ranges.md`; preserve the source tutorial URL by redirect. |

### Interfaces (§19)

| # | Article | Status | Notes |
|---|---|---|---|
| 11 | Interfaces introduction | ✅ Exists; review in PR 41 | Retain `fundamentals/types/interfaces.md`; explain contract, instance-state/construction, inheritance, and implementation differences from classes; link shared class rules rather than repeat them. |
| 48 | Interface implementation | 📥 Proposed expansion, PR 41 | Expand the introduction or add `fundamentals/interfaces/implementation.md` if depth warrants it; explicit implementation, member conflicts, properties/indexers. Design choices in BS05. |

### Enums (§20)

| # | Article | Status | Notes |
|---|---|---|---|
| 12 | Enumerations | ✅ Exists; revise in PR 42 | Retain `fundamentals/types/enums.md`; named versus representable values, defaults, parsing versus validation, small flags subset. |

### Delegates (§21)

| # | Article | Status | Notes |
|---|---|---|---|
| 16 | Delegates, lambdas, and events introduction | ✅ Exists; review in PR 43 | Retain `fundamentals/types/delegates-lambdas.md`; `Func<>`/`Action<>`, named methods/lambdas, invocation. Practical capture guidance is already in #56333. |
| 51 | Basic events | 📥 Pull subset, PR 44 | Proposed `fundamentals/delegates/events.md`; subscribe/raise/unsubscribe. Custom delegate/multicast/event mechanics stay deeper. |

### Exceptions and errors (§22)

| # | Article | Status | Notes |
|---|---|---|---|
| 55 | Overview | ✅ Exists | |
| 56 | Using exceptions | ✅ Exists | |
| 57 | Exception handling | ✅ Exists | Ensure exception filters (C# 6), throw expressions (C# 7), await in catch/finally (C# 5) are covered |
| 58 | Creating and throwing exceptions | ✅ Exists | |
| 59 | Compiler-generated exceptions | ✅ Exists | |
| 81 | Tutorial: Handle exceptions with try-catch | ✅ Exists | |
| 82 | Tutorial: Execute cleanup code with finally | ✅ Exists | |

### Attributes (§23)

| # | Article | Status | Notes |
|---|---|---|---|
| 60 | Using attributes | 📝 New | Common attributes, syntax, targets; defer custom attribute creation |

### Documentation comments (Annex D)

| # | Article | Status | Notes |
|---|---|---|---|
| 62 | XML documentation | 📝 New or Pull | `///` comments, common tags |
| 89 | Generate documentation output | 📝 Proposed common task, PR 36 | XML output with `dotnet build`, then link maintained publishing-tool guidance rather than duplicating it. Proposed `xml-comments/common-tasks/`; see [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 80 | Tutorial: Generate API documentation | ✅ Exists | |

### Asynchronous programming basics (supporting work)

| # | Article | Status | Notes |
|---|---|---|---|
| 88 | Async programming overview | 📥 Pull, PR 34 | Move from `asynchronous-programming/index.md`; redirect old URL. |
| 54 | Consuming async methods | 📝 Proposed, PR 34 | `async`/`await`, task-based pattern, async entry points, brief consuming `await foreach`; deeper async topics stay in the focus section. |

### Coding style (post-standard)

| # | Article | Status | Notes |
|---|---|---|---|
| 63 | C# identifier names | ✅ Exists | |
| 64 | C# coding conventions | ✅ Exists | |
| 65 | C# documentation comments | ✅ Exists | |
| 101 | Using .NET analyzers | 📝 New | Roslyn analyzers, .NET SDK analyzers, StyleCop, enabling/configuring via `.editorconfig` and `AnalysisLevel`; finding and fixing code issues |

## Planning Status Summary

| Work state | Scope | Meaning |
|---|---|---|
| Approved architecture and task coverage | Decision 16, 2026-10-29 | Language foundations plus applied guidance; detailed splits/paths remain phase work, with concrete OOP redistribution after the Phase G checkpoint; no implementation started by approval |
| Phase F complete | PRs 19-23, all merged | Pattern section, deconstruction, two pattern tutorials, four Build software guides, and the badge-label tutorial; see the [merge evidence](plan/phase-f-patterns-functional.md) |
| Former October completion target | #55930 / PR 23 | Delivered in #56528 on 2026-10-29; no next phase scheduled by this reconciliation |
| Standard-aligned expansion | Phases H-P | Classes through Documentation comments; reuse current introductions and deeper reference |
| Applied guidance and retirement | BS01-BS12 | Future backlog; BS12 isn't an article and BS11 may merge into existing coverage |
| Programming Guide ledger | 82 articles at the 2026-10-16 snapshot | Two PR 22 source consolidations shipped in #56333; other rows remain future dispositions |

The old ~93-article estimate is retired rather than presented as a current census. Some rows are
retained introductions, some are planned merges/extracts, and some are conditional new articles;
adding them would double-count future outputs. Stable article IDs preserve traceability, not a
guaranteed article total. Consult individual shipped rows for delivery evidence.

## Complete planned Fundamentals TOC

The following is the target TOC for the approved plan, not a copy of the live TOC or authorization
to reorder it now. Building software's shipped placement and first four children remain intact;
later children are approved future task coverage. New
Classes-through-Documentation-comments checkpoints follow standard order while retaining canonical
introduction URLs. Conditional arrays/interface/parsing pages appear only if their task's gap
review justifies separate articles. Never publish those nodes before real content lands.

```yml
# This is the planned structure, not the live Fundamentals TOC.
# It follows the C# standard ordering (§7→§23) and incorporates
# all decisions from the planning discussion.

- name: Fundamentals
  items:

  # ─── §7 Basic concepts: Program structure ───
  - name: Program structure
    items:
    - name: Overview
      href: fundamentals/program-structure/index.md
    - name: Main method and entry points
      href: fundamentals/program-structure/main-command-line.md
    - name: Top-level statements
      href: fundamentals/program-structure/top-level-statements.md
    - name: Namespaces and using directives
      # SLIMMED (Decision 12b): brief intro + cross-reference to the canonical
      # §14 Namespaces article (fundamentals/namespaces/overview.md).
      # Retain this introduction URL; redirect only a genuinely retired URL.
      href: fundamentals/program-structure/namespaces.md
    - name: Preprocessor directives
      # NEW: #if, #region, #nullable, #pragma warning only
      href: fundamentals/program-structure/preprocessor-directives.md
    - name: "Tutorial: Build file-based apps"
      href: fundamentals/tutorials/file-based-programs.md
    - name: "Tutorial: How to display command-line arguments"
      href: fundamentals/tutorials/how-to-display-command-line-arguments.md
    - name: "Tutorial: Console application"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/console-app.md
    - name: "Tutorial: Build a command-line app with System.CommandLine"
      # NEW: System.CommandLine for commands, subcommands, arguments, options
      href: fundamentals/tutorials/system-commandline.md
    - name: Organizing programs
      # NEW: assemblies, namespaces, types as organizational tools (#34836)
      href: fundamentals/program-structure/organizing-programs.md

  # ─── §8 Types ───
  - name: Type system
    items:
    - name: Overview
      # REVISE: value vs reference, unified type system, built-in types
      href: fundamentals/types/index.md
    - name: Built-in types and literals
      # NEW: numeric types (incl unsigned, nint), bool, char, string intro,
      # literal syntax (binary, digit separators, raw string literals),
      # default expressions, implicitly typed variables (var),
      # target-typed new, dynamic binding
      href: fundamentals/types/built-in-types.md
    - name: Tuples and deconstruction
      # REVISE: merge existing tuples + deconstruct articles; add inferred names (C# 7.1),
      # tuple comparison (C# 7.3), with on tuples
      href: fundamentals/types/tuples.md
    - name: Generics
      # NEW: consuming generic types/methods, type inference, basic constraints
      # (class, struct, new(), base type), brief mention of Enum/Delegate/unmanaged
      # constraints, covariance/contravariance on interfaces and delegates (C# 4),
      # collection expressions (C# 12), dictionary initializers, spread elements
      href: fundamentals/types/generics.md
    - name: Type conversions, casting, and boxing
      # PULL from programming guide: casting, conversions, boxing/unboxing, is/as
      href: fundamentals/types/conversions.md
    - name: "Tutorial: Introduction to classes"
      href: fundamentals/tutorials/classes.md
    - name: "Tutorial: Explore record types"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/records.md
    - name: "Tutorial: Converting types"
      displayName: cast, is, as
      href: fundamentals/tutorials/safely-cast-using-pattern-matching-is-and-as-operators.md
    - name: "Tutorial: Choosing between tuples, records, structs, and classes"
      # NEW: teach readers to decide between tuple/record/struct/class/interface
      href: fundamentals/tutorials/choosing-types.md

  # ─── Null safety (§8 nullability, cross-cutting) ───
  - name: Null safety
    items:
    - name: Overview
      # NEW: unified null safety story, comparison of nullable value types
      # vs nullable reference types
      href: fundamentals/null-safety/index.md
    - name: Nullable value types
      # NEW/PULL: T? for value types (C# 2), HasValue, GetValueOrDefault
      href: fundamentals/null-safety/nullable-value-types.md
    - name: Nullable reference types
      # PULL from tutorials + concepts: enable NRT, annotating code, ?, !,
      # flow analysis, all new code should use this
      href: fundamentals/null-safety/nullable-reference-types.md
    - name: Null operators
      # NEW: ?., ?[], ??, ??=, null-conditional assignment (C# 14—use without
      # detailed explanation), is null / is not null
      href: fundamentals/null-safety/null-operators.md
    - name: Resolve nullable warnings
      # PULL from existing nullable warnings content.
      # Task-style article: lives under common-tasks/ per Decision 11.
      href: fundamentals/null-safety/common-tasks/resolve-warnings.md
    - name: Nullable migration strategies
      # PULL from existing migration content
      href: fundamentals/null-safety/migration-strategies.md
    - name: "Tutorial: Explore nullable reference types"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/nullable-reference-types.md

  # ─── Strings (§8.2.5 in standard, standalone per decision) ───
  - name: Strings
    items:
    - name: Overview
      # NEW: string basics, immutability, string vs String, verbatim strings,
      # escape sequences, \e (C# 13)
      href: fundamentals/strings/index.md
    - name: String interpolation
      # PULL/REVISE from tutorials: $"" (C# 6), newlines in interpolations (C# 11),
      # constant interpolated strings (C# 10—use without explanation)
      href: fundamentals/strings/interpolation.md
    - name: Raw string literals
      # NEW: """ syntax (C# 11), raw interpolated strings
      href: fundamentals/strings/raw-string-literals.md
    - name: nameof operator
      # NEW: nameof (C# 6), extended nameof scope (C# 11—use without explanation),
      # unbound generic types in nameof (C# 14—use without explanation)
      href: fundamentals/strings/nameof.md
    - name: Search strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/search.md
    - name: Split strings into substrings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/split.md
    - name: Concatenate strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/concatenate.md
    - name: Modify string contents
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/modify.md
    - name: Compare strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/compare.md
    - name: "Tutorial: Explore string interpolation"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/string-interpolation.md

  # ─── §11 Patterns and pattern matching ───
  # Sequenced before §12/§13 per the standard. Articles live under fundamentals/patterns/.
  - name: Pattern matching
    items:
    - name: Overview
      # SHIPPED: #55966; revised again in #56113.
      # Motivate when/why to use patterns vs. imperative branching.
      href: fundamentals/patterns/pattern-matching.md
    - name: Declaration, constant, and var patterns
      # SHIPPED: #55966; declaration, constant, and var patterns.
      href: fundamentals/patterns/declaration-constant-var-patterns.md
    - name: Type patterns
      # SHIPPED: #55966; type tests and generic inputs.
      href: fundamentals/patterns/type-patterns.md
    - name: Property and positional patterns
      # SHIPPED: #56113; property, extended property, and positional patterns.
      href: fundamentals/patterns/property-positional-patterns.md
    - name: Relational, logical, and parenthesized patterns
      # SHIPPED: #56113; relational, logical, and parenthesized patterns.
      href: fundamentals/patterns/relational-logical-patterns.md
    - name: List and slice patterns
      # SHIPPED: #56113; list and slice patterns.
      href: fundamentals/patterns/list-patterns.md
    - name: Discards and the discard pattern
      # SHIPPED: #55966; moved/reworked with redirects.
      href: fundamentals/patterns/discards.md
    - name: Deconstruct tuples and other types
      # SHIPPED: #56286; records, tuples, custom/extension Deconstruct, mixed forms.
      href: fundamentals/patterns/deconstruct.md
    - name: "Tutorial: Pattern matching basics"
      # SHIPPED: #56286; live navigation places both pattern tutorials under Tutorials.
      href: fundamentals/tutorials/pattern-matching-basics.md
    - name: "Tutorial: Build algorithms using pattern matching"
      href: fundamentals/tutorials/build-algorithms-using-pattern-matching.md

  # ─── §12 Expressions and operators ───
  # NEW section (Decision 12). Fills the §12 operator gap; before §13 Statements.
  - name: Expressions and operators
    items:
    - name: Overview and operator precedence
      # NEW: expression vs. statement, expression classifications,
      # operator precedence and associativity, evaluation order.
      # Cross-links to switch expression (Pattern matching) and LINQ (Statements).
      href: fundamentals/expressions/index.md
    - name: Arithmetic, comparison, logical, and assignment operators
      # NEW: arithmetic (+ - * / %), unary (+ - !), increment/decrement (++ --),
      # relational (< > <= >=), equality operators (== !=; cross-link to
      # Reference vs. value equality), conditional-logical (&& || short-circuit),
      # conditional operator (?:), simple + compound assignment (= += -= ...).
      # EXCLUDED (stay in Language Reference, cross-linked): shift (<< >> >>>),
      # bitwise (& | ^ ~), checked/unchecked.
      href: fundamentals/expressions/operators.md

  # ─── §13 Statements ───
  - name: Statements
    items:
    - name: Selection statements
      # NEW: if/else branching, switch statement, ternary conditional;
      # links to pattern matching for switch expressions.
      # (Deferred cleanup: trim the ?: mention to a cross-reference to
      # Expressions and operators §12.20 — not part of this batch.)
      href: fundamentals/statements/selection-statements.md
    - name: Iteration statements
      # NEW: for, foreach, while, do-while; iterating collections;
      # break and continue in loops
      href: fundamentals/statements/iteration-statements.md
    - name: Working with collections
      # NEW: Arrays, List<T>, Dictionary<K,V>; adding, removing, searching;
      # collection expressions (C# 12); ranges and indexes (C# 8)
      href: fundamentals/statements/collections.md
    - name: LINQ and query expressions
      # NEW (subset): query syntax, fluent syntax, common operators
      # (Where, Select, OrderBy, GroupBy); lambda expressions in LINQ;
      # link to LINQ Focus section for advanced scenarios
      href: fundamentals/statements/linq.md
    - name: Equality comparisons
      # SHIPPED (PR #54849) as "C# Equality comparisons": value vs reference
      # equality, ==, !=, Equals, GetHashCode, ReferenceEquals; struct vs class
      # defaults; record equality (records-first; IEquatable<T> deemphasized).
      # Relocated from Type system into the new fundamentals/expressions/ folder;
      # renders as the first child of the combined "Expressions and statements" node.
      href: fundamentals/expressions/equality.md

  # ─── Build software: SHIPPED in #56333 (2026-10-19) ───
  # First four direct children match the merged TOC. No Functional techniques subgroup.
  # Live placement follows the combined Expressions and statements node.
  - name: Build software
    items:
    - name: Overview
      # Compare behavior and design intent, not the current PR inventory.
      href: fundamentals/building-software/index.md
    - name: Lambda expressions
      # Practical parameter/body forms, capture/static, inline vs named behavior.
      href: fundamentals/building-software/lambdas.md
    - name: Local functions
      # Practical helper scope, parameters/capture, static, recursion, alternatives.
      href: fundamentals/building-software/local-functions.md
    - name: Iterators
      # Synchronous yield, foreach, deferred production vs completed collections.
      href: fundamentals/building-software/iterators.md
    # PROPOSED backlog below, not authored in #56333 and not October commitments.
    - name: Object roles and composition
      href: fundamentals/building-software/object-design.md
    - name: Construction and initialization choices
      href: fundamentals/building-software/object-initialization.md
    - name: Member-shape choices
      href: fundamentals/building-software/member-design.md
    - name: Callbacks and notifications
      href: fundamentals/building-software/callbacks-and-events.md
    - name: Contracts and dependencies
      href: fundamentals/building-software/contracts-and-dependencies.md
    - name: Collection and sequence contracts
      href: fundamentals/building-software/collection-contracts.md
    - name: Resource ownership and lifetime
      href: fundamentals/building-software/resource-lifetime.md
    - name: Failure contracts
      href: fundamentals/building-software/failure-contracts.md
    - name: Values, identity, equality, and copying
      href: fundamentals/building-software/value-and-identity-design.md
    - name: Extensions versus wrappers
      href: fundamentals/building-software/extensions-or-wrappers.md
    - name: Common tasks
      items:
      - name: Parse input
        # CONDITIONAL: omit if BS08/existing string tasks own the whole procedure.
        href: fundamentals/building-software/common-tasks/parse-input.md

  # ─── §14 Namespaces ───
  - name: Namespaces
    items:
    - name: Organizing code with namespaces
      # CANONICAL §14 article (Decision 12b): motivation for namespaces, declaring,
      # file-scoped (C# 10), using directives, aliases, extern alias, nested namespaces.
      # The program-structure namespaces article is slimmed to a brief intro + link here.
      href: fundamentals/namespaces/overview.md

  # Approved construct taxonomy: resolve article splits after Phase G before OOP moves.
  # Canonical type-introduction URLs stay unchanged.
  # §15 Classes
  - name: Classes
    items:
    - name: Overview
      href: fundamentals/types/classes.md
    - name: Records
      # Retain canonical URL. Classes owns record classes; Structs owns the
      # record-class/record-struct comparison in this same article.
      href: fundamentals/types/records.md
    - name: Objects
      href: fundamentals/object-oriented/objects.md
    - name: Class members
      href: fundamentals/classes/index.md
    - name: Access modifiers
      href: fundamentals/classes/access-modifiers.md
    - name: Fields and constants
      href: fundamentals/classes/fields-constants.md
    - name: Properties
      href: fundamentals/classes/properties.md
    - name: Constructors
      href: fundamentals/classes/constructors.md
    - name: Methods
      href: fundamentals/classes/methods.md
    - name: Inheritance and polymorphism
      href: fundamentals/classes/inheritance.md
    - name: Extensions
      href: fundamentals/classes/extensions.md
    - name: Partial types and members
      href: fundamentals/classes/partial-types.md
    - name: "Tutorial: Object-oriented C#"
      href: fundamentals/tutorials/oop.md
    - name: "Tutorial: Inheritance in C# and .NET"
      href: fundamentals/tutorials/inheritance.md

  # §16 Structs
  - name: Structs
    # Differences from classes; link the canonical records comparison.
    href: fundamentals/types/structs.md

  # §17 Arrays and §18 Extended indexing and slicing
  - name: Arrays, indexes, and ranges
    items:
    - name: Array semantics
      # CONDITIONAL: expand existing collections instead if sufficient.
      href: fundamentals/collections/arrays.md
    - name: Indexers
      href: fundamentals/collections/indexers.md
    - name: Indexes and ranges
      href: fundamentals/collections/indexes-ranges.md
    - name: "Tutorial: Explore indexes and ranges"
      href: fundamentals/tutorials/ranges.md

  # §19 Interfaces
  - name: Interfaces
    # Differences from classes, not a repeat of shared declaration/member rules.
    items:
    - name: Overview
      href: fundamentals/types/interfaces.md
    - name: Implementation
      # CONDITIONAL: expand the existing introduction if sufficient.
      href: fundamentals/interfaces/implementation.md

  # §20 Enums
  - name: Enums
    href: fundamentals/types/enums.md

  # §21 Delegates
  - name: Delegates
    items:
    - name: Delegates, lambdas, and events
      href: fundamentals/types/delegates-lambdas.md
    - name: Basic events
      href: fundamentals/delegates/events.md

  # ─── §22 Exceptions ───
  - name: Exceptions and errors
    items:
    - name: Overview
      href: fundamentals/exceptions/index.md
    - name: Using exceptions
      href: fundamentals/exceptions/using-exceptions.md
    - name: Exception handling
      # Ensure exception filters (C# 6) covered,
      # throw expressions (C# 7), await in catch/finally (C# 5)
      href: fundamentals/exceptions/exception-handling.md
    - name: Creating and throwing exceptions
      href: fundamentals/exceptions/creating-and-throwing-exceptions.md
    - name: Compiler-generated exceptions
      href: fundamentals/exceptions/compiler-generated-exceptions.md
    - name: "Tutorial: How to handle an exception using try-catch"
      href: fundamentals/exceptions/how-to-handle-an-exception-using-try-catch.md
    - name: "Tutorial: How to execute cleanup code using finally"
      href: fundamentals/exceptions/how-to-execute-cleanup-code-using-finally.md

  # ─── §23 Attributes ───
  - name: Attributes
    # NEW (brief): using common attributes, attribute syntax,
    # attribute targets; defer creating custom attributes to Advanced
    href: fundamentals/attributes.md

  # ─── §D Documentation comments ───
  - name: XML documentation comments
    items:
    - name: Overview
      # NEW (brief) or PULL: documenting code with ///, common tags
      href: fundamentals/xml-comments.md
    - name: Generate documentation output
      # PROPOSED: compiler XML output; link current publishing-tool guidance.
      # Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/xml-comments/common-tasks/documentation-tools.md
    - name: "Tutorial: Generate API documentation with XML comments"
      href: fundamentals/tutorials/xml-documentation.md

  # Cross-cutting supporting work (Phase Q), not additional standard clauses.
  - name: Asynchronous programming basics
    items:
    - name: Overview
      href: fundamentals/async/index.md
    - name: Consuming async methods
      href: fundamentals/async/consuming-async.md

  - name: Coding style
    items:
    - name: C# identifier names
      href: fundamentals/coding-style/identifier-names.md
    - name: C# coding conventions
      href: fundamentals/coding-style/coding-conventions.md
    - name: C# documentation comments
      href: fundamentals/coding-style/documenting-code.md
    - name: Using .NET analyzers
      # NEW: Roslyn analyzers, .NET SDK analyzers, StyleCop,
      # .editorconfig and AnalysisLevel configuration
      href: fundamentals/coding-style/analyzers.md

  # Live Tutorials entry added in #56528 (2026-10-29), closing #55930 / PR 23.
  # Other tutorial rows above remain beside their planned subject owners.
  - name: Tutorials
    items:
    - name: "Tutorial: Combine C# techniques to generate badge labels"
      href: fundamentals/tutorials/functional-techniques.md
```
