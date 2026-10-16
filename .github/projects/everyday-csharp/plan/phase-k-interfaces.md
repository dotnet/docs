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

**Dependencies:** existing class introduction/member vocabulary as the baseline; PR 26/30 when sharing migrated examples. Link current canonical class coverage until future Classes work lands. No dependence on adopting every Building software proposal.

**Done when:** one canonical teaching owner explains interface-specific differences without repeating class rules, examples show implementation and interface views, all interface sources and shared snippets have a single retirement owner, and specialized content remains accessible through links and redirects.
