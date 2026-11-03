# Update published C# specification to a new version

You're updating the published C# language specification from the current version to the next version. This is a multi-step process that involves configuration changes, TOC updates, link replacements, and cleanup.

## Input parameters

- **TARGET_VERSION**: The C# version to publish (e.g., "10", "11")
- **BRANCH_NAME**: The branch of `dotnet/csharpstandard` to use (e.g., "alpha-v10", "alpha-v11")
- **PROPOSAL_FOLDER**: The proposal folder being absorbed (e.g., "csharp-10.0")

Ask the user for these values before proceeding if not provided.

## Reference: PR #52889 pattern

This prompt follows the pattern established in PR #52889 (https://github.com/dotnet/docs/pull/52889), which published the C# 9 alpha branch. That PR made the following categories of changes across 50 files:

1. Switched the `_csharpstandard` branch from `draft-v8` to `alpha-v9`
2. Removed `csharp-9.0/*.md` from the docfx.json build configuration (files list, metadata entries, titleSuffix)
3. Updated `docs/csharp/specification/toc.yml` to reflect the new spec version name and added chapter numbers to TOC entries
4. Updated `docs/csharp/specification/overview.md` to describe the new draft version
5. Replaced all `~/_csharplang/proposals/csharp-9.0/` links with `~/_csharpstandard/standard/` links
6. Updated cross-docset links (using `/dotnet/csharp/language-reference/...` format)
7. Fixed existing `~/_csharpstandard/standard/` anchor references that changed between spec versions (section numbers shifted)
8. Updated `.openpublishing.redirection.csharp.json` redirect targets
9. Removed feature spec entries from `docs/csharp/specification/toc.yml`

## Step-by-step process

### Phase 0: Discover what's changing

1. **Fetch the new spec's table of contents** to understand section numbers and anchors:
   https://raw.githubusercontent.com/dotnet/csharpstandard/{BRANCH_NAME}/standard/README.md

2. **Fetch the current spec's table of contents** to identify anchor changes:
   https://raw.githubusercontent.com/dotnet/csharpstandard/{CURRENT_BRANCH}/standard/README.md
   Find the current branch in `.openpublishing.publish.config.json` under `_csharpstandard`.

3. **Find all links to proposals being removed**:
   grep -rn "proposals/{PROPOSAL_FOLDER}" docs/

4. **Find all existing spec links that might have shifted anchors**:
   grep -rn "_csharpstandard/standard/" docs/ --include="*.md"

5. **Identify the proposal files in the build** by checking `docfx.json` for:
   - The `files` list under `_csharplang/proposals`
   - The `ms.date`, `titleSuffix`, `title`, and `description` metadata entries for `_csharplang/proposals/{PROPOSAL_FOLDER}/*.md`

### Phase 1: Configuration changes

6. **Update `.openpublishing.publish.config.json`**: Change the `_csharpstandard` branch from the current value to `{BRANCH_NAME}`.

7. **Update `docfx.json`**: Remove all `{PROPOSAL_FOLDER}` entries:
   - Remove `"{PROPOSAL_FOLDER}/*.md"` from the `files` array under `_csharplang/proposals`
   - Remove the `"_csharplang/proposals/{PROPOSAL_FOLDER}/*.md"` entry from `ms.date` metadata
   - Remove the `"_csharplang/proposals/{PROPOSAL_FOLDER}/*.md"` entry from `titleSuffix` metadata
   - Remove all `"_csharplang/proposals/{PROPOSAL_FOLDER}/..."` entries from `title` metadata (the `fileMetadata.title` section)
   - Remove all `"_csharplang/proposals/{PROPOSAL_FOLDER}/..."` entries from `description` metadata (the `fileMetadata.description` section)
   - Remove any `exclude` entries specific to `{PROPOSAL_FOLDER}` files
   - Clean up any trailing formatting issues (trailing commas, etc.)

### Phase 2: TOC and overview updates

8. **Update `docs/csharp/specification/toc.yml`**:
   - Change the draft specification name (e.g., "C# 9 early draft specification" -> "C# 10 early draft specification")
   - Add chapter numbers to TOC entries if the new branch uses them and the current TOC doesn't have them yet
   - Remove all feature specification entries under the "Feature specifications" section that reference `{PROPOSAL_FOLDER}` proposals
   - If removing entries leaves an empty category (e.g., "Basic concepts" with no children), remove the category too

9. **Update `docs/csharp/specification/overview.md`**:
   - Update the description to reference the new version number
   - Update the `ms.date` frontmatter

### Phase 3: Replace proposal links with spec links

10. **Build the mapping table**: For each proposal file in `{PROPOSAL_FOLDER}`, identify the corresponding section in the new spec. The mapping requires:
    - Reading each proposal file name
    - Finding where that feature is now specified in the standard (by searching the new spec's README.md TOC)
    - Recording the exact `{file}.md#{anchor}` target

11. **Replace internal docset links** (`docs/csharp/` files):
    - Change `~/_csharplang/proposals/{PROPOSAL_FOLDER}/{file}.md` -> `~/_csharpstandard/standard/{spec-file}.md#{anchor}`
    - Change `~/_csharplang/proposals/{PROPOSAL_FOLDER}/{file}.md#{section}` -> `~/_csharpstandard/standard/{spec-file}.md#{anchor}`
    - Update surrounding prose: "feature proposal note" -> "C# language specification", "feature specification" -> "C# language specification", etc.

12. **Replace cross-docset links** (files outside `docs/csharp/`):
    - Change `/dotnet/csharp/language-reference/proposals/{PROPOSAL_FOLDER}/{file}` -> `/dotnet/csharp/language-reference/language-specification/{spec-file}#{anchor}`

### Phase 4: Fix shifted anchor references

13. **Compare old vs new spec TOCs** to identify sections where numbering shifted. Common causes:
    - New sections inserted (e.g., "with expressions" added as section 12.10 pushes everything after it)
    - Sections renumbered due to new content

14. **Update all existing `_csharpstandard/standard/` references** that point to anchors that shifted. This affects files that were already linking to the spec (not just the proposal replacements).

    Key files to check:
    - `docs/csharp/language-reference/operators/*.md`
    - `docs/csharp/language-reference/keywords/*.md`
    - `docs/csharp/language-reference/compiler-messages/*.md`
    - `docs/csharp/language-reference/builtin-types/*.md`
    - `docs/csharp/linq/index.md`

### Phase 5: Redirection file updates

15. **Update `.openpublishing.redirection.csharp.json`**:
    - Find any `redirect_url` values pointing to `/dotnet/csharp/language-reference/proposals/{PROPOSAL_FOLDER}/...`
    - Update those targets to point to the corresponding spec sections
    - Keep the `source_path_from_root` entries as-is (they define the old URLs being redirected FROM)

### Phase 6: Verification

16. **Verify no remaining proposal links**:
    grep -rn "proposals/{PROPOSAL_FOLDER}" docs/
    Expected: zero matches.

17. **Verify no remaining redirect targets to removed proposals**:
    grep -n "proposals/{PROPOSAL_FOLDER}" .openpublishing.redirection.csharp.json | grep "redirect_url"
    Expected: zero matches.

18. **Check for build warnings** after the OpenPublishing.Build check completes. Common issues:
    - Bookmark warnings (anchor doesn't exist in target file)
    - Broken cross-references

## Important notes

- **External GitHub links** (e.g., `https://github.com/dotnet/csharplang/blob/main/proposals/...`) that point to proposals being removed should be evaluated case by case. If the feature has no clear spec section (like `skip-localsinit`), leave the GitHub link.
- **Proposal files for other versions** (e.g., `csharp-11.0`, `csharp-12.0`) must NOT be touched — only `{PROPOSAL_FOLDER}` links are being replaced.
- **The `_csharplang/proposals` folder** continues to exist for newer versions. Only the target version's folder is removed from the build.
- **Link format rules**:
  - Inside `docs/csharp/`: use `~/_csharpstandard/standard/{file}.md#{anchor}`
  - Outside `docs/csharp/` (cross-docset): use `/dotnet/csharp/language-reference/language-specification/{file}#{anchor}`
- **Anchor format**: Anchors in the csharpstandard repo use the pattern `#{section-number}-{title-slugified}` (e.g., `#1516-synthesized-record-class-members`). Verify each anchor exists in the new branch's README.md TOC.
