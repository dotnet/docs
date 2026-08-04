> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Content Sources for Pull Articles

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
| Methods | `programming-guide/classes-and-structs/methods.md` + `concepts/methods.md` | Merge + revise |
| Polymorphism | `programming-guide/classes-and-structs/polymorphism.md` | Merge into Inheritance |
| Interfaces (OOP) | `programming-guide/interfaces/` | Pull + revise |
| Indexers | `programming-guide/indexers/` | Pull + add ranges/indexes |
| Events | `concepts/` events articles (subset) | Pull basic subset |
| Local functions | `concepts/` + `programming-guide/` | Merge + revise |
| Iterators | `concepts/iterators.md` + `programming-guide/` | Merge + revise |
| Type conversions | `programming-guide/types/` casting/conversion articles | Pull + revise |
| Async overview | `asynchronous-programming/index.md` | Pull + redirect |
| Tutorials (6 articles) | `tutorials/` section | Move into Fundamentals tutorials |

## Sections That Will Shrink

As content moves into Fundamentals, these existing top-level sections will lose articles. They aren't eliminated as part of this plan, but tracking what moves helps plan redirects.

| Section | Articles Moving Out | Remaining After |
|---|---|---|
| **Tutorials** | 6 (records, patterns, NRT, ranges, interpolation, console app) | REST client, LINQ tutorial (→ LINQ section) |
| **C# concepts** | Methods, iterators, delegates/events subset | Delegates/events (advanced), versioning |
| **How-to C# articles** | 5 string articles | Catch non-CLS exception |
| **C# programming guide** | ~15 articles from Classes/Structs, Interfaces, Indexers, Types | Covariance, generics (advanced), strings (advanced) |
| **Asynchronous programming** | 1 (index/overview) | Cancellation, ConfigureAwait, parallel patterns, advanced async |

## Open Items for Future Discussion

1. **Pattern matching depth**: The comprehensive pattern matching article may need to be split into two: one covering the core concepts and most common patterns, and one covering advanced patterns (list patterns, nested positional patterns, complex combinators).
1. **Generics article scope**: The single Generics article covers consuming, basic constraints, covariance/contravariance, *and* collection expressions. This may be too much for one article.
1. **Tutorial curation**: As Fundamentals grows, some existing tutorials may become redundant with the main content. Should any tutorials be retired rather than moved?
1. **Cross-references with Language Reference**: Many Fundamentals articles will need "See also" links to the corresponding Language Reference pages for complete syntax details.
1. **Redirect strategy**: Every moved article needs a redirect from its old URL. The redirect mapping should be produced as part of each phase's execution plan.

