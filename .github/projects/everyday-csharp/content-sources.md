> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Content Sources for Pull Articles

Classify future pulls as canonical construct coverage or practical technique/design guidance;
their legacy location doesn't determine their final Fundamentals owner. The earlier requirement
to resolve the Functional techniques label and split before PR 22 is superseded by
[Decision 14](decisions.md#decision-14-building-software-purpose-and-initial-structure).
Building software's first practical guides shipped in PR #56333 on 2026-10-19, under the
H1/TOC label **Build software**.
We adopted the later construct/design organization and task coverage on 2026-10-29 in
[Decision 16](decisions.md#decision-16-adopt-language-foundations-and-applied-guidance-as-the-governing-plan).
[Phases H-R](plan/README.md#plan-index--prs-by-phase) own that work rather than an unclassified
Phase G OOP inventory. Foundation redistribution follows the G namespace checkpoint and the
G-P execution order; substantial new applied drafting/delivery waits until P is complete
([Decision 17](decisions.md#decision-17-foundations-first-execution-and-source-harvesting)).
Exact source splits, final paths, and redirects remain implementation decisions.

## Complete Programming Guide sweep

The [source ledger](plan/programming-guide-inventory.md) accounts for all **82** Programming
Guide Markdown articles outside snippet trees at its 2026-10-16 snapshot. Two source consolidations
subsequently shipped in #56333; the remaining dispositions stay future work. It separates construct teaching, Building software
extracts, specialized material retained until an advanced/reference owner is approved, and index
retirement. Every source appears once; shared extracts don't authorize premature source deletion.

[BS01-BS12](plan/phase-r-building-software.md) add actionable backlog for object roles/composition,
construction, API member shape, callbacks/events, contracts, collections, resource lifetime, failure
contracts, value/identity choices, extensions/wrappers, parsing, and preservation/retirement.
They are future roadmap tasks, **not October commitments**. The former October target #55930
shipped in #56528 on 2026-10-29.

The source table below is an orientation summary; the per-article ledger is authoritative for the
new Programming Guide sweep and the phase plans define planned output paths, not live destinations.

The [five harvesting batches](plan/phase-r-building-software.md#harvesting-batches) group the
twelve retained BS tasks into object/state design; contracts/values/extensions; behavior/sequences;
lifetime/failure/input; and retirement closeout. Their source-backed task details identify the
sections to extract, foundation mechanics to link, paired choice examples, and source-specific
retirement actions. The [shared-source holds](plan/programming-guide-inventory.md#shared-source-retirement-holds)
prevent foundation pulls from deleting material still needed by those later batches. Exact
advanced routes and conditional article splits stay explicit implementation questions.

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
| Building software overview | New cross-cutting guidance | Shipped in #56333 at `fundamentals/building-software/index.md`; compare behavior and communicated design intent, not a feature inventory |
| Lambda expressions | New practical guide; retain Type system introduction and Language Reference | Shipped in #56333 at `fundamentals/building-software/lambdas.md`; not a move of the reference article |
| Local functions | `programming-guide/classes-and-structs/local-functions.md` | Shipped at `fundamentals/building-software/local-functions.md`; legacy article deleted/redirected and snippets replaced in #56333 |
| Iterators | `iterators.md` + `programming-guide/concepts/iterators.md` | Shipped at `fundamentals/building-software/iterators.md`; both legacy articles deleted/redirected and snippets replaced in #56333 |
| Deconstruction | `fundamentals/functional/deconstruct.md` | Shipped at `fundamentals/patterns/deconstruct.md` in #56286; snippets consolidated into the patterns project, inbound links repaired |
| Pattern tutorials | `tutorials/patterns-objects.md` and the former `fundamentals/tutorials/pattern-matching.md` | Shipped in #56286 at `fundamentals/tutorials/pattern-matching-basics.md` (canal lock) and `build-algorithms-using-pattern-matching.md` (toll calculator); no pending pull to a shared slug |
| Combined-techniques tutorial | New guided badge-label program | Shipped in #56528 at `fundamentals/tutorials/functional-techniques.md`; one incremental sample, linked from Build software and Tutorials |
| Type conversions | `programming-guide/types/` casting/conversion articles | Pull + revise |
| Async overview | `asynchronous-programming/index.md` | Pull + redirect |
| Tutorials (6 articles) | `tutorials/` section | Move into Fundamentals tutorials |

## Building software source reconciliation

Evidence: PR [#56333](https://github.com/dotnet/docs/pull/56333), merged 2026-10-19 at
`7a5a9cf8549d`; status and source diff verified 2026-10-29. All migration actions below shipped
and are present on this rebased planning branch, superseding the former accepted/open status.

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
- The final review changed the H1/TOC label to **Build software**, without changing the folder
  or restoring a Functional techniques subgroup. The separate combined-techniques tutorial
  shipped in #56528; remaining OOP/methods migrations stay future work.

## Sections That Will Shrink

As content is redistributed, these existing top-level sections lose articles. Programming Guide
retirement is now explicitly tracked by BS12, including advanced/reference relocation rather than
pulling every remaining article into Fundamentals. Other legacy sections retain their separate
restructuring boundaries.

| Section | Articles Moving Out | Remaining After |
|---|---|---|
| **Tutorials** | 6 (records, patterns, NRT, ranges, interpolation, console app) | REST client, LINQ tutorial (→ LINQ section) |
| **C# concepts** | Iterators consolidated in merged #56333; Methods and delegates/events subset remain planned | Methods remains at `csharp/methods.md` in this PR; delegates/events (advanced), versioning |
| **How-to C# articles** | 5 string articles | Catch non-CLS exception |
| **C# programming guide** | All 82 snapshot articles have a ledger disposition; local functions/iterators consolidation shipped in #56333 | Specialized variance/generic/runtime/custom-event material remains until BS12 approves new canonical homes; other ledger dispositions aren't completed by this reconciliation |
| **Asynchronous programming** | 1 (index/overview) | Cancellation, ConfigureAwait, parallel patterns, advanced async |

## Open Items for Future Discussion

1. **Pattern matching depth (resolved for Phase F)**: #55966 and #56113 shipped the overview, basics, and dedicated structural-pattern articles; #56286 completed deconstruction and distinct tutorials. Any additional depth work needs a new, demonstrated gap rather than repeating the old split proposal.
1. **Generics article scope**: The single Generics article covers consuming, basic constraints, covariance/contravariance, *and* collection expressions. This may be too much for one article.
1. **Tutorial curation**: As Fundamentals grows, some existing tutorials may become redundant with the main content. Should any tutorials be retired rather than moved?
1. **Cross-references with Language Reference**: Many Fundamentals articles will need "See also" links to the corresponding Language Reference pages for complete syntax details.
1. **Redirect strategy**: Every moved article needs a redirect from its old URL. The redirect mapping should be produced as part of each phase's execution plan.
1. **Per-article implementation details**: The Classes-through-Documentation-comments phases and BS01-BS12 coverage are approved in Decision 16. Resolve exact source splits, final destinations, preservation owners, and redirects during assigned work before moves, with concrete OOP redistribution after the Phase G checkpoint. Build software's shipped placement remains settled; #55930's tutorial is complete, not the next task. Plan approval doesn't start phase work.
