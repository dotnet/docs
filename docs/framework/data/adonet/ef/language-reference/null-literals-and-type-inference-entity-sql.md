---
description: "Learn more about: Null Literals and Type Inference (Entity SQL)"
title: "Null Literals and Type Inference (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: edd56afb-af1b-4e7d-b210-cb8998143426
---
# Null Literals and Type Inference (Entity SQL)

Null literals are compatible with any type in the Entity SQL type system. However, for the type of a null literal to be inferred correctly, Entity SQL imposes certain constraints on where a null literal can be used.

## Typed Nulls

 Typed nulls can be used anywhere. Type inference is not required for typed nulls because the type is known. For example, you can construct a null of type Int16 with the following Entity SQL construct:

 `(cast(null as Int16))`

## Free-Floating Null Literals

 Free-floating null literals can be used in the following contexts:

- As an argument to a CAST or TREAT expression. This is the recommended way to produce a typed null expression.

- As an argument to a method or a function. Standard overload rules apply.

- As one of the arguments to an arithmetic expression such as +, -, or /. The other arguments cannot be null literals, otherwise type inference is not possible.

- As any of the arguments to a logical expression (AND, OR, or NOT). All the arguments are known to be of type Boolean.

- As the argument to an IS NULL or IS NOT NULL expression.

- As one or more of the arguments to a LIKE expression. All arguments are expected to be strings.

- As one or more of the arguments to a named-type constructor.

- As one or more of the arguments to a multiset constructor. At least one argument to the multiset constructor must be an expression that is not a null literal.

- As one or more of the THEN or ELSE expressions in a CASE expression. At least one of the THEN or ELSE expressions in the CASE expression must be an expression other than a null literal.

 Free-floating null literals cannot be used in other scenarios. For example,  they cannot be used as arguments to a row constructor.

## See also

- [Entity SQL Overview](entity-sql-overview.md)
