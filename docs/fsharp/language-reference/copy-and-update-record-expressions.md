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

## See also

- [Records](records.md)
- [Anonymous Records](anonymous-records.md)
- [F# Language Reference](index.md)
