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

**Dependencies:** existing statements and null-safety material. Coordinate snippet changes with BS07/BS08; those design articles aren't prerequisites for correcting exception semantics.

**Done when:** the seven retained articles have distinct purposes, propagation/filter/cleanup examples are runnable, links route specialized content to real destinations, and any moves have redirects and repaired inbound links. Prefer scope/clarity improvements over cosmetic syntax changes alone.
