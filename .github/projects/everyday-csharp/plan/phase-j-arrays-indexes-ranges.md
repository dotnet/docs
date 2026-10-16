> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase J: Arrays (§17), indexes, and ranges (§18)

Arrays precede extended indexing and slicing in the standard. Existing collections material remains the first introduction; this phase fills semantic gaps and gives indexers/ranges an explicit roadmap home.

### PR 40 — Arrays and collection semantics

- Audit existing `docs/csharp/language-reference/builtin-types/arrays.md` and the current Fundamentals collections article before proposing new text.
- Proposed compact output: `fundamentals/collections/arrays.md`, only if the existing collections teaching article can't own the missing depth without a large expansion.
- Cover fixed length, zero-based indexing, reference semantics, element default values, one-dimensional versus jagged/multidimensional shapes, and collection-expression initialization.
- Harvest `programming-guide/generics/generics-and-arrays.md` and useful initializer examples; advanced generic-array/reflection mechanics stay out of Fundamentals.
- BS06 owns array/list/dictionary/result-contract choices. Don't duplicate the collections/LINQ work already completed in Phase E.
- Done when the decision to expand an existing article versus add the proposed article is recorded, ordinary arrays have complete beginner semantics, and no new navigation node exists without live content.

### PR 30 — Indexers, index-from-end, ranges, and tutorial

This retains PR 30's indexing/ranges scope. Its old extensions component is [PR 46](phase-h-classes.md#pr-46--extension-members).

Sources relative to `docs/csharp/`:

- `programming-guide/indexers/{index,using-indexers,comparison-between-properties-and-indexers,indexers-in-interfaces}.md`.
- `tutorials/ranges-indexes.md`.
- Current collections guidance and the Language Reference's existing indexing/range articles for full rules.

Proposed outputs: `fundamentals/collections/indexers.md`, `fundamentals/collections/indexes-ranges.md`, and `fundamentals/tutorials/ranges.md`. Split the tutorial into a follow-on delivery if the move exceeds a reviewable PR.

1. Teach ordinary indexers after properties, including supported key types and accessors. Coordinate interface-member syntax with PR 41 rather than establish a second owner.
2. Teach `^` and `..`, start/end bounds, omitted bounds, and the **exclusive** range end. Distinguish a range from a collection-expression spread element.
3. Verify supported receiver types and whether a slice copies elements or represents a view; don't generalize array/string behavior to every indexable type. Span implementation details remain advanced.
4. Extract property/method/indexer API-choice comparisons and collection-return contracts into BS03/BS06. Keep the tutorial focused on concrete slicing tasks.

**Dependencies:** properties in PR 26 for authored-indexer depth; existing collections for basic use. The ranges tutorial can reuse live reference targets without waiting for every class/interface phase.

**Done when:** examples verify boundaries and observed copy/view behavior for the demonstrated types, all Programming Guide indexer sources have owners, the tutorial has its redirect, and collection/array/indexer/range articles cross-link instead of repeating one another.
