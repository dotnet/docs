---
title: Copy and Update Record Expressions (F#)
description: Learn how to write a 'copy and update record expression' that copies an existing record, updates specified fields, and returns the updated record.
keywords: visual f#, f#, functional programming
author: ChrSteinert
ms.author: phcart
ms.date: 06/04/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: b5fc4ef0-64eb-4272-96a7-bb4dffbb634a
---

# Copy and Update Record Expressions

A *copy and update record expression* is an expression that copies an existing record, updates specified fields, and returns the updated record.


## Syntax

```fsharp
{ record-name with
    updated-member-definitions }
```

## Remarks
Records are immutable by default, so that there is no update to an existing record possible. To create an updated record all the fields of a record would have to be specified again. To simplify this task a *copy and update record expression* can be used. This expression takes an existing record, creates a new one of the same type by using specified fields from the expression and the missing field specified by the expression.
This can be useful when you have to copy an existing record, and possibly change some of the field values.

Take for instance a newly created record.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1905.fs)]

If you were to update only on field of that record you could use the *copy and update record expression* like the following:

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1906.fs)]

## See Also
[Records](records.md)

[F# Language Reference](index.md)
