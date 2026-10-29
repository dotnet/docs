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

### Execution and sample units

Enter after I; deliver PR 40 → PR 30's indexer/range concepts → the ranges tutorial if split,
then K. Existing `fundamentals/statements/collections.md` stays the first collections owner;
record the expand-versus-new-article gap decision before creating the conditional array article.

| Unit | Reader outcome and runnable evidence | Preservation / exit |
|---|---|---|
| Arrays (PR 40) | Predict fixed length, aliasing, and element defaults; contrast array assignment with a slice copy. Demonstrate a jagged shape versus a rectangular shape only as needed to recognize them. | Keep the complete array reference canonical. `generics-and-arrays.md`'s generic implementation detail gets a BS12 hold, not an automatic move into Fundamentals. |
| Indexers (PR 30) | Use/access an authored integer or text-key indexer after properties. Reuse a compact example from `indexers/using-indexers.md`; the source index's date-key example is a candidate, not its paged-data framework. | Preserve API abstraction choices from `indexers/index.md` and the property comparison for BS03/BS06. PR 41 owns the shared interface-indexer extract and final retirement coordination for that source. |
| Ranges and tutorial (PR 30) | Predict `^1`, `..`, omitted bounds, empty ranges, exclusive ends, and invalid bounds on the actual receiver. The moved tutorial produces one useful slicing result with output. | Verify array/string slice observations without introducing span internals. Redirect `tutorials/ranges-indexes.md` only when its revised tutorial and all inbound/snippet repairs land. |

**Dependencies:** H's properties/methods support authored-indexer depth; completed collections
support basic use. Current live references can supply tutorial links. Don't wait for K to teach
ordinary indexers or link a future interface destination; K later completes that cross-link.

**Done when:** examples verify boundaries and observed copy/view behavior for the demonstrated types, all Programming Guide indexer sources have owners, the tutorial has its redirect, and collection/array/indexer/range articles cross-link instead of repeating one another.
