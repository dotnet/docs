> Part of the [Everyday C# plan](README.md). PR 25's framework shipped; follow-ons remain backlog.

## Phase H: Classes (§15)

Teach class and member semantics, including record classes, as the common baseline. Following the standard's teaching strategy, [Structs](phase-i-structs.md) and [Interfaces](phase-k-interfaces.md) explain their differences from classes rather than repeat the shared rules. Then link to [Building software](phase-r-building-software.md) for design choices. This redistributes the construct portions of legacy PR 25-31; it doesn't duplicate their old OOP articles.

**Canonical homes:** retain `fundamentals/types/classes.md` as the short class introduction. PR #56923 established `fundamentals/classes/` for member depth and retained `fundamentals/object-oriented/objects.md` for object references, identity, and lifetime. Later member/inheritance destinations remain proposed until their assigned work ships. Decision 16's construct-first coverage and class-first teaching remain intact; this reconciliation changes tracking only.

Reuse `fundamentals/types/records.md` for record coverage, surfaced in this Classes checkpoint rather than creating a second records article. PR 25 owns the record-class explanation; PR 39 owns the record-class/record-struct comparison in that same canonical article and the struct-specific teaching in `types/structs.md`. The early Type system overview still links to these introductions.

All source paths below are relative to `docs/csharp/`. Destinations described as proposed don't exist by virtue of this plan.

### PR 25 — Classes, objects, accessibility, fields, and constants

**✅ Framework shipped:** [#56923](https://github.com/dotnet/docs/pull/56923), merged
2026-11-25 at `35f6dec804ff3931bf200a4d9d0a9c36e049cf34`, fixes #56748.
This completes the PR 25 framework and selected articles, not all of Phase H or its source retirements.

- New articles: **Class members and instances** at `fundamentals/classes/index.md`,
  **Class accessibility** at `fundamentals/classes/access-modifiers.md`, and
  **Fields and constants** at `fundamentals/classes/fields-constants.md`.
- Revised introductions retain their URLs: **C# classes** at `fundamentals/types/classes.md`
  and **Objects - create instances of types** at `fundamentals/object-oriented/objects.md`.
  The former supplies declaration/reference basics; the latter follows references, identity,
  equality, and lifetime. Neither becomes another member-depth owner.
- Coverage includes independent instances/shared static state, reference assignment, static
  classes, a small private nested type, common/default accessibility and containing-type limits,
  field initialization, `readonly`, `const`, and `static readonly`. Combined accessibility
  modifiers and specialized fields link to reference; backing-field attributes aren't taught here.
- All three new articles, the class introduction, and the objects article share
  `fundamentals/classes/snippets/index/{Classes.csproj,Program.cs}`. The new executable targets
  `net11.0` with nullable and implicit usings enabled; there aren't separate access/fields projects.
- Deleted only `programming-guide/classes-and-structs/members.md` and
  `how-to-define-constants.md`. Their redirects target `/dotnet/csharp/fundamentals/classes`
  and `/dotnet/csharp/fundamentals/classes/fields-constants`, respectively.
  Their legacy TOC entries were removed; `fundamentals/object-oriented/index.md` now links
  to the member overview, and `how-to/index.md` links directly to the new constants section.
- The legacy `access-modifiers.md`, `fields.md`, `constants.md`,
  `static-classes-and-static-class-members.md`, and `nested-types.md` remain published with
  introductory pointers to the new articles. They weren't deleted or redirected. Applied
  API/state extracts and advanced/reference preservation remain on the
  [source holds](programming-guide-inventory.md#shared-source-retirement-holds); BS03/BS12 aren't complete.
- The live Classes TOC node sits after Namespaces and before the retained Object-oriented
  programming node, with only the three new articles (`toc.yml`, lines 167-180 at the merge).
  The early Type system entries retain
  their URLs under the names **C# classes** and **C# record types**. The target TOC's broader
  Classes grouping remains a plan, not an already-shipped navigation move.

#### Record classes within PR 25

**✅ Record-class revision shipped in #56923:** **C# record types** retains
`fundamentals/types/records.md`. It teaches positional declarations and generated members,
reference assignment, value equality, `with`, shared array references/shallow copying,
init-only versus mutable properties, deconstruction, and the record-inheritance boundary.
It links the existing equality, deconstruction, records tutorial, property/constructor,
inheritance, and reference owners rather than replace them.

The existing `fundamentals/types/snippets/records/` project gains `RecordClasses.cs`
(`Route` and `Reading`); its `Program.cs` invokes the new demo. `RecordStruct.cs` now uses
`Route` for the assignment comparison. The article retains a compact record-class/record-struct
comparison, including positional-property defaults; [PR 39](phase-i-structs.md) still owns the
deeper paired struct semantics and cross-links. PR 26/27/29 mechanics remain follow-ons.

### PR 26 — Properties

**Next article, not started here:** [#56749](https://github.com/dotnet/docs/issues/56749).

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
