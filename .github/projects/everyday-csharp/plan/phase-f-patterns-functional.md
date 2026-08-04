> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

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

