# Draft Plan: Fundamentals Restructuring PR Breakdown

**TL;DR:** Break the ~91-article restructuring into ~35 small, independently mergeable PRs organized in proposed TOC order. Each PR aims for ~10 files (articles, snippets, toc.yml, redirects), adds its content to the live TOC immediately, and leaves the section in a publishable state. PR file budgets are advisory: a PR may exceed ~10 files when relocating text to other sections is the right call (Goal 11), and PRs that grow too large are split along a natural seam into separate, consecutively numbered PRs (for example, the collections/LINQ and equality work split into PR 14a / PR 14b). Every new or revised article follows the example-heavy, latest-version-saturation style from Goals 4 and 8.

**Conventions for every PR:**

The Fundamentals audience is a developer who knows another language and is learning C#. An alternative audience is a new developer that has only months of experience with C# as their first programming language. They don't yet have C# vocabulary, can't recognize C#-specific idioms on sight, and don't share the project context an experienced C# developer takes for granted. The conventions below are grouped by the audience-derived principle they serve so each one's *why* stays visible.

*Sample readability (P1) — write samples that a new C# developer can read line-by-line:*

- All code examples are included from external snippet files (no inline code blocks), and every article has a corresponding snippet project.
- All snippet code uses the full "Everyday C#" feature set per the feature tables.
- Prefer file-based apps over larger project-based samples for simplicity and ease of understanding, unless a feature requires a more complex setup.
- For any construct the sample isn't teaching, pick the most familiar form: use `while` or `foreach` before `for` (reserve `for` for explicit index iteration); use a regular method before a static factory unless the article is about factories.
- Add a brief intent comment on any line whose purpose or syntax isn't immediately obvious — for example, lines like `_ = something;`, a literal argument with hidden significance, a spread element in a collection expression, or the line where deferred LINQ execution actually occurs.
- When a sample illustrates a decision, show *both* branches and include the result as a trailing comment (`// => …`) so readers correlate code to output without running it. When two syntaxes are meant to be equivalent, make the console output identical across both samples so readers can see the equivalence.
- Lead with the newer, recommended form first, then show the equivalent baseline form when it aids understanding. When you contrast correct and incorrect code, show the correct version first, explain why it works, then show the incorrect version with the diagnostic it produces.
- Show each common form of a construct, not just one — for example, a single null-conditional access (`a?.b`) and a chain (`a?.b?.c`) — so readers recognize the pattern when they meet variations.
- Don't use a contextual keyword (`value`, `record`, `field`, `scoped`) as a sample identifier; it reads as the keyword and obscures the lesson.
- In tutorials, when a code block belongs in a new file, tell the reader to create the file and give it a name. Don't drop code that has nowhere to live.
- Never place consecutive code snippets. They are hard to read and harder for readers to follow. Either intersperse explanatory text between snippets or combine related snippets into a single example.

*Terminology (P2) — treat every C# term as new until the article defines it:*

- Define concepts when they are first introduced. Don't assume readers know what a "type" or "namespace" is before those concepts are covered in the proposed TOC. Remember that this is "fundamentals" content. Any term likely to be unfamiliar to a new C# developer should be defined inline at first use — one short sentence — with a link to the deeper reference. This applies to terms the author considers obvious (for example, *dereference*, *type parameter* vs. *type argument*, *primary constructor*), not just terms the author considers new.
- *Use the official term for every concept, and define it.* Match the term used in the language spec, the API reference, or the Microsoft style guide; never coin a synonym for an established term (for example, don't call an annotation a "hint," and don't say null state "moves" when it *changes* on a line). If a familiar term from another language helps orient readers, name it once as a bridge to the C# term (for example, "a map — called a dictionary in C#"), then use the C# term consistently. Introduce the term, define it in one sentence at first use, then state the rule that uses it.
- When a symbol's meaning depends on context (`T?` differs between value types, constrained reference types, and unconstrained generics), spell out which form you mean before listing rules. Lead a constraints discussion with a one-line model of what is being constrained.
- Definitions are less important for concepts that aren't related to the C# language. The goal for Fundamentals is to teach readers how C# works. While we teach through examples, the libraries and packages used in the examples are less important than the language features being demonstrated. For example, when teaching about collections, it's more important to explain what a collection is and how to use them in C# than to provide an in-depth explanation of `List<T>` vs. `Dictionary<K,V>`.
- Cross reference liberally. It's assumed readers are familiar with content in the "Get started" section, so links there should be minimal and scoped to recommendations for beginners to start there instead. Links and cross references should encourage readers to learn more and dive deeper into the fundamental concepts covered in this section.
- Link every API type, member, or namespace named in prose with an `<xref:...>` cross-reference, not plain text or a hand-built URL.
- If and only if a feature was first added in one of the last three released versions (C# 12–14), mention when it was first introduced.

*Reader's project frame (P3) — default to a current project, and teach how to verify settings:*

- Lead with the current-project assumption. "New projects from recent templates set `<Nullable>enable</Nullable>` in the project file" is the default framing for any setup or configuration statement — no opening hedge.
- Immediately follow such statements with a one- or two-sentence pointer that shows existing-project readers where to verify the setting in their own `.csproj` and how to enable it if it's missing.
- Reserve full migration guidance for the migration articles. When the existing-project path is more than a setting check (for example, planning a phased rollout), link out rather than inlining the strategy.
- When a feature is recommended as the fix for a diagnostic, run the code and confirm the diagnostic actually clears in the scenario being recommended. Reviewer skepticism ("does that actually work here?") usually means the verification wasn't done.
- When recommending a modern feature over an older alternative, always include a justification — state *why* the recommended approach is preferred and better than what. If the justification would require an out-of-scope detour, demonstrate the recommended form in code and cut the claim. Never describe older features as obsolete or deprecated (Goal 9).

*Scope discipline (P4) — every section must earn its place in Fundamentals:*

- Apply the two-criteria fit test (Goal 11) to every section, not just every article. *Filter A — universality:* used by almost all C# developers almost all of the time. *Filter B — accessibility:* readable by a developer with less than one month of .NET and C# experience given the Fundamentals coverage that precedes the article.
- When a section fails Filter A, *cut the text from the Fundamentals draft and paste it into the most appropriate existing destination article* (Language Reference, a Deep dives section, or an Advanced section), with light editing for fit. Don't delete the content — pulled articles often carry valuable detail that simply belongs elsewhere. The canonical example is the nullable-reference-type migration article in PR 9: it targets large pre-C# 8 codebases and fails universality, so its migration-strategy text stays in the existing migration article and the Fundamentals NRT article links out instead of inlining.
- When an *entire* article fails Filter A, don't pull it into Fundamentals at all. Document the decision as an explicit "leave in place" line item in the affected PR, with a one-line reason. Revisit when that area of the docs is restructured.
- When content fails Filter B but passes Filter A, *rewrite — don't exclude.* Define vocabulary at first use, simplify the example, and lead with motivation. Accessibility failures are an editing problem, not a scoping problem.
- Identify destinations at planning time, not at review time. If a PR's draft includes redistributed sections, name the destination files in the PR description before writing so reviewers see the full picture and the destinations don't drift.
- Accept that redistribution may push a PR's file count above the ~10-file target. Exceeding the budget is acceptable when the alternative is losing content or merging an off-topic Fundamentals article. If the PR grows too large, split it along a natural seam (see the *Mechanics* group below).

*Structural hygiene that supports the principles above:*

- *Open with what the article covers and its key takeaway.* Don't open with what the article *doesn't* cover or with "X and Y are different," and don't link back to the section overview from the introduction. When the default behavior is usually what readers want, say so, and frame the advanced features as options for when the default doesn't fit.
- Each article follows concept → example → concept → example structure. The concept discussion should include motivating scenarios for the feature or concept being covered. When framing a newer feature, state what the syntax is for, show the newer or less familiar variant first, then show the equivalent baseline case — don't skip the baseline form readers need to understand it.
- One topic per paragraph. A new case (for example, "the same pitfall also applies to arrays of structs") starts a new paragraph.
- Promote a bold paragraph-lead to `###` when it anchors more than one paragraph of content. Inline bold disappears in the TOC and is harder to scan.
- Replace long "the rule is simple" prose with a short structured rule — a one-sentence lead, bold trigger words, then a two- or three-bullet list or a labeled example. For enumerations of operators, options, or common forms, use a short intro sentence plus a bullet list, and include any item that also has its own subsection so the list is complete.
- Prefer articles that are between a 5- and 10-minute read (roughly 1000–2000 words). Longer and shorter articles are allowed, but should be the exception. Put the concepts readers must not miss near the top; don't save key mental models, syntax alternatives, providers, or execution semantics for the final section.

*Mechanics — TOC, metadata, links, redirects:*

- Update `toc.yml` incrementally so new content is navigable immediately.
- Add redirect entries for every moved file (use the "/.openpublishing/redirection.csharp.json" file).
- *Make every move build-clean.* A redirect alone doesn't silence "Invalid link" warnings: when you move or rename a file, also fix every inbound relative link repo-wide (sibling articles, the section `index.md`, `toc.yml`, and cross-section files such as `docs/standard/...`) and the moved file's own outbound links, all in the same PR.
- *Match the snippet mechanism to the code's build behavior.* Code that should compile lives in a snippet project referenced with `:::code` (CI compiles it). Code that intentionally *doesn't compile* stays inline in a fenced ```` ```csharp ```` block, never in a snippet project. Code that intentionally *warns* (for example, a nullable diagnostic) lives in a snippet project configured not to fail on that warning and must actually emit it — don't comment it out or "fix" it. Before deleting or moving a snippet file, grep every `source=` reference to it and update them in the same commit.
- Every article must include a tip near the top that identifies where the article sits in the four-tier content structure (*Get started* → *Fundamentals* → *Deep dives* → *Reference*), describes who it's written for, and routes readers to the right tier based on their experience level (Goal 1). Put Big-O and other complexity details in a `> [!TIP]` note, not inline prose, and verify the statement precisely against the API/reference before review.
- Set the `ms.topic` metadata value in each article's YAML front matter to match the article's content type (`overview`, `tutorial`, `concept`, `how-to`, `troubleshooting`, or `reference`).
- After writing content, verify the article's structure, required metadata, and sections against the template for its content type (see the [Include major topic types](EverydayCSharp-ProjectMap.md#include-major-topic-types) table for template links). This is mandatory for every article before it can be merged to ensure consistency and completeness across the Fundamentals section.
- Do not add F1 or helpviewer keywords to Fundamentals articles. When pulling content from the Reference section, remove any F1 or helpviewer keywords.
- Do not add links to files that will be created in future PRs until those files are live. For example, if PR 3 creates the `fundamentals/types/enums.md` article, then earlier PRs should not link to that file until PR 3 is merged. This may require some temporary duplication of content or placeholders for links, but it will prevent broken links in merged PRs. Instead, when an article is created, add appropriate links to it in earlier articles as needed to connect the content together.
- *Branch from `main`.* When a prerequisite PR is still in review, assume it merges — don't rebase your branch onto the prerequisite's branch, and don't link to files that aren't live yet.
- Every PR description lists redistributed content explicitly. For each section moved out of the Fundamentals draft, name the source (which planned Fundamentals article it was cut from), the destination (file path), and a one-line reason — formatted as `source draft article → destination file path → reason`. This keeps the trail visible for downstream review and for future restructuring of the destination area.
- Follow the *Fundamentals folder layout convention*: each section's `index.md` and concept articles live at the section's top level (for example, `fundamentals/strings/interpolation.md`); task-style articles ("how do I do X?") are grouped under a `<section>/common-tasks/` subfolder (for example, `fundamentals/strings/common-tasks/search.md`) with their snippets under `<section>/common-tasks/snippets/`; tutorials live flat under `fundamentals/tutorials/` rather than nested per section. The section's `toc.yml` renders a nested **Common tasks** group beneath the concept articles. Sections without task-style articles don't get a `common-tasks/` subfolder. See [Decision 11](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials) in the Project Map.
- *Run the pre-submit checklist before opening the PR* rather than leaving it for a late review pass. Confirm that every output-producing sample shows its result as a trailing `// => …` comment; that equivalent samples have matching output; that samples saturate the everyday-feature set even when those features aren't the topic; that no contextual keyword is used as an identifier; that every newly introduced term is defined at first use; that headings avoid gerund (`-ing`) forms unless the official term requires one; and that each article's structure and required metadata match the template for its content type.
- *Every PR leaves its section coherent.* After a PR merges, the section it touches must be publishable: no placeholder or "coming soon"/"TODO"/stub articles, no empty or orphaned TOC nodes, and no broken links. If a subtopic can't be finished in the PR, leave it out of both the article and the TOC rather than shipping a stub.
- *Place or reorder a TOC node only when its backing content is live in the same PR.* Never insert a TOC node ahead of the article that fills it, and never move a section into its final Option A position until the moved content is live. When a PR reorders nodes (for example, lifting Patterns §11 above Expressions §12 and Statements §13), it names the prerequisite PR that made the moved content live.

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

[#52685](https://github.com/dotnet/docs/pull/52685) *Merged*

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
3. *Migration article stays in place* — the `nullable-migration-strategies.md` content remains at `advanced-topics/update-applications/nullable-migration-strategies.md` (the "Update existing apps" area); the Fundamentals NRT article links out to it rather than inlining migration strategy, because the migration guidance targets large pre-C# 8 codebases and fails Filter A universality (Goal 11 / Decision 1). No Fundamentals migration article is created.
4. Pull `tutorials/nullable-reference-types.md` → `fundamentals/tutorials/nullable-reference-types.md` (flat under tutorials, not nested under null-safety)
5. toc.yml + redirects (for the consolidated NRT article, `resolve-warnings.md`, and the NRT tutorial)

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

[#54475](https://github.com/dotnet/docs/pull/54475) *Merged*

> ~10 files

1. Pull `fundamentals/strings/common-tasks/concatenate.md` — from `how-to/concatenate-multiple-strings.md`
2. Pull `fundamentals/strings/common-tasks/modify.md` — from `how-to/modify-string-contents.md`
3. Pull `fundamentals/strings/common-tasks/compare.md` — from `how-to/compare-strings.md`
4. Pull `tutorials/string-interpolation.md` → `fundamentals/tutorials/string-interpolation.md`
5. toc.yml + redirects

> *Watch for redistribution:* the existing concatenate, modify, and compare how-tos include `StringBuilder` vs. concatenation benchmarks, culture-sensitive comparison deep-dives, and `string.Create`-style allocation guidance. Those sections fail universality — cut them to a Strings deep dive (or globalization content for culture-sensitive comparison) rather than carrying them into Fundamentals.

## Phase E: Expressions and Statements (§12–§13) — 7 PRs

> *Eventual TOC order (Option A, standard-faithful):* **Pattern matching (§11) → Expressions and
> operators (§12) → Statements (§13)**. PR build order differs from TOC order because PR 13
> (Statements: selection + iteration) and PR 14a (collections + LINQ) already shipped/are in flight;
> the new Expressions PRs (15, 16) render *before* the Statements node in `toc.yml`. See
> [Decision 12](EverydayCSharp-ProjectMap.md#decision-12-expressions-and-operators-section).
>
> *Decomposition (this batch):* 15 (Expressions overview + precedence) and 16 (Expressions
> operators) are the content PRs; each inserts its own TOC node with a live article behind it. Two
> follow-ups are sequenced *after* their prerequisites so no PR ships a placeholder or a link to a
> not-yet-live target: **17** (deferred `?:` slim-down of the merged Selection-statements article)
> and **18** (cross-link wiring from already-shipped Built-in types and Null safety articles into the
> new Expressions section). 17 and 18 are small, run last in the cluster, and touch shipped articles
> only to remove duplication or add now-safe links.

### PR 13 — Statements: selection + iteration

[#54716](https://github.com/dotnet/docs/pull/54716) *Merged*

> ~8 files

1. Create `fundamentals/statements/` directory
2. New `fundamentals/statements/selection-statements.md` — `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions
3. New `fundamentals/statements/iteration-statements.md` — `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops
4. Snippet files + toc.yml

### PR 14a — Statements: collections + LINQ

[#54807](https://github.com/dotnet/docs/pull/54807) *Merged*

> ~8 files

1. New `fundamentals/statements/collections.md` — Arrays, `List<T>`, `Dictionary<TKey,TValue>`; adding, removing, and searching elements; collection expressions (C# 12); ranges and indexes (C# 8) applied to collections. Lead indexes/ranges with what they're for; show an index from the start and from the end; distinguish range `..` from spread `..`; use *index* rather than *position*; and emphasize that a range end is ***exclusive***. Avoid `[...]` as prose elision where collection-expression spread syntax is in play.
2. New `fundamentals/statements/linq.md` — query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios. Put query syntax, method syntax, providers, and deferred vs. eager execution near the top; make equivalent query/method samples print identical output; annotate the line where deferred execution actually happens; and use one best "for more information" link rather than stacked link boilerplate.
3. Snippet files + toc.yml

> *Reorder label (no content change):* the section/TOC node **"Statements and expressions" →
> "Statements"** (§13). This is a label-only change to the in-flight work; the true §12 expression
> content moves to the new Expressions and operators section (PRs 15/16).

### PR 14b — Type system: equality

> ~6 files

1. New `fundamentals/types/equality.md` — value equality vs. reference equality; `Equals`, `==`, `ReferenceEquals`; struct vs. class defaults; `IEquatable<T>`; record equality semantics
2. Snippet files + toc.yml

> *Split rationale:* equality lives in the Type system area while collections and LINQ live in Statements; the topics share no snippet code and no readers will reach for them together. Splitting also leaves room for the equality redistribution work (move `IEqualityComparer<T>` design, `GetHashCode` contract, and operator overloading rules to Language Reference / OOP deep dive) without crowding collections and LINQ.

> *Cross-link (Decision 12):* the equality *operators* (`==`, `!=`) get a survey slot in the new
> Expressions operators article (PR 16); this article stays in Type system and owns equality
> *semantics*. Cross-link the two so readers move between operator syntax and equality behavior.

> *Watch for redistribution:* the equality article will attract content that fails universality — `IEqualityComparer<T>` design, the full `GetHashCode` contract, operator overloading rules for `==` and `!=`, and equality semantics for ref structs. Move those topics to Language Reference (operator overloading, `GetHashCode` contract) or an OOP deep dive (`IEqualityComparer<T>`), and keep the Fundamentals article scoped to "what `==` and `Equals` do for the types you've already met."

> *Coherence check:* Type-system equality node stays live with a complete article; the outbound
> cross-link to the equality-operator survey is **deferred to PR 16** (its target, `operators.md`,
> lands there). No placeholder; no forward link.

### PR 15 — Expressions: overview + operator precedence

> ~5 files

1. Create `fundamentals/expressions/` directory
2. New `fundamentals/expressions/index.md` — what an expression is; expression vs. statement; expression classifications (value vs. variable); operands and operators; the operator precedence and associativity table (§12.4.2); evaluation order and side effects
3. Snippet files + toc.yml — **insert the "Expressions and operators (§12)" TOC node immediately before the Statements node** (the concrete, live anchor at this point). The node ships with `index.md` behind it, so it's never empty. The final Patterns-above-Expressions ordering is completed by PR 19, when the standalone Patterns §11 node is created
4. Cross-links that are **safe to add now** (targets already live): Expressions overview → LINQ (Statements, PR 14a) and → Null operators `??`/`?.` (Null safety, merged)

> *Spec anchor:* §12.1–§12.2, §12.4.1–§12.4.2. Precedence is rule-heavy — present it as a structured
> table and verify each row against §12.4.2 before review.

> *Deferred links (targets not yet live):* Expressions overview → **switch expression** is added by
> **PR 19** (which creates `patterns/pattern-matching.md`); the **operators** cross-link is added by
> **PR 16** (which creates `operators.md`). Don't link either until those PRs merge.

> *Coherence check:* Expressions node goes live with a complete overview article and the precedence
> table; only backward links (to already-live LINQ and null operators) are wired; forward links to
> switch expression and `operators.md` are deferred to the PRs that create them.

### PR 16 — Expressions: arithmetic, comparison, logical, and assignment operators

> ~6 files

1. New `fundamentals/expressions/operators.md` — arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`), relational (`< > <= >=`), equality operators (`== !=`, survey; cross-link to `fundamentals/types/equality.md` for semantics), conditional-logical (`&& ||` with short-circuiting), the conditional operator (`?:`, §12.20), simple and compound assignment (`= += -= *= /= %=`)
2. Snippet files + toc.yml — add the `operators.md` node under the already-live Expressions node (PR 15)
3. Cross-links safe to add now: operators.md → Type-system equality (PR 14b, live) for equality *semantics*; operators.md → Language Reference for the excluded shift/bitwise/`checked`-`unchecked` operators (Reference already live). Add the reciprocal Expressions-overview → operators link in `index.md` here

> *Spec anchor:* §12.12, §12.14.1–11, §12.8.16, §12.9.2–4/7, §12.16, §12.20, §12.23.1–2/5.

> *Single-article scope (refinement of Q5):* the reduced §12 scope (shift/bitwise/`checked`-`unchecked`
> excluded per Q6) keeps `operators.md` inside the 1000–2000-word target as one coherent article, so
> the Expressions section stays **two articles** (overview + operators). Splitting `operators.md`
> across two PRs (e.g., arithmetic/relational/equality vs. boolean/`?:`/assignment) was considered and
> **rejected**: it would either ship a partial operators article after the first PR (violating the
> coherence rule) or create two thin sub-articles against the two-article decision. One focused article
> is the cleaner review unit.

> *Excluded (Decision 12):* shift operators (`<< >> >>>`, §12.13), integer/bitwise logical operators
> (`& | ^ ~`, §12.15/§12.9.5), and `checked`/`unchecked` (§12.8.20) are too niche for Fundamentals —
> they stay in the Language Reference; this article cross-links out rather than teaching them. Their
> snippets are **not** authored in Fundamentals.

> *Coherence check:* Expressions section is complete after this PR (overview + operators, both live);
> `?:` is taught here as a §12.20 expression; equality-semantics and Language-Reference links point
> only at live targets. The remaining inbound links from shipped Built-in types / Null safety articles
> are wired in PR 18.

### PR 17 — Deferred cleanup: slim `?:` in Selection statements (later pass)

> ~2 files · **DEFERRED — sequence after PR 16; not part of the initial reorder batch**

1. Trim the "ternary conditional operator" coverage in the merged `fundamentals/statements/selection-statements.md` (shipped in PR 13) to a brief mention **plus a cross-reference** to the Expressions `operators.md` article, removing the duplicated teaching of `?:`
2. Updated snippet references (if any) + toc.yml (no node change)

> *Rationale (Q5):* PR 16 now teaches `?:` as a §12.20 expression, so the merged Selection-statements
> article no longer needs to teach it. This is a pure de-duplication + cross-reference pass on already
> shipped content — held back as a *later cleanup* so the initial reorder batch doesn't touch PR 13's
> merged article. **Prerequisite:** PR 16 live (the cross-reference target must exist first).

> *Coherence check:* Selection-statements article stays complete and publishable — `?:` is still
> introduced, just no longer taught in duplicate; the cross-reference points at the now-live
> `operators.md`. No stub, no broken link.

### PR 18 — Cross-link wiring: shipped articles → Expressions section

> ~3 files · **sequence after PRs 15 + 16**

1. Add inbound cross-links from already-shipped articles into the new Expressions section, now that both Expressions articles are live: **Built-in types → Expressions operators** (operators on the types just introduced) and **Null safety (`??`/`?.`) → Expressions overview** (reciprocal of the overview → null-operators link added in PR 15)
2. toc.yml unchanged (no new nodes) — link-only edits to existing, shipped articles

> *Rationale:* these links edit already-merged Fundamentals articles (Built-in types, Null safety)
> whose natural owner PRs shipped before the Expressions section existed. Wiring them in one small,
> clearly-scoped PR after the Expressions content is live keeps every earlier merged PR build-clean and
> avoids forward links. Relational-patterns → relational-operators and Expressions-overview → switch
> expression are **not** here — those are owned by PRs 20 and 19 respectively (the PRs that create the
> patterns side of each link).

> *Coherence check:* purely additive links to live targets; no new articles, no TOC nodes, nothing to
> leave incomplete. Every touched article was already coherent and stays so.

## Phase F: Pattern Matching (§11) + Functional (§12) — 5 PRs

> *Option A ordering (Decision 12):* Pattern matching (§11) is sequenced **before** Expressions and
> operators (§12) and Statements (§13) in the eventual TOC. The pattern-matching articles move out of
> `fundamentals/functional/` into a dedicated **`fundamentals/patterns/`** folder so patterns stand as
> their own §11 section rather than a sub-topic of Functional techniques. Functional techniques
> (lambdas, local functions, iterators — PRs 22–23) remain in `fundamentals/functional/`.

### PR 19 — Pattern matching: overview + declaration/constant/var + type patterns

> ~10 files

1. Revise `fundamentals/patterns/pattern-matching.md` — high-level introduction to pattern matching and switch expressions (C# 8); motivate when and why to use patterns vs. imperative branching
2. New `fundamentals/patterns/declaration-constant-var-patterns.md` — declaration patterns, constant patterns, var patterns (combined into one article because each is brief on its own)
3. New `fundamentals/patterns/type-patterns.md` — type-testing patterns, pattern matching with generics (C# 7.1)
4. Snippet files + toc.yml + redirects (from former `fundamentals/functional/` paths)
5. **Create the `fundamentals/patterns/` TOC section and reorder it into its final Option A position** — the Patterns (§11) node moves above the Expressions (§12) and Statements (§13) nodes. This reorder happens here because this is the first PR where `patterns/` content is live. **Prerequisite:** the Expressions node (PRs 15/16) is already live, so there's a stable §12 node to sit above
6. Add the deferred **Expressions overview → switch expression** cross-link in `expressions/index.md` (its target, `patterns/pattern-matching.md`, becomes live in this PR)

> *Coherence check:* the Patterns node is populated with real articles (overview + basics) the moment
> it's inserted/reordered — never an empty node; redirects cover every moved `functional/` path; the
> switch-expression back-link is wired only now that its target is live. The remaining pattern
> articles (PRs 20–21) expand the already-live, already-positioned Patterns node.

### PR 20 — Pattern matching: property/positional + relational/logical + list patterns

> ~10 files

1. New `fundamentals/patterns/property-positional-patterns.md` — property patterns (C# 8), extended property patterns (C# 10), positional patterns (C# 8)
2. New `fundamentals/patterns/relational-logical-patterns.md` — relational patterns, combinator/logical patterns (`and`, `or`, `not`), parenthesized patterns (C# 9)
3. New `fundamentals/patterns/list-patterns.md` — list patterns (C# 11), slice patterns
4. Snippet files + toc.yml
5. Add the **relational patterns → relational operators** cross-link (from `relational-logical-patterns.md` to `expressions/operators.md`, live since PR 16) so readers connect `< > <= >=` patterns to the operators

> *Coherence check:* new pattern articles slot under the already-live, already-positioned Patterns
> node; the relational-operators link points at a live target (PR 16). No reorder needed here; no
> placeholder.

### PR 21 — Pattern matching: deconstruction + tutorial

> ~6 files

1. Revise `fundamentals/patterns/deconstruct.md` — records, tuples, custom `Deconstruct`, mixed deconstructions
2. Pull `tutorials/patterns-objects.md` → `fundamentals/tutorials/pattern-matching.md`
3. Updated snippets + toc.yml + redirect (including redirect from former `fundamentals/functional/deconstruct.md`)

> *Coherence check:* completes the Patterns section; the tutorial and revised deconstruct article are
> both live with redirects for every moved path. Patterns §11 is fully coherent after this PR.

### PR 22 — Functional techniques

> ~10 files

1. Revise `fundamentals/functional/index.md` — (new overview article, C# as multi-paradigm)
2. New `fundamentals/functional/lambdas.md` — closures, captures, expression vs. statement lambdas, method group conversions
3. Pull `fundamentals/functional/local-functions.md` — from `programming-guide/classes-and-structs/local-functions.md`
4. Pull `fundamentals/functional/iterators.md` — from `iterators.md` + `programming-guide/concepts/iterators.md`
5. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing iterator content includes state-machine internals, `IAsyncEnumerable` mechanics, custom enumerator authoring, and exception-handling rules around `yield`. Those sections fail universality — move them to Language Reference (state-machine details, exception rules) or an Async/Iterators deep dive (`IAsyncEnumerable`, custom enumerators). Keep the Fundamentals iterators article on consuming and writing simple `yield return` iterators.

### PR 23 — Tutorial: Functional techniques in C#

> ~4 files

1. New `fundamentals/tutorials/functional-techniques.md` — breadth-focused tutorial demonstrating functional techniques (lambdas, local functions, pattern matching expressions, iterators, LINQ) in combination rather than depth in any single area
2. Snippet files + toc.yml

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

## Phase H: Remaining Sections — 5 PRs

### PR 34 — Async basics

> ~6 files

1. Create `fundamentals/async/` directory
2. Pull `asynchronous-programming/index.md` → `fundamentals/async/index.md` — async programming overview; redirect old URL
3. New `fundamentals/async/consuming-async.md` — `async`/`await`, task-based pattern, async Main (C# 7.1), brief `await foreach`; link to Async focus section
4. Snippet files + toc.yml + redirect

### PR 35 — Attributes

> ~4 files

1. New `fundamentals/attributes.md` — common attributes, syntax, targets; defer custom attribute creation
2. Snippet files + toc.yml

> *Split rationale:* async and attributes share neither subject matter nor snippet code; they were combined only to fit the file budget. Each topic also has its own redistribution work (async → Async deep dive; attributes → Language Reference / reflection deep dive). Splitting keeps each PR focused.

> *Watch for redistribution:* the existing async overview includes `ConfigureAwait` rules, synchronization-context internals, `ValueTask`, `IAsyncDisposable`, custom awaiters, and `TaskCompletionSource` patterns — all of which fail universality. Move them to the Async deep dive. The existing attributes content includes custom-attribute authoring, attribute-target rules in detail, and reflection-based attribute reading — move those to Language Reference (attribute syntax and targets) or a reflection deep dive. Keep Fundamentals on consuming async APIs with `await` and on applying common attributes that already exist.

### PR 36 — XML docs + Coding style + Console app tutorial

> ~10 files

1. New or pull `fundamentals/xml-comments.md` — `///` comments, common tags
2. New `fundamentals/xml-comments/common-tasks/documentation-tools.md` — generating XML output with `dotnet build`; DocFX; Sandcastle; other current tools (task-style article under the `common-tasks/` subfolder per [Decision 11](EverydayCSharp-ProjectMap.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials))
3. New `fundamentals/coding-style/design-alternatives.md` — common design decisions: patterns vs. branching, class vs. struct, `record` modifier, tuples, interfaces vs. abstract classes, `enum` vs. sealed hierarchy, delegates vs. single-method interfaces, and others
4. Pull `tutorials/console-teleprompter.md` → `fundamentals/tutorials/console-app.md` + redirect
5. toc.yml + redirects

> Addresses [#34830](https://github.com/dotnet/docs/issues/34830) — XML documentation content from Language Reference moves into Fundamentals via the XML docs articles in this PR.

6. Cross-cutting: all Coding style articles should mention `.editorconfig` usage and link to the EditorConfig section in "Get started". Link to pertinent analyzer rules and code style rules relevant to each article's design decisions.

### PR 37 — Using .NET analyzers

> ~4 files

1. New `fundamentals/coding-style/analyzers.md` — Roslyn analyzers, .NET SDK analyzers, StyleCop, enabling/configuring via `.editorconfig` and `AnalysisLevel`; finding and fixing code issues
2. Snippet files + toc.yml

### PR 38 — Exceptions modernization pass

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
- *Polymorphism → redirect to merged Inheritance article* (PR 29)
- *Pattern matching split into 3 PRs* (PRs 19–21) per project map decision: overview + basics | structural patterns | deconstruct + tutorial. **Relocated to `fundamentals/patterns/`** (Decision 12, Option A) so §11 stands as its own section before Expressions/Statements.
- *Namespaces (§14) gets its own PR (PR 24)* at the start of Phase G. **Consolidated (Decision 12b):** `fundamentals/namespaces/overview.md` is the canonical §14 article; the shipped Program-structure "Namespaces" article (PR 1) is slimmed to intro + cross-reference with a redirect + inbound-link fix.
- *Using .NET analyzers gets its own PR (PR 37)* after the Coding style PR; keeps PR 36 at ~10 files
- *PRs within a phase are sequential* (e.g., Type system PRs 3→6 go in order); *phases are largely independent* and can run in parallel if multiple authors contribute
- *Two-criteria fit test applied per section* — universality and beginner accessibility (Goal 11). Sections that fail universality are relocated (text moved, not deleted) to Language Reference, Deep dives, or Advanced; sections that fail only accessibility are rewritten in place.
- *Out-of-scope full articles stay where they are.* Documented as explicit "leave in place" line items in the relevant PR; revisited when that area is restructured. The nullable-reference-type migration article is the canonical example.
- *PR file budgets are advisory when redistribution is required.* A PR may exceed ~10 files when relocating text to other sections is the right call.
- *Oversized PRs are split along natural seams into separate, consecutively numbered PRs* so each stays small enough for focused human review. (The old letter-suffix convention is retired now that upcoming PRs use plain integers; only the in-flight **PR 14a** / **PR 14b** keep their suffixes.) Current split work: Statements collections + LINQ (PR 14a) and Type-system equality (PR 14b); the Expressions section — overview + precedence (PR 15) and operators + assignment (PR 16) — plus its deferred `?:` cleanup (PR 17) and cross-link wiring (PR 18); OOP properties (PR 26) and constructors (PR 27); OOP events + partial types (PR 31) and object lifetime (PR 32); Async basics (PR 34) and Attributes (PR 35).
- *Expressions and operators (§12) gets a dedicated section* (Decision 12, Option A) via PRs 15/16 — `fundamentals/expressions/index.md` (overview + operator precedence/associativity) and `fundamentals/expressions/operators.md` (arithmetic, unary, `++`/`--`, relational, equality survey, `&&`/`||`, `?:`, simple + compound assignment). Kept as **two articles** (refinement of Q5): the Q6 exclusions keep `operators.md` a single coherent article, so it is not split across PRs. **Excluded from Fundamentals** (stay in Language Reference, cross-linked): shift (`<< >> >>>`), integer/bitwise logical (`& | ^ ~`), and `checked`/`unchecked`.
- *Deferred cleanup is its own PR (PR 17).* Trimming the `?:` (ternary conditional) mention in the merged Selection-statements article (PR 13) to a cross-reference — now that `?:` is taught in PR 16 — is a **later-cleanup item, sequenced after 16, not part of the initial reorder batch**.
- *Cross-link wiring into the Expressions section is PR 18*, sequenced after 15/16: it adds inbound links from the already-shipped Built-in types and Null safety articles once both Expressions articles are live. Relational-patterns→relational-operators and Expressions-overview→switch-expression links are owned by PRs 20 and 19 respectively (they land with the patterns-side content).
