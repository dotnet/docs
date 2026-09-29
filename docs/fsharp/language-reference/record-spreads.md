---
title: Record spread operators
description: Compose F# record types and values, project fields, and override fields with record spread operators.
ms.date: 09/29/2026
ai-usage: ai-generated
---

# Record spread operators

Starting with F# 11, record spreads let you compose records from existing record types and values. Use `...Type` to contribute field declarations to a new named record, or `...expression` to contribute field values to a named or anonymous record.

## Compose record types

To share connection fields across configuration types, spread `Endpoint` into a new record declaration:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="RecordTypes":::

`ClientOptions` has `Host`, `Port`, and `TimeoutSeconds` fields. It is a fresh nominal type: spreads don't create inheritance or structural subtyping. You can't pass `ClientOptions` where an `Endpoint` is required without constructing that value.

Multiple sources and explicit declarations can appear in the same type definition:

```fsharp
type Logging = { LogLevel: string }
type LoggedClientOptions = { ...ClientOptions; ...Logging }
```

Only record fields participate. Methods, properties that aren't record fields, and static members aren't copied. A source can be a named record or an anonymous record type, including an abbreviation for an anonymous record. The destination of a type spread must be a named record type.

## Compose record values

Copy the endpoint into client options, then use an anonymous record to replace the host:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="RecordValues":::

Expression spreads accept named or anonymous record sources and destinations, including struct records. Each destination field must receive a value. An explicit target annotation is useful when several named record types share labels.

### Strengthen a field's type

A later field declaration can replace the type of a spread field. Use that rule to model a checked value separately from its incoming representation. A private union case provides a positive-quantity type:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Quantity":::

Keep the unchanged declarations and assignments in one place, while replacing the field that needs validation:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Strengthen":::

The spread doesn't convert an `int` into a `PositiveQuantity`. The explicit replacement supplies the new value after the check succeeds. Only the quantity is validated here; product codes and prices retain their original types and values.

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="ValidationUse":::

### Combine independent models

Compose declarations from multiple records, then assemble a value from those sources:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Compose":::

The result is an immutable snapshot of the contributed field values. `CanOrder` is computed when `listing` is constructed; subsequent construction with a different `Available` value doesn't automatically recompute it.

To expose only a subset of fields, declare that target explicitly:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Project":::

### Project into a known target

A target type selects the fields to keep. Multiple sources can supply replacements:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Projection":::

A known target type determines which spread fields are used. `endpoint` keeps `Host` and `Port` but omits `TimeoutSeconds`. The `production` value combines the original options, two overridden endpoint fields, and an explicit timeout. An explicitly written field that doesn't exist on the target is still an error.

Without a target annotation, an anonymous record takes its shape from all the contributions. A named record still needs an inferable nominal type. Annotating only the target doesn't determine an unknown source's type: write `(source: ClientOptions)` on a function parameter when needed.

## Field order and overrides

Contributions are read from left to right. For a repeated field name, the **rightmost contribution wins**. The rule applies both to field declarations in types and to field values in expressions.

```fsharp
let laterHost = {| Host = "db.example.com" |}
let corrected: Endpoint = { ...local; ...laterHost; Port = 5433 }
```

A type spread can replace a field's type with a later explicit declaration. The corresponding value construction must then supply a value of that replacement type. Repeated explicit declarations or bindings remain errors; spreads don't permit `{ Host = "first"; Host = "second" }`.

For type declarations, a winning field appears at the position of its winning contribution. Fields from a source retain their source order. This order matters for constructors and signature conformance.

### Evaluation and copying

Spread source expressions run once each, in source order, even if a later contribution replaces every field they provide:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Evaluation":::

The result is a new record, not a reference to the source record. Field values are copied, not deeply cloned: a field that refers to a mutable object still refers to that object. Each selected field uses the conversions and coercions that an explicit field assignment would use.

Nested field updates work with spreads, as they do with copy-and-update:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Nested":::

A later contribution to `Connection` replaces an earlier nested update to that field. Place deliberate overrides after the spreads they should override.

## Warnings about shadowed fields

A later spread can accidentally undo an explicit choice. The compiler reports these warnings by default:

| Warning | Meaning |
|---|---|
| FS3897 | A field from a type spread shadows an earlier explicit field declaration. |
| FS3898 | A field from an expression spread shadows an earlier explicit field binding. |

For example, `{ Host = "db.example.com"; ...local }` takes `Host` from `local`, not `"db.example.com"`.

For an audit of other overlaps, enable these [opt-in warnings](compiler-options.md#opt-in-warnings):

| Warning | Meaning |
|---|---|
| FS3905 | A type spread shadows a field from an earlier type spread. |
| FS3906 | An explicit field shadows a field from an earlier spread. |
| FS3907 | An expression spread shadows a field from an earlier expression spread. |

```xml
<WarnOn>$(WarnOn);3905;3906;3907</WarnOn>
```

These notices don't change rightmost-wins behavior.

## Representation and API compatibility

Type spreads copy field mutability and field-level attributes. They don't copy type-level attributes; the destination's own `[<Struct>]` attribute determines its representation. Source type arguments must satisfy the source's generic constraints, including units-of-measure constraints.

> [!IMPORTANT]
> A type spread creates a source-level dependency. Adding a source field can change the destination's public fields and constructor without an edit to the destination declaration. Changes to field attributes, mutability, constraints, or collisions can also affect callers. Use type spreads when that shared evolution is intentional.

Spreads don't bypass accessibility checks. Nullable records aren't valid spread sources; establish that a nullable value is non-null before using it. Cyclic dependencies *through spreads* are rejected. Ordinary recursive record fields aren't prohibited merely because the declaration also uses a spread.

Type spreads work in `.fsi` files. A signature can use explicit fields while the implementation uses spreads, or the reverse, provided the resulting fields and their order agree. Quotations contain the elaborated record construction, not a spread node.

## Choose spreads or copy-and-update

Use [copy-and-update expressions](copy-and-update-record-expressions.md) for a same-type update from one source. Use spreads to combine sources, project to a different record type, or reuse field declarations. Don't combine `with` and `...` in the same record expression.

Spreads don't apply to collections, object expressions, arbitrary .NET objects, or C# records. They don't provide record pattern syntax. [Record constructors](records.md#record-constructors) are a separate preview feature.

## See also

- [Records](records.md)
- [Anonymous records](anonymous-records.md)
- [What's new in F# 11](../whats-new/fsharp-11.md)
- [F# RFC FS-1151: Record spreads](https://github.com/fsharp/fslang-design/blob/main/RFCs/FS-1151-record-spreads.md)
