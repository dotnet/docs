> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase N: Exceptions (§22)

### PR 38 — Everyday exception handling and cleanup

Retain and revise the seven existing articles in `docs/csharp/fundamentals/exceptions/`:

- `index.md`, `using-exceptions.md`, `exception-handling.md`.
- `creating-and-throwing-exceptions.md`, `compiler-generated-exceptions.md`.
- `how-to-handle-an-exception-using-try-catch.md`, `how-to-execute-cleanup-code-using-finally.md`.

This replaces the vague "modernization pass" with explicit coverage and source accounting.

1. Teach throwing, catching specific exceptions, filters, `throw;` versus a new throw, propagation, and `finally`. Keep throw expressions and ordinary `await` in handlers in context, rather than force every modern syntax form into every sample.
2. Coordinate cleanup and `using` with BS07/legacy PR 32. Exception mechanics remain here; ownership and lifetime choices belong in Building software.
3. BS08 owns "exception versus expected failed input/Try pattern" comparisons, harvesting `programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md` and `programming-guide/types/how-to-convert-a-string-to-a-number.md`. Don't create a dependency on a third-party result abstraction.
4. Reconcile [dotnet/docs#34831](https://github.com/dotnet/docs/issues/34831): retain specialized LINQ exception guidance in LINQ and non-CLS/SEH/runtime-specific handling in advanced material. Verify actual source locations before any move.
5. Keep compiler diagnostics in Language Reference. CLR internals, first-chance/corrupted-state exceptions, and advanced async task supervision don't become beginner exceptions content.

### Review units within PR 38

| Retained owner | Reader outcome and concrete revision | Evidence / exclusions |
|---|---|---|
| `index.md` + `using-exceptions.md` | Orient readers to propagation and where to handle a recoverable failure; shorten repeated syntax in favor of the depth owner. | One small call chain shows an exception reaching a caller, not catch-all code that silently continues. |
| `exception-handling.md` + try/catch how-to | Teach typed catches versus `when` filters, ordering, and `throw;` preservation. Correct the existing terminology that calls the exception type specification itself an exception filter. | Run matched/unmatched filter paths and rethrow; keep detailed runtime/filter-unwind rules in reference. |
| `creating-and-throwing-exceptions.md` + `compiler-generated-exceptions.md` | Explain throwing suitable existing exceptions and recognizing runtime-generated failures; separate task-returning observation and specialized custom-exception authoring. | Audit each specialized section against the scope test before relocation; don't confuse runtime exceptions with compiler diagnostics. Name the advanced owner before removal. |
| Finally how-to, linked from the handling article | Show cleanup on success and handled failure, including failure before resource acquisition completes. | Reuse its stream/null-check scenario; verify cleanup and no masking exception from cleanup. `using` mechanics link reference; BS07 later compares ownership/lifetime designs. |

These are focused review slices, not seven replacement articles or a new tutorial. Keep the
seven URLs unless a specific consolidation proves necessary; any consolidation must identify its
redirect target before deleting a page.

**Dependencies and sequence:** Enter after M, before O. Use completed statements/null-safety;
coordinate snippet changes and preserved extracts with BS07/BS08, which follow P and don't block
exception mechanics. Async examples use live async guidance or Q/PR 34 if that subset is delivered;
ordinary synchronous propagation doesn't require Q.

**Done when:** the seven retained articles have distinct purposes, propagation/filter/cleanup examples are runnable, links route specialized content to real destinations, and any moves have redirects and repaired inbound links. Prefer scope/clarity improvements over cosmetic syntax changes alone.
