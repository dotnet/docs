---
name: dotnet-release-ga
description: 'Reviews .NET documentation for a new major release that has reached general availability. Use to remove stale release-stage labels while preserving valid preview references, and to review updateeachrelease articles.'
argument-hint: 'Provide the .NET release version and the release-update checklist items in scope'
---

# Update .NET Documentation for a GA Release

Use this skill for a yearly release-status pass when a new .NET release reaches general availability (GA). Remove stale preview or release-candidate status only where the text describes the release itself. Preserve accurate feature previews, historical examples, and general prerelease guidance.

## Required Inputs

Confirm these details before editing:

- The .NET release version and its GA status.
- The issue checklist items included in this task.
- Any reviewer feedback or explicit requests to preserve or revert changes.

Don't assume that a request for one checklist item authorizes work on every item in the larger release checklist.

## Workflow

### 1. Confirm release status and scope

1. Verify the release date and GA status with current, authoritative .NET release sources. Don't infer GA status from a preview or RC announcement.
2. Read the issue checklist and the full relevant PR feedback. Treat explicit requests to preserve or revert content as scope constraints.
3. Identify the exact release and release-stage terms to search for, including its preview, RC, and prerelease forms.

### 2. Inventory candidate content

Search the repository for the release's version numbers and status terms, including Markdown articles, front matter, tables, templates, code samples, and configuration files.

Also find every article tagged with `ms.custom: updateeachrelease`. Review each matching article for release-specific content that this task covers. Don't skip this pass because a page wasn't found by a search for the new version number. Don't update unrelated version guidance merely because the article has this tag.

Record candidate paths and classify each occurrence before editing. A text match alone doesn't establish that a reference is stale.

### 3. Classify each preview or RC reference

Apply these rules to every candidate:

| Reference type | Action |
| --- | --- |
| Release-status text that says the target .NET release is in preview or RC | Update it to reflect GA, or remove it if it no longer applies |
| Feature status that remains preview after the release | Keep the preview notice unless an authoritative source confirms that the feature shipped |
| General prerelease SDK instructions or guidance that applies to future releases | Preserve it unless the task explicitly asks to change it |
| Historical or illustrative version examples | Keep them when they explain a tool or workflow; use a specific version rather than replacing it with a placeholder |
| Preview references to another release | Leave them unchanged unless the task includes that release |
| Templates or shared guidance that reviewers asked to preserve | Revert or avoid edits to those files |

For example, a GA release can still include preview features. Don't remove a feature-level preview notice just because the containing .NET or language release is GA. Conversely, don't describe the entire release as preview solely because one feature remains in preview.

### 4. Make scoped edits

1. Change only references that are stale for the target release and included in the approved checklist scope.
2. Preserve surrounding article structure, sample specificity, and unrelated version guidance.
3. Don't generalize concrete examples into placeholders unless the article or user request calls for a template.
4. Don't remove general prerelease procedures, examples, issue-template options, or tooling documentation solely because a named release has reached GA.
5. If release status is uncertain, or an example could be historical or illustrative, leave it unchanged and ask for clarification rather than guessing.

### 5. Validate changes

1. Search again for the target release's preview, RC, and prerelease forms. Review each remaining match and confirm whether it is intentionally preserved.
2. Recheck all `ms.custom: updateeachrelease` articles in the task's scope.
3. Verify changed release claims against authoritative sources and confirm that feature-level preview claims remain accurate.
4. Run the narrowest existing lint, build, or validation command for the changed files.
5. Review the diff for unintended changes, especially to general prerelease guidance, specific sample values, and files that reviewers asked to preserve.

## Completion Report

Summarize:

- The release version and checklist scope.
- The files and kinds of release-status references updated.
- The feature-level, historical, and general prerelease references intentionally preserved.
- The `updateeachrelease` review performed and any in-scope changes made.
- Validation commands and results.
- Any uncertain release claims or out-of-scope follow-up work.
