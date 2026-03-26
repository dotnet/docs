---
model: Claude Opus 4.6 (copilot)
agent: agent
description: Searches existing docs and Roslyn source for additional related error codes
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'todo']
---

# Search for additional related error codes

You are searching for error codes related to a theme that may have been missed during initial consolidation. The user will provide:

- **Destination filename** — the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`
- **Theme description** — the theme to search for

## Key file locations

- **Destination file**: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- **TOC file**: `docs/csharp/language-reference/toc.yml`
- **Catch-all file**: `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`
- **Roslyn ErrorCodes**: `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCodes.cs`
- **Roslyn Resources**: `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx`

## Phase A: Search existing documentation

1. Read the destination file to collect all error codes already included.
2. Search all files whose names start with `cs` in these folders:
   - `docs/csharp/language-reference/compiler-messages/`
   - `docs/csharp/misc/`
3. For each candidate file, read its content and determine whether the error it documents relates to the theme.
4. Build a list of candidate files with their error codes and a brief reason why they match.

**Present the candidate list to the user and stop.** Format the list as:

```
| File | Error Code | Reason |
|------|-----------|--------|
| cs0220.md | CS0220 | Describes compile-time overflow |
```

Tell the user: *Review this list. Approve the files you want merged, then run `ErrorConsolidation.2.MergeExisting` with the approved list.*

**Wait for the user to respond before proceeding to Phase B.**

## Phase B: Search undocumented errors in the catch-all file

1. Read the `f1_keywords` front matter from `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`.
2. For each error code listed:
   a. Extract the numeric portion (e.g., `CS0463` → `463`).
   b. Find the constant with that number in `ErrorCodes.cs`. The constant will look like `ERR_SomeName = NNNN` or `WRN_SomeName = NNNN`.
   c. Find the corresponding `<data>` element in `CSharpResources.resx` whose `name` attribute matches the constant name (e.g., `ERR_SomeName`).
   d. Read the verbatim error message from the `<value>` child element.
3. Filter the results to only those whose error message relates to the theme.
4. Exclude any codes already in the destination file.

**Present the filtered list to the user and stop.** Format as:

```
| Error Code | Error Message |
|-----------|--------------|
| CS0463 | Evaluation of the decimal constant expression failed |
| CS1021 | Integral constant is too large |
```

Tell the user: *Review this list. Tell me which error codes to add.*

**Wait for the user to respond before proceeding to Phase C.**

## Phase C: Batch add approved error codes

For each approved error code:

1. **Update destination front matter:**
   - Add the code to `f1_keywords` in sorted numeric order.
   - Add the code to `helpviewer_keywords` in sorted numeric order.

2. **Update the error list** in the destination file body:
   - Add an entry in sorted numeric order:
     ```
     - [**CS{NNNN}**](#anchor-tbd): *{verbatim error message from CSharpResources.resx}*
     **Handling format placeholders:** The Roslyn source message may contain interpolation markers like `'{0}'`, `'{1}'`, etc. Replace these with descriptive terms that keep the text as close to the verbatim message as possible for SEO, while still reading as a coherent sentence. Use generic terms like `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'` based on the context of the error. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Look at the XML `<comment>` element following the `<value>` (if present) for hints about what each placeholder represents.
     ```

3. **Update the TOC:**
   - Add the code to the `displayName` for the destination file entry in `docs/csharp/language-reference/toc.yml`, maintaining numeric sort order.

4. **Remove from catch-all file:**
   - Remove the code from `f1_keywords` in `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`.

No redirections are needed for these error codes — they had no standalone articles.

Present a summary of all changes made.
