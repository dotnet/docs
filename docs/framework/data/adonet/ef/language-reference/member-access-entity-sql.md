---
description: "Learn more about: . (Member Access) (Entity SQL)"
title: ". (Member Access) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 4733e3b2-3efa-4b96-b591-ac31350e96ad
---
# . (Member Access) (Entity SQL)

The dot operator (.) is the Entity SQL member access operator. You use the member access operator to yield the value of a property or field of an instance of structural conceptual model type.

## Syntax

```sql
expression.identifier
```

## Arguments

 `expression`
 An instance of a structural conceptual model type.

 `identifier`
 A property or field that belongs to an object instance.

## Remarks

 The dot (.) operator may be used to extract fields from a record, similar to extracting properties of a complex or entity type. For example, if n of type Name is a member of type Person, and p is an instance of type Person, then p.n is a legal member access expression that yields a value of type Name.

 `select p.Name.FirstName from LOB.Person as p`

## See also

- [Entity SQL Reference](entity-sql-reference.md)
