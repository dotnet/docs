> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase F: Pattern matching (§11) + Building software — 5 PRs

> *Option A ordering (Decision 12):* Pattern matching (§11) is sequenced **before** Expressions and
> operators (§12) and Statements (§13) in the eventual TOC. The pattern-matching articles move out of
> `fundamentals/functional/` into a dedicated **`fundamentals/patterns/`** folder so patterns stand as
> their own §11 section rather than a sub-topic of Functional techniques.

> **Reconciled 2026-10-29: Phase F complete.** All five planned deliveries merged into
> `dotnet/docs` and are present on this rebased planning branch. The first two PRs were already
> recorded; the missing PR 21 and PR 23 links and stale PR 22 status are reconciled below.
> [Decision 14](../decisions.md#decision-14-building-software-purpose-and-initial-structure)
> supersedes the former Functional techniques grouping. The shipped H1/TOC label is **Build
> software**, with four direct guides at `fundamentals/building-software/`. The combined-techniques
> tutorial is under Tutorials, not a restored subgroup. Decision 16 separately adopts the
> language-foundations/applied-guidance organization and Phases G-R as the active plan,
> not work completed by Phase F or newly scheduled here.

| Planning ID | Merged PR | Merge date (UTC) | Merge commit |
|---|---|---|---|
| PR 19 | [#55966](https://github.com/dotnet/docs/pull/55966) | 2026-09-17 | `2f3d9fd69245` |
| PR 20 | [#56113](https://github.com/dotnet/docs/pull/56113) | 2026-09-25 | `26d2cfe2023d` |
| PR 21 | [#56286](https://github.com/dotnet/docs/pull/56286) | 2026-10-06 | `67daa56878f4` |
| PR 22 | [#56333](https://github.com/dotnet/docs/pull/56333) | 2026-10-19 | `7a5a9cf8549d` |
| PR 23 | [#56528](https://github.com/dotnet/docs/pull/56528) | 2026-10-29 | `c2ba99f507e7` |

### PR 19 — Pattern matching: overview + declaration/constant/var + type patterns

[#55966](https://github.com/dotnet/docs/pull/55966) *merged 2026-09-17*

> Original estimate: ~10 files. As shipped: 66 files, including redirects, snippet replacement,
> and inbound-link repairs.

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
>
> **As shipped:** also moved/reworked `fundamentals/patterns/discards.md`, titled "Discards and
> the discard pattern", with its own snippet project. Pattern samples share
> `patterns/snippets/patterns/`; redirects and inbound-link repairs cover the former
> `functional/pattern-matching.md` and `functional/discards.md` homes. The diff confirms the
> Patterns-before-Expressions order and the switch-expression cross-link.

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
> *PR 21 follow-through:* #56286 updated both deconstruction links in
> `property-positional-patterns.md` to `deconstruct.md`, including the
> `#deconstruct-user-defined-types` anchor. The former `../functional/deconstruct.md` follow-up
> is resolved.

### PR 21 — Pattern matching: deconstruction + tutorial

[#56286](https://github.com/dotnet/docs/pull/56286) *merged 2026-10-06*, closing
[dotnet/docs#55928](https://github.com/dotnet/docs/issues/55928).

> Original estimate: ~6 files. As shipped: 44 files, including legacy snippet retirement,
> redirects, and inbound-link repairs.

1. Move/revise `fundamentals/functional/deconstruct.md` → `fundamentals/patterns/deconstruct.md`, H1/TOC "Deconstruct tuples and other types". Covers tuples, positional records, custom/extension `Deconstruct`, mixed declarations, and discards. Samples consolidate into `patterns/snippets/patterns/DeconstructSamples.cs`; inbound links and anchors are updated.
2. Move/rework `tutorials/patterns-objects.md` → `fundamentals/tutorials/pattern-matching-basics.md`, "Tutorial: Pattern matching basics". The canal-lock tutorial has its own `tutorials/snippets/pattern-matching-objects/` project.
3. Relocate the pre-existing toll-calculator tutorial from `fundamentals/tutorials/pattern-matching.md` → `fundamentals/tutorials/build-algorithms-using-pattern-matching.md`, "Tutorial: Build algorithms using pattern matching". The merged destination is neither the original proposed shared slug nor the intermediate `advanced/` destination described in the PR body.
4. Update `toc.yml` with deconstruction under Patterns and both tutorials under Tutorials; remove the now-empty Functional techniques node and legacy "Explore patterns in objects" entry. Redirect the moved paths and repair inbound links.

> *Coherence check:* completes the Patterns section; the tutorial and revised deconstruct article are
> both live with redirects for every moved path. Patterns §11 is fully coherent after this PR.
> The final redirect for the former `fundamentals/tutorials/pattern-matching.md` URL points to
> `pattern-matching-basics`; the legacy top-level `tutorials/pattern-matching.md` URL points to
> `build-algorithms-using-pattern-matching`. This records shipped routing, not a new IA choice.

### PR 22 — Building software

[#56333](https://github.com/dotnet/docs/pull/56333) *merged 2026-10-19*.

The former 2026-10-16 accepted/open status is superseded by the merge.
The actual scope exceeds the original ~10-file estimate because consolidation includes snippets,
redirects, and repository-wide inbound-link updates (51 files as shipped).

1. New `fundamentals/building-software/index.md` — compare valid algorithmic approaches and how code communicates design intent to developers and coding agents. Contextual paragraphs compare inline/named behavior, local/private helpers, parameters/capture, and completed/deferred results.
2. New `fundamentals/building-software/lambdas.md` — practical parameter/body forms, capture, static lambdas, and comparisons with method groups and local functions. Retain the Type system introduction and complete Language Reference article.
3. Rework `programming-guide/classes-and-structs/local-functions.md` into `fundamentals/building-software/local-functions.md` — helper scope, explicit inputs/captured context, static local functions, recursion, and alternatives.
4. Consolidate `iterators.md` and `programming-guide/concepts/iterators.md` into `fundamentals/building-software/iterators.md` — synchronous element production, deferred execution, and iterator/collection/loop/LINQ choices.
5. Four snippet projects under `fundamentals/building-software/snippets/`: `overview/`, `lambdas/`, `local-functions/`, and `iterators/`. Legacy iterator/local-function samples are replaced; the final editorial pass doesn't change snippets.
6. Add four direct **Build software** children after Expressions and statements and before Object-oriented programming in `toc.yml`; remove legacy entries. The overview H1 is "Build software" (metadata title remains "Building software"). Redirect consolidated sources and retired `fundamentals/functional/` destinations, and update inbound links. See [source reconciliation](../content-sources.md#building-software-source-reconciliation).

> *Coverage boundary:* the practical guides link to complete syntax and restrictions rather than
> reproduce an exhaustive reference. This PR doesn't implement the breadth tutorial, remaining OOP
> migrations, or every feature in the original inventory, such as local-function attributes.

### PR 23 — Combined-techniques tutorial (historical title: Functional techniques in C#)

[#56528](https://github.com/dotnet/docs/pull/56528) *merged 2026-10-29*, closing
[dotnet/docs#55930](https://github.com/dotnet/docs/issues/55930). October's remaining completion
target is delivered.

### Dependency gate: reconcile with PR #56333

**Satisfied:** #56333 merged before #56528. The tutorial uses the live practical guides and
pattern/LINQ articles rather than the retired Functional techniques destinations.

### As shipped

Five files changed in #56528: the tutorial, its source/project, the Build software overview,
and `toc.yml`.

1. `fundamentals/tutorials/functional-techniques.md`, **"Tutorial: Combine C# techniques to generate badge labels"**, builds one small program incrementally: sort attendees with a lambda/LINQ, produce copies with an iterator, select messages with patterns, name formatting with a local function, and verify a total.
2. `tutorials/snippets/functional-techniques/Program.cs` holds the complete runnable source and named excerpt regions, with a .NET 10 project beside it. `BADGE_SORT`, `BADGE_COPIES`, `BADGE_FORMAT`, and `BADGE_COUNT` select stages in the same file. Optional `BADGE_DIAGNOSTICS`, `BADGE_REPEAT`, and `BADGE_SNAPSHOT` expose deferred execution, repeated enumeration, and eager caching. The final implementation uses prefixed symbols, not a literal `TRACE` symbol.
3. Prose explains why each technique fits and contrasts valid alternatives, including local/private helpers, inline/named selection, and iterators/completed collections. Each concept links to live Fundamentals, deeper guidance, or reference material.
4. `toc.yml` adds the tutorial under Fundamentals → Tutorials, and `building-software/index.md` links to it from Next steps. No Functional techniques subgroup returns; no source move or redirect is needed.

### Phase closeout and remaining boundary

All PR 19-23 deliverables are accounted for by merged diffs, local articles/snippet paths, and
navigation. No Phase F shipping gap remains. This reconciliation doesn't rerun sample builds or
constitute a full-project link audit.

Advanced iterator mechanics, LINQ provider internals, local-function attributes, broader OOP
migrations, and BS01-BS12 remain outside this phase. The remaining work now follows the
[foundation-first execution sequence](README.md#execution-sequence): G-P, then R's applied
harvesting batches, with Q placed by genuine dependencies. Decision 17 sequences that future work
without reopening this closeout. Decision 16 approves its architectural direction and task coverage
separately from this closeout; neither decision starts implementation or supplies delivery dates.
Detailed splits and final destinations remain assigned phase work; concrete OOP redistribution
follows the Phase G namespace checkpoint.
