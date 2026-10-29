> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase I: Structs (§16)

Use Classes as the shared baseline, following the standard's strategy of explaining structs through their differences from classes. Link shared member syntax and accessibility rules rather than reteach them; focus the struct lesson on changed semantics and restrictions. This comparison describes language behavior, not a universal recommendation to choose one type form.

### PR 39 — Struct value semantics, initialization, and readonly members

**Reuse, not new coverage:** revise the existing `docs/csharp/fundamentals/types/structs.md`. Its early Type system link remains useful; render its deeper learning path at the standard-aligned Structs checkpoint rather than create `fundamentals/structs/structs.md` with duplicate content.

Sources:

- `docs/csharp/fundamentals/types/structs.md` and `records.md`.
- `docs/csharp/language-reference/builtin-types/struct.md` for complete rules.
- Applicable instance-constructor/property extracts from [Phase H](phase-h-classes.md); `programming-guide/types/boxing-and-unboxing.md` only for the ordinary value/reference distinction.

Work:

1. Contrast class/reference and struct/value semantics, including assignment/copying, reference-valued fields inside copied structs, default initialization versus `new`, parameterless constructors, auto-default behavior, readonly structs, and readonly members. Explain that structs don't declare a base class or participate in class-style inheritance, but can implement interfaces.
2. Explicitly compare `record class` and `record struct` in the existing canonical `fundamentals/types/records.md`, coordinated with PR 25's record-class coverage. Show reference versus value semantics, assignment versus shallow `with` copying, value equality, and inheritance differences. Compare positional properties: init-only by default for record classes, read/write for record structs, and init-only for `readonly record struct`. Neither record form implies deep immutability. Link this comparison from `types/structs.md` and reuse existing equality guidance rather than duplicate it.
3. Extract decisions about class/struct/record shape, immutable values, copying, and shared referenced data into BS09. Remove unsupported universal size/performance prescriptions rather than teach struct choice as a fixed byte-count rule.
4. Keep `ref struct`, ref fields, boxing-performance analysis, `in`-parameter optimization, unsafe layout, and memory-lifetime internals in reference/advanced coverage. Use examples to distinguish observable semantics from optimization claims.

**Dependencies and sequence:** Enter after H and before J. Reuse its class/type-system, records,
constructor, and equality vocabulary; PR 25/27's shared edits precede this delivery. Existing
canonical coverage remains available for source review, but isn't a reason to bypass execution order.

**Review units:** First revise `types/structs.md` for assignment, parameters, `default` versus
construction, and readonly behavior. Then update the shared `types/records.md` comparison and
its navigation/cross-links in the same coordinated delivery, or a separately reviewable follow-on
under PR 39 before J. Use one sample with an integer and a referenced mutable collection so
copying the value and sharing its referenced data are both observable. Check the existing
struct introduction's “small, lightweight”/heap framing against the semantics-focused lesson;
don't replace it with a universal allocation/performance rule. No new structs tutorial is required.
Record any boxing or design extract still needed by BS09/BS12 before retiring shared sources.

**Done when:** class rules are linked once and struct-specific differences are explicit; the existing articles retain their distinct canonical roles; examples demonstrate independent values versus shared referenced objects and `default` versus constructor behavior. A paired `record class` / `record struct` example verifies assignment, `with`, equality, and positional-property mutation; no blanket claim implies deep copying or deep immutability. Confirm actual observations with runnable examples, and update links/navigation only when content lands.
