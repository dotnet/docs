---
name: error-consolidation-setup
description: Creates a consolidated C# compiler diagnostic article skeleton, TOC entry, and optional seed-code metadata. Use to start a new error-consolidation workflow.
---

# Set Up an Error Consolidation Article

Create a new consolidated compiler error and warning article. Do not merge existing articles or search for additional diagnostics in this skill.

## Required Inputs

Collect these inputs from the user:

- **Destination filename**: The new `.md` filename, such as `overloaded-operator-errors.md`.
- **Theme description**: A short description, such as "overflow, underflow, and checked and unchecked operators."
- **Seed error codes** (optional): New, undocumented error codes to include initially.

## Step 1: Ask for TOC Placement

Ask the user:

> Where in the TOC should this entry be placed? Provide the name or href of the existing entry it should appear after.

Stop and wait for the answer before making any changes.

## Step 2: Create the Destination File

Create `docs/csharp/language-reference/compiler-messages/{destination-filename}` with this front matter:

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

Add this body:

```markdown
# Resolve errors and warnings for {short theme title}

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

```

## Step 3: Add the TOC Entry

Add an entry to `docs/csharp/language-reference/toc.yml` immediately after the entry the user specified. Match neighboring indentation and style.

```yaml
  - name: {Short theme title}
    href: ./compiler-messages/{destination-filename}
    displayName: >
      {theme keywords},
      {CS codes sorted numerically, comma-separated}
```

## Step 4: Populate Seed Error Codes

If the user supplied seed codes, process all of them as one batch.

For each code:

1. Extract its numeric portion. For example, `CS0220` becomes `220`.
2. Find the constant assigned that number in `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs`.
3. Find the `<data>` element in `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx` whose `name` exactly matches the constant name, including its `ERR_` or `WRN_` prefix.
4. Read the verbatim compiler message from the element's `<value>` child.

Then:

- Add every code to `f1_keywords` and `helpviewer_keywords`, sorted numerically.
- Add every code to the article's master error list, sorted numerically:

  ```markdown
  - [**CS{NNNN}**](#anchor-tbd): *{verbatim error message}*
  ```

- Use `#anchor-tbd` until the consolidation phase assigns thematic anchors.
- Replace Roslyn format placeholders such as `'{0}'` and `'{1}'` with descriptive terms while preserving the static message text and producing a coherent sentence. Prefer context-appropriate generic terms such as `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'`. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Use the following XML `<comment>` element, when present, to identify placeholder meanings.
- Add every code to the TOC entry's `displayName`, sorted numerically.
- Remove every code from `f1_keywords` in `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`.

## Step 5: Present for Review

Stop and present:

1. The full destination file content.
2. The new TOC entry.
3. A summary of codes removed from the catch-all file.

Wait for user approval before ending. Do not merge existing articles or search for additional diagnostics; those are separate skills.
