---
model: Claude Opus 4.6 (copilot)
agent: agent
description: Creates a new consolidated compiler error/warning article skeleton and TOC entry
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'todo']
---

# Create a consolidated error article

You are creating a new consolidated compiler error/warning article. The user will provide:

- **Destination filename** — the name of the new `.md` file (e.g., `overloaded-operator-errors.md`)
- **Theme description** — a short description of the theme (e.g., "overflow, underflow, and checked and unchecked operators")
- **Seed error codes** (optional) — a list of new, undocumented error codes to include from the start

## Step 1: Ask for TOC placement

Ask the user: *Where in the TOC should this entry be placed? Provide the name or href of the existing entry it should appear after.*

Wait for the user's answer before proceeding.

## Step 2: Create the destination file

Create the file at `docs/csharp/language-reference/compiler-messages/{destination-filename}` with this structure:

```yaml
---
title: "Resolve errors and warnings related to {theme description}"
description: "This article helps you diagnose and correct compiler errors and warnings related to {theme description}"
f1_keywords:
  # populated from seed error codes, sorted numerically
helpviewer_keywords:
  # populated from seed error codes, sorted numerically
ms.date: {today's date in MM/DD/YYYY format}
ai-usage: ai-assisted
---
```

Then add the body:

```markdown
# Resolve errors and warnings for {short theme title}

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

```

## Step 3: Add the TOC entry

Add an entry in `docs/csharp/language-reference/toc.yml` at the location the user specified. The entry format is:

```yaml
  - name: {Short theme title}
    href: ./compiler-messages/{destination-filename}
    displayName: >
      {theme keywords},
      {CS codes sorted numerically, comma-separated}
```

Look at neighboring entries in the TOC for style and indentation guidance.

## Step 4: Populate seed error codes (if provided)

If the user provided seed error codes, process them as a batch:

For each error code:

1. Extract the numeric portion (e.g., `CS0220` → `220`).
2. Find the constant with that number in the Roslyn source file `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCodes.cs`. The constant name maps to the symbolic name.
3. Find the corresponding `<data>` element in `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx` whose `name` attribute matches the `ErrorCodes.cs` constant name exactly, including the `ERR_` or `WRN_` prefix.
4. Read the verbatim error message from the `<value>` child element.

Then update the destination file:

- Add each code to `f1_keywords` and `helpviewer_keywords` in sorted numeric order.
- Add an entry to the error list in the article body. Use this format:
  ```
  - [**CS{NNNN}**](#anchor-tbd): *{verbatim error message}*
  ```
  Use `#anchor-tbd` as the anchor — these will be updated in the Consolidate phase.
  **Handling format placeholders:** The Roslyn source message may contain interpolation markers like `'{0}'`, `'{1}'`, etc. Replace these with descriptive terms that keep the text as close to the verbatim message as possible for SEO, while still reading as a coherent sentence. Use generic terms like `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'` based on the context of the error. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Look at the XML `<comment>` element following the `<value>` (if present) for hints about what each placeholder represents.
- Add each code to the `displayName` in the TOC entry, in sorted numeric order.

For each seed code, also remove it from the `f1_keywords` front matter in `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`.

## Step 5: Present for review

**Stop and present the created skeleton to the user.** Show:

1. The full destination file content
2. The new TOC entry
3. A summary of any codes removed from the catch-all file

Wait for user approval before ending. Do not proceed to merging or searching — those are separate prompt files.
