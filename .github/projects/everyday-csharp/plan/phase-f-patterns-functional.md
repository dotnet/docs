> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase F: Pattern Matching (§11) + Functional inventory — 5 PRs

> *Option A ordering (Decision 12):* Pattern matching (§11) is sequenced **before** Expressions and
> operators (§12) and Statements (§13) in the eventual TOC. The pattern-matching articles move out of
> `fundamentals/functional/` into a dedicated **`fundamentals/patterns/`** folder so patterns stand as
> their own §11 section rather than a sub-topic of Functional techniques. Functional techniques
> (lambdas, local functions, iterators — PRs 22–23) remain in `fundamentals/functional/`.

> **IA decision gate:** The final sentence above records the existing Option A plan; it isn't the
> approved permanent taxonomy. Under the two-part hypothesis, lambda-expression, local-function, and
> iterator syntax belongs in standard-aligned Part 1, while the Functional overview and tutorial are
> Part 2 candidates. Decide the final homes before approving PR 22. PR
> [#55966](https://github.com/dotnet/docs/pull/55966) **merged 2026-09-17** and supplied
> construct-first evidence for Pattern matching overview/basic patterns; PR
> [#56113](https://github.com/dotnet/docs/pull/56113) (PR 20, merged 2026-09-25) added the
> structural-pattern articles on the same construct-first framing. Neither PR settles the permanent
> Functional/OOP taxonomy question — don't treat either merge as approval of the surrounding
> technique taxonomy.

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

### PR 22 — Functional techniques

> **Placement unresolved:** classify the overview as Part 2 guidance and the three construct articles
> as Part 1 syntax/semantics before implementation.

> ~10 files

1. Revise `fundamentals/functional/index.md` — (new overview article, C# as multi-paradigm)
2. New `fundamentals/functional/lambdas.md` — closures, captures, expression vs. statement lambdas, method group conversions
3. Pull `fundamentals/functional/local-functions.md` — from `programming-guide/classes-and-structs/local-functions.md`
4. Pull `fundamentals/functional/iterators.md` — from `iterators.md` + `programming-guide/concepts/iterators.md`
5. Snippet files + toc.yml + redirects

> *Watch for redistribution:* the existing iterator content includes state-machine internals, `IAsyncEnumerable` mechanics, custom enumerator authoring, and exception-handling rules around `yield`. Those sections fail universality — move them to Language Reference (state-machine details, exception rules) or an Async/Iterators deep dive (`IAsyncEnumerable`, custom enumerators). Keep the Fundamentals iterators article on consuming and writing simple `yield return` iterators.

### PR 23 — Tutorial: Functional techniques in C#

> **Part 2 / Tutorials candidate:** retain as deferred inventory until Bill approves the technique
> area name and placement.

> ~4 files

1. New `fundamentals/tutorials/functional-techniques.md` — breadth-focused tutorial demonstrating functional techniques (lambdas, local functions, pattern matching expressions, iterators, LINQ) in combination rather than depth in any single area
2. Snippet files + toc.yml
