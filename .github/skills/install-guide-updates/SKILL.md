---
name: install-guide-updates
description: 'Updates .NET Linux installation-guide content for supported distribution versions and native dependencies. Use when refreshing Linux install articles, support tables, prerequisites, package lists, or end-of-life notes for .NET 8, .NET 9, and .NET 10.'
argument-hint: 'Provide an installation article or Linux distribution to update'
version: 1.0
---

# Update the .NET Linux Installation Guide

Update an existing Linux installation article so that its supported operating system versions and native dependency lists agree with the pinned .NET release metadata.

## Scope

- Document .NET 8, .NET 9, and .NET 10.
- Don't document .NET 11 or another preview release in the installation guide.
- Preserve the article's existing structure, Markdown style, and distribution-specific package-manager syntax.
- Limit edits to support information, end-of-life notes, prerequisites, and directly related text unless another change is required for consistency.

## Authoritative Sources

Use the GitHub MCP server to read the files from the `dotnet/core` repository using the matching tag. Don't infer metadata from the rendered GitHub pages when the source files are available.

| .NET version | Tag | Supported operating systems | Native dependencies |
| --- | --- | --- | --- |
| .NET 10 | `v10.0.11` | `release-notes/10.0/supported-os.json` | `release-notes/10.0/os-packages.json` |
| .NET 9 | `v9.0.19` | `release-notes/9.0/supported-os.json` | `release-notes/9.0/os-packages.json` |
| .NET 8 | `v8.0.30` | `release-notes/8.0/supported-os.json` | Use the .NET 9 package data as described in step 4 |

Source URLs:

- `https://github.com/dotnet/core/blob/v10.0.11/release-notes/10.0/supported-os.json`
- `https://github.com/dotnet/core/blob/v9.0.19/release-notes/9.0/supported-os.json`
- `https://github.com/dotnet/core/blob/v8.0.30/release-notes/8.0/supported-os.json`
- `https://github.com/dotnet/core/blob/v10.0.11/release-notes/10.0/os-packages.json`
- `https://github.com/dotnet/core/blob/v9.0.19/release-notes/9.0/os-packages.json`

## Workflow

### 1. Identify the target

1. Determine the installation article and Linux distribution from the user's request. If the user provides only one of them, search the installation-guide content for the matching article.
2. Read the entire target article before you edit it.
3. Identify every support table, version-specific prerequisite list, shared dependency list, and related end-of-life note in the article.
4. Note how the article separates package names by distribution version and .NET version. Keep that organization unless it prevents the article from expressing accurate requirements.

### 2. Retrieve release metadata

1. Read all three `supported-os.json` files from the authoritative sources.
2. Read the .NET 9 and .NET 10 `os-packages.json` files.
3. Select entries that match the target distribution. Check distribution names, IDs, version labels, architectures, and qualifiers instead of relying on a partial name match.
4. Record the source entries that control each planned documentation change. If no entry matches, stop and report the missing source data instead of guessing.

### 3. Update operating system support

1. Cross-reference the target distribution in each `supported-os.json` file.
2. Make each support table accurate and complete for .NET 8, .NET 9, and .NET 10:
   - Add newly supported distribution versions.
   - Remove distribution versions that aren't supported for that .NET release.
   - Preserve architecture or support qualifiers from the source when the article represents them.
3. Update related end-of-life or end-of-support notes only when an authoritative source confirms the date. Don't invent or estimate dates.
4. Remove preview-version rows and notes, including .NET 11.

### 4. Update native dependencies

1. For .NET 9 and .NET 10, use the exact dependencies listed for the target distribution in the corresponding `os-packages.json` file.
2. For .NET 8, start with the closest matching .NET 9 dependency entry (use .NET 9 URL and tag) because no .NET 8 `os-packages.json` file exists:
   - Add the distribution's zlib package. zlib is required for .NET 8, but not for .NET 9 or .NET 10.
   - Preserve existing .NET 8 package-name differences when they are necessary for the applicable distribution version.
   - Preserve other existing .NET 8 dependencies unless the release metadata or the article's supported package set shows that they are no longer required.
3. If one command installs dependencies for multiple .NET versions, use version pivots or separate commands when necessary to keep the .NET 9 and .NET 10 lists exact and the .NET 8 zlib requirement clear.
4. Remove `libgdiplus` from dependency lists and remove notes that tell users to install or configure it.
5. Don't add a dependency merely because another distribution requires it.

### 5. Reconcile the article

1. Check prose, examples, tabs, includes, and notes for claims that conflict with the updated tables and dependency lists.
2. Keep commands valid for the distribution version and package manager that each section covers.
3. Retain existing dependencies that apply outside the version-specific .NET runtime lists only when the article explains their separate purpose.
4. Apply the repository's Markdown writing instructions and AI-usage frontmatter requirements to every article you change.

### 6. Validate the update

1. Compare every documented support row with the matching `supported-os.json` entry.
2. Compare every .NET 9 and .NET 10 dependency list with the matching `os-packages.json` entry. The package sets must match exactly.
3. Verify that every .NET 8 dependency path includes the correct zlib package.
4. Search the changed article for `libgdiplus`, `.NET 11`, and preview installation-guide content; remove any instances that violate this workflow.
5. Check that Markdown tables, links, includes, selectors, and code blocks remain syntactically valid. Run the narrowest available repository validation for the changed files.
6. Review the final diff for unrelated changes.

## Completion Report

Summarize:

- The distribution and article that you updated.
- Support versions added or removed for each .NET release.
- Dependency changes for each .NET release.
- The release metadata files used.
- Validation commands and their results.
- Any ambiguity or missing source data that requires maintainer review.