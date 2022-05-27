---
description: "Learn more about: ISOF (Entity SQL)"
title: "ISOF (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 5b2b0d34-d0a7-4bcd-baf2-58aa8456d00b
---
# ISOF (Entity SQL)

Determines whether the type of an expression is of the specified type or one of its subtypes.

## Syntax

```sql
expression IS [ NOT ] OF ( [ ONLY ] type )
```

## Arguments

 `expression`
 Any valid query expression to determine the type of.

 NOT
 Negates the EDM.Boolean result of IS OF.

 ONLY
 Specifies that IS OF returns `true` only if `expression` is of type `type` and not any of one its subtypes.

 `type`
 The type to test `expression` against. The type must be namespace-qualified.

## Return Value

 `true` if `expression` is of type T and T is either a base type, or a derived type of `type`; null if `expression` is null at run time; otherwise, `false`.

## Remarks

 The expressions `expression IS NOT OF (type)` and `expression IS NOT OF (ONLY type)` are syntactically equivalent to `NOT (expression IS OF (type))` and `NOT (expression IS OF (ONLY type))`, respectively.

 The following table shows the behavior of `IS OF` operator over some typical- and corner patterns. All exceptions are thrown from the client side before the provider gets invoked:

|Pattern|Behavior|
|-------------|--------------|
|null IS OF (EntityType)|Throws|
|null IS OF (ComplexType)|Throws|
|null IS OF (RowType)|Throws|
|TREAT (null AS EntityType) IS OF (EntityType)|Returns DBNull|
|TREAT (null AS ComplexType) IS OF (ComplexType)|Throws|
|TREAT (null AS RowType) IS OF (RowType)|Throws|
|EntityType IS OF (EntityType)|Returns true/false|
|ComplexType IS OF (ComplexType)|Throws|
|RowType IS OF (RowType)|Throws|

## Example

 The following Entity SQL query uses the IS OF operator to determine the type of a query expression, and then uses the TREAT operator to convert an object of the type Course to a collection of objects of the type OnsiteCourse. The query is based on the [School Model](/previous-versions/dotnet/netframework-4.0/bb896300(v=vs.100)).

 [!code-sql[DP EntityServices Concepts#TREAT_ISOF]~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#treat_isof)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
