> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase R: Building software growth

Building software compares valid ways to achieve a result and explains what names, code shape, scope, dependencies, and execution timing communicate to developers and coding agents. It isn't a replacement for the construct-first articles or complete Language Reference.

PR #56333 establishes the overview, lambdas, local functions, and iterators. Preserve that approved initial placement; this phase proposes later content, not a move of those four articles. PR 23/#55930 remains separate and doesn't depend on this backlog.

The [82-article Programming Guide inventory](programming-guide-inventory.md) is the source ledger. A source often contains both language mechanics and useful decision guidance: extract the latter, keep one canonical mechanics owner, and retire the source only after all valuable content has destinations.

**All article paths below are proposed**, relative to `docs/csharp/fundamentals/building-software/`. They are design proposals for Bill's review, not live link targets. Use small comparisons, not large scenario frameworks or thin "Related techniques" lists. Each article introduces a decision process, explains alternatives with short contextual examples, and summarizes the reasoning.

### BS01 — Object roles, encapsulation, and composition (legacy PR 33)

- Proposed `object-design.md`, absorbing the useful OOP overview and former encapsulation/composition article commitment.
- Sources: `fundamentals/object-oriented/index.md`; Programming Guide abstract/sealed members, accessibility, fields/properties, and override/new guidance.
- Compare delegating to a collaborator with extending a base class. Explain which behavior and dependencies each shape exposes without making "composition over inheritance" an unexplained universal rule.
- Construct mechanics stay with PR 25/26/29. Prerequisite: live class/inheritance explanations, whether current canonical articles or their later replacements.
- Done when comparable small examples explain ownership of state/behavior and the original OOP overview has an explicit keep/merge/redirect disposition. Don't create both `object-design.md` and the former `encapsulation-composition.md` as duplicative overviews.

### BS02 — Construction and initialization choices

- Proposed `object-initialization.md`.
- Sources: Programming Guide constructors, instance/using/private constructors, object-and-collection initializers, object-initializer how-to, and lightweight-property-class how-to.
- Compare constructor parameters/primary constructors, object initializers, `required`, and `init` for required inputs, defaults, and later mutation. Show nested initializer mutation versus replacing an existing object.
- PR 26/27 own syntax and construction order. Coordinate source extraction before either task retires shared material.
- Done when the same small type demonstrates alternatives and their caller-visible contract; no claim treats `required` as runtime validation, non-null enforcement, or deep immutability.

### BS03 — Fields, properties, methods, and indexers as an API

- Proposed `member-design.md`.
- Sources: Programming Guide fields, properties/using-properties, accessor accessibility, methods, and comparison-between-properties-and-indexers.
- Compare exposing state, computing a property, invoking an operation, and indexing elements. Explain validation, observable cost/side effects, and the expectations created by each surface.
- PR 25/26/28/30 retain language mechanics. Avoid framework-design catalog scope or hard claims that property access is necessarily cheap/pure.
- Done when examples show useful alternatives and their effects, with the ordinary syntax linked once rather than redefined.

### BS04 — Supplied behavior, callbacks, and notifications

- Proposed `callbacks-and-events.md`; this replaces the old PR 28 "lambdas in OOP" placeholder.
- Sources: Programming Guide delegates-with-named-vs-anonymous-methods, using-delegates, and event subscription/unsubscription.
- Compare a named method, lambda, injected `Func<>`/`Action<>`, and publisher-owned event notification. Build on the existing lambda/local-function guides, not another capture tutorial.
- PR 43/44 own delegate/event mechanics. Explain handler identity and ownership, without advanced event architecture, threading, weak events, or fire-and-forget.
- Done when a minimal callback and event example show who supplies behavior, who invokes it, and how a subscription ends.

### BS05 — Interface contracts, base classes, and collaborators

- Proposed `contracts-and-dependencies.md`.
- Sources: Programming Guide explicit-interface examples, interface properties/indexers, abstract/sealed class members, and generic-interface consuming examples.
- Compare a capability contract, shared base implementation, and a collaborator. Explain public versus explicit implementation as an API-surface decision with the same observable behavior where possible.
- PR 29/41 own dispatch/implementation rules. Keep default-interface evolution, generic math, and dependency-injection framework configuration in deeper content.
- Done when examples explain how the caller's reference type changes visible operations and why each dependency boundary fits its context.

### BS06 — Collection and sequence contracts

- Proposed `collection-contracts.md`.
- Sources: Programming Guide object/collection initializers, dictionary initialization, indexers, generic collections/interfaces, query projections, and the iterator material already consolidated by #56333.
- Compare an array, mutable collection, read-only interface, and deferred sequence for enumeration, lookup, mutation, and when work occurs. Include compact loop versus LINQ/projection comparisons where they aid the decision.
- Reuse Phase E's collections/LINQ and PR #56333's iterator guides. Don't imply `IEnumerable<T>` guarantees deferred execution or a read-only interface freezes its underlying collection.
- Done when sample results and repeated enumeration/mutation observations are verified, `..` spread isn't confused with slicing, and provider internals stay in LINQ.

### BS07 — Resource ownership and lifetime (legacy PR 32)

- Proposed `resource-lifetime.md`, replacing the former `object-oriented/object-lifetime.md` destination.
- Sources: useful cleanup discussion in Programming Guide finalizers and current Fundamentals exceptions/finally guidance; link existing .NET disposal guidance.
- Compare a caller-owned resource with an operation that creates and disposes its own resource. Use `using`/`using` declarations and a small explicit `try/finally` comparison.
- PR 38 retains exception/cleanup semantics. Finalizer authoring, `SafeHandle`, full dispose patterns, async-dispose authoring, and GC internals stay advanced.
- Done when ownership is explicit, resource lifetime is observable, and no example returns a deferred sequence over an already-disposed resource without explaining/fixing that lifetime.

### BS08 — Expected failure, validation, and exceptions

- Proposed `failure-contracts.md`.
- Sources: Programming Guide numeric-string validation/conversion how-tos and existing exception articles.
- Compare exception-based contracts with `TryParse`/Try-style results for expected invalid input; identify programmer mistakes separately from ordinary user input.
- PR 38 owns throw/catch/filter mechanics. Don't introduce a result-type library or imply exceptions should always be replaced with return values.
- Done when valid/invalid input paths are tested and alternatives' caller obligations are clear.

### BS09 — Values, identity, equality, and copying

- Proposed `value-and-identity-design.md`.
- Sources: Programming Guide copy constructors, lightweight-property classes, ToString override, boxing/conversions, and existing types/records/equality articles.
- Compare tuples, records, classes, and structs using value/identity needs; demonstrate shallow copying of reference-valued members and immutable-versus-mutable state without a performance prescription.
- PR 25 retains record-class mechanics, PR 39 owns struct semantics and the record-class/record-struct comparison, and PR 42 owns enums; existing equality remains canonical. BS09 builds on that class-first teaching without repeating it. A short enum-versus-richer-model comparison may use released classes/records, not preview unions.
- Done when copying and equality observations are verified, `ToString` isn't confused with serialization, and readers can identify which data remains shared.

### BS10 — Extensions versus wrappers and owned members

- Proposed `extensions-or-wrappers.md`.
- Sources: Programming Guide extension members, custom-extension how-to, and enum-extension how-to.
- Compare adding discoverable syntax around an existing type, defining a member on a type you own, and wrapping a dependency to change its contract or hold state.
- PR 46 teaches released extension syntax and lookup. This article explains the choice rather than prescribing extensions for every utility method.
- Done when examples expose the differences in state, ownership, discoverability, and unchanged underlying type behavior.

### BS11 — Parsing and conversion at program boundaries

- Proposed `common-tasks/parse-input.md` if a bounded procedural article remains useful after BS08; otherwise merge the relevant material into BS08 and existing string/conversion tasks.
- Sources: Programming Guide numeric-string test, string-to-number, byte-array-to-int, and hexadecimal conversion how-tos.
- Use ordinary `TryParse` and explicit format/culture choices. Binary/byte-order and hexadecimal protocol details aren't universal; retain them in appropriate specialized conversion/interop homes instead of forcing them into a beginner parsing task.
- Done when the no-duplicate decision with BS08 is recorded, culture-sensitive examples are verified, and source-specific destinations preserve valuable specialized content.

### BS12 — Programming Guide retirement and preservation ledger

This is a tracking/redistribution task, not a new Fundamentals article.

- Complete the per-source actions in the [inventory](programming-guide-inventory.md), including retained advanced/reference material, legacy indexes, and routes already authored in open #56333.
- Don't delete entire mixed articles after copying only their introductory paragraphs. Record each extract, remaining destination, snippets, redirect, TOC removal, and inbound-link repair.
- Advanced generic authoring/variance, runtime behavior, custom delegate/multicast rules, custom events, and compatibility/versioning are not Building software beginner articles just because they live in Programming Guide.
- Propose named advanced/reference homes before retiring retained material. No indefinite new Programming Guide destinations are introduced.
- Done when all source rows have a reviewed final owner and every actual retirement is build-clean; this will span later phases, not October.

## Delivery contract

Each task starts with the inventory's source rows and current canonical-owner check. Agree the output/split before drafting, extract mechanics and applied choices separately, preserve unique material, and validate examples, code-region references, navigation, redirects, and inbound links. Shared sources have one retirement coordinator (BS12), so an earlier extraction never authorizes deleting material another task still needs.
