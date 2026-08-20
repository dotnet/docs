---
name: error-consolidation-search
description: Finds C# diagnostics related to a consolidation theme. Use after setup to review documented and catch-all candidates through explicit approval gates.
---

# Search for Related Error Codes

Search for theme-related diagnostics that may have been missed during initial consolidation. Preserve all three phase boundaries and approval gates.

## Required Inputs

Collect these inputs from the user:

- **Destination filename**: The consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`.
- **Theme description**: The theme to search for.

## Key Paths

- Destination: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- TOC: `docs/csharp/language-reference/toc.yml`
- Catch-all: `docs/csharp/misc/sorry-we-don-t-have-specifics-on-this-csharp-error.md`
- Roslyn error codes: `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs`
- Roslyn resources: `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx`

## Phase A: Search Existing Documentation

1. Read the destination and collect all included error codes.
2. Search all files whose names begin with `cs` in:
   - `docs/csharp/language-reference/compiler-messages/`
   - `docs/csharp/misc/`
3. Read every candidate and decide whether its diagnostic relates to the theme.
4. Build a candidate list containing the file, error code, and a brief reason it matches.

Present the list and stop:

```markdown
| File | Error Code | Reason |
|------|------------|--------|
| cs0220.md | CS0220 | Describes compile-time overflow |
```

Tell the user:

> Review this list. Approve the files you want merged, then run the `error-consolidation-merge-existing` skill with the approved list.

Wait for the user before proceeding to Phase B. Do not merge candidates in this skill.

## Phase B: Search Undocumented Catch-All Errors

After the Phase A gate is satisfied:

1. Read `f1_keywords` from the catch-all file's front matter.
2. For each listed code:
   1. Extract the numeric portion, such as `CS0463` to `463`.
   2. Find the `ERR_` or `WRN_` constant assigned that number in `ErrorCode.cs`.
   3. Find the `<data>` element in `CSharpResources.resx` whose `name` exactly matches the constant.
   4. Read the verbatim message from its `<value>` child.
3. Keep only messages related to the theme.
4. Exclude codes already present in the destination.

Present the filtered list and stop:

```markdown
| Error Code | Error Message |
|------------|---------------|
| CS0463 | Evaluation of the decimal constant expression failed |
| CS1021 | Integral constant is too large |
```

Tell the user:

> Review this list. Tell me which error codes to add.

Wait for explicit approval before proceeding to Phase C.

## Phase C: Add Approved Error Codes

Process all approved codes as one batch.

For each code:

1. Add it to destination `f1_keywords` and `helpviewer_keywords` in numeric order.
2. Add it to the destination master error list in numeric order:

   ```markdown
   - [**CS{NNNN}**](#anchor-tbd): *{verbatim error message from CSharpResources.resx}*
   ```

   Use `#anchor-tbd` until the consolidation phase assigns thematic anchors. Replace Roslyn format placeholders such as `'{0}'` and `'{1}'` with descriptive terms while preserving the static message text and producing a coherent sentence. Prefer context-appropriate generic terms such as `'type'`, `'value'`, `'operator'`, `'member'`, or `'method'`. For example, `Constant value '{0}' cannot be converted to a '{1}'` becomes `Constant value 'value' cannot be converted to a 'type'`. Use the following XML `<comment>` element, when present, to identify placeholder meanings.
3. Add it to the destination TOC entry's `displayName` in numeric order.
4. Remove it from `f1_keywords` in the catch-all file.

Do not create redirects for these codes because they had no standalone articles.

Present a summary of all changes made.
