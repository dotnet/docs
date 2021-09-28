---
description: "Learn more about: BC36599: Range variable name can be inferred only from a simple or qualified name with no arguments"
title: "Range variable name can be inferred only from a simple or qualified name with no arguments"
ms.date: 07/20/2015
f1_keywords:
  - "vbc36599"
  - "bc36599"
helpviewer_keywords:
  - "BC36599"
ms.assetid: 17763dbe-f74f-4ccb-8086-cb7e45ec4d12
---
# BC36599: Range variable name can be inferred only from a simple or qualified name with no arguments

A programming element that takes one or more arguments is included in a LINQ query. The compiler is unable to infer a range variable from that programming element.

**Error ID:** BC36599

## To correct this error

Supply an explicit variable name for the programming element, as shown in the following code:

```vb
Dim query = From var1 In collection1
            Select VariableAlias= SampleFunction(var1), var1
```

## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Select Clause](../queries/select-clause.md)
