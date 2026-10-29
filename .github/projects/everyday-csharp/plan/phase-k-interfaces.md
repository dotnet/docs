> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase K: Interfaces (§19)

Use Classes as the shared baseline, following the standard's strategy of describing interfaces by their differences from classes. Link shared declaration/member vocabulary; explain the interface-specific contract and implementation rules instead of building a parallel class tutorial.

### PR 41 — Interface contracts and implementation

**Retain the existing introduction:** `docs/csharp/fundamentals/types/interfaces.md`. Expand it or link a proposed `fundamentals/interfaces/implementation.md` for deeper implementation examples; decide that split before authoring, not by automatically writing both.

Harvest:

- `programming-guide/interfaces/explicit-interface-implementation.md`.
- `programming-guide/interfaces/how-to-explicitly-implement-interface-members.md`.
- `programming-guide/interfaces/how-to-explicitly-implement-members-of-two-interfaces.md`.
- `programming-guide/classes-and-structs/interface-properties.md`.
- `programming-guide/indexers/indexers-in-interfaces.md`, coordinated with PR 30.
- Consuming examples from `programming-guide/generics/generic-interfaces.md`; generic authoring and detailed variance belong in deeper material.

Work:

1. Starting from a familiar class, define the contract it implements and demonstrate using that class or a struct through an interface reference. Contrast constructing a class instance with using an interface view, no interface instance fields/instance constructors, and multiple interface inheritance versus a class's single base class. Don't turn the beginner subset into false blanket claims that interface members can't have bodies or static members; route those advanced forms to reference.
2. Explain implicit and explicit implementation, same-name member conflicts, and which member is accessible through which reference. Preserve small property/indexer examples without duplicating their accessor lessons.
3. Move the interface portion formerly in PR 29 here. Extract interface-versus-base-class and dependency-boundary decisions into BS05, not the declaration article.
4. Retain default interface implementation, static abstract members/generic math, ref-struct interface constraints, and library versioning in existing advanced/reference homes.

**Dependencies and sequence:** Enter after J, before L, using H's class/property/dispatch baseline
and J's indexers. No applied comparison is a prerequisite. Resolve the introduction/depth split
before drafting; the retained introduction remains the early Type system route.

**Review units:** (1) Contract consumption/implementation with class and struct instances;
(2) public versus explicit members and same-name conflicts; (3) shared property/indexer extracts
and source retirement. These can be reviewed separately under PR 41 without three mandatory new
articles. Reuse `explicit-interface-implementation.md`'s same-signature `Paint` example to verify
which reference exposes/calls each implementation; leave its default-implementation section in
reference/advanced coverage. The generic-interface source's constrained `SortedList<T>`/sorting
implementation isn't a required beginner sample. Prefer a small consuming example and preserve
the algorithm/authoring material through BS12.

**Shared-source exit:** PR 41 coordinates `indexers/indexers-in-interfaces.md` retirement with
PR 30; BS05 still needs its contract/API-surface extract. Record both before any deletion.
One runnable interface-view example is sufficient; don't create another OOP tutorial.

**Done when:** one canonical teaching owner explains interface-specific differences without repeating class rules, examples show implementation and interface views, all interface sources and shared snippets have a single retirement owner, and specialized content remains accessible through links and redirects.
