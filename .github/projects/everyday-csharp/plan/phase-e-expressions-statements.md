> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase E: Expressions and Statements (§12–§13) — 7 PRs

> *Eventual TOC order (Option A, standard-faithful):* **Pattern matching (§11) → Expressions and
> operators (§12) → Statements (§13)**. PR build order differs from TOC order because PR 13
> (Statements: selection + iteration) and PR 14a (collections + LINQ) already shipped/are in flight;
> the new Expressions PRs (15, 16) render *before* the Statements node in `toc.yml`. See
> [Decision 12](../decisions.md#decision-12-expressions-and-operators-section).
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

### PR 14b — Equality (planned as Type system; shipped in Expressions)

[#54849](https://github.com/dotnet/docs/pull/54849) *Merged*

> ~6 files

1. New equality article — value equality vs. reference equality; `Equals`, `==`, `ReferenceEquals`; struct vs. class defaults; record equality semantics
2. Snippet files + toc.yml

> **As shipped (differs from the plan above):** during review the article was **relocated out of Type system into a new `fundamentals/expressions/` folder** and now lives at **`fundamentals/expressions/equality.md`** (snippets at `fundamentals/expressions/snippets/equality/`, net10.0, 0 warnings/0 errors). Consequences:
> - The `fundamentals/expressions/` directory and its TOC node were **created here, ahead of PR 15** (PR 15 no longer creates the folder — it adds `index.md` beside the shipped `equality.md`).
> - In `toc.yml` the article renders as the **first child of a combined "Expressions and statements" node** (before *Selection statements*), not under Type system.
> - The article was retitled **"C# Equality comparisons"** (`ms.topic: concept-article`).
> - Review reworked the content: **`IEquatable<T>` was deliberately deemphasized** to an optional secondary optimization; **`GetHashCode` was added** so the member survey is the five members `==`, `!=`, `Equals`, `GetHashCode`, `ReferenceEquals`; the structure is **records-first** (an IMPORTANT callout tells readers to reach for `record` before hand-writing equality), with a manual-implementation section gated on "when a type can't be a record" and links to compiler warnings [CS0660]/[CS0661].
> - The outbound cross-link to the equality-operator survey remains **deferred to PR 16**; for now the article links to `language-reference/operators/equality-operators.md`.

> *Split rationale:* equality lives in the Type system area while collections and LINQ live in Statements; the topics share no snippet code and no readers will reach for them together. Splitting also leaves room for the equality redistribution work (move `IEqualityComparer<T>` design, `GetHashCode` contract, and operator overloading rules to Language Reference / OOP deep dive) without crowding collections and LINQ.

> *Cross-link (Decision 12):* the equality *operators* (`==`, `!=`) get a survey slot in the new
> Expressions operators article (PR 16); this article owns equality
> *semantics*. Cross-link the two so readers move between operator syntax and equality behavior.

> *Watch for redistribution:* the equality article will attract content that fails universality — `IEqualityComparer<T>` design, the full `GetHashCode` contract, operator overloading rules for `==` and `!=`, and equality semantics for ref structs. Move those topics to Language Reference (operator overloading, `GetHashCode` contract) or an OOP deep dive (`IEqualityComparer<T>`), and keep the Fundamentals article scoped to "what `==` and `Equals` do for the types you've already met."

> *Coherence check:* the equality node stays live with a complete article; the outbound
> cross-link to the equality-operator survey is **deferred to PR 16** (its target, `operators.md`,
> lands there). No placeholder; no forward link.

### PR 15 — Expressions: overview + operator precedence

> ~5 files

1. ~~Create `fundamentals/expressions/` directory~~ — **already created by PR 14b** when the equality article was relocated there (see the "As shipped" note under PR 14b). This PR adds `index.md` beside the shipped `equality.md`.
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

1. New `fundamentals/expressions/operators.md` — arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`), relational (`< > <= >=`), equality operators (`== !=`, survey; cross-link to `fundamentals/expressions/equality.md` for semantics), conditional-logical (`&& ||` with short-circuiting), the conditional operator (`?:`, §12.20), simple and compound assignment (`= += -= *= /= %=`)
2. Snippet files + toc.yml — add the `operators.md` node under the already-live Expressions node (PR 15)
3. Cross-links safe to add now: operators.md → Expressions equality (`fundamentals/expressions/equality.md`, PR 14b, live) for equality *semantics*; operators.md → Language Reference for the excluded shift/bitwise/`checked`-`unchecked` operators (Reference already live). Add the reciprocal Expressions-overview → operators link in `index.md` here

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

