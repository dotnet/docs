> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase H: Classes (§15)

Teach class and member semantics, including record classes, as the common baseline. Following the standard's teaching strategy, [Structs](phase-i-structs.md) and [Interfaces](phase-k-interfaces.md) explain their differences from classes rather than repeat the shared rules. Then link to [Building software](phase-r-building-software.md) for design choices. This redistributes the construct portions of legacy PR 25-31; it doesn't duplicate their old OOP articles.

**Canonical-home plan:** retain `fundamentals/types/classes.md` as the short class introduction. Plan `fundamentals/classes/` articles for member and inheritance depth. Retain the existing objects article where useful. Decision 16 approves this construct-first coverage; resolve exact source splits and final destinations during assigned work, after the Phase G namespace checkpoint and before concrete OOP redistribution. No live TOC change or phase start is part of this planning edit.

Reuse `fundamentals/types/records.md` for record coverage, surfaced in this Classes checkpoint rather than creating a second records article. PR 25 owns the record-class explanation; PR 39 owns the record-class/record-struct comparison in that same canonical article and the struct-specific teaching in `types/structs.md`. The early Type system overview still links to these introductions.

All source paths below are relative to `docs/csharp/`. Destinations described as proposed don't exist by virtue of this plan.

### PR 25 — Classes, objects, accessibility, fields, and constants

- Reconcile `fundamentals/types/classes.md` and `fundamentals/object-oriented/objects.md`; don't write a third definition of a class.
- Harvest `programming-guide/classes-and-structs/{members,access-modifiers,fields,constants,static-classes-and-static-class-members,nested-types}.md` plus `how-to-define-constants.md`.
- Proposed outputs: `fundamentals/classes/{index,access-modifiers,fields-constants}.md`. Define class/instance/static members, accessibility, constants versus instance state, and a small nested-type example only where it clarifies scope.
- Extract API-surface and state-visibility decisions into BS03. Preserve specialized `volatile`, fixed buffers, ref fields, and memory-model content in reference/advanced destinations rather than import it into Fundamentals.
- Done when the early class introduction routes to a single member-depth owner, examples distinguish instance/static state, and every retired source has a redirect and repaired inbound/snippet links.

#### Record classes within PR 25

- Reconcile existing `fundamentals/types/records.md`, the records tutorial, and equality guidance; retain their canonical URLs and distinct outcomes. This extends the already-shipped PR 4 coverage, not a new records introduction.
- Teach `record` / `record class` as reference types with synthesized members, positional declarations, value-based equality, and `with` expressions. Compare an ordinary class with a record class without implying record classes acquire struct/value-type copying semantics.
- Explain assignment versus a `with` copy, shared reference-valued members, and shallow copying. Positional record-class properties are init-only by default; records aren't necessarily immutable and init-only properties don't guarantee deep immutability.
- Coordinate property/constructor mechanics with PR 26/27 and record-class inheritance differences with PR 29. Link the existing equality owner rather than repeat its full lesson.
- PR 39 adds the explicit `record class` versus `record struct` comparison. Done when examples distinguish reference identity, value equality, and copying, and both phases use one records owner instead of competing guides.

### PR 26 — Properties

- Harvest `programming-guide/classes-and-structs/{properties,auto-implemented-properties,using-properties,restricting-accessor-accessibility}.md` and `how-to-declare-and-use-read-write-properties.md`.
- Proposed output: `fundamentals/classes/properties.md`. Cover accessors, auto/computed/field-backed properties, `init`, `required`, and accessor accessibility using released syntax.
- Extract state validation, computed versus stored values, and mutation choices into BS03; don't conflate `required` with non-null validation or shallow readonly access with deep immutability.
- Done when one teaching article owns the mechanics and examples show initialization and subsequent mutation separately. Ref-return and interop details go to existing reference/advanced homes.

### PR 27 — Constructors and initialization mechanics

- Harvest `programming-guide/classes-and-structs/{constructors,instance-constructors,using-constructors,private-constructors,static-constructors}.md`.
- Proposed output: `fundamentals/classes/constructors.md`; link the existing primary-constructor tutorial where applicable.
- Cover instance/primary constructors, constructor chaining, initializer order at the everyday level, and recognizing static constructors. Extract constructor-versus-initializer choices and copying into BS02/BS09.
- Keep detailed runtime initialization order and module initializers in reference. Done when examples distinguish required initialization from default values and the constructors sources have one unambiguous teaching owner.

### PR 28 — Methods and arguments

- Merge useful teaching content from `methods.md`, `programming-guide/classes-and-structs/methods.md`, and `named-and-optional-arguments.md`.
- Proposed output: `fundamentals/classes/methods.md`; preserve named/optional arguments, parameter versus argument vocabulary, ordinary passing, `ref`/`out` basics, expression bodies, and released `params` collections.
- BS04 owns callback/API-shape comparisons formerly bundled as "lambdas in OOP." Don't author a second lambda guide beside PR #56333.
- Done when syntax depth links to reference, behavior-bearing examples build, and obsolete source routes and snippets are reconciled.

### PR 29 — Inheritance and dispatch mechanics

- Reconcile existing `fundamentals/object-oriented/{inheritance,polymorphism}.md` with `programming-guide/classes-and-structs/{abstract-and-sealed-classes-and-class-members,knowing-when-to-use-override-and-new-keywords}.md`.
- Proposed canonical destination: `fundamentals/classes/inheritance.md`; verify the actual existing-source set before moving it.
- Cover base/derived members, abstract/sealed, virtual/override/new, base calls, and dispatch through base references. BS01 owns inheritance versus composition; BS05 owns interface versus base-class choices.
- Include a compact covariant-return example where it clarifies a derived override's return type;
  keep the complete override constraints in reference.
- The former interface portion of PR 29 becomes [PR 41](phase-k-interfaces.md#pr-41--interface-contracts-and-implementation), not a second interfaces article.
- Done when examples show actual dispatch results and polymorphism has one owner with appropriate redirects. Compatibility/versioning detail remains deeper material.

### PR 31 — Partial types and members

- Extract the beginner subset from `programming-guide/classes-and-structs/partial-classes-and-methods.md` into proposed `fundamentals/classes/partial-types.md`.
- Explain recognizing handwritten/generated parts, matching type identity, and common partial members without teaching source-generator authoring.
- Cover partial classes/structs and recognition of partial methods, properties, events, and
  constructors using released forms; distinguish the everyday generated/handwritten boundary
  from the complete implementation/signature restrictions kept in reference.
- The former event portion moves to [PR 44](phase-m-delegates.md#pr-44--basic-events); it isn't lost or reimplemented here.
- Done when generated-code boundaries are clear and advanced generator/member restrictions retain reference coverage.

### PR 46 — Extension members

- Harvest `programming-guide/classes-and-structs/extension-methods.md`, `how-to-implement-and-call-a-custom-extension-method.md`, and `how-to-create-a-new-method-for-an-enumeration.md`.
- Proposed output: `fundamentals/classes/extensions.md`, taught with released extension-block syntax and recognition of legacy `this` syntax.
- This is the extensions portion formerly bundled in PR 30. [Phase J](phase-j-arrays-indexes-ranges.md) retains indexers and ranges. BS10 owns extension-versus-wrapper design choices.
- Done when examples explain invocation and basic lookup without importing overload-resolution internals, and enum-extension examples cross-link to the retained enum introduction.

## Dependencies and review

Enter after G; complete this class baseline before I. The review order is
PR 25 → 26 → 27 → 28 → 29 → 31 → 46. Shared mechanics require PR 25 first,
properties support constructor examples, and methods support dispatch/extension examples.
PR 31 and PR 46 have no intrinsic dependency on one another; this is a review order.
The enum example in PR 46 can use the live enum introduction, then L adds the revised cross-link.

### Article-level review units

The source lists above supply the extracts; these units make the reader outcome and sample
contract explicit without scheduling an extra article per example.

| Task | Reader can / focused snippet evidence | Shared-source hold and boundary |
|---|---|---|
| PR 25 | Declare two independent class instances, recognize shared static state, and predict access through public/private members. Contrast class assignment and a record-class `with` copy using one reference-valued member. | Preserve accessibility/field/property design extracts for BS01/BS03; keep records/equality URLs. Full nested-type rules remain reference. |
| PR 26 | Read/write/initialize a property and distinguish auto, computed, and field-backed forms. Verify `required` omission diagnostic separately from a null value and from runtime validation; show `init` versus later `set`. | `using-properties.md` contains validation, computed values, and implementation hiding for BS03; the lightweight-class source also feeds BS02/BS09. Don't retire it after accessor extraction alone. |
| PR 27 | Follow instance/primary construction and chaining; compare default state with required constructor inputs. Use the existing primary-constructor tutorial rather than create another. | Add `object-and-collection-initializers.md`, its object-initializer how-to, and `how-to-write-a-copy-constructor.md` to the source reconciliation. PR 27 owns object-initializer mechanics; collection mechanics route to PR 40/current collections, while BS02/BS06/BS09 keep their extracts. Private constructors don't justify a singleton tutorial. |
| PR 28 | Declare/call a method and predict ordinary versus `ref`/`out` argument effects. Use equivalent named/positional calls and released `params` collection calls with observable output. | Preserve supplied-behavior/API-shape extracts for BS03/BS04; overload resolution, ref-safety, and specialized parameter optimization stay reference. |
| PR 29 | Predict virtual override versus hidden-member dispatch through base/derived references. Keep the static reference type visible in both examples; show base calls and sealed/abstract boundaries. | Keep intended-extensibility extracts for BS01/BS05 and ToString representation for BS09. Versioning and inheritance-safe copy design stay advanced. |
| PR 31 | Locate a member across two partial files and distinguish generated from handwritten ownership. Use a multi-file snippet project; show released partial member forms only where their purpose is clear. | Preserve generator implementation/restriction detail through BS12; no generator-authoring tutorial or custom-event lesson. |
| PR 46 | Declare and consume an extension block and recognize equivalent legacy `this` syntax. Show namespace import and an actual instance member taking precedence, not an overload-resolution table. | Preserve “General Guidelines” ownership/limited-scope guidance for BS10 and assembly-versioning detail for advanced coverage. Don't duplicate enum mechanics or the LINQ operator tutorial. |

Use the existing type-system vocabulary, null-safety, and equality articles. Split overly large
pulls along these boundaries while retaining the historical IDs. Record preserved applied
sections in BS12 before moving sources; their new comparison articles wait for R after P.
At each exit, the planned depth article has one canonical owner, its orientation link is retained,
all moved snippet consumers are repaired, and redirects/navigation/inbound links land together.
Before moving content, resolve actual canonical destinations and extract valuable advanced text
into named reference homes. These are implementation decisions, not renewed architecture approval.
Every move follows the [shared verification contract](verification-and-decisions.md).
