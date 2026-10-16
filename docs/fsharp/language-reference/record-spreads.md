---
title: Record spread operators
description: Compose F# record types and values, project fields, and override fields with record spread operators.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# Record spread operators

To share fields without merging distinct model types, use record spreads, available starting with F# 11.

Use `...Type` to contribute field declarations to a new named record, or `...expression` to contribute field values to a named or anonymous record. Declaration reuse and value mapping are independent choices.

## Compose record types

To share connection fields across configuration types, spread `Endpoint` into a new record declaration:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="RecordTypes":::

`ClientOptions` has `Host`, `Port`, and `TimeoutSeconds`. It is a distinct nominal type, not an `Endpoint` subtype.

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

A later field declaration can replace the type of a spread field. For example, represent a parsed identifier with `type CustomerId = CustomerId of System.Guid`, then distinguish an imported record from one with that identifier:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Strengthen":::

`Guid.TryParse` validates the text; the spread only copies fields. `CustomerId` distinguishes identifiers from other GUIDs without imposing further rules.

### Combine independent models

Compose declarations from a curated nominal record and an anonymous record type, then assemble values from independent sources:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="ComposeTypes":::

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Records.fs" id="Compose":::

Named and anonymous sources supply `ProductCard`; the card then supplies anonymous view state. `CanOrder` is computed once, not recalculated when a later construction changes the counts.

### Project into a known target

A target type selects the fields to keep. Multiple sources can supply replacements:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Projection":::

`endpoint` keeps only `Host` and `Port`; `production` combines sources and explicit overrides. Explicit fields absent from the target remain errors.

An unannotated anonymous record takes all contributed fields. A named target must be inferable. Unknown sources need their own annotations, such as `(source: ClientOptions)` on a function parameter.

## Field order and overrides

Contributions are read from left to right. For a repeated field name, the **rightmost contribution wins**. The rule applies both to field declarations in types and to field values in expressions.

```fsharp
let laterHost = {| Host = "db.example.com" |}
let corrected: Endpoint = { ...local; ...laterHost; Port = 5433 }
```

After a type override, supply a value of the replacement type. Repeated explicit fields, such as `{ Host = "first"; Host = "second" }`, remain errors.

For type declarations, a winning field appears at the position of its winning contribution. Fields from a source retain their source order. This order matters for constructors and signature conformance.

### Evaluation and copying

Spread source expressions run once each, in source order, even if a later contribution replaces every field they provide:

:::code language="fsharp" source="../whats-new/snippets/fsharp-11/Stable.fs" id="Evaluation":::

Spreads create a new record with shallow field copies and the same conversions as explicit assignments. Mutable objects referenced by fields remain shared.

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
> Use type spreads only when shared evolution is intentional. A source-field change can alter the destination's public fields, constructor, attributes, or constraints without an edit to that destination.

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
