> Part of the [Everyday C# plan](README.md). Inventory taken 2026-10-16; future work, not an October commitment.

## Programming Guide source sweep

The checked-out `EverydayCSharp` branch contains **82 Markdown articles** under `docs/csharp/programming-guide/`, excluding snippet trees and assets. Each appears exactly once below. The sweep considered article purpose, sections, and representative content, not just numeric counts or directory names. Existing canonical teaching/reference and source code still need task-specific verification before migration.

Paths in the **Source** column are relative to `docs/csharp/programming-guide/`. Task links name the owning delivery area; the final column distinguishes practical extracts from construct coverage and advanced material. This ledger records destinations/proposals, not completed moves.

### Destination and action key

- **Extract:** harvest useful decision guidance for [BS01-BS11](phase-r-building-software.md); the remaining mechanics have the phase owner named in the row.
- **Merge/move:** consolidate into the named canonical construct article, with redirects when the source is retired.
- **Retain/link:** outside beginner scope; keep the source until BS12 identifies and approves its advanced/reference replacement. This isn't a permanent endorsement of Programming Guide as a destination.
- **Retire index:** replace navigation only after all child routes are live.
- **PR 22:** moves authored in open [dotnet/docs#56333](https://github.com/dotnet/docs/pull/56333), not merged.

Use the detailed destination/task definitions in [Classes](phase-h-classes.md), [Structs](phase-i-structs.md), [Arrays and ranges](phase-j-arrays-indexes-ranges.md), [Interfaces](phase-k-interfaces.md), [Enums](phase-l-enums.md), [Delegates](phase-m-delegates.md), and [Building software](phase-r-building-software.md). Earlier type/string/collections tasks retain their existing canonical homes; don't rewrite them just to empty a directory.

| Source | Action and task | Destination and reason |
|---|---|---|
| `classes-and-structs/abstract-and-sealed-classes-and-class-members.md` | Merge PR 29; extract BS01/BS05 | Inheritance mechanics in Classes; extending behavior versus a capability/collaborator in Building software. |
| `classes-and-structs/access-modifiers.md` | Merge PR 25; extract BS01/BS03 | Class/member accessibility versus intentionally exposed API surface. |
| `classes-and-structs/anonymous-types.md` | Retain/link, BS12 | Reference/LINQ owner to confirm; anonymous types remain excluded from Fundamentals. No new beginner anonymous-type article. |
| `classes-and-structs/auto-implemented-properties.md` | Merge PR 26; extract BS02/BS03 | Properties mechanics, initialized data, and small encapsulated-state choices. |
| `classes-and-structs/constants.md` | Merge PR 25; extract BS03 | Fields/constants owner; distinguish a constant contract from instance state where useful. |
| `classes-and-structs/constructors.md` | Merge PR 27; extract BS02 | Constructor mechanics versus required inputs and initialization choices. |
| `classes-and-structs/extension-methods.md` | Merge PR 46; extract BS10 | Released extension syntax versus extension/wrapper/owned-member choices; deep binding rules stay reference. |
| `classes-and-structs/fields.md` | Merge PR 25; extract BS03 | Fields and storage choices; preserve volatile/fixed/ref-field detail outside Fundamentals. |
| `classes-and-structs/finalizers.md` | Retain advanced, BS12; extract/link BS07 | Only useful resource-lifetime orientation enters Building software; finalizer implementation remains advanced. |
| `classes-and-structs/how-to-create-a-new-method-for-an-enumeration.md` | Merge PR 46; extract BS10 | Enum extensions belong to extension mechanics/choice, with a PR 42 cross-link. |
| `classes-and-structs/how-to-declare-and-use-read-write-properties.md` | Merge PR 26; extract BS03 | Property accessors versus controlled read/write state. |
| `classes-and-structs/how-to-define-abstract-properties.md` | Merge PR 26/29; extract BS05 | Property mechanics and inheritance; a contract example only where it clarifies the choice. |
| `classes-and-structs/how-to-define-constants.md` | Merge PR 25 | One fields/constants lesson; no redundant standalone how-to. |
| `classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md` | Extract BS02/BS09; merge mechanics PR 26 | Initialization and value/identity choices; don't retain a second basic property tutorial. |
| `classes-and-structs/how-to-implement-and-call-a-custom-extension-method.md` | Merge PR 46; extract BS10 | Extension invocation and extension-versus-wrapper choice. |
| `classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer.md` | Extract BS06; merge Phase E collections | Initialization choices; preserve dictionary behavior, don't invent dictionary-expression syntax. |
| `classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer.md` | Extract BS02; merge mechanics PR 27 | Construction versus initializer work, including mutate-existing versus replace-nested-object behavior. |
| `classes-and-structs/how-to-override-the-tostring-method.md` | Extract BS09; merge mechanics PR 29 | Human-readable representation versus identity/equality; not a serialization contract. |
| `classes-and-structs/how-to-return-subsets-of-element-properties-in-a-query.md` | Extract BS06; retain LINQ/reference details via BS12 | Projection choices with named/tuple alternatives; don't import anonymous-type teaching into Fundamentals. |
| `classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md` | Merge existing types/LINQ; extract BS06 | Explain inference in the existing owner; extract only useful collection/projection choices. |
| `classes-and-structs/how-to-write-a-copy-constructor.md` | Extract BS09; merge mechanics PR 27 | Copy construction, record alternatives, and shared reference-valued state. |
| `classes-and-structs/implicitly-typed-local-variables.md` | Merge existing type-system owner; BS12 | `var` mechanics and reference restrictions; no separate Building software article just for inference. |
| `classes-and-structs/instance-constructors.md` | Merge PR 27; extract BS02 | Instance/primary-constructor mechanics and required inputs. |
| `classes-and-structs/interface-properties.md` | Merge PR 41; extract BS05 | Contract members; share property syntax with PR 26. |
| `classes-and-structs/knowing-when-to-use-override-and-new-keywords.md` | Merge PR 29; extract BS01 | Dispatch mechanics and intended extensibility; keep examples' static reference types visible. |
| `classes-and-structs/local-functions.md` | PR 22 consolidation | Building software local-functions guide; preserve open-PR status, don't plan its initial migration twice. |
| `classes-and-structs/members.md` | Merge PR 25; BS12 retirement routing | Member orientation in Classes; specialized member kinds link to their owners. |
| `classes-and-structs/methods.md` | Merge PR 28; extract BS03/BS04 | Parameters/member mechanics versus supplied behavior and API shape. |
| `classes-and-structs/named-and-optional-arguments.md` | Merge PR 28; extract BS02/BS03 if useful | Call syntax versus defaults and caller-visible contracts; overload edge rules stay reference. |
| `classes-and-structs/nested-types.md` | Merge small subset PR 25; retain detail via BS12 | Scope/encapsulation orientation, not a new nested-type design article. |
| `classes-and-structs/object-and-collection-initializers.md` | Extract BS02/BS06; merge mechanics PR 27/40 | Construction, nested object identity, and collection initialization; preserve advanced/LINQ portions separately. |
| `classes-and-structs/partial-classes-and-methods.md` | Merge subset PR 31; retain advanced via BS12 | Recognize generated/handwritten parts; generator authoring and full member restrictions stay deeper. |
| `classes-and-structs/private-constructors.md` | Merge PR 27; extract BS02 | Construction access and who may create instances; no generic singleton-pattern tutorial. |
| `classes-and-structs/properties.md` | Merge PR 26; extract BS03 | Accessor mechanics versus computed/stored/validated state and mutation. |
| `classes-and-structs/restricting-accessor-accessibility.md` | Merge PR 26; extract BS03 | Accessibility syntax versus public read/private write contract. |
| `classes-and-structs/static-classes-and-static-class-members.md` | Merge PR 25; extract BS03 | Static/instance mechanics and shared state/call shape, without a universal utility-class preference. |
| `classes-and-structs/static-constructors.md` | Merge intro PR 27; retain runtime detail via BS12 | Recognize one-time type setup; detailed execution ordering stays reference. |
| `classes-and-structs/using-constructors.md` | Merge PR 27; extract BS02 | Consolidate construction basics and initialization decisions. |
| `classes-and-structs/using-properties.md` | Merge PR 26; extract BS03 | Accessor use, computed values, validation, and hidden implementation choices. |
| `classes-and-structs/versioning-with-the-override-and-new-keywords.md` | Retain/link, BS12 | Library compatibility/versioning is advanced; ordinary dispatch is taught by PR 29. |
| `concepts/index.md` | Retire index, BS12 | Replace legacy routing only after every remaining concepts child has a live canonical route. |
| `concepts/iterators.md` | PR 22 consolidation | Building software iterators; BS06 adds contract choices later, not a duplicate iterator introduction. |
| `concepts/covariance-contravariance/creating-variant-generic-interfaces.md` | Retain/link, BS12 | Advanced generic authoring; don't pull variance-declaration rules into beginner contracts. |
| `concepts/covariance-contravariance/index.md` | Extract consuming orientation; retire index BS12 | Existing generics introduction links deeper; no new Fundamentals variance section. |
| `concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md` | Merge consuming subset PR 43; retain detail BS12 | Everyday delegate use, with variance conversions explained only as needed. |
| `concepts/covariance-contravariance/using-variance-in-delegates.md` | Retain/link, BS12 | Full custom delegate covariance/contravariance remains reference/advanced. |
| `concepts/covariance-contravariance/using-variance-in-interfaces-for-generic-collections.md` | Extract BS06/PR 41; retain detail BS12 | Consuming collection contracts; variance declaration and edge rules stay deeper. |
| `concepts/covariance-contravariance/variance-in-delegates.md` | Retain/link, BS12 | Generic/custom delegate variance, not another beginner callback guide. |
| `concepts/covariance-contravariance/variance-in-generic-interfaces.md` | Merge small consuming subset PR 41; retain detail BS12 | Interface consumption versus advanced variance rules. |
| `delegates/delegates-with-named-vs-anonymous-methods.md` | Extract BS04; merge PR 43 | Named methods and lambdas; retain anonymous-method syntax in reference rather than recommend it. |
| `delegates/how-to-combine-delegates-multicast-delegates.md` | Retain/link, BS12 | Multicast/custom delegate details remain deeper than the standard event subset. |
| `delegates/how-to-declare-instantiate-and-use-a-delegate.md` | Extract consuming subset PR 43; retain custom declarations BS12 | `Func<>`/`Action<>` and method groups first; don't erase custom-delegate reference coverage. |
| `delegates/index.md` | Merge orientation PR 43; retire index BS12 | Route the beginner introduction, applied callbacks, and complete delegate reference distinctly. |
| `delegates/using-delegates.md` | Extract BS04; merge subset PR 43; retain detail BS12 | Supplied behavior and invocation; multicast exception/return rules stay reference. |
| `events/how-to-implement-custom-event-accessors.md` | Retain/link, BS12 | Advanced event implementation; PR 44 uses the standard pattern. |
| `events/how-to-implement-interface-events.md` | Retain/link, BS12 | Explicit event contracts are a specialized extension of PR 41/44. |
| `events/how-to-raise-base-class-events-in-derived-classes.md` | Retain/link, BS12 | Advanced event extensibility; BS01 can link rather than teach the full pattern. |
| `events/how-to-subscribe-to-and-unsubscribe-from-events.md` | Extract BS04; merge PR 44 | Handler identity and subscription ownership; preserve useful examples. |
| `events/index.md` | Merge subset PR 44; retire index BS12 | Basic event orientation with advanced routes retained. |
| `generics/constraints-on-type-parameters.md` | Merge consuming subset with existing generics; retain authoring BS12 | Ordinary constraints versus advanced generic algorithms and new constraint families. |
| `generics/differences-between-cpp-templates-and-csharp-generics.md` | Retain/link, BS12 | Cross-language migration/reference niche, not universal first-month material. |
| `generics/generic-classes.md` | Extract BS06 consuming examples; retain authoring BS12 | Compare collection contracts without introducing generic data-structure implementation. |
| `generics/generic-delegates.md` | Merge consuming subset PR 43; retain authoring BS12 | Consume standard delegate types; custom generic delegate authoring remains deeper. |
| `generics/generic-interfaces.md` | Extract BS05/BS06; merge subset PR 41 | Consume generic capabilities; preserve custom-interface design details outside beginner scope. |
| `generics/generic-methods.md` | Merge existing generics/PR 28 consuming subset; retain authoring BS12 | Type inference and calls, without another advanced generic-algorithm article. |
| `generics/generic-type-parameters.md` | Merge existing generics vocabulary; retain authoring BS12 | Parameter/argument terminology at first use; fuller authoring stays deeper. |
| `generics/generics-and-arrays.md` | Extract subset PR 40; retain advanced BS12 | Array element types and generic consumption; don't import reflection/generic-array implementation detail. |
| `generics/generics-in-the-run-time.md` | Retain/link, BS12 | Runtime generic implementation is advanced, not a Building software comparison. |
| `indexers/comparison-between-properties-and-indexers.md` | Extract BS03; merge PR 30 | Member-shape choices versus mechanical property/indexer differences. |
| `indexers/index.md` | Extract BS03/BS06; merge PR 30 | Indexed lookup, dictionary/date examples, and appropriate API expectations. |
| `indexers/indexers-in-interfaces.md` | Merge PR 30/41; extract BS05 | Shared indexer/contract example with one retirement owner. |
| `indexers/using-indexers.md` | Merge PR 30; extract BS03/BS06 | Syntax and non-integer keys versus element-access contracts. |
| `interfaces/explicit-interface-implementation.md` | Merge PR 41; extract BS05 | Implementation visibility and contract choices; default-interface content stays advanced. |
| `interfaces/how-to-explicitly-implement-interface-members.md` | Merge PR 41; extract BS05 | Small explicit contract example, not a duplicate how-to after consolidation. |
| `interfaces/how-to-explicitly-implement-members-of-two-interfaces.md` | Merge PR 41; extract BS05 | Interface views/name conflicts versus caller-facing surface. |
| `strings/how-to-determine-whether-a-string-represents-a-numeric-value.md` | Extract BS08/BS11; merge existing string tasks | Expected invalid input, parsing, and validation instead of exception-driven normal control flow. |
| `strings/index.md` | Merge existing Strings; retain specialized remainder BS12 | Existing canonical string introduction owns basics; preserve niche API/performance detail separately. |
| `types/boxing-and-unboxing.md` | Merge existing conversions/PR 39 subset; extract BS09 | Ordinary value/reference behavior; deeper allocation/performance mechanics stay reference. |
| `types/casting-and-type-conversions.md` | Merge existing conversions; extract BS09 if useful | Existing type-conversion owner, not a second Building software casting tutorial. |
| `types/how-to-convert-a-byte-array-to-an-int.md` | Retain specialized route BS12; evaluate BS11 | Byte order/binary protocols aren't universal beginner parsing; preserve that information. |
| `types/how-to-convert-a-string-to-a-number.md` | Extract BS08/BS11; merge existing conversion tasks | Try-style outcomes, culture/format choice, and caller responsibility. |
| `types/how-to-convert-between-hexadecimal-strings-and-numeric-types.md` | Retain specialized route BS12; evaluate BS11 | Specialized hexadecimal/byte conversion; don't force protocol details into ordinary input parsing. |

## Retirement acceptance contract

BS12 coordinates shared-source retirement. Each delivery records the extracted paragraphs/examples, remaining owner, snippet regions, redirects, TOC updates, and repo-wide inbound links. A partial extract isn't authorization to delete the source. New advanced homes require a named destination and review before retirement.

Only the local planning files change now. The inventory neither marks PR #56333 merged nor claims these source articles have already been moved.
