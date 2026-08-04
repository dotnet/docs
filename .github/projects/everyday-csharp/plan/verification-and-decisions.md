> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

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
