---
name: error-consolidation-merge-existing
description: Merges standalone C# diagnostic articles into a consolidated article with redirects and TOC updates. Use after the user approves the source list.
---

# Merge Existing Error Articles

Merge an approved list of standalone compiler error or warning articles into an existing consolidated destination. Process the entire approved list, then stop; searching and thematic consolidation are separate skills.

## Required Inputs

Collect these inputs from the user:

- **Destination filename**: The consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`.
- **Theme description**: The theme shared by the diagnostics.
- **Source files**: The user-approved list of existing articles to merge.

## Key Paths

- Destination: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- TOC: `docs/csharp/language-reference/toc.yml`
- Redirections: `.openpublishing.redirection.csharp.json`
- Redirect skill: `.github/skills/redirect-article/SKILL.md`
- Redirect script: `.github/skills/redirect-article/scripts/create-redirect-entry.ps1`

## Batch Process

For each source file in the approved list, complete all the following steps.

### 1. Read and Extract

Read the source and extract:

- The error code from the filename or front matter, such as `CS0220`.
- The verbatim compiler message:
  1. Extract the code's numeric portion.
  2. Find the constant assigned that number in `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs`.
  3. Find the matching `<data>` element in `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx`.
  4. Read its `<value>` child.
- The article body after its front matter and H1.

### 2. Update the Destination

In the front matter, add the code to `f1_keywords` and `helpviewer_keywords` in numeric order.

Add the code to the master error list in numeric order:

```markdown
- [**CS{NNNN}**](#anchor-tbd): *{verbatim compiler error message}*
```

Use `#anchor-tbd` until the consolidation phase assigns thematic anchors.

Replace Roslyn format placeholders such as `'{0}'` and `'{1}'` with descriptive terms while preserving the static message text and producing a coherent sentence. Prefer context-appropriate generic terms such as `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'`. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Use the following XML `<comment>` element, when present, to identify placeholder meanings.

Append the source content as a new H2 section:

```markdown
## CS{NNNN}

{source article content, adapted to fit as a section rather than a standalone article}
```

Remove the source front matter, H1, and `See also` section. Demote existing source headings one level so source H2 headings become H3 headings, and so on.

### 3. Create the Redirect

Follow the `redirect-article` skill. Use its script; do not manually edit the redirection JSON:

```powershell
./.github/skills/redirect-article/scripts/create-redirect-entry.ps1 `
    -RedirectionFile ".openpublishing.redirection.csharp.json" `
    -SourcePath "docs/csharp/language-reference/compiler-messages/{source-filename}" `
    -RedirectUrl "/dotnet/csharp/language-reference/compiler-messages/{destination-filename-without-extension}"
```

If the source is under `docs/csharp/misc/`, use that location in `SourcePath`. Also follow the redirect skill's requirement to find and update repository links to the deleted article.

### 4. Update the TOC

In `docs/csharp/language-reference/toc.yml`:

- Add the code to the destination entry's `displayName`, maintaining numeric order.
- Find and remove the source file's complete TOC entry, including its `- name:` and `href:` block.

### 5. Delete the Source

Delete the source Markdown file after its content, redirect, links, and TOC entry have been handled.

## Present the Batch Summary

After processing every approved source, present:

- All source files merged.
- The count of error codes added.
- All redirects created.
- All TOC entries removed.

Do not proceed to searching or thematic consolidation.
