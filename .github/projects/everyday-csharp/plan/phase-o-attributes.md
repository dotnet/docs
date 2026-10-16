> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase O: Attributes (§23)

### PR 35 — Apply and understand existing attributes

Proposed destination: `docs/csharp/fundamentals/attributes.md`.

Sources:

- `docs/csharp/advanced-topics/reflection-and-attributes/attribute-tutorial.md`.
- `docs/csharp/advanced-topics/reflection-and-attributes/index.md`.
- `docs/csharp/language-reference/attributes/` for complete syntax and recognized attributes.
- Small applicable attribute examples already present in property, enum, and exception guidance.

1. Explain metadata versus ordinary execution, applying an attribute, constructor/named arguments, and common targets at the usage level.
2. Use a few existing attributes with visible practical effects; explain the compiler/tool/runtime consumer instead of implying the annotation runs code by itself.
3. Coordinate backing-field targets with PR 26 and flags with PR 42; those examples should link rather than repeat a reference catalog.
4. Keep custom attribute class authoring, `AttributeUsage` edge rules, reflection-based reading, generic attributes, interop layout/unions, and metadata-query implementation in advanced/reference coverage. Harvest only the beginner subset, not the entire reflection tutorial.

**Dependencies:** ordinary classes, constructors, and properties vocabulary, with existing canonical links available until those phases land.

**Done when:** a new reader can apply and recognize attributes, examples demonstrate what observes them, full syntax remains in reference, and no advanced reflection article is deleted just because a short introductory passage was extracted.
