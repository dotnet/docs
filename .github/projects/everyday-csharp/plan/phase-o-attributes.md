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

**Review units:** Extract the existing tutorial's `ObsoleteAttribute` motivation/application
before its custom-class/reflection walkthrough. First teach recognizing/applying metadata;
then demonstrate the consumer with a small compiler diagnostic example and a target/argument
example. Keep intentionally diagnostic-producing code separate from ordinary successful snippets.
The custom-attribute tutorial remains an advanced canonical destination, not a retired source:
add an orientation link to the new beginner article and retain its authoring/reading outcome.
No new reflection tutorial or exhaustive compiler-recognized-attribute catalog is planned.

**Dependencies and sequence:** Enter after N, before P, using H's ordinary classes, constructors,
and properties. Coordinate L's flags and H's backing-field-target cross-links now that the
usage article is live; don't migrate their whole lessons into it.

**Done when:** a new reader can apply and recognize attributes, examples demonstrate what observes them, full syntax remains in reference, and no advanced reflection article is deleted just because a short introductory passage was extracted.
