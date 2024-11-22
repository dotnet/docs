---
title: Copy and Update Record Expressions
description: Learn how to write a 'copy and update expression' that copies an existing record or anonymous record, updates specified fields, and returns the updated record or anonymous record.
author: ChrSteinert
ms.date: 06/12/2019
---
# Copy and Update Record Expressions

A *copy and update record expression* is an expression that copies an existing record, updates specified fields, and returns the updated record.

## Syntax

```fsharp
{ record-name with
    updated-labels }

{| anonymous-record-name with
    updated-labels |}
```

## Remarks

Records and anonymous records are immutable by default, so it is not possible to update an existing record. To create an updated record all the fields of a record would have to be specified again. To simplify this task a *copy and update expression* can be used. This expression takes an existing record, creates a new one of the same type by using specified fields from the expression and the missing field specified by the expression.

This can be useful when you have to copy an existing record, and possibly change some of the field values.

Take for instance a newly created record.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1905.fs)]

To update only two fields in that record you can use the *copy and update record expression*:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1906.fs)]

## Nested Record Copy and Update

In F# 7.0 and later, the *copy and update expression* has been enhanced to support updates on nested record fields. This feature allows for more concise syntax when working with deeply nested records.

Consider the following example:

### Before

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet19061.fs)]

### After

With the new feature, you can use dot-notation to reach nested fields and update them directly:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet19062.fs)]

This syntax eliminates the need for multiple `with` expressions. Instead, it allows for specifying updates on nested fields directly, while still allowing multiple fields (even at different levels of nesting) to be updated in the same expression.

### Anonymous Records

The same syntax extension works for anonymous records as well. Additionally, you can use this syntax to copy and update regular records into anonymous ones, adding new fields in the process:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet19063.fs)]

This flexibility ensures that the same concise syntax applies whether you're working with regular or anonymous records.

## See also

- [Records](records.md)
- [Anonymous Records](anonymous-records.md)
- [F# Language Reference](index.md)
