# Draft Plan: Fundamentals Restructuring PR Breakdown

**TL;DR:** Break the ~91-article restructuring into ~35 small, independently mergeable PRs organized in proposed TOC order. Each PR aims for ~10 files (articles, snippets, toc.yml, redirects), adds its content to the live TOC immediately, and leaves the section in a publishable state. PR file budgets are advisory: a PR may exceed ~10 files when relocating text to other sections is the right call (Goal 11), and PRs that grow too large are split along a natural seam into separate, consecutively numbered PRs (for example, the collections/LINQ and equality work split into PR 14a / PR 14b). Every new or revised article follows the example-heavy, latest-version-saturation style from Goals 4 and 8.

**Conventions for every PR:**

The Fundamentals audience is a developer who knows another language and is learning C#. An alternative audience is a new developer that has only months of experience with C# as their first programming language. They don't yet have C# vocabulary, can't recognize C#-specific idioms on sight, and don't share the project context an experienced C# developer takes for granted. The conventions below are grouped by the audience-derived principle they serve so each one's *why* stays visible.

*Sample readability (P1) — write samples that a new C# developer can read line-by-line:*

- All code examples are included from external snippet files (no inline code blocks), and every article has a corresponding snippet project.
- All snippet code uses the full "Everyday C#" feature set per the feature tables.
- Prefer file-based apps over larger project-based samples for simplicity and ease of understanding, unless a feature requires a more complex setup.
- For any construct the sample isn't teaching, pick the most familiar form: use `while` or `foreach` before `for` (reserve `for` for explicit index iteration); use a regular method before a static factory unless the article is about factories.
- Add a brief intent comment on any line whose purpose or syntax isn't immediately obvious — for example, lines like `_ = something;`, a literal argument with hidden significance, a spread element in a collection expression, or the line where deferred LINQ execution actually occurs.
- When a sample illustrates a decision, show *both* branches and include the result as a trailing comment (`// => …`) so readers correlate code to output without running it. When two syntaxes are meant to be equivalent, make the console output identical across both samples so readers can see the equivalence.
- Lead with the newer, recommended form first, then show the equivalent baseline form when it aids understanding. When you contrast correct and incorrect code, show the correct version first, explain why it works, then show the incorrect version with the diagnostic it produces.
- Show each common form of a construct, not just one — for example, a single null-conditional access (`a?.b`) and a chain (`a?.b?.c`) — so readers recognize the pattern when they meet variations.
- Don't use a contextual keyword (`value`, `record`, `field`, `scoped`) as a sample identifier; it reads as the keyword and obscures the lesson.
- In tutorials, when a code block belongs in a new file, tell the reader to create the file and give it a name. Don't drop code that has nowhere to live.
- Never place consecutive code snippets. They are hard to read and harder for readers to follow. Either intersperse explanatory text between snippets or combine related snippets into a single example.

*Terminology (P2) — treat every C# term as new until the article defines it:*

- Define concepts when they are first introduced. Don't assume readers know what a "type" or "namespace" is before those concepts are covered in the proposed TOC. Remember that this is "fundamentals" content. Any term likely to be unfamiliar to a new C# developer should be defined inline at first use — one short sentence — with a link to the deeper reference. This applies to terms the author considers obvious (for example, *dereference*, *type parameter* vs. *type argument*, *primary constructor*), not just terms the author considers new.
- *Use the official term for every concept, and define it.* Match the term used in the language spec, the API reference, or the Microsoft style guide; never coin a synonym for an established term (for example, don't call an annotation a "hint," and don't say null state "moves" when it *changes* on a line). If a familiar term from another language helps orient readers, name it once as a bridge to the C# term (for example, "a map — called a dictionary in C#"), then use the C# term consistently. Introduce the term, define it in one sentence at first use, then state the rule that uses it.
- When a symbol's meaning depends on context (`T?` differs between value types, constrained reference types, and unconstrained generics), spell out which form you mean before listing rules. Lead a constraints discussion with a one-line model of what is being constrained.
- Definitions are less important for concepts that aren't related to the C# language. The goal for Fundamentals is to teach readers how C# works. While we teach through examples, the libraries and packages used in the examples are less important than the language features being demonstrated. For example, when teaching about collections, it's more important to explain what a collection is and how to use them in C# than to provide an in-depth explanation of `List<T>` vs. `Dictionary<K,V>`.
- Cross reference liberally. It's assumed readers are familiar with content in the "Get started" section, so links there should be minimal and scoped to recommendations for beginners to start there instead. Links and cross references should encourage readers to learn more and dive deeper into the fundamental concepts covered in this section.
- Link every API type, member, or namespace named in prose with an `<xref:...>` cross-reference, not plain text or a hand-built URL.
- If and only if a feature was first added in one of the last three released versions (C# 12–14), mention when it was first introduced.

*Reader's project frame (P3) — default to a current project, and teach how to verify settings:*

- Lead with the current-project assumption. "New projects from recent templates set `<Nullable>enable</Nullable>` in the project file" is the default framing for any setup or configuration statement — no opening hedge.
- Immediately follow such statements with a one- or two-sentence pointer that shows existing-project readers where to verify the setting in their own `.csproj` and how to enable it if it's missing.
- Reserve full migration guidance for the migration articles. When the existing-project path is more than a setting check (for example, planning a phased rollout), link out rather than inlining the strategy.
- When a feature is recommended as the fix for a diagnostic, run the code and confirm the diagnostic actually clears in the scenario being recommended. Reviewer skepticism ("does that actually work here?") usually means the verification wasn't done.
- When recommending a modern feature over an older alternative, always include a justification — state *why* the recommended approach is preferred and better than what. If the justification would require an out-of-scope detour, demonstrate the recommended form in code and cut the claim. Never describe older features as obsolete or deprecated (Goal 9).

*Scope discipline (P4) — every section must earn its place in Fundamentals:*

- Apply the two-criteria fit test (Goal 11) to every section, not just every article. *Filter A — universality:* used by almost all C# developers almost all of the time. *Filter B — accessibility:* readable by a developer with less than one month of .NET and C# experience given the Fundamentals coverage that precedes the article.
- When a section fails Filter A, *cut the text from the Fundamentals draft and paste it into the most appropriate existing destination article* (Language Reference, a Deep dives section, or an Advanced section), with light editing for fit. Don't delete the content — pulled articles often carry valuable detail that simply belongs elsewhere. The canonical example is the nullable-reference-type migration article in PR 9: it targets large pre-C# 8 codebases and fails universality, so its migration-strategy text stays in the existing migration article and the Fundamentals NRT article links out instead of inlining.
- When an *entire* article fails Filter A, don't pull it into Fundamentals at all. Document the decision as an explicit "leave in place" line item in the affected PR, with a one-line reason. Revisit when that area of the docs is restructured.
- When content fails Filter B but passes Filter A, *rewrite — don't exclude.* Define vocabulary at first use, simplify the example, and lead with motivation. Accessibility failures are an editing problem, not a scoping problem.
- Identify destinations at planning time, not at review time. If a PR's draft includes redistributed sections, name the destination files in the PR description before writing so reviewers see the full picture and the destinations don't drift.
- Accept that redistribution may push a PR's file count above the ~10-file target. Exceeding the budget is acceptable when the alternative is losing content or merging an off-topic Fundamentals article. If the PR grows too large, split it along a natural seam (see the *Mechanics* group below).

*Structural hygiene that supports the principles above:*

- *Open with what the article covers and its key takeaway.* Don't open with what the article *doesn't* cover or with "X and Y are different," and don't link back to the section overview from the introduction. When the default behavior is usually what readers want, say so, and frame the advanced features as options for when the default doesn't fit.
- Each article follows concept → example → concept → example structure. The concept discussion should include motivating scenarios for the feature or concept being covered. When framing a newer feature, state what the syntax is for, show the newer or less familiar variant first, then show the equivalent baseline case — don't skip the baseline form readers need to understand it.
- One topic per paragraph. A new case (for example, "the same pitfall also applies to arrays of structs") starts a new paragraph.
- Promote a bold paragraph-lead to `###` when it anchors more than one paragraph of content. Inline bold disappears in the TOC and is harder to scan.
- Replace long "the rule is simple" prose with a short structured rule — a one-sentence lead, bold trigger words, then a two- or three-bullet list or a labeled example. For enumerations of operators, options, or common forms, use a short intro sentence plus a bullet list, and include any item that also has its own subsection so the list is complete.
- Prefer articles that are between a 5- and 10-minute read (roughly 1000–2000 words). Longer and shorter articles are allowed, but should be the exception. Put the concepts readers must not miss near the top; don't save key mental models, syntax alternatives, providers, or execution semantics for the final section.

*Mechanics — TOC, metadata, links, redirects:*

- Update `toc.yml` incrementally so new content is navigable immediately.
- Add redirect entries for every moved file (use the "/.openpublishing/redirection.csharp.json" file).
- *Make every move build-clean.* A redirect alone doesn't silence "Invalid link" warnings: when you move or rename a file, also fix every inbound relative link repo-wide (sibling articles, the section `index.md`, `toc.yml`, and cross-section files such as `docs/standard/...`) and the moved file's own outbound links, all in the same PR.
- *Match the snippet mechanism to the code's build behavior.* Code that should compile lives in a snippet project referenced with `:::code` (CI compiles it). Code that intentionally *doesn't compile* stays inline in a fenced ```` ```csharp ```` block, never in a snippet project. Code that intentionally *warns* (for example, a nullable diagnostic) lives in a snippet project configured not to fail on that warning and must actually emit it — don't comment it out or "fix" it. Before deleting or moving a snippet file, grep every `source=` reference to it and update them in the same commit.
- Every article must include a tip near the top that identifies where the article sits in the four-tier content structure (*Get started* → *Fundamentals* → *Deep dives* → *Reference*), describes who it's written for, and routes readers to the right tier based on their experience level (Goal 1). Put Big-O and other complexity details in a `> [!TIP]` note, not inline prose, and verify the statement precisely against the API/reference before review.
- Set the `ms.topic` metadata value in each article's YAML front matter to match the article's content type (`overview`, `tutorial`, `concept`, `how-to`, `troubleshooting`, or `reference`).
- After writing content, verify the article's structure, required metadata, and sections against the template for its content type (see the [Include major topic types](../project-map.md#include-major-topic-types) table for template links). This is mandatory for every article before it can be merged to ensure consistency and completeness across the Fundamentals section.
- Do not add F1 or helpviewer keywords to Fundamentals articles. When pulling content from the Reference section, remove any F1 or helpviewer keywords.
- Do not add links to files that will be created in future PRs until those files are live. For example, if PR 3 creates the `fundamentals/types/enums.md` article, then earlier PRs should not link to that file until PR 3 is merged. This may require some temporary duplication of content or placeholders for links, but it will prevent broken links in merged PRs. Instead, when an article is created, add appropriate links to it in earlier articles as needed to connect the content together.
- *Branch from `main`.* When a prerequisite PR is still in review, assume it merges — don't rebase your branch onto the prerequisite's branch, and don't link to files that aren't live yet.
- Every PR description lists redistributed content explicitly. For each section moved out of the Fundamentals draft, name the source (which planned Fundamentals article it was cut from), the destination (file path), and a one-line reason — formatted as `source draft article → destination file path → reason`. This keeps the trail visible for downstream review and for future restructuring of the destination area.
- Follow the *Fundamentals folder layout convention*: each section's `index.md` and concept articles live at the section's top level (for example, `fundamentals/strings/interpolation.md`); task-style articles ("how do I do X?") are grouped under a `<section>/common-tasks/` subfolder (for example, `fundamentals/strings/common-tasks/search.md`) with their snippets under `<section>/common-tasks/snippets/`; tutorials live flat under `fundamentals/tutorials/` rather than nested per section. The section's `toc.yml` renders a nested **Common tasks** group beneath the concept articles. Sections without task-style articles don't get a `common-tasks/` subfolder. See [Decision 11](../decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials) in the Project Map.
- *Run the pre-submit checklist before opening the PR* rather than leaving it for a late review pass. Confirm that every output-producing sample shows its result as a trailing `// => …` comment; that equivalent samples have matching output; that samples saturate the everyday-feature set even when those features aren't the topic; that no contextual keyword is used as an identifier; that every newly introduced term is defined at first use; that headings avoid gerund (`-ing`) forms unless the official term requires one; and that each article's structure and required metadata match the template for its content type.
- *Every PR leaves its section coherent.* After a PR merges, the section it touches must be publishable: no placeholder or "coming soon"/"TODO"/stub articles, no empty or orphaned TOC nodes, and no broken links. If a subtopic can't be finished in the PR, leave it out of both the article and the TOC rather than shipping a stub.
- *Place or reorder a TOC node only when its backing content is live in the same PR.* Never insert a TOC node ahead of the article that fills it, and never move a section into its final Option A position until the moved content is live. When a PR reorders nodes (for example, lifting Patterns §11 above Expressions §12 and Statements §13), it names the prerequisite PR that made the moved content live.

## Plan index — PRs by phase

This plan is split by phase for easier navigation. The conventions above apply to **every** PR.

| Phase | Scope | PRs |
|---|---|---|
| [A — Program structure (§7)](phase-a-program-structure.md) | Namespaces, preprocessor, CommandLine tutorial | PR 1–2 |
| [B — Type system (§8)](phase-b-type-system.md) | Built-in types, classes/structs/records, generics, conversions | PR 3–7 |
| [C — Null safety](phase-c-null-safety.md) | Nullable value types, null operators, NRT, migration | PR 8–9 |
| [D — Strings](phase-d-strings.md) | Raw strings, interpolation, search/split, compare | PR 10–12 |
| [E — Expressions & statements (§12–§13)](phase-e-expressions-statements.md) | Statements, collections, LINQ, **equality**, operators | PR 13–18 |
| [F — Pattern matching (§11) + functional (§12)](phase-f-patterns-functional.md) | Patterns, deconstruction, functional techniques | PR 19–23 |
| [G — Namespaces (§14) + OOP (§15)](phase-g-namespaces-oop.md) | OOP members, inheritance, events, lifetime | PR 24–33 |
| [H — Remaining sections](phase-h-remaining.md) | Async, attributes, XML docs, analyzers, exceptions | PR 34–38 |
| [Verification & decisions](verification-and-decisions.md) | Build/lint verification + running decisions log | — |

See the [Project Map](../project-map.md) for goals, decisions, feature coverage, and the target TOC.
