> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase F: Pattern matching (§11) + Building software — 5 PRs

> *Option A ordering (Decision 12):* Pattern matching (§11) is sequenced **before** Expressions and
> operators (§12) and Statements (§13) in the eventual TOC. The pattern-matching articles move out of
> `fundamentals/functional/` into a dedicated **`fundamentals/patterns/`** folder so patterns stand as
> their own §11 section rather than a sub-topic of Functional techniques.

> **Reconciled 2026-10-16:** [Decision 14](../decisions.md#decision-14-building-software-purpose-and-initial-structure)
> supersedes the former Functional techniques grouping and PR 22 placement gate. The overview,
> lambdas, local functions, and iterators are direct children of **Building software** at
> `fundamentals/building-software/`, authored and accepted in open
> [#56333](https://github.com/dotnet/docs/pull/56333), not merged. Complete syntax remains linked
> reference material; separate Part 1 homes aren't a prerequisite for these practical guides.
> The broader two-part/OOP boundary remains a planning proposal. PR 23 is the only Everyday C#
> completion target for the remainder of October, subject to the dependency gate below.

### PR 19 — Pattern matching: overview + declaration/constant/var + type patterns

[#55966](https://github.com/dotnet/docs/pull/55966) *merged*

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

[#56113](https://github.com/dotnet/docs/pull/56113) *merged 2026-09-25*

> ~10 files (as shipped: 10 files — `expressions/operators.md`, `patterns/list-patterns.md`,
> `patterns/pattern-matching.md`, `patterns/property-positional-patterns.md`,
> `patterns/relational-logical-patterns.md`, three new snippet files, `snippets/patterns/Program.cs`,
> `toc.yml`)

1. New `fundamentals/patterns/property-positional-patterns.md` — property patterns (C# 8), extended property patterns (C# 10, shipped via the member-path `DateTime { Date.DayOfWeek: ... }` example), positional patterns (C# 8)
2. New `fundamentals/patterns/relational-logical-patterns.md` — relational patterns, combinator/logical patterns (`and`, `or`, `not`), parenthesized patterns (C# 9). **As shipped**, titled "Relational, logical, and parenthesized patterns" (not just "Relational and logical patterns")
3. New `fundamentals/patterns/list-patterns.md` — list patterns (C# 11), slice patterns. **As shipped**, titled "List and slice patterns"
4. Snippet files + toc.yml
5. Add the **relational patterns → relational operators** cross-link. **As shipped**, this is bidirectional: `expressions/operators.md` gained an inline forward link to `patterns/relational-logical-patterns.md`, and the new article's "See also" section links back to `expressions/operators.md` (live since PR 16)

> *Coherence check:* new pattern articles slot under the already-live, already-positioned Patterns
> node; the relational-operators link points at a live target (PR 16). No reorder needed here; no
> placeholder. ✅ Confirmed via diff: `toc.yml` only inserts the three new rows under the existing
> Pattern matching node — no reorder. A pre-merge automated review flagged that the "Logical and
> parenthesized pattern reference" link skipped the `#parenthesized-pattern` anchor; the shipped
> article resolved this by splitting it into two separate reference links (`#logical-patterns` and
> `#parenthesized-pattern`), so no follow-up is needed.
>
> *Note for PR 21:* `property-positional-patterns.md` links to the deconstruction article at its
> **current** location, `../functional/deconstruct.md` (that file hasn't moved yet). When PR 21 moves
> it to `fundamentals/patterns/deconstruct.md`, update this in-repo link (the public redirect will
> cover external links, but the internal relative link should point at the new location directly).

### PR 21 — Pattern matching: deconstruction + tutorial

> **Prerequisite now live:** PR 20 (#56113) merged 2026-09-25, so the structural-pattern articles
> (property/positional, relational/logical/parenthesized, list/slice) are all live under
> `fundamentals/patterns/`. PR 21 is unblocked.

> ~6 files

1. Revise `fundamentals/patterns/deconstruct.md` — records, tuples, custom `Deconstruct`, mixed deconstructions. **Also update the inbound relative link** from the newly-shipped `patterns/property-positional-patterns.md` "See also" section, which currently points at `../functional/deconstruct.md`
2. Pull `tutorials/patterns-objects.md` → `fundamentals/tutorials/pattern-matching.md`
3. Updated snippets + toc.yml + redirect (including redirect from former `fundamentals/functional/deconstruct.md`)

> *Coherence check:* completes the Patterns section; the tutorial and revised deconstruct article are
> both live with redirects for every moved path. Patterns §11 is fully coherent after this PR.

### PR 22 — Building software

[#56333](https://github.com/dotnet/docs/pull/56333) **OPEN; authored/accepted, not merged**

Evidence: `more-everyday-csharp` head `4737e1c7fe82c91ed8e6d531a3a78a0f5e9cc11e`,
verified 2026-10-16. Bill accepted the implementation and final editorial pass.
The actual scope exceeds the original ~10-file estimate because consolidation includes snippets,
redirects, and repository-wide inbound-link updates.

1. New `fundamentals/building-software/index.md` — compare valid algorithmic approaches and how code communicates design intent to developers and coding agents. Contextual paragraphs compare inline/named behavior, local/private helpers, parameters/capture, and completed/deferred results.
2. New `fundamentals/building-software/lambdas.md` — practical parameter/body forms, capture, static lambdas, and comparisons with method groups and local functions. Retain the Type system introduction and complete Language Reference article.
3. Rework `programming-guide/classes-and-structs/local-functions.md` into `fundamentals/building-software/local-functions.md` — helper scope, explicit inputs/captured context, static local functions, recursion, and alternatives.
4. Consolidate `iterators.md` and `programming-guide/concepts/iterators.md` into `fundamentals/building-software/iterators.md` — synchronous element production, deferred execution, and iterator/collection/loop/LINQ choices.
5. Four snippet projects under `fundamentals/building-software/snippets/`: `overview/`, `lambdas/`, `local-functions/`, and `iterators/`. Legacy iterator/local-function samples are replaced; the final editorial pass doesn't change snippets.
6. Add four direct Building software children after Expressions and statements in `toc.yml`; remove legacy entries. Redirect consolidated sources and retired `fundamentals/functional/` destinations, and update inbound links. See [source reconciliation](../content-sources.md#building-software-source-reconciliation).

> *Coverage boundary:* the practical guides link to complete syntax and restrictions rather than
> reproduce an exhaustive reference. This PR doesn't implement the breadth tutorial, remaining OOP
> migrations, or every feature in the original inventory, such as local-function attributes.

### PR 23 — Combined-techniques tutorial (historical title: Functional techniques in C#)

**Issue:** [dotnet/docs#55930](https://github.com/dotnet/docs/issues/55930). **October's only Everyday C# completion target.** This is not authored in #56333 and remains a tutorial, not a new reference or section overview.

### Dependency gate: reconcile with PR #56333

PR [#56333](https://github.com/dotnet/docs/pull/56333) remains open. The approved direction is Building software with four direct guides: overview, lambdas, local functions, and iterators. Before authoring PR 23:

1. Read its final review decisions and shipped diff; don't treat the earlier `fundamentals/functional/` proposal as canonical. If PR #56333 changes its scope, recompute the tutorial's gap rather than preserving the original checklist mechanically.
2. Confirm the tutorial still adds a cohesive learning outcome beyond the overview's already-authored combined-techniques example. The tutorial should guide a reader through choices and incremental changes, not copy that example into another page.
3. Confirm the reader-facing title and slug with Bill. Retain `fundamentals/tutorials/functional-techniques.md` as the historical proposed path until that review; a title about combining techniques or building a small algorithm may better express the approved purpose. Don't create both versions or restore a Functional techniques subgroup.
4. Resolve depth links against **live** canonical articles. Intended links are `fundamentals/building-software/{index,lambdas,local-functions,iterators}.md`, the shipped pattern articles, and current LINQ guidance. When a prerequisite hasn't merged to the publishing base, wait for it or use a valid existing target; don't ship links to future paths. Drafting may proceed without declaring the dependency merged.

### Scoped work

1. Build one compact, runnable tutorial that combines a lambda, local helper, pattern expression, iterator, and LINQ only where each serves the small algorithm. Explain what each choice communicates about behavior, scope, inputs/capture, and execution timing. Don't invent a large domain to justify the feature list.
2. Use an introduction to establish the task, stepwise code to teach the decisions, and a short summary of the resulting thought process. Refer to depth guides for syntax and restrictions rather than reteach them. Where comparing equivalent alternatives, show both results and explain the context in prose.
3. Put tutorial snippets beside the approved tutorial destination and add its entry to the live tutorial navigation. Cross-link from Building software when the tutorial is live. Don't move the four practical guides or create empty future nodes.
4. Keep advanced iterator mechanics, LINQ provider internals, broader OOP migrations, and BS01-BS12 out of this PR. Those tasks aren't prerequisites for October's tutorial.

### Done when

- Bill has reviewed the post-#56333 title, placement, scope, and sample choice.
- The tutorial adds a guided end-to-end outcome, not a duplicate overview/reference.
- Every taught concept links to a live canonical depth target; the retired subgroup is absent.
- Samples build and run on the intended released compiler, with output and deferred execution verified.
- The tutorial's navigation, snippet references, and any changed inbound links are build-clean.
- Phase F's remaining work is reconciled explicitly: completing #55930 doesn't imply that an open prerequisite or an unrelated earlier task has merged.
