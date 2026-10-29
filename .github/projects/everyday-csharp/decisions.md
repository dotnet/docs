> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Key Decisions

### Decision 1: Null safety is its own section

**Choice:** Null safety gets a standalone sub-section within Fundamentals, covering both nullable value types and nullable reference types with a comparison between the two.

**Rationale:** Null safety is cross-cutting. It touches the type system, expressions, patterns, and API design. Nullable reference types are the single most impactful feature for code quality in C#, and "all new code should use this." Giving it its own section signals that  importance and provides a single place to learn the complete null safety story.

**Terminology:** Use only the official null-state vocabulary, and define each term before the rule that uses it. A variable's *null state* is either *not-null* or *maybe-null*; the null state *changes* on a line (it doesn't "move"). A nullable *annotation* (`?`) states the design intent for a reference type — whether a variable is *meant* to hold null — and is distinct from null state; don't describe an annotation as a "hint." Define "null state" at first use before stating the analysis rules.

**Migration content lives in Advanced.** Strategies for adding nullable annotations to an existing pre-C# 8 codebase fail Filter A (universality) and stay at `advanced-topics/update-applications/nullable-migration-strategies.md`; the Fundamentals null-safety articles link out rather than inlining migration guidance.

### Decision 2: Strings is its own section

**Choice:** Strings get a standalone sub-section within Fundamentals.

**Rationale:** Strings are one of the most-used types in C#, and the existing how-to articles (search, split, concatenate, modify, compare) are among the highest-traffic pages in the C# docs. C# has significantly improved string handling with interpolation (C# 6), raw string literals (C# 11), and interpolated raw strings. The string type also has a rich API surface already documented in the API reference — the Fundamentals content focuses on *using* strings idiomatically, not exhaustively documenting every method.

**Scope boundary:** Custom interpolated string handlers, allocation avoidance techniques, and `Span<char>` manipulation are deferred to Focus
or Advanced sections.

### Decision 3: Remove anonymous types from Fundamentals

**Choice:** Anonymous types are removed from the Fundamentals section
entirely.

**Rationale:** Tuples (C# 7+) are the preferred solution for lightweight unnamed data structures. Anonymous types remain documented in the Language Reference for developers maintaining older code, but they aren't part of "Everyday C#" for new development.

### Decision 4: Async basics subset in Fundamentals

**Choice:** A small async sub-section appears in Fundamentals, after OOP. It covers consuming async methods with `await` and declaring `async` methods that call other async methods. A brief mention of `await foreach` (async streams) links to the Async Focus section.

**Rationale:** Almost all C# applications consume async APIs. Developers need to understand `await` and the `async` method declaration pattern as part of everyday coding. However, the full async model (cancellation, `ConfigureAwait`, parallel patterns, custom awaiters, `TaskCompletionSource`, etc.) belongs in the dedicated Async Focus section.

### Decision 5: New extensions syntax replaces `this` extension methods

**Choice:** The Fundamentals section teaches the new C# 14 extension syntax as the primary way to write extensions. The legacy `this` parameter syntax gets a brief note as the older approach.

**Rationale:** C# 14 extensions are "a major design space" that subsumes and improves upon extension methods. They support extension properties and other member kinds beyond methods. Teaching the new syntax first gives readers the most useful and forward-looking mental model.

**Placement:** Extensions appear in the OOP sub-section, since they extend types with new members.

### Decision 6: Follow the C# standard's ordering

**Choice:** The Fundamentals section ordering follows the C# standard (§7→§23), with non-standard content (coding style, tutorials) appearing after standard-aligned sections.

**Rationale:** The C# standard represents a carefully considered progression through the language. Following it provides a coherent learning path and makes it easy for readers familiar with the standard to find content. It also provides a principled answer to "where does this topic go?" for any future content.

**Revisit status:** Preserve this ordering for canonical syntax and semantics. Decision 13 records the subsequent two-part hypothesis, adopted as the governing plan in Decision 16. Decision 14 supersedes the former Functional techniques placement with the shipped Building software section; detailed OOP splits remain phase work.

### Decision 7: Delegates scope — `Func<>` and `Action<>` are fundamental

**Choice:** Delegates are covered in Fundamentals when used as `Func<...>` and `Action<...>` types. Lambda expressions are the primary syntax shown. More advanced scenarios (declaring custom delegate types, multicast delegates, advanced event patterns) are deferred.

**Rationale:** Every C# developer uses `Func<>` and `Action<>` through LINQ, async callbacks, and everyday APIs. Lambda expressions are the idiomatic way to create delegates. The full delegate model with custom declarations and multicast invocation lists is a deeper topic that most developers encounter less frequently.

**Structure:** The Type system introduction remains at `fundamentals/types/delegates-lambdas.md`. Practical lambda guidance (parameter/body forms, capture, static lambdas, and comparisons with named helpers) shipped at `fundamentals/building-software/lambdas.md` in PR #56333 (merged 2026-10-19). This supersedes the former Functional techniques destination. The proposed OOP callback/event-handler article remains future work, not delivered by that PR.

### Decision 8: Generics scope — consuming is fundamental, authoring is Focus

**Choice:** The basics of generics (consuming generic types like `List<T>`, calling generic methods, basic type constraints) are fundamental. Authoring generic algorithms is a Focus section topic.

**Rationale:** You can't write real C# without consuming generics. `List<T>`, `Dictionary<TKey, TValue>`, `Task<T>`, `Func<T>`, and `IEnumerable<T>` are everywhere. Understanding type parameters, basic constraints, and covariance/contravariance at the consumption level is essential. Designing generic algorithms with complex constraint combinations is a specialized skill.

### Decision 9: Events — basic subscribe/unsubscribe is fundamental

**Choice:** Basic event usage (subscribing, unsubscribing, the standard event pattern) appears in Fundamentals. Custom event accessors, advanced multicast scenarios, and designing event-based architectures are deferred.

**Rationale:** Events are pervasive in .NET (UI frameworks, ASP.NET middleware, domain events). Developers need to know how to subscribe to and raise events. The internal mechanics of custom event accessors are a niche topic.

### Decision 10: Example-heavy articles with "Everyday C#" feature saturation

**Choice:** Every Fundamentals article leads with code examples and uses everyday C# features throughout its samples — not only the feature the article teaches.

**Rationale:** Most engineers learn a language by reading and writing code, not by reading prose descriptions. Articles should therefore be structured as short explanatory text followed by meaningful, runnable examples. Additionally, samples should incorporate the full "Everyday C#" feature set: features from "Include and explain," features from "Use in sample code without detailed explanation," and the applicable subsets from "Include a subset." For instance, an article on exception handling should still use file-scoped namespaces, collection expressions, nullable reference types, and raw string literals when they fit naturally. This consistent exposure helps readers internalize idioms across the entire Fundamentals section.

**Implications for authors:**

- *Structure each article as concept → example → concept → example*, not as a wall of prose with a code block at the end. Put the concepts readers must not miss near the top; when framing a newer feature, state what the syntax is for and show the newer or less familiar variant first, then the equivalent baseline form. Use headings that name the concept without gerund (`-ing`) forms unless the official term requires one, and use a short intro plus bullets for enumerations of operators, options, or common forms, including items that also have their own subsection.
- *Prefer small, focused examples* that each illustrate one point, over large monolithic samples. Don't repeat code or content already shown earlier in the same article; if the recommended form is clear from code and explaining why would pull in out-of-scope concepts, demonstrate it and move on.
- *Make each sample readable on first pass.* For any construct a sample isn't teaching, pick the most familiar form (`while` or `foreach` before `for`; a regular method before a static factory). Add a brief intent comment on any line whose purpose or syntax isn't obvious, such as the spread element in a collection expression or the line that triggers deferred LINQ execution. When the sample illustrates a decision, show both branches and print the result as a trailing comment (`// => …`). When two syntaxes produce the same result, make the output comments identical so the equivalence is visible.
- *Review every sample's using directives, type declarations, and local variables* to confirm they use the latest syntax (e.g., `global using`, file-scoped namespace, `var`, collection expressions, primary constructors) even when those features aren't the article's topic.
- *Treat the three feature tables as a checklist* when writing or reviewing samples. If a feature from "Use in sample code without detailed explanation" appears naturally, use it without commentary. If a feature from "Include a subset" is relevant to the scenario, include it with a brief link to its full article. Keep link boilerplate small: when a paragraph mostly points elsewhere, choose the single best "For more information" target instead of stacking links.

### Decision 11: Fundamentals folder layout — concepts, common tasks, tutorials

**Choice:** Each Fundamentals section uses a three-bucket folder layout:

- *Concept articles and the section overview* live at the section's top level (for example, `fundamentals/strings/index.md`, `fundamentals/strings/interpolation.md`).
- *Task-style articles* that answer "how do I do X?" live under a `<section>/common-tasks/` subfolder (for example, `fundamentals/strings/common-tasks/search.md`), with their snippet projects under `<section>/common-tasks/snippets/`. The section's `toc.yml` renders a nested **Common tasks** group beneath the concept articles — a collapsible subnode, not a flat heading.
- *Tutorials* live flat under `fundamentals/tutorials/` rather than nested per section.

Sections without task-style articles don't get a `common-tasks/` subfolder.

**Rationale:** Readers scan a section's TOC for either "explain this to me" (concepts) or "show me how to do this specific thing" (tasks). Visually separating the two via folder structure and a nested TOC group reduces cognitive load and signals which articles teach a concept versus demonstrate a task. Flat tutorials keep the tutorial index discoverable as a single learning path rather than scattering tutorials across section folders.

**Origin:** Adopted in [PR 11 (#53991)](https://github.com/dotnet/docs/pull/53991), which moved `search.md` and `split.md` under `fundamentals/strings/common-tasks/`, relocated `resolve-warnings.md` to `fundamentals/null-safety/common-tasks/`, and moved the NRT tutorial to the flat `fundamentals/tutorials/` folder.

### Decision 12: Expressions and operators section

**Choice:** Add a dedicated **Expressions and operators (§12)** section, positioned per the C#
standard **after Pattern matching (§11) and before Statements (§13)**. It has two concept articles:
an overview + operator-precedence article (`fundamentals/expressions/index.md`) and an operators
article (`fundamentals/expressions/operators.md`).

**Rationale:** §12 is the largest clause in the standard, but the earlier plan had no home for the
core operator set — arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`),
relational (`< > <= >=`), equality operators (`== !=`), conditional-logical (`&& ||`), the
conditional operator (`?:`), operator precedence/associativity, and simple + compound assignment.
These pass both fit-test filters (universal and beginner-accessible), so they belong in Fundamentals.
The section is sequenced before Statements because expressions are the building blocks that
statements compose, matching §12 → §13.

**Scope boundary (excluded → Language Reference, cross-linked):** shift operators (`<< >> >>>`,
§12.13), integer/bitwise logical operators (`& | ^ ~`, §12.15/§12.9.5), and `checked`/`unchecked`
(§12.8.20) are too niche for everyday code (fail Filter A). They stay in the Language Reference; the
new articles cross-link out. The equality *operators* get a survey slot here, but equality
*semantics* live in the dedicated equality article. **As shipped (PR [#54849](https://github.com/dotnet/docs/pull/54849)), that article was relocated out of Type system into a new `fundamentals/expressions/` folder — it now lives at `fundamentals/expressions/equality.md`** and renders as the first child of the combined "Expressions and statements" TOC node. It is
cross-linked rather than duplicated. The conditional `?:` operator is taught here; trimming its
mention in the merged Selection-statements article is a **deferred later-cleanup item**.

**Historical ordering (Option A; Functional techniques placement superseded by Decision 14):** The Fundamentals section order mirrors the standard where content belongs
to a clause: Program structure → Type system → Null safety → Strings → **Pattern matching (§11)** →
**Expressions and operators (§12)** → **Statements (§13)** → Functional techniques → Namespaces →
OOP → Async → Exceptions → Attributes → XML docs → Coding style. Pattern-matching articles move to a
`fundamentals/patterns/` folder (their own §11 section) instead of `fundamentals/functional/`.

Preserve this as the historical Option A record. Decision 13 introduced the two-part hypothesis;
Decision 14 resolves the former Functional techniques inventory as direct children of Building
software after Expressions and statements in PR #56333. Decision 16 adopts the broader
construct/design separation; concrete OOP redistribution follows the Phase G namespace checkpoint.

**§12 coverage map (for the authors of the two new articles).** §12 is the standard's largest clause
and its subclauses are scattered across already-merged sections; the two new articles own only the
gap. Use this map to avoid duplicating covered material and to wire cross-links to the existing homes.

*Write in the new Expressions articles (the gap — nothing owns these today):* operator precedence &
associativity + evaluation order (§12.4.2); arithmetic `+ - * / %` (§12.12); unary `+ - !`
(§12.9.2–4); increment/decrement `++ --` (§12.8.16, §12.9.7); relational `< > <= >=` (§12.14.1–4);
equality-operator survey `== !=` (§12.14.5–11); conditional-logical `&& ||` with short-circuiting
(§12.16); conditional operator `?:` (§12.20, re-homed from Selection statements); simple + compound
assignment `= += -= *= /= %=` (§12.23.2/.5).

*Already covered elsewhere (cross-link, do not re-teach):* literals/`default`/`new`
(§12.8.2/.17/.21 → Type system > Built-in types); interpolated strings (§12.8.3 → Strings);
`nameof` (§12.8.23 → Strings); tuple literals (§12.8.6 → Type system > Tuples); null-conditional
`?.`/`?[]` and null-coalescing `??`/`??=` (§12.8.8/.11/.13, §12.17 → Null safety > Null operators);
null-forgiving `!` (§12.8.9 → Null safety > NRT); cast/`as` (§12.9.8, §12.14.13 → Type system >
Conversions); index-from-end `^` and range `..` (§12.9.6, §12.10 → Collections / Indexers); `await`
(§12.9.9 → Async); switch expression (§12.11 → Pattern matching, §11); `is` (§12.14.12 → Pattern
matching); throw expression (§12.18 → Exceptions); lambdas (§12.21 → Type system introduction /
Building software practical guidance; complete syntax in Language Reference); query
expressions/LINQ (§12.22 → Statements > LINQ); deconstructing assignment (§12.23.3 → Patterns >
Deconstruction); event assignment (§12.23.6 → OOP > Events). Equality *semantics* (`Equals`,
`GetHashCode`, record equality) live in the dedicated equality article (`fundamentals/expressions/equality.md`, relocated there from Type system in PR #54849); the new
survey cross-links to it.

*Excluded from Fundamentals (Q6 — stay in Language Reference, cross-link out only):* shift
`<< >> >>>` (§12.13); integer/bitwise logical `& | ^` and complement `~` (§12.15, §12.9.5);
`checked`/`unchecked` (§12.8.20).

### Decision 12b: Consolidate Namespaces (§14) to one canonical article

**Choice:** The standalone **Namespaces (§14)** article (`fundamentals/namespaces/overview.md`,
article #100) is the canonical §14 home. The shipped Program-structure article
`fundamentals/program-structure/namespaces.md` (article #4) is slimmed to a brief intro +
cross-reference to #100.

**Rationale:** §14 Namespaces is its own clause, distinct from §7 program structure, and the two
articles duplicated file-scoped namespaces, global/static `using`, and aliases. Consolidating removes
the overlap and keeps Program structure focused on §7. Because the program-structure article is
already published, the slim requires a redirect (if any URL changes) and a repo-wide inbound-link fix
per the build-clean rule.

### Decision 13: Two-part Fundamentals IA hypothesis

**Status:** Historical working hypothesis, adopted as the governing plan on
2026-10-29 in Decision 16. Decision 14 separately settled Building software's name,
direct four-article structure, and initial placement; PR #56333 didn't itself approve the broader model.

**Hypothesis:** Organize Fundamentals in two parts:

1. A standard-ordered sequence of compact articles that define terms and explain syntax and
   semantics for common constructs. Examples should establish conceptual types, purpose, result use,
   and why each construct fits.
2. A later set of standalone, actionable, example-rich guidance articles that explain when to apply
   syntax, idioms, and programming techniques.

**Original implications (Functional techniques treatment superseded by Decision 14):** `Functional techniques` and `Object-oriented programming` aren't C# standard
clauses. Treat them as Part 2 move candidates. Their construct articles—lambda expressions, local
functions, iterators, type and member declarations, inheritance mechanics, interfaces, events, and
`using` syntax—remain candidates for canonical homes in Part 1. Technique articles should link to
canonical construct articles without duplicating their syntax rules.

**Evidence, not scope:** PR [#55966](https://github.com/dotnet/docs/pull/55966) (merged 2026-09-17)
and PR [#56113](https://github.com/dotnet/docs/pull/56113) (merged 2026-09-25) shipped the Pattern
matching overview, basic patterns, and structural patterns (property/positional,
relational/logical/parenthesized, list/slice). Their neutral, construct-first treatment is useful
input to this IA decision; being merged doesn't settle the permanent Functional/OOP taxonomy, and
neither PR should be read as expanding into future technique guidance.

**Current implementation questions:** Decision 16 settles the broader model and adopts the
expanded phase coverage. Resolve each mixed OOP article's exact split boundaries, retained
content, destinations, and redirect targets during its assigned work, after the Phase G namespace
checkpoint. Don't reopen the shipped section's initial placement or require separate Part 1 homes
for #56333's lambda, local-function, and iterator guides. Complete syntax and restrictions remain
linked reference material.

### Decision 14: Building software purpose and initial structure

**Accepted:** originally reconciled 2026-10-16 against then-open PR
[#56333](https://github.com/dotnet/docs/pull/56333), head
`4737e1c7fe82c91ed8e6d531a3a78a0f5e9cc11e`.

**As shipped, reconciled 2026-10-29:** #56333 merged 2026-10-19 at `7a5a9cf8549d`.
Final review changed the H1 and TOC label to **Build software**; the folder remains
`building-software/`, and the overview metadata title remains "Building software".
The accepted purpose and direct-child structure below are unchanged.

**Choice:** Building software teaches how valid approaches to algorithms can produce the same
results yet communicate different design intent. Developers and coding agents infer intent from
code shape, names, scope, dependencies, and execution timing. The section combines language
elements introduced earlier to help readers align those expectations with their actual design.
Its purpose isn't a catalog of the features in the current PR or a tutorial on one paradigm.

**Initial structure:** The merged `docs/csharp/toc.yml` places **Build
software** after Expressions and statements and before Object-oriented programming. Its direct
children are Overview, Lambda expressions, Local functions, and Iterators, at
`fundamentals/building-software/{index,lambdas,local-functions,iterators}.md`. There is no nested
Functional techniques group. This supersedes the earlier Functional techniques inventory and the
intermediate proposal to nest that group beneath Building software.

The three companion articles lead with practical choices, then supply enough syntax and examples
to apply them. They link to complete reference rules rather than claim exhaustive syntax ownership.
The Type system delegates/lambdas introduction remains separate and links to the practical guide.
The combined-techniques tutorial shipped separately in #56528; the future OOP work isn't completed
by either PR.

**Delivery status:** Its four articles, snippet projects, legacy-source consolidation, redirects,
inbound-link updates, and TOC changes **shipped in #56333**. The previously accepted/open status
is superseded by the merge. The separate combined-techniques tutorial subsequently shipped in
[#56528](https://github.com/dotnet/docs/pull/56528) on 2026-10-29; it doesn't complete the future OOP work.
See [source coverage](content-sources.md#building-software-source-reconciliation) and
[article status](toc-and-articles.md#building-software).

### Decision 15: Durable overviews and contextual comparisons

**Accepted:** 2026-10-16; reflected in PR #56333 at `4737e1c7fe`.

**Choice:** Section overviews explain the section's long-term purpose, not the current PR contents.
Comparison guidance names valid alternatives and explains their context and the expectations each
communicates. Use short explanatory paragraphs with small inline examples, not terse unexplained
rules such as "Start with what the caller needs." Introduce *caller* as the code that supplies
inputs, invokes the operation, and uses its results.

The accepted overview develops four comparisons:

- Inline behavior, such as `Where(task => task.Priority > 3)`, exposes the steps at the point of
  use; a named helper, such as `Where(IsUrgent)`, emphasizes purpose.
- A local function limits a helper to its containing member; a private method makes it available
  to other members and suggests reuse across the type.
- Explicit parameters expose supplied inputs; captured variables connect a helper to its
  surrounding context. `static` prevents capture.
- A method that builds a completed collection finishes that work before returning it; a deferred
  iterator produces elements on demand. The same values can involve different execution timing.

First identify the needed behavior, then consider readers' inferred expectations, choose the form
that aligns with the design, and explain behavior code shape alone doesn't reveal. For example,
`IEnumerable<T>` alone doesn't establish execution timing because collections and iterators can
both expose it. Avoid unsupported universal preferences or a detailed syntax tutorial in the
overview.

**Scope of the final editorial pass:** The overview expands the four comparisons into explanatory
paragraphs. Lambdas, local functions, and iterators receive light framing/clarification edits only;
snippets are unchanged in the latest commit. Preserve this contextual comparison style in future
Everyday C# guidance.

### Decision 16: Adopt language foundations and applied guidance as the governing plan

**Accepted:** 2026-10-29: "Let's consider the proposal as the new plan. Make any
edits to the project map and phases."

**Choice:** Adopt the October planning expansion and its language-foundations/applied-guidance
organization as the active plan, replacing Decision 13's hypothesis status. Language foundations
follow standard order through Namespaces, Classes, Structs, Arrays/indexes/ranges, Interfaces,
Enums, Delegates, Exceptions, and Attributes, plus Documentation comments. Classes establishes
the shared baseline, including record classes; Structs and Interfaces teach their differences.
Retain canonical introductions and the coordinated record-class/record-struct coverage.

Build software supplies applied design and algorithm choices, harvesting useful Programming
Guide material without duplicating syntax explanations. Phases G-R and BS01-BS12 are the
approved task coverage, including review and potential splitting of mixed OOP articles. Their
conditional outputs remain conditional; the plan doesn't require a new article for every task.

**Implementation boundary:** Phase G remains namespace consolidation and the checkpoint before
concrete OOP redistribution. Resolve detailed per-article split boundaries, final destinations,
advanced/reference owners, and redirect targets in the assigned phase work before moves.
Decision 17 now supplies the foundation-first execution sequence; phase letters and historical
PR IDs remain unchanged.
Keep all scope exclusions, snippet/readability rules, and Decisions 14-15 intact.

**Shipped preservation:** Build software's current placement, four direct guides, and URLs stay
as shipped in #56333. In particular, its lambda, local-function, and iterator guides don't need
new language-foundations homes. Phase F and #55930 remain complete through #56528.

**Authorization:** This approval adopts the plan; it doesn't start phase work, authorize article
moves or live TOC reorganization, create issues, or authorize commits or pushes. Implementation scheduling follows Decision 17's order.
No new delivery dates or workload totals are implied.

### Decision 17: Foundations-first execution and source harvesting

**Team decision, 2026-10-29.**

**Sequence:** Treat shipped expressions, statements, collections, equality, patterns, and the
Phase F guides/tutorial as completed prerequisites. Finish G Namespaces → H Classes → I Structs →
J Arrays/indexes/ranges → K Interfaces → L Enums → M Delegates/events → N Exceptions →
O Attributes → P Documentation comments before substantial new Phase R applied drafting/delivery.
This supersedes the earlier blanket flexibility to choose any later phase. It doesn't reorder
the shipped Build software section or require duplicate syntax homes for its practical guides.

**Execution detail:** The [phase index](plan/README.md#execution-sequence) preserves historical
PR identifiers and distinguishes internal task dependencies from review order. Supporting Q
work uses its genuine dependencies; optional style/analyzer/console work is not a new priority
or gate. Existing canonical articles can supply prerequisite links without being recreated.

**Harvesting:** Phase R proceeds through object/state design (BS01/PR 33, BS02, BS03),
contracts/values/extensions (BS05, BS09, BS10), supplied behavior/sequences (BS04, BS06),
lifetime/failure/input (BS07/PR 32, BS08, BS11), and retirement closeout (BS12). BS12 starts
tracking during foundations, not only in the last batch. Foundation pulls preserve named
applied extracts until their later batch; no partial extraction authorizes deleting a mixed source.
Programming Guide remains a source to retire, not a permanent destination.

**Boundary:** Exact conditional article splits and advanced redirect targets remain assigned
implementation questions, with evidence required before retirement. This decision sequences
the plan only: no article moves, live navigation changes, new issues, commits, pushes, calendar
or file-count commitments.

## Roadmap instruction: October 2026 planning expansion

**Requested:** 2026-10-16.

**Historical execution scope:** Only [dotnet/docs#55930](https://github.com/dotnet/docs/issues/55930)
was targeted for completion during the rest of October, with its tutorial to follow PR #56333's
final decisions. **Closeout 2026-10-29:** #56333 merged 2026-10-19; #55930 shipped in #56528 on
2026-10-29. [Phase F](plan/phase-f-patterns-functional.md) is complete; no new scope is scheduled.

Expand the plan after Phase G with explicit standard-aligned coverage of classes, structs,
arrays/indexes/ranges, interfaces, enums, delegates, exceptions, attributes, and Documentation
comments. Documentation comments are included despite being an annex; Unsafe code and the
other appendixes are excluded from this Fundamentals expansion. Harvest Programming Guide
material as useful instead of assuming all those subjects require new content.

Sweep Programming Guide for Building software candidates and record concrete future tasks.
The [expanded phase plans](plan/README.md#plan-index--prs-by-phase) and
[82-source ledger](plan/programming-guide-inventory.md) implement this planning request locally.
Decision 16 records 2026-10-29 adoption of this expansion as the active plan. Detailed
article boundaries and final paths remain implementation decisions, not a blanket architecture
approval gate. Plan approval doesn't authorize publication, content moves, new issues, commits,
or pushes. Decisions 14-15 and PR #56333's initial structure remain intact.

## Roadmap guidance: Class-first differences and records

**Requested:** 2026-10-16.

Follow the standard's current teaching strategy: Classes establishes the shared rules, while
Structs and Interfaces explain how they differ from classes. Link common rules rather than
repeat the same member/declaration lessons in three sections.

Expand Classes to cover record classes. Structs explicitly covers the differences between
`record class` and `record struct`, including reference/value semantics, assignment and shallow
`with` copies, equality, inheritance, and positional-property mutability. Neither form implies
deep immutability.

[PR 25](plan/phase-h-classes.md#record-classes-within-pr-25) and
[PR 39](plan/phase-i-structs.md) coordinate sections of the existing `fundamentals/types/records.md`;
don't create competing records articles or replace its canonical URL. The early Type system
orientation remains useful. This guidance changes the plan, not October's scope or live articles.
