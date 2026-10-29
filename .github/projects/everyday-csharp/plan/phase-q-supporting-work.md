> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase Q: Cross-cutting supporting work

These aren't additional standard clauses. Keep them distinct from the Classes-through-Attributes sequence and from applied Building software comparisons.

### Placement and genuine dependencies

Q is a supporting lane, not a phase to insert arbitrarily between G-P or ahead of R. The
[foundation-first sequence](README.md#execution-sequence) governs new applied growth.

| Task | Actual prerequisite and placement |
|---|---|
| PR 34 | Class/method/task vocabulary and N's exception-observation links support the beginner async subset. Schedule when that subset is selected; synchronous R examples needn't wait. An applied example that uses async disposal or async enumeration must first have live consuming-async guidance, or remain synchronous/link to the existing async focus area. |
| PR 37 | Existing coding conventions and a verified SDK analyzer configuration, not the new construct phases. It can support sample review without becoming a delivery gate. |
| PR 45 | Coding-style consolidation is independent. A console-teleprompter rewrite depends on PR 34 only if its retained outcome actually uses async; inspect the current tutorial before setting that gate. Redistribution of design-alternatives follows R's batches, not a competing overview. |

No new tutorial commitment or async prerequisite is inferred for the shipped Phase F tutorial.

### PR 34 — Async basics

Retain the existing scope: extract the beginner consuming subset of `docs/csharp/asynchronous-programming/index.md` into proposed `fundamentals/async/{index,consuming-async}.md`, only after checking current canonical ownership.

Teach awaiting task-returning APIs, returning/awaiting work rather than discarding tasks, ordinary async exception observation, and a brief `await foreach` link. Don't teach fire-and-forget in Fundamentals. Keep cancellation architecture, synchronization-context internals, `ConfigureAwait`, `ValueTask`, custom awaiters, and task-supervision machinery in the async focus area.

Done when consuming samples are runnable, old/new overview roles are reconciled, and any actual move has redirects and repaired links. This isn't an October task.

### PR 37 — .NET analyzers

Proposed `fundamentals/coding-style/analyzers.md`: SDK analyzers, finding/fixing issues, `.editorconfig`, and `AnalysisLevel`. Link to existing tooling and rule reference; don't turn the article into a third-party-analyzer catalog.

Done when a small sample demonstrates a configured rule and correction, settings are verified, and code-style articles link to the appropriate existing rule descriptions.

### PR 45 — Coding style and console tutorial reconciliation

This retains the non-documentation-comments portion formerly bundled in PR 36.

1. Keep naming/conventions guidance in Coding style; link `.editorconfig` and the analyzer article when live.
2. Redistribute the old `design-alternatives.md` inventory into BS01-BS11. Reuse Building software's durable overview instead of creating another competing design-choice overview.
3. Audit `docs/csharp/tutorials/console-teleprompter.md` before moving useful teaching into proposed `fundamentals/tutorials/console-app.md`. Check overlap with current Get started/console tutorials and replace outdated sample setup where needed.
4. Don't make all new theory phases prerequisites for a tutorial that can use existing canonical depth links.

Done when coding conventions, applied choices, XML comments, and console procedures have distinct homes; no second copy of the old design-alternatives backlog survives as an independent article commitment.
