> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Verification

- After each PR: verify redirect JSON entries resolve correctly
- After each "pull" PR: confirm the old URL redirects to the new location
- Spot-check 2–3 code samples per PR against the feature checklist (Goals 4 & 8)
- After all PRs: full link-check pass across the Fundamentals section and cross-referencing sections

### Expanded roadmap review contract

- October 2026 has one Everyday C# completion target: [dotnet/docs#55930](https://github.com/dotnet/docs/issues/55930). Reconcile its title, sample gap, and live canonical links against final decisions in open PR #56333 before implementation.
- Phases H-P explicitly account for Classes (§15), Structs (§16), Arrays (§17), extended indexing and slicing (§18), Interfaces (§19), Enums (§20), Delegates (§21), Exceptions (§22), Attributes (§23), and Documentation comments (Annex D). Unsafe code and all other appendixes are excluded.
- The later construct/design taxonomy and proposed paths require Bill's review. PR #56333's approved initial Building software placement isn't reopened.
- Validate all relative planning-file links/anchors, new numeric task-ID uniqueness, legacy task routing, and the Programming Guide source ledger. The ledger must equal the actual 82-article source set at this snapshot, with no omissions or duplicate source rows.
- Existing canonical introductions and already-shipped material aren't new article commitments. Conditional outputs remain conditional until their gap review; don't claim the old rough article estimate as a current total.
- Classes establishes shared rules and covers record classes; Structs and Interfaces teach their differences from that baseline. Verify that links replace repeated rules and the retained records article has coordinated PR 25/39 ownership. Paired record-class/record-struct samples must demonstrate assignment, shallow `with` copies, equality, and positional-property mutability without implying deep immutability.
- On later migration PRs, name every extract and retained section's owner before deleting a mixed source. BS12 coordinates shared-source retirement; preserve useful examples, complete syntax, advanced material, redirects, TOC entries, inbound links, and snippet references.
- This planning edit changes no live content, snippets, redirect JSON, or `docs/csharp/toc.yml`; no new issues, commits, or pushes are authorized.

## Decisions

- *~10 total files per PR* including toc.yml, redirects, and snippets; tutorial-only PRs may be smaller (~4 files)
- *Move + revise in same PR* rather than two-step
- *Incremental TOC updates* — each PR makes its section live immediately
- *Polymorphism → reconcile with canonical Inheritance* (PR 29 / Phase H); verify which legacy sources still exist before scheduling their retirement.
- *Pattern matching split into 3 PRs* (PRs 19–21) per project map decision: overview + basics | structural patterns | deconstruct + tutorial. **Relocated to `fundamentals/patterns/`** (Decision 12, Option A) so §11 stands as its own section before Expressions/Statements.
- *Namespaces (§14) gets its own PR (PR 24)* at the start of Phase G. **Consolidated (Decision 12b):** `fundamentals/namespaces/overview.md` is the canonical §14 article; the shipped Program-structure "Namespaces" article (PR 1) is slimmed to intro + cross-reference with a redirect + inbound-link fix.
- *Using .NET analyzers retains PR 37*, now in Phase Q; PR 36 is documentation comments in Phase P, with its former coding-style/console scope routed to PR 45 and Building software.
- *PRs within a phase are sequential* (e.g., Type system PRs 3→6 go in order); *phases are largely independent* and can run in parallel if multiple authors contribute
- *Two-criteria fit test applied per section* — universality and beginner accessibility (Goal 11). Sections that fail universality are relocated (text moved, not deleted) to Language Reference, Deep dives, or Advanced; sections that fail only accessibility are rewritten in place.
- *Out-of-scope full articles stay where they are.* Documented as explicit "leave in place" line items in the relevant PR; revisited when that area is restructured. The nullable-reference-type migration article is the canonical example.
- *PR file budgets are advisory when redistribution is required.* A PR may exceed ~10 files when relocating text to other sections is the right call.
- *Oversized PRs are split along natural seams into separate, consecutively numbered PRs* so each stays small enough for focused human review. (The old letter-suffix convention is retired now that upcoming PRs use plain integers; only the in-flight **PR 14a** / **PR 14b** keep their suffixes.) Current split work: Statements collections + LINQ (PR 14a) and Type-system equality (PR 14b); the Expressions section — overview + precedence (PR 15) and operators + assignment (PR 16) — plus its deferred `?:` cleanup (PR 17) and cross-link wiring (PR 18); OOP properties (PR 26) and constructors (PR 27); OOP events + partial types (PR 31) and object lifetime (PR 32); Async basics (PR 34) and Attributes (PR 35).
- *Expressions and operators (§12) gets a dedicated section* (Decision 12, Option A) via PRs 15/16 — `fundamentals/expressions/index.md` (overview + operator precedence/associativity) and `fundamentals/expressions/operators.md` (arithmetic, unary, `++`/`--`, relational, equality survey, `&&`/`||`, `?:`, simple + compound assignment). Kept as **two articles** (refinement of Q5): the Q6 exclusions keep `operators.md` a single coherent article, so it is not split across PRs. **Excluded from Fundamentals** (stay in Language Reference, cross-linked): shift (`<< >> >>>`), integer/bitwise logical (`& | ^ ~`), and `checked`/`unchecked`.
- *The broader two-part Fundamentals model remains a hypothesis* (Decision 13). Decision 14 resolves the former Functional techniques inventory as four direct Building software articles, authored and accepted in open [#56333](https://github.com/dotnet/docs/pull/56333), not merged. The expanded Phases H-R now propose the remaining construct/design split for review; they aren't a second implementation of those four guides.
- *PR [#55966](https://github.com/dotnet/docs/pull/55966) and PR [#56113](https://github.com/dotnet/docs/pull/56113) are shipped, evidence-only.* They merged (2026-09-17 and 2026-09-25) for Pattern matching overview/basic patterns and structural patterns, respectively; being merged doesn't expand their scope or count as approval of the surrounding technique taxonomy.
- *Approval gates:* Decision 14 supersedes the former PR 22 label/placement gate; separate Part 1 homes aren't required before its practical guides proceed. Review the new construct/design split, canonical paths, and source-retirement ledger before executing Phases H-R. PR 23 has its own post-#56333 gate and doesn't wait for this later backlog.
- *Durable overviews and contextual comparisons* (Decision 15): introduce the section's long-term purpose, explain valid alternatives with context and small examples, and describe how names, scope, dependencies, and timing communicate design intent to developers and coding agents. Introduce and summarize the decision process rather than rely on unexplained rules.
- *Deferred cleanup is its own PR (PR 17).* Trimming the `?:` (ternary conditional) mention in the merged Selection-statements article (PR 13) to a cross-reference — now that `?:` is taught in PR 16 — is a **later-cleanup item, sequenced after 16, not part of the initial reorder batch**.
- *Cross-link wiring into the Expressions section is PR 18*, sequenced after 15/16: it adds inbound links from the already-shipped Built-in types and Null safety articles once both Expressions articles are live. Relational-patterns→relational-operators and Expressions-overview→switch-expression links are owned by PRs 20 and 19 respectively (they land with the patterns-side content).
