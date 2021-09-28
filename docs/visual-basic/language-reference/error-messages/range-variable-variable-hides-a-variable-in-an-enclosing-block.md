---
description: "Learn more about: BC36633: Range variable <variable> hides a variable in an enclosing block, a previously defined range variable, or an implicitly declared variable in a query expression"
title: "Range variable <variable> hides a variable in an enclosing block, a previously defined range variable, or an implicitly declared variable in a query expression"
ms.date: 07/20/2015
f1_keywords:
  - "bc36633"
  - "vbc36633"
helpviewer_keywords:
  - "BC36633"
ms.assetid: 5d5470e4-3de5-49c2-8831-1087625f4a77
---
# BC36633: Range variable \<variable> hides a variable in an enclosing block, a previously defined range variable, or an implicitly declared variable in a query expression

A range variable name specified in a `Select`, `From`, `Aggregate`, or `Let` clause duplicates the name of a range variable already specified previously in the query, or the name of a variable that is implicitly declared by the query, such as a field name or the name of an aggregate function.

 **Error ID:** BC36633

## To correct this error

- Ensure that all range variables in a particular query scope have unique names. You can enclose a query in parentheses to ensure that nested queries have a unique scope.

## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [From Clause](../queries/from-clause.md)
- [Let Clause](../queries/let-clause.md)
- [Aggregate Clause](../queries/aggregate-clause.md)
- [Select Clause](../queries/select-clause.md)
