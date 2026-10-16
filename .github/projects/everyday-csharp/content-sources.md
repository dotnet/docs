> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Content Sources for Pull Articles

Classify future pulls as canonical construct coverage or practical technique/design guidance;
their legacy location doesn't determine their final Fundamentals owner. The earlier requirement
to resolve the Functional techniques label and split before PR 22 is superseded by
[Decision 14](decisions.md#decision-14-building-software-purpose-and-initial-structure).
Building software's first practical guides are authored and accepted in open PR #56333, not merged.
The proposed later OOP split is now detailed in [Phases H-R](plan/README.md#plan-index--prs-by-phase)
for Bill's review rather than left as an unclassified Phase G inventory.

## Complete Programming Guide sweep

The [source ledger](plan/programming-guide-inventory.md) accounts for all **82** current Programming
Guide Markdown articles outside snippet trees. It separates construct teaching, Building software
extracts, specialized material retained until an advanced/reference owner is approved, and index
retirement. Every source appears once; shared extracts don't authorize premature source deletion.

[BS01-BS12](plan/phase-r-building-software.md) add actionable backlog for object roles/composition,
construction, API member shape, callbacks/events, contracts, collections, resource lifetime, failure
contracts, value/identity choices, extensions/wrappers, parsing, and preservation/retirement.
They are future roadmap tasks, **not October commitments**. Only #55930 is targeted for completion.

The source table below is an orientation summary; the per-article ledger is authoritative for the
new Programming Guide sweep and the phase plans define proposed output paths.

| Target Article | Source Location | Action |
|---|---|---|
| Namespaces and using | *No single source* | New, informed by programming guide |
| Nullable value types | `language-reference/builtin-types/nullable-value-types.md` | Adapt for Fundamentals voice |
| Nullable reference types | `tutorials/nullable-reference-types.md` + `nullable-references.md` | Consolidate |
| Resolve nullable warnings | Existing nullable warnings articles | Pull |
| Nullable migration | Existing migration articles | Pull |
| String interpolation | `tutorials/string-interpolation.md` | Pull + modernize |
| String how-tos (5 articles) | `how-to/` string articles | Pull |
| Access modifiers | `programming-guide/classes-and-structs/access-modifiers.md` | Pull + revise |
| Fields and constants | `programming-guide/classes-and-structs/fields.md` + `constants.md` | Merge + revise |
| Properties | `programming-guide/classes-and-structs/properties.md` + related | Pull + major revise for everday C# features |
| Constructors | `programming-guide/classes-and-structs/constructors.md` + related | Pull + add primary constructors |
| Methods | `programming-guide/classes-and-structs/methods.md` + `methods.md` | Merge mechanics in PR 28; extract API-shape guidance into BS03/BS04 |
| Polymorphism | Existing `fundamentals/object-oriented/` inheritance/polymorphism material; Programming Guide abstract/sealed and override/new guides | Reconcile actual existing sources in PR 29; extract design choices into BS01/BS05 |
| Interfaces | `programming-guide/interfaces/` | Pull + split declaration/implementation mechanics from design-choice guidance |
| Indexers | `programming-guide/indexers/` | Pull + add ranges/indexes |
| Events | `programming-guide/events/` (subset) | PR 44 owns basics; BS04 extracts subscription/notification choices |
| Building software overview | New cross-cutting guidance | Authored/accepted in open PR #56333 at `fundamentals/building-software/index.md`; compare behavior and communicated design intent, not a feature inventory |
| Lambda expressions | New practical guide; retain Type system introduction and Language Reference | Authored/accepted in open PR #56333 at `fundamentals/building-software/lambdas.md`; not a move of the reference article |
| Local functions | `programming-guide/classes-and-structs/local-functions.md` | Rework practical guidance at `fundamentals/building-software/local-functions.md`; delete/redirect legacy article and replace its snippets in open PR #56333 |
| Iterators | `iterators.md` + `programming-guide/concepts/iterators.md` | Consolidate practical synchronous-iterator guidance at `fundamentals/building-software/iterators.md`; delete/redirect both legacy articles and replace snippets in open PR #56333 |
| Type conversions | `programming-guide/types/` casting/conversion articles | Pull + revise |
| Async overview | `asynchronous-programming/index.md` | Pull + redirect |
| Tutorials (6 articles) | `tutorials/` section | Move into Fundamentals tutorials |

## Building software source reconciliation

Evidence: PR [#56333](https://github.com/dotnet/docs/pull/56333),
`more-everyday-csharp` head `4737e1c7fe82c91ed8e6d531a3a78a0f5e9cc11e`;
status verified 2026-10-16 as **OPEN**, `mergedAt=null`. Bill accepted the implementation task.
All migration actions below are authored in that PR, not shipped on this planning branch.

- The four articles and their snippet projects live under
  `docs/csharp/fundamentals/building-software/`. Snippet folders are
  `snippets/overview/`, `snippets/lambdas/`, `snippets/local-functions/`, and `snippets/iterators/`.
  The iterator and local-function project files move from their legacy locations; their old
  sample sources are replaced by focused `Program.cs` examples.
- `.openpublishing.redirection.csharp.json` redirects `csharp/iterators.md`,
  `csharp/programming-guide/concepts/iterators.md`, and
  `csharp/programming-guide/classes-and-structs/local-functions.md` to the new guides.
  The older `csharp/local-functions-vs-lambdas.md` redirect now targets the new local-functions
  guide directly.
- The retired `csharp/fundamentals/functional/{index,lambdas,local-functions,iterators}.md`
  destinations also redirect to Building software. These redirects preserve historical URLs;
  they don't imply a retained Functional techniques grouping.
- `docs/csharp/toc.yml` adds four direct Building software children and removes the old iterator
  and local-function entries. Inbound links are updated across Fundamentals, Concepts, the
  Programming Guide, Language Reference, tutorials, tour articles, expression trees, code-analysis
  style rules, and related samples/parallel-programming guidance. The Type system introduction
  and complete syntax references remain in place.
- The final commit changes the overview's purpose and comparison prose and lightly reframes the
  three companion articles; it doesn't alter snippets. The combined-techniques tutorial and
  remaining OOP/methods migrations remain future work.

## Sections That Will Shrink

As content is redistributed, these existing top-level sections lose articles. Programming Guide
retirement is now explicitly tracked by BS12, including advanced/reference relocation rather than
pulling every remaining article into Fundamentals. Other legacy sections retain their separate
restructuring boundaries.

| Section | Articles Moving Out | Remaining After |
|---|---|---|
| **Tutorials** | 6 (records, patterns, NRT, ranges, interpolation, console app) | REST client, LINQ tutorial (→ LINQ section) |
| **C# concepts** | Iterators consolidated in open PR #56333; Methods and delegates/events subset remain planned | Methods remains at `csharp/methods.md` in this PR; delegates/events (advanced), versioning |
| **How-to C# articles** | 5 string articles | Catch non-CLS exception |
| **C# programming guide** | All 82 articles have a ledger disposition; local functions/iterators consolidation is authored in open #56333 | Specialized variance/generic/runtime/custom-event material remains until BS12 approves new canonical homes; none of the new ledger moves is completed by this planning edit |
| **Asynchronous programming** | 1 (index/overview) | Cancellation, ConfigureAwait, parallel patterns, advanced async |

## Open Items for Future Discussion

1. **Pattern matching depth**: The comprehensive pattern matching article may need to be split into two: one covering the core concepts and most common patterns, and one covering advanced patterns (list patterns, nested positional patterns, complex combinators).
1. **Generics article scope**: The single Generics article covers consuming, basic constraints, covariance/contravariance, *and* collection expressions. This may be too much for one article.
1. **Tutorial curation**: As Fundamentals grows, some existing tutorials may become redundant with the main content. Should any tutorials be retired rather than moved?
1. **Cross-references with Language Reference**: Many Fundamentals articles will need "See also" links to the corresponding Language Reference pages for complete syntax details.
1. **Redirect strategy**: Every moved article needs a redirect from its old URL. The redirect mapping should be produced as part of each phase's execution plan.
1. **Remaining Fundamentals boundary**: Review the proposed Classes-through-Documentation-comments phases and BS01-BS12 split. Building software's approved name/initial placement remain settled. Confirm actual destinations and source preservation before executing later phases; #55930's tutorial is the only October completion target.
