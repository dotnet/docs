> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase H: Remaining Sections — 5 PRs

### PR 34 — Async basics

> ~6 files

1. Create `fundamentals/async/` directory
2. Pull `asynchronous-programming/index.md` → `fundamentals/async/index.md` — async programming overview; redirect old URL
3. New `fundamentals/async/consuming-async.md` — `async`/`await`, task-based pattern, async Main (C# 7.1), brief `await foreach`; link to Async focus section
4. Snippet files + toc.yml + redirect

### PR 35 — Attributes

> ~4 files

1. New `fundamentals/attributes.md` — common attributes, syntax, targets; defer custom attribute creation
2. Snippet files + toc.yml

> *Split rationale:* async and attributes share neither subject matter nor snippet code; they were combined only to fit the file budget. Each topic also has its own redistribution work (async → Async deep dive; attributes → Language Reference / reflection deep dive). Splitting keeps each PR focused.

> *Watch for redistribution:* the existing async overview includes `ConfigureAwait` rules, synchronization-context internals, `ValueTask`, `IAsyncDisposable`, custom awaiters, and `TaskCompletionSource` patterns — all of which fail universality. Move them to the Async deep dive. The existing attributes content includes custom-attribute authoring, attribute-target rules in detail, and reflection-based attribute reading — move those to Language Reference (attribute syntax and targets) or a reflection deep dive. Keep Fundamentals on consuming async APIs with `await` and on applying common attributes that already exist.

### PR 36 — XML docs + Coding style + Console app tutorial

> ~10 files

1. New or pull `fundamentals/xml-comments.md` — `///` comments, common tags
2. New `fundamentals/xml-comments/common-tasks/documentation-tools.md` — generating XML output with `dotnet build`; DocFX; Sandcastle; other current tools (task-style article under the `common-tasks/` subfolder per [Decision 11](../decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials))
3. New `fundamentals/coding-style/design-alternatives.md` — common design decisions: patterns vs. branching, class vs. struct, `record` modifier, tuples, interfaces vs. abstract classes, `enum` vs. sealed hierarchy, delegates vs. single-method interfaces, and others
4. Pull `tutorials/console-teleprompter.md` → `fundamentals/tutorials/console-app.md` + redirect
5. toc.yml + redirects

> Addresses [#34830](https://github.com/dotnet/docs/issues/34830) — XML documentation content from Language Reference moves into Fundamentals via the XML docs articles in this PR.

6. Cross-cutting: all Coding style articles should mention `.editorconfig` usage and link to the EditorConfig section in "Get started". Link to pertinent analyzer rules and code style rules relevant to each article's design decisions.

### PR 37 — Using .NET analyzers

> ~4 files

1. New `fundamentals/coding-style/analyzers.md` — Roslyn analyzers, .NET SDK analyzers, StyleCop, enabling/configuring via `.editorconfig` and `AnalysisLevel`; finding and fixing code issues
2. Snippet files + toc.yml

### PR 38 — Exceptions modernization pass

> ~9 files

1. Revise all 5 exception articles + 2 tutorials in `fundamentals/exceptions/` for latest feature saturation — update all code samples to use file-scoped namespaces, collection expressions, NRT, raw string literals, primary constructors where natural
2. Updated snippet files
3. toc.yml (reorder to match proposed TOC if needed)

> Addresses [#34831](https://github.com/dotnet/docs/issues/34831) — clean up the Exceptions section, move LINQ exceptions article to LINQ section, move Non-CLS exceptions to Advanced section.

> *Watch for redistribution:* in addition to the LINQ exceptions and Non-CLS exceptions articles already flagged for relocation, the existing exceptions content includes CLR exception model details, Structured Exception Handling (SEH) interop, first-chance exceptions, and corrupted-state exception rules. Those sub-sections fail universality — move them to a runtime/advanced deep dive. Keep the modernization pass focused on idiomatic everyday exception handling.

