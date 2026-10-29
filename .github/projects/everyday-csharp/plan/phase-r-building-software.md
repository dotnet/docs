> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase R: Building software growth

Building software compares valid ways to achieve a result and explains what names, code shape, scope, dependencies, and execution timing communicate to developers and coding agents. It isn't a replacement for the construct-first articles or complete Language Reference.

PR #56333 shipped the overview, lambdas, local functions, and iterators on 2026-10-19 under the H1/TOC label **Build software**. Preserve that placement; this phase plans later content, not a move of those four articles or new language-foundations homes for the three practical guides. The separate PR 23/#55930 tutorial shipped in #56528 on 2026-10-29 and doesn't depend on this backlog.

The [82-article Programming Guide inventory](programming-guide-inventory.md) is the source ledger. A source often contains both language mechanics and useful decision guidance: extract the latter, keep one canonical mechanics owner, and retire the source only after all valuable content has destinations.

**Approved task coverage (2026-10-29, Decisions 16-17):** BS01-BS12 are the active applied-guidance
and retirement plan, not started work. Article paths below are planned destinations relative to
`docs/csharp/fundamentals/building-software/`, not live link targets. Resolve exact splits, final
paths, and redirects during assigned work; conditional outputs remain conditional. Substantial
new applied drafting/delivery follows the entire G-P foundation wave, not merely the Phase G
checkpoint or the availability of an older class introduction. Use small comparisons, not large
scenario frameworks or thin "Related techniques" lists. Each article introduces a decision process,
explains alternatives with short contextual examples, and summarizes the reasoning.

### Harvesting batches

| Batch | Review order | Entry and exit |
|---|---|---|
| R1: Object and state design | BS01 (PR 33) → BS02 → BS03 | After P; H/J mechanics are live. Establish object responsibilities, valid initialization, and caller-facing member shape without repeating syntax. |
| R2: Contracts, values, and adaptation | BS05 → BS09 → BS10 | Build on R1 and H-L. Compare dependency contracts, identity/copy needs, and how to extend a type without confusing these distinct choices. |
| R3: Behavior and sequences | BS04 → BS06 | M's delegate/event lifecycle and completed collections/LINQ/iterator guidance support supplied behavior and collection-result contracts. Reuse earlier batches' API vocabulary. |
| R4: Lifetime, failure, and input | BS07 (PR 32) → BS08 → BS11 disposition | N's cleanup/handling is live. Make ownership and failure obligations explicit; keep BS11 conditional rather than create a duplicate parsing guide. |
| R5: Retirement closeout | BS12 closes remaining source/index routes | All extracts and specialized destinations for each retiring source are accepted. Close per-source holds incrementally, not a bulk delete at the end. |

BS12 begins the ledger/hold work with the first foundation source extraction, continues through
R1-R4, and isn't a thirteenth article or a blanket prerequisite to writing those batches.
The batch order is a review sequence, not a claim that every article in a batch semantically
requires every preceding article. Q is required only for an example that actually depends on its
async subset; synchronous applied examples avoid that gate.

**Source-reading basis:** The task details below use a bounded 2026-10-29 reading of representative
Programming Guide sections: initialization/nested identity, property validation, copy construction,
inheritance dispatch, explicit interface views, indexer abstraction, callbacks/subscriptions,
extension guidelines, cleanup, generic collection consumption, projections, and numeric/binary
conversion. The 82-source ledger still defines the wider scope; task entry includes auditing the
remaining sections/snippet consumers, not a claim that every final split has already been resolved.
All `programming-guide/...` and other source paths below are relative to `docs/csharp/`.

**Shared execution gate:** Each BS01-BS11 delivery first records source section → construct owner /
applied owner / advanced owner in the ledger, then implements one bounded comparison article or
the recorded merge alternative. Runnable paired examples show matching results where behavior is
equivalent and label intentional differences. Before acceptance, verify outputs, scope/access,
mutation/timing as applicable, snippet regions, metadata, live TOC navigation, depth links, and
all changed inbound/outbound links. For every retired URL choose one canonical redirect, repair
inbound links to the appropriate depth, and remove old navigation in the same delivery. If a
shared extract or advanced route is unresolved, retain the source on an explicit BS12 hold.
This isn't permission to leave Programming Guide as its permanent home.

### BS01 — Object roles, encapsulation, and composition (legacy PR 33)

- Planned `object-design.md`, absorbing the useful OOP overview and former encapsulation/composition article commitment.
- Sources: `fundamentals/object-oriented/index.md`;
  `programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md`,
  `access-modifiers.md`, `fields.md`, `properties.md`, and
  `knowing-when-to-use-override-and-new-keywords.md` in that same source directory.
- Compare delegating to a collaborator with extending a base class. Explain which behavior and dependencies each shape exposes without making "composition over inheritance" an unexplained universal rule.
- Construct mechanics stay with PR 25/26/29. Entry is R1 after P, with H's class/inheritance
  explanations complete; an older live introduction doesn't bypass this sequence.
- Harvest the abstract/sealed source's common-base-definition motivation and the override/new
  source's base-typed caller expectations. Retain its dispatch walkthrough in PR 29; don't
  turn hiding into a recommended customization mechanism. Compare a small formatter supplied
  as a collaborator with a specialized base-class formatter: identify who owns state and which
  behavior a caller can substitute. Readers and coding agents should infer intentional
  extensibility versus an implementation detail, not a universal inheritance prohibition.
- Delivery slices: reconcile the OOP overview's role with the shipped Build software overview;
  then write the focused object-design comparison. Decide keep/slim/merge for the old OOP index
  before retiring it. Its canonical redirect is unresolved until that scope comparison; member
  sources stay on hold for BS03/BS05 and their foundation owners.
- Done when comparable small examples explain ownership of state/behavior and the original OOP overview has an explicit keep/merge/redirect disposition. Don't create both `object-design.md` and the former `encapsulation-composition.md` as duplicative overviews.

### BS02 — Construction and initialization choices

- Planned `object-initialization.md`.
- Sources: `programming-guide/classes-and-structs/{constructors,instance-constructors,using-constructors,private-constructors,object-and-collection-initializers,how-to-initialize-objects-by-using-an-object-initializer,how-to-implement-a-lightweight-class-with-auto-implemented-properties}.md`.
- Compare constructor parameters/primary constructors, object initializers, `required`, and `init` for required inputs, defaults, and later mutation. Show nested initializer mutation versus replacing an existing object.
- PR 26/27 own syntax and construction order. Coordinate source extraction before either task retires shared material.
- After BS01, extract caller-required inputs, construction access, defaults, and mutation
  boundaries. The initializer source's `Property = { ... }` mutates an existing nested object;
  contrast it with assigning a new nested instance using observable identity/state. The
  lightweight-class example distinguishes get-only, private-set, and init access; correct its
  overly broad immutability framing rather than carry it into the new article.
- Use one small contact/configuration type to compare constructor inputs with initializer-set
  options; explain when a private constructor limits construction without prescribing factories
  for ordinary objects. The source's collection/anonymous-type portions aren't this lesson:
  PR 40/BS06 and LINQ/advanced preservation own those. No new initialization tutorial is required.
- Retire constructor-only sources to PR 27's canonical mechanics home after their extracts are
  accepted; `object-and-collection-initializers.md` waits for BS06 and preservation, and the
  lightweight-class source waits for BS09. Redirect each mixed source only after choosing its
  dominant retained outcome; inbound links to applied choices can target this planned article
  when it becomes live.
- Done when the same small type demonstrates alternatives and their caller-visible contract; no claim treats `required` as runtime validation, non-null enforcement, or deep immutability.

### BS03 — Fields, properties, methods, and indexers as an API

- Planned `member-design.md`.
- Sources: `programming-guide/classes-and-structs/{fields,constants,properties,using-properties,restricting-accessor-accessibility,methods,static-classes-and-static-class-members}.md`;
  `programming-guide/indexers/{index,using-indexers,comparison-between-properties-and-indexers}.md`.
- Compare exposing state, computing a property, invoking an operation, and indexing elements. Explain validation, observable cost/side effects, and the expectations created by each surface.
- PR 25/26/28/30 retain language mechanics. Avoid framework-design catalog scope or hard claims that property access is necessarily cheap/pure.
- After BS02, harvest `using-properties.md`'s validation/computation/hidden-storage rationale
  and the indexer source's “API matches its abstraction” explanation. Its table of accessor
  differences is construct material for PR 30, not the applied comparison. Replace dated
  JIT/inlining prescriptions with observable caller expectations.
- Compare a validated property, a computation method, and date/key-based lookup on a small
  measurement log; make mutation and repeated computation visible. Explain why a method name
  can communicate work/side effects and why indexing communicates element lookup. Do not copy
  the source index's paged-data implementation into Fundamentals.
- First deliver the member-choice comparison, then reconcile source tables/examples with their
  mechanics owners. Hold property sources for BS02 and indexer sources for BS05/BS06 as applicable;
  advanced paged-data/performance sections need named owners through BS12. Redirects normally
  favor the matching property/method/indexer lesson; exact mixed-source targets require section
  reconciliation, not a blanket redirect of every source to member-design.
- Done when examples show useful alternatives and their effects, with the ordinary syntax linked once rather than redefined.

### BS04 — Supplied behavior, callbacks, and notifications

- Planned `callbacks-and-events.md`; this replaces the old PR 28 "lambdas in OOP" placeholder.
- Sources: `programming-guide/delegates/{delegates-with-named-vs-anonymous-methods,using-delegates}.md`;
  `programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md`;
  applicable supplied-behavior extracts from `programming-guide/classes-and-structs/methods.md`.
- Compare a named method, lambda, injected `Func<>`/`Action<>`, and publisher-owned event notification. Build on the existing lambda/local-function guides, not another capture tutorial.
- PR 43/44 own delegate/event mechanics. Explain handler identity and ownership, without advanced event architecture, threading, weak events, or fire-and-forget.
- R3 starts here after R2. Extract named-versus-inline intent and the subscription source's
  stored-handler/unsubscribe and publisher-held-reference explanation. Use a small operation
  with a supplied predicate and a completion notification: who selects behavior, who invokes
  it, whether a result is expected, and who ends the subscription must be explicit.
- Deliver the callback comparison before its notification/lifetime counterpart, keeping one
  bounded article if they fit. Delegate assignment and event syntax link PR 43/44; capture and
  helper scope link the shipped lambda/local-function guides. The IDE/Forms walkthrough is
  preserved outside this article, and custom delegate/multicast rules stay deeper.
- Hold the subscription source until PR 44, this extract, and any UI-specific preservation route
  are complete. PR 43 coordinates named/anonymous source mechanics with BS12's custom-delegate
  preservation; redirect targets remain source-specific, not automatically this comparison.
- Done when a minimal callback and event example show who supplies behavior, who invokes it, and how a subscription ends.

### BS05 — Interface contracts, base classes, and collaborators

- Planned `contracts-and-dependencies.md`.
- Sources: `programming-guide/interfaces/{explicit-interface-implementation,how-to-explicitly-implement-interface-members,how-to-explicitly-implement-members-of-two-interfaces}.md`;
  `programming-guide/classes-and-structs/{interface-properties,abstract-and-sealed-classes-and-class-members,how-to-define-abstract-properties}.md`;
  `programming-guide/indexers/indexers-in-interfaces.md`; `programming-guide/generics/generic-interfaces.md`.
- Compare a capability contract, shared base implementation, and a collaborator. Explain public versus explicit implementation as an API-surface decision with the same observable behavior where possible.
- PR 29/41 own dispatch/implementation rules. Keep default-interface evolution, generic math, and dependency-injection framework configuration in deeper content.
- R2 begins with BS01/BS03's object/API vocabulary. Harvest the explicit-interface source's
  same-name `Paint` implementations and caller reference views; compare a public capability
  with an explicitly exposed capability using the same operation. Then contrast inheriting
  shared implementation with holding a collaborator. Explain what each dependency promises.
- The generic-interface source's consumption of `IComparable<T>` is useful orientation;
  its constrained `SortedList<T>`/BubbleSort implementation, variance declarations, and generic
  authoring aren't beginner dependency-design examples. Do not copy that framework here.
- PR 41 retains the implementation tutorial and coordinates interface-indexer retirement with
  PR 30. Hold abstract/sealed content for BS01/PR 29 and generic-interface content for BS06/BS12.
  Default implementations remain reference/advanced. Prefer construct redirects for mechanical
  how-tos; settle the generic mixed-source target only after its full preservation inventory.
- Done when examples explain how the caller's reference type changes visible operations and why each dependency boundary fits its context.

### BS06 — Collection and sequence contracts

- Planned `collection-contracts.md`.
- Sources: `programming-guide/classes-and-structs/{object-and-collection-initializers,how-to-initialize-a-dictionary-with-a-collection-initializer,how-to-return-subsets-of-element-properties-in-a-query,how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression}.md`;
  `programming-guide/indexers/{index,using-indexers}.md`;
  `programming-guide/generics/{generic-classes,generic-interfaces}.md`;
  the live `fundamentals/building-software/iterators.md`, not its retired Programming Guide source.
- Compare an array, mutable collection, read-only interface, and deferred sequence for enumeration, lookup, mutation, and when work occurs. Include compact loop versus LINQ/projection comparisons where they aid the decision.
- Reuse Phase E's collections/LINQ and PR #56333's iterator guides. Don't imply `IEnumerable<T>` guarantees deferred execution or a read-only interface freezes its underlying collection.
- Follow BS04 in R3. Separate three review slices: requested operations (enumerate/index/mutate);
  completed versus deferred results and repeat enumeration; then initialization/projection
  choices. Use one small data set and record which work/mutation is visible to the caller.
- Harvest the dictionary how-to's concrete duplicate-key difference: `Add` initialization throws
  while an index initializer replaces that key. That behavioral difference belongs in the
  comparison, not a claim that the syntaxes are interchangeable. Source projections retain
  their select-only-needed-data motivation; use a named/tuple result in Fundamentals and keep
  anonymous-type mechanics in LINQ/reference.
- Foundation prerequisites are J/K plus shipped collections/LINQ/iterators; R3 also reuses
  BS03/BS05's API/contract vocabulary. Generic collection implementation and paged indexer
  frameworks remain advanced. If the three slices don't fit one article, record the split
  before drafting rather than expand the overview into a syntax catalog.
- Close BS02/BS03/BS05 shared-source holds only after their extracts and PR 27/30/40/41 mechanics
  are live. Redirect dictionary/basic inference sources to existing collections/types as
  appropriate; the projection source awaits a preserved LINQ destination. Never re-retire
  `concepts/iterators.md`, already consolidated in #56333.
- Done when sample results and repeated enumeration/mutation observations are verified, `..` spread isn't confused with slicing, and provider internals stay in LINQ.

### BS07 — Resource ownership and lifetime (legacy PR 32)

- Planned `resource-lifetime.md`, replacing the former `object-oriented/object-lifetime.md` destination.
- Sources: `programming-guide/classes-and-structs/finalizers.md` (“Explicit release of resources”);
  `fundamentals/exceptions/{exception-handling,how-to-execute-cleanup-code-using-finally}.md`;
  existing `docs/standard/garbage-collection/{unmanaged,implementing-dispose,implementing-disposeasync}.md`
  (these last paths are repository-relative).
- Compare a caller-owned resource with an operation that creates and disposes its own resource. Use `using`/`using` declarations and a small explicit `try/finally` comparison.
- PR 38 retains exception/cleanup semantics. Finalizer authoring, `SafeHandle`, full dispose patterns, async-dispose authoring, and GC internals stay advanced.
- R4 begins here. Extract the need for deterministic release, not the finalizer source's blanket
  finalizer recommendation or runtime-dependent shutdown-output example. The existing disposal
  articles remain the canonical implementation depth; this article teaches consumer ownership.
- Compare a borrowed reader left open for its caller with an operation-owned reader disposed
  on success/failure. A small instrumented disposable can show cleanup timing deterministically;
  a short iterator-over-reader example exposes enumeration after disposal and its corrected
  ownership boundary. Link the shipped iterator guide; don't teach `yield` again.
- Deliver ownership/using comparison, then the deferred-sequence lifetime check. N/PR 38 and
  R3's sequence contract are prerequisites. Async disposal is excluded from this beginner
  outcome unless Q's consuming guidance is live; advanced authoring still stays out.
- Don't delete finalizers.md after lifting its cleanup motivation: BS12 must preserve finalizer
  semantics, runtime differences, snippets, and reference routes. Its eventual redirect belongs
  with that preserved advanced/reference outcome, not automatically resource-lifetime.
- Done when ownership is explicit, resource lifetime is observable, and no example returns a deferred sequence over an already-disposed resource without explaining/fixing that lifetime.

### BS08 — Expected failure, validation, and exceptions

- Planned `failure-contracts.md`.
- Sources: `programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md`;
  `programming-guide/types/how-to-convert-a-string-to-a-number.md`;
  retained `fundamentals/exceptions/{creating-and-throwing-exceptions,using-exceptions}.md`.
- Compare exception-based contracts with `TryParse`/Try-style results for expected invalid input; identify programmer mistakes separately from ordinary user input.
- PR 38 owns throw/catch/filter mechanics. Don't introduce a result-type library or imply exceptions should always be replaced with return values.
- After BS07, harvest the numeric-test source's important distinction: numeric-looking text may
  be outside a chosen type's range or have the wrong numeric form. Compare parsing trusted
  contract input with repeatedly receiving ordinary invalid user input; show what the caller
  checks and what exception handling would mean in each context.
- Test valid input, invalid text, overflow, and null/empty input; make culture explicit where
  it changes acceptance. Don't copy the conversion source's broad “always catch” or efficiency
  prescriptions without context. Use the same accepted values across alternatives and link
  exception syntax instead of redefining it.
- Before retirement, agree BS11's concept-versus-procedure disposition and the existing
  string/conversion owner. Both numeric sources stay on a shared hold until that decision;
  use one chosen redirect per source and repair inbound links to concept or procedure as needed.
- Done when valid/invalid input paths are tested and alternatives' caller obligations are clear.

### BS09 — Values, identity, equality, and copying

- Planned `value-and-identity-design.md`.
- Sources: `programming-guide/classes-and-structs/{how-to-write-a-copy-constructor,how-to-implement-a-lightweight-class-with-auto-implemented-properties,how-to-override-the-tostring-method}.md`;
  `programming-guide/types/{boxing-and-unboxing,casting-and-type-conversions}.md`;
  retained `fundamentals/types/{classes,structs,records,tuples,enums}.md` and
  `fundamentals/expressions/equality.md`.
- Compare tuples, records, classes, and structs using value/identity needs; demonstrate shallow copying of reference-valued members and immutable-versus-mutable state without a performance prescription.
- PR 25 retains record-class mechanics, PR 39 owns struct semantics and the record-class/record-struct comparison, and PR 42 owns enums; existing equality remains canonical. BS09 builds on that class-first teaching without repeating it. A short enum-versus-richer-model comparison may use released classes/records, not preview unions.
- Follow BS05 in R2; H/I/L and BS02's initialization choices are available. Extract the copy
  how-to's explicit copy construction and inheritance caveat, but retain constructor mechanics
  in PR 27 and specialized hierarchy-copy design deeper. The lightweight-class source motivates
  controlled mutation; distinguish “caller can't set this property” from deep immutability.
- Compare identity-bearing contact/entity data with a value-like measurement/snapshot, then
  mutate a referenced member after copying to reveal shared data. Keep tuple-versus-record
  naming/equality comparisons small; don't turn this into another records/equality tutorial.
  Human-readable ToString output isn't a stable persistence/serialization format.
- Retire the lightweight-class source only with BS02/PR 26 acknowledgment; copy constructors
  coordinate PR 27, ToString PR 29, and boxing/conversions their existing owners/PR 39.
  Preserve allocation/boxing detail through BS12 rather than redirect all conversion traffic
  to this design comparison.
- Done when copying and equality observations are verified, `ToString` isn't confused with serialization, and readers can identify which data remains shared.

### BS10 — Extensions versus wrappers and owned members

- Planned `extensions-or-wrappers.md`.
- Sources: `programming-guide/classes-and-structs/{extension-methods,how-to-implement-and-call-a-custom-extension-method,how-to-create-a-new-method-for-an-enumeration}.md`.
- Compare adding discoverable syntax around an existing type, defining a member on a type you own, and wrapping a dependency to change its contract or hold state.
- PR 46 teaches released extension syntax and lookup. This article explains the choice rather than prescribing extensions for every utility method.
- Finish R2 here, after BS09. Harvest extension-methods.md's “General Guidelines” discussion of
  source ownership, limited scope, and inappropriate derivation. Compare an owned instance member,
  an extension over an external type, and a wrapper that holds state/changes the contract using
  the same small formatting/lookup operation. Tell readers and agents what each shape can
  promise, rather than call extensions actual changes to the underlying type.
- Link H/PR 46 and L/PR 42 for extension/enum mechanics; don't re-copy LINQ examples, ref receiver
  optimization, detailed binding, or assembly-versioning advice into this choice article.
- PR 46 and BS10 jointly release these sources; BS12 verifies advanced lookup/versioning
  preservation. Redirect syntax-oriented sources to the extension teaching owner and route
  design-oriented inbound links here once live. The enum how-to doesn't become a duplicate
  enum article.
- Done when examples expose the differences in state, ownership, discoverability, and unchanged underlying type behavior.

### BS11 — Parsing and conversion at program boundaries

- Proposed `common-tasks/parse-input.md` if a bounded procedural article remains useful after BS08; otherwise merge the relevant material into BS08 and existing string/conversion tasks.
- Sources: `programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value.md`;
  `programming-guide/types/{how-to-convert-a-string-to-a-number,how-to-convert-a-byte-array-to-an-int,how-to-convert-between-hexadecimal-strings-and-numeric-types}.md`.
- Use ordinary `TryParse` and explicit format/culture choices. Binary/byte-order and hexadecimal protocol details aren't universal; retain them in appropriate specialized conversion/interop homes instead of forcing them into a beginner parsing task.
- Follow BS08 in R4. First decide whether a distinct procedure adds a real outcome: obtain input,
  choose the numeric type/format/culture, handle failure, and use the accepted value. Reuse
  existing string/conversion tasks if they already own that outcome; no mandatory new article.
  If retained, run the procedure with two explicit cultures plus invalid/overflow input.
- The byte-array source depends on machine endianness and `BitConverter`; the hexadecimal
  source combines character code points, numeric parsing, floating-point bit conversion, and
  byte formatting. Record separate preservation destinations/modernization needs for those
  outcomes; a single beginner parse-input redirect would lose content. Confirm exact specialized
  destinations and shared snippet consumers during this task, with evidence, before retirement.
- Hold numeric sources for the BS08/BS11 split and specialized sources for BS12's named owners.
  Completion can be a recorded merge/disposition with no new article, provided each source's
  redirect and inbound-link destination are explicit before deletion.
- Done when the no-duplicate decision with BS08 is recorded, culture-sensitive examples are verified, and source-specific destinations preserve valuable specialized content.

### BS12 — Programming Guide retirement and preservation ledger

This is a tracking/redistribution task, not a new Fundamentals article.

- Complete the remaining per-source actions in the [inventory](programming-guide-inventory.md), including retained advanced/reference material and legacy indexes; don't repeat routes already shipped in #56333.
- Don't delete entire mixed articles after copying only their introductory paragraphs. Record each extract, remaining destination, snippets, redirect, TOC removal, and inbound-link repair.
- Advanced generic authoring/variance, runtime behavior, custom delegate/multicast rules, custom events, and compatibility/versioning are not Building software beginner articles just because they live in Programming Guide.
- Propose named advanced/reference homes before retiring retained material. No indefinite new Programming Guide destinations are introduced.
- Start the hold ledger during G-P, review it after each R batch, and close remaining legacy
  indexes in R5 only after every child has a live route. Sources with preserved advanced material
  may retire earlier once their individual gate passes; no need to wait for unrelated sources.
- Per retiring source, record source headings/example regions; PR/BS acceptance evidence;
  final canonical path; one redirect target and repaired deep links; all snippet consumers;
  TOC/index removal; and build/link results. A planned path or an extracted paragraph isn't
  acceptance evidence. The [shared-source holds](programming-guide-inventory.md#shared-source-retirement-holds)
  identify current blockers; fill exact advanced destinations during assigned work.
- Sources not examined in this bounded pass remain explicit investigation: inspect all remaining
  sections, compare candidate live reference/advanced homes, identify unique examples, and name
  an owner before proposing retirement. Report unresolved routes as holds, never “done.”
- Done when all source rows have a reviewed final owner and every actual retirement is build-clean; this will span later phases, not October.

## Delivery contract

Each task starts with the inventory's source rows and current canonical-owner check. Agree the output/split before drafting, extract mechanics and applied choices separately, preserve unique material, and validate examples, code-region references, navigation, redirects, and inbound links. Shared sources have one retirement coordinator (BS12), so an earlier extraction never authorizes deleting material another task still needs.
