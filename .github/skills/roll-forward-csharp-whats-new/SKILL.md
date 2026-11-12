---
name: roll-forward-csharp-whats-new
description: 'Rolls the three-release C# What''s new window forward. Use after a confirmed annual C# GA release to preserve release history, move the older What''s new article into history, repair links and redirects, and remove stale introductory version framing without erasing compatibility requirements. Older C# language features remain supported; only their new framing changes.'
---

# Roll forward C# What's new

Owner: C# guide maintainers.

Use this workflow after a confirmed major C# GA release, not for preview graduation or new-release feature documentation. Reuse the contributor's prepared repository and branch. Preserve existing work; don't switch branches, reset work, stage, commit, or push without explicit instruction.

Older C# language features remain supported. They are ordinary C#; only their "new" framing changes when their release leaves the three-release What's new window.

## Confirm scope

- Obtain the repository, work branch, and confirmed new GA major version **N** from the contributor. Don't infer GA status or release dates from the calendar.
- Derive the major version leaving the What's new window **R = N - 3**. Retain introductory version framing for **N - 2**, **N - 1**, and **N**, plus current previews. Previews don't count toward the three GA releases.
- For example, a supplied N of 15 moves 12 out of the What's new window and retains 13/14/15; the next N of 16 moves 13 out and retains 14/15/16. These are arithmetic examples, not release-status claims.
- Limit edits to moving R's What's new article into history, useful history, inbound callers, and stale introductory framing. Don't change unrelated versions, policy, minimum language versions, samples, or SDK/framework requirements without separate evidence and scope.
- Record initial tracked and untracked changes so the final handoff distinguishes existing work from this workflow.

## Locate the content and companions

Resolve these links relative to this skill; use repository-relative paths for searches and edits:

- [C# version history](../../../docs/csharp/whats-new/csharp-version-history.md).
- [Owning C# TOC](../../../docs/csharp/toc.yml).
- [C# landing page](../../../docs/csharp/index.yml), [tour landing page](../../../docs/csharp/tour-of-csharp/index.yml), and [reference landing page](../../../docs/csharp/language-reference/index.yml).
- [Language version requirements](../../../docs/csharp/language-reference/language-versioning.md).
- [C# redirects](../../../.openpublishing.redirection.csharp.json).
- [Redirect article](../redirect-article/SKILL.md) owns article deletion and redirect creation through its existing script.
- [Sort redirects](../sort-redirects/SKILL.md) owns redirect ordering through its existing script.

This skill owns annual release selection, history preservation, semantic review, and acceptance checks. Reuse the companions for redirect mechanics; don't duplicate their scripts.

## Inventory before deletion

1. Locate R's What's new article under `docs/csharp/whats-new/` and inspect its history or relevant earlier window roll-forward changes if needed. Don't assume every release uses identical filenames or headings.
1. Inventory all feature headings, generated fragments, explicit anchors, reference/proposal/tutorial links, summaries, release/SDK context, and preview or experimental caveats.
1. Create a source-to-destination map for the article and each feature fragment. Prefer the corresponding history section for release context and a specific reference or tutorial section for feature details. Verify each destination exists.
1. Search the entire repository, not just the C# guide, for callers of the article basename, old path, published URL, and feature fragments. Include Markdown, reference-style links, HTML, YAML/landing pages, includes, and callers outside `docs/csharp/`.
1. Search the C# guide broadly for R's numeric and spelled-out versions, including `C#`, escaped `C\#`, `C Sharp`, and HTML-encoded forms. Inspect feature headings, notes, tables, links, and introductory prose, not only exact "new in" matches.
1. Include "new in", "introduced", "added", "available", "starting with", "beginning with", "as of", and "C# R or later" phrasing. Normalize Markdown emphasis, escapes, HTML/entities, and whitespace in a read-only search view so line breaks and markup don't hide matches. Search for all C# mentions as a backstop, then classify those that refer to R. Don't rewrite source files through normalization.

## Move the older What's new article into history

1. Expand R's existing history section with concise, useful feature summaries and relevant reference, proposal, specification, and tutorial links. Preserve supported release and SDK context; don't invent dates or copy the whole old article.
1. Transfer meaningful preview and experimental explanations with their opt-in requirements, limitations, and warnings. Interceptors don't become GA because their original release article moves into history. Preserve historical preview caveats and link to current feature documentation for later status.
1. Adjust relative links for the history article's location. Keep stable proposal URLs intact, including version numbers in proposal paths.
1. Apply repository metadata guidance to intentional content changes. Don't transplant the deleted article's identity, author, dates, or other frontmatter into history, and don't accidentally transfer metadata through redirect options.
1. Follow the redirect-article companion to delete only the selected article and add its redirect. Use the full extensionless `/dotnet/csharp/whats-new/csharp-version-history` destination plus R's verified history fragment. Inspect generated entries for unintended metadata-transfer behavior.
1. Remove the TOC entry for the deleted What's new article and update affected landing pages. Repair every caller from the inventory, including outside-guide callers.
1. Map feature-fragment callers individually to verified history or reference destinations. An article-level redirect doesn't guarantee that an old feature fragment survives; don't append the deleted article's feature fragments to the new history URL blindly.
1. Follow the sort-redirects companion and inspect the resulting redirect diff. Don't blanket delete snippets or sample trees; check all consumers before any separately justified cleanup.

## Review version mentions semantically

Remove introductory framing such as "new in R" when it merely advertises a now-established feature. Rewrite the sentence naturally and preserve the explanation; don't apply blind replacements or delete whole feature sections.

Retain and explain these categories in the handoff:

- **Historical chronology:** Release history, original compiler behavior, and accurate feature timelines.
- **Actual requirements:** `LangVersion`, SDK, framework, library, configuration, and opt-in constraints, including project examples.
- **Diagnostics and compiler history:** Literal compiler messages, warning waves, and compiler-version history.
- **Compatibility boundaries:** Concrete before/after behavior, migration guidance, and overload/binding differences. Examples include pre-C# 12 `params` behavior and CS9194; their version boundaries carry meaning beyond novelty.
- **Stable destinations:** Versioned proposal URLs and links whose version component identifies the source.
- **Preview caveats:** Experimental status and historical restrictions that moving an article into history alone can't resolve.

For "R or later" and similar wording, decide whether the version expresses a real prerequisite or merely stale introduction. Keep real constraints. If evidence doesn't settle the distinction, retain the text and report the uncertainty rather than silently broaden support.

## Validate acceptance

Use available repository tooling; install tools only after a missing-tool failure warrants it. Validate the actual changed files, not only search results.

- Confirm the selected article is gone and the source-to-destination inventory accounts for its useful material, feature anchors, release context, and caveats.
- Parse the touched redirect JSON. Verify normalized source paths are unique, entries follow the companion's sort order, and the new destination resolves directly without a new redirect chain.
- Parse each touched owning YAML file and confirm the TOC has no entry for the deleted What's new article. Inspect affected landing pages for stale version labels and URLs.
- Repeat the entire-repository caller sweep for the deleted path, basename, published URL, and feature fragments. Classify legitimate redirect-source entries and historical records; repair unresolved live callers.
- Perform real local path **and fragment** checks for every changed link and mapped destination. Inspect generated heading IDs and explicit anchors, including punctuation and duplicate-heading suffixes. A file-existence test alone isn't enough.
- Repeat the broad normalized all-C#-mentions sweep across the guide. Classify every remaining R mention using the retained categories above, and report any unresolved candidates.
- Run Markdown lint and whitespace checks on all touched files. Explicitly include untracked files, including a new skill if present; ordinary tracked diffs and repository ignore rules can omit them.
- Review the complete diff against the initial state for accidental metadata movement, sample deletion, unrelated version edits, and changes to existing contributor work.
- Run an available local docs/link build if practical. State exactly what ran and its result; don't claim publishing validation, external HTTP checks, or build success without those checks.

## Hand off

Report changed files, the release leaving the What's new window and retained GA window, preserved history/link mappings, and retained-reference rationales. Give exact validation results and limitations, including checks not run and unresolved semantic questions. Confirm branch and uncommitted status, and leave all changes for contributor review unless explicitly instructed otherwise.
