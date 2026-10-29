> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase L: Enums (§20)

### PR 42 — Enumeration values, defaults, and validation

Revise the existing `docs/csharp/fundamentals/types/enums.md`; don't create another enum introduction to populate this phase. Use `language-reference/builtin-types/enum.md` for complete rules.

1. Explain named integral constants, underlying types, assigned values, aliases, default zero, and values with no declared name. Avoid implying the compiler restricts an enum variable to its named members.
2. Show switch expressions and appropriate handling of external input. Demonstrate `Enum.TryParse` separately from validating whether a value is defined or a valid combination.
3. Keep a small flags example if justified, linking to the fuller reference instead of importing a bitwise-operator tutorial.
4. Coordinate `programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration.md` with PR 46; extension mechanics are owned there. Extract enum-versus-richer-type choices into BS09 without preview union/closed-hierarchy dependencies.

**Dependencies and sequence:** Enter after K, before M, using completed types/patterns and H's
extension explanation. Cross-link attributes only when O becomes live; a small flags example
can link the current reference meanwhile, without a forward dependency on PR 35.

**Review units:** Correct the current introduction's claim that the compiler enforces named
values; pair an unnamed cast value/default zero with a named value. Then verify `TryParse`
on a named input, an unnamed numeric input, and invalid text; show the separate defined-value
check and explain why flags combinations need different validation. Keep the existing enum
article and snippet project, not a new tutorial. The enum-extension how-to remains PR 46/BS10's
shared source; L adds the consuming cross-link, not another extension lesson.

**Done when:** examples distinguish names from the full representable value set and parsing from validation; the existing URL remains canonical; no preview-only feature is required; extension and design comparisons route to their own teaching owners.
