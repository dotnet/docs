---
model: Claude Opus 4.6 (copilot)
agent: agent
description: Merges existing standalone error articles into a consolidated article
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'todo']
---

# Merge existing error articles into a consolidated article

You are merging existing standalone compiler error/warning articles into a consolidated destination file. The user will provide:

- **Destination filename** — the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`
- **Theme description** — the theme these errors relate to
- **Source files** — a list of existing error article files to merge (already approved by the user)

## Key file locations

- **Destination file**: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- **TOC file**: `docs/csharp/language-reference/toc.yml`
- **Redirection file**: `.openpublishing.redirection.csharp.json`
- **Redirect script**: `.github/skills/redirect-article/scripts/create-redirect-entry.ps1`

## Batch process: for each source file

Process the entire approved list. For each source file:

### 1. Read and extract

Read the source file and extract:
- The error code (from the filename or front matter, e.g., `CS0220`)
- The error message: extract the numeric portion of the error code, find the constant with that number in `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCodes.cs`, then find the matching `<data>` element in `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx` and read the verbatim text from its `<value>` child element.
- The article body content (everything after the front matter and H1)

### 2. Update the destination file

**Front matter:**
- Add the error code to `f1_keywords` in sorted numeric order.
- Add the error code to `helpviewer_keywords` in sorted numeric order.

**Error list:**
- Add an entry to the error list at the top of the article, in sorted numeric order. Format:
  ```
  - [**CS{NNNN}**](#anchor-tbd): *{verbatim compiler error message}*
  ```
  Use `#anchor-tbd` as a placeholder anchor — these will be finalized in the Consolidate phase.
  **Handling format placeholders:** The Roslyn source message may contain interpolation markers like `'{0}'`, `'{1}'`, etc. Replace these with descriptive terms that keep the text as close to the verbatim message as possible for SEO, while still reading as a coherent sentence. Use generic terms like `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'` based on the context of the error. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Look at the XML `<comment>` element following the `<value>` (if present) for hints about what each placeholder represents.

**Content:**
- Add the source file's content as a new H2 section at the end of the destination file:
  ```markdown
  ## CS{NNNN}

  {source article content, adapted to fit as a section rather than standalone article}
  ```
  Remove any front matter, H1 heading, and `See also` sections from the pasted content. Adjust heading levels (H2 in the source becomes H3, etc.).

### 3. Create a redirect

Use the `create-redirect-entry.ps1` script to add a redirect from the source file to the destination:

```powershell
./.github/skills/redirect-article/scripts/create-redirect-entry.ps1 `
    -RedirectionFile ".openpublishing.redirection.csharp.json" `
    -SourcePath "docs/csharp/language-reference/compiler-messages/{source-filename}" `
    -RedirectUrl "/dotnet/csharp/language-reference/compiler-messages/{destination-filename-without-extension}"
```

If the source file is in `docs/csharp/misc/`, adjust the `SourcePath` accordingly.

### 4. Update the TOC

In `docs/csharp/language-reference/toc.yml`:
- Add the error code to the `displayName` for the destination file entry, maintaining numeric sort order.
- Find and remove the TOC entry for the source file (the `- name:` / `href:` block that references it).

### 5. Delete the source file

Delete the source markdown file from the repository.

## After processing all files

Present a summary:
- List of all source files merged
- Count of error codes added to the destination
- List of redirects created
- List of TOC entries removed

Do not proceed to searching or consolidation — those are separate prompt files.
