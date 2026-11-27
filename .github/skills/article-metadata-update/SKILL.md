---
name: article-metadata-update
description: Finds articles that meet user-defined criteria, presents evidence for approval, and applies narrowly scoped frontmatter updates. Use for bulk article metadata changes with a discover-then-approve workflow.
argument-hint: 'Provide the article criteria, exclusions, search scope, metadata key, and desired string value; or identify a previously approved manifest and groups or paths'
---

# Update article metadata

Use this skill to select articles by their actual scope and update one frontmatter key. Keep eligibility decisions separate from the script that applies the edits.

## Required inputs

Confirm the following details before discovery:

- The selection criteria and exclusions.
- The repository-relative search directories.
- The metadata key and desired string value.

Reuse details that the user already supplied. Don't assume that a version number, release cutoff, metadata key, or value from a previous task applies to a new task.

## Discover mode

Discovery doesn't authorize article edits.

1. Read the applicable repository instructions and inspect existing workspace changes. Keep the user's branch, commits, and unrelated edits intact.
1. Use fast, scoped searches to collect candidates from paths, titles, frontmatter, and relevant article text. Read enough context to establish each candidate's scope. Don't repeatedly scan every line of every article.
1. Classify each entry as `candidate`, `review`, or `excluded`. Record a reason and evidence with a repository-relative path, line number, and short quotation.
1. Verify time-sensitive eligibility facts against current authoritative sources when the criteria depend on support status or release dates.
1. Create a JSON manifest in the session artifacts directory, outside the repository. Use the schema below. Give groups stable, descriptive IDs.
1. Run the script in `Preview` mode. The script records current values, content hashes, expected result hashes, and completion status. It also writes a CSV beside the manifest.
1. Present the grouped list, reasons, uncertainties, exclusions, and already-correct counts. Attach the report when the list is too large for chat. **Stop and wait for explicit approval.**

### Eligibility rules

Apply the user's filter, not a hard-coded documentation retirement policy.

- A text match or old SDK example doesn't establish that an article is obsolete.
- A feature introduced in an earlier release can remain relevant to current releases.
- Historical release summaries and breaking-change records can qualify as stable, release-specific content even when their features or migration advice remain useful.
- A diagnostic or feature that the tools no longer produce differs from an API that merely became obsolete.
- Don't equate versions of .NET, .NET Framework, language compilers, or independent tools.
- Treat mixed-version articles and uncertain scope as `review` unless the user's criteria resolve the uncertainty.
- Exclude shared includes and general reference pages unless the user explicitly includes them.

### Manifest schema

The initial manifest contains selection decisions, not approval flags:

```json
{
  "schemaVersion": 1,
  "metadata": {
    "key": "ms.update-cycle",
    "value": "3650-days"
  },
  "articles": [
    {
      "path": "docs\\core\\compatibility\\9.0.md",
      "group": "breaking-change-indexes",
      "classification": "candidate",
      "reason": "The introduction scopes the list to migration to .NET 9.",
      "evidence": "docs\\core\\compatibility\\9.0.md:10: If you're migrating an app to .NET 9..."
    }
  ]
}
```

The example illustrates the format, not a default filter or permission to edit that file. Include `review` and `excluded` entries in the manifest so the report explains the selection boundaries.

Run commands from the repository root, or pass `-RepositoryRoot` explicitly:

```powershell
.\.github\skills\article-metadata-update\scripts\update-frontmatter.ps1 `
    -Mode Preview `
    -ManifestPath "<session-artifacts>\article-metadata-manifest.json"
```

Don't manually edit the snapshot hashes, preview metadata, or completion status. After the target key, value, or article contents change, run a new preview and obtain approval for the revised proposal.

## Apply mode

The user can approve the full candidate list, specific groups, or individual paths. Translate that approval into explicit arguments; never infer approval from the manifest's existence.

1. Identify exactly which groups or paths the user approved. A group selects only `candidate` entries. A `review` entry requires explicit path approval; the script never selects an `excluded` entry.
1. Run `Apply` against the previewed manifest. Don't rediscover a broader set of files or use wildcard approvals.
1. If the script reports stale content, stop. Reinspect the affected articles, create a fresh preview, and obtain approval for any materially changed proposal. Don't replace hashes to bypass the check.
1. Verify the diff against the approved scope. Confirm that only the target frontmatter field changed and that article text, other metadata, encoding, and line endings remain intact.
1. Report changed, already-correct, and remaining counts. Leave edits local and uncommitted unless the user requests a Git operation.

```powershell
.\.github\skills\article-metadata-update\scripts\update-frontmatter.ps1 `
    -Mode Apply `
    -ManifestPath "<session-artifacts>\article-metadata-manifest.json" `
    -ApprovedGroups "breaking-change-indexes"
```

```powershell
.\.github\skills\article-metadata-update\scripts\update-frontmatter.ps1 `
    -Mode Apply `
    -ManifestPath "<session-artifacts>\article-metadata-manifest.json" `
    -ApprovedPaths "docs\core\compatibility\9.0.md"
```

## Script contract

Location: `.\scripts\update-frontmatter.ps1`. Requires PowerShell 7.2 or later; no additional packages.

| Parameter | Purpose |
| --- | --- |
| `Mode` | `Preview` records the proposal without article edits. `Apply` edits explicitly selected entries. |
| `ManifestPath` | Identifies the JSON manifest. The derived CSV uses the same basename. Keep both outside the repository. |
| `RepositoryRoot` | Selects the article repository root. Defaults to the current directory. Apply must use the root recorded by preview. |
| `ApprovedGroups` | Selects named groups of `candidate` entries in Apply mode. |
| `ApprovedPaths` | Selects individual `candidate` or `review` entries in Apply mode. |

The script supports unquoted top-level keys and single-line printable string values, including plain strings, YAML single-quoted strings, and JSON-compatible double-quoted strings. It quotes new values when plain YAML could change their meaning. It rejects multiline or structured target values, duplicate top-level keys, merge keys, quoted frontmatter keys, unsupported encodings, and linked paths rather than guess.

UTF-8 files retain their BOM, if present, and existing line endings. Existing inline comments on the target field remain intact. New fields appear after `ms.date`, or immediately before the closing frontmatter delimiter when `ms.date` is absent. The script doesn't update `ms.date`, `ai-usage`, or any other field unless that field is the explicitly requested target.

All selected files pass stale-content checks before any article write. The script also checks each file immediately before its write and verifies the resulting bytes. If a later operation fails, earlier edits can remain; inspect the surfaced error and manifest rather than assume an atomic batch. Repeating an approved apply verifies and skips completed results.

For CRLF files, use a command-scoped whitespace check that recognizes carriage returns without changing Git configuration:

```powershell
git -c core.whitespace=blank-at-eol,blank-at-eof,space-before-tab,cr-at-eol diff --check
```

## Regression checks

Run the standalone fixture checks after you change the script:

```powershell
.\.github\skills\article-metadata-update\scripts\update-frontmatter.Tests.ps1
```

The checks use temporary articles and manifests, require no test framework, and remove their fixtures when they finish. They cover approval boundaries, stale-file preflight, already-correct values, ambiguous frontmatter, safe YAML string values, comments, encoding, and line endings.
